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
        private static Data CreateData(int num,
            string name, string desc, string imageName, Action<int> action)
        {
            var data = new Data
            {
                Name = name,
                Description = desc,
                Picture = imageName,
                OnClick = new Command(() =>
                {
                    action(num);
                })
            };
            return data;
        }

        public static ObservableCollection<Group> GetPunches(Action<int> action)
        {
            string png = "punch_icon.png";

            // パンチ系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData(9, "チュモクチルギ", "パンチ", png, action),
                },
                new Group("8級") {
                    CreateData(8, "ジョチョチルギ", "両手突き", png, action),
                }
            };
            return groups;
        }

        public static ObservableCollection<Group> GetKnives(Action<int> action)
        {
            string png = "chop_icon.png";

            // 手刀系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData(9, "ソンナルモクチギ", "手刀受け", png, action),
                },
                new Group("8級") {
                    CreateData(8, "アギソンモクチギ", "両手刀受け", png, action),
                },
                new Group("7級") {
                    CreateData(7, "チェッピブンモクチギ", "両手刀受け", png, action),
                }
            };
            return groups;
        }

        /// <summary>
        /// Gets the kicks.
        /// </summary>
        /// <returns>The kicks.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetKicks(Action<int> action)
        {
            string png = "kick_icon.png";

            // キック系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData(1, "アプチャギ", "前に蹴る", png, action),
                    CreateData(2, "トルリョチャギ", "回して蹴る", png, action),
                    CreateData(3, "ネリョチャギ", "かかと落とし", png, action),
                },
                new Group("8級") {
                    CreateData(4, "ヨプチャギ", "横蹴り", png, action),
                    CreateData(5, "ティッチャギ", "後ろ蹴り", png, action),
                },
                new Group("7級") {
                }
            };
            return groups;
        }

        public static ObservableCollection<Group> GetGuards(Action<int> action)
        {
            string png = "guard_icon.png";

            // 受け系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    CreateData(1, "ソンナルマッキ", "手刀受け", png, action),
                },
                new Group("8級") {
                    CreateData(2, "ヤンソンナルマッキ", "両手刀受け", png, action),
                },
                new Group("7級") {
                    CreateData(3, "ヘッチョンマッキ", "両端受け", png, action),
                },
                new Group("6級") {
                    CreateData(4, "パタンソンマッキ", "両端受け", png, action),
                },
                new Group("5級") {
                    CreateData(5, "ピットロマッキ", "ひねり受け", png, action),
                },
                new Group("4級") {
                    CreateData(6, "サントゥルマッキ", "上段両受け", png, action),
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
