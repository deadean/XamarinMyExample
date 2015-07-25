using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Controls
{
	public partial class PageButtons : ContentPage
	{
		public PageButtons()
		{
			InitializeComponent();
			if (Device.OS == TargetPlatform.Windows)
			{
				btn1.Image = (FileImageSource)ImageSource.FromFile("Assets\\edit.png");
			}
		}
	}
}
