using GalaSoft.MvvmLight.Ioc;
using Library.Commands;
using Library.Types;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.Common.Interfaces.Logging;
using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Bases
{
	public abstract class AdvancedPageViewModelBase : AdvancedViewModelBase, INavigableAdvancedViewModelBase, ILoggableObject
	{
		#region Fields

		private readonly AsyncCommand mvBackCommand;
		protected readonly INavigationServiceCommon modNavigationService;
		private object mvNavigationParameter;
		private INavigationHelper modNavigationHelper;
		private ILogService modLogService;

		#endregion

		#region Ctor

		protected AdvancedPageViewModelBase()
		{
			modNavigationService = ServiceLocator.Current.GetInstance<INavigationServiceCommon>();
			mvBackCommand = new AsyncCommand(OnBackCommand);

			modLogService = ServiceLocator.Current.GetInstance<ILogService>();
		}
		
		#endregion

		#region Public Methods

		public void SetNavigationHelper(INavigationHelper navigationHelper)
		{
			modNavigationHelper = navigationHelper;
		}

		public ILogService GetLog()
		{
			return modLogService;
		}

		#endregion

		#region Protected Methods

		protected virtual async Task OnNavigatedTo(object navigationParameter) {  }

		#endregion

		#region Properties

		public virtual object NavigationParameter 
		{
			get { return mvNavigationParameter; }
			set
			{
				mvNavigationParameter = value;
				this.OnNavigatedTo(mvNavigationParameter);
			}
		}

		#endregion

		#region Commands

		public AsyncCommand BackCommand
		{
			get { return mvBackCommand; }
		}

		#endregion

		#region Commands Execute Handlers

		private async Task OnBackCommand()
		{
			modNavigationHelper.GoBackCommand.Execute(null);
		}

		#endregion

		
	}
}
