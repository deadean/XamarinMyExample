using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Data.Interfaces.Entities
{
	public interface IEntity
	{
		string IdEntity { get; }
		string ClassType { get; }
	}
}
