﻿namespace Poomsae
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using VideoPlayerSample.Services;
    using Xamarin.Forms;

    /// <summary>
    /// プンセの詳細 ページクラス.
    /// </summary>
    class DanPoomsaeDetailPage : ContentPage
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
        /// Creates the group.
        /// </summary>
        /// <returns>The group.</returns>
        /// <param name="title">Title.</param>
        /// <param name="order">Order.</param>
        /// <param name="image">Image.</param>
        private Group CreateGroup(string title, string order, string image)
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
                        this.OpenDetail(title, order, image);
                    })
                },
                new Data
                {
                    Name = "動画",
                    Description = "動画再生",
                    Picture = "movie_icon.png",
                    OnClick = new Command(() =>
                    {
                        this.PlayMovie(1);
                    })
                }
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:poomsae.DanPoomsaeDetailPage"/> class.
        /// </summary>
        public DanPoomsaeDetailPage()
        {
            this.Title = "段プンセ詳細"; //ページのタイトル

            var ar = new ObservableCollection<Group> {
                this.CreateGroup("高麗(コウリョ)", "hoge->bar", "hoge.png"),
                this.CreateGroup("金剛(クンガン)", "hoge->bar", "hoge.png"),
                this.CreateGroup("太白(テベック)", "hoge->bar", "hoge.png"),
                this.CreateGroup("平原(ピョンウォン)", "hoge->bar", "hoge.png"),
                this.CreateGroup("十進(シッチン)", "hoge->bar", "hoge.png"),
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

            // layout.Children.Add(listView);

            // 生成したラベルをこのビューの子要素とする.
            // base.Content = layout;

            base.Content = new StackLayout
            {
                // iOSのみ上部にマージンをとる.
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Children = { listView }
            };
        }

        /// <summary>
        /// プンセの順番.
        /// </summary>
        /// <returns>The detail.</returns>
        /// <param name="name">Name.</param>
        /// <param name="detail">Detail.</param>
        /// <param name="image">詳細画像.</param>
        private void OpenDetail(string name, string detail, string image)
        {
            try
            {
                // ページを遷移する.
                Navigation.PushAsync(new PoomsaeOrderPage
                {
                    BindingContext = new PoomsaeOrderPageViewModel()
                    {
                        Name = name,
                        Source = ImageSource.FromResource(image),
                        Desc = detail
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// プンセ動画再生.
        /// </summary>
        /// <returns>The alert.</returns>
        private void PlayMovie(int id)
        {
            var uri = "http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_7200K.MP4";
            DependencyService.Get<IVideoPlayerService>().Open(uri);
        }
    }
}
