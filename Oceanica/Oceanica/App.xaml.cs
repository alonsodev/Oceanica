using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Oceanica
{
    using Xamarin.Forms;
    using Oceanica.Views;
    using Oceanica.Models;
    using Oceanica.Services;
    using Oceanica.ViewModels;

    public partial class App : Application
	{
        public App ()
		{
			InitializeComponent();
            NavigationPage np = new NavigationPage(new MainMenuPage());
            np.BarBackgroundColor = Color.FromRgb(37, 60, 91);
            MainPage = np;

            //MainPage = new Oceanica.MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
