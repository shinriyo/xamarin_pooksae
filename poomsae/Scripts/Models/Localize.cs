//-----------------------------------------------------------------------
// <copyright file="Localize.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System;
    using System.Collections.Generic;
    using Realms;
    using Realms.Tool;

    /// <summary>
    /// Localize Realm.
    /// </summary>
    public class Localize : RealmObject, IModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [ObjectId]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>The created.</value>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        /// <value>The updated.</value>
        public DateTimeOffset Updated { get; set; }

        /// <summary>
        /// キー.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; set; }

        /// <summary>
        /// 実際の文字列の値.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>The country identifier.</value>
        public Country CountryId { get; set; }

        /// <summary>
        /// ダンプ時に便利.
        /// </summary>
        /// <returns>The string.</returns>
        public override string ToString()
        {
            return string.Format("[Localize: Id={0}, Created={1}, Updated={2}, Key={3}, Name={4}, CountryId={5}]", Id, Created, Updated, Key, Name, CountryId);
        }
    }

    /// <summary>
    /// Country.
    /// </summary>
    public class Country : RealmObject, IModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [ObjectId]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>The created.</value>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        /// <value>The updated.</value>
        public DateTimeOffset Updated { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// ダンプ時に便利.
        /// </summary>
        /// <returns>The string.</returns>
        public override string ToString()
        {
            return string.Format("[Country: Id={0}, Created={1}, Updated={2}, Name={3}]", Id, Created, Updated, Name);
        }
    }
}
