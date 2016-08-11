//-----------------------------------------------------------------------
// <copyright file="ICrossPlatformToolService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace CrossPlatformToolSample.Services
{
    /// <summary>
    /// クロスプラットフォームで使いそうなものツール.
    /// </summary>
    public interface ICrossPlatformToolService
    {
        /// <summary>
        /// クリップボードにコピーする. 
        /// </summary>
        /// <param name="text">Text.</param>
        void CopyToClipboard(string text);

        /// <summary>
        /// Gets the special folder path.
        /// </summary>
        /// <returns>The special folder path.</returns>
        string GetSpecialFolderPath();

        /// <summary>
        /// Directories the exists.
        /// </summary>
        /// <returns><c>true</c>, if exists was directoryed, <c>false</c> otherwise.</returns>
        /// <param name="path">Path.</param>
        bool DirectoryExists(string path);

        /// <summary>
        /// Deletes the directory.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="recursive">If set to <c>true</c> recursive.</param>
        void DeleteDirectory(string path, bool recursive = false);

        /// <summary>
        /// Files the exists.
        /// </summary>
        /// <returns><c>true</c>, if exists was filed, <c>false</c> otherwise.</returns>
        /// <param name="path">Path.</param>
        bool FileExists(string path);

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="path">Path.</param>
        void DeleteFile(string path);
    }
}
