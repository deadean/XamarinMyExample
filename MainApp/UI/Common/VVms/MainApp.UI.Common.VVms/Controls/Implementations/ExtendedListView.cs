using PhotoTransfer.UI.Common.VVms.Controls.Interfaces.DataTemplateSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.VVms.Controls.Implementations
{
	public class ExtendedListView : ListView
	{
		BindableProperty ItemTemplateSelectorProperty = BindableProperty.Create<ExtendedListView, IDataTemplateSelector>(x => x.ItemTemplateSelector, null);

		private static void OnDataTemplateSelectorChanged(BindableObject bindable, object oldvalue, object newvalue)
		{
			((ExtendedListView)bindable).OnDataTemplateSelectorChanged((IDataTemplateSelector)oldvalue, (IDataTemplateSelector)newvalue);
		}

		protected virtual void OnDataTemplateSelectorChanged(IDataTemplateSelector oldValue, IDataTemplateSelector newValue)
		{
			if (ItemTemplate != null && newValue != null)
				throw new ArgumentException("Cannot set both ItemTemplate and ItemTemplateSelector", "ItemTemplateSelector");

			ItemTemplateSelector = newValue;
		}

		public IDataTemplateSelector ItemTemplateSelector 
		{
			get
			{
				return GetValue(ItemTemplateSelectorProperty) as IDataTemplateSelector;
			}

			set
			{
				SetValue(ItemTemplateSelectorProperty, value);
			}
		}

		protected override Cell CreateDefault(object item)
		{
			if (ItemTemplateSelector == null)
				return base.CreateDefault(item);

			var template = ItemTemplateSelector.SelectTemplate(item, this);

			if (template == null)
				return base.CreateDefault(item);

			var templatedInstance = template.CreateContent();

			return templatedInstance as Cell ?? 
				(templatedInstance is View ? new ViewCell { View = templatedInstance as View } : null);
		}
	}
}
