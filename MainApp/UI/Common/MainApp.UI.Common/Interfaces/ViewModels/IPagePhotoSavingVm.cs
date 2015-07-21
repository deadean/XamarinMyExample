using Library.Commands;
using System.Collections.Generic;

namespace PhotoTransfer.UI.Common.Interfaces.ViewModels
{
	public interface IPagePhotoSavingVm
	{
		AsyncCommand SavePhotoCommand { get; }
		IPhotoVm SelectedItem { get; }
		int Rotation { get; }
		bool IsEdit { get; set; }
		IList<IPhotoVm> Photos { get; }
	}
}
