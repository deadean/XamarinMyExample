using GalaSoft.MvvmLight.Ioc;
using MainApp.Services.Interfaces.PlatformInfo;
using MainApp.UI.Common.Views.Implementations.Views.Controls;
using MainApp.UI.Common.Views.Implementations.Views.MainPage;
using MainApp.UI.Common.Views.Implementations.Views.Pages;
using MainApp.UI.Common.Views.Implementations.Views.Services;
using MainApp.UI.Common.Views.Implementations.Views.Xamarin1;
using MainApp.UI.Common.Views.Implementations.Views.XAML;
using MainApp.UI.Common.VVms.Implementations.ViewModels.Controls;
using MainApp.UI.Common.VVms.Implementations.ViewModels.MainPage;
using MainApp.UI.Common.VVms.Implementations.ViewModels.Services;
using MainApp.UI.Common.VVms.Implementations.ViewModels.Xamarin1;
using MainApp.UI.Common.VVms.Implementations.ViewModels.XAML;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.Common.Implementations.Factories;
using PhotoTransfer.Common.Interfaces.Factories;
using PhotoTransfer.Common.Interfaces.Logging;
using PhotoTransfer.Data.Interfaces.Logging;
using PhotoTransfer.Data.Interfaces.Translation;
using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.Services.WebService.Interfaces;
using PhotoTransfer.Services.WebService.Interfaces.Photo;
using PhotoTransfer.UI.Common.Interfaces.DependencyBlock;
using PhotoTransfer.UI.Common.Interfaces.Dialogs;
using PhotoTransfer.UI.Common.Interfaces.File;
using PhotoTransfer.UI.Common.Interfaces.Image;
using PhotoTransfer.UI.Common.Interfaces.LocatorStrategies;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using PhotoTransfer.UI.Common.Interfaces.Photo;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using PhotoTransfer.UI.Common.Interfaces.SpeechRecognitionService;
using PhotoTransfer.UI.Common.VVms.Implementations.DependencyBlock;
using PhotoTransfer.UI.Common.VVms.Implementations.LocatorStrategies;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.MainPage;
using PhotoTransfer.UI.Data.Implementations.Logging;
using PhotoTransfer.UI.Data.Implementations.Navigation;
using PhotoTransfer.UI.DataBases.Implementations.InternalStorage;
using PhotoTransfer.UI.DataBases.Implementations.ModelService;
using PhotoTransfer.UI.DataBases.Interfaces.DataBases;
using PhotoTransfer.WP.Services.Implementations.Image;
using PhotoTransfer.WP.Services.Implementations.Logging;
using PhotoTransfer.WP.Services.Implementations.Navigation;
using PhotoTransfer.WP.Services.Implementations.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms;
using MainApp.UI.Common.Views;
using MainApp.UI.Common.VVms;

namespace MainApp
{
	public partial class App : Application 
	{
		public App()
		{
			InitializeComponent();

			try
			{
				INavigationServiceCommon<XamarinNavigationContext<ContentPage>> navService =
				new NavigationServiceMessagingCenter<XamarinNavigationContext<ContentPage>>();

				//navService.RegisterWithExternalAction<PageLoadingVm, MainPageVm>(GetMainPage);

				SimpleIoc.Default.Register<INavigationServiceCommon>(() => navService);
				SimpleIoc.Default.Register<INavigationServiceCommon<XamarinNavigationContext<ContentPage>>>(() => navService);

				ConfigureDependencyResolves();
				Initialize();
			}
			catch (Exception ex) { }
		}


		#region Private Methods

		private void Initialize()
		{
			GetMainPage();
			//var loadingPageVm = ServiceLocator.Current.GetInstance<PageLoadingVm>();
			//var loadingPage = new PageLoading { BindingContext = loadingPageVm };

			//MainPage = new NavigationPage(loadingPage);
			//ServiceLocator.Current.GetInstance<INavigationServiceCommon<XamarinNavigationContext<ContentPage>>>()
			//	.SetNavigationContext(new XamarinNavigationContext<ContentPage>(MainPage as NavigationPage));

			//loadingPageVm.Load();
		}

		private void ConfigureDependencyResolves()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			ConfigureDependenciesByPlatform();

			ConfigureDependenciesByViewModels();

			ConfigureDependenciesByDependencyService();

			ConfigureDependencies();

			ConfigureDependencyBlocks();

			ConfigureLocatorStrategies();
		}

		private void ConfigureLocatorStrategies()
		{
			SimpleIoc.Default.Register<IMainPageLocatorStrategy<MainPageVm>, MainPageLocatorStrategy<MainPageVm>>();
		}

		private static void ConfigureDependencyBlocks()
		{
			SimpleIoc.Default.Register<IMainPageDependencyBlock, MainPageDependencyBlock>();
		}

		private static void ConfigureDependencies()
		{
			SimpleIoc.Default.Register<ILoggingSettings, LogSettings>();
			SimpleIoc.Default.Register<ILogService, LogService>();
			SimpleIoc.Default.Register<IObjectsByTypeFactory, ObjectsByTypeFactory>();
			SimpleIoc.Default.Register<IPhotoService, PhotoService>();
			//SimpleIoc.Default.Register<IApplicationWebService, ApplicationWebService>();
			SimpleIoc.Default.Register<ISQLiteDataAccessService, SQLiteDataAccessService>();
			SimpleIoc.Default.Register<IInternalStorage, InternalSQLiteStorage>();
			SimpleIoc.Default.Register<IInternalModelService, InternalModelService>();
			SimpleIoc.Default.Register<IIconsLoader, IconsLoader>();
		}

		private static void ConfigureDependenciesByDependencyService()
		{
			SimpleIoc.Default.Register<ITranslationDictionary>(() => DependencyService.Get<ITranslationDictionary>());
			SimpleIoc.Default.Register<ITranslator>(() => DependencyService.Get<ITranslator>());
			SimpleIoc.Default.Register<IPreferencesService>(() => DependencyService.Get<IPreferencesService>());
			SimpleIoc.Default.Register<IFileWorkerService>(() => DependencyService.Get<IFileWorkerService>());
			SimpleIoc.Default.Register<ISpeechRecognitionService>(() => DependencyService.Get<ISpeechRecognitionService>());
			SimpleIoc.Default.Register<IWebService>(() => DependencyService.Get<IWebService>());
			SimpleIoc.Default.Register<IImageLoader>(() => DependencyService.Get<IImageLoader>());
			SimpleIoc.Default.Register<IDialogService>(() => DependencyService.Get<IDialogService>());
			SimpleIoc.Default.Register<ISQLiteConnection>(() => DependencyService.Get<ISQLiteConnection>());
			SimpleIoc.Default.Register<IPlatformInfo>(() => DependencyService.Get<IPlatformInfo>());
		}

		private static void ConfigureDependenciesByViewModels()
		{
			SimpleIoc.Default.Register<MainPageVm>();
			//SimpleIoc.Default.Register<PageLoadingVm>();
			//SimpleIoc.Default.Register<PagePreferencesVm>();
			//SimpleIoc.Default.Register<PagePhotoSavingVm>();
			//SimpleIoc.Default.Register<PagePhotoEditingVm>();
			//SimpleIoc.Default.Register<SaveCommentsPageVm>();
			//SimpleIoc.Default.Register<PageSelectPhotoVm>();
			//SimpleIoc.Default.Register<PageSelectPhotoForSyncVm>();
		}

		private static void ConfigureDependenciesByPlatform()
		{
		}

		#region Navigation Mapping

		private void ConfigureNavigationService()
		{
			var navService = ServiceLocator.Current.GetInstance<INavigationServiceCommon<XamarinNavigationContext<ContentPage>>>();

			RegisterNavigationMapsByPlatform(navService);
			RegisterNavigationMaps(navService);
			RegisterNavigationMapsWithpopToRoot(navService);
		}

		private static void RegisterNavigationMapsWithpopToRoot(INavigationServiceCommon<XamarinNavigationContext<ContentPage>> navService)
		{
			//navService.RegisterWithPopToRoot<PagePreferencesVm, MainPageVm>();
			//navService.RegisterWithPopToRoot<SaveCommentsPageVm, MainPageVm>();
			//navService.RegisterWithPopToRoot<PagePhotoEditingVm, MainPageVm>();
			//navService.RegisterWithPopToRoot<PageMultiPhotoSavingVm, MainPageVm>();
		}

		private static void RegisterNavigationMaps(INavigationServiceCommon<XamarinNavigationContext<ContentPage>> navService)
		{
			navService.Register<TabItemControlsVm, PageImageControls, PageImageControlsVm>();
			navService.Register<TabItemControlsVm, CustomControls, PageCustomControlsVm>();
			navService.Register<TabItemControlsVm, PageToolBars, PageToolBarsVm>();
			navService.Register<TabItemControlsVm, PageButtons, PageButtonsVm>();
			navService.Register<TabItemControlsVm, PageAbsoluteLayout, PageAbsoluteLayoutVm>();
			navService.Register<TabItemControlsVm, StandartControls, StandartControlsVm>();
			navService.Register<TabItemControlsVm, PageAnimations, PageAnimationsVm>();
			navService.Register<TabItemControlsVm, PageCollectionViews, PageCollectionViewsVm>();
			navService.Register<TabItemXAMLVm, ParameteredConstructorInXaml, PageParameteredConstructorInXamlVm>();
			navService.Register<TabItemXAMLVm, PageDeviceOnPlatformInXaml, PageDeviceOnPlatformInXamlVm>();
			navService.Register<TabItemXAMLVm, PageResourceDictionary, PageResourceDictionaryVm>();
			navService.Register<TabItemXAMLVm, PageStyle, PageStyleVm>();
			navService.Register<TabItemXamarinFeaturesVm, PageDeviceStartTimer, PageDeviceStartTimerVm>();
			navService.Register<TabItemXamarinFeaturesVm, PageTapGestureRecognizer, TapGestureRecognizerVm>();
			navService.Register<TabItemXamarinFeaturesVm, PageDataBinding, PageDataBindingVm>();
			navService.Register<TabItemServicesVm, PageIPlatformInfo, PageIPlatformInfoVm>();
			navService.Register<TabItemServicesVm, PageWorkingWithFiles, PageWorkingWithFilesVm>();
			//navService.Register<MainPageVm, PageSelectPhoto, PageSelectPhotoVm>();
			//navService.Register<MainPageVm, PageSelectPhoto, PageSelectPhotoForSyncVm>();
			//navService.Register<MainPageVm, PagePreferences, PagePreferencesVm>();
			//navService.Register<MainPageVm, PagePhotoSaving, PagePhotoSavingVm, IList<IFileSource>>();
			//navService.Register<PagePhotoSavingVm, SaveCommentsPage, SaveCommentsPageVm, IList<IPhoto>>();
			//navService.Register<PagePhotoEditingVm, SaveCommentsPage, SaveCommentsPageVm, IList<IPhoto>>();
			//navService.Register<PageSelectPhotoVm, PagePhotoSaving, PagePhotoEditingVm, IList<IPhoto>>();
		}

		private void RegisterNavigationMapsByPlatform(INavigationServiceCommon<XamarinNavigationContext<ContentPage>> navService)
		{
		}

		#endregion

		private void GetMainPage()
		{
			var mainView = new MainPage
			{
				BindingContext = ServiceLocator.Current.GetInstance<MainPageVm>()
			};

			MainPage = new NavigationPage(mainView);

			ServiceLocator.Current.GetInstance<INavigationServiceCommon<XamarinNavigationContext<ContentPage>>>()
				.SetNavigationContext(new XamarinNavigationContext<ContentPage>(MainPage as NavigationPage));

			ConfigureNavigationService();
		}

		#endregion

		#region Protected Methods

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
			// Should be used here to save data from application
			// Application.Current.Properties; 
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		#endregion
	}
}
