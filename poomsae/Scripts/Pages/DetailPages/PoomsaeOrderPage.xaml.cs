//-----------------------------------------------------------------------
// <copyright file="PoomsaeOrderPage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using CrossPlatformToolSample.Services;
using Xamarin.Forms;

namespace Poomsae
{
    public partial class PoomsaeOrderPage : ContentPage
    {
        public PoomsaeOrderPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            // Button button = (Button)sender;
            // 親をとってその子のLabel.
            var titleLabel = this.FindByName<Label>("valueLabel");
            var title = "クリップボードにコピー";
            var message = "クリップボードにコピーしました。";
            await DisplayAlert(title, message, "OK");

            // クリップボードにコピー.
            DependencyService.Get<ICrossPlatformToolService>().CopyToClipboard(titleLabel.Text);
        }
    }
}
