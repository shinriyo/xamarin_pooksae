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
		private Realm realm;
		public DogController ()
		{
//			var realm = Realm.GetInstance();
			this.realm = Realm.GetInstance();

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

		public void Insert()
		{
			realm.Write(() => 
				{
					var mydog = realm.CreateObject<Dog>();
					mydog.Name = "Rex";
					mydog.Age = 1;
				});
		}

		public void Update(int id, Dog dog)
		{
			var res = realm.All<Dog>().Where(d => d.SSN == id.ToString()).First();
			using (var trans = realm.BeginWrite ())
			{
				res.Name = dog.Name;
				res.Age = dog.Age;
				res.Owner = dog.Owner;
			}
		}

		public Dog FindById (int id)
		{
//			return realm.All<Dog> ().Where (d => d.SSN == "1").First ();
			return null;
		}

		public RealmResults<Dog> FindAll()
		{
			return (realm.All<Dog>());
		}

		public int Count()
		{
			return (realm.All<Dog>()).Count();
		}

		public void Delete()
		{
			// トランザクションを開始してオブジェクトを削除します
			using (var trans = realm.BeginWrite())
			{
				foreach (var dog in realm.All<Dog>()) {
					realm.Remove(dog);
					trans.Commit();
				}
			}
		}

		public void DeleteById(int id)
		{
			// Delete an object with a transaction
			using (var trans = realm.BeginWrite ()) {
				realm.Remove(realm.All<Dog>().Where(d => d.SSN == id.ToString()).First());
			}
		}
	}
}

