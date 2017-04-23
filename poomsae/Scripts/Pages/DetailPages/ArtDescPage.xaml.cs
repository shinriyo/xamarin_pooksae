//-----------------------------------------------------------------------
// <copyright file="ArtDescPage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using CrossPlatformToolSample.Services;
using Xamarin.Forms;

namespace Poomsae
{
    public partial class ArtDescPage : ContentPage
    {
        public ArtDescPage()
        {
            InitializeComponent();

            // フォント
            var label = this.FindByName<Label>("koreanValueLabel");
            label.FontFamily = "SourceHanSerifKR-Bold";
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

        async void OnKoreanButtonClicked(object sender, EventArgs args)
        {
            // Button button = (Button)sender;
            // 親をとってその子のLabel.
            var titleLabel = this.FindByName<Label>("koreanValueLabel");
            var title = "クリップボードにコピー";
            var message = "クリップボードにコピーしました。";
            await DisplayAlert(title, message, "OK");

            // クリップボードにコピー.
            DependencyService.Get<ICrossPlatformToolService>().CopyToClipboard(titleLabel.Text);
        }
    }
}
