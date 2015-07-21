using Library.Extensions;

using PhotoTransfer.Data.Interfaces.Entities.Preferences;

using System;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages.Preferences
{
	public class TextPreferenceVm : PreferenceBaseVm
	{
		public TextPreferenceVm(IPreference preference) : base(preference)
		{
		}
	}
}
