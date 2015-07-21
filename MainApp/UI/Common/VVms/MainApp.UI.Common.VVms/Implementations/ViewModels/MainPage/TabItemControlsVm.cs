﻿using Library.Commands;
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

		#endregion

		#region Protected Methods

		#endregion
	}
}
