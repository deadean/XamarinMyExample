using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using MainApp.UI.Common.VVms;

namespace MainApp.UI.Common.Views.Implementations.Views.Controls
{
	public partial class PageCollectionViews : ContentPage
	{
		public PageCollectionViews()
		{
			try {
				InitializeComponent();
			} catch (Exception ex) {
				
			}
		}

		void OnSubmitButtonClicked(object sender, EventArgs args)
		{
			PersonalInformation personalInfo = (PersonalInformation)tableView.BindingContext;
			summaryLabel.Text = String.Format(
				"{0} is {1} years old, and has an email address " +
				"of {2}, and a phone number of {3}, and is {4}" +
				"a programmer.",
				personalInfo.Name, personalInfo.Age,
				personalInfo.EmailAddress, personalInfo.PhoneNumber,
				personalInfo.IsProgrammer ? "" : "not ");
		}
	}
}
