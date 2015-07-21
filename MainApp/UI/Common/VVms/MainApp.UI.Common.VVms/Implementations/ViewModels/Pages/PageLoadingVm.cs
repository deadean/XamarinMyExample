using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.Common.Interfaces.Logging;
using PhotoTransfer.Data.Constants.Language;
using PhotoTransfer.Data.Enums;
using PhotoTransfer.Data.Interfaces.Translation;
using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.UI.Common.Bases;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.MainPage;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages
{
	public class PageLoadingVm : AdvancedPageViewModelBase, IPageLoadingVm
	{
		private readonly IPreferencesService modPreferenceService;
		private readonly ILogService modLogService;
		private readonly ITranslator modTranslator;

		public PageLoadingVm(IPreferencesService preferenceService, ILogService logService, ITranslator translator)
		{
			modPreferenceService = preferenceService;
			modLogService = logService;
			modTranslator = translator;			
		}
		
		public async void Load()
		{
			await ServiceLocator.Current.GetInstance<IInternalModelService>().Initialize();
			await ConfigureLanguage();
			bool isExceptionExist = await modLogService.CheckForExistingExceptions();
			await modNavigationService.NavigateAsync<PageLoadingVm, MainPageVm>(this);
		}

		private async Task ConfigureLanguage()
		{			
			var language = await modPreferenceService.GetPreference(TranslationKeys.LANGUAGE);
			modTranslator.Language = (enLanguage)Enum.Parse(typeof(enLanguage), language);
		}
	}
}
