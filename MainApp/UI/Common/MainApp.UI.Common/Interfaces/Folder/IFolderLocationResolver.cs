using PhotoTransfer.UI.Common.Enums.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Interfaces.Folder
{
	public interface IFolderLocationResolver
	{
		string ResolveLocation(enFileWorkerLocation location, bool isRelativeLocation = false);
	}
}
