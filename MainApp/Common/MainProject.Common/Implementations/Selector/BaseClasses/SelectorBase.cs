using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.Common.Implementations.Selector.Common;
using PhotoTransfer.Common.Interfaces.Selector;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoTransfer.Common.Implementations.Selector.BaseClasses
{
	public abstract class SelectorBase<TVm, TItem, TContainer> : ISelector<TVm, TItem, TContainer>
		where TItem : class
	{
		#region Properties

		public virtual List<IMapping<TItem>> Mappings { get; set; }

		#endregion

		#region Constructors

		public SelectorBase()
		{
			Mappings = new List<IMapping<TItem>>();			
		}

		#endregion

		#region ISelector Implementation

		public TItem SelectItem(TVm item)
		{
			var mapping = Mappings.FirstOrDefault(x => GetKey(item).Equals(x.Key));
			return mapping.With(x => x.Value);
		}

		public TItem SelectItem(TVm item, TContainer container)
		{
			return container == null ? SelectItem(item) : SelectItemPrivate(item, container);
		}

		protected abstract object GetKey(TVm vmFrom);

		#endregion

		#region Protected methods

		protected virtual TItem SelectItemPrivate(TVm item, TContainer container)
		{
			return default(TItem);
		}

		#endregion
	}
}
