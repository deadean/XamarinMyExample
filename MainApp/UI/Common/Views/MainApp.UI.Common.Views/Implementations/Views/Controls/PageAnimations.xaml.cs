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
					 -bottomSectionSettings.Width - 300, 0, 300, Easing.SinIn);
			bottomSectionMain.TranslateTo(
					 -bottomSectionMain.Width - 300, 0, 300, Easing.SinIn);
		}

		private void CloseSettings()
		{
			bottomSectionSettings.TranslateTo(0, 0, 300, Easing.SinIn);
			bottomSectionMain.TranslateTo(0, 0, 300, Easing.SinIn);
		}

		async void OnButton3Clicked(object sender, EventArgs args)
		{
			await button3.RotateTo(360, 2000);
			button3.Rotation = 0;
		}

		void OnButton4Clicked(object sender, EventArgs args)
		{
			button4.RelRotateTo(90, 2000);
		}

		void OnButton5Clicked(object sender, EventArgs args)
		{
			ViewExtensions.CancelAnimations(button3);
		}

		async void OnButton6Clicked(object sender, EventArgs args)
		{
			await button6.RotateTo(90, 250);
			await button6.RotateTo(-90, 500);
			await button6.RotateTo(0, 250);
		}

		async void OnButton7Clicked(object sender, EventArgs args)
		{
			button7.Rotation = 0;
			button7.RotateTo(360, 2000);
			await button7.ScaleTo(5, 1000);
			await button7.ScaleTo(1, 1000);
		}

		async void OnButton8Clicked(object sender, EventArgs args)
		{
			button8.Rotation = 0;
			await Task.WhenAny<bool>
			(
				button8.RotateTo(360, 2000),
				button8.ScaleTo(5, 1000)
			);
			await button8.ScaleTo(1, 1000);
		}

		Point center;
		double radius;
		async void OnButton9Clicked(object sender, EventArgs args)
		{
			button9.Rotation = 0;
			button9.AnchorY = radius / button9.Height;
			await button9.RotateTo(360, 1000);
		}
		void OnSizeChanged(object sender, EventArgs args)
		{
			center = new Point(absoluteLayout.Width / 2, absoluteLayout.Height / 2);
			radius = Math.Min(absoluteLayout.Width, absoluteLayout.Height) / 2;
			AbsoluteLayout.SetLayoutBounds(button9,
			new Rectangle(center.X - button9.Width / 2, center.Y - radius,
			AbsoluteLayout.AutoSize,
			AbsoluteLayout.AutoSize));
		}

		async void OnButton10Clicked(object sender, EventArgs args)
		{
			await button10.RotateTo(90, 250, Easing.SinOut);
			await button10.RotateTo(-90, 500, Easing.SinInOut);
			await button10.RotateTo(0, 250, Easing.SinIn);
		}
		async void OnButton11Clicked(object sender, EventArgs args)
		{
			await button11.TranslateTo(0, (Height - button11.Height) / 2, 1000, Easing.BounceOut);
			await Task.Delay(2000);
			await button11.TranslateTo(0, 0, 1000, Easing.SpringOut);
		}
		Random random = new Random();
		async void OnButton12Clicked(object sender, EventArgs args)
		{
			Func<double, double> customEase = t => 9 * t * t * t - 13.5 * t * t + 5.5 * t;

			double scale = Math.Min(Width / button12.Width, Height / button12.Height);
			await button12.ScaleTo(scale, 1000, new Easing(t => (int)(5 * t) / 5.0));
			//await button12.ScaleTo(1, 1000, (Easing)RandomEase);
			await button12.ScaleTo(1, 1000, customEase);
		}
		double RandomEase(double t)
		{
			return t == 0 || t == 1 ? t : t + 0.25 * (random.NextDouble() - 0.5);
		}
		async void OnButton13Clicked(object sender, EventArgs args)
		{
			// Swing down from lower-left corner.
			button13.AnchorX = 0;
			button13.AnchorY = 1;
			await button13.RotateTo(90, 3000,
			new Easing(t => 1 - Math.Cos(10 * Math.PI * t) * Math.Exp(-5 * t)));
			// Drop to the bottom of the screen.
			await button13.TranslateTo(0, (Height - button13.Height) / 2 - button13.Width,
		   // Prepare AnchorX and AnchorY for next rotation.
		   1000, Easing.BounceOut);
			button13.AnchorX = 1;
			button13.AnchorY = 0;
			// Compensate for the change in AnchorX and AnchorY.
			button13.TranslationX -= button13.Width - button13.Height; button13.TranslationY += button13.Width + button13.Height;
			// Fall over.
			await button13.RotateTo(180, 1000, Easing.BounceOut);
			// Fade out while ascending to the top of the screen.
			await Task.WhenAll
			(
				button13.FadeTo(0, 4000), button13.TranslateTo(0, -Height, 5000, Easing.CubicIn)
			);
			await Task.Delay(3000);
			button13.TranslationX = 0;
			button13.TranslationY = 0;
			button13.Rotation = 0;
			button13.Opacity = 1;
		}
	}
}
