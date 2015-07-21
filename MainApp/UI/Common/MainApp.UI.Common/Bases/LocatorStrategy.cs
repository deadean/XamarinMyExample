using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.Common.Interfaces.Logging;
using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Bases
{
	public class LocatorStrategy : BaseLocatorStrategy, ILoggableObject
	{

		#region Fields

		private readonly ILogService modLogService;
		
		#endregion

		#region Properties

		#endregion

		#region Ctor

		public LocatorStrategy(INavigationServiceCommon navigationService)
		{
			NavigationService = navigationService;
			modLogService = ServiceLocator.Current.GetInstance<ILogService>();
		}

		#endregion

		#region Public Methods

		public ILogService GetLog()
		{
			return modLogService;
		}

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

				#endregion

		
	}
}
