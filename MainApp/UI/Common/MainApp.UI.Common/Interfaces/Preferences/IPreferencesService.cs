using PhotoTransfer.Data.Interfaces.Entities.Preferences;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Interfaces.Preferences
{
	public interface IPreferencesService
	{
		event EventHandler<IPreferenceChangedEventArgs> PreferenceChanged;

		Task<bool> SavePreference<T>(string key, T value);		
		Task<string> GetPreference(string key);
		Task<IEnumerable<IPreference>> GetAllPreferencesAsync();
		Task ResetPreferencesToDefault();
		Task<IEnumerable<object>> ResolvePreferenceListValues(string key);
	}
}
