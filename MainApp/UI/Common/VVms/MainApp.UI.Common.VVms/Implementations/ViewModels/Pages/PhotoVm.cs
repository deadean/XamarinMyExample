using GalaSoft.MvvmLight.Ioc;

using Library.Types;
using Library.Extensions;

using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.UI.Common.Interfaces.Image;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Data.Implementations.Entities.Photo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;


namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages
{
	public class PhotoVm : AdvancedViewModelBase, IPhotoVm
	{
		#region Services

		private static readonly IImageLoader modImageLoader = ServiceLocator.Current.GetInstance<IImageLoader>();

		#endregion

		#region Fields

		private object mvPhoto;
		private readonly IPhoto mvPhotoEntity;
		private string mvNewName;

		#endregion

		#region Properties
		
		public IPhoto PhotoEntity
		{
			get
			{
				return mvPhotoEntity;
			}
		}

		public string FileName
		{
			get
			{
				return mvPhotoEntity.FileName;
			}
		}

		public string NewName 
		{
			get
			{
				return mvNewName;
			}

			set
			{
				mvNewName = value;
				this.OnPropertyChanged();
			}
		}

		public object PhotoImage
		{
			get 
			{
				return mvPhoto; 
			}

			protected set 
			{
				mvPhoto = value; 
				this.OnPropertyChanged(); 
			}
		}

		public string Comment 
		{
			get
			{
				var com = mvPhotoEntity.Comments.FirstOrDefault();
				return com == null ? string.Empty : (com.Comment ?? string.Empty);
			}
		}

		#endregion

		#region Ctor

		public PhotoVm(IPhoto photo)
		{
			mvPhotoEntity = photo;
			mvNewName = FileName;			
		}

		#endregion

		#region Public Methods

		public async Task LoadPhotoAsync()
		{			
			PhotoImage = await modImageLoader.LoadImageSourceFromByteArrayAsync(PhotoEntity.Data, 400, 400);
		}

		#endregion
	}
}
