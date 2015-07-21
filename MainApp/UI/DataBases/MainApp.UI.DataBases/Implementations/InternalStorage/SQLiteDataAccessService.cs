using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.UI.Data.Implementations.Entities.Photo;
using PhotoTransfer.UI.Data.Implementations.Entities.Preferences;
using PhotoTransfer.UI.DataBases.Interfaces.DataBases;

using SQLite;
using SQLite.Net.Async;
using SQLiteNetExtensionsAsync.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.DataBases.Implementations.InternalStorage
{
	public class SQLiteDataAccessService : ISQLiteDataAccessService
	{
		#region Fields

		private SQLiteAsyncConnection modConnection;
		private readonly ISQLiteConnection modConnectionInfo;

		#endregion

		#region Ctor

		public SQLiteDataAccessService(ISQLiteConnection connection)
		{
			modConnectionInfo = connection;
		}

		#endregion

		#region Public Methods

		public async Task Save<T>(T item) where T : IEntity, new()
		{
			await modConnection.InsertAsync(item);
			await modConnection.UpdateWithChildrenAsync(item);
		}

		public async Task Update<T>(T item) where T : IEntity, new()
		{
			await modConnection.InsertOrReplaceWithChildrenAsync(item);
		}

		public async Task<List<T>> Items<T>() where T : IEntity, new()
		{
			var res = await modConnection.GetAllWithChildrenAsync<T>();
			return res;
		}

		public Task<T> ItemById<T>(string id) where T : IEntity, new()
		{
			return modConnection.GetAsync<T>((item) => item.IdEntity == id);
		}

		public async Task ResetItems<T>() where T : IEntity, new()
		{
			await modConnection.DropTableAsync<T>();
			await modConnection.CreateTableAsync<T>();		
		}

		public async Task Initialize()
		{
			ConnectionInfo<SQLiteAsyncConnection> connectionInfo = await modConnectionInfo.GetConnection();
			modConnection = connectionInfo.Connection;

			if (connectionInfo.IsInitializedDbStructure)
				return;

			await modConnection.DropTableAsync<PhotoCommentRelation>();
			await modConnection.DropTableAsync<PhotoComment>();
			await modConnection.DropTableAsync<Photo>();
			await modConnection.DropTableAsync<Preference>();

			await modConnection.CreateTableAsync<PhotoComment>();
			await modConnection.CreateTableAsync<Photo>();
			await modConnection.CreateTableAsync<PhotoCommentRelation>();
			await modConnection.CreateTableAsync<Preference>();
		}

		#endregion

		#region Private Methods		

		#endregion		
	}
}
