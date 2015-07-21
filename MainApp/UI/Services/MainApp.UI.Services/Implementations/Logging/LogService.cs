using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.Common.Interfaces.Logging;
using PhotoTransfer.Data.Interfaces.Logging;
using PhotoTransfer.UI.Common.Constants;
using PhotoTransfer.UI.Common.Enums.File;
using PhotoTransfer.UI.Common.Interfaces.File;
using PhotoTransfer.WP.Services.Implementations.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(LogService))]

namespace PhotoTransfer.WP.Services.Implementations.Logging
{
	public class LogService : ILogService
	{

		#region Fields

		private readonly IFileWorkerService modFileWorkerService;
		private readonly ILoggingSettings modLoggingSettings;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public LogService() : this(
			ServiceLocator.Current.GetInstance<IFileWorkerService>(),
			ServiceLocator.Current.GetInstance<ILoggingSettings>()
			) { }

		[PreferredConstructor]
		public LogService(IFileWorkerService fileService, ILoggingSettings settings) 
		{
			modFileWorkerService = fileService;
			modLoggingSettings = settings;
		}

		#endregion

		#region Public Methods

		public async Task Write(string message)
		{
			try
			{
				string logMessage = string.Format(modLoggingSettings.LogFormat, DateTime.Now, message);
				modFileWorkerService.AddToTextFileAsync(modLoggingSettings.LogFile, logMessage + Environment.NewLine);
			}
			catch (Exception ex)
			{

			}
		}

		public async Task Write(Exception exception)
		{
			try
			{
				string logMessage = string.Format(modLoggingSettings.LogFormat, DateTime.Now, exception.ToString());
				modFileWorkerService.AddToTextFileAsync(modLoggingSettings.LogFile, logMessage+Environment.NewLine);
			}
			catch (Exception ex)
			{

			}
		}

		public async Task<bool> CheckForExistingExceptions()
		{
			try
			{
				var file = await modFileWorkerService.TryGetFileAsync(modLoggingSettings.LogFile, enFileWorkerLocation.Default);
				if (file == null)
					return false;

				var fileData = await modFileWorkerService.GetFileData(file);

				var text = System.Text.Encoding.UTF8.GetString(fileData, 0, fileData.Length);
				bool isExceptionExist =
						 text.Contains(Constants.Configuration.LoggingSettings.LogError)
					|| text.Contains(Constants.Configuration.LoggingSettings.LogException);

				bool isShouldCleanLogFile = !isExceptionExist
					&& this.ConvertBytesToMegabytes(fileData.LongCount()) > Constants.Configuration.LoggingSettings.LogFileSize;

				if (isShouldCleanLogFile)
				{
					await modFileWorkerService.SaveToTextFileAsync(modLoggingSettings.LogFile, string.Empty, enFileWorkerLocation.Default);
				}

				return isExceptionExist;
			}
			catch (Exception ex)
			{

			}
			return false;
		}

		#endregion

		#region Private Methods

		private double ConvertBytesToMegabytes(long bytes)
		{
			return (bytes / 1024f) / 1024f;
		}

		#endregion

		#region Protected Methods

		#endregion



		
	}
}
