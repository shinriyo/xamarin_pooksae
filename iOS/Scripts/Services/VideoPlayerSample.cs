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
			// TODO:
			MPMoviePlayerController moviePlayer;
			moviePlayer = new MPMoviePlayerController(NSUrl.FromFilename(uri));
			//UIApplication.SharedApplication.Window.RootController.Add(moviePlayer.View);
			var root = UIApplication.SharedApplication.KeyWindow.RootViewController.NavigationController;
			//root.Add(moviePlayer.View);
			moviePlayer.ShouldAutoplay = true;
			moviePlayer.SetFullscreen(true, true);
			moviePlayer.Play();
		}
	}
}
