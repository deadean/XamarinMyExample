using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.UI.Data.Implementations.Entities.Photo;
using PhotoTransfer.UI.DataBases.Interfaces.DataBases;
using SQLite;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.DataBases.Implementations.InternalStorage
{
	public class XamarinSQLiteDataAccessService : ISQLiteDataAccessService
	{

		#region Fields

		private readonly SQLiteAsyncConnection modConnection;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public XamarinSQLiteDataAccessService(IXamarinSQLiteConnection connection)
		{
			modConnection = connection.GetConnection();
			modConnection.CreateTableAsync<Photo>();
		}

		#endregion

		#region Public Methods

		public Task Save<T>(T item) where T : IEntity, new()
		{
			throw new NotImplementedException();
		}

		public Task<List<T>> Items<T>() where T : IEntity, new()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion







		
	}
}
