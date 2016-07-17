//-----------------------------------------------------------------------
// <copyright file="EmptyClass.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using CellTool;
    using System;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;


    public class EmptyClass
    {
        public static ObservableCollection<Group> GetPunches(Action<int> action)
        {
            int id = 10;
            // TOD: コレは後で消す.
            // パンチ系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    new Data {
                        Name = "チュモクチルギ", Description = "パンチ", Picture = "punch_icon.png",
                        OnClick = new Command(() => {
                            action(id);
                        })
                    },
                },
                new Group("?級") {
                    new Data {
                        Name = "ジョチョチルギ", Description = "両手突き", Picture = "punch_icon.png",
                        OnClick = new Command(() => {
                            action(id);
                        })
                    },
                }
            };
            return groups;
        }

        public static ObservableCollection<Group> GetKnives(Action<int> action)
        {
            // TOD: コレは後で消す.
            int id = 10;
            // 手刀系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    new Data {
                        Name = "ソンナルモクチギ", Description = "手刀受け", Picture = "chop_icon.png",
                            OnClick = new Command(() => {
                            action(id);
                        })
                    }
                },
                new Group("8級") {
                    new Data {Name = "アギソンモクチギ", Description = "両手刀受け", Picture = "chop_icon.png"},
                },
                new Group("7級") {
                    new Data {Name = "チェッピブンモクチギ", Description = "両手刀受け", Picture = "chop_icon.png"},
                }
            };
            return groups;
        }

        public static ObservableCollection<Group> GetKicks(Action<int> action)
        {
            // TOD: コレは後で消す.
            // キック系.
            var groups = new ObservableCollection<Group>
            {
                new Group("9級") {
                    new Data {Name = "アプチャギ", Description = "前に蹴る", Picture = "kick_icon.png"},
                    new Data {Name = "トルリョチャギ", Description = "回して蹴る", Picture = "kick_icon.png"},
                    new Data {Name = "ネリョチャギ", Description = "かかと落とし", Picture = "kick_icon.png"}
                },
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
