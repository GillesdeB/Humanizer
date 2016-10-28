using Humanizer;
using Humanizer.Localisation;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Humanizer_Nuget_package_test
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void BtnStart_OnClick(object sender, RoutedEventArgs e)
        {
            MessageDialog messageDialog;

            //Dates
            DateTime aDate = DateTime.UtcNow;
            messageDialog = new MessageDialog(aDate.Humanize());
            await messageDialog.ShowAsync();

            messageDialog = new MessageDialog(aDate.AddHours(-30).Humanize());
            await messageDialog.ShowAsync();

            messageDialog = new MessageDialog(aDate.AddHours(4).Humanize());
            await messageDialog.ShowAsync();

            // Timespan
            TimeSpan timeSpan = TimeSpan.FromSeconds(100);
            messageDialog = new MessageDialog(timeSpan.Humanize());
            await messageDialog.ShowAsync();

            timeSpan = TimeSpan.FromSeconds(100000);
            messageDialog = new MessageDialog(timeSpan.Humanize());
            await messageDialog.ShowAsync();

            messageDialog = new MessageDialog(timeSpan.Humanize(precision: 4));
            await messageDialog.ShowAsync();

            messageDialog = new MessageDialog(timeSpan.Humanize(precision: 2, maxUnit: TimeUnit.Hour, minUnit: TimeUnit.Second));
            await messageDialog.ShowAsync();

            // Plural & quantities
            var text = "process";
            messageDialog = new MessageDialog($"{text.ToQuantity(0)}, {text.ToQuantity(1)}, {text.ToQuantity(3)}");
            await messageDialog.ShowAsync();

            text = "men";
            messageDialog = new MessageDialog($"{text.ToQuantity(0, ShowQuantityAs.Words)}, {text.ToQuantity(1, ShowQuantityAs.Words)}, {text.ToQuantity(3, ShowQuantityAs.Words)}");
            await messageDialog.ShowAsync();

            text = "case";
            messageDialog = new MessageDialog($"{text.ToQuantity(0)}, {text.ToQuantity(1)}, {text.ToQuantity(3)}");
            await messageDialog.ShowAsync();

            text = "geese";
            messageDialog = new MessageDialog($"{text.ToQuantity(0)}, {text.ToQuantity(1)}, {text.ToQuantity(3)}");
            await messageDialog.ShowAsync();

            text = "one goose";
            messageDialog = new MessageDialog($"{text.ToQuantity(0)}, {text.ToQuantity(1)}, {text.ToQuantity(3)}");
            await messageDialog.ShowAsync();

            //Number to words
            messageDialog = new MessageDialog(1234.ToWords());
            await messageDialog.ShowAsync();

            messageDialog = new MessageDialog(1234456789.ToWords());
            await messageDialog.ShowAsync();

            messageDialog = new MessageDialog(1234.ToOrdinalWords());
            await messageDialog.ShowAsync();

            messageDialog = new MessageDialog(1234.Ordinalize());
            await messageDialog.ShowAsync();

            // Computer sizes
            messageDialog = new MessageDialog(1024.Kilobytes().ToString());
            await messageDialog.ShowAsync();

            messageDialog = new MessageDialog(532000.Kilobytes().ToString());
            await messageDialog.ShowAsync();

            messageDialog = new MessageDialog(1024.Kilobytes().AddKilobytes(512).Bytes.ToString());
            await messageDialog.ShowAsync();

            messageDialog = new MessageDialog(1024.Kilobytes().AddKilobytes(512).Megabytes.ToString());
            await messageDialog.ShowAsync();
        }
    }
}