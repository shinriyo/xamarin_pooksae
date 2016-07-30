using System;

namespace ClipboardSample.Services
{
    public interface IClipboardService
    {
        void CopyToClipboard(string text);
    }
}
