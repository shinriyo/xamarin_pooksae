using System;
using Android.Media;
using VideoPlayerSample.Android;
using VideoPlayerSample.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(VideoPlayerService))]

namespace VideoPlayerSample.Android
{
	public class VideoPlayerService : IVideoPlayerService
	{
		public void Open(string uri)
		{
			var mediaPlayer = new MediaPlayer();
			// TODO:
			mediaPlayer.SetDataSource(uri);
			mediaPlayer.Prepare();
			mediaPlayer.Start();
		}
	}
}