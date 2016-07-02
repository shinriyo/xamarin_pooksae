using System;
using System.Collections.ObjectModel;
using CellTool;

namespace poomsae
{
	public class EmptyClass
	{
		public static ObservableCollection<Group> GetPunches()
		{
			// TOD: コレは後で消す.
			// パンチ系.
			var ar = new ObservableCollection<Group>
			{
				new Group("9級") {
					new Data {Name = "パンチ", Description = "パンチ", Picture = "woman.png"},
				}
			};
			return ar;
		}

		public static ObservableCollection<Group> GetKnives()
		{
			// TOD: コレは後で消す.
			// 手刀系.
			var ar = new ObservableCollection<Group>
			{
				new Group("9級") {
					new Data {Name = "ソンナルマッキ", Description = "かかと落とし", Picture = "man.png"}
				},
				new Group("8級") {
					new Data {Name = "ソンナルマッキ", Description = "後ろ蹴り", Picture = "woman.png"},
				}
			};
			return ar;
		}

		public static ObservableCollection<Group> GetKicks()
		{
			// TOD: コレは後で消す.
			// キック系.
			var ar = new ObservableCollection<Group>
			{
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
			return ar;
		}
	}
}
