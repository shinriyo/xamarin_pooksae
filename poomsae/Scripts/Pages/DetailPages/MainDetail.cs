using System;
using Xamarin.Forms;

namespace taekwondo
{
	/// <summary>
	/// Main detail.
	/// </summary>
	public sealed class MainDetail : DetailObject
	{
		public MainDetail ()
		{
			base.title = "メインページ";
			base.content = "内容";
			var uri = "http://www.sapporoworks.ne.jp/main.jpg";
			base.page = new Image {
				Source = ImageSource.FromUri(new Uri(uri))
			};
		}
	}
}

