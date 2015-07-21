using MainApp.Services.Interfaces.PlatformInfo;
using MainApp.WinPhone81.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformInfo))]


namespace MainApp.WinPhone81.Services
{
	public class PlatformInfo : IPlatformInfo
	{
		EasClientDeviceInformation devInfo = new EasClientDeviceInformation();

		public string GetModel()
		{
			return String.Format("{0} {1}", devInfo.SystemManufacturer, devInfo.SystemProductName);
		}

		public string GetVersion()
		{
			return devInfo.OperatingSystem;
		}
	}
}
