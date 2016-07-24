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
        private static Group CreateGroup(int num,
            string name, string desc, string imageName, Action<int> action)
        {
            var group = new Group(num.ToString() + "級") {
                new Data {
                    Name = name, Description = desc,
                    Picture = imageName,
                    OnClick = new Command(() => {
                        action(num);
                    })
                }
            };

            return group;
        }

        public static ObservableCollection<Group> GetPunches(Action<int> action)
        {
            string png = "punch_icon.png";

            // パンチ系.
            var groups = new ObservableCollection<Group>
            {
                CreateGroup(9, "チュモクチルギ", "パンチ", png, action),
                CreateGroup(8, "ジョチョチルギ", "両手突き", png, action),
            };
            return groups;
        }

        public static ObservableCollection<Group> GetKnives(Action<int> action)
        {
            string png = "chop_icon.png";

            // 手刀系.
            var groups = new ObservableCollection<Group>
            {
                CreateGroup(9, "ソンナルモクチギ", "手刀受け", png, action), 
                CreateGroup(8, "アギソンモクチギ", "両手刀受け", png, action), 
                CreateGroup(7, "チェッピブンモクチギ", "両手刀受け", png, action), 
                //new Group("9級") {
                //    new Data {
                //        Name = "ソンナルモクチギ", Description = "手刀受け", Picture = "chop_icon.png",
                //            OnClick = new Command(() => {
                //            action(id);
                //        })
                //    }
                //},
                //new Group("8級") {
                //    new Data {Name = "アギソンモクチギ", Description = "両手刀受け", Picture = "chop_icon.png"},
                //},
                //new Group("7級") {
                //    new Data {Name = "チェッピブンモクチギ", Description = "両手刀受け", Picture = "chop_icon.png"},
                //}
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
            var data = new Data { Name = "アプチャギ", Description = "前に蹴る", Picture = png };
            var g = new Group("9級");
            g.Add(data);

            // TOD: コレは後で消す.
            // キック系.
            var groups = new ObservableCollection<Group>
            {
                g,
                //new Group("9級") {
                    //new Data {Name = "アプチャギ", Description = "前に蹴る", Picture = "kick_icon.png"},
                    //new Data {Name = "トルリョチャギ", Description = "回して蹴る", Picture = "kick_icon.png"},
                    //new Data {Name = "ネリョチャギ", Description = "かかと落とし", Picture = "kick_icon.png"}
                //},
                new Group("8級") {
                    new Data {Name = "ヨプチャギ", Description = "横蹴り", Picture = "kick_icon.png"},
                    new Data {Name = "ティッチャギ", Description = "後ろ蹴り", Picture = "kick_icon.png"},
                },
                new Group("7級") {
                    new Data {Name = "ヨプチャギ", Description = "横蹴り", Picture = "kick_icon.png"},
                    new Data {Name = "ティッチャギ", Description = "後ろ蹴り", Picture = "kick_icon.png"},
                }
            };
            return groups;
        }

        public static ObservableCollection<Group> GetGuards(Action<int> action)
        {
            // TOD: コレは後で消す.
            // 受け系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    new Data {Name = "ソンナルマッキ", Description = "手刀受け", Picture = "guard_icon.png"}
                },
                new Group("8級") {
                    new Data {Name = "ソンナルマッキ", Description = "両手刀受け", Picture = "guard_icon.png"},
                },
                new Group("7級") {
                    new Data {Name = "ヘッチョンマッキ", Description = "両端受け", Picture = "guard_icon.png"},
                },
                new Group("6級") {
                    new Data {Name = "パタンソンマッキ", Description = "掌底受け", Picture = "guard_icon.png"},
                },
                new Group("5級") {
                    new Data {Name = "ピットロマッキ", Description = "ひねり受け", Picture = "guard_icon.png"},
                },
                new Group("4級") {
                    new Data {Name = "サントゥルマッキ", Description = "上段両受け", Picture = "guard_icon.png"},
                },
                new Group("3級") {
                    new Data {Name = "TODO", Description = "両端受け", Picture = "guard_icon.png"},
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
