using PhotoTransfer.Common.Interfaces.Logging;
using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.UI.Common.Interfaces.LocatorStrategies;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Bases
{
	public abstract class BaseLocatorStrategy : IBaseLocatorStrategy
	{

		#region Fields

		#endregion

		#region Properties

		public INavigationServiceCommon NavigationService
		{
			get;
			protected set;
		}

		#endregion

		#region Ctor

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion
		
	}
}
