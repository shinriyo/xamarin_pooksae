using System;
using System.Collections.Generic;
using VideoPlayerSample.Services;
using Xamarin.Forms;

namespace Poomsae
{
    public partial class PlayVideoPage : ContentPage
    {
        public PlayVideoPage()
        {
            InitializeComponent();

            var uri = "http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_7200K.MP4";
            DependencyService.Get<IVideoPlayerService>().Open(uri);
        }

        private void OnButtonClicked(object sender, EventArgs args)
        {
            DependencyService.Get<IVideoPlayerService>().Play();
        }
    }
}

