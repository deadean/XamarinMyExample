using PhotoTransfer.Data.Enums;
namespace PhotoTransfer.UI.Common.Constants
{
	public static partial class Constants
	{
		public static partial class Configuration
		{
			public const string csDefaultWebServerLoadPhotoUrl = "http://smykmob.myddns.ru:222/mob/Api/v1/photos";
			//public const string csWebServerLoadPhotoUrl = "http://localhost:53206/Api/v1/photos";

			public const string csLocalDbFileName = "adaica.db3";

			public const enLanguage csDefaultLanguage = enLanguage.DEU;


			public static class LoggingSettings
			{
				public const string LogStringFormat = "Time :{0}, Message :{1}";
				public const string LogFile = "adaicaMobile.log";
				public const string LogException = "exception";
				public const string LogError = "error";
				public const double LogFileSize = 5;
			}

			public static class WebServerApi
			{
				public const string csWebServerApiLoadLog = "http://smykmob.myddns.ru:222/mob/Api/v1/logs";
				//public const string csWebServerApiLoadLog = "http://localhost:53206/Api/v1/logs";
			}
		}
	}
}
