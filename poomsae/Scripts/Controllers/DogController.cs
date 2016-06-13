﻿using Realms;
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
			// トランザクションを用いてオブジェクトを保存・更新します.
			this.realm.Write(() =>
			{
				var id = this.Count();	
				var mydog = realm.CreateObject<Dog>();
				mydog.SSN = (id).ToString ();
				mydog.Name = newDog.Name;
				mydog.Age = newDog.Age;
			});
		}

		public void Update(string id, Dog dog)
		{
			if (this.CountById(id) == 0)
			{
				return;
			}

			var res = this.realm.All<Dog>().Where(d => d.SSN == id).Single();
			using(var trans = realm.BeginWrite())
			{
				res.Name = dog.Name;
				res.Age = dog.Age;
				res.Owner = dog.Owner;
				trans.Commit();
			}
		}

		public Dog FindById(string id)
		{
			if (this.CountById(id) == 0)
			{
				return null;
			}

			return this.realm.All<Dog>().Where(d => d.SSN == id).Single();
		}

		public Dog[] FindAll()
		{
			return this.realm.All<Dog>().ToArray();
		}

		public int Count()
		{
			return this.realm.All<Dog>().Count();
		}		

		public int CountById(string id)
		{
			return this.realm.All<Dog>().Where(d => d.SSN == id).Count();
		}

		public void DeleteAll()
		{
			// トランザクションを開始してオブジェクトを削除します.
			using (var trans = this.realm.BeginWrite())
			{
				// これはだめ.
//				foreach (var dog in realm.All<Dog>())
//				{
//					this.realm.Remove(dog);
//				}
				this.realm.RemoveAll<Dog>();
				trans.Commit();
			}
		}

		public void DeleteById(string id)
		{
			var obj = this.FindById(id);
			if (obj == null)
			{
				return; 
			}

			// Delete an object with a transaction
			using (var trans = this.realm.BeginWrite ()) {
				this.realm.Remove(obj);
				trans.Commit();
			}
		}
	}
}

