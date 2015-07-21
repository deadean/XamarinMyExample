using PhotoTransfer.UI.Common.Constants;
using PhotoTransfer.UI.Common.Interfaces.Image;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.WP.Services.Implementations.Image
{
	public sealed class IconsLoader : IIconsLoader
	{
		#region Fields

		private readonly Dictionary<string, string> modIconsSources = new Dictionary<string, string>();

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public IconsLoader()
		{
			Device.OnPlatform
				(
				Android:()=>RegisterIcons_Android(),
				WinPhone:()=>RegisterIcons_WinPhone(),
				Default:()=>RegisterIcons_Android()
				);
		}

		

		#endregion

		#region Public Methods

		public string GetIconPath(string icon)
		{
			string iconPath = icon;
			Device.OnPlatform
			 (
				Android: () => iconPath = Path.Combine(Constants.Icons.csAndroidIcons, modIconsSources[icon], icon),
				WinPhone: () => iconPath = Path.Combine(Constants.Icons.csWinPhone80Icons, modIconsSources[icon], icon),
				Default: () => iconPath = Path.Combine(icon)
			 );
			return iconPath;
		}

		#endregion

		#region Private Methods

		private void RegisterIcons_WinPhone()
		{
			modIconsSources.Add(IconNames.csConfirm, IconNames.WinPhone.csCommonIcons);
			modIconsSources.Add(IconNames.csMicrophone, IconNames.WinPhone.csCommonIcons);
			modIconsSources.Add(IconNames.csSettings, IconNames.WinPhone.csSettingsIcons);
			modIconsSources.Add(IconNames.csSendLogFile, IconNames.WinPhone.csSettingsPageIcons);
			modIconsSources.Add(IconNames.csSaveSettings, IconNames.WinPhone.csSettingsPageIcons);
            modIconsSources.Add(IconNames.csMakePhoto, IconNames.WinPhone.csMainPageIcons);
            modIconsSources.Add(IconNames.csOpenPhoto, IconNames.WinPhone.csMainPageIcons);
            modIconsSources.Add(IconNames.csSync, IconNames.WinPhone.csMainPageIcons);
		}

		private void RegisterIcons_Android()
		{
			modIconsSources.Add(IconNames.csConfirm, IconNames.Android.csCommonIcons);
			modIconsSources.Add(IconNames.csMicrophone, IconNames.Android.csCommonIcons);
			modIconsSources.Add(IconNames.csSettings, IconNames.Android.csSettingsIcons);
			modIconsSources.Add(IconNames.csSendLogFile, IconNames.Android.csSettingsPageIcons);
			modIconsSources.Add(IconNames.csSaveSettings, IconNames.Android.csSettingsPageIcons);
            modIconsSources.Add(IconNames.csMakePhoto, IconNames.Android.csMainPageIcons);
            modIconsSources.Add(IconNames.csOpenPhoto, IconNames.Android.csMainPageIcons);
            modIconsSources.Add(IconNames.csSync, IconNames.Android.csMainPageIcons);
		}

		#endregion
	}
}
