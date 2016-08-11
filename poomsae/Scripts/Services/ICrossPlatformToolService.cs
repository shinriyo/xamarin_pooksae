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
    }
}
