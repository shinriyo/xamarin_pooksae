//-----------------------------------------------------------------------
// <copyright file="ClipboardService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using ClipboardSample.Services;
using ClipboardSample.iOS;
using Xamarin.Forms;
using Foundation;
using UIKit;
using MediaPlayer;

[assembly: Dependency(typeof(ClipboardService))]

namespace ClipboardSample.iOS
{
	public class ClipboardService : IClipboardService
	{
		public void CopyToClipboard(String text)
		{
			UIPasteboard clipboard = UIPasteboard.General;
			clipboard.String = text;
		}
	}
}
