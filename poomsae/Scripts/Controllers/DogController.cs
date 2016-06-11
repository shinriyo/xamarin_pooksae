using Realms;
//using System;
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
			this.realm = Realm.GetInstance();
		}

		public void Insert(Dog newDog)
		{
			this.realm.Write(() => 
				{
					var mydog = realm.CreateObject<Dog>();
					mydog.Name = newDog.Name;
					mydog.Age = newDog.Age;

				});
		}

		public void Update(int id, Dog dog)
		{
			var res = this.realm.All<Dog>().Where(d => d.SSN == id.ToString()).First();
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
			return this.realm.All<Dog>().Count();
		}

		public void Delete()
		{
			// トランザクションを開始してオブジェクトを削除します.
			using (var trans = this.realm.BeginWrite())
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
			using (var trans = this.realm.BeginWrite ()) {
				this.realm.Remove(realm.All<Dog>().Where(d => d.SSN == id).First());
				trans.Commit();
			}
		}
	}
}

