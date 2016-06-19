using System;
using Xamarin.Forms;

namespace poomsae
{
	/// <summary>
	/// ナビゲーション.
	/// </summary>
	class PoomsaePage : ContentPage, IDetail
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
			return new PoomsaePage ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="poomsae.PoomsaePage"/> class.
		/// </summary>
		public PoomsaePage()
		{
			this.Title = "Poomsae"; //ページのタイトル

			var layout = new StackLayout();

			var label = new Label()
			{
				FontSize = 30,
				XAlign = TextAlignment.Center,
				Text = "選択"
			};

			layout.Children.Add(label);

			// ボタンを生成.
			var button1 = new Button { Text = "詳細へ移動" };
			//ボタンクリック時の処理
			button1.Clicked += async (s, a) => {
				// ページを遷移する.
				await Navigation.PushAsync(new PoomsaeDetailPage());
			};

			layout.Children.Add(button1);

			this.Content = layout;
		}
	}

	/// <summary>
	/// プンセの詳細.
	/// </summary>
	class PoomsaeDetailPage : ContentPage
	{
		public PoomsaeDetailPage()
		{
			this.Title = "プンセ詳細"; //ページのタイトル
		}
	}
}

