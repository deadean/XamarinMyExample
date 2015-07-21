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
	public class Photo : AbstractEntityBase, IPhoto
	{
		#region Fields

		#endregion

		#region Properties

		public string FileName { get; set; }

		public byte[] Data { get; set; }

		[PrimaryKey]
		public string ID { get; set; }

		[ManyToMany(typeof(PhotoCommentRelation),
			CascadeOperations = CascadeOperation.All)]
		public List<PhotoComment> PhotoCommentRelation { get; set; }

		public IEnumerable<IComment> Comments
		{
			get { return PhotoCommentRelation; }
		}		

		#endregion

		#region Ctor

		public Photo()
		{
			ID = KeyGenerator.GetKey(ClassType);
			PhotoCommentRelation = new List<PhotoComment> { new PhotoComment() };
		}

		#endregion

		#region Public Methods
		
		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		protected override void GenerateId()
		{
			this.GenerateIdAndClassType(Constants.Entitites.csPhoto);
		}

		protected override string PrivateGetEntityId()
		{
			return this.ID;
		}

		#endregion
	}
}
