using MainApp.UI.Common.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.MainPage
{
	public class MenuItemVm:IMenuItemVm
	{
		

		#region Fields

		#endregion

		#region Properties

		public ICommand Command
		{
			get;
			private set;
		}

		public string Name
		{
			get;private set;
		}

		public void ChangeName(string newName)
		{
			Name = newName;
		}

		#endregion

		#region Ctor

		public MenuItemVm(string name, ICommand command)
		{
			Name = name;
			Command = command;
		}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion
		
	}
}
