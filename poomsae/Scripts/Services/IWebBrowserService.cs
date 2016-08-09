//-----------------------------------------------------------------------
// <copyright file="IWebBrowserService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace OpenWebBrowserSample.Services
{
    using System;

    public interface IWebBrowserService
    {
        void Open(Uri uri);
        string Get();
    }
}