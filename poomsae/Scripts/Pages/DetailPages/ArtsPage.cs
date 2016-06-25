using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

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
			base.Title = "技辞典"; // ページのタイトル.
			var layout = new StackLayout();

			var subTitle = "技の解説";
			var label = new Label()
			{
				FontSize = 30,
				XAlign = TextAlignment.Center,
				Text = subTitle
			};

			layout.Children.Add(label);

			// TODO: ローカライズ.
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

				// ボタンクリック時の処理.
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
		private class Data
		{ // <-1
			public String Name { get; set; }
			public String Phone { get; set; }
			public String Icon { get; set; }
		}

		private class Group : ObservableCollection<Data>
		{ // <-1
			public string Title { get; private set; }
			public Group(string title)
			{
				Title = title;
			}
		}

		public ArtDetailPage()
		{
			// TODO: ローカライズ.
			this.Title = "技詳細";

			//var layout = new StackLayout();
			//var subTitle = "技の解説";

			//var label = new Label()
			//{
			//	FontSize = 30,
			//	XAlign = TextAlignment.Center,
			//	Text = subTitle
			//};

			//layout.Children.Add(label);

			//http://www.buildinsider.net/mobile/xamarintips/0038
			var ar = new ObservableCollection<Group> { // <-2
		        new Group("Man") {
				  new Data {Name = "Brent M. Soltis", Phone = "601-400-3356", Icon = "man.png"},
				  new Data {Name = "Joel K. Coffey", Phone = "360-403-0486", Icon = "man.png"},
				  new Data {Name = "Michael H. White", Phone = "620-625-0916", Icon = "man.png"}
				},
				new Group("Woman") {
				  new Data {Name = "Rhonda J. Bailey", Phone = "801-617-8209", Icon = "woman.png"},
				  new Data {Name = "Elizabeth E. McClellan", Phone = "415-771-0336", Icon = "woman.png"},
				}
			};

			// テンプレートの作成（ImageCell使用）.
			var cell = new DataTemplate(typeof(ImageCell));        // <-3
			cell.SetBinding(ImageCell.TextProperty, "Name");        // <-4
			cell.SetBinding(ImageCell.DetailProperty, "Phone");     // <-5
			cell.SetBinding(ImageCell.ImageSourceProperty, "Icon"); // <-6

			// リストビューを生成する.
			var listView = new ListView
			{
				ItemsSource = ar,
				ItemTemplate = cell,
				IsGroupingEnabled = true,  // <-3
				GroupDisplayBinding = new Binding("Title"),  // <-4
			};

			//layout.Children.Add(listView);

			// 生成したラベルをこのビューの子要素とする.
			//base.Content = layout;

			base.Content = new StackLayout
			{
				Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0), // iOSのみ上部にマージンをとる
				Children = { listView }
			};
		}

		public override string ToString()
		{
			// これがそのままタイトルになるので.
			return string.Format("{0}", this.Title);
		}
	}
}


