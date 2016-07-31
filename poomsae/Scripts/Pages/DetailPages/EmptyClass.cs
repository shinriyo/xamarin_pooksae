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
        /// DBから取ってくる共通処理.
        /// 
        /// (例)パンチ系.
        /// var groups = new ObservableCollection<Group>
        /// {
        ///     new Group("9級") {
        ///         CreateData("チュモクチルギ", "パンチ", "パンチします.", iconImage,
        ///             string.Format(detailImageBase, "VerticalPunch"), action),
        ///     },
        ///     new Group("8級") {
        ///         CreateData("ジョチョチルギ", "両手突き", "両手でパンチします.",
        ///             iconImage, string.Format(detailImageBase, "VerticalPunch"), action),
        ///     }
        /// };
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="iconImage">Icon image.</param>
        /// <param name="detailImageBase">Detail image base.</param>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> Common(int type, string iconImage,
                                                         string detailImageBase,
                                                         Action<string, string, string> action)
        {
            var groups = new ObservableCollection<Group>();
            var artModelController = new Controller<ArtModel>();
            var res = artModelController.GetResults().Where(d => d.Type == type);
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
                // 変わった時かつ最初ではない前ループのグループを追加.
                if (nowKyu != kyu && nowKyu != initKyu)
                {
                    groups.Add(group);
                }

                // 変わった時または最初.
                if (nowKyu != kyu || nowKyu == initKyu)
                {
                    group = new Group(string.Format("{0}級", kyu));
                }

                var data = CreateData(name, desc, detail, iconImage,
                                      string.Format(detailImageBase, picture), action);
                group.Add(data);
                nowKyu = kyu; // 更新.
            }

            // 最初のままループを出てしまったら追加.
            if (nowKyu == initKyu)
            {
                groups.Add(group);
            }

            return groups;
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
            return Common((int)ArtModel.ArtType.Punch, iconImage, detailImageBase, action);
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
            return Common((int)ArtModel.ArtType.Kick, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// 手刀系.
        /// </summary>
        /// <returns>The chops.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetChops(Action<string, string, string> action)
        {
            string iconImage = "chop_icon.png";
            string detailImageBase = @"poomsae.Resources.Punch.{0}.jpg";
            return Common((int)ArtModel.ArtType.Chop, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// 受け系.
        /// </summary>
        /// <returns>The guards.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetGuards(Action<string, string, string> action)
        {
            string iconImage = "guard_icon.png";
            string detailImageBase = @"poomsae.Resources.Punch.{0}.jpg";
            return Common((int)ArtModel.ArtType.Guard, iconImage, detailImageBase, action);
            //手刀下段受け  ソンナルアレマッキ
            //手刀打ち メチュモネリョチギ
            //手刀中段受け  ソンナルモントンマッキ
            //貫手縦突き   ピョンソクセオチルギ
            //拳下段ささえ受け    コドロアレマッキ
            //拳中段ささえ受け    コドロモントンマッキ
        }
    }
}
