//-----------------------------------------------------------------------
// <copyright file="CrossPlatformToolService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using CrossPlatformToolSample.Services;
using CrossPlatformToolSample.iOS;
using Xamarin.Forms;
using UIKit;

[assembly: Dependency(typeof(CrossPlatformToolService))]

namespace CrossPlatformToolSample.iOS
{
	/// <summary>
	/// クロスプラットフォームで使いそうなものツール.
	/// </summary>
	public class CrossPlatformToolService : ICrossPlatformToolService
	{
		/// <summary>
		/// クリップボードにコピー.
		/// </summary>
		/// <param name="text">Text.</param>
		public void CopyToClipboard(String text)
		{
			UIPasteboard clipboard = UIPasteboard.General;
			clipboard.String = text;
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
