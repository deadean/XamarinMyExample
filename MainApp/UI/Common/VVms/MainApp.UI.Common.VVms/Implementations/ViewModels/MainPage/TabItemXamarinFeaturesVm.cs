using Library.Commands;
using MainApp.UI.Common.VVms.Implementations.ViewModels.Xamarin1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.MainPage
{
	public class TabItemXamarinFeaturesVm : TabItemVm
	{

		#region Fields

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public TabItemXamarinFeaturesVm(string name)
			: base(name)
		{
			Menus.Add(new MenuItemVm("Device.StartTimer", new AsyncCommand(OnDeviceStartTimerClick)));
			Menus.Add(new MenuItemVm("TapGestureRecognizer", new AsyncCommand(OnTapGestureRecognizerClick)));
			Menus.Add(new MenuItemVm("DataBinding"
				, new AsyncCommand(async () => await this.modNavigationService.NavigateAsync<TabItemXamarinFeaturesVm, PageDataBindingVm>(this))));
		}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		private Task OnDeviceStartTimerClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemXamarinFeaturesVm, PageDeviceStartTimerVm>(this);
		}

		private Task OnTapGestureRecognizerClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemXamarinFeaturesVm, TapGestureRecognizerVm>(this);
		}

		#endregion

		#region Protected Methods

		#endregion
	}
}
