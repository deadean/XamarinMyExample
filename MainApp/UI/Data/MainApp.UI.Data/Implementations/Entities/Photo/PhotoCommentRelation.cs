using PhotoTransfer.Data;
using PhotoTransfer.Data.Constants;
using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.UI.Data.Bases.Entities;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Data.Implementations.Entities.Photo
{
	public class PhotoCommentRelation : AbstractEntityBase, IPhotoCommentRelation
	{
		#region Properties

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[ForeignKey(typeof(Photo))]
		public string PhotoId { get; set; }

		[ForeignKey(typeof(PhotoComment))]
		public string PhotoCommentId { get; set; }

		#endregion

		#region Ctor

		public PhotoCommentRelation(string photoId, string commentId)
		{
			PhotoId = photoId;
			PhotoCommentId = commentId;
		}

		public PhotoCommentRelation(){}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		protected override void GenerateId()
		{
			this.GenerateIdAndClassType(Constants.Entitites.csPhotoCommentRelation);
		}

		protected override string PrivateGetEntityId()
		{
			return this.ID.ToString();
		}

		#endregion
		
	}
}
