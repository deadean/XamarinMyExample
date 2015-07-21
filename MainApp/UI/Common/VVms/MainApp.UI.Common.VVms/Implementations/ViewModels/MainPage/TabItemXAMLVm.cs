using Library.Commands;
using MainApp.UI.Common.VVms.Implementations.ViewModels.XAML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.MainPage
{
	public class TabItemXAMLVm:TabItemVm
	{
		#region Fields

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public TabItemXAMLVm(string name)
			: base(name)
		{
			Menus.Add(new MenuItemVm("Parametered Constructor in XAML and Invocation Methods in XAML", new AsyncCommand(OnParameteredConstructorInXamlClick)));
			Menus.Add(new MenuItemVm("Device.OnPlatform in Xaml", new AsyncCommand(OnDeviceOnPlatformInXamlClick)));
			Menus.Add(new MenuItemVm("ResourceDictionary", new AsyncCommand(OnResourceDictionaryClick)));
			Menus.Add(new MenuItemVm("Styles", new AsyncCommand(OnStylesClick)));
		}
		

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		private Task OnParameteredConstructorInXamlClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemXAMLVm, PageParameteredConstructorInXamlVm>(this);
		}

		private Task OnDeviceOnPlatformInXamlClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemXAMLVm, PageDeviceOnPlatformInXamlVm>(this);
		}

		private Task OnResourceDictionaryClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemXAMLVm, PageResourceDictionaryVm>(this);
		}

		private Task OnStylesClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemXAMLVm, PageStyleVm>(this);
		}

		#endregion

		#region Protected Methods

		#endregion
	}
}
