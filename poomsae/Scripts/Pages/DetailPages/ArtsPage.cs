//-----------------------------------------------------------------------
// <copyright file="ArtsPage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System;
    using System.Linq;
    using CellTool;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    /// <summary>
    /// Arts page.
    /// </summary>
    public sealed class ArtsPage : ContentPage, IDetail
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
            var parent = new StackLayout();
            var scroll = new ScrollView();
            var layout = new StackLayout();
            scroll.Content = layout;
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.VerticalOptions = LayoutOptions.CenterAndExpand;

            var subTitle = "技の解説";
            var label = new Label()
            {
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = subTitle
            };

            // タイトルは親に直置き
            parent.Children.Add(label);
            parent.Children.Add(scroll);

            var artTypes = new string[]
            {
                "DUMMY",
                "投げ(꺾기)",
                "倒し(넘기기)",
                "踏み(딛기)",
                "跳び(뛰기)",
                "受け(막기)",
                "押し(밀기)",
                "引き(빼기)",
                "構え(서기)",
                "掴み(잡기)",
                "準備姿勢(준비자세)",
                "パンチ(지르기)",
                "突き(찌르기)",
                "切り(찍기)",
                "蹴り(차기)",
                "肘打ち&手刀系(치기)",
                "避け(피하기)",
                "特殊(특수품)",
                "使用部位(사용부위)"
            };

            var blue = "3396D7";
            var red = "E62465";

            // ボタンを生成.
            foreach (var it in artTypes.Select((x, i) => new { Value = x, Index = i }))
            {
                var artType = it.Value;
                var index = it.Index;
                if (index == 0)
                {
                    // 0はダミーなのでスキップ.
                    continue;
                }

                var button = new Button
                {
                    Text = artType,
                    FontSize = 16,
                    // 奇数偶数で交互.
                    BackgroundColor = Color.FromHex(index % 2 == 0 ? red : blue),
                    TextColor = Color.FromHex(index % 2 == 0 ? blue : red),
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

                layout.Children.Add(button);
            }

            base.Content = parent;
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
        /// <param name="koreanName">韓国名.</param>
        private void OpenDetail(string name, string detail, string image, string koreanName)
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
                        Desc = detail.Replace("<br />", Environment.NewLine),
                        KoreanName = koreanName
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
            this.Title = string.Format("技詳細:{0}", name);
            ObservableCollection<Group> groups = null;
            int pageType = i;

            // http://www.buildinsider.net/mobile/xamarintips/0038

            if (pageType == (int)ArtModel.ArtType.Throw)
            {
                // 꺾기
                groups = DBAccess.GetThrows(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Down)
            {
                // 넘기기
                groups = DBAccess.GetDowns(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Stamp)
            {
                // 딛기
                groups = DBAccess.GetStamps(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Jump)
            {
                // 뛰기
                groups = DBAccess.GetJumps(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Guard)
            {
                // 막기
                groups = DBAccess.GetGuards(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Push)
            {
                // 밀기
                groups = DBAccess.GetPushes(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Back)
            {
                // 빼기
                groups = DBAccess.GetBacks(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Stance)
            {
                // 서기
                groups = DBAccess.GetStances(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Grab)
            {
                // 잡기
                groups = DBAccess.GetGrabs(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Prepare)
            {
                // 준비자세
                groups = DBAccess.GetPrepares(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Punch)
            {
                // 지르기
                groups = DBAccess.GetPunches(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Attack)
            {
                // 찌르기
                groups = DBAccess.GetAttacks(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Cut)
            {
                // 찍기
                groups = DBAccess.GetCuts(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Kick)
            {
                // 차기 キック系.
                groups = DBAccess.GetKicks(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Elbow)
            {
                // 肘打ち(치기).
                groups = DBAccess.GetElbows(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Dodge)
            {
                // 피하기
                groups = DBAccess.GetDodges(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Special)
            {
                // 특수품
                groups = DBAccess.GetSpecials(this.OpenDetail);
            }
            else if (pageType == (int)ArtModel.ArtType.Part)
            {
                // 사용부위
                groups = DBAccess.GetParts(this.OpenDetail);
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
                // iPhoneにおいて、ステータスバーとの重なりを防ぐためパディングを調整する.
                Padding = new Thickness(0, Tools.GetPlatformPaddingSize(), 0, 0),
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
