namespace Poomsae
{
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
            base.Title = "TOP"; //ページのタイトル

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
                Text = "Taekwon-Do Dict"
            };

            layout.Children.Add(titleLabel);

            // TODO: ローカライズ.
            var button = new Button { Text = "初期化" };
            layout.Children.Add(button);
            button.Clicked += async (sender, e) =>
            {
                var ok = "実行";
                var cancel = "キャンセル";
                var message = "初期化しますがよろしいですか？";
                var result = await DisplayActionSheet(message, cancel, ok);
                if (result == ok)
                {
                    Tools.InitializeDB();
                }
            };

            var dlButton = new Button { Text = "ダウンロード" };
            layout.Children.Add(dlButton);
            var dlLabel = new Label
            {
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
            };
            layout.Children.Add(dlLabel);

            dlButton.Clicked += (sender, args) =>
            {
                using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
                {
                    var url = "http://vps6-d.kuku.lu/files/20160619-1533_82a335b14b41d4fb9f72ab726a64a9c6.csv";
                    var csvString = httpClient.GetStringAsync(url).Result;
                    dlLabel.Text = csvString;
                    Tools.SplitCSV(csvString);
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
