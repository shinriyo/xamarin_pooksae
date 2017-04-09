//-----------------------------------------------------------------------
// <copyright file="DBAccess.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using CellTool;
    using Realms;
    using Xamarin.Forms;

    /// <summary>
    /// DBA ccess.
    /// </summary>
    public class DBAccess
    {
        private const int initKyu = -1;

        /// <summary>
        /// Creates the data.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="name">Name.</param>
        /// <param name="desc">Desc.</param>
        /// <param name="detail">Detail.</param>
        /// <param name="iconImage">Icon Image.</param>
        /// <param name="image">Image.</param>
        /// <param name="action">Action.</param>
        private static Data CreateData(
            string name, string desc, string detail, string iconImage,
            string image, Action<string, string, string, string> action)
        {
            var data = new Data
            {
                Name = name,
                Description = desc,
                IconImage = iconImage,
                OnClick = new Command(() =>
                {
                    action(name, detail, image, desc);
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
        private static ObservableCollection<Group> Common(int type, string iconImage,
                                                         string detailImageBase,
                                                         Action<string, string, string, string> action)
        {
            var groups = new ObservableCollection<Group>();
            var realm = Realm.GetInstance(App.realmFile);
            var res = realm.All<ArtModel>().Where(d => d.Type == type);
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
                System.Diagnostics.Debug.WriteLine(
                    "Common Log: kyu:{0} name:{1} desc:{2} detail:{3} :picture:{4}",
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
                                      string.Format(detailImageBase, picture),
                                      action);
                group.Add(data);

                // 更新.
                nowKyu = kyu;
            }

            // 1つでもあれば最後に追加.
            if (res.Count() > 0)
            {
                groups.Add(group);
            }

            return groups;
        }

        /// <summary>
        /// Gets the throws.
        /// </summary>
        /// <returns>The throws.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetThrows(
            Action<string, string, string, string> action)
        {
            // TODO:
            string iconImage = "kick_icon.png";
            // TODO:
            string detailImageBase = @"poomsae.Resources.Kick.{0}.jpg";
            return Common((int)ArtModel.ArtType.Throw, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// Gets the downs.
        /// </summary>
        /// <returns>The downs.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetDowns(
            Action<string, string, string, string> action)
        {
            // TODO:
            string iconImage = "kick_icon.png";
            // TODO:
            string detailImageBase = @"poomsae.Resources.Kick.{0}.jpg";
            return Common((int)ArtModel.ArtType.Down, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// Gets the stamps.
        /// </summary>
        /// <returns>The stamps.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetStamps(
            Action<string, string, string, string> action)
        {
            // TODO:
            string iconImage = "kick_icon.png";
            // TODO:
            string detailImageBase = @"poomsae.Resources.Kick.{0}.jpg";
            return Common((int)ArtModel.ArtType.Stamp, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// 跳び系.
        /// </summary>
        /// <returns>The jumps.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetJumps(
            Action<string, string, string, string> action)
        {
            string iconImage = "jump_icon.png";
            string detailImageBase = @"poomsae.Resources.Jump.{0}.jpg";
            return Common((int)ArtModel.ArtType.Jump, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// 受け系.
        /// </summary>
        /// <returns>The guards.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetGuards(
            Action<string, string, string, string> action)
        {
            string iconImage = "guard_icon.png";
            string detailImageBase = @"poomsae.Resources.Guard.{0}.jpg";
            return Common((int)ArtModel.ArtType.Guard, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// 押し系.
        /// </summary>
        /// <returns>The pushes.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetPushes(
            Action<string, string, string, string> action)
        {
            string iconImage = "push_icon.png";
            string detailImageBase = @"poomsae.Resources.Pushe.{0}.jpg";
            return Common((int)ArtModel.ArtType.Push, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// Gets the backs.
        /// </summary>
        /// <returns>The backs.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetBacks(
            Action<string, string, string, string> action)
        {
            string iconImage = "push_icon.png";
            string detailImageBase = @"poomsae.Resources.Pushe.{0}.jpg";
            return Common((int)ArtModel.ArtType.Back, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// 構え.
        /// </summary>
        /// <returns>The stances.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetStances(
            Action<string, string, string, string> action)
        {
            string iconImage = "stance_icon.png";
            string detailImageBase = @"poomsae.Resources.Stance.{0}.jpg";
            return Common((int)ArtModel.ArtType.Stance, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// Gets the punches.
        /// </summary>
        /// <returns>The punches.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetPunches(
            Action<string, string, string, string> action)
        {
            string iconImage = "punch_icon.png";
            string detailImageBase = @"poomsae.Resources.Punch.{0}.jpg";
            return Common((int)ArtModel.ArtType.Punch, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// Gets the attacks.
        /// </summary>
        /// <returns>The attacks.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetAttacks(
            Action<string, string, string, string> action)
        {
            // TODO:
            string iconImage = "kick_icon.png";
            // TODO:
            string detailImageBase = @"poomsae.Resources.Kick.{0}.jpg";
            return Common((int)ArtModel.ArtType.Attack, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// Gets the cuts.
        /// </summary>
        /// <returns>The cuts.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetCuts(
            Action<string, string, string, string> action)
        {
            // TODO:
            string iconImage = "kick_icon.png";
            // TODO:
            string detailImageBase = @"poomsae.Resources.Kick.{0}.jpg";
            return Common((int)ArtModel.ArtType.Cut, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// Gets the kicks.
        /// </summary>
        /// <returns>The kicks.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetKicks(
            Action<string, string, string, string> action)
        {
            string iconImage = "kick_icon.png";
            string detailImageBase = @"poomsae.Resources.Kick.{0}.jpg";
            return Common((int)ArtModel.ArtType.Kick, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// 肘系.
        /// </summary>
        /// <returns>The elbows.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetElbows(
            Action<string, string, string, string> action)
        {
            string iconImage = "elbow_icon.png";
            string detailImageBase = @"poomsae.Resources.Elbow.{0}.jpg";
            return Common((int)ArtModel.ArtType.Elbow, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// Gets the dodges.
        /// </summary>
        /// <returns>The dodges.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetDodges(
            Action<string, string, string, string> action)
        {
            // TODO:
            string iconImage = "kick_icon.png";
            // TODO:
            string detailImageBase = @"poomsae.Resources.Kick.{0}.jpg";
            return Common((int)ArtModel.ArtType.Dodge, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// Gets the specials.
        /// </summary>
        /// <returns>The specials.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetSpecials(
            Action<string, string, string, string> action)
        {
            // TODO:
            string iconImage = "kick_icon.png";
            // TODO:
            string detailImageBase = @"poomsae.Resources.Kick.{0}.jpg";
            return Common((int)ArtModel.ArtType.Special, iconImage, detailImageBase, action);
        }

        /// <summary>
        /// Gets the parts.
        /// </summary>
        /// <returns>The parts.</returns>
        /// <param name="action">Action.</param>
        public static ObservableCollection<Group> GetParts(
        Action<string, string, string, string> action)
        {
            // TODO:
            string iconImage = "kick_icon.png";
            // TODO:
            string detailImageBase = @"poomsae.Resources.Kick.{0}.jpg";
            return Common((int)ArtModel.ArtType.Part, iconImage, detailImageBase, action);
        }
    }
}
