using Realms;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;

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

		public void Insert(T selfObj)
		{
			this.realm.Write(() => 
				{
					Debug.WriteLine(new string('=', 10));
					Debug.WriteLine(typeof(T));
					var toObj = this.realm.CreateObject<T>();
					System.Type type = typeof(T);
					foreach (System.Reflection.PropertyInfo pi in type.GetTypeInfo().DeclaredProperties)
					{
//						object selfValue = type.GetProperty(selfObj.Name).GetValue(self, null);
//						object toValue = type.GetProperty(toObj.Name).GetValue(to, null);
						var selfValue = pi.GetValue(selfObj);
						var toValue = pi.GetValue(toObj);

//						if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
						if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
						{
							pi.SetValue(toObj, selfValue, null);
						}
					}
				});
		}

		public void Update(int id, T obj)
		{
			var res = this.realm.All<T>().Where(d => d.SSN == id.ToString()).First();
			using (var trans = realm.BeginWrite ())
			{
				res = obj;
				trans.Commit();
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

		public void DeleteAll()
		{
			// トランザクションを開始してオブジェクトを削除します.
			using (var trans = this.realm.BeginWrite())
			{
				foreach (var obj in realm.All<T>())
				{
					this.realm.Remove(obj);
				}
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
