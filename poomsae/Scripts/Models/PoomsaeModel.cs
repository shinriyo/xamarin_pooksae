//-----------------------------------------------------------------------
// <copyright file="PoomsaeModel.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using Realms;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Poomsae model.
    /// </summary>
    public class PoomsaeModel : RealmObject
    {
        public enum KyuOrDan
        {
            Kyu,
            Dan,
        }

        [PrimaryKey]
        public string Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }

        /// ローカライズの言語.
        /// </summary>
        /// <value>The country identifier.</value>
        public string Language { get; set; }

        /// <summary>
        /// 0:級 or 1:段.
        /// </summary>
        /// <value>The key.</value>
        public int Type { get; set; }

        /// <summary>
        /// 級/段.
        /// </summary>
        /// <value>The kyu.</value>
        public int Kyu { get; set; }

        /// <summary>
        /// 実際の文字列の値.
        /// </summary>
        /// <value>The value.</value>
        public string Name { get; set; }

        /// <summary>
        /// ハングル.
        /// </summary>
        /// <value>The value.</value>
        public string Hangl { get; set; }

        /// <summary>
        /// 意味.
        /// </summary>
        /// <value>The meaning.</value>
        public string Meaning { get; set; }

        /// <summary>
        /// 順序.
        /// </summary>
        /// <value>The value.</value>
        public string Order { get; set; }

        /// <summary>
        /// 詳細.
        /// </summary>
        /// <value>The value.</value>
        public string Detail { get; set; }

        /// <summary>
        /// YouTubeのURL.
        /// </summary>
        /// <value>You tube URL.</value>
        public string YouTubeURL { get; set; }

        /// <summary>
        /// 画像.
        /// </summary>
        /// <value>The value.</value>
        public string Picture { get; set; }

        public override string ToString()
        {
            return string.Format("[PoomsaeModel: Id={0}, Created={1}, Updated={2}, Language={3}, Type={4}, Kyu={5}, Name={6}, Hangl={7}, Meaning={8}, Order={9}, Detail={10}, YouTubeURL={11}, Picture={12}]", Id, Created, Updated, Language, Type, Kyu, Name, Hangl, Meaning, Order, Detail, YouTubeURL, Picture);
        }
    }
}
