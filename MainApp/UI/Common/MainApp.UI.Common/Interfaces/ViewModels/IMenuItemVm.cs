using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainApp.UI.Common.Interfaces.ViewModels
{
	public interface IMenuItemVm : INameVm
	{
		ICommand Command { get; }
	}
}
