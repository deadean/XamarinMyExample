using Library.Types;
using MainApp.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Common.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.MainPage
{
	public class TabItemVm : AdvancedPageViewModelBase, ITabItemVm
	{

		#region Fields

		#endregion

		#region Properties

		public string Name
		{
			get;
			private set;
		}

		public IList<IMenuItemVm> Menus
		{
			get;
			private set;
		}

		#endregion

		#region Ctor

		public TabItemVm(string name)
		{
			Name = name;
			Menus = new ObservableCollection<IMenuItemVm>();
		}

		#endregion

		#region Public Methods

		public void ChangeName(string newName)
		{
			Name = newName;
		}

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion




		
	}
}
