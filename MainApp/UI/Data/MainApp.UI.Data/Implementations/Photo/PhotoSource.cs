using PhotoTransfer.Data.Interfaces.File;
using PhotoTransfer.Data.Interfaces.Photo;
using PhotoTransfer.WP.Data.Implementations.File;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.WP.Data.Implementations.Photo
{
	public class PhotoSource : FileSource, IPhotoSource
	{
		public object PhotoContainer
		{
			get
			{
				return File;
			}
		}

		public PhotoSource(IFileSource fileSource) : base(fileSource.FilePath, fileSource.IsNew)
		{ 
		}

		public PhotoSource(string photoPath, bool isNew = false) : base(photoPath, isNew)
		{
		}
	}
}
