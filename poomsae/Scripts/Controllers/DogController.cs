using Realms;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Threading;

namespace poomsae
{
	public class DogController
	{
		public DogController ()
		{
			var realm = Realm.GetInstance();

			// Use LINQ to query
			var puppies = realm.All<Dog>().Where(d => d.Age < 2);

			puppies.Count(); // => 0 because no dogs have been added yet

			// Update and persist objects with a thread-safe transaction
			realm.Write(() => 
				{
					var mydog = realm.CreateObject<Dog>();
					mydog.Name = "Rex";
					mydog.Age = 1;
				});

			realm.Write(() => 
				{
					var mydog = realm.CreateObject<Dog>();
					mydog.Name = "threeee";
					mydog.Age = 3;
				});
			
			// Queries are updated in real-time
			puppies.Count(); // => 1

			// LINQ query syntax works as well
			var oldDogs = from d in realm.All<Dog>() where d.Age > 8 select d;
			Debug.WriteLine("==========");
			foreach (var d in oldDogs) 
			{
				Debug.WriteLine(d.Name);
			}
			Debug.WriteLine("==========");

			// Query and update from any thread
//			new Thread(() =>
			new Task(() =>
				{
					var realm2 = Realm.GetInstance();

					var theDog = realm2.All<Dog>().Where(d => d.Age == 1).First();
					realm2.Write(() => theDog.Age = 3);
				}).Start();
		}
	}
}

