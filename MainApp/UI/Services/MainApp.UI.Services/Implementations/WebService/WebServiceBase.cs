using GalaSoft.MvvmLight.Ioc;
using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Data.Interfaces.File;
using PhotoTransfer.Services.WebService.Interfaces;
using PhotoTransfer.Services.WebService.Interfaces.Photo;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using PhotoTransfer.Data.Constants.Language;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;

namespace PhotoTransfer.WP.Services.Implementations.WebService
{
	public abstract class ApplicationWebServiceBase : IApplicationWebService
	{

		#region Fields

		private IPreferencesService modPreferencies;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		protected ApplicationWebServiceBase(IPreferencesService preferencies)
		{
			modPreferencies = preferencies;
		}

		protected ApplicationWebServiceBase() : this(ServiceLocator.Current.GetInstance<IPreferencesService>()) { }

		#endregion

		#region Public Methods



		#region IWebService methods abstraction

		public abstract Task UploadLogFile(string logFilePath);

		public abstract Task UploadPhoto(IFileSource fileSource, IComment comment);

		public abstract Task UploadPhoto(IPhoto photo, IComment comment);

		#endregion

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		protected Task<string> GetPreferredUrl()
		{
			return modPreferencies.GetPreference(TranslationKeys.WEB_SERVER_URL);
		}

		#endregion





	}
}
