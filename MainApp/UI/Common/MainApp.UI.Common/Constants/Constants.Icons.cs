using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.Constants
{
	public static partial class Constants
	{
		public static class Icons
		{
			public const string csAndroidIcons = "";
			public const string csWinPhone80Icons = "Assets\\Icons";			
		}
	}

	public static class IconNames
	{
		public static class Android
		{
			public const string csCommonIcons = "";
			public const string csSettingsIcons = "";
			public const string csSettingsPageIcons = "";
            public const string csMainPageIcons = "";
		}

		public static class WinPhone
		{
			public const string csCommonIcons = "Common";
			public const string csSettingsIcons = "Settings";
			public const string csSettingsPageIcons = "SettingsPage";
            public const string csMainPageIcons = "MainPage";
		}

		#region Settings

		public const string csConfirm = "confirm.png";
		public const string csMicrophone = "microphone.png";
		public const string csSettings = "settings.png";
		public const string csSendLogFile = "sendLogFile.png";
		public const string csSaveSettings = "saveSettings.png";
        public const string csMakePhoto = "makePhoto.png";
        public const string csOpenPhoto = "openPhoto.png";
        public const string csSync = "synchronization.png";

		#endregion
	}
}
