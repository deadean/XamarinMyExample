using Library.Types;
using PhotoTransfer.Data.Interfaces.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.Interfaces.Navigation
{
	public interface INavigationServiceCommon
	{
		Task Navigate<TVm, TVmDestination, TArgs>(TVm sender, TArgs parameter)
			where TVmDestination : INavigableAdvancedViewModelBase
			where TVm : class, INavigableAdvancedViewModelBase
			where TArgs : class;

		Task NavigateAsync<TVmSender, TVmDestination>(TVmSender sender)
			where TVmDestination : INavigableAdvancedViewModelBase
			where TVmSender : class, INavigableAdvancedViewModelBase;

		void Register<TVm, TView, TViewVmDestination>()
			where TVm : class, INavigableAdvancedViewModelBase
			where TViewVmDestination : INavigableAdvancedViewModelBase, new()
			where TView : class, new();

		void Register<TVm, TView, TViewVmDestination, TArgs>()
			where TVm : class, INavigableAdvancedViewModelBase
			where TViewVmDestination : INavigableAdvancedViewModelBase, new()
			where TView : class, new();

		void RegisterWithExternalAction<TVm, TViewVmDestination>(Action action)
			where TVm : class, INavigableAdvancedViewModelBase
			where TViewVmDestination : INavigableAdvancedViewModelBase;

		void RegisterWithPopToRoot<TVm, TViewVmDestination>()
			where TVm : class, INavigableAdvancedViewModelBase
			where TViewVmDestination : INavigableAdvancedViewModelBase;

		void Register<TVm, TView>()
			where TVm : INavigableAdvancedViewModelBase
			where TView : class;

		Task Navigate<TVm>()
			where TVm : INavigableAdvancedViewModelBase;

		Task Navigate<TVm>(object parameter)
			where TVm : INavigableAdvancedViewModelBase;
	}

	public interface INavigationServiceCommon<T> : INavigationServiceCommon
	{
		void SetNavigationContext(T navigationContext);
	}
}
