using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

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
			ImageFromStream();
			ImageFromRunTime();
		}

		private void ImageFromRunTime()
		{
			if (Device.OS == TargetPlatform.Windows)
				return;

			int rows = 128;
			int cols = 64;
			BmpMaker bmpMaker = new BmpMaker(cols, rows);

			for (int row = 0; row < rows; row++)
				for (int col = 0; col < cols; col++)
				{
					bmpMaker.SetPixel(row, col, 2 * row, 0, 2 * (128 - row));
				}

			ImageSource imageSource = bmpMaker.Generate();
			img3.Source = imageSource;
		}

		private void ImageFromStream()
		{
			//Uri uri = new Uri("http://developer.xamarin.com/demo/IMG_0925.JPG?width=512");
			//WebRequest request = WebRequest.Create (uri);
			//request.BeginGetResponse((IAsyncResult arg) => 
			//{
			//	Stream stream = request.EndGetResponse(arg).GetResponseStream();
			//	ImageSource imageSource = ImageSource.FromStream(() => stream);
			//	Device.BeginInvokeOnMainThread(() => img2.Source = imageSource);
			//}, null); 
		}

		private void ImageFromResource()
		{
			//var res = ImageSource.FromResource("MainAppUICommonResources.Images.ModernUserInterface256.jpg");
			ImageSource res = null;
			Device.OnPlatform
				(
				Android: () => res = ImageSource.FromFile("icon.png"),
				Default: () => res = ImageSource.FromFile("icon.png")
				);

			if(Device.OS==TargetPlatform.Windows)
			{
				res = ImageSource.FromFile("Assets\\ModernUserInterface256.jpg");
			}
			
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
