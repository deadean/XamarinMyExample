using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Data.Interfaces.Entities.Photo
{
	public interface IComment:IEntity
	{
		string Comment { get; set; }
	}
}
