using System;
using VideoPlayerSample.Services;
using VideoPlayerSample.iOS;
using Xamarin.Forms;
using Foundation;
using UIKit;
using MediaPlayer;

[assembly: Dependency(typeof(VideoPlayerService))]

namespace VideoPlayerSample.iOS
{
	public class VideoPlayerService : IVideoPlayerService
	{
		public void Open(string uri)
		{
			var moviePlayer = new MPMoviePlayerController(NSUrl.FromString(uri));
			moviePlayer.SetFullscreen(true, true);
			moviePlayer.Play();
		}
	}
}
