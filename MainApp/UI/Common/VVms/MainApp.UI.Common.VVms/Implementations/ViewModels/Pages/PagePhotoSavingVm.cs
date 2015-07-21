using GalaSoft.MvvmLight.Ioc;

using Library.Commands;
using Library.Extensions;

using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Data.Interfaces.File;
using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.UI.Common.Bases;
using PhotoTransfer.UI.Common.Extensions;
using PhotoTransfer.UI.Common.Enums.File;
using PhotoTransfer.UI.Common.Interfaces.File;
using PhotoTransfer.UI.Common.Interfaces.Image;
using PhotoTransfer.UI.Common.Interfaces.SpeechRecognitionService;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.MainPage;
using PhotoTransfer.UI.Data.Implementations.Entities.Photo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using VMErrors = PhotoTransfer.UI.Common.VVms.Constants.Constants;
using Microsoft.Practices.ServiceLocation;
using System.Threading;
using System.Collections.ObjectModel;
using Library.Types;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages
{
	public class PagePhotoSavingVm : AdvancedPageViewModelBase, IPagePhotoSavingVm
	{
		#region Fields

		protected readonly IInternalModelService modDataBaseService;
		protected readonly IFileWorkerService modFileWorkerService;

		private readonly AsyncCommand mvSavePhotoCommand;

		protected readonly ObservableCollection<IPhotoVm> mvPhotos = new ObservableCollection<IPhotoVm>();

		private int mvRotation;
		private IPhotoVm mvCurrentPhoto;

		private bool mvIsEdit;

		#endregion

		#region Ctor

		[PreferredConstructor]
		public PagePhotoSavingVm(
			IFileWorkerService fileService,
			IInternalModelService dataBaseService)
		{
			modFileWorkerService = fileService;
			modDataBaseService = dataBaseService;

			Rotation = 0;
			mvSavePhotoCommand = new AsyncCommand(SavePhotoAsync);
		}

		public PagePhotoSavingVm()
			: this(
				ServiceLocator.Current.GetInstance<IFileWorkerService>(),
				ServiceLocator.Current.GetInstance<IInternalModelService>())
		{
			MessagingCenter.Subscribe<ContentPage>(this, VMErrors.Messages.PAGE_DISAPPEARING, OnPageDisappearing);
		}

		#endregion

		#region Commands

		public AsyncCommand SavePhotoCommand
		{
			get
			{
				return mvSavePhotoCommand;
			}
		}

		#endregion

		#region Properties

		public int Rotation
		{
			get
			{
				return mvRotation;
			}

			set
			{
				mvRotation = value;
				this.OnPropertyChanged();
			}
		}

		public bool IsEdit
		{
			get
			{
				return mvIsEdit;
			}

			set
			{
				mvIsEdit = value;
				this.OnPropertyChanged();
			}
		}

		public IList<IPhotoVm> Photos
		{
			get
			{
				return mvPhotos;
			}
		}

		public IPhotoVm SelectedItem
		{
			get
			{
				return mvCurrentPhoto;
			}

			set
			{
				mvCurrentPhoto = value;
				this.OnPropertyChanged();				
			}
		}		

		#endregion

		#region Private methods

		private async Task SavePhotoAsync()
		{
			await OnSavePhotoAsyncProtected();
		}

		#endregion

		#region Protected Methods

		protected async Task<IPhoto> GetPhotoFromFile(IFileSource fileSource)
		{
			if (fileSource == null)
				return null;

			IPhoto newPhoto = await modDataBaseService.CreateEntity<IPhoto>();
			newPhoto.Data = await modFileWorkerService.GetFileData(fileSource);
			newPhoto.FileName = fileSource.Name;
			return newPhoto;
		}

		protected virtual async Task OnSavePhotoAsyncProtected()
		{
			if (!mvPhotos.All(x => CheckName(x.NewName)))
				return;

			var photos = mvPhotos.Select(photo =>
			{
				photo.PhotoEntity.FileName = photo.NewName;
				return photo.PhotoEntity;
			}).ToList();

			await this.modNavigationService.Navigate<PagePhotoSavingVm, SaveCommentsPageVm, IList<IPhoto>>(this, photos);
		}

		protected override async Task OnNavigatedTo(object navigationParameter)
		{
			await base.OnNavigatedTo(navigationParameter);

			try
			{
				mvPhotos.Clear();

				var itemsLoadingTask = navigationParameter.WithType<IList<IFileSource>, Task>(async x =>
				{
					await Task.WhenAll(x.Select(async photoFile => mvPhotos.Add(new PhotoVm(await GetPhotoFromFile(photoFile)))).ToArray());
				});

				if (itemsLoadingTask != null)
					await itemsLoadingTask;

				navigationParameter.WithType<IList<IPhoto>>(x =>
				{
					x.ForEach(photo => mvPhotos.Add(new PhotoVm(photo)));
				});

				await Task.WhenAll(mvPhotos.Select(x => x.LoadPhotoAsync()).ToArray());
				SelectedItem = mvPhotos.FirstOrDefault();
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

		#endregion

		#region Cleanup

		public override void Cleanup()
		{
			base.Cleanup();
			MessagingCenter.Unsubscribe<ContentPage>(this, VMErrors.Messages.PAGE_DISAPPEARING);
		}

		#endregion

		#region Message Handlers

		async void OnPageDisappearing(ContentPage page)
		{
			try
			{
				if (NavigationParameter == null)
					return;

				await NavigationParameter.WithType<IList<IFileSource>, Task>(async fss =>
				{
					await Task.WhenAll(fss.Select(async fs =>
					{
						if (fs.IsTemporary)
						{
							await fs.DeleteAsync();
						}
					}));
				});
			}
			catch (Exception ex)
			{

			}
			finally
			{
				MessagingCenter.Unsubscribe<ContentPage>(this, VMErrors.Messages.PAGE_DISAPPEARING);
			}
		}

		#endregion

		#region Static methods

		protected static bool CheckName(string name)
		{
			return !string.IsNullOrWhiteSpace(name);
		}

		#endregion
	}
}
