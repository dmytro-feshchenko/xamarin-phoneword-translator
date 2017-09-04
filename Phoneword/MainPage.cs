using System;

using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        Entry phoneWordText;
        Button translateButton;
        Button callButton;
        Entry translatedText;

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

            panel.Children.Add(new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Translated number:"
            });

            panel.Children.Add(translatedText = new Entry {
                Text = "No any number translated yet.",
                IsEnabled = false,
            });

			panel.Children.Add(callButton = new Button
			{
				Text = "Call is not available now.",
                IsEnabled = false
			});

            translateButton.Clicked += this.OnTranslate;

            this.Content = panel;
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = phoneWordText.Text;
            string translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);
            if (!String.IsNullOrEmpty(translatedNumber))
            {
                // Display the number and enable call button
                this.callButton.IsEnabled = true;
                this.callButton.Text = "Call " + translatedNumber;
                this.translatedText.Text = translatedNumber;
            }
            else
            {
                // Validation error
                this.callButton.IsEnabled = false;
                this.callButton.Text = "Call is not available now.";
                this.translatedText.Text = "It seems this text is not valid phone number.";
            }
        }
    }
}