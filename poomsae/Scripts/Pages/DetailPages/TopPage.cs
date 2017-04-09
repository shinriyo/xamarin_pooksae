//-----------------------------------------------------------------------
// <copyright file="TopPage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using LoadingMessageSample.Services;
    using Xamarin.Forms;

    /// <summary>
    /// メイン.
    /// My content page.
    /// </summary>
    public sealed class TopPage : ContentPage, IDetail
    {
        /// <summary>
        /// Init this instance.
        /// </summary>
        public ContentPage Init()
        {
            return new TopPage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Poomsae.TopPage"/> class.
        /// </summary>
        public TopPage()
        {
            // ページのタイトル.
            base.Title = "TOP";

            // iPhoneにおいて、ステータスバーとの重なりを防ぐためパディングを調整する.
            base.Padding = new Thickness(0, Tools.GetPlatformPaddingSize(), 0, 0);

            var layout = new StackLayout();

            // ラベルを１つ生成.
            var titleLabel = new Label
            {
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Center,
                Text = "TaekwonDict",
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic,
            };

            layout.Children.Add(titleLabel);

            var titleLogoImage = new Image()
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromResource("poomsae.Resources.titleLogoImage.png")
            };
            layout.Children.Add(titleLogoImage);

            // 下のレイアウト.
            var bottomLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.EndAndExpand,
                // 下から上げる.
                Padding = new Thickness(0, 0, 0, 20),
            };

            var initializeButton = new Button
            {
                Text = "初期化",
                FontSize = 22,
                BackgroundColor = Color.FromHex("34B9FF"),
                TextColor = Color.FromHex("000000"),
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic,
            };
            bottomLayout.Children.Add(initializeButton);

            initializeButton.Clicked += async (sender, args) =>
            {
                var ok = "実行";
                var cancel = "キャンセル";
                var message = "初期化しますがよろしいですか？";
                var result = await DisplayActionSheet(message, cancel, ok);
                if (result == ok)
                {
                    // ローディング開始.
                    DependencyService.Get<ILoadingMessage>().Show("ローディング....");

                    // DB初期化やCSVをWebからロード.
                    bool isSuccess = await Tools.Initialization();
                    this.ShowResultDialog(isSuccess);

                    // ローディング閉じる.
                    DependencyService.Get<ILoadingMessage>().Hide();
                }
            };

            var logoImage = new Image()
            {
                WidthRequest = 120,
                HorizontalOptions = LayoutOptions.End,
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("World_Taekwondo_Federation_Logo.png")
            };
            bottomLayout.Children.Add(logoImage);

            // ラベルを１つ生成.
            var campanyLabel = new Label
            {
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End,
                Text = "(c)shinriyo"
            };
            bottomLayout.Children.Add(campanyLabel);

            layout.Children.Add(bottomLayout);

            // Admob
            var banner = new Xamarinos.AdMob.Forms.AdBanner();
            banner.AdID = "ca-app-pub-0808805008177805/7436471671";
            bottomLayout.Children.Add(banner);

            // 生成したラベルをこのビューの子要素とする
            base.Content = layout;
        }

        /// <summary>
        /// DL結果のダイアログ.
        /// </summary>
        /// <param name="isSuccess">If set to <c>true</c> is success.</param>
        public void ShowResultDialog(bool isSuccess)
        {
            if (isSuccess)
            {
                DisplayAlert("成功", "初期化に成功しました。", "OK");
            }
            else
            {
                DisplayAlert("エラー", "初期化に失敗しました。", "閉じる。");
            }
            System.Diagnostics.Debug.WriteLine(isSuccess);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Poomsae.DetailObject"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Poomsae.DetailObject"/>.</returns>
        public override string ToString()
        {
            // これがそのままタイトルになるので.
            return this.Title;
        }
    }
}
