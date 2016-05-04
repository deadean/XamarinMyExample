using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MainApp.UI.Common.Views
{
	public partial class PageTransforms : ContentPage
	{
		static readonly TimeSpan duration = TimeSpan.FromSeconds (1);
		Random random = new Random ();
		Point startPoint;
		Point animationVector;
		DateTime startTime;

		public PageTransforms ()
		{
			try {
				InitializeComponent ();	

				for (int i = 0; i < Device.OnPlatform (12, 12, 18); i++) {
					grid.Children.Insert (0, new Label {
						TranslationX = i,
						TranslationY = -i
					});
				}

				Device.StartTimer (TimeSpan.FromMilliseconds (16), OnTimerTick);


			} catch (Exception ex) {
				
			}

		}

		void OnButtonClicked (object sender, EventArgs args)
		{
			Button button = (Button)sender;
			View container = (View)button.Parent;

			// The start of the animation is the current Translation properties.
			startPoint = new Point (button.TranslationX, button.TranslationY);

			// The end of the animation is a random point.
			double endX = (random.NextDouble () - 0.5) * (container.Width - button.Width);
			double endY = (random.NextDouble () - 0.5) * (container.Height - button.Height);

			// Create a vector from start point to end point.
			animationVector = new Point (endX - startPoint.X, endY - startPoint.Y);

			// Save the animation start time.
			startTime = DateTime.Now;
		}

		bool OnTimerTick ()
		{
			// Get the elapsed time from the beginning of the animation.
			TimeSpan elapsedTime = DateTime.Now - startTime;

			// Normalize the elapsed time from 0 to 1.
			double t = Math.Max (0, Math.Min (1, elapsedTime.TotalMilliseconds /
			           duration.TotalMilliseconds));

			// Calculate the new translation based on the animation vector.
			button.TranslationX = startPoint.X + t * animationVector.X;
			button.TranslationY = startPoint.Y + t * animationVector.Y;
			return true;
		}

		void OnAnimateScaleClicked (object sender, EventArgs args)
		{
			Button button = (Button)sender;
			AnimateAndBack (1, 5, TimeSpan.FromSeconds (3), (double value) => {
				button.Scale = value;
			});
		}

		void OnAnimateFontSizeClicked (object sender, EventArgs args)
		{
			Button button = (Button)sender;

			AnimateAndBack (button.FontSize, 5 * button.FontSize, 
				TimeSpan.FromSeconds (3), (double value) => {
				button.FontSize = value;
			});
		}

		async void AnimateAndBack (double fromValue, double toValue, 
		                          TimeSpan duration, Action<double> callback)
		{
			Stopwatch stopWatch = new Stopwatch ();
			double t = 0;
			stopWatch.Start ();

			while (t < 1) {
				double tReversing = 2 * (t < 0.5 ? t : 1 - t);
				callback (fromValue + (toValue - fromValue) * tReversing);
				await Task.Delay (16);
				t = stopWatch.ElapsedMilliseconds / duration.TotalMilliseconds;
			}

			stopWatch.Stop ();
			callback (fromValue);
		}
	}
}

