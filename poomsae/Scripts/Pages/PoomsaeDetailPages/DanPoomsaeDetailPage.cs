//-----------------------------------------------------------------------
// <copyright file="DanPoomsaeDetailPage.cs" company="shinriyo">
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
    class DanPoomsaeDetailPage : PoomsaeDetailPageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:poomsae.DanPoomsaeDetailPage"/> class.
        /// </summary>
        public DanPoomsaeDetailPage()
        {
            // ページのタイトル.
            this.Title = "有段者の型・詳細";

            // 詳細画面のパス.
            string detailImageBase = @"poomsae.Resources.DanPoomsae.{0}.jpg";
            string stepFormat = @"poomsae.Resources.DanPoomsae.Step.pal{0}.png";

            var groups = new ObservableCollection<Group>();
            var realm = Realm.GetInstance();
            var res = realm.All<PoomsaeModel>().Where(d => d.Type == (int)PoomsaeModel.KyuOrDan.Dan)
                           .OrderBy(d => d.Kyu);

            foreach (var item in res)
            {
                groups.Add(base.CreateGroup(
                    item.Name,
                    item.Hangl,
                    // パス付き画像.
                    string.Format(detailImageBase, item.Picture),
                    // パス付きステップ画像.
                    string.Format(stepFormat, item.Kyu),
                    item.Meaning,
                    item.Order,
                    item.Detail,
                    item.YouTubeURL
                ));
            }

            // テンプレートの作成（ImageCell使用）.
            var cell = new DataTemplate(typeof(ImageCell));

            // PoomsaeDetailPageBase.Dataに対応.
            cell.SetBinding(ImageCell.TextProperty, "Name");
            cell.SetBinding(ImageCell.DetailProperty, "Description");

            // これはアイコン.
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconImage");

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
                // iPhoneにおいて、ステータスバーとの重なりを防ぐためパディングを調整する.
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Children = { listView }
            };
        }
    }
}
