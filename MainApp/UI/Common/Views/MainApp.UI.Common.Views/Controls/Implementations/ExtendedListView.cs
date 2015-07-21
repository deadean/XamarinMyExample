using PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using ISelector = PhotoTransfer.Common.Interfaces.Selector.ISelector<
	object,
	Xamarin.Forms.DataTemplate,
	Xamarin.Forms.BindableObject>;

namespace PhotoTransfer.UI.Common.Views.Controls.Implementations
{
	public class ExtendedListView : ListView
	{
		#region Bindable properties

		BindableProperty ItemTemplateSelectorProperty = BindableProperty.Create<ExtendedListView, ISelector>(x => x.ItemTemplateSelector, null);

		#endregion

		#region Handlers

		private static void OnDataTemplateSelectorChanged(BindableObject bindable, object oldvalue, object newvalue)
		{			
			((ExtendedListView)bindable).OnDataTemplateSelectorChanged((ISelector)oldvalue, (ISelector)newvalue);
		}

		protected virtual void OnDataTemplateSelectorChanged(ISelector oldValue, ISelector newValue)
		{
			if (ItemTemplate != null && newValue != null)
				throw new ArgumentException("Cannot set both ItemTemplate and ItemTemplateSelector", "ItemTemplateSelector");

			ItemTemplateSelector = newValue;
		}

		#endregion

		#region Properties

		public ISelector ItemTemplateSelector 
		{
			get
			{
				return GetValue(ItemTemplateSelectorProperty) as ISelector;
			}

			set
			{
				SetValue(ItemTemplateSelectorProperty, value);
			}
		}

		#endregion

		#region Methods

		protected override Cell CreateDefault(object item)
		{
			if (ItemTemplateSelector == null)
				return base.CreateDefault(item);

			var template = ItemTemplateSelector.SelectItem(item as PreferenceBaseVm);

			if (template == null)
				return base.CreateDefault(item);

			var templatedInstance = template.CreateContent();
			
			return templatedInstance as Cell ?? 
				(templatedInstance is View ? new ViewCell { View = templatedInstance as View } : null);
		}

		#endregion
	}
}
