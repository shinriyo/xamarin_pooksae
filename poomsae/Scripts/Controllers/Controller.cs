using Realms;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace poomsae
{
	public class Model : RealmObject
	{
		[ObjectId]
		public string SSN { get; set; }
	}

	public class Controller<T> where T : Model, new()
	{
		private Realm realm;
		public Controller()
		{
			this.realm = Realm.GetInstance();
		}

		public T Create()
		{
			return this.realm.CreateObject<T>();
		}

		public void Insert(T newobj)
		{
//			this.realm.Write(() => 
//				{
//					var myObj = this.realm.CreateObject<T>();
//					newobj;
//				});
		}

		public void Update(int id, T obj)
		{
			var res = this.realm.All<T>().Where(d => d.SSN == id.ToString()).First();
			using (var trans = realm.BeginWrite ())
			{
				res = obj;
			}
		}

		public T FindById (string id)
		{
			return this.realm.All<T>().Where(d => d.SSN == id.ToString()).FirstOrDefault();
		}

		public T[] FindAll()
		{
			return this.realm.All<T>().ToArray();
		}

		public int Count()
		{
			return this.realm.All<T>().Count();
		}

		public void Delete()
		{
			// トランザクションを開始してオブジェクトを削除します.
			using (var trans = this.realm.BeginWrite())
			{
				foreach (var obj in realm.All<T>())
				{
					this.realm.Remove(obj);
					trans.Commit();
				}
			}
		}

		public void DeleteById(string id)
		{
			// Delete an object with a transaction
			using (var trans = this.realm.BeginWrite ()) {
				this.realm.Remove(realm.All<T>().Where(d => d.SSN == id).First());
				trans.Commit();
			}
		}
	}
}
