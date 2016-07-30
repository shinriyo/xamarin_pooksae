using Realms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Realms.Tool
{
    /// <summary>
    /// Model用インターフェイス.
    /// </summary>
    public interface IModel
    {
        string Id { get; set; }
        DateTimeOffset Created { get; set; }
        DateTimeOffset Updated { get; set; }
    }

    /// <summary>
    /// 拡張メソッド.
    /// </summary>
    public static class Extend
    {
        public static T FirstOrNull<T>(this IEnumerable<T> sequence) where T : RealmObject, IModel, new()
        {
            foreach (T item in sequence)
                return item;
            return null;
        }
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
        /// インクリメント.
        /// </summary>
        public int Increment()
        {
            var res = this.realm.All<T>().OrderByDescending(i => i.Created).FirstOrNull<T>();
            if (res != null)
            {
                var id = int.Parse(res.Id) + 1;
                return id;
            }

            return 1;
        }

        /// <summary>
        /// Insert the specified selfObj.
        /// </summary>
        /// <param name="selfObj">Self object.</param>
        public void Insert(T selfObj)
        {
            // 1開始.
            selfObj.Id = this.Increment().ToString();
            selfObj.Created = DateTimeOffset.Now;
            selfObj.Updated = DateTimeOffset.Now;

            this.realm.Write(() =>
            {
                this.realm.Manage<T>(selfObj);
            });
        }

        /*
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

			var toObj = this.realm.All<T>().Where(d => d.Id == id).Single();
			var type = toObj.GetType();

			using (var trans = realm.BeginWrite())
			{
				foreach (System.Reflection.PropertyInfo pi in type.GetTypeInfo().DeclaredProperties)
				{
					// idのみ上書きさしない.
					if (pi.Name == "Id" || pi.Name == "Updated" || pi.Name == "Created")
					{
						continue;
					}

					object selfValue = pi.GetValue(selfObj, null);

					if (selfValue == null)
					{
						Debug.WriteLine(new string('-', 10));
						Debug.WriteLine("selfValue: {0}", selfValue);

						// ここで実際にInsertされる.
						pi.SetValue(toObj, selfValue, null);
					}
				}

				selfObj.Updated = DateTimeOffset.Now;
				trans.Commit();
			}
		}
		*/

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

            return this.realm.All<T>().Where(d => d.Id == id).Single();
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>The all.</returns>
        public T[] FindAll()
        {
            return this.realm.All<T>().ToArray();
        }

        public RealmResults<T> GetResults()
        {
            return this.realm.All<T>();
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
            return this.realm.All<T>().Where(d => d.Id == id).Count();
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
            using (var trans = this.realm.BeginWrite())
            {
                this.realm.Remove(realm.All<T>().Where(d => d.Id == id).Single());
                trans.Commit();
            }
        }
    }
}
