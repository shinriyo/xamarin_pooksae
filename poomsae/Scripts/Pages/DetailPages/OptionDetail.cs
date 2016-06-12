using System;
using Xamarin.Forms;
using System.Diagnostics;

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

			var uri = "http://www.sapporoworks.ne.jp/main.jpg";
			var layout = new StackLayout();
			var img = new Image {
				Source = ImageSource.FromUri(new Uri(uri))
			};

			var someImage = new Image() {
				Aspect = Aspect.AspectFit,
				Source = ImageSource.FromUri(new Uri("http://xamarin.com/content/images/pages/branding/assets/xamagon.png")),
			};

			var label = new Label() {
				FontSize = 40,
				XAlign = TextAlignment.Center,
				Text = "選択"
			};

			layout.Children.Add(label);

			// ボタンを生成.
			var languages = new string[3]{"日本語", "英語", "韓国語"};

			foreach (var language in languages)
			{
				var button = new Button { Text = language };
				layout.Children.Add(button);
				button.Clicked += async(s, a) => {
					this.SetDB();
				};
			}

			layout.Children.Add(img);
			layout.Children.Add(someImage);

			// 生成したラベルをこのビューの子要素とする.
			base.Content = layout;
		}

		private void SetDB()
		{
			//var lc = new Controller<Localize>();
			var cc = new Controller<Country>();
			Country newCon = new Country()
			{
				Name = "Japan"	
			};

			var newCon2 = new Country()
			{
				Name = "Japan"	
			};

			cc.Insert(newCon);
			//			cc.Insert(newCon2);
			//			Debug.WriteLine(new string('*', 10));
			//			foreach(var c in cc.FindAll())
			//			{
			//				Debug.WriteLine(c.SSN);
			//				Debug.WriteLine(c.Name);
			//			}
			Debug.WriteLine(new string('*', 10));

			var dc = new DogController ();
			dc.DeleteAll();

			var myDog = new Dog() { Name = "一郎", Age = 10 };
			var myDog2 = new Dog() { Name = "次郎", Age = 11 };
			var myDog3 = new Dog() { Name = "三郎", Age = 12 };
			dc.Insert(myDog);
			dc.Insert(myDog2);
			dc.Insert(myDog3);

			Debug.WriteLine(new string('=', 10));
			var dogs = dc.FindAll();

			Debug.WriteLine("count:{0}", dc.Count());

			foreach(var dog in dogs)
			{
				Debug.WriteLine("id:{0}, name:{1}, age:{2}",
					dog.SSN, dog.Name, dog.Age);
				Debug.WriteLine(new string('-', 10));
			}	
		}
	}
}
