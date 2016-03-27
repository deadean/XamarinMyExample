using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using MainApp.UI.Common.VVms;
using System.Windows.Input;

namespace MainApp.UI.Common.Views.Implementations.Views.Controls
{
	public partial class PageCollectionViews : ContentPage
	{
		int xOffset = 0;
		// ranges from -2 to 2
		int yOffset = 0;
		// ra
		public PageCollectionViews ()
		{
			try {
				InitializeComponent ();
				MoveCommand = new Command<string> (ExecuteMove, CanExecuteMove);
				tb.BindingContextChanged += Tb_BindingContextChanged;
			} catch (Exception ex) {
				
			}
		}

		void Tb_BindingContextChanged (object sender, EventArgs e)
		{
			
		}

		public ICommand MoveCommand { private set; get; }

		void ExecuteMove (string direction)
		{
			switch (direction) {
			case "left":
				xOffset--;
				break;
			case "right":
				xOffset++;
				break;
			case "up":
				yOffset--;
				break;
			case "down":
				yOffset++;
				break;
			}
			((Command)MoveCommand).ChangeCanExecute ();
		
			AbsoluteLayout.SetLayoutBounds (boxView,
				new Rectangle ((xOffset + 2) / 4.0,
					(yOffset + 2) / 4.0, 0.2, 0.2));
		}

		bool CanExecuteMove (string direction)
		{
			switch (direction) {
			case "left":
				return xOffset > -2;
			case "right":
				return xOffset < 2;
			case "up":
				return yOffset > -2;
			case "down":
				return yOffset < 2;
			}
			return false;
		}


		void OnSubmitButtonClicked (object sender, EventArgs args)
		{
			PersonalInformation personalInfo = (PersonalInformation)tableView.BindingContext;
			summaryLabel.Text = String.Format (
				"{0} is {1} years old, and has an email address " +
				"of {2}, and a phone number of {3}, and is {4}" +
				"a programmer.",
				personalInfo.Name, personalInfo.Age,
				personalInfo.EmailAddress, personalInfo.PhoneNumber,
				personalInfo.IsProgrammer ? "" : "not ");
		}
	}
}
