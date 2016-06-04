using System;
using Xamarin.Forms;

namespace poomsae
{
//	public class Singleton<T> where T : class, new()
//	{
//		private static T instance = null;
//
//		private Singleton() { }
//
//		public static T Instancia
//		{
//			get 
//			{
//				if (instance == null)
//					instance = new T();
//				return instance;
//			}
//		}
//	}

	/// <summary>
	/// Detail object.
	/// </summary>
	public class DetailObject
	{
		public string title {get;protected set;}
		public string content {get;protected set;}
		public View page {get;protected set;}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="poomsae.DetailObject"/>.</returns>
		public override string ToString ()
		{
			// これがそのままタイトルになるので.
			return string.Format ("title={0}", title);
		}
	}
}

