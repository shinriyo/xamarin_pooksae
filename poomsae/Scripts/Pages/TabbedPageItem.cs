using System;
using Xamarin.Forms;

namespace poomsae
{
	public class TabbedPageItem : ContentPage {
		public TabbedPageItem(string title) {
			//タブに表示される文字列
			Title = title;
			//ラベルを生成
			var label1 = new Label {
				FontSize = 40,
				//ビューの中央に配置
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Text = title
			};
			Content = label1;//ラベルのみを配置する
		}
	}
}

