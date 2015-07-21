using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Data.Interfaces.Entities.Photo
{
	public interface IPhoto : IEntity
	{
		string FileName { get; set; }
		byte[] Data { get; set; }
		IEnumerable<IComment> Comments { get; }
	}
}
