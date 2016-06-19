using Realms;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;

namespace poomsae
{
	//public class Model : RealmObject
	//{
	//	[ObjectId]
	//	public string SSN { get; set; }
	//}

	public interface IModel
	{
		[ObjectId]
		string SSN { get; set; }
	}

	//public class Controller<T> where T : RealmObject, new()
	//public class Controller<T> where T : Model, new()
	public class Controller<T> where T : RealmObject, IModel, new()
	{
		private Realm realm;
		public Controller()
		{
			this.realm = Realm.GetInstance();
		}

		public void Insert(T selfObj)
		{
			this.realm.Write(() => 
			{
				Debug.WriteLine(new string('*', 10));
				Debug.WriteLine(typeof(T));

				// this.realm.CreateObject<T>();でエラーにならないおまじない.
				this.realm.Manage<T>(selfObj);
				var toObj = this.realm.CreateObject<T>();
				var type = toObj.GetType();

				foreach (System.Reflection.PropertyInfo pi in type.GetTypeInfo().DeclaredProperties)
				{
					object selfValue = pi.GetValue(selfObj, null);

					if (selfValue == null)
					{
						Debug.WriteLine(new string('-', 10));
						Debug.WriteLine("selfValue: {0}", selfValue);						

						// ここで実際にInsertされる.
						pi.SetValue(toObj, selfValue, null);
					}
				}
			});
		}

		public void Update(string id, T obj)
		{
			var res = this.realm.All<T>().Where(d => d.SSN == id).Single();
			using (var trans = realm.BeginWrite())
			{
				// TODO: use reflection later.
				//res.Hoge = obj.Hoge;
				trans.Commit();
			}
		}

		public T FindById(string id)
		{
			if (this.CountById(id) == 0)
			{
				return null;
			}

			return this.realm.All<T>().Where(d => d.SSN == id).Single();
		}

		public T[] FindAll()
		{
			return this.realm.All<T>().ToArray();
		}

		public int Count()
		{
			return this.realm.All<T>().Count();
		}

		public int CountById(string id)
		{
			return this.realm.All<T>().Where(d => d.SSN == id).Count();
		}

		public void DeleteAll()
		{
			// Delete an object with a transaction
			using (var trans = this.realm.BeginWrite())
			{
				this.realm.RemoveAll<T>();
				trans.Commit();
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
