//-----------------------------------------------------------------------
// <copyright file="KyuPoomsaeDetailPage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    /// <summary>
    /// プンセの詳細 ページクラス.
    /// </summary>
    class KyuPoomsaeDetailPage : PoomsaeDetailPageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:poomsae.KyuPoomsaeDetailPage"/> class.
        /// </summary>
        public KyuPoomsaeDetailPage()
        {
            this.Title = "級プンセ詳細"; //ページのタイトル

            var ar = new ObservableCollection<Group> {
                base.CreateGroup("太極1章(テグ イルジャン)", "hoge->bar", "hoge.png"),
                base.CreateGroup("太極2章(テグ イージャン)", "hoge->bar", "hoge.png"),
                base.CreateGroup("太極3章(テグ サムジャン)", "hoge->bar", "hoge.png"),
                base.CreateGroup("太極4章(テグ サージャン)", "hoge->bar", "hoge.png"),
                base.CreateGroup("太極5章(テグ オージャン)", "hoge->bar", "hoge.png"),
                base.CreateGroup("太極6章(テグ ユッジャン)", "hoge->bar", "hoge.png"),
                base.CreateGroup("太極7章(テグ チルジャン)", "hoge->bar", "hoge.png"),
                base.CreateGroup("太極8章(テグ パルジャン)", "hoge->bar", "hoge.png"),
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
            //var uri = "http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_7200K.MP4";
            //var uri = "yuk_jang.mp4";
            //DependencyService.Get<IVideoPlayerService>().Open(uri);

            try
            {
                // ページを遷移する.
                Navigation.PushAsync(new PlayVideoPage
                {
                    //BindingContext = new PoomsaeOrderPageViewModel()
                    //{
                    //    Name = name,
                    //    Source = ImageSource.FromResource(image),
                    //    Desc = detail
                    //}
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}
