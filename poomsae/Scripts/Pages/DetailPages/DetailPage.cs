using System;
using Xamarin.Forms;

namespace poomsae
{
	/// <summary>
	/// I detail.
	/// </summary>
	public interface IDetail{
		ContentPage Init();
	}

	/// <summary>
	/// Detail factory.
	/// </summary>
	public static class DetailFactory
	{
		/// <summary>
		/// Instantiate the specified obj.
		/// こいつで転送.
		/// </summary>
		/// <param name="obj">Object.</param>
		public static ContentPage CreateObject(IDetail obj)
		{
			return obj.Init();
		}
	}
}

