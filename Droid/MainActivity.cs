using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Poomsae.Droid
{
	[Activity(Label = "poomsae.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			// バナー用
			Xamarinos.AdMob.Forms.Android.AdBannerRenderer.Init();

			// インターステイシャル用
			//Xamarinos.AdMob.Forms.CrossAdmobManager.Init(”広告ユニットID”);

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}
	}
}

