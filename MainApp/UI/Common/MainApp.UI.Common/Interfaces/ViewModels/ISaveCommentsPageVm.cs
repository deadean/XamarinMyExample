using Library.Commands;

namespace PhotoTransfer.UI.Common.Interfaces.ViewModels
{
	public interface ISaveCommentsPageVm
	{
		AsyncCommand SavePhotoCommentCommand { get; }
		AsyncCommand SpeechCommand { get; }

		string Comment { get; }
	}
}
