using System;
using Xamarin.Forms;

namespace poomsae
{
	public interface IDetail{
//		Page Init();
		ContentPage Init();
	}

	public static class DetailFactory
	{
		public static ContentPage Instantiate(IDetail obj)
		{
			return obj.Init();
		}
	}

	/// <summary>
	/// 詳細ページ.
	/// </summary>
	public class DetailPage : ContentPage
	{
		public DetailPage(IDetail obj)
		{
			obj.Init();
		}

		public DetailPage(DetailObject obj)
		{
			this.Title = obj.title;
			this.Content = obj.page;
//			this.Content = new Label
//			{
//				// テキストを中央に表示する.
//				Text = obj.title,
//				HorizontalOptions = LayoutOptions.Center,
//				VerticalOptions = LayoutOptions.Center
//			};
		}
	}
}

