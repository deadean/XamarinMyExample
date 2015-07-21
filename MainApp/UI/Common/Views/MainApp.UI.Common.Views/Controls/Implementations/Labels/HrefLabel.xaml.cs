using Library.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.Views.Controls.Implementations.Labels
{
	public partial class HrefLabel : Label
	{
		public static readonly BindableProperty CommandProperty =
			BindableProperty.Create<HrefLabel, ICommand>(
				x => x.Command,
				default(ICommand));

		public HrefLabel()
		{
			InitializeComponent();

			GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new DelegateCommand(OnTap)
			});
		}

		public ICommand Command
		{
			get
			{
				return (ICommand)GetValue(CommandProperty);
			}

			set
			{
				SetValue(CommandProperty, value);
			}
		}

		private void OnTap()
		{
			Command.With(x => x.Execute(null));
		}
	}
}
