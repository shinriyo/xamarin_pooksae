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

			Debug.WriteLine("カウント");
			var cnt = puppies.Count(); // => 0 because no dogs have been added yet
			Debug.WriteLine(cnt);

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
					mydog.Name = "30才の犬";
					mydog.Age = 30;
				});

			Debug.WriteLine("カウント");
			// Queries are updated in real-time
			cnt = puppies.Count(); // => 1
			Debug.WriteLine(cnt);

			// LINQ query syntax works as well
			var oldDogs = from d in realm.All<Dog>() where d.Age > 8 select d;

			Debug.WriteLine("爺さん犬");
			foreach (var d in oldDogs) 
			{
				Debug.WriteLine(d.Name);
			}

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

		public Dog FindById (string id)
		{
			return this.realm.All<Dog>().Where(d => d.SSN == id.ToString()).FirstOrDefault();
		}

		public Dog[] FindAll()
		{
			return this.realm.All<Dog>().ToArray();
		}

		public int Count()
		{
			return (this.realm.All<Dog>()).Count();
		}

		public void Delete()
		{
			// トランザクションを開始してオブジェクトを削除します.
			using (var trans = realm.BeginWrite())
			{
				foreach (var dog in realm.All<Dog>())
				{
					this.realm.Remove(dog);
					trans.Commit();
				}
			}
		}

		public void DeleteById(string id)
		{
			// Delete an object with a transaction
			using (var trans = realm.BeginWrite ()) {
				realm.Remove(realm.All<Dog>().Where(d => d.SSN == id).First());
				trans.Commit();
			}
		}
	}
}

