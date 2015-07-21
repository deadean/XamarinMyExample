namespace PhotoTransfer.UI.Common.Extensions
{
	public static class FileExtensions
	{
		public static string ToPNGFileName(this string fileName)
		{
			return fileName.AddExtension(Constants.Constants.File.PNG_EXTENSION);
		}

		public static string ToJPGFileName(this string fileName)
		{
			return fileName.AddExtension(Constants.Constants.File.JPG_EXTENSION);
		}

		internal static string AddExtension(this string fileName, string extension)
		{
			return string.Format("{0}{1}", fileName, extension);
		}
	}
}
