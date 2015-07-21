using Library.Types;
using PhotoTransfer.Data.Interfaces.Navigation;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.WP.Services.Implementations.Navigation
{
	public class NavigationServiceMessagingCenter<T> : INavigationServiceCommon<T>
		where T : INavigationContext<ContentPage>
	{

		private T modNavigationContext;

		public void SetNavigationContext(T navigationContext)
		{
			modNavigationContext = navigationContext;
		}

		public void Register<TVm, TView>()
			where TVm :  INavigableAdvancedViewModelBase
			where TView : class
		{
			
		}

		public void Register<TVm, TView, TViewVmDestination>()
			where TVm : class, INavigableAdvancedViewModelBase
			where TViewVmDestination : INavigableAdvancedViewModelBase, new()
			where TView : class, new()
		{
			MessagingCenter.Subscribe<TVm>(this
					, typeof(TViewVmDestination).Name
					, async (sender) =>
					{
						try
						{
							Device.BeginInvokeOnMainThread(async () =>
							{
								try
								{
									var view = new TView();
									var vm = new TViewVmDestination();
									vm.NavigationParameter = null;
									(view as ContentPage).BindingContext = vm;

									await modNavigationContext.PushAsync(view as ContentPage);
								}
								catch (Exception ex)
								{
								}
							});
						}
						catch (Exception ex)
						{

						}

						
					});
		}

		public void Register<TVm, TView, TViewVmDestination, TArgs>()
			where TVm : class, INavigableAdvancedViewModelBase
			where TViewVmDestination : INavigableAdvancedViewModelBase, new()
			where TView : class, new()
		{
			MessagingCenter.Subscribe<TVm, TArgs>(this
					, typeof(TViewVmDestination).Name
					, async (sender, args) =>
					{
						try
						{
							Device.BeginInvokeOnMainThread(async () =>
							{
								try
								{
									var view = new TView();
									var vm = new TViewVmDestination();
									vm.NavigationParameter = args;
									(view as ContentPage).BindingContext = vm;

									//var res = action(args) as ContentPage;

									await modNavigationContext.PushAsync(view as ContentPage);
								}
								catch (Exception ex)
								{
								}
							});
						}
						catch (Exception ex)
						{

						}
					});
		}

		public void RegisterWithPopToRoot<TVm, TViewVmDestination>()
			where TVm : class, INavigableAdvancedViewModelBase
			where TViewVmDestination : INavigableAdvancedViewModelBase
		{
			MessagingCenter.Subscribe<TVm>(this
					, typeof(TViewVmDestination).Name
					, async (sender) =>
					{
						try
						{
							Device.BeginInvokeOnMainThread(async () =>
							{
								try
								{
									await modNavigationContext.AsyncPopToRoot();
								}
								catch (Exception ex)
								{
								}
							});
						}
						catch (Exception ex)
						{

						}
					});
		}

		public Task Navigate<TVm>() where TVm : INavigableAdvancedViewModelBase
		{
			throw new NotImplementedException();
		}

		public Task Navigate<TVm>(object parameter) where TVm : INavigableAdvancedViewModelBase
		{
			throw new NotImplementedException();
		}

		public async Task Navigate<TVm, TVmDestination, TArgs>(TVm sender, TArgs parameter)
			where TVmDestination :  INavigableAdvancedViewModelBase
			where TVm : class, INavigableAdvancedViewModelBase
			where TArgs : class
		{
			Type type = typeof(TVmDestination);
			MessagingCenter.Send<TVm, TArgs>(sender, type.Name, parameter);
		}

		public async Task NavigateAsync<TVmSender, TVmDestination>(TVmSender sender)
			where TVmDestination : INavigableAdvancedViewModelBase
			where TVmSender : class, INavigableAdvancedViewModelBase
		{
			Type type = typeof(TVmDestination);
			MessagingCenter.Send<TVmSender>(sender, type.Name);
		}





		public void RegisterWithExternalAction<TVm, TViewVmDestination>(Action action)
			where TVm : class, INavigableAdvancedViewModelBase
			where TViewVmDestination : INavigableAdvancedViewModelBase
		{
			MessagingCenter.Subscribe<TVm>(this
					, typeof(TViewVmDestination).Name
					, async (sender) =>
					{
						try
						{
							Device.BeginInvokeOnMainThread(async () =>
							{
								try
								{
									action();
								}
								catch (Exception ex)
								{
								}
							});
						}
						catch (Exception ex)
						{

						}
					});
		}
	}
}
