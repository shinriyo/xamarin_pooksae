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
		/// <summary>
		/// Initializes a new instance of the <see cref="poomsae.MyMasterDetailPage"/> class.
		/// </summary>
		public MyMasterDetailPage()
		{
			// ココにページを詰める.
			var items = new ContentPage[] {
				new MyContentPage(),
				new MainPage(),
				new ArtsPage(),
				new OptionDetail(),
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
				this.Detail = new NavigationPage(DetailFactory.CreateObject((IDetail)args.SelectedItem))
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

