using System;
using System.Collections.Generic;
using Realms;

namespace poomsae
{
	/// <summary>
	/// Localize.
	/// </summary>
	public class Localize : RealmObject, IModel
	{
		public string id { get; set; }
		public Country CountryId { get; set; }
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
