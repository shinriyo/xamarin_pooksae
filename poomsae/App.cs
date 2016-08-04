//-----------------------------------------------------------------------
// <copyright file="App.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using Xamarin.Forms;

    /// <summary>
    /// App.
    /// </summary>
    public class App : Application
    {
        /// <summary>
        /// The version.
        /// 今後リリース毎に編集する.
        /// </summary>
        public const string version = "0.1";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Poomsae.App"/> class.
        /// </summary>
        public App()
        {
            // The root page of your application
            // MasterDetailPageを継承したクラスを生成してMainPageとする
            this.MainPage = new MyMasterDetailPage();
        }

        /// <summary>
        /// Ons the start.
        /// </summary>
        /// <returns>The start.</returns>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Ons the sleep.
        /// </summary>
        /// <returns>The sleep.</returns>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Ons the resume.
        /// </summary>
        /// <returns>The resume.</returns>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
