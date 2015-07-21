using Library.Types;
using PhotoTransfer.Data.Interfaces.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Interfaces.LocatorStrategies
{
	public interface IMainPageLocatorStrategy<T>
		where T : class, INavigableAdvancedViewModelBase
	{
		//Task OpenPreferences(T mainPage);
		//Task OnNavigateOnSavingPhotos(T mainPage, IList<IFileSource> photos);
	}
}
