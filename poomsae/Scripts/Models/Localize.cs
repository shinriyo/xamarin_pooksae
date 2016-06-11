using System;
using System.Collections.Generic;
using Realms;

namespace poomsae
{
	// Define your models like regular C# classes
	public class Localie : RealmObject 
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}
}
