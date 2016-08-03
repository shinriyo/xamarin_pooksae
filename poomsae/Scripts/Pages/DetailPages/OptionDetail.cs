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
        /// Creates the localize.
        /// </summary>
        /// <param name="layout">Layout.</param>
        public void CreateLocalize(StackLayout layout)
        {
            // TODO: ローカライズ.
            var selectTitle = "言語選択";

            var label = new Label()
            {
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = selectTitle
            };

            layout.Children.Add(label);

            var realm = Realm.GetInstance();
            var mySetting = realm.All<SettingModel>().FirstOrNull();

            // ボタンを生成.
            List<Button> buttons = new List<Button>();
            var languageNames = new string[] { "ja", "kr", "en", "vi" };
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
                    // トランザクションを開始して、オブジェクトを更新します
                    using (var trans = Realm.GetInstance().BeginWrite())
                    {
                        // 再度取得が必須.
                        realm = Realm.GetInstance();
                        mySetting = realm.All<SettingModel>().FirstOrNull();
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
        }

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="layout">Layout.</param>
        public void CreateContact(StackLayout layout)
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
