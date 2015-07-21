using GalaSoft.MvvmLight.Ioc;

using Library.Commands;
using Library.Extensions;

using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.Data.Interfaces.Entities.Preferences;
using PhotoTransfer.UI.Common.Interfaces.Dialogs;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using PhotoTransfer.Data.Constants.Language;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages.Preferences
{
	public class ListPreferenceVm : PreferenceBaseVm
	{
		#region Fields

		#region Static services

		static IPreferencesService modPreferencesService = ServiceLocator.Current.GetInstance<IPreferencesService>();

		#endregion
		
		List<string> modAllValues = new List<string>();

		#endregion

		#region Consturctors

		ListPreferenceVm(IPreference pref) : base(pref)
		{			
		}

		#endregion

		#region Properties

		public string CurrentValue 
		{
			get
			{
				return PreferenceValue;
			}

			set
			{
				PreferenceValue = value;
				this.OnPropertyChanged();
			}
		}

		public List<string> AllItems
		{
			get 
			{
				return modAllValues;
			} 
		}

		#endregion

		#region Private methods

		private async Task ResolveType()
		{			
			modAllValues.Clear();
			(await modPreferencesService.ResolvePreferenceListValues(PreferenceName)).Select(x => x.ToString()).ForEach(modAllValues.Add);
		}

		#endregion

		#region Public methods

		public static async Task<ListPreferenceVm> CreateAsync(IPreference pref)
		{
			var newListPref = new ListPreferenceVm(pref);
			await newListPref.ResolveType();
			return newListPref;
		}

		#endregion
	}
}
