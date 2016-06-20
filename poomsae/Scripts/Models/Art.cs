using Realms;
using Realms.Tool;
using System;
using System.Collections.Generic;

namespace poomsae
{
	public class Art : RealmObject, IModel
	{
		public string Id { get; set; }
		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Updated { get; set; }

		public Country CountryId { get; set; }
		public ArtDetail ArtDetailId { get; set; }

		public override string ToString()
		{
			return string.Format("[Art: Id={0}, Created={1}, Updated={2}, CountryId={3}, ArtDetailId={4}]", Id, Created, Updated, CountryId, ArtDetailId);
		}
	}

	public class ArtDetail : RealmObject, IModel
	{
		public string Id { get; set; }
		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Updated { get; set; }

		public Country CountryId { get; set; }
		public string Description { get; set; }

		public override string ToString()
		{
			return string.Format("[ArtDetail: Id={0}, Created={1}, Updated={2}, CountryId={3}, Description={4}]", Id, Created, Updated, CountryId, Description);
		}
	}
}

