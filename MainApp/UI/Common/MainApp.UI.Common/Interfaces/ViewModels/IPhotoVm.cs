using PhotoTransfer.Data.Interfaces.Entities.Photo;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.Interfaces.ViewModels
{
	public interface IPhotoVm
	{
		IPhoto PhotoEntity { get; }
		string FileName { get; }
		string NewName { get; }
		string Comment { get; }
		object PhotoImage { get; }
		Task LoadPhotoAsync();
	}
}
