//-----------------------------------------------------------------------
// <copyright file="TopPage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System.Diagnostics;
    using System.IO;
    using CsvHelper;
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
                    // ローカライズファイル.
                    var url = "http://vps6-d.kuku.lu/files/20160619-1533_82a335b14b41d4fb9f72ab726a64a9c6.csv";
                    var csvString = httpClient.GetStringAsync(url).Result;
                    dlLabel.Text = csvString;

                    var csv = new CsvReader(new StringReader(csvString));
                    while (csv.Read())
                    {
                        var records = csv.GetField<string>(0);
                        Debug.WriteLine("{0} ", records);
                    }

                    // ローカライズファイル.
                    var localizeUrl = "http://vps6-d.kuku.lu/files/20160725-0035_2b21358ee0d5a871860a15789270a433.csv";
                    csvString = httpClient.GetStringAsync(localizeUrl).Result;
                    dlLabel.Text += csvString;

                    csv = new CsvReader(new StringReader(csvString));
                    while (csv.Read())
                    {
                        var records = csv.GetField<string>(0);
                        Debug.WriteLine("{0} ", records);
                    }

                    // パンチ系ファイル.
                    var punchUrl = "http://vps6-d.kuku.lu/files/20160726-0053_cd22c32f91d04333262d320a8e49fd40.csv";
                    csvString = httpClient.GetStringAsync(punchUrl).Result;
                    dlLabel.Text += csvString;

                    csv = new CsvReader(new StringReader(csvString));
                    while (csv.Read())
                    {
                        var kyu = csv.GetField<int>(0);
                        var name = csv.GetField<string>(1);
                        var desc = csv.GetField<string>(2);
                        var detail = csv.GetField<string>(3);
                        var picture = csv.GetField<string>(4);
                        Debug.WriteLine("Kyu:{0}, Name:{1}, Desc:{2}, " +
                                        "Detail:{3}, Picture{0} ",
                                        kyu, name, desc, detail, picture);
                    }

                    // キック系ファイル.
                    var kickUrl = "http://vps6-d.kuku.lu/files/20160725-0849_fbca8e210bea1a8b35e5b12ba70b0a14.csv";
                    csvString = httpClient.GetStringAsync(kickUrl).Result;
                    dlLabel.Text += csvString;

                    csv = new CsvReader(new StringReader(csvString));
                    while (csv.Read())
                    {
                        var kyu = csv.GetField<int>(0);
                        var name = csv.GetField<string>(1);
                        var desc = csv.GetField<string>(2);
                        var detail = csv.GetField<string>(3);
                        var picture = csv.GetField<string>(4);
                        Debug.WriteLine("Kyu:{0}, Name:{1}, Desc:{2}, " +
                                        "Detail:{3}, Picture{0} ",
                                        kyu, name, desc, detail, picture);
                    }

                    // チョップ系ファイル.
                    var chopUrl = "http://vps6-d.kuku.lu/files/20160725-0856_7759c7a4b8b7b3dd5613576968451f6d.csv";
                    csvString = httpClient.GetStringAsync(chopUrl).Result;
                    dlLabel.Text += csvString;

                    csv = new CsvReader(new StringReader(csvString));
                    while (csv.Read())
                    {
                        var kyu = csv.GetField<int>(0);
                        var name = csv.GetField<string>(1);
                        var desc = csv.GetField<string>(2);
                        var detail = csv.GetField<string>(3);
                        var picture = csv.GetField<string>(4);
                        Debug.WriteLine("Kyu:{0}, Name:{1}, Desc:{2}, " +
                                        "Detail:{3}, Picture{0} ",
                                        kyu, name, desc, detail, picture);
                    }

                    // 受け系ファイル.
                    var guardUrl = "http://vps6-d.kuku.lu/files/20160726-0057_e3d23c791475be2247fa60c3c7de91bd.csv";
                    csvString = httpClient.GetStringAsync(guardUrl).Result;
                    dlLabel.Text += csvString;

                    csv = new CsvReader(new StringReader(csvString));
                    while (csv.Read())
                    {
                        var kyu = csv.GetField<int>(0);
                        var name = csv.GetField<string>(1);
                        var desc = csv.GetField<string>(2);
                        var detail = csv.GetField<string>(3);
                        var picture = csv.GetField<string>(4);
                        Debug.WriteLine("Kyu:{0}, Name:{1}, Desc:{2}, " +
                                        "Detail:{3}, Picture{0} ",
                                        kyu, name, desc, detail, picture);
                    }
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
