using System;
using Xamarin.Forms;

namespace poomsae
{
	// TODO: 消すかも？
	public class PoomsaeDetail : ContentPage, IDetail
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
			return new PoomsaeDetail ();
		}

		public PoomsaeDetail ()
		{
			this.Title = "プンセ";

			var uri = "http://www.sapporoworks.ne.jp/main.jpg";
			var layout = new StackLayout();
			var img = new Image {
				Source = ImageSource.FromUri(new Uri(uri))
			};
			layout.Children.Add(img);

			// 生成したラベルをこのビューの子要素とする.
			base.Content = layout;
		}
	}
}

