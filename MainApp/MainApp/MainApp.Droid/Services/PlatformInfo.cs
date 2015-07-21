using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MainApp.Services.Interfaces.PlatformInfo;
using MainApp.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformInfo))]

namespace MainApp.Droid.Services
{
	public class PlatformInfo : IPlatformInfo
	{
		public string GetModel()
		{
			return String.Format("{0} {1}", Build.Manufacturer,
																			Build.Model);
		}

		public string GetVersion()
		{
			return Build.VERSION.Release.ToString();
		}
	}
}