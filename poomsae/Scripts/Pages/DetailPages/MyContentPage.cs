using Xamarin.Forms;

namespace poomsae
{
	/// <summary>
	/// メイン.
	/// My content page.
	/// </summary>
	class MyContentPage : ContentPage, IDetail
	{
		/// <summary>
		/// Init this instance.
		/// </summary>
		public ContentPage Init()
		{
			return new MyContentPage();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="poomsae.MyContentPage"/> class.
		/// </summary>
		public MyContentPage()
		{
			base.Title = "ベース"; //ページのタイトル

			// iPhoneにおいて、ステータスバーとの重なりを防ぐためパディングを調整する.
			base.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

			var layout = new StackLayout();
			var logoImage = new Image()
			{
				Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("World_Taekwondo_Federation_Logo.png")
			};
			layout.Children.Add(logoImage);

			// ラベルを１つ生成.
			var titleLabel = new Label {
				FontSize = 40,
				HorizontalOptions = LayoutOptions.Center,
				Text = "Taekwon-Do"
			};

			layout.Children.Add(titleLabel);

			var button = new Button { Text = "初期化" };
			layout.Children.Add(button);
			button.Clicked += async (sender, e) =>
			{
				var ok = "実行";
				var cancel = "キャンセル";
				var message = "初期化しますがよろしいですか？";
				var result = await DisplayActionSheet(message, cancel, ok);
				if(result == ok)
				{
					Tools.InitializeDB();	
				}
			};

			// ラベルを１つ生成.
			var campanyLabel = new Label
			{
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
				Text = "(c)shinriyo"
			};
			layout.Children.Add(campanyLabel);

			// 生成したラベルをこのビューの子要素とする
			base.Content = layout;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.</returns>
		public override string ToString ()
		{
			// これがそのままタイトルになるので.
			return this.Title;
		}
	}

//	public T
}

