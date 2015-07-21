using PhotoTransfer.Data.Interfaces.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoTransfer.Services.DataBases.Interfaces
{
	public interface IInternalStorage
	{
		Task Save<T>(T item)
			where T : IEntity, new();

		Task Update<T>(T item)
			where T : IEntity, new();

		Task<List<T>> Items<T>()
			where T : IEntity, new();

		Task<T> ItemById<T>(string id)
			where T : IEntity, new();

		Task ResetItems<T>()
			where T : IEntity, new();

		Task Initialize();
	}
}
