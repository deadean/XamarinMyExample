using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.VVms.Implementations.Messages
{
	public class OnNavigatedFromMessage:MessageBase
	{

	}

	public class OnNavigatedFromMessage<T> : OnNavigatedFromMessage
	{
		public T Sender { get; set; }
	}
}
