//-----------------------------------------------------------------------
// <copyright file="PoomsaeDetailPageBase.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using VideoPlayerSample.Services;
    using Xamarin.Forms;

    public class PoomsaeDetailPageBase : ContentPage
    {
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
            var uri = "http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_7200K.MP4";
            DependencyService.Get<IVideoPlayerService>().Open(uri);
        }
    }
}