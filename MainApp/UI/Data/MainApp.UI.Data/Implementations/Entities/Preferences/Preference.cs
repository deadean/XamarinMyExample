using PhotoTransfer.Data;
using PhotoTransfer.Data.Constants;
using PhotoTransfer.Data.Enums;
using PhotoTransfer.Data.Interfaces.Entities.Preferences;
using PhotoTransfer.UI.Data.Bases.Entities;
using SQLite.Net.Attributes;

namespace PhotoTransfer.UI.Data.Implementations.Entities.Preferences
{
	public class Preference : AbstractEntityBase, IPreference
	{
		#region Properties

		[PrimaryKey]
		public string ID { get; set; }

		public string Name { get; set; }

		public string Value { get; set; }

		public enPreferenceType PreferenceType { get; set; }

		public bool Equals(IPreference other)
		{
			return other.Name == other.Name && other.Value == other.Value;
		}

		#endregion
		
		#region AbstractEntityBase Implementation
		
		protected override string PrivateGetEntityId()
		{
			return ID;
		}

		protected override void GenerateId()
		{
			GenerateIdAndClassType(Constants.Entitites.csPreference);
			ID = KeyGenerator.GetKey(ClassType);
		}

		#endregion
	}
}
