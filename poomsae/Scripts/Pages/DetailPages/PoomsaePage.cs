/////
namespace Poomsae
{
    using System;
    using Xamarin.Forms;
    using System.Collections.ObjectModel;


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
                XAlign = TextAlignment.Center,
                Text = "選択"
            };

            layout.Children.Add(label);

            // ボタンを生成.
            var button1 = new Button { Text = "プンセ詳細" };

            //ボタンクリック時の処理
            button1.Clicked += async (s, a) =>
            {
                // ページを遷移する.
                await Navigation.PushAsync(new PoomsaeDetailPage());
            };

            layout.Children.Add(button1);

            this.Content = layout;
        }
    }

    /// <summary>
    /// プンセの詳細 ページクラス.
    /// </summary>
    class PoomsaeDetailPage : ContentPage
    {
        /// <summary>
        /// Data.
        /// </summary>
        private class Data
        {
            public String Name { get; set; }
            public String Description { get; set; }
            public String Picture { get; set; }
        }

        /// <summary>
        /// Group.
        /// </summary>
        private class Group : ObservableCollection<Data>
        {
            public string Title { get; private set; }
            public Group(string title)
            {
                Title = title;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:poomsae.PoomsaeDetailPage"/> class.
        /// </summary>
        public PoomsaeDetailPage()
        {
            this.Title = "プンセ詳細"; //ページのタイトル

            var ar = new ObservableCollection<Group> {
                new Group("太極9章") {
                  new Data {Name = "アプチャギ", Description = "601-400-3356", Picture = "man.png"},
                  new Data {Name = "トルリョチャギ", Description = "360-403-0486", Picture = "man.png"},
                  new Data {Name = "ネリョチャギ", Description = "620-625-0916", Picture = "man.png"}
                },
                new Group("太極8章") {
                  new Data {Name = "ヨプチャギ", Description = "801-617-8209", Picture = "woman.png"},
                  new Data {Name = "ティッチャギ", Description = "415-771-0336", Picture = "woman.png"},
                },
                new Group("太極7章") {
                  new Data {Name = "ヨプチャギ", Description = "801-617-8209", Picture = "woman.png"},
                  new Data {Name = "ティッチャギ", Description = "415-771-0336", Picture = "woman.png"},
                }
            };

            // テンプレートの作成（ImageCell使用）.
            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetBinding(ImageCell.TextProperty, "Name");
            cell.SetBinding(ImageCell.DetailProperty, "Description");
            cell.SetBinding(ImageCell.ImageSourceProperty, "Picture");

            // リストビューを生成する.
            var listView = new ListView
            {
                ItemsSource = ar,
                ItemTemplate = cell,
                IsGroupingEnabled = true,  // <-3
                GroupDisplayBinding = new Binding("Title"),  // <-4
            };

            // layout.Children.Add(listView);

            // 生成したラベルをこのビューの子要素とする.
            // base.Content = layout;

            base.Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0), // iOSのみ上部にマージンをとる
                Children = { listView }
            };
        }
    }
}
