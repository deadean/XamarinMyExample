using PhotoTransfer.Data.Interfaces.File;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Interfaces.Photo
{
	public interface IPhotoService
	{
		Task<IList<IFileSource>> GetPhotoAsync();

		Task<IFileSource> SelectPhoto();
	}
}
