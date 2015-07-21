using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.Services.WebService.Interfaces.Photo;
using PhotoTransfer.UI.Common.Interfaces.DependencyBlock;
using PhotoTransfer.UI.Common.Interfaces.Image;
using PhotoTransfer.UI.Common.Interfaces.Photo;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.VVms.Implementations.DependencyBlock
{
	public class MainPageDependencyBlock : IMainPageDependencyBlock
	{
		private readonly IPhotoService modPhotoService;
		private readonly IApplicationWebService modPhotoWebService;
		private readonly IInternalModelService modModelService;
		private readonly IPreferencesService modPreferencesService;

		public MainPageDependencyBlock(IPhotoService photoService, 
			//IApplicationWebService photoWebService,
			IInternalModelService modelService,
			IPreferencesService preferencesService)
		{
			modPhotoService = photoService;
			//modPhotoWebService = photoWebService;
			modModelService = modelService;
			modPreferencesService = preferencesService;
		}

		public IPhotoService PhotoService
		{
			get { return modPhotoService; }
		}

		public IApplicationWebService PhotoWebService
		{
			get { return modPhotoWebService; }
		}

		public IInternalModelService ModelService
		{
			get { return modModelService; }
		}

		public IPreferencesService PreferencesService 
		{
			get { return modPreferencesService; }
		}
	}
}
