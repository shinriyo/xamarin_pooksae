using System;
using System.Collections.Generic;
using Realms;

namespace poomsae
{
	// Define your models like regular C# classes
	public class Localize : RealmObject, IModel
	{
		public string SSN { get; set; }
		public Country CountryId { get; set; }
	}

	public class Country : RealmObject, IModel 
	{
		public string SSN { get; set; }
		public string Name { get; set; }
	}
}
