using System;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.VVms.Controls.Implementations.DataTemplateSelector.Common
{
	public class TemplateMapping : TemplateMapping<object>
	{
	}

	public class TemplateMapping<TKey>
	{
		public TKey Key { get; set; }
		public DataTemplate Template { get; set; }
	}
}
