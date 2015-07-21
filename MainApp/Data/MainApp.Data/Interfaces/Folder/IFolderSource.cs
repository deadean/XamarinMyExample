using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Data.Interfaces.Folder
{
	public interface IFolderSource
	{
		object Folder { get; }
		string Path { get; }
	}
}
