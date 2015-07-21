using PhotoTransfer.Common.Implementations.Special;
using PhotoTransfer.Common.Interfaces.Special;
using PhotoTransfer.Data.Interfaces.File;

using System;
using System.Collections.Generic;
using System.IO;
using PathIO = System.IO.Path;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.WP.Data.Implementations.File
{
	public class FileSource : IFileSource
	{
		#region Contructor
		
		public FileSource(string filePath, bool isNew = false)
		{
			FilePath = filePath;
			IsNew = isNew;
			IsTemporary = false;
		}
		
		#endregion

		public object File
		{
			get 
			{
				return FilePath;
			}
		}

		public string Name
		{
			get 
			{
				return PathIO.GetFileNameWithoutExtension(FilePath);
			}
		}

		public string FullName
		{
			get
			{
				return PathIO.GetFileName(FilePath);
			}
		}

		public string FilePath
		{
			get;
			private set;
		}

		public bool IsNew
		{
			get;
			private set;
		}

		public bool IsTemporary
		{
			get;
			private set;
		}

		public Task DeleteAsync()
		{
			throw new NotImplementedException();
		}
	}
}
