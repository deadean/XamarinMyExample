using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.WP.Services.Utils
{
	public static class NameGenerator
	{
		public static string GeneratedImageName
		{
			get
			{
				return "img" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
			}			
		}
	}
}
