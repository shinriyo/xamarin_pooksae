using System;
using Xamarin.Forms;
// ログ.
using System.Diagnostics;

namespace poomsae
{
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
			Debug.WriteLine("ログ用");
			base.Title = "ベース"; //ページのタイトル

			// iPhoneにおいて、ステータスバーとの重なりを防ぐためパディングを調整する.
			base.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

			var layout = new StackLayout();

			// ラベルを１つ生成.
			var titleLabel = new Label {
				//FontSize = 40,
				FontSize = 20,
				Text = "Tewkwondo App"
			};


			layout.Children.Add(titleLabel);

			var button = new Button { Text = "start" };
			layout.Children.Add(button);
			button.Clicked += (s, a) =>
			{
				
			};

			// ラベルを１つ生成.
			var campanyLabel = new Label
			{
				//FontSize = 40,
				FontSize = 20,
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

