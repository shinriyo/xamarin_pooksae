using System;
using Android.Media;
using ClipboardSample.Android;
using ClipboardSample.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClipboardService))]

namespace ClipboardSample.Android
{
	public class ClipboardService : IClipboardService
	{
		public void CopyToClipboard(String text)
		{
			// TODO:
			//LaunchActivity.AndroidClipboardManager.Text = text;
		}
	}
}