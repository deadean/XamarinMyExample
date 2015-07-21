using Library.Commands;

namespace PhotoTransfer.UI.Common.Interfaces.ViewModels
{
	public interface IPagePhotoEditingVm : IPagePhotoSavingVm
	{
		AsyncCommand SavePhotoCommentCommand { get; }
	}
}
