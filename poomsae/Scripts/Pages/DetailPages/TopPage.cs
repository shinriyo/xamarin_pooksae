﻿//-----------------------------------------------------------------------
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
    class TopPage : ContentPage, IDetail
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
            base.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            var layout = new StackLayout();
            var logoImage = new Image()
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("World_Taekwondo_Federation_Logo.png")
            };
            layout.Children.Add(logoImage);

            // ラベルを１つ生成.
            var titleLabel = new Label
            {
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Center,
                Text = "Taekwondo Dict"
            };

            layout.Children.Add(titleLabel);

            var initializeButton = new Button { Text = "初期化" };
            layout.Children.Add(initializeButton);

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

            // ラベルを１つ生成.
            var campanyLabel = new Label
            {
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                Text = "(c)shinriyo"
            };
            layout.Children.Add(campanyLabel);

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
