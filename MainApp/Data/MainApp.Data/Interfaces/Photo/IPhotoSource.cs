using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Data.Interfaces.File;
namespace PhotoTransfer.Data.Interfaces.Photo
{
	public interface IPhotoSource : IFileSource
	{
		object PhotoContainer { get; }
	}
}
