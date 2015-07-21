using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Pages
{
	public partial class PageImageControls : ContentPage
	{
		public PageImageControls()
		{
			InitializeComponent();
			ResizeImage();
			ImageFromWebUrl();
			ImageFromResource();
		}

		private void ImageFromResource()
		{
			//var res = ImageSource.FromResource("MainAppUICommonResources.Images.ModernUserInterface256.jpg");
			var res = ImageSource.FromFile("Assets\\ModernUserInterface256.jpg");
			this._photo.Source = res;
		}

		private void ImageFromWebUrl()
		{
			img1.Source = new UriImageSource() { Uri = new Uri("http://developer.xamarin.com/demo/IMG_1415.JPG") };
		}

		protected void ResizeImage()
		{
			var res = ImageSource.FromFile("icon.png");
			this._photo.Source = res;
		}
	}
}
