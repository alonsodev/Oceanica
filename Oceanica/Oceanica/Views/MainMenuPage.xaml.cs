using Oceanica.Interfaces;
using Oceanica.Models;
using Oceanica.Services;
using Oceanica.ViewModels;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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
        public MainMenuPage()
        {
            this.dataService = new DataService();
            InitializeComponent();
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
            else
            {
                checkPermission();
            }
        }

        private async void checkPermission()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Localización requerida", "La localización es requerida", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    await Task.Delay(3000);
                    var locator = CrossGeolocator.Current;
                    if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "Por favor habilitar el GPS del dispositivo para el correcto funcionamiento de la aplicación.",
                            "Aceptar");

                        IGpsPermission oGpsPermission = DependencyService.Get<IGpsPermission>();
                        oGpsPermission.GetGps();
                    }
                }/*else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Localización denegada", "No se puede continuar, intentar nuevamente.", "OK");
                    
                }*/
            }
            catch (Exception ex)
            {

            }
        }
    }
}