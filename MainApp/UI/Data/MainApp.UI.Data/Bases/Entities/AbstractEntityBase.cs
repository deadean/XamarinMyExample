using PhotoTransfer.Data;
using PhotoTransfer.Data.Interfaces.Entities;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Data.Bases.Entities
{
	public abstract class AbstractEntityBase : IEntity
	{

		#region Fields

		#endregion

		#region Properties

		public string ClassType { get; private set; }

		public string IdEntity
		{
			get { return PrivateGetEntityId(); }
		}

		protected abstract string PrivateGetEntityId();

		#endregion

		#region Ctor

		protected AbstractEntityBase() { GenerateId(); }

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		protected abstract void GenerateId();

		protected void GenerateIdAndClassType(string classType)
		{
			ClassType = classType;
		}

		#endregion




		
	}
}
