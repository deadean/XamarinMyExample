using PhotoTransfer.Common.Implementations.Selector.BaseClasses;
using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages.Preferences;

using System;

using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.Views.Controls.Implementations.DataTemplateSelector
{
	[ContentProperty("Mappings")]
	public class TypeDataTemplateSelector : SelectorBase<object, DataTemplate, BindableObject>
	{
		protected override object GetKey(object vmFrom)
		{
			return vmFrom.GetType();
		}
	}
}
