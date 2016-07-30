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
	}
}