using Realms;
using Realms.Tool;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poomsae
{
	public class LocalizeController
	{
		private Realm realm;

		public LocalizeController ()
		{
			this.realm = Realm.GetInstance();
		}

		/// <summary>
		/// Gets my setting.
		/// </summary>
		/// <returns>The my setting.</returns>
		public Setting GetMySetting()
		{
			var sc = new Controller<Setting>();
			var setting = sc.FindAll().FirstOrNull();
			return setting;
		}

		public Localize FindByKey(string key)
		{
			if (this.CountByKey(key) == 0)
			{
				return null;
			}

			var mysertting = this.GetMySetting();
			return this.realm.All<Localize>()
				       .Where(d => d.Key == key && d.CountryId == mysertting.country)
			           .Single();
		}

		public Localize[] FindAll()
		{
			return this.realm.All<Localize>().ToArray();
		}

		public int Count()
		{
			return this.realm.All<Localize>().Count();
		}		

		public int CountByKey(string key)
		{
			return this.realm.All<Localize>().Where(d => d.Key == key).Count();
		}
	}
}

