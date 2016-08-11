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
			UIApplication.SharedApplication.OpenUrl(uri);
		}

		/// <summary>
		/// Get this instance.
		/// </summary>
		public string Get()
		{
			return NSBundle.MainBundle.BundlePath + "/Content";
		}
	}
}