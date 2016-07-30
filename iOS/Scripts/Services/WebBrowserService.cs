using System;
using OpenWebBrowserSample.Services;
using OpenWebBrowserSample.iOS;
using Xamarin.Forms;
using UIKit;

[assembly: Dependency(typeof(WebBrowserService))]

namespace OpenWebBrowserSample.iOS
{
	public class WebBrowserService : IWebBrowserService
	{
		public void Open(Uri uri)
		{
			UIApplication.SharedApplication.OpenUrl(uri);
		}
	}
}