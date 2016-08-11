//-----------------------------------------------------------------------
// <copyright file="WebBrowserService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Android.Content;
using OpenWebBrowserSample.Android;
using OpenWebBrowserSample.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebBrowserService))]

namespace OpenWebBrowserSample.Android
{
	/// <summary>
	/// Web browser service.
	/// </summary>
	public class WebBrowserService : IWebBrowserService
	{
		/// <summary>
		/// Open the specified uri.
		/// </summary>
		/// <param name="uri">URI.</param>
		public void Open(Uri uri)
		{
			Forms.Context.StartActivity(
				new Intent(Intent.ActionView,
					global::Android.Net.Uri.Parse(uri.AbsoluteUri)));
		}

		/// <summary>
		/// Get this instance.
		/// </summary>
		public string Get()
		{
			return "file:///android_asset/Content/";
		}
	}
}