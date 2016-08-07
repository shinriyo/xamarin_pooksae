//-----------------------------------------------------------------------
// <copyright file="PoomsaeDetailPageBase.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Realms;
    using VideoPlayerSample.Services;
    using Xamarin.Forms;

    /// <summary>
    /// Poomsae detail page base.
    /// </summary>
    public class PoomsaeDetailPageBase : ContentPage
    {
        private const int initKyu = -1;

        /// <summary>
        /// Data.
        /// </summary>
        protected class Data
        {
            public String Name { get; set; }
            public String Description { get; set; }
            public String Picture { get; set; }
            public ICommand OnClick { get; set; }
        }

        /// <summary>
        /// Group.
        /// </summary>
        protected class Group : ObservableCollection<Data>
        {
            public string Title { get; private set; }
            public Group(string title)
            {
                Title = title;
            }
        }

        /// <summary>
        /// Creates the groups.
        /// </summary>
        /// <returns>The groups.</returns>
        /// <param name="title">Title.</param>
        /// <param name="order">Order.</param>
        /// <param name="image">Image.</param>
        protected ObservableCollection<Group> CreateGroups(int type, Action<string, string, string> action)
        {
            var groups = new ObservableCollection<Group>();
            // TODO:
            var kyuOrDan = (type == (int)PoomsaeModel.KyuOrDan.Kyu) ? "級" : "段";
            string iconImage = "kick_icon.png";
            string detailImageBase = @"poomsae.Resources.Punch.{0}.jpg";
            var realm = Realm.GetInstance();
            var res = realm.All<PoomsaeModel>().Where(d => d.Type == type);
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
                    // N級.
                    group = new Group(string.Format("{0}{1}", kyu, kyuOrDan));
                }

                var data = this.CreateData(name, desc, detail, iconImage,
                                      string.Format(detailImageBase, picture), action);
                group.Add(data);
                nowKyu = kyu; // 更新.
            }

            // 1つでもあれば最後に追加.
            if (res.Count() > 0)
            {
                groups.Add(group);
            }

            return groups;
        }

        /// <summary>
        /// TODO: Creates the data.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="name">Name.</param>
        /// <param name="desc">Desc.</param>
        /// <param name="detail">Detail.</param>
        /// <param name="imageName">Image name.</param>
        /// <param name="image">Image.</param>
        /// <param name="action">Action.</param>
        private Data CreateData(
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
        /// Creates the group.
        /// </summary>
        /// <returns>The group.</returns>
        /// <param name="title">Title.</param>
        /// <param name="order">Order.</param>
        /// <param name="image">Image.</param>
        protected Group CreateGroup(string title, string order, string image)
        {
            return new Group(title)
            {
                new Data
                {
                    Name = "順序",
                    Description = "順序",
                    Picture = "note_icon.png",
                    OnClick = new Command(() =>
                    {
                        this.OpenDetail(title, order, image);
                    })
                },
                new Data
                {
                    Name = "動画",
                    Description = "動画再生",
                    Picture = "movie_icon.png",
                    OnClick = new Command(() =>
                    {
                        this.PlayMovie(1);
                    })
                }
            };
        }

        /// <summary>
        /// プンセの順番.
        /// </summary>
        /// <returns>The detail.</returns>
        /// <param name="name">Name.</param>
        /// <param name="detail">Detail.</param>
        /// <param name="image">詳細画像.</param>
        private void OpenDetail(string name, string detail, string image)
        {
            try
            {
                // ページを遷移する.
                Navigation.PushAsync(new PoomsaeOrderPage
                {
                    BindingContext = new PoomsaeOrderPageViewModel()
                    {
                        Name = name,
                        Source = ImageSource.FromResource(image),
                        Desc = detail
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// プンセ動画再生.
        /// </summary>
        /// <returns>The alert.</returns>
        private void PlayMovie(int id)
        {
            var title = "未完成";
            var message = "動画再生はまだできません。";
            base.DisplayAlert(title, message, "OK");
            return;

            //var uri = "http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_7200K.MP4";
            //DependencyService.Get<IVideoPlayerService>().Open(uri);
        }
    }
}