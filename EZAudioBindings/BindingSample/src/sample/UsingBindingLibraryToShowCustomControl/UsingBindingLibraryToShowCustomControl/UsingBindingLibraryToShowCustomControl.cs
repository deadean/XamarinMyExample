using System;

using Xamarin.Forms;

namespace UsingBindingLibraryToShowCustomControl
{
	public class App : Application
	{
		public App ()
		{
			try {
				// The root page of your application
				MainPage = new ContentPage {
					Content = new Control()
				};
			} catch (Exception ex) {
				
			}

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

