﻿//-----------------------------------------------------------------------
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

        [ObjectId]
        public string Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }

        /// <summary>
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
        /// 説明.
        /// </summary>
        /// <value>The value.</value>
        public string Desc { get; set; }

        /// <summary>
        /// 詳細.
        /// </summary>
        /// <value>The value.</value>
        public string Detail { get; set; }

        /// <summary>
        /// 画像.
        /// </summary>
        /// <value>The value.</value>
        public string Picture { get; set; }

        public override string ToString()
        {
            return string.Format("[ArtModel: Id={0}, Created={1}, Updated={2}, Country={3}, Key={4}, Name={5}, Desc={6}, Detail={7}, Picture={8}]", Id, Created, Updated, Language, Type, Name, Desc, Detail, Picture);
        }
    }
}

