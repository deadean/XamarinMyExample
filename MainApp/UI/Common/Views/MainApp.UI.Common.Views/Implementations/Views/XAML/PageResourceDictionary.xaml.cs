using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.XAML
{
	public partial class PageResourceDictionary : ContentPage
	{
		public PageResourceDictionary()
		{
			InitializeComponent();

			Device.StartTimer(TimeSpan.FromSeconds(1),
			() =>
			{
				Resources["currentDateTime"] = DateTime.Now.ToString();
				return true;
			});
		}
	}
}
