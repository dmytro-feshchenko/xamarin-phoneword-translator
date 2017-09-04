using System;

using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        Entry phoneWordText;
        Button translateButton;
        Button callButton;

        public MainPage()
        {
			double topPadding = 0;
			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					topPadding = 40;
					break;
				default:
					topPadding = 20;
					break;
			}
            StackLayout panel = new StackLayout
            {
                Padding = new Thickness(20, topPadding, 20, 20),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 15,
            };

			panel.Children.Add(new Label {
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "Enter a password:"
			});

			panel.Children.Add(phoneWordText = new Entry {
				Text = "1-855-XAMARIN"
			});

            panel.Children.Add(translateButton = new Button {
                Text = "Translate"
            });

            panel.Children.Add(callButton = new Button
			{
				Text = "Call",
                IsEnabled = false
			});

            panel.Children.Add(new Entry {});

            this.Content = panel;
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = phoneWordText.Text;
            string translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);
            if (!String.IsNullOrEmpty(translatedNumber))
            {
                // todo: Display the number
            }
            else
            {
                // todo: Validation error
            }
        }
    }
}