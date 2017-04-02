//-----------------------------------------------------------------------
// <copyright file="YouTubePage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using OpenWebBrowserSample.Services;
    using Xamarin.Forms;

    /// <summary>
    /// You tube page.
    /// </summary>
    public sealed class YouTubePage : ContentPage
    {
        /// <summary>
        /// Gets or sets TouTube URL.
        /// </summary>
        /// <value>You tube URL.</value>
        public static string youTubeUrl { private get; set; }

        public YouTubePage()
        {
            var baseHtml = @"<!DOCTYPE html>
            <html>
            <head>
              <script src=""js/jquery.js""></script>
              <script src=""js/mediaelement-and-player.min.js""></script>
              <link rel=""stylesheet"" href=""css/mediaelementplayer.css"" />
              <video width=""100%"" id=""player1"" preload=""none"">
                <source type=""video/youtube"" src=""{0}"" />
              </video>
              <script>
                var player = new MediaElementPlayer('#player1');
              </script>
            </head>
            <body>
            <hr />
            上の動画をタップすると最大画面で動画が再生されます。<br />
			左上のボタンを押下で動画を閉じられます。
            </body>
            </html>";

            var htmlSource = string.Format(baseHtml, youTubeUrl);
            var html = new HtmlWebViewSource
            {
                Html = htmlSource,
                // パスを取る時.
                BaseUrl = DependencyService.Get<IWebBrowserService>().Get(),
            };

            var webView = new WebView
            {
                Source = html
            };

            // iPhoneにおいて、ステータスバーとの重なりを防ぐためパディングを調整する.
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            Content = webView;
        }
    }
}
