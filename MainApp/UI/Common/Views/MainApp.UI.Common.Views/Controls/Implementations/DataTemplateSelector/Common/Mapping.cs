using PhotoTransfer.Common.Implementations.Selector.Common;
using System;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.Views.Controls.Implementations.DataTemplateSelector.Common
{	
	[ContentProperty("Value")]
	public class Mapping<TValue> : IMapping<TValue>
	{
		public object Key { get; set; }
		public TValue Value { get; set; }
	}
}
