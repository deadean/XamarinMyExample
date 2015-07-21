using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Interfaces.ProgressBar
{
	public interface IProgressBarService
	{
		Task Start();

		Task Stop();
	}
}
