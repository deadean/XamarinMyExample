namespace PhotoTransfer.UI.Common.Interfaces.Preferences
{
	public interface IPreferenceChangedEventArgs
	{
		string PreferenceName { get; set; }
	}

	public interface IPreferenceChangedEventArgs<T> : IPreferenceChangedEventArgs
	{
		T Value { get; set; }
	}
}
