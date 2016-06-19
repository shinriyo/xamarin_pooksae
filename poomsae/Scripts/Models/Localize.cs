using Realms;
using Realms.Tool;
using System;
using System.Collections.Generic;

namespace poomsae
{
	/// <summary>
	/// Localize.
	/// </summary>
	public class Localize : RealmObject, IModel
	{
		public string id { get; set; }

		/// <summary>
		/// キー.
		/// </summary>
		/// <value>The key.</value>
		public string Key { get; set; }

		/// <summary>
		/// 実際の文字列の値.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }
		public Country CountryId { get; set; }

		/// <summary>
		/// ダンプ時に便利.
		/// </summary>
		/// <returns>The string.</returns>
		public override string ToString()
		{
			return string.Format("[Localize: id={0}, Key={1}, Name={2}, CountryId={3}]", id, Key, Name, CountryId);
		}
	}

	/// <summary>
	/// Country.
	/// </summary>
	public class Country : RealmObject, IModel 
	{
		public string id { get; set; }
		public string Name { get; set; }

		/// <summary>
		/// ダンプ時に便利.
		/// </summary>
		/// <returns>The string.</returns>
		public override string ToString()
		{
			return string.Format("[Country: id={0}, Name={1}]", id, Name);
		}
	}
}
