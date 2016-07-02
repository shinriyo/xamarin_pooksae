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
		/// <summary>
		/// Data.
		/// </summary>
		private class Data
		{
			public String Name { get; set; }
			public String Description { get; set; }
			public String Picture { get; set; }
		}

		/// <summary>
		/// Group.
		/// </summary>
		private class Group : ObservableCollection<Data>
		{
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

			//http://www.buildinsider.net/mobile/xamarintips/0038
			var ar = new ObservableCollection<Group> { // <-2
		        new Group("9級") {
					new Data {Name = "アプチャギ", Description = "前に蹴る", Picture = "man.png"},
					new Data {Name = "トルリョチャギ", Description = "回して蹴る", Picture = "man.png"},
					new Data {Name = "ネリョチャギ", Description = "かかと落とし", Picture = "man.png"}
				},
				new Group("8級") {
					new Data {Name = "ヨプチャギ", Description = "横蹴り", Picture = "woman.png"},
					new Data {Name = "ティッチャギ", Description = "後ろ蹴り", Picture = "woman.png"},
				},
				new Group("7級") {
					new Data {Name = "ヨプチャギ", Description = "横蹴り", Picture = "woman.png"},
					new Data {Name = "ティッチャギ", Description = "後ろ蹴り", Picture = "woman.png"},
				}
			};

			// テンプレートの作成（ImageCell使用）.
			var cell = new DataTemplate(typeof(ImageCell)); // <-3
			cell.SetBinding(ImageCell.TextProperty, "Name"); // <-4
			cell.SetBinding(ImageCell.DetailProperty, "Description"); // <-5
			cell.SetBinding(ImageCell.ImageSourceProperty, "Picture"); // <-6

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
				// iOSのみ上部にマージンをとる.
				Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
				Children = { listView
	}
			};
		}

		public override string ToString()
		{
			// これがそのままタイトルになるので.
			return string.Format("{0}", this.Title);
		}
	}
}


