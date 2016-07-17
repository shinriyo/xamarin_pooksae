using System;

using Xamarin.Forms;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poomsae
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			/*
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};*/

			//			MainPage = new MyContentPage();

			// MasterDetailPageを継承したクラスを生成してMainPageとする
			this.MainPage = new MyMasterDetailPage();

			// NavigationPageを使用して最初のページを表示する
			//			MainPage = new NavigationPage(new MainPage()) {
			//				//  タイトルバーの背景色や文字色は、NavigationPageのプロパティをセットする
			//				BarBackgroundColor = Color.FromRgba(0.2, 0.6, 0.86, 1),
			//				BarTextColor = Color.White
			//			};

			//			MainPage = new TabbedPage() {
			//				Children = {
			//					new TabbedPageItem("Tab1"),
			//					new TabbedPageItem("Tab2"),
			//					new TabbedPageItem("Tab3")
			//				}
			//			};

			//			// CarouselPageをMainPageとしてセットする
			//			MainPage = new CarouselPage() {
			//				Children = {
			//					new CarouselPageItem(Color.Green),
			//					new CarouselPageItem(Color.Red),
			//					new CarouselPageItem(Color.Aqua)
			//				}
			//			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

