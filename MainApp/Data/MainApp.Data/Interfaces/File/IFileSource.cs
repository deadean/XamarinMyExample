using System.IO;
using System.Threading.Tasks;

namespace PhotoTransfer.Data.Interfaces.File
{
	public interface IFileSource
	{
		object File { get; }
		string Name { get; }
		string FullName { get; }
		string FilePath { get; }
		bool IsNew { get; }
		bool IsTemporary { get; }
		Task DeleteAsync();
	}
}
