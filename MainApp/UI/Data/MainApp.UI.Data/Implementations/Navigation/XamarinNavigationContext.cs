using GalaSoft.MvvmLight.Ioc;
using Library.Types;
using PhotoTransfer.Data.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Data.Implementations.Navigation
{
	public sealed class XamarinNavigationContext<T> : NavigationPage, INavigationContext<T>
	{
		private readonly NavigationPage modPage;
		public XamarinNavigationContext(NavigationPage page)
		{
			modPage = page;
		}

		public Task PushAsync(T page)
		{
			try
			{
				return modPage.Navigation.PushAsync(page as Page);
			}
			catch (Exception ex)
			{

			}
			throw new Exception();
		}


		public Task AsyncPopToRoot()
		{
			return modPage.Navigation.PopToRootAsync();
		}
	}
}
