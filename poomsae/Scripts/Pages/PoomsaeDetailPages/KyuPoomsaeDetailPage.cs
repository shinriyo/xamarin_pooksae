//-----------------------------------------------------------------------
// <copyright file="KyuPoomsaeDetailPage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Realms;
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
            // ページのタイトル.
            this.Title = "級プンセ詳細";

            var groups = new ObservableCollection<Group>();
            var realm = Realm.GetInstance();
            var res = realm.All<PoomsaeModel>().Where(d => d.Type == (int)PoomsaeModel.KyuOrDan.Kyu)
                           .OrderBy(d => d.Kyu);

            foreach (var item in res)
            {
                groups.Add(base.CreateGroup(
                    item.Name,
                    item.Desc,
                    item.Picture
                ));
            }

            //var ar = new ObservableCollection<Group> {
            //    base.CreateGroup("太極1章(テグ イルジャン)", "hoge->bar", "hoge.png"),
            //    base.CreateGroup("太極2章(テグ イージャン)", "hoge->bar", "hoge.png"),
            //    base.CreateGroup("太極3章(テグ サムジャン)", "hoge->bar", "hoge.png"),
            //    base.CreateGroup("太極4章(テグ サージャン)", "hoge->bar", "hoge.png"),
            //    base.CreateGroup("太極5章(テグ オージャン)", "hoge->bar", "hoge.png"),
            //    base.CreateGroup("太極6章(テグ ユッジャン)", "hoge->bar", "hoge.png"),
            //    base.CreateGroup("太極7章(テグ チルジャン)", "hoge->bar", "hoge.png"),
            //    base.CreateGroup("太極8章(テグ パルジャン)", "hoge->bar", "hoge.png"),
            //};

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
                ItemsSource = groups,
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
    }
}
