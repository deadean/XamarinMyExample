using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Data.Interfaces.Entities.Photo
{
	public interface IPhotoCommentRelation : IEntity
	{
		string PhotoId { get; }
		string PhotoCommentId { get; }
		//int IdObject { get; }
	}
}
