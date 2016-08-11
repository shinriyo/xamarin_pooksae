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
    using Xamarin.Forms;

    /// <summary>
    /// Poomsae detail page base.
    /// </summary>
    public class PoomsaeDetailPageBase : ContentPage
    {
        /// <summary>
        /// Data.
        /// </summary>
        protected class Data
        {
            public String Name { get; set; }
            public String Description { get; set; }
            public String IconImage { get; set; }
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
        /// <param name="image">Image.</param>
        /// <param name="stepImage">Step image.</param>
        /// <param name="meaning">Meaning.</param>
        /// <param name="order">Order.</param>
        /// <param name="detail">Detail.</param>
        protected Group CreateGroup(string title, string hangl, string image,
                                    string stepImage, string meaning,
                                    string order, string detail,
                                    string youTubeUrl)
        {
            return new Group(title)
            {
                new Data
                {
                    Name = "順序",
                    Description = "順序",
                    IconImage = "note_icon.png",
                    OnClick = new Command(() =>
                    {
                        this.OpenDetail(title, hangl, image, stepImage,
                                        meaning, order, detail);
                    })
                },
                new Data
                {
                    Name = "動画",
                    Description = "動画再生",
                    IconImage = "movie_icon.png",
                    OnClick = new Command(() =>
                    {
                        this.PlayMovie(youTubeUrl);
                    })
                }
            };
        }

        /// <summary>
        /// プンセの詳細を開く.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="image">Image.</param>
        /// <param name="stepImage">Step image.</param>
        /// <param name="meaning">Meaning.</param>
        /// <param name="order">Order.</param>
        /// <param name="detail">Detail.</param>
        private void OpenDetail(string name, string hangl, string image,
                                string stepImage, string meaning, string order,
                                string detail)
        {
            try
            {
                // ページを遷移する.
                Navigation.PushAsync(new PoomsaeOrderPage
                {
                    BindingContext = new PoomsaeOrderPageViewModel()
                    {
                        Name = name,
                        Hangl = hangl,
                        Image = ImageSource.FromResource(image),
                        ActionStep = ImageSource.FromResource(stepImage),
                        Meaning = meaning,
                        Order = order,
                        Detail = detail
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
        /// <param name="youTubeUrl">YouTubeのURL.</param>
        private void PlayMovie(string youTubeUrl)
        {
            //var title = "未完成";
            //var message = "動画再生はまだできません。";
            //base.DisplayAlert(title, message, "OK");
            try
            {
                YouTubePage.youTubeUrl = youTubeUrl;

                // ページを遷移する.
                Navigation.PushAsync(new YouTubePage());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}