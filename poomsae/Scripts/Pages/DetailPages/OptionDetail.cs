using System;
using Xamarin.Forms;

namespace taekwondo
{
	public class OptionDetail : DetailObject
	{
		public OptionDetail ()
		{
			base.title = "オプション";
			base.content = "オプション";
			var uri = "http://www.sapporoworks.ne.jp/main.jpg";
			var layout = new StackLayout();
			var img = new Image {
				Source = ImageSource.FromUri(new Uri(uri))
			};
			layout.Children.Add(img);
			base.page = layout;
		}
	}
}
