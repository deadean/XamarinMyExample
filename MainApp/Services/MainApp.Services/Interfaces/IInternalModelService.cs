using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.Data.Interfaces.Entities.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Services.DataBases.Interfaces
{
	public interface IInternalModelService
	{
		Task SaveCommentToPhoto(IPhoto photo, string comment);
		Task<IComment> GetCommentByPhoto(string photoFileName);
		Task ResetPrefrencesTable();
		Task SaveEntity<T>(T item) where T : IEntity, new();
		Task UpdateEntityAsync<T>(T item) where T : IEntity, new();
		Task<T> ItemById<T>(string id) where T : IEntity, new();
		Task<List<T>> Items<T>() where T : IEntity, new();
		Task<T> CreateEntity<T>() where T : IEntity;
		Task Initialize();
	}
}
