using Realms;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace poomsae
{
	/// <summary>
	/// Model用インターフェイス.
	/// </summary>
	public interface IModel
	{
		[ObjectId]
		string id { get; set; }
	}

	/// <summary>
	/// Controller.
	/// </summary>
	public class Controller<T> where T : RealmObject, IModel, new()
	{
		private Realm realm;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:poomsae.Controller`1"/> class.
		/// </summary>
		public Controller()
		{
			this.realm = Realm.GetInstance();
		}

		/// <summary>
		/// Insert the specified selfObj.
		/// </summary>
		/// <param name="selfObj">Self object.</param>
		public void Insert(T selfObj)
		{
			this.realm.Write(() => 
			{
				this.realm.Manage<T>(selfObj);
				/*
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
				*/
			});
		}

		/// <summary>
		/// Update the specified id and obj.
		/// </summary>
		/// <param name="id">Identifier.</param>
		/// <param name="obj">Object.</param>
		public void Update(string id, T selfObj)
		{
			// 一度チェック.
			if (this.CountById(id) == 0)
			{
				return;
			}

			var toObj = this.realm.All<T>().Where(d => d.id == id).Single();
			var type = toObj.GetType();

			using (var trans = realm.BeginWrite())
			{
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

				trans.Commit();
			}
		}

		/// <summary>
		/// Finds the by identifier.
		/// </summary>
		/// <returns>The by identifier.</returns>
		/// <param name="id">Identifier.</param>
		public T FindById(string id)
		{
			if (this.CountById(id) == 0)
			{
				return null;
			}

			return this.realm.All<T>().Where(d => d.id == id).Single();
		}

		/// <summary>
		/// Finds all.
		/// </summary>
		/// <returns>The all.</returns>
		public T[] FindAll()
		{
			return this.realm.All<T>().ToArray();
		}

		/// <summary>
		/// Count this instance.
		/// </summary>
		public int Count()
		{
			return this.realm.All<T>().Count();
		}

		/// <summary>
		/// Counts the by identifier.
		/// </summary>
		/// <returns>The by identifier.</returns>
		/// <param name="id">Identifier.</param>
		public int CountById(string id)
		{
			return this.realm.All<T>().Where(d => d.id == id).Count();
		}

		/// <summary>
		/// Deletes all.
		/// </summary>
		/// <returns>The all.</returns>
		public void DeleteAll()
		{
			// Delete an object with a transaction
			using (var trans = this.realm.BeginWrite())
			{
				this.realm.RemoveAll<T>();
				trans.Commit();
			}
		}

		/// <summary>
		/// Deletes the by identifier.
		/// </summary>
		/// <returns>The by identifier.</returns>
		/// <param name="id">Identifier.</param>
		public void DeleteById(string id)
		{
			// Delete an object with a transaction
			using (var trans = this.realm.BeginWrite ()) {
				this.realm.Remove(realm.All<T>().Where(d => d.id == id).First());
				trans.Commit();
			}
		}
	}
}
