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
		public string Id { get; set; }
		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Updated { get; set; }

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
			return string.Format("[Localize: Id={0}, Created={1}, Updated={2}, Key={3}, Name={4}, CountryId={5}]", Id, Created, Updated, Key, Name, CountryId);
		}
	}

	/// <summary>
	/// Country.
	/// </summary>
	public class Country : RealmObject, IModel 
	{
		public string Id { get; set; }
		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Updated { get; set; }

		public string Name { get; set; }

		/// <summary>
		/// ダンプ時に便利.
		/// </summary>
		/// <returns>The string.</returns>
		public override string ToString()
		{
			return string.Format("[Country: Id={0}, Created={1}, Updated={2}, Name={3}]", Id, Created, Updated, Name);
		}
	}
}
