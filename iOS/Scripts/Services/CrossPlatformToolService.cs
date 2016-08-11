//-----------------------------------------------------------------------
// <copyright file="CrossPlatformToolService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.IO;
using CrossPlatformToolSample.iOS;
using CrossPlatformToolSample.Services;
using UIKit;
using Xamarin.Forms;

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

		/// <summary>
		/// Directories the exists.
		/// </summary>
		/// <returns><c>true</c>, if exists was directoryed, <c>false</c> otherwise.</returns>
		/// <param name="path">Path.</param>
		public bool DirectoryExists(string path)
		{
			return Directory.Exists(path);
		}
	}
}
