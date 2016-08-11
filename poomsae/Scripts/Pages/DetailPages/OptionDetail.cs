//-----------------------------------------------------------------------
// <copyright file="OptionDetail.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using Realms;
    using System;
    using System.Collections.Generic;
    using Xamarin.Forms;

    /// <summary>
    /// Option detail.
    /// </summary>
    public class OptionDetail : ContentPage, IDetail
    {
        #region Public Methods
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Poomsae.DetailObject"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Poomsae.DetailObject"/>.</returns>
        public override string ToString()
        {
            // これがそのままタイトルになるので.
            return string.Format("{0}", this.Title);
        }

        /// <summary>
        /// Init this instance.
        /// </summary>
        public ContentPage Init()
        {
            return new OptionDetail();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:poomsae.OptionDetail"/> class.
        /// </summary>
        public OptionDetail()
        {
            // TODO: ローカライズ.
            var title = "オプション";
            base.Title = title;

            var layout = new StackLayout();

            // ローカライズ系.
            //this.CreateLocalize(layout);

            // 連絡先系.
            this.CreateContact(layout);

            // 生成したラベルをこのビューの子要素とする.
            base.Content = layout;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="layout">Layout.</param>
        private void CreateContact(StackLayout layout)
        {
            var appointmentLabel = new Label()
            {
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "連絡"
            };
            layout.Children.Add(appointmentLabel);

            var officialSiteButton = new Button { Text = "公式サイト" };
            officialSiteButton.Clicked += (sender, a) =>
            {
                var uri = new Uri("http://shinriyo.hateblo.jp");
                Device.OpenUri(uri);
            };
            layout.Children.Add(officialSiteButton);

            var appointmentButton = new Button { Text = "Eメール" };
            appointmentButton.Clicked += (sender, a) =>
            {
                var uri = new Uri("mailto:shinriyo@gmail.com");
                Device.OpenUri(uri);
            };
            layout.Children.Add(appointmentButton);
        }
        #endregion
    }
}
