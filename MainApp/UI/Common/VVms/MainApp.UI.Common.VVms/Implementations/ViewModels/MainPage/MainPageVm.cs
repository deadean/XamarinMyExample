using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

using Library.Commands;
using Library.Types;
using Library.Extensions;

using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Data.Interfaces.Entities.Preferences;
using PhotoTransfer.Data.Interfaces.File;
using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.Services.WebService.Interfaces.Photo;
using PhotoTransfer.UI.Common.Bases;
using PhotoTransfer.UI.Common.Interfaces.DependencyBlock;
using PhotoTransfer.UI.Common.Interfaces.Image;
using PhotoTransfer.UI.Common.Interfaces.LocatorStrategies;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using PhotoTransfer.UI.Common.Interfaces.Photo;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using PhotoTransfer.UI.Common.Interfaces.SpeechRecognitionService;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages.Preferences;
using PhotoTransfer.UI.Data.Implementations.Entities.Photo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

using commonConstants = PhotoTransfer.UI.Common.Constants;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;
using MainApp.UI.Common.Interfaces.ViewModels;
using System.Collections.ObjectModel;
using MainApp.UI.Common.VVms.Implementations.ViewModels.MainPage;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.MainPage
{
	public class MainPageVm : AdvancedPageViewModelBase, IMainPageVm
	{
		#region Fields

		//private DelegateCommand mvTakePhotoCommand;
		//private DelegateCommand mvOpenPhotoCommand;
		//private AsyncCommand mvSyncPhotoCommand;
		//private AsyncCommand mvOpenPreferences;

		//private readonly IPhotoService modPhotoService;
		//private readonly IApplicationWebService modPhotoWebService;
		private readonly IInternalModelService modModelService;
		//private readonly IPreferencesService modPreferencesService;
		private readonly IMainPageLocatorStrategy<MainPageVm> modLocatorStrategy;

		#endregion

		#region Properties

		public ObservableCollection<ITabItemVm> Tabs { get; set; }

		#endregion

		#region Commands

		//public DelegateCommand OpenPhotoCommand
		//{
		//	get
		//	{
		//		return mvOpenPhotoCommand;
		//	}
		//}

		//public DelegateCommand TakePhotoCommand
		//{
		//	get
		//	{
		//		return mvTakePhotoCommand;
		//	}
		//}

		//public AsyncCommand SyncPhotoCommand
		//{
		//	get
		//	{
		//		return mvSyncPhotoCommand;
		//	}
		//}

		//public AsyncCommand OpenPreferencesCommand
		//{
		//	get
		//	{
		//		return mvOpenPreferences;
		//	}
		//}

		#endregion

		#region Ctor

		[PreferredConstructor]
		public MainPageVm(IMainPageDependencyBlock dependencyBlock, IMainPageLocatorStrategy<MainPageVm> locatorStrategy)
		{
			//mvOpenPhotoCommand = new DelegateCommand(OnOpenPhotoCommand);
			//mvTakePhotoCommand = new DelegateCommand(OnTakePhotoCommand);
			//mvSyncPhotoCommand = new AsyncCommand(OnSyncPhotoCommand);
			//mvOpenPreferences = new AsyncCommand(OnOpenPreferencesCommand);

			//modPhotoService = dependencyBlock.PhotoService;
			modModelService = dependencyBlock.ModelService;
			//modPreferencesService = dependencyBlock.PreferencesService;
			//modLocatorStrategy = locatorStrategy;
			Tabs = new ObservableCollection<ITabItemVm>();
			Tabs.Add(new TabItemControlsVm("Controls"));
			Tabs.Add(new TabItemXAMLVm("XAML features"));
			Tabs.Add(new TabItemXamarinFeaturesVm("Xamarin features"));
			Tabs.Add(new TabItemServicesVm("Services"));
		}

		protected MainPageVm(IMainPageDependencyBlock dependencyBlock)
			: this(dependencyBlock, ServiceLocator.Current.GetInstance<IMainPageLocatorStrategy<MainPageVm>>()) { }

		public MainPageVm() : this(ServiceLocator.Current.GetInstance<IMainPageDependencyBlock>()) { }

		#endregion

		#region Protected Methods

		//protected virtual Task OnNavigateOnSavingPhoto(IList<IFileSource> result)
		//{
		//	return modLocatorStrategy.OnNavigateOnSavingPhotos(this, result);
		//}

		#endregion

		#region Command Execute Handlers

		//private Task OnSyncPhotoCommand()
		//{
		//	return OnSyncPrivate();
		//}

		//protected virtual async Task OnSyncPrivate()
		//{
		//	await this.modNavigationService.NavigateAsync<MainPageVm, PageSelectPhotoForSyncVm>(this);
		//}

		//private async void OnOpenPhotoCommand()
		//{
		//	await OpenPhotoPrivate();
		//}

		//protected Task OpenPhotoPrivate()
		//{
		//	return this.modNavigationService.NavigateAsync<MainPageVm, PageSelectPhotoVm>(this);
		//}

		//private async void OnTakePhotoCommand()
		//{
		//	var result = await this.modPhotoService.GetPhotoAsync();

		//	if (result == null || !result.Any())
		//		return;			

		//	//Must be list of photos
		//	await OnNavigateOnSavingPhoto(result);
		//}

		//private async Task OnOpenPreferencesCommand()
		//{
		//	await this.modLocatorStrategy.OpenPreferences(this);
		//}

		#endregion
	}
}
