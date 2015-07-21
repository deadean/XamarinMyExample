using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Enums;
using XLabs.Forms.Controls;

namespace PhotoTransfer.UI.Common.Views.Controls.Implementations
{
	public class ComboboxCell : ExtendedTextCell
	{		
		public static readonly BindableProperty IsEditableProperty = BindableProperty.Create<ComboboxCell, bool>(x => x.IsEditable, default(bool));

		public bool IsEditable
		{
			get
			{
				return (bool)GetValue(IsEditableProperty);
			}

			set
			{
				SetValue(IsEditableProperty, value);
			}
		}

		public ComboboxCell()
		{			
			var cmb = new Combobox<string>();
		}
	}
}
