using GalaSoft.MvvmLight.Ioc;
using Library.Extensions;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.Services.WebService.Interfaces.Photo;
using PhotoTransfer.UI.Common.Interfaces.Image;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages
{
	public class PageSelectPhotoForSyncVm : PageSelectPhotoVm, IPageSelectPhotoForSyncVm
	{
		#region Fields

		protected IApplicationWebService modPhotoWebService;

		#endregion

		#region Ctor

		[PreferredConstructor]
		public PageSelectPhotoForSyncVm(
			IInternalModelService modelService,
			IImageLoader imageLoader,
			IApplicationWebService photoWebService)
			: base(modelService, imageLoader)
		{
			modPhotoWebService = photoWebService;
		}

		public PageSelectPhotoForSyncVm() : this(
				ServiceLocator.Current.GetInstance<IInternalModelService>(),
				ServiceLocator.Current.GetInstance<IImageLoader>(),
				ServiceLocator.Current.GetInstance<IApplicationWebService>())
		{
		}

		#endregion

		#region Protected Methods

		protected override async Task OnFinishSelectionCommandPrivate(IList<IPhotoVm> selectedItems)
		{
			try
			{
				IsLoading = true;

				foreach (var item in selectedItems.Select(x => x.PhotoEntity))
				{
					await modPhotoWebService.UploadPhoto(item, item.Comments.FirstOrDefault());	
				}
				
				IsLoading = false;
				await modNavigationService.NavigateAsync<PageSelectPhotoForSyncVm, MainPageVm>(this);
			}
			catch (Exception ex)
			{

			}
		}

		#endregion
	}
}
