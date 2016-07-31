using VideoPlayerSample.Services;
using VideoPlayerSample.iOS;
using Xamarin.Forms;
using Foundation;
using UIKit;
using AVFoundation;
using Xamarin.Forms.Platform.iOS;
using MediaPlayer;
using System.Drawing;
using CoreGraphics;

[assembly: Dependency(typeof(VideoPlayerService))]

namespace VideoPlayerSample.iOS
{
	public class VideoPlayerService : UIViewController, IVideoPlayerService
	{
		MPMoviePlayerController moviePlayer;

		public void Open(string uri)
		{
			// first define the Online Video URL you want to play 
			var urltoplay = new NSUrl("http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4");
			this.moviePlayer = new MPMoviePlayerController();
			// set the URL to the Video Player
			this.moviePlayer.ContentUrl = urltoplay;
			this.moviePlayer.View.Frame = new CGRect(55, 170, 310f, 200f);
			// Set this property True if you want the video to be auto played on page load
			this.moviePlayer.ShouldAutoplay = false;
			// If you want to keep the Video player on-ready-to-play state, then enable this
			// This will keep the video content loaded from the URL, untill you play it.
			this.moviePlayer.PrepareToPlay();
			// Enable the embeded video controls of the Video Player, this has several types of Embedded controls for you to choose
			this.moviePlayer.ControlStyle = MPMovieControlStyle.Embedded;

			View.AddSubview(this.moviePlayer.View);

			// To play full screen
			moviePlayer.SetFullscreen(true, true);
		}

		public void Play()
		{
			moviePlayer.Play();
		}
	}
}
