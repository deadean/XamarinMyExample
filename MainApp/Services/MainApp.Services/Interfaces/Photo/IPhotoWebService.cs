using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Data.Interfaces.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Services.WebService.Interfaces.Photo
{
	public interface IApplicationWebService
	{
		Task UploadPhoto(IFileSource photoSource, IComment comment);
		Task UploadPhoto(IPhoto photo, IComment comment);
		Task UploadLogFile(string logFilePath);
	}
}
