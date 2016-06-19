using Realms.Tool;
using System.Diagnostics;

namespace poomsae
{
	/// <summary>
	/// Tools.
	/// </summary>
	public static class Tools
	{
		public static void InitializeDB()
		{
			var cc = new Controller<Country>();
			cc.DeleteAll();

			var japan = new Country() { Name = "Japan" };
			var korea = new Country() { Name = "Korea" };
			var english = new Country() { Name = "English" };

			cc.Insert(japan);
			cc.Insert(korea);
			cc.Insert(english);

			foreach (var c in cc.FindAll())
			{
				Debug.WriteLine(c);
			}

			Debug.WriteLine(new string('*', 10));
			var lc = new Controller<Localize>();
			lc.DeleteAll();

			// 名前系.
			var japanName = new Localize() {
				Key = "Language",
				Name = "日本",
				CountryId = japan
			};

			var englishName = new Localize()
			{
				Key = "Language",
				Name = "英語",
				CountryId = english
			};

			var koreanName = new Localize()
			{
				Key = "Language",
				Name = "韓国語",
				CountryId = korea
			};

			var sc = new Controller<Setting>();
			var setting = new Setting()
			{
				country = japan,
				version = "0.1"
			};
			sc.Insert(setting);
		}
	}
}

