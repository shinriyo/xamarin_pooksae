namespace Poomsae
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    /// <summary>
    /// プンセの詳細 ページクラス.
    /// </summary>
    class KyuPoomsaeDetailPage : ContentPage
    {
        /// <summary>
        /// Data.
        /// </summary>
        private class Data
        {
            public String Name { get; set; }
            public String Description { get; set; }
            public String Picture { get; set; }
            public ICommand OnClick { get; set; }
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
        /// Creates the data.
        /// </summary>
        /// <returns>The data.</returns>
        private Group CreateGroup(string title)
        {
            return new Group(title)
            {
                new Data
                {
                    Name = "順序",
                    Description = "順序",
                    Picture = "note_icon.png",
                    OnClick = new Command(() =>
                    {
                        this.OpenAlert(1);
                    })
                },
                new Data
                {
                    Name = "動画",
                    Description = "動画再生",
                    Picture = "movie_icon.png",
                    OnClick = new Command(() =>
                    {
                        this.OpenAlert(1);
                    })
                }
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:poomsae.KyuPoomsaeDetailPage"/> class.
        /// </summary>
        public KyuPoomsaeDetailPage()
        {
            this.Title = "級プンセ詳細"; //ページのタイトル

            var ar = new ObservableCollection<Group> {
                this.CreateGroup("太極1章(テグ イルジャン)"),
                this.CreateGroup("太極2章(テグ イージャン)"),
                this.CreateGroup("太極3章(テグ サムジャン)"),
                this.CreateGroup("太極4章(テグ サージャン)"),
                this.CreateGroup("太極5章(テグ オージャン)"),
                this.CreateGroup("太極6章(テグ ユッジャン)"),
                this.CreateGroup("太極7章(テグ チルジャン)"),
                this.CreateGroup("太極8章(テグ パルジャン)"),
            };

            // テンプレートの作成（ImageCell使用）.
            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetBinding(ImageCell.TextProperty, "Name");
            cell.SetBinding(ImageCell.DetailProperty, "Description");
            cell.SetBinding(ImageCell.ImageSourceProperty, "Picture");

            // クリックの対応.
            cell.SetBinding(ImageCell.CommandProperty, "OnClick");

            // リストビューを生成する.
            var listView = new ListView
            {
                ItemsSource = ar,
                ItemTemplate = cell,
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Title"),
            };

            base.Content = new StackLayout
            {
                // iOSのみ上部にマージンをとる.
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Children = { listView }
            };
        }

        /// <summary>
        /// Opens the alert.
        /// </summary>
        /// <returns>The alert.</returns>
        private void OpenAlert(int id)
        {
            base.DisplayAlert("TODO: タイトル." + id, "TODO: まだ。", "OK");
        }
    }
}
