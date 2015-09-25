using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Controls
{
	public partial class PageAnimations : ContentPage
	{
		public PageAnimations()
		{
			InitializeComponent();
		}

		public void OnButton1Clicked(object sender, EventArgs args)
		{
			ShowSettings();
		}

		public void OnButton2Clicked(object sender, EventArgs args)
		{
			CloseSettings();
		}

		private void ShowSettings()
		{
			bottomSectionSettings.TranslateTo(
					 -bottomSectionSettings.Width-300, 0, 300, Easing.SinIn);
			bottomSectionMain.TranslateTo(
					 -bottomSectionMain.Width-300, 0, 300, Easing.SinIn);
		}

		private void CloseSettings()
		{
			bottomSectionSettings.TranslateTo(0, 0, 300, Easing.SinIn);
			bottomSectionMain.TranslateTo(0, 0, 300, Easing.SinIn);
		}
	}
}
