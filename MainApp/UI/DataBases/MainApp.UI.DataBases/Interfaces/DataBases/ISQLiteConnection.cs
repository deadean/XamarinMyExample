using PhotoTransfer.UI.DataBases.Implementations.InternalStorage;

using SQLite.Net.Async;

using System;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.DataBases.Interfaces.DataBases
{
	public interface ISQLiteConnection
	{
		Task<ConnectionInfo<SQLiteAsyncConnection>> GetConnection();
	}
}
