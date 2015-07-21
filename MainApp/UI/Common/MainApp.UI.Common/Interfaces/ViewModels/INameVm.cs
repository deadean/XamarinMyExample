﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.UI.Common.Interfaces.ViewModels
{
	public interface INameVm
	{
		string Name { get; }
		void ChangeName(string newName);
	}
}
