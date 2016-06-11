using System;
using System.Collections.Generic;
using Realms;

namespace poomsae
{
	// Define your models like regular C# classes
	public class Localize : Model
	{
		public Country CountryId { get; set; }
	}

	public class Country : RealmObject 
	{
		public string SSN { get; set; }
		public string Name{ get; set; }
	}
}
