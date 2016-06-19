using Realms;
using Realms.Tool;
using System;
using System.Collections.Generic;

namespace poomsae
{
	public class Art : RealmObject, IModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Updated { get; set; }

		public ArtDetail detail { get; set; }
	}

	public class ArtDetail : RealmObject, IModel
	{
		public string Id { get; set; }
		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Updated { get; set; }

		public string Description { get; set; }
	}
}

