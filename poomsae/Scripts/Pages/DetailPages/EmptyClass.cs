using CellTool;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace poomsae
{
	public class EmptyClass
	{
		public static ObservableCollection<Group> GetPunches(Action<int> action)
		{
			int id = 10;
			// TOD: コレは後で消す.
			// パンチ系.
			var groups = new ObservableCollection<Group>
			{
				new Group("9級") {
					new Data {
						Name = "パンチ", Description = "パンチ", Picture = "punch_icon.png",
						OnClick = new Command(() => {
							action(id);
						})
					},
				}
			};
			return groups;
		}

		public static ObservableCollection<Group> GetKnives(Action<int> action)
		{
			// TOD: コレは後で消す.
			int id = 10;
			// 手刀系.
			var groups = new ObservableCollection<Group>
			{
				new Group("9級") {
					new Data {
						Name = "ソンナルモクチギ", Description = "手刀受け", Picture = "chop_icon.png",
							OnClick = new Command(() => {
							action(id);
						})
					}
				},
				new Group("8級") {
					new Data {Name = "アギソンモクチギ", Description = "両手刀受け", Picture = "chop_icon.png"},
				},
				new Group("7級") {
					new Data {Name = "チェッピブンモクチギ", Description = "両手刀受け", Picture = "chop_icon.png"},
				}
			};
			return groups;
		}

		public static ObservableCollection<Group> GetKicks(Action<int> action)
		{
			// TOD: コレは後で消す.
			// キック系.
			var groups = new ObservableCollection<Group>
			{
				new Group("9級") {
					new Data {Name = "アプチャギ", Description = "前に蹴る", Picture = "kick_icon.png"},
					new Data {Name = "トルリョチャギ", Description = "回して蹴る", Picture = "kick_icon.png"},
					new Data {Name = "ネリョチャギ", Description = "かかと落とし", Picture = "kick_icon.png"}
				},
				new Group("8級") {
					new Data {Name = "ヨプチャギ", Description = "横蹴り", Picture = "kick_icon.png"},
					new Data {Name = "ティッチャギ", Description = "後ろ蹴り", Picture = "kick_icon.png"},
				},
				new Group("7級") {
					new Data {Name = "ヨプチャギ", Description = "横蹴り", Picture = "kick_icon.png"},
					new Data {Name = "ティッチャギ", Description = "後ろ蹴り", Picture = "kick_icon.png"},
				}
			};
			return groups;
		}

		public static ObservableCollection<Group> GetGuards(Action<int> action)
		{
			// TOD: コレは後で消す.
			// 受け系.
			var groups = new ObservableCollection<Group>
			{
				new Group("9級") {
					new Data {Name = "ソンナルマッキ", Description = "手刀受け", Picture = "guard_icon.png"}
				},
				new Group("8級") {
					new Data {Name = "ソンナルマッキ", Description = "両手刀受け", Picture = "guard_icon.png"},
				},
				new Group("7級") {
					new Data {Name = "へっチョンマッキ", Description = "両端受け", Picture = "guard_icon.png"},
				}
			};
			return groups;
		}

	}
}
