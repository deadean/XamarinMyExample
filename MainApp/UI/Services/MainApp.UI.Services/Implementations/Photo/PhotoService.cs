using PhotoTransfer.UI.Common.Interfaces.Photo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using CommonConstants = PhotoTransfer.UI.Common.Constants.Constants;
using PhotoTransfer.UI.Common.Enums.File;
using PhotoTransfer.UI.Common.Interfaces.Folder;
using PhotoTransfer.UI.Common.Interfaces.File;
using PhotoTransfer.WP.Data.Implementations.File;
using PhotoTransfer.WP.Services.Utils;
using PhotoTransfer.Data.Interfaces.File;
using XLabs.Platform.Services.Media;
using XLabs.Platform.Device;
using XLabs.Ioc;
using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.Common.Interfaces.Logging;

namespace PhotoTransfer.WP.Services.Implementations.Photo
{
	public class PhotoService : IPhotoService, ILoggableObject
	{
		#region Fields

		private IMediaPicker modMediaPicker;
		private readonly IFileWorkerService modFileWorkerService;
		private readonly ILogService modLogService;
		//private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
		//private TaskCompletionSource<int> task;

		#endregion

		#region Ctor

		public PhotoService(IFileWorkerService fileWorkerService, ILogService logService)
		{
			modFileWorkerService = fileWorkerService;
			modLogService = logService;
		}

		#endregion

		#region Public Methods

		public Task<IList<IFileSource>> GetPhotoAsync()
		{
			return TakePicture();
		}

		public async Task<IFileSource> SelectPhoto()
		{
			return await SelectFile();
		}

		public ILogService GetLog()
		{
			return modLogService;
		}

		#endregion

		#region Private Methods

		private async Task<IFileSource> SelectFile()
		{
			try
			{
				return await modFileWorkerService.PickFileAsync(
						enFileWorkerLocation.Pictures,
						CommonConstants.File.JPG_EXTENSION,
						CommonConstants.File.PNG_EXTENSION);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message, ex.InnerException);
			}
		}

		private async Task<IList<IFileSource>> TakePicture()
		{
			Setup();

			IList<IFileSource> photos = new List<IFileSource>();
			await TakePhotosAsync(photos);						
			return photos;
		}

		private Task TakePhotosAsync(IList<IFileSource> photos)
		{
			return TakePhoto(photos);
		}

		private async Task TakePhoto(IList<IFileSource> photos)
		{
			var file = default(MediaFile);

			try
			{
				//file = await this._mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions
				//{
				//	MaxPixelDimension = 400,
				//	Name = NameGenerator.GeneratedImageName
				//}).ContinueWith(t =>
				//{
				//	try
				//	{
				//		if (t.IsFaulted)
				//		{
				//			throw new Exception("TakePicture", t.Exception);
				//		}
				//		else if (t.IsCanceled)
				//		{
				//			task.SetResult(0);
				//		}
				//		else
				//		{
				//			return t.Result;
				//		}
				//	}
				//	catch (Exception ex)
				//	{
				//		this.GetLog().Write(ex);
				//	}
				//	return null;
				//}, _scheduler);

				file = await modMediaPicker.TakePhotoAsync(new CameraMediaStorageOptions
				{
					MaxPixelDimension = 400,
					Name = NameGenerator.GeneratedImageName
				});
			}
			catch (TaskCanceledException)
			{
				if (file == null)
					return;
			}
			catch (Exception ex)
			{
				this.GetLog().Write(ex);
			}

			if (file == null)
				return;

			await TakePhoto(photos);

			//var child = Task.Factory.StartNew(async () =>
			//{
			//	await TakePhoto(photos);
			//}, TaskCreationOptions.AttachedToParent);

			IFileSource filePhotoSource = null;
			using (file)
			{
				filePhotoSource = string.IsNullOrWhiteSpace(Path.GetDirectoryName(file.Path)) ?
					await ResolveImageAsync(file) :
					await modFileWorkerService.GetFileAsync(file.Path, isNew: true);
			}

			if (filePhotoSource != null)
				photos.Add(filePhotoSource);
		}

		private ImageSource CheckImageOrientation(MediaFile mediaFile)
		{
			var bytes = default(byte[]);
			using (var streamReader = new StreamReader(mediaFile.Source))
			{
				using (var memstream = new MemoryStream())
				{
					streamReader.BaseStream.CopyTo(memstream);
					bytes = memstream.ToArray();
				}
			}

			//using (var memoryStream = new MemoryStream(bytes))
			//{
			//	var rotateImage = Image.FromStream(memoryStream);
			//	rotateImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
			//	rotateImage.Save(memoryStream, rotateImage.RawFormat);
			//	byteArray = memoryStream.ToArray();
			//}

			return ImageSource.FromStream(() => new MemoryStream(bytes));
		}

		private void Setup()
		{
			if (modMediaPicker != null)
			{
				return;
			}

			var device = Resolver.Resolve<IDevice>();

			try
			{
				modMediaPicker = DependencyService.Get<IMediaPicker>();
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
			finally
			{
				if (modMediaPicker == null)
					modMediaPicker = device.MediaPicker;
			}
		}

		private async Task<IFileSource> ResolveImageAsync(MediaFile mediaFile)
		{
			return await modFileWorkerService.CacheFileAsync(mediaFile.Source, Path.GetFileName(mediaFile.Path), fileIsNew: true);
		}

		#endregion


	}
}
