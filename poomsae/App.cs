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
            /*
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};*/

            // MasterDetailPageを継承したクラスを生成してMainPageとする
            this.MainPage = new MyMasterDetailPage();
            //			MainPage = new TabbedPage() {
            //				Children = {
            //					new TabbedPageItem("Tab1"),
            //					new TabbedPageItem("Tab2"),
            //					new TabbedPageItem("Tab3")
            //				}
            //			};
            //this.MainPage = new VideoPlayerPage { BindingContext = new VideoPlayerViewModel() };
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
