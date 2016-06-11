using System;
using Xamarin.Forms;
// ログ.
using System.Diagnostics;

namespace poomsae
{
	class MyContentPage : ContentPage, IDetail
	{
		/// <summary>
		/// Init this instance.
		/// </summary>
		public ContentPage Init()
		{
			return new MyContentPage();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="poomsae.MyContentPage"/> class.
		/// </summary>
		public MyContentPage()
		{
			Debug.WriteLine("ログ用");
			base.Title = "ベース"; //ページのタイトル

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

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.</returns>
		public override string ToString ()
		{
			// これがそのままタイトルになるので.
			return this.Title;
		}
	}

//	public T
}

