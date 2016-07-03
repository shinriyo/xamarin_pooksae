using Realms.Tool;
using System;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CellTool
{
	/// <summary>
	/// Data.
	/// </summary>
	public class Data
	{
		public String Name { get; set; }
		public String Description { get; set; }
		public String Picture { get; set; }
		public ICommand OnClick { get; set; }
	}

	/// <summary>
	/// Group.
	/// </summary>
	public class Group : ObservableCollection<Data>
	{
		public string Title { get; private set; }
		public Group(string title)
		{
			Title = title;
		}
	}
}

namespace poomsae
{
	/// <summary>
	/// Tools.
	/// </summary>
	public static class Tools
	{


		public static void SplitCSV(string csvString)
		{
			foreach (var line in csvString.Split('\n'))
			{
				var values = line.Split(',');
				// 出力する
				foreach (var value in values)
				{
					Debug.WriteLine("{0} ", value);
				}
			}
		}

		/// <summary>
		/// Initializes the db.
		/// </summary>
		/// <returns>The db.</returns>
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
			var japanName = new Localize()
			{
				Key = "LANGUAGE",
				Name = "日本",
				CountryId = japan
			};

			var englishName = new Localize()
			{
				Key = "LANGUAGE",
				Name = "英語",
				CountryId = english
			};

			var koreanName = new Localize()
			{
				Key = "LANGUAGE",
				Name = "韓国語",
				CountryId = korea
			};

			lc.Insert(japanName);
			lc.Insert(englishName);
			lc.Insert(koreanName);

			var sc = new Controller<Setting>();
			sc.DeleteAll();
			var setting = new Setting()
			{
				country = japan,
				version = "0.1"
			};
			sc.Insert(setting);

			// 技の初期化.
			// TODO: CSVでやる？.
			var ac = new Controller<Art>();
			var adc = new Controller<ArtDetail>();
			var apchaiDesc = new ArtDetail
			{
				CountryId = japan,
				Description = "前に蹴る",
			};

			var apchagi = new Art
			{
				CountryId = japan,
				ArtDetailId = apchaiDesc
			};
			ac.Insert(apchagi);
			adc.Insert(apchaiDesc);
		}
	}
}

