//-----------------------------------------------------------------------
// <copyright file="LocalizeController.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Realms;
    using Realms.Tool;

    /// <summary>
    /// Localize controller.
    /// </summary>
    public class LocalizeController
    {
        /// <summary>
        /// The realm.
        /// </summary>
        private Realm realm;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Poomsae.LocalizeController"/> class.
        /// </summary>
        public LocalizeController()
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

        /// <summary>
        /// Finds the by key.
        /// </summary>
        /// <returns>The by key.</returns>
        /// <param name="key">Key.</param>
        public string FindByKey(string key)
        {
            if (this.CountByKey(key) == 0)
            {
                return null;
            }

            var mysertting = this.GetMySetting();
            var res = this.realm.All<Localize>()
                       .Where(d => d.Key == key && d.Country == mysertting.language)
                          .FirstOrNull();
            if (res == null)
            {
                return string.Empty;
            }
            return res.Key;
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>The all.</returns>
        public Localize[] FindAll()
        {
            return this.realm.All<Localize>().ToArray();
        }

        /// <summary>
        /// Count this instance.
        /// </summary>
        public int Count()
        {
            return this.realm.All<Localize>().Count();
        }

        /// <summary>
        /// Counts the by key.
        /// </summary>
        /// <returns>The by key.</returns>
        /// <param name="key">Key.</param>
        public int CountByKey(string key)
        {
            return this.realm.All<Localize>().Where(d => d.Key == key).Count();
        }
    }
}
