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
	public class PhotoComment : AbstractEntityBase, IComment
	{
		#region Fields

		#endregion

		#region Properties

		public string Comment
		{
			get;
			set;
		}

		[PrimaryKey]
		public string ID { get; set; }

		[ManyToMany(typeof(PhotoCommentRelation),
			CascadeOperations = CascadeOperation.All)]
		public List<Photo> PhotoCommentRelation { get; set; }

		#endregion

		#region Ctor

		public PhotoComment() { }

		public PhotoComment(string comment)
		{
			Comment = comment;
			ID = KeyGenerator.GetKey(ClassType);
			PhotoCommentRelation = new List<Photo>();
		}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		protected override void GenerateId()
		{
			this.GenerateIdAndClassType(Constants.Entitites.csComment);
		}

		protected override string PrivateGetEntityId()
		{
			return this.ID;
		}

		#endregion

	}
}
