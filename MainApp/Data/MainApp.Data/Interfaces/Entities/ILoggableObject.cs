using PhotoTransfer.Common.Interfaces.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Data.Interfaces.Entities
{
	public interface ILoggableObject
	{
		ILogService GetLog();
	}
}
