using System;
using Xamarin.Forms;

using System.Diagnostics;

namespace taekwondo
{
	class MyContentPage : ContentPage, IDetail {
		public ContentPage Init()
		{
			return new MyContentPage();
		}

		public MyContentPage() {
			Debug.WriteLine("{0}ContentPage", 2223);

			// iPhoneにおいて、ステータスバーとの重なりを防ぐためパディングを調整する.
			base.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

			// ラベルを１つ生成.
			var label1 = new Label {
				FontSize = 40,
				Text = "Developers.IO"
			};
			// 生成したラベルをこのビューの子要素とする
			base.Content = label1;
		}

		~MyContentPage()
		{
//			System.Console.WriteLine (111);
#if __ANDROID__ || __IOS__
			Debug.WriteLine("My trace statement");
#else
//			Console.WriteLine("My trace statement");
#endif
			Debug.WriteLine("デバッグ・メッセージを出力");
			base.Content = null;
		}
	}

//	public T
}

