using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Data.Interfaces.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Services.WebService.Interfaces
{
	public interface IWebService
	{
		Task UploadPhoto(IFileSource fileSource, IComment comment);
		Task UploadPhoto(IPhoto photo, IComment comment);
		Task UploadFile(string filePath, string webServerApi);
	}
}
