using System;

namespace PhotoTransfer.Common.Implementations.Selector.Common
{	
	public interface IMapping<TValue>
	{
		object Key { get; set; }
		TValue Value { get; set; }
	}
}
