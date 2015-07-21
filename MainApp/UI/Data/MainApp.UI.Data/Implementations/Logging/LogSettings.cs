using PhotoTransfer.Data.Interfaces.Logging;
using PhotoTransfer.UI.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Data.Implementations.Logging
{
	public sealed class LogSettings : ILoggingSettings
	{

		#region Fields

		#endregion

		#region Properties

		public string LogFormat
		{
			get;
			private set;
		}

		public string LogFile
		{
			get;
			private set;
		}

		#endregion

		#region Ctor

		public LogSettings()
		{
			LogFormat = Constants.Configuration.LoggingSettings.LogStringFormat;
			LogFile = Constants.Configuration.LoggingSettings.LogFile;
		}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion



		
	}
}
