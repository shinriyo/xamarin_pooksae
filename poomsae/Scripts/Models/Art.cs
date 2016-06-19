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

		public override string ToString()
		{
			return string.Format("[Art: Id={0}, Name={1}, Created={2}, Updated={3}, detail={4}]", Id, Name, Created, Updated, detail);
		}
	}

	public class ArtDetail : RealmObject, IModel
	{
		public string Id { get; set; }
		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Updated { get; set; }

		public string Description { get; set; }

		public override string ToString()
		{
			return string.Format("[ArtDetail: Id={0}, Created={1}, Updated={2}, Description={3}]", Id, Created, Updated, Description);
		}
	}
}

