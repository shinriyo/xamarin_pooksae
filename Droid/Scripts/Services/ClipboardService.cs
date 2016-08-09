//-----------------------------------------------------------------------
// <copyright file="ClipboardService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Android.Content;
using ClipboardSample.Android;
using ClipboardSample.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClipboardService))]

namespace ClipboardSample.Android
{
	public class ClipboardService : IClipboardService
	{
		public void CopyToClipboard(String text)
		{
			// Get the Clipboard Manager
			var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);

			// Create a new Clip
			ClipData clip = ClipData.NewPlainText("xxx_title", text);

			// Copy the text
			clipboardManager.PrimaryClip = clip;
		}
	}
}