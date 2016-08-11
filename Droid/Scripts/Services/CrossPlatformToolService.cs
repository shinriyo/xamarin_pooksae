//-----------------------------------------------------------------------
// <copyright file="CrossPlatformToolService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.IO;
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
		/// Directories the exists.
		/// </summary>
		/// <returns><c>true</c>, if exists was directoryed, <c>false</c> otherwise.</returns>
		/// <param name="path">Path.</param>
		public bool DirectoryExists(string path)
		{
			return Directory.Exists(path);
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
		/// Deletes the directory.
		/// </summary>
		/// <param name="path">Path.</param>
		/// <param name="recursive">If set to <c>true</c> recursive.</param>
		public void DeleteDirectory(string path, bool recursive = false)
		{
			System.IO.Directory.Delete(path, recursive);
		}

		/// <summary>
		/// Files the exists.
		/// </summary>
		/// <returns><c>true</c>, if exists was filed, <c>false</c> otherwise.</returns>
		/// <param name="path">Path.</param>
		public bool FileExists(string path)
		{
			return System.IO.File.Exists(path);
		}

		/// <summary>
		/// Deletes the file.
		/// </summary>
		/// <param name="path">Path.</param>
		public void DeleteFile(string path)
		{
			System.IO.File.Delete(path);
		}
	}
}