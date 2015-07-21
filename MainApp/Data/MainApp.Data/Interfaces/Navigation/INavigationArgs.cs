using Library.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Data.Interfaces.Navigation
{
	public interface INavigationArgs
	{
		INavigableAdvancedViewModelBase ViewModel { get; }
		object Parameter { get; }
	}
}
