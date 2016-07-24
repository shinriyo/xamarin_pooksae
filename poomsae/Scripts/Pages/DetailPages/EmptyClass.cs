//-----------------------------------------------------------------------
// <copyright file="EmptyClass.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System;
    using System.Collections.ObjectModel;
    using CellTool;
    using Xamarin.Forms;


    public class EmptyClass
    {
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

        public static ObservableCollection<Group> GetPunches(Action<string, string, string> action)
        {
            string iconImage = "punch_icon.png";
            string detailImageBase = @"poomsae.Resources.Punch.{0}.jpg";

            // パンチ系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData("チュモクチルギ", "パンチ", "パンチします.", iconImage,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                },
                new Group("8級") {
                    CreateData("ジョチョチルギ", "両手突き", "両手でパンチします.",
                               iconImage, string.Format(detailImageBase, "VerticalPunch"), action),
                }
            };
            return groups;
        }

        public static ObservableCollection<Group> GetChops(Action<string, string, string> action)
        {
            string iconImage = "chop_icon.png";
            string detailImageBase = @"poomsae.Resources.Punch.{0}.jpg";

            // 手刀系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData("ソンナルモクチギ", "手刀受け", "手刀受け", iconImage,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                },
                new Group("8級") {
                    CreateData("アギソンモクチギ", "両手刀受け", "両手刀受け", iconImage,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                },
                new Group("7級") {
                    CreateData("チェッピブンモクチギ", "両手刀受け", "両手刀受け", iconImage,
                               string.Format(detailImageBase, "VerticalPunch"), action),
                }
            };
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
