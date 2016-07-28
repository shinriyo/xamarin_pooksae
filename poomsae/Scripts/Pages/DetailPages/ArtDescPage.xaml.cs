using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poomsae
{
    public partial class ArtDescPage : ContentPage
    {
        public ArtDescPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }
    }
}
