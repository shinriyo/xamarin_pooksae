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
	public class WebBrowserService : IWebBrowserService
	{
		public void Open(Uri uri)
		{
			Forms.Context.StartActivity(
				new Intent(Intent.ActionView,
					global::Android.Net.Uri.Parse(uri.AbsoluteUri)));
		}

		public string Get()
		{
			return "file:///android_asset/Content/";
		}
	}
}