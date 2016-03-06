using Library.Commands;
using MainApp.UI.Common.VVms.Implementations.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.MainPage
{
	public class TabItemControlsVm:TabItemVm
	{

		#region Fields

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public TabItemControlsVm(string name):base(name)
		{
			Menus.Add(new MenuItemVm("Working with Images", new AsyncCommand(OnImageClick)));
			Menus.Add(new MenuItemVm("CustomControls", new AsyncCommand(OnCustomControlsClick)));
			Menus.Add(new MenuItemVm("ToolBars", new AsyncCommand(OnToolBarsClick)));
			Menus.Add(new MenuItemVm("Buttons", new AsyncCommand(OnButtonsClick)));
			Menus.Add(new MenuItemVm("Absolute Layout"
				, new AsyncCommand(async () => await this.modNavigationService.NavigateAsync<TabItemControlsVm, PageAbsoluteLayoutVm>(this))));
			Menus.Add(new MenuItemVm("Slider/Stepper/Switch/Checkbox/Editor/SearchBar/DateTimePicker/Picker"
				, new AsyncCommand(async () => await this.modNavigationService.NavigateAsync<TabItemControlsVm, StandartControlsVm>(this))));
			Menus.Add(new MenuItemVm("Working with animations"
				, new AsyncCommand(async () => await this.modNavigationService.NavigateAsync<TabItemControlsVm, PageAnimationsVm>(this))));
			Menus.Add(new MenuItemVm("Working with collection views"
				, new AsyncCommand(async () => await this.modNavigationService.NavigateAsync<TabItemControlsVm, PageCollectionViewsVm>(this))));
		}
		

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		private Task OnImageClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemControlsVm, PageImageControlsVm>(this);
		}

		private Task OnCustomControlsClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemControlsVm, PageCustomControlsVm>(this);
		}

		private Task OnToolBarsClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemControlsVm, PageToolBarsVm>(this);
		}

		private Task OnButtonsClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemControlsVm, PageButtonsVm>(this);
		}

		#endregion

		#region Protected Methods

		#endregion
	}
}
