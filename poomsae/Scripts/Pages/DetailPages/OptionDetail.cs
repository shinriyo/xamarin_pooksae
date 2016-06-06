using System;
using Xamarin.Forms;

namespace poomsae
{
	public class OptionDetail : ContentPage, IDetail
	{
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.</returns>
		public override string ToString ()
		{
			// これがそのままタイトルになるので.
			return string.Format ("title={0}", this.Title);
		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		public ContentPage Init()
		{
			return new OptionDetail ();
		}

		public OptionDetail ()
		{
			var dc = new DogController ();

			var uri = "http://www.sapporoworks.ne.jp/main.jpg";
			var layout = new StackLayout();
			var img = new Image {
				Source = ImageSource.FromUri(new Uri(uri))
			};
			layout.Children.Add(img);
			// 生成したラベルをこのビューの子要素とする
			base.Content = layout;
		}
	}
}
