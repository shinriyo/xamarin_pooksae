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
					Debug.WriteLine(typeof(T));

					// Error.
					this.realm.Manage<T>(selfObj);
					// Error.
					var obj = this.realm.CreateObject<T>();

					// TODO: I will write later.
					//System.Type type = typeof(T);
					//foreach (System.Reflection.PropertyInfo pi in type.GetTypeInfo().DeclaredProperties)
					//{
					//	object selfValue = type.GetProperty(selfObj.Name).GetValue(self, null);
					//	object toValue = type.GetProperty(toObj.Name).GetValue(to, null);
					//	var selfValue = pi.GetValue(selfObj);
					//	var toValue = pi.GetValue(toObj);

					//	if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
					//	{
					//		pi.SetValue(toObj, selfValue, null);
					//	}
					//}
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
