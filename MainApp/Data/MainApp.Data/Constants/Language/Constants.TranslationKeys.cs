using PhotoTransfer.Data.Enums;

namespace PhotoTransfer.Data.Constants.Language
{
	public static class TranslationKeys
	{
		#region MainPage constants

		public const string OPEN_PHOTO = "OPEN_PHOTO_KEY";
		public const string SEND_LOG = "SEND_LOG_PHOTO_KEY";
		public const string MAKE_PHOTO = "MAKE_PHOTO_KEY";
		public const string SYNCHRONIZE = "SYNCHRONIZE_KEY";
		public const string SETTINGS = "SETTINGS";

		#endregion

		#region PagePhotoSave/Editing/Comments page

		public const string SAVE = "SAVE";
		public const string USE_SPEECH = "USE_SPEECH";
		public const string COMMENTS = "COMMENTS";
		public const string INPUT_COMMENT = "INPUT_COMMENT";
		public const string PHOTO_COMMENT = "PHOTO_COMMENT";
		public const string SELECT_PHOTO = "SELECT_PHOTO";

		#endregion		

		#region Preferences names

		public const string WEB_SERVER_URL = "SERVER_ADDRESS";
		public const string LANGUAGE = "LANGUAGE";

		#endregion

		#region Languages

		public static readonly string ENGLISH = enLanguage.ENG.ToString();
		public static readonly string DEUTSCH = enLanguage.DEU.ToString();
		public static readonly string RUSSIAN = enLanguage.RUS.ToString();

		#endregion
	}
}
