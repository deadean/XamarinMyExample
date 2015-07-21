using PhotoTransfer.Common.Interfaces.Factories;
using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Data.Interfaces.Entities.Preferences;
using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.UI.Data.Implementations.Entities.Photo;
using PhotoTransfer.UI.Data.Implementations.Entities.Preferences;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.DataBases.Implementations.ModelService
{
	public class InternalModelService : IInternalModelService
	{

		#region Fields

		private readonly IInternalStorage modStorage;
		private readonly IObjectsByTypeFactory modFactoryObjects;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public InternalModelService(
			IInternalStorage storage
			, IObjectsByTypeFactory factory
			)
		{
			modStorage = storage;
			modFactoryObjects = factory;

			InitObjectsFactory();
		}

		#endregion

		#region Public Methods

		public async Task SaveCommentToPhoto(IPhoto photo, string comment)
		{
			try
			{
				var photos = await modStorage.Items<Photo>();
				bool isPhotoExist = photos.Any(x => x.IdEntity == photo.IdEntity);
				Photo photoItem = photo as Photo;
				if (isPhotoExist)
				{
					if (photoItem.PhotoCommentRelation.Any())
					{
						photoItem.PhotoCommentRelation.First().Comment = comment;
					}
					else
					{
						PhotoComment commentItem = new PhotoComment(comment);
						PhotoCommentRelation relation = new PhotoCommentRelation(photo.IdEntity, commentItem.IdEntity);
						photoItem.PhotoCommentRelation.Add(commentItem);
						commentItem.PhotoCommentRelation.Add(photoItem);
					}
					await modStorage.Update<Photo>(photoItem);
					//await modStorage.Update<PhotoComment>(photoItem.PhotoCommentRelation.First());
					//await modStorage.Update<PhotoCommentRelation>(photoItem.PhotoCommentRelation.First());
				}
				else
				{
					PhotoComment commentItem = new PhotoComment(comment);
					PhotoCommentRelation relation = new PhotoCommentRelation(photo.IdEntity, commentItem.IdEntity);
					photoItem.PhotoCommentRelation.Add(commentItem);
					commentItem.PhotoCommentRelation.Add(photoItem);

					await modStorage.Save<Photo>(photoItem);
					await modStorage.Save<PhotoComment>(commentItem);
					await modStorage.Save<PhotoCommentRelation>(relation);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}			
		}

		public async Task<IComment> GetCommentByPhoto(string photoFileName)
		{
			try
			{
				var photoComents = await modStorage.Items<PhotoComment>();
				var comment = photoComents.FirstOrDefault(x => x.PhotoCommentRelation.Any(y => y.FileName == photoFileName));
				return comment;
			}
			catch (Exception ex)
			{

			}
			return null;
		}

		public async Task ResetPrefrencesTable()
		{
			await modStorage.ResetItems<Preference>();
			
		}

		public Task SaveEntity<T>(T item) where T : IEntity, new()
		{
			return modStorage.Save<T>(item);
		}

		public Task UpdateEntityAsync<T>(T item) where T : IEntity, new()
		{
			return modStorage.Update<T>(item);
		}

		public Task<T> CreateEntity<T>() where T : IEntity
		{
			return Task.Run(() => modFactoryObjects.GetObjectFromFactory<T>());
		}

		public Task<T> ItemById<T>(string id) where T : IEntity, new()
		{
			return modStorage.ItemById<T>(id);
		}

		public Task<List<T>> Items<T>() where T : IEntity, new()
		{
			return modStorage.Items<T>();
		}

		#endregion

		#region Private Methods

		private void InitObjectsFactory()
		{
			modFactoryObjects.RegisterObject<IPhoto, Photo>();
			modFactoryObjects.RegisterObject<IPhotoCommentRelation, PhotoCommentRelation>();
			modFactoryObjects.RegisterObject<IComment, PhotoComment>();
			modFactoryObjects.RegisterObject<IPreference, Preference>();
		}

		#endregion


		public Task Initialize()
		{
			return modStorage.Initialize();
		}
	}
}
