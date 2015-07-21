using GalaSoft.MvvmLight.Ioc;

using PhotoTransfer.Common.Implementations.Extensions;

using Library.Commands;
using Library.Types;
using Library.Extensions;

using Microsoft.Practices.ServiceLocation;

using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.Services.WebService.Interfaces.Photo;
using PhotoTransfer.UI.Common.Bases;
using PhotoTransfer.UI.Common.Interfaces.Image;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Data.Implementations.Entities.Photo;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages
{
	public class PageSelectPhotoVm : AdvancedPageViewModelBase, IPageSelectPhotoVm
	{
		#region Fields

		private readonly IInternalModelService modModelService;
		private readonly IImageLoader modImageLoader;
		
		private bool mvIsLoading;
		private IList<IPhotoVm> mvItems;
		private IList<IPhotoVm> mvSelectedItems = new ObservableCollection<IPhotoVm>();
		private AsyncCommand<IEnumerable> mvOnSelectionFinishedCommand; 

		#endregion

		#region Properties

		public bool IsLoading
		{
			get 
			{				
				return mvIsLoading; 
			}

			set
			{
				mvIsLoading = value; 
				this.OnPropertyChanged();
			}
		}

		public IList<IPhotoVm> Items
		{
			get
			{
				return mvItems;
			}

			set
			{
				mvItems = value;
				this.OnPropertyChanged();
			}
		}

		public IList<IPhotoVm> SelectedItems 
		{
			get
			{
				return mvSelectedItems;
			}

			set
			{
				mvSelectedItems = value;
				this.OnPropertyChanged();
			}
		}

		#endregion

		#region Commands

		public AsyncCommand<IEnumerable> FinishSelectionCommand
		{
			get
			{
				return mvOnSelectionFinishedCommand;
			}
		}		

		#endregion

		#region Ctor

		public PageSelectPhotoVm()
			: this(
				ServiceLocator.Current.GetInstance<IInternalModelService>(),
				ServiceLocator.Current.GetInstance<IImageLoader>())
		{

		}

		[PreferredConstructor]
		public PageSelectPhotoVm(IInternalModelService modelService, IImageLoader imageLoader)
		{
			modModelService = modelService;
			modImageLoader = imageLoader;
			mvOnSelectionFinishedCommand = new AsyncCommand<IEnumerable>(OnFinishSelectionCommand);
		}

		#endregion
		
		#region Protected Methods

		protected override async Task OnNavigatedTo(object navigationParameter)
		{
			try
			{
				mvSelectedItems.With(x => x.Clear());
				mvItems.With(x => x.Clear());
				//await base.OnNavigatedTo(navigationParameter);

				var modPhotos = await modModelService.Items<Photo>();
				mvItems = new List<IPhotoVm>();

				foreach (var item in modPhotos)
				{
					var photoVM = new PhotoVm(item);
					await photoVM.LoadPhotoAsync();
					mvItems.Add(photoVM);
				}

				this.OnPropertyChanged(x => x.Items);
			}
			catch (Exception ex)
			{

			}
		}

		#endregion

		#region Command delegates

		private async Task OnFinishSelectionCommand(IEnumerable selectedItems)
		{
			var items = selectedItems.OfType<IPhotoVm>().ToList();

			if (!items.Any())
			{				
				return;
			}

			await OnFinishSelectionCommandPrivate(items);
		}

		protected virtual async Task OnFinishSelectionCommandPrivate(IList<IPhotoVm> selectedItems)
		{
			//mvSelectedItems.Clear();

			var selectedItemPhotos = selectedItems.Select(x => x.PhotoEntity).ToList();
			await modNavigationService.Navigate<PageSelectPhotoVm, PagePhotoEditingVm, IList<IPhoto>>(this, selectedItemPhotos);			
		}

		#endregion
	}
}
