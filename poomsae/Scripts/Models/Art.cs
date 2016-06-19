using Realms;
using Realms.Tool;
using System;
using System.Collections.Generic;

namespace poomsae
{
	public class Art : RealmObject, IModel
	{
		public string id { get; set; }
		public string Name { get; set; }
		public ArtDetail detail { get; set; }
	}

	public class ArtDetail : RealmObject, IModel
	{
		public string id { get; set; }
		public string Description { get; set; }
	}
}

