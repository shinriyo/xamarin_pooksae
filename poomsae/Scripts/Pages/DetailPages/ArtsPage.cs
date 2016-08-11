//-----------------------------------------------------------------------
// <copyright file="ArtsPage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System;
    using CellTool;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    /// <summary>
    /// Arts page.
    /// </summary>
    public class ArtsPage : ContentPage, IDetail
    {
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Poomsae.DetailObject"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Poomsae.DetailObject"/>.</returns>
        public override string ToString()
        {
            // これがそのままタイトルになるので.
            return string.Format("{0}", this.Title);
        }

        /// <summary>
        /// Init this instance.
        /// </summary>
        public ContentPage Init()
        {
            return new ArtsPage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:poomsae.ArtsPage"/> class.
        /// </summary>
        public ArtsPage()
        {
            base.Title = "技辞典"; // ページのタイトル.
            var layout = new StackLayout();

            var subTitle = "技の解説";
            var label = new Label()
            {
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = subTitle
            };

            layout.Children.Add(label);

            // TODO: ローカライズ.
            var artTypes = new string[]
            {
                "パンチ(지르기)",
                "蹴り(차기)",
                "手刀系",
                "受け(막기)",
                "肘打ち(치기)",
                "構え(서기)",
                "밀기",
                "跳び(뛰기)",
            };

            int index = 0;

            // ボタンを生成.
            foreach (var artType in artTypes)
            {
                var button = new Button
                {
                    Text = artType
                };

                // 詳細がどれか.
                int pageType = index;
                string name = artTypes[index];

                // ボタンクリック時の処理.
                button.Clicked += async (s, a) =>
                {
                    // ページを遷移する.
                    await Navigation.PushAsync(new ArtDetailPage(pageType, name));
                };
                index++;
                layout.Children.Add(button);
            }

            // 生成したラベルをこのビューの子要素とする.
            base.Content = layout;
        }
    }

    /// <summary>
    /// 技詳細.
    /// </summary>
    class ArtDetailPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Poomsae.ArtDetailPage"/> class.
        /// </summary>
        public ArtDetailPage()
        {
        }

        /// <summary>
        /// Opens the detail.
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
                Navigation.PushAsync(new ArtDescPage
                {
                    BindingContext = new ArtDescPageViewModel()
                    {
                        // この変数はXAMLと同じBidingになっていること.
                        Name = name,
                        Picture = ImageSource.FromResource(image),
                        Desc = detail.Replace("<br />", Environment.NewLine)
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:poomsae.ArtDetailPage"/> class.
        /// </summary>
        /// <param name="i">ページタイプ.</param>
        /// <param name="name">Name.</param>
        public ArtDetailPage(int i, string name)
        {
            // TODO: ローカライズ.
            this.Title = string.Format("技詳細:{0}", name);
            ObservableCollection<Group> groups = null;
            int pageType = i;

            // http://www.buildinsider.net/mobile/xamarintips/0038
            if (pageType == 0)
            {
                // パンチ系.
                groups = DBAccess.GetPunches(this.OpenDetail);
            }
            else if (pageType == 1)
            {
                // キック系.
                groups = DBAccess.GetKicks(this.OpenDetail);
            }
            else if (pageType == 2)
            {
                // 手刀系.
                groups = DBAccess.GetChops(this.OpenDetail);
            }
            else if (pageType == 3)
            {
                // 受け系.
                groups = DBAccess.GetGuards(this.OpenDetail);
            }
            else if (pageType == 4)
            {
                // 肘打ち(치기).
                groups = DBAccess.GetElbows(this.OpenDetail);
            }
            else if (pageType == 5)
            {
                // 構え(서기).
                groups = DBAccess.GetStances(this.OpenDetail);
            }
            else if (pageType == 6)
            {
                // 밀기(押し系).
                groups = DBAccess.GetPushes(this.OpenDetail);
            }
            else if (pageType == 7)
            {
                // 跳び(뛰기).
                groups = DBAccess.GetJumps(this.OpenDetail);
            }

            // テンプレートの作成（ImageCell使用）.
            var cell = new DataTemplate(typeof(ImageCell));

            // "Tools.Data"の中のプロパティに対応した文字をそれぞれバインド.
            cell.SetBinding(ImageCell.TextProperty, "Name");
            cell.SetBinding(ImageCell.DetailProperty, "Description");

            // これはアイコン.
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconImage");
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

        /// <summary>
        /// Tostring override.
        /// </summary>
        /// <returns>The string.</returns>
        public override string ToString()
        {
            // これがそのままタイトルになるので.
            return string.Format("{0}", this.Title);
        }
    }
}
