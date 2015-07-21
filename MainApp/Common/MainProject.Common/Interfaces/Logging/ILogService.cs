using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Common.Interfaces.Logging
{
	public interface ILogService
	{
		Task Write(string message);
		Task Write(Exception exception);

		Task<bool> CheckForExistingExceptions();
	}
}
