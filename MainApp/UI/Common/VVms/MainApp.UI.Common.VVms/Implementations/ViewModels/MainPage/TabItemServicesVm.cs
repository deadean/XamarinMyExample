using Library.Commands;
using MainApp.UI.Common.VVms.Implementations.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.MainPage
{
	public class TabItemServicesVm : TabItemVm
	{
		#region Fields

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public TabItemServicesVm(string name)
			: base(name)
		{
			Menus.Add(new MenuItemVm("IPlatformInfo", new AsyncCommand(OnIPlatformInfoClick)));
			Menus.Add(new MenuItemVm("Working with files", new AsyncCommand(OnWorkingWithFilesClick)));
		}
		

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		private Task OnIPlatformInfoClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemServicesVm, PageIPlatformInfoVm>(this);
		}

		private Task OnWorkingWithFilesClick()
		{
			return this.modNavigationService.NavigateAsync<TabItemServicesVm, PageWorkingWithFilesVm>(this);
		}

		#endregion

		#region Protected Methods

		#endregion
	}
}
