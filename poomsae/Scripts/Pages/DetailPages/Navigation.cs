using System;
using Xamarin.Forms;

namespace poomsae
{
	//メインのページ
	class MainPage : ContentPage, IDetail
	{
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.</returns>
		public override string ToString ()
		{
			// これがそのままタイトルになるので.
			return this.Title;
		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		public ContentPage Init()
		{
			return new MainPage ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="poomsae.MainPage"/> class.
		/// </summary>
		public MainPage()
		{
			this.Title = "age"; //ページのタイトル

			var uri = "http://www.sapporoworks.ne.jp/main.jpg";
			var layout = new StackLayout();
			var img = new Image
			{
				Source = ImageSource.FromUri(new Uri(uri))
			};

			var someImage = new Image()
			{
				Aspect = Aspect.AspectFit,
				Source = ImageSource.FromUri(new Uri("http://xamarin.com/content/images/pages/branding/assets/xamagon.png")),
			};

			layout.Children.Add(someImage);

			var label = new Label()
			{
				FontSize = 30,
				XAlign = TextAlignment.Center,
				Text = "選択"
			};

			layout.Children.Add(label);

			//ボタンを生成
			var button1 = new Button { Text = "NextPageへ移動" };
			//ボタンクリック時の処理
			button1.Clicked += async (s, a) => {
				//ページを遷移する
				await Navigation.PushAsync(new NextPage());
			};

			layout.Children.Add(button1);

			this.Content = layout;
		}
	}

	/// <summary>
	/// Next page.
	/// </summary>
	class NextPage : ContentPage
	{
		public NextPage()
		{
			this.Title = "NextPage"; //ページのタイトル


		}
	}
}

