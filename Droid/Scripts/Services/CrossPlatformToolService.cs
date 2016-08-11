//-----------------------------------------------------------------------
// <copyright file="CrossPlatformToolService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Android.Content;
using CrossPlatformToolSample.Android;
using CrossPlatformToolSample.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CrossPlatformToolService))]

namespace CrossPlatformToolSample.Android
{
	/// <summary>
	/// Cross platform tool service.
	/// </summary>
	public class CrossPlatformToolService : ICrossPlatformToolService
	{
		/// <summary>
		/// クリップボードにコピー.
		/// </summary>
		/// <param name="text">Text.</param>
		public void CopyToClipboard(String text)
		{
			// Get the Clipboard Manager
			var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);

			// Create a new Clip
			ClipData clip = ClipData.NewPlainText("xxx_title", text);

			// Copy the text
			clipboardManager.PrimaryClip = clip;
		}

		/// <summary>
		/// Gets the special folder path.
		/// </summary>
		/// <returns>The special folder path.</returns>
		public string GetSpecialFolderPath()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return documentsPath;
		}
	}
}