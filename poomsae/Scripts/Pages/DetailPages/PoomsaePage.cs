//-----------------------------------------------------------------------
// <copyright file="PoomsaePage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using Xamarin.Forms;

    /// <summary>
    /// ナビゲーション.
    /// </summary>
    class PoomsaePage : ContentPage, IDetail
    {
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Poomsae.DetailObject"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Poomsae.DetailObject"/>.</returns>
        public override string ToString()
        {
            // これがそのままタイトルになるので.
            return this.Title;
        }

        /// <summary>
        /// Init this instance.
        /// </summary>
        public ContentPage Init()
        {
            return new PoomsaePage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Poomsae.PoomsaePage"/> class.
        /// </summary>
        public PoomsaePage()
        {
            this.Title = "Poomsae"; //ページのタイトル

            var layout = new StackLayout();

            var label = new Label()
            {
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "選択"
            };

            layout.Children.Add(label);

            // ボタンを生成.
            var button1 = new Button { Text = "詳細(級)" };

            //ボタンクリック時の処理
            button1.Clicked += async (s, a) =>
            {
                // ページを遷移する.
                await Navigation.PushAsync(new KyuPoomsaeDetailPage());
            };

            layout.Children.Add(button1);

            this.Content = layout;

            // ボタンを生成.
            var button2 = new Button { Text = "詳細(段)" };

            //ボタンクリック時の処理
            button2.Clicked += async (s, a) =>
            {
                // ページを遷移する.
                await Navigation.PushAsync(new DanPoomsaeDetailPage());
            };

            // TODO: Reactive待ち.
            //button2.ClickAsObservable()
            //    .Publish(_ =>
            //        Button2.ClickAsObservable()
            //        .Amb(
            //            Button3.ClickAsObservable()))
            //    .Subscribe(btnName => InvokeOnMainThread(() =>
            //        Label1.Text = btnName + " Clicked"));

            layout.Children.Add(button2);
        }
    }
}
