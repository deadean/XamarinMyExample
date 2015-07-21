using PhotoTransfer.Data.Enums;
using PhotoTransfer.Data.Interfaces.Entities.Preferences;
using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using PhotoTransfer.UI.Data.Implementations.Entities.Preferences;
using PhotoTransfer.Data.Constants.Language;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TransKeys = PhotoTransfer.Data.Constants.Language.TranslationKeys;
using Configuration = PhotoTransfer.UI.Common.Constants.Constants.Configuration;
using Xamarin.Forms;
using PhotoTransfer.WP.Services.Implementations.Preferences;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

[assembly:Dependency(typeof(PreferencesService))]
namespace PhotoTransfer.WP.Services.Implementations.Preferences
{
	public class PreferencesService : IPreferencesService
	{
		#region Fields

		private List<Preference> modPreferences;
		private readonly IInternalModelService modModelService;
		private readonly Dictionary<string, IEnumerable<object>> modListValuesMappings = new Dictionary<string, IEnumerable<object>>();

		#endregion

		#region Constructors

		//Constructor for dependency service
		public PreferencesService() : this(ServiceLocator.Current.GetInstance<IInternalModelService>())
		{
		}

		[PreferredConstructor]
		public PreferencesService(IInternalModelService modelService)
		{
			modModelService = modelService;
			InitListPreferenceMappings();
		}

		private void InitListPreferenceMappings()
		{
			modListValuesMappings.Clear();
			modListValuesMappings[TransKeys.LANGUAGE] = Enum.GetValues(typeof(enLanguage)).Cast<object>();
		}

		#endregion

		#region IPreferencesService implementation

		#region Methods

		public async Task<bool> SavePreference<T>(string key, T value)
		{			
			await LoadPreferences();
			var pref = modPreferences.FirstOrDefault(x => x.Name == key);

			if (pref == null || pref.Value.Equals(value))
				return false;

			pref.Value = value.ToString();
			await SavePreferencePrivate(pref);
			return true;
		}

		public async Task<string> GetPreference(string key)
		{
			await LoadPreferences();
			return modPreferences.FirstOrDefault(x => x.Name == key).Value;
		}

		public async Task<IEnumerable<IPreference>> GetAllPreferencesAsync()
		{
			await LoadPreferences();
			return modPreferences;
		}

		public async Task ResetPreferencesToDefault()
		{
			await modModelService.ResetPrefrencesTable();
			await InitDefaultPreferences();
		}

		public async Task<IEnumerable<object>> ResolvePreferenceListValues(string key)
		{
			await LoadPreferences();
			var preference = await GetPreference(key);
			var listValues = default(IEnumerable<object>);
			modListValuesMappings.TryGetValue(key, out listValues);
			return listValues;
		}

		#endregion

		#region Events

		public event EventHandler<IPreferenceChangedEventArgs> PreferenceChanged;

		#endregion

		#endregion

		#region Private methods

		async Task AddNewPreference(string key, object value, enPreferenceType prefType = enPreferenceType.Text)
		{
			var pref = await modModelService.CreateEntity<IPreference>() as Preference;
			pref.Name = key;
			pref.Value = value.ToString();
			pref.PreferenceType = prefType;
			await modModelService.SaveEntity(pref);
			modPreferences.Add(pref);
		}

		async Task LoadPreferences()
		{
			if (modPreferences == null)
			{
				modPreferences = await modModelService.Items<Preference>();
			}

			if (modPreferences.Any())
				return;

			await InitDefaultPreferences();
		}

		async Task InitDefaultPreferences()
		{
			await AddNewPreference(TranslationKeys.WEB_SERVER_URL, Configuration.csDefaultWebServerLoadPhotoUrl);
			await AddNewPreference(TranslationKeys.LANGUAGE, Configuration.csDefaultLanguage, enPreferenceType.List);
		}

		async Task SavePreferencePrivate(IPreference preference)
		{
			await modModelService.UpdateEntityAsync(preference as Preference);
			RaisePreferenceChanged(preference);
		}

		protected virtual void RaisePreferenceChanged(IPreference preference)
		{
			RaisePreferenceChanged(preference.Name, preference.Value);
		}

		protected virtual void RaisePreferenceChanged(string name, string value)
		{
			var handler = PreferenceChanged;

			if (handler == null)
				return;

			handler(this, CreatePreferenceChangedArgs(name, value));
		}

		private IPreferenceChangedEventArgs CreatePreferenceChangedArgs(string name, string value)
		{
			IPreferenceChangedEventArgs preferencesArgs;
			
			if (value == null)
			{
				preferencesArgs = new PreferenceChangedEventArgs();
			}
			else
			{
				switch (name)
				{
					case TransKeys.LANGUAGE:
						preferencesArgs = new PreferenceChangedEventArgs<enLanguage>
						{
							Value = (enLanguage)Enum.Parse(typeof(enLanguage), value)
						};

						break;
					default:
						preferencesArgs = new PreferenceChangedEventArgs<string>
						{
							Value = value
						};

						break;
				}
			}

			preferencesArgs.PreferenceName = name;
			return preferencesArgs;
		}

		#endregion
	}
}
