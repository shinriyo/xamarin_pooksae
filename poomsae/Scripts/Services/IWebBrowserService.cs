using System;

namespace OpenWebBrowserSample.Services
{
    public interface IWebBrowserService
    {
        void Open(Uri uri);
    }
}