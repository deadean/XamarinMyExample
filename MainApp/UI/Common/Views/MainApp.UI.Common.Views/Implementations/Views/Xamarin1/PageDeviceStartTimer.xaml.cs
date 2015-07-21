using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Xamarin1
{
	public partial class PageDeviceStartTimer : ContentPage
	{
		public PageDeviceStartTimer()
		{
			InitializeComponent();
			Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
		}

		bool OnTimerTick()
		{
			DateTime dt = DateTime.Now;
			timeLabel.Text = dt.ToString("T");
			dateLabel.Text = dt.ToString("D");
			return true;
		}
	}
}
