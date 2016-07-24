//-----------------------------------------------------------------------
// <copyright file="OptionDetail.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using Realms;
    using Realms.Tool;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
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
            // TODO: ローカライズ.
            var selectTitle = "言語選択";

            var label = new Label()
            {
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = selectTitle
            };

            layout.Children.Add(label);

            var lc = new LocalizeController();
            var mySetting = lc.GetMySetting();

            // ボタンを生成.
            List<Button> buttons = new List<Button>();
            var languageNames = new string[] { "ja", "kr", "en" };
            foreach (var language in languageNames)
            {
                string myLang = mySetting == null ? "ja" : mySetting.language;
                bool isEnable = (myLang != language);

                var button = new Button
                {
                    Text = language,
                    IsEnabled = isEnable
                };
                buttons.Add(button);

                layout.Children.Add(button);
                // TODO: ローカライズ.
                var dialogTitle = "変更完了";
                button.Clicked += (s, a) =>
                {
                    base.DisplayAlert(dialogTitle, language + "に変更されました", "OK");
                    using (var trans = Realm.GetInstance().BeginWrite())
                    {
                        // トランザクションがないと怒られる.
                        mySetting.language = language;
                        trans.Commit();
                    }

                    // ON/OFF切り替え.
                    foreach (var itemBtn in buttons)
                    {
                        bool isSelected = (itemBtn.Text == language);
                        itemBtn.IsEnabled = !isSelected;
                    }
                };
            }

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

            // 生成したラベルをこのビューの子要素とする.
            base.Content = layout;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
