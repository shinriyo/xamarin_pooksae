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
        private static Data CreateData(
            string name, string desc, string detail, string imageName,
            Action<string, string> action)
        {
            var data = new Data
            {
                Name = name,
                Description = desc,
                Picture = imageName,
                OnClick = new Command(() =>
                {
                    action(name, detail);
                })
            };
            return data;
        }

        public static ObservableCollection<Group> GetPunches(Action<string, string> action)
        {
            string png = "punch_icon.png";

            // パンチ系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData("チュモクチルギ", "パンチ", "パンチします.", png, action),
                },
                new Group("8級") {
                    CreateData("ジョチョチルギ", "両手突き", "両手でパンチします.", png, action),
                }
            };
            return groups;
        }

        public static ObservableCollection<Group> GetKnives(Action<string, string> action)
        {
            string png = "chop_icon.png";

            // 手刀系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData("ソンナルモクチギ", "手刀受け", "手刀受け", png, action),
                },
                new Group("8級") {
                    CreateData("アギソンモクチギ", "両手刀受け", "両手刀受け", png, action),
                },
                new Group("7級") {
                    CreateData("チェッピブンモクチギ", "両手刀受け", "両手刀受け", png, action),
                }
            };
            return groups;
        }

        /// <summary>
        /// Gets the kicks.
        /// </summary>
        /// <returns>The kicks.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetKicks(Action<string, string> action)
        {
            string png = "kick_icon.png";

            // キック系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData("アプチャギ", "前に蹴る", "前に蹴る", png, action),
                    CreateData("トルリョチャギ", "回して蹴る", "回して蹴る", png, action),
                    CreateData("ネリョチャギ", "かかと落とし", "かかと落とし", png, action),
                },
                new Group("8級") {
                    CreateData("ヨプチャギ", "横蹴り", "横蹴り", png, action),
                    CreateData("ティッチャギ", "後ろ蹴り", "後ろ蹴り", png, action),
                },
                new Group("7級") {
                }
            };
            return groups;
        }

        public static ObservableCollection<Group> GetGuards(Action<string, string> action)
        {
            string png = "guard_icon.png";

            // 受け系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData("ソンナルマッキ", "手刀受け", "手刀受け", png, action),
                },
                new Group("8級") {
                    CreateData("ヤンソンナルマッキ", "両手刀受け", "両手刀受け", png, action),
                },
                new Group("7級") {
                    CreateData("ヘッチョンマッキ", "両端受け", "両端受け", png, action),
                },
                new Group("6級") {
                    CreateData("パタンソンマッキ", "両端受け", "両端受け", png, action),
                },
                new Group("5級") {
                    CreateData("ピットロマッキ", "ひねり受け", "ひねり受け", png, action),
                },
                new Group("4級") {
                    CreateData("サントゥルマッキ", "上段両受け", "上段両受け", png, action),
                },
                new Group("3級") {
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
