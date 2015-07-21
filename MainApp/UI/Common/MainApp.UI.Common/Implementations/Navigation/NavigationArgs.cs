using Library.Types;
using PhotoTransfer.Data.Interfaces.Navigation;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Implementations.Navigation
{
	public class NavigationArgs : INavigationArgs
	{
		public NavigationArgs(object viewModel) : this(viewModel, null)
		{

		}

		public NavigationArgs(object viewModel, object parameter)
		{
			ViewModel = viewModel as INavigableAdvancedViewModelBase;
			Parameter = parameter;
		}

		public INavigableAdvancedViewModelBase ViewModel
		{
			get;
			private set;
		}

		public object Parameter
		{
			get;
			private set;
		}
	}
}
