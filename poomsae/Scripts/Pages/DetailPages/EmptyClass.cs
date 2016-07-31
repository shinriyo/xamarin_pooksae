//-----------------------------------------------------------------------
// <copyright file="EmptyClass.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System.Linq;
    using System;
    using System.Collections.ObjectModel;
    using CellTool;
    using Xamarin.Forms;
    using Realms.Tool;

    public class EmptyClass
    {
        private const int initKyu = -1;
        static void HandleAction(string arg1, string arg2, string arg3)
        {

        }

        private static Data CreateData(
            string name, string desc, string detail, string imageName,
            string image,
            Action<string, string, string> action)
        {
            var data = new Data
            {
                Name = name,
                Description = desc,
                Picture = imageName,
                OnClick = new Command(() =>
                {
                    action(name, detail, image);
                })
            };
            return data;
        }

        /// <summary>
        /// Gets the punches.
        /// </summary>
        /// <returns>The punches.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetPunches(Action<string, string, string> action)
        {
            string iconImage = "punch_icon.png";
            string detailImageBase = @"poomsae.Resources.Punch.{0}.jpg";
            var groups = new ObservableCollection<Group>();

            // 技のテーブル.
            var artModelController = new Controller<ArtModel>();
            var res = artModelController.GetResults().Where(d => d.Type == 0);
            Group group = null;
            // 判定用.
            int nowKyu = initKyu;

            foreach (var item in res)
            {
                var kyu = item.Kyu;
                var name = item.Name;
                var desc = item.Desc;
                var detail = item.Detail;
                var picture = item.Picture;
                System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3} {4}",
                                                   kyu, name, desc, detail, picture);
                // 変わった時または最初.
                if (nowKyu != kyu || nowKyu == initKyu)
                {
                    System.Diagnostics.Debug.WriteLine("changed");
                    group = new Group(string.Format("{0}級", kyu));
                }

                var data = CreateData(name, desc, detail, iconImage,
                                      string.Format(detailImageBase, picture), action);
                group.Add(data);

                // ここはまだ変更時ではないので追加しない.
                if (kyu != initKyu)
                {
                    System.Diagnostics.Debug.WriteLine("not first");
                    groups.Add(group);
                }

                nowKyu = kyu; // 更新.
            }

            // パンチ系.
            //var groups = new ObservableCollection<Group>
            //{
            //    new Group("9級") {
            //        CreateData("チュモクチルギ", "パンチ", "パンチします.", iconImage,
            //                   string.Format(detailImageBase, "VerticalPunch"), action),
            //    },
            //    new Group("8級") {
            //        CreateData("ジョチョチルギ", "両手突き", "両手でパンチします.",
            //                   iconImage, string.Format(detailImageBase, "VerticalPunch"), action),
            //    }
            //};
            return groups;
        }

        /// <summary>
        /// Gets the chops.
        /// </summary>
        /// <returns>The chops.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetChops(Action<string, string, string> action)
        {
            string iconImage = "chop_icon.png";
            string detailImageBase = @"poomsae.Resources.Punch.{0}.jpg";

            var groups = new ObservableCollection<Group>();
            // 技のテーブル.
            var artModelController = new Controller<ArtModel>();
            var res = artModelController.GetResults().Where(d => d.Type == 3);

            Group group = null;
            foreach (var item in res)
            {
                // 判定用.
                int nowKyu = -1;

                var kyu = item.Kyu;
                var name = item.Name;
                var desc = item.Desc;
                var detail = item.Detail;
                var picture = item.Picture;

                if (nowKyu != kyu)
                {
                    if (kyu != -1)
                    {
                        groups.Add(group);
                    }
                    group = new Group(string.Format("{0}級", kyu));
                }

                var data = CreateData(name, desc, detail, iconImage,
                                      string.Format(detailImageBase, picture), action);
                group.Add(data);
            }

            // 手刀系.
            //var groups = new ObservableCollection<Group>
            //{
            //    new Group("9級") {
            //        CreateData("ソンナルモクチギ", "手刀受け", "手刀受け", iconImage,
            //                   string.Format(detailImageBase, "VerticalPunch"), action),
            //    },
            //    new Group("8級") {
            //        CreateData("アギソンモクチギ", "両手刀受け", "両手刀受け", iconImage,
            //                   string.Format(detailImageBase, "VerticalPunch"), action),
            //    },
            //    new Group("7級") {
            //        CreateData("チェッピブンモクチギ", "両手刀受け", "両手刀受け", iconImage,
            //                   string.Format(detailImageBase, "VerticalPunch"), action),
            //    }
            //};
            return groups;
        }

        /// <summary>
        /// Gets the kicks.
        /// </summary>
        /// <returns>The kicks.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetKicks(Action<string, string, string> action)
        {
            string iconImage = "kick_icon.png";
            string detailImageBase = @"poomsae.Resources.Punch.{0}.jpg";

            // 技のテーブル.
            var artModelController = new Controller<ArtModel>();
            var res = artModelController.GetResults().Where(d => d.Type == 3);
            foreach (var item in res)
            {
                if (item.Type == 0)
                {
                    //item.Kyu,
                    //item.Name,
                    //item.Desc,
                    //item.Picture,
                }
            }

            // キック系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData("アプチャギ", "前に蹴る", "前に蹴る", iconImage,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                    CreateData("トルリョチャギ", "回して蹴る", "回して蹴る", iconImage,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                    CreateData("ネリョチャギ", "かかと落とし", "かかと落とし", iconImage,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                },
                new Group("8級") {
                    CreateData("ヨプチャギ", "横蹴り", "横蹴り", iconImage,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                    CreateData("ティッチャギ", "後ろ蹴り", "後ろ蹴り", iconImage,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                },
                new Group("7級") {
                }
            };
            return groups;
        }

        public static ObservableCollection<Group> GetGuards(Action<string, string, string> action)
        {
            string iconPng = "guard_icon.png";
            string detailImageBase = @"poomsae.Resources.Punch.{0}.jpg";

            // 技のテーブル.
            var artModelController = new Controller<ArtModel>();
            var res = artModelController.GetResults().Where(d => d.Type == 3);
            foreach (var item in res)
            {
                if (item.Type == 0)
                {
                    //item.Kyu,
                    //item.Name,
                    //item.Desc,
                    //item.Picture,
                }
            }

            // 受け系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData("ソンナルマッキ", "手刀受け", "手刀受け", iconPng,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                },
                new Group("8級") {
                    CreateData("ヤンソンナルマッキ", "両手刀受け", "両手刀受け", iconPng,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                },
                new Group("7級") {
                    CreateData("ヘッチョンマッキ", "両端受け", "両端受け", iconPng,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                },
                new Group("6級") {
                    CreateData("パタンソンマッキ", "両端受け", "両端受け", iconPng,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                },
                new Group("5級") {
                    CreateData("ピットロマッキ", "ひねり受け", "ひねり受け", iconPng,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                },
                new Group("4級") {
                    CreateData("サントゥルマッキ", "上段両受け", "上段両受け", iconPng,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                }

                //手刀下段受け  ソンナルアレマッキ
                //手刀打ち メチュモネリョチギ
                //手刀中段受け  ソンナルモントンマッキ
                //貫手縦突き   ピョンソクセオチルギ
                //拳下段ささえ受け    コドロアレマッキ
                //拳中段ささえ受け    コドロモントンマッキ
            };
            return groups;
        }
    }
}
