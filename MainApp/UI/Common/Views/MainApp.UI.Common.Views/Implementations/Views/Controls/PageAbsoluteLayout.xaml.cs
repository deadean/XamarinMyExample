using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Controls
{
	public partial class PageAbsoluteLayout : ContentPage
	{
		const double squareSize = 35; 
		public PageAbsoluteLayout()
		{
			InitializeComponent();
			AbsoluteLayout absoluteLayout = new AbsoluteLayout
			{
				Padding = new Thickness(50),
				BackgroundColor = Color.FromRgb(240, 220, 130)
			};

			absoluteLayout.Children.Add(
					new BoxView
					{
						Color = Color.Blue
					},
					new Rectangle(0, 10, 200, 5));

			absoluteLayout.Children.Add(
					new BoxView
					{
						Color = Color.Blue
					},
					new Rectangle(0, 20, 200, 5));

			absoluteLayout.Children.Add(
					new BoxView
					{
						Color = Color.Blue
					},
					new Rectangle(10, 0, 5, 65));

			absoluteLayout.Children.Add(
					new BoxView
					{
						Color = Color.Blue
					},
					new Rectangle(20, 0, 5, 65));

			absoluteLayout.Children.Add(
					new Label
					{
						Text = "Stylish Header",
						FontSize = 24
					},
					new Point(30, 25));

			absoluteLayout.Children.Add(
					new Label
					{
						FormattedText = new FormattedString
						{
							Spans = 
                    {
                        new Span
                        {
                            Text = "Although the "
                        },
                        new Span
                        {
                            Text = "AbsoluteLayout",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = " is usually employed for purposes other " +
                                    "than the display of text using "
                        },
                        new Span
                        {
                            Text = "Label",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = ", obviously it can be used in that way. " +
                                    "The text continues to wrap nicely " +
                                    "within the bounds of the container " +
                                    "and any padding that might be applied."
                        }
                    }
						}
					},
					new Point(0, 80));

			AbsoluteLayout l1 = new AbsoluteLayout();

			for (int row = 0; row < 8; row++)
			{
				for (int col = 0; col < 8; col++)
				{
					// Skip every other square.
					if (((row ^ col) & 1) == 0)
						continue;  

					BoxView boxView = new BoxView { Color = Color.FromRgb(0, 64, 0) };
					Rectangle rect = new Rectangle(col * squareSize, row * squareSize, squareSize, squareSize);
					l1.Children.Add(boxView, rect);
				}
			} 

			absoluteLayout.Children.Add(l1, new Point(0, 130));

			this.Content = absoluteLayout;

		}
	}
}
