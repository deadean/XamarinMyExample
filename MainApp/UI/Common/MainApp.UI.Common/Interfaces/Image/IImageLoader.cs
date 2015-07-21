using PhotoTransfer.Data.Interfaces.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.Interfaces.Image
{
	public interface IImageLoader
	{
		Task<object> LoadImageSourceFromByteArrayAsync(byte[] imageData, int reqWidth, int reqHeight);
		Task<object> LoadImageSourceAsyncFromByteArray(byte[] imgData);
		Task<object> LoadImageSourceAsyncFromFile(string filePath);
		Task<object> LoadImageSourceAsyncFromFileSource(IFileSource fileSource);
	}
}
