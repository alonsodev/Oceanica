using Oceanica.Models;
using Oceanica.Services;
using Oceanica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Oceanica.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenuPage : ContentPage
	{
        #region Services
        private DataService dataService;
        #endregion
        public MainMenuPage ()
		{
            this.dataService = new DataService();
            InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PerfilLocal oPerfilLocal = this.dataService.First<PerfilLocal>(false);
            if (oPerfilLocal == null)
            {
                var vMainViewModel = MainViewModel.GetInstance();
                vMainViewModel.MenuEditarPerfil = new MenuEditarPerfilViewModel();
                vMainViewModel.MenuEditarPerfil.FirstValidation = true;
                Application.Current.MainPage.Navigation.PushAsync(new MenuEditarPerfilPage());
            }
        }
    }
}