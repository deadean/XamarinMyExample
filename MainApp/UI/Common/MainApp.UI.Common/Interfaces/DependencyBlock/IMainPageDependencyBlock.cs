using PhotoTransfer.Services.DataBases.Interfaces;
using PhotoTransfer.Services.WebService.Interfaces.Photo;
using PhotoTransfer.UI.Common.Interfaces.Image;
using PhotoTransfer.UI.Common.Interfaces.Photo;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Interfaces.DependencyBlock
{
	public interface IMainPageDependencyBlock
	{
		//IPhotoService PhotoService { get; }
		IInternalModelService ModelService { get; }
		//IPreferencesService PreferencesService { get; }
	}
}
