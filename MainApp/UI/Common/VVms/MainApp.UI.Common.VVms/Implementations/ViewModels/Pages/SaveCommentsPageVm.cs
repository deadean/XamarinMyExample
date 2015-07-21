using GalaSoft.MvvmLight.Ioc;
using Library.Commands;
using Library.Extensions;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.UI.Common.Bases;
using PhotoTransfer.UI.Common.Enums.File;
using PhotoTransfer.UI.Common.Interfaces.File;
using PhotoTransfer.UI.Common.Interfaces.Navigation;
using PhotoTransfer.UI.Common.Interfaces.SpeechRecognitionService;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages
{
	public class SaveCommentsPageVm : AdvancedPageViewModelBase, ISaveCommentsPageVm
	{
		#region Fields

		private readonly IInternalModelService modDataBaseService;
		private readonly IFileWorkerService modFileWorkerService;

		private readonly AsyncCommand mvSavePhotoComment;
		private readonly AsyncCommand mvSpeechCommand;

		private string mvComment;
		private IList<IPhoto> modPhotos;

		#endregion

		#region Properties
		
		public string Comment
		{
			get
			{
				return mvComment;
			}

			set
			{
				mvComment = value;
				this.OnPropertyChanged();
			}
		}

		#endregion

		#region Ctor

		[PreferredConstructor]
		public SaveCommentsPageVm(
			IInternalModelService dataBaseService, 
			IFileWorkerService fileWorkerService)
		{
			modFileWorkerService = fileWorkerService;
			modDataBaseService = dataBaseService;

			mvSavePhotoComment = new AsyncCommand(OnSaveComment);
		}

		public SaveCommentsPageVm()
			: this(
				ServiceLocator.Current.GetInstance<IInternalModelService>(),
				ServiceLocator.Current.GetInstance<IFileWorkerService>())
		{ }

		#endregion

		#region Commands

		public AsyncCommand SavePhotoCommentCommand
		{
			get
			{
				return mvSavePhotoComment;
			}
		}

		public AsyncCommand SpeechCommand
		{
			get
			{
				return mvSpeechCommand;
			}
		}

		#endregion

		#region Command Handlers
		
		private async Task OnSaveComment()
		{
			try
			{
				foreach (var item in modPhotos)
				{
					await modDataBaseService.SaveCommentToPhoto(item, Comment);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex.InnerException);
			}

			await this.modNavigationService.NavigateAsync<SaveCommentsPageVm, MainPageVm>(this);
		}

		#endregion

		#region Protected Methods

		protected async override Task OnNavigatedTo(object navigationParameter)
		{
			await base.OnNavigatedTo(navigationParameter);
			modPhotos = NavigationParameter as IList<IPhoto>;
			Comment = string.Join(", ", modPhotos.Where(x => x.Comments.Any()).Select(x => x.Comments.FirstOrDefault().Comment).Distinct());
		}

		#endregion
	}
}
