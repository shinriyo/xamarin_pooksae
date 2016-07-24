//-----------------------------------------------------------------------
// <copyright file="PoomsaePage.cs" company="shinriyo">
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
                "パンチ系",
                "キック系",
                "手刀系",
                "受け系",
            };

            int i = 0;

            // ボタンを生成.
            foreach (var artType in artTypes)
            {
                var button = new Button
                {
                    Text = artType
                };

                // 詳細がどれか.
                int detailType = i;
                string name = artTypes[i];

                // ボタンクリック時の処理.
                button.Clicked += async (s, a) =>
                {
                    // ページを遷移する.
                    await Navigation.PushAsync(new ArtDetailPage(detailType, name));
                };
                i++;
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
        /// <param name="id">Identifier.</param>
        private void OpenDetail(int id)
        {
            try
            {
                // ページを遷移する.
                Navigation.PushAsync(new ArtDescPage
                {
                    BindingContext = new ArtDescPageViewModel()
                    {
                        Name = "タイトル",
                        Source = ImageSource.FromResource(@"poomsae.Resources.Punch.VerticalPunch.jpg"),
                        Desc = "説明"
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
        /// <param name="i">The index.</param>
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
                groups = EmptyClass.GetPunches(this.OpenDetail);
            }
            else if (pageType == 1)
            {
                // キック系.
                groups = EmptyClass.GetKicks(this.OpenDetail);
            }
            else if (pageType == 2)
            {
                // 手刀系.
                groups = EmptyClass.GetKnives(this.OpenDetail);
            }
            else if (pageType == 3)
            {
                // 受け系.
                groups = EmptyClass.GetGuards(this.OpenDetail);
            }

            // テンプレートの作成（ImageCell使用）.
            var cell = new DataTemplate(typeof(ImageCell));

            // Dataの中のプロパティに対応した文字.
            cell.SetBinding(ImageCell.TextProperty, "Name");
            cell.SetBinding(ImageCell.DetailProperty, "Description");
            cell.SetBinding(ImageCell.ImageSourceProperty, "Picture");
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
