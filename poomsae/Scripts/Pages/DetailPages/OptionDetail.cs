namespace poomsae
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
        /// Returns a <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.</returns>
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
                XAlign = TextAlignment.Center,
                Text = selectTitle
            };

            layout.Children.Add(label);

            // ボタンを生成.
            var languages = this.GetCountries();
            //var mySetting = this.GetMySetting();
            var lc = new LocalizeController();
            var mySetting = lc.GetMySetting();

            List<Button> buttons = new List<Button>();
            foreach (var item in languages.Select((v, i) => new { Value = v, Index = i }))
            {
                var index = item.Index;
                Country country = item.Value;
                bool isEnable = (mySetting.country.Name != item.Value.Name);
                string langName = country.Name;
                var button = new Button
                {
                    Text = langName,
                    IsEnabled = isEnable
                };
                buttons.Add(button);

                layout.Children.Add(button);
                // TODO: ローカライズ.
                var dialogTitle = "変更完了";
                button.Clicked += (s, a) =>
                {
                    base.DisplayAlert(dialogTitle, langName + "に変更されました", "OK");
                    using (var trans = Realm.GetInstance().BeginWrite())
                    {
                        // トランザクションがないと怒られる.
                        country.Name = langName;
                        mySetting.country = country;
                        //this.UpdateMySetting(mySetting, country);
                        trans.Commit();
                    }

                    // ON/OFF切り替え.
                    foreach (var itemBtn in buttons)
                    {
                        bool isSelected = (itemBtn.Text == langName);
                        itemBtn.IsEnabled = !isSelected;
                    }
                };
            }

            /*
			var appointmentLabel = new Label()
			{
				FontSize = 30,
				XAlign = TextAlignment.Center,
				Text = "連絡"
			};
			layout.Children.Add(appointmentLabel);

			var appointmentButton = new Button { Text = "Eメール" };
			appointmentButton.Clicked += (s, a) =>
			{
				var uri = "http://xamarin.com/";
				//DependencyService.Get<IWebBrowserService>().Open(new Uri(uri)); // open in WebBrowser
			};
			layout.Children.Add(appointmentButton);
			*/
            // 生成したラベルをこのビューの子要素とする.
            base.Content = layout;
        }
        #endregion

        #region Private Methods
        ///// <summary>
        ///// Gets my setting.
        ///// </summary>
        ///// <returns>The my setting.</returns>
        //private Setting GetMySetting()
        //{
        //	var sc = new Controller<Setting>();
        //	var setting = sc.FindAll().FirstOrNull();
        //	return setting;
        //}

        /*
		private void UpdateMySetting(Setting setting, Country country)
		{
			var sc = new Controller<Setting>();
			setting.country = country;
			sc.Update(setting.Id, setting);
		}
		*/

        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <returns>The countries.</returns>
        private Country[] GetCountries()
        {
            var cc = new Controller<Country>();
            var countries = cc.FindAll();
            return countries.Select(item => item).ToArray();
        }
        #endregion
    }
}
