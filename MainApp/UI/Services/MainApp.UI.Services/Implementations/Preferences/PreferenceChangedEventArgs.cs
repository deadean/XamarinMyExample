using PhotoTransfer.UI.Common.Interfaces.Preferences;
using System;

namespace PhotoTransfer.WP.Services.Implementations.Preferences
{
	public class PreferenceChangedEventArgs : IPreferenceChangedEventArgs
	{
		public string PreferenceName { get; set; }		
	}

	public class PreferenceChangedEventArgs<T> : IPreferenceChangedEventArgs<T>
	{
		public string PreferenceName { get; set; }
		public T Value { get; set; }
	}
}
