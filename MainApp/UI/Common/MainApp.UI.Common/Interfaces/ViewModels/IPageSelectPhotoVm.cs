using Library.Commands;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PhotoTransfer.UI.Common.Interfaces.ViewModels
{
	public interface IPageSelectPhotoVm
	{
		bool IsLoading { get; }
		IList<IPhotoVm> Items { get; }
		IList<IPhotoVm> SelectedItems { get; }
		AsyncCommand<IEnumerable> FinishSelectionCommand { get; }
	}
}
