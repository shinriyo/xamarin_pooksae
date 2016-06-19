using Realms;
using Realms.Tool;
using System;
using System.Collections.Generic;

namespace poomsae
{
	/// <summary>
	/// 現在の設定.
	/// </summary>
	public class Setting : RealmObject, IModel
	{
		public string Id { get; set; }
		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Updated { get; set; }

		public Country country { get; set; }
		public string version { get; set; }
	}
}
