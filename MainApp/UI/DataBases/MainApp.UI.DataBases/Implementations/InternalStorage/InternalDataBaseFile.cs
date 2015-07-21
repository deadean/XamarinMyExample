using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.UI.Common.Enums.File;
using PhotoTransfer.UI.Common.Interfaces.File;
using PhotoTransfer.UI.Data.Implementations.Entities.Photo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.DataBases.Implementations.InternalStorage
{
	public sealed class InternalDataBaseFile : IInternalModelService
	{
		#region Fields

		private readonly IFileWorkerService modFileWorkerService;

		#endregion
		#region Properties

		#endregion
		#region Ctor

		public InternalDataBaseFile(IFileWorkerService fileWorkerService)
		{
			modFileWorkerService = fileWorkerService;
		}

		#endregion
		#region Public Methods

		public async Task SaveCommentToPhoto(string photoFileName, string comment)
		{
			var result = await modFileWorkerService.SaveToTextFileAsync(photoFileName, comment, isReplacingExisted : true);
            //use result for Success notifications, if needed
		}

		public async Task<IComment> GetCommentByPhoto(string photoFileName)
		{
			//var file = await modFileWorkerService.TryGetFileAsync(photoFileName, enFileWorkerLocation.Default);
			return null;
			//return new PhotoComment(file == null ? string.Empty : await file.GetFileContentAsync());
		}

		#endregion
		#region Private Methods

		#endregion
		#region Protected Methods

		#endregion

		public Task SaveEntity<T>(T item) where T : IEntity
		{
			throw new System.NotImplementedException();
		}

		public Task SaveCommentToPhoto(IPhoto photo, string comment)
		{
			throw new System.NotImplementedException();
		}



		public Task<T> CreateEntity<T>() where T : IEntity
		{
			throw new System.NotImplementedException();
		}


		public Task<T> ItemById<T>(string id) where T : IEntity, new()
		{
			throw new System.NotImplementedException();
		}


		public Task<List<T>> Items<T>() where T : IEntity, new()
		{
			throw new System.NotImplementedException();
		}


		public Task UpdateEntityAsync<T>(T item) where T : IEntity, new()
		{
			throw new System.NotImplementedException();
		}
	}
}
