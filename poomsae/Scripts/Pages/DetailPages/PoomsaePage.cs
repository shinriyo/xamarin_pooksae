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
            // ページのタイトル.
            this.Title = "プンセ";

            var layout = new StackLayout();

            var label = new Label()
            {
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "選択"
            };

            layout.Children.Add(label);

            // ボタンを生成.
            var button1 = new Button
            {
                Text = "有級者の型",
                FontSize = 16,
                BackgroundColor = Color.FromHex("33B9FF"),
                TextColor = Color.FromHex("FFFFFF"),
            };

            // ボタンクリック時の処理.
            button1.Clicked += async (s, a) =>
            {
                // ページを遷移する.
                await Navigation.PushAsync(new KyuPoomsaeDetailPage());
            };

            layout.Children.Add(button1);

            this.Content = layout;

            // ボタンを生成.
            var button2 = new Button
            {
                Text = "有段者の型",
                FontSize = 16,
                BackgroundColor = Color.FromHex("33B9FF"),
                TextColor = Color.FromHex("000000"),
            };

            // ボタンクリック時の処理.
            button2.Clicked += async (s, a) =>
            {
                // ページを遷移する.
                await Navigation.PushAsync(new DanPoomsaeDetailPage());
            };

            layout.Children.Add(button2);
        }
    }
}
