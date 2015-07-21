using PhotoTransfer.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Interfaces.LocatorStrategies
{
	public interface IBaseLocatorStrategy
	{
		INavigationServiceCommon NavigationService { get; }
	}
}
