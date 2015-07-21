using PhotoTransfer.Data.Enums;
using PhotoTransfer.UI.Common.VVms.Controls.Implementations.DataTemplateSelector.BaseClasses;
using PhotoTransfer.UI.Common.VVms.Controls.Interfaces.DataTemplateSelector;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages.Preferences;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.VVms.Controls.Implementations.DataTemplateSelector
{
	public class PreferencesListTemplateSelector : DataTemplateSelectorBase<enPreferenceType, PreferenceBaseVm>
	{
		#region DataTemplateSelectorBase implementation

		protected override enPreferenceType GetKey(PreferenceBaseVm vmFrom)
		{
			return vmFrom.PreferenceType;
		}

		#endregion
	}
}
