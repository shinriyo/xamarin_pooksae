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

			//ボタンを生成
			var button1 = new Button { Text = "NextPageへ移動" };
			//ボタンクリック時の処理
			button1.Clicked += async (s, a) => {
				//ページを遷移する
				await Navigation.PushAsync(new NextPage());
			};

			Content = button1;
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

