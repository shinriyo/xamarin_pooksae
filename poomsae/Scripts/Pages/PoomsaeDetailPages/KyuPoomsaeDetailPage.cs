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
        /// Initializes a new instance of the <see cref="T:poomsae.KyuPoomsaeDetailPage"/> class.
        /// </summary>
        public KyuPoomsaeDetailPage()
        {
            this.Title = "級プンセ詳細"; //ページのタイトル

            var ar = new ObservableCollection<Group> {
                new Group("太極1章")
                {
                    new Data
                    {
                        Name = "順序", Description = "順序", Picture = "note_icon.png",
                        OnClick = new Command(() => {
                            this.OpenAlert(1);
                        })
                    },
                    new Data {Name = "動画", Description = "動画再生", Picture = "movie_icon.png",
                        OnClick = new Command(() => {
                            this.OpenAlert(1);
                        })
                    }
                },
                new Group("太極2章") {
                },
                new Group("太極3章") {
                },
                new Group("太極4章") {
                },
                new Group("太極5章") {
                },
                new Group("太極6章") {
                },
                new Group("太極7章")
                {
                    new Data
                    {
                        Name = "順序", Description = "順序", Picture = "note_icon.png",
                        OnClick = new Command(() => {
                            this.OpenAlert(1);
                        })
                    },
                    new Data {Name = "動画", Description = "動画再生", Picture = "movie_icon.png",
                        OnClick = new Command(() => {
                            this.OpenAlert(1);
                        })
                    },
                }
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
