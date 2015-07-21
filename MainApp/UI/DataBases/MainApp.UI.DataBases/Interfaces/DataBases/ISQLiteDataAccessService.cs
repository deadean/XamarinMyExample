using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.UI.DataBases.Interfaces.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.DataBases.Interfaces.DataBases
{
	public interface ISQLiteDataAccessService
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
