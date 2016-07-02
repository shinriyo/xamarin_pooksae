using CellTool;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

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
				"手刀系",
				"その他",
			};

			int i = 0;
			// ボタンを生成.
			foreach (var artType in artTypes)
			{
				var button = new Button
				{
					Text = artType
				};

				// 詳細がどれか.
				int detailType = i;
				string name = artTypes[i];

				// ボタンクリック時の処理.
				button.Clicked += async (s, a) =>
				{
					// ページを遷移する.
					await Navigation.PushAsync(new ArtDetailPage(detailType, name));
				};
				i++;
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
		public ArtDetailPage()
		{ }

		public ArtDetailPage(int i, string name)
		{
			// TODO: ローカライズ.
			this.Title = string.Format("技詳細:{0}", name);
			ObservableCollection<Group> ar = null;
			int pageType = i;

			//http://www.buildinsider.net/mobile/xamarintips/0038
			if (pageType == 0)
			{
				ar = EmptyClass.GetPunches();
			}
			else if (pageType == 1)
			{
				ar = EmptyClass.GetKicks();
			}
			else if (pageType == 2)
			{
				ar = EmptyClass.GetKnives();
			}
			else if (pageType == 3)
			{
				ar = EmptyClass.GetKnives();
			}

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

