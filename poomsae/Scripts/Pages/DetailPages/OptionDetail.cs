using Realms.Tool;
using System.Linq;
using Xamarin.Forms;

namespace poomsae
{
	/// <summary>
	/// Option detail.
	/// </summary>
	public class OptionDetail : ContentPage, IDetail
	{
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.</returns>
		public override string ToString ()
		{
			// これがそのままタイトルになるので.
			return string.Format ("{0}", this.Title);
		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		public ContentPage Init()
		{
			return new OptionDetail ();
		}

		public OptionDetail ()
		{
			base.Title = "オプション"; //ページのタイトル

			var layout = new StackLayout();

			var label = new Label()
			{
				FontSize = 30,
				XAlign = TextAlignment.Center,
				Text = "選択"
			};

			layout.Children.Add(label);

			// ボタンを生成.
			var languages = GetLanguages();

			foreach (var language in languages)
			{
				var button = new Button { Text = language };
				layout.Children.Add(button);
				button.Clicked += (s, a) => {
					// TODO:
				};
			}

			// 生成したラベルをこのビューの子要素とする.
			base.Content = layout;
		}

		private string[] GetLanguages()
		{
			var cc = new Controller<Country>();
			var countries = cc.FindAll();
			return countries.Select(item=>item.Name).ToArray();
		}
	}
}
