using Library.Commands;

using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Data.Interfaces.File;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.MainPage;
using PhotoTransfer.UI.Data.Implementations.Entities.Photo;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages
{
	public class PagePhotoEditingVm : PagePhotoSavingVm, IPagePhotoEditingVm
	{
		#region Fields

		private readonly AsyncCommand mvSavePhotoCommentCommand;

		#endregion

		#region Properties

		public AsyncCommand SavePhotoCommentCommand
		{
			get
			{
				return mvSavePhotoCommentCommand;
			}
		}

		#endregion

		#region Ctor

		public PagePhotoEditingVm()
		{
			mvSavePhotoCommentCommand = new AsyncCommand(SavePhotoCommentAsync);
			IsEdit = true;
		}		

		#endregion

		#region Private Methods

		private async Task SavePhotoCommentAsync()
		{			
			await modNavigationService.Navigate<PagePhotoEditingVm, SaveCommentsPageVm, IList<IPhoto>>(this, Photos.Cast<IPhoto>().ToList());
		}

		#endregion

		#region Protected Methods

		protected override async Task OnSavePhotoAsyncProtected()
		{
			try
			{
				foreach (var photo in mvPhotos)
				{
					photo.PhotoEntity.FileName = photo.NewName;
					await modDataBaseService.UpdateEntityAsync<Photo>(photo.PhotoEntity as Photo);
				}

				await modNavigationService.NavigateAsync<PagePhotoEditingVm, MainPageVm>(this);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		#endregion
	}
}
