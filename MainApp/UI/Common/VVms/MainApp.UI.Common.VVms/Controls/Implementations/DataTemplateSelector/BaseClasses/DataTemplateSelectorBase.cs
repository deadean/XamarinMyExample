using PhotoTransfer.UI.Common.VVms.Controls.Implementations.DataTemplateSelector.Common;
using PhotoTransfer.UI.Common.VVms.Controls.Interfaces.DataTemplateSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.VVms.Controls.Implementations.DataTemplateSelector.BaseClasses
{
	public abstract class DataTemplateSelectorBase<TKey, TVm> : IDataTemplateSelector<TVm>
	{
		#region Properties

		public List<TemplateMapping<TKey>> TemplateMappings { set; get; }

		#endregion

		#region Constructors

		public DataTemplateSelectorBase()
		{
			TemplateMappings = new List<TemplateMapping<TKey>>();
		}

		#endregion

		#region IDataTemplateSelector Implementation

		public virtual DataTemplate SelectTemplate(TVm item, BindableObject container)
		{			
			var mapping = TemplateMappings.FirstOrDefault(x => x.Key.Equals(GetKey(item)));
			return mapping == null ? null : mapping.Template;
		}

		protected abstract TKey GetKey(TVm vmFrom);

		#endregion

		#region Public methods

		public DataTemplate SelectTemplate(object item, BindableObject container)
		{
			return SelectTemplate((TVm)item, container);
		}

		#endregion
	}
}
