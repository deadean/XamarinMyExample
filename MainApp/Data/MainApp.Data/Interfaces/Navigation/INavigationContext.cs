using Library.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Data.Interfaces.Navigation
{
	public interface INavigationContext<T>
	{
		Task PushAsync(T page);

		Task AsyncPopToRoot();
	}
}
