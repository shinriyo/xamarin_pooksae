//-----------------------------------------------------------------------
// <copyright file="MyMasterDetailPage.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xamarin.Forms;
    using VideoPlayerSample.Services;

    /// <summary>
    /// App.
    /// </summary>
    public class App : Application
    {
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
