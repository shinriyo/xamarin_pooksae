//-----------------------------------------------------------------------
// <copyright file="IWebBrowserService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace OpenWebBrowserSample.Services
{
    using System;

    /// <summary>
    /// Web browser service.
    /// </summary>
    public interface IWebBrowserService
    {
        /// <summary>
        /// Open the specified uri.
        /// </summary>
        /// <param name="uri">URI.</param>
        void Open(Uri uri);

        /// <summary>
        /// Get this instance.
        /// </summary>
        string Get();
    }
}