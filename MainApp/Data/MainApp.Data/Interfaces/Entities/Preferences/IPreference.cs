using PhotoTransfer.Data.Enums;
using System;

namespace PhotoTransfer.Data.Interfaces.Entities.Preferences
{
	public interface IPreference : IEntity, IEquatable<IPreference>
	{
		string Name { get; set; }
		string Value { get; set; }
		enPreferenceType PreferenceType { get; set; }
	}
}
