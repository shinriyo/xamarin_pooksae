using System;
using Xamarin.Forms;

namespace poomsae
{
	/// <summary>
	/// My master detail page.
	/// トップページ.
	/// </summary>
	class MyMasterDetailPage : MasterDetailPage
	{
		public MyMasterDetailPage()
		{
			// TODO: 今のところタイトルだが後で変える.
//			var items = new[] { "Ietm1", "Item2", "Item3" };
//			var items = new DetailObject[] {
//				new MainDetail(),
//				new PoomsaeDetail(),
//				new OptionDetail(),
//			};
			var items = new ContentPage[] {
				new MyContentPage(),
				new MainPage()
			};

			ListView listView = new ListView
			{
				ItemsSource = items,
				BackgroundColor = Color.Transparent
			};

			// マスターページ.
			this.Master = new ContentPage
			{
				BackgroundColor = Color.FromRgba(0.86,0.91,0.94,0.5),
				// iPhoneにおいて、ステータスバーとの重なりを防ぐためパディングを調整する.
				Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
				Title = "Master", // 必須
				Icon = "menu.png",
				Content = listView
			};

			// リストが選択された際のイベント処理.
			listView.ItemSelected += (s, args) => {
				// プロパティDetailに新しいページをセットする.
//				this.Detail = new NavigationPage(new DetailPage((DetailObject)args.SelectedItem))
				this.Detail = new NavigationPage(DetailFactory.Instantiate((IDetail)args.SelectedItem))
//				this.Detail = new NavigationPage((Page)args.SelectedItem)
				{
					//  タイトルバーの背景色や文字色は、NavigationPageのプロパティをセットする.
					BarBackgroundColor = Color.FromRgba(0.2, 0.6, 0.86, 1),
					BarTextColor = Color.White
				};

				//  Detailページを表示する.
				this.IsPresented = false;
			};

			// 必須　最初のページをセットする.
			listView.SelectedItem = items[0];
		}
	}
}

