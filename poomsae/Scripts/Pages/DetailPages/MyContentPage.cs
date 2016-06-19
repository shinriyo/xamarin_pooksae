using System;
using Xamarin.Forms;
// ログ.
using System.Diagnostics;

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
				var ok = "削除";
				var cancel = "キャンセル";
				var message = "初期化しますがよろしいですか？";
				var result = await DisplayActionSheet(message, cancel, ok);
				if(result == ok)
				{
					this.SetDB();	
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

		// TODO: 後で消す.
		private void SetDB()
		{
			//var lc = new Controller<Localize>();
			var cc = new Controller<Country>();
			cc.DeleteAll();

			Country newCon = new Country()
			{
				Name = "Japan"
			};

			var newCon2 = new Country()
			{
				Name = "Korea"
			};

			cc.Insert(newCon);
			cc.Insert(newCon2);
			Debug.WriteLine(new string('*', 10));

			foreach (var c in cc.FindAll())
			{
				Debug.WriteLine(c);
				//Debug.WriteLine(c.id);
				//Debug.WriteLine(c.Name);
			}
			Debug.WriteLine(new string('*', 10));
		}
	}

//	public T
}

