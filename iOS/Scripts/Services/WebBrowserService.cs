//-----------------------------------------------------------------------
// <copyright file="WebBrowserService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Foundation;
using OpenWebBrowserSample.iOS;
using OpenWebBrowserSample.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebBrowserService))]

namespace OpenWebBrowserSample.iOS
{
	public class WebBrowserService : IWebBrowserService
	{
		public void Open(Uri uri)
		{
			UIApplication.SharedApplication.OpenUrl(uri);
		}

		public string Get()
		{
			return NSBundle.MainBundle.BundlePath + "/Content";
		}
	}
}