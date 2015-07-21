using GalaSoft.MvvmLight.Ioc;
using Library.Commands;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.Data.Interfaces.Entities.Preferences;
using PhotoTransfer.Data.Interfaces.Logging;
using PhotoTransfer.Services.WebService.Interfaces.Photo;
using PhotoTransfer.UI.Common.Bases;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.MainPage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages.Preferences
{
	public class PagePreferencesVm : AdvancedPageViewModelBase, IPagePreferencesVm
	{
		#region Fields

		private Action modPostSavePreferences;

		private readonly IPreferencesService modPreferencesService;
		private readonly IApplicationWebService modWebService;
		private readonly ILoggingSettings modLoggingSettings;		
		private readonly AsyncCommand modSendLogFileCommand;

		#endregion

		#region Constructors

		[PreferredConstructor]
		public PagePreferencesVm(
			IPreferencesService preferencesService, 
			//IApplicationWebService webService, 
			ILoggingSettings loggingSettings)
		{			
			modPreferencesService = preferencesService;
			//modWebService = webService;
			modLoggingSettings = loggingSettings;

			modSendLogFileCommand = new AsyncCommand(OnSendLogCommand);

			Load();
		}

		public PagePreferencesVm() 
			: this(
				ServiceLocator.Current.GetInstance<IPreferencesService>(), 
				//ServiceLocator.Current.GetInstance<IApplicationWebService>(), 
				ServiceLocator.Current.GetInstance<ILoggingSettings>())
		{
		}

		#endregion

		#region Properties

		public IList<IPreferenceVm> Preferences { get; set; }

		public Action PostSavePreferencesAction 
		{
			set
			{
				modPostSavePreferences = value;
			}
		}

		#endregion

		#region Commands

		public AsyncCommand SavePreferencesCommand
		{
			get
			{
				return new AsyncCommand(OnSavePreferences);
			}
		}

		public AsyncCommand SendLogFileCommand
		{
			get
			{
				return modSendLogFileCommand;
			}
		}

		#endregion

		#region Command Execute Handlers

		private async Task OnSendLogCommand()
		{
			try
			{
				await modWebService.UploadLogFile(modLoggingSettings.LogFile);
			}
			catch (Exception ex)
			{
				this.GetLog().Write(ex);
			}
		}

		#endregion

		#region Private methods

		async void Load()
		{
			await LoadPreferences(await modPreferencesService.GetAllPreferencesAsync());
		}

		async Task OnSavePreferences()
		{
			var isAnyPreferenceChanged = false;
			
			foreach (var item in Preferences)
			{				
				isAnyPreferenceChanged &= await modPreferencesService.SavePreference(item.PreferenceName, item.PreferenceValue);
			}
			
			await SavePreferencesPrivate();
		}

		protected virtual async Task SavePreferencesPrivate()
		{
			await modNavigationService.NavigateAsync<PagePreferencesVm, MainPageVm>(this);

			if (modPostSavePreferences == null)
				return;

			modPostSavePreferences();			
		}
		
		#endregion

		#region Public methods
		
		private async Task LoadPreferences(IEnumerable<IPreference> preferences)
		{
			Preferences = new List<IPreferenceVm>();

			foreach (var item in preferences)
			{
				Preferences.Add(await PreferencesVmCreator.CreatePreference(item));
			}
		}		

		#endregion		
	}
}
