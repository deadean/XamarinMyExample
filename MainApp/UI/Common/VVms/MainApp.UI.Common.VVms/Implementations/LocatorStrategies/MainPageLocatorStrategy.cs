using GalaSoft.MvvmLight.Ioc;
using Library.Types;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.Data.Interfaces.File;
using PhotoTransfer.UI.Common.Bases;
using PhotoTransfer.UI.Common.Interfaces.LocatorStrategies;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.MainPage;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.VVms.Implementations.LocatorStrategies
{
	public class MainPageLocatorStrategy<T> : LocatorStrategy, IMainPageLocatorStrategy<T>
		where T : class, INavigableAdvancedViewModelBase
	{
		#region Ctor

		public MainPageLocatorStrategy(INavigationServiceCommon navigationService)
			: base(navigationService)
		{

		}

		protected MainPageLocatorStrategy() : base(ServiceLocator.Current.GetInstance<INavigationServiceCommon>()) { }

		#endregion

		#region Public Methods

		public Task OpenPreferences(T mainPage)
		{
			return OpenPreferenciesPrivate(mainPage);
		}

		public Task OnNavigateOnSavingPhotos(T mainPage, IList<IFileSource> photos)
		{
			return OnNavigateOnSavingPhotosProtected(mainPage, photos);
		}

		#endregion

		#region Private Methods

		protected virtual Task OpenPreferenciesPrivate(T mainPage)
		{
			return this.NavigationService.NavigateAsync<T, PagePreferencesVm>(mainPage);
		}

		protected virtual Task OnNavigateOnSavingPhotosProtected(T mainPage, IList<IFileSource> photos)
		{
			return this.NavigationService.Navigate<T, PagePhotoSavingVm, IList<IFileSource>>(mainPage, photos);
		}

		#endregion
	}
}
