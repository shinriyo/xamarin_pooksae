//-----------------------------------------------------------------------
// <copyright file="IVideoPlayerService.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace VideoPlayerSample.Services
{
    using Xamarin.Forms;

    public interface IVideoPlayerService
    {
        void Open(string uri);
        void Play();
        void Stop();
        void Pause();
    }
}
