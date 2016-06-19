using System;
using Xamarin.Forms;

namespace poomsae
{
	public class ArtsPage : ContentPage, IDetail
	{
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
			return new ArtsPage();
		}

		public ArtsPage()
		{
			base.Title = "技辞典"; //ページのタイトル

			var layout = new StackLayout();

			var label = new Label()
			{
				FontSize = 30,
				XAlign = TextAlignment.Center,
				Text = "技の解説"
			};

			layout.Children.Add(label);

			var artTypes = new string[]
			{
				"パンチ系",
				"キック系",
				"その他",
			};

			// ボタンを生成.
			foreach (var artType in artTypes)
			{
				var button = new Button
				{
					Text = artType
				};

				//ボタンクリック時の処理
				button.Clicked += async (s, a) =>
				{
					// ページを遷移する.
					await Navigation.PushAsync(new ArtDetailPage());
				};

				layout.Children.Add(button);
			}

			// 生成したラベルをこのビューの子要素とする.
			base.Content = layout;
		}
	}

	/// <summary>
	/// 技詳細
	/// </summary>
	class ArtDetailPage : ContentPage
	{
		public ArtDetailPage()
		{
			this.Title = "技詳細"; //ページのタイトル

		}

		public override string ToString()
		{
			// これがそのままタイトルになるので.
			return string.Format("{0}", this.Title);
		}
	}
}


