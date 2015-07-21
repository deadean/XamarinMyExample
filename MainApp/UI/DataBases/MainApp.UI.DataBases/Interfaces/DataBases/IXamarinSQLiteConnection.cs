using SQLite;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.DataBases.Interfaces.DataBases
{
	public interface IXamarinSQLiteConnection
	{
		SQLiteAsyncConnection GetConnection();
	}
}
