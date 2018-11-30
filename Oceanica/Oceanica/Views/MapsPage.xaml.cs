using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanica.Views
{
    using Oceanica.Interfaces;
    using Oceanica.ViewModels;
    using Plugin.Geolocator;
    using Plugin.Geolocator.Abstractions;
    using System.Threading;
    using Xamarin.Forms;
    using TK.CustomMap;
    using Xamarin.Forms.Xaml;
    using Plugin.Permissions.Abstractions;
    using Plugin.Permissions;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapsPage : ContentPage
	{
        private List<TKCustomMapPin> _pins = new List<TKCustomMapPin>();
		public MapsPage ()
		{
			InitializeComponent ();
            loadCurrentPosition(false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //loadCurrentPosition();
            enabledGPS();

        }

        private void BtnRefrescarPosicion_Clicked(object sender, System.EventArgs e)
        {
            loadCurrentPosition(true);
        }
        /*
        private void MyMap_MapClicked(object sender, TK.CustomMap.TKGenericEventArgs<TK.CustomMap.Position> e)
        {
            _pins.Clear();
            //if(MyMap.Pins != null)  MyMap.Pins.ToList().Clear();
            var pin = new TKCustomMapPin
            {
                //Type =  TKCustomMapPin.Place,
                Position = e.Value,
                Title = "Posición Actual"
                //Label = "Posición Actual",
            };
            
            _pins.Add(pin);
           // MyMap.Pins = _pins;
            
        }*/

        async private void MyMap_PinDragEnd(object sender, TK.CustomMap.TKGenericEventArgs<TK.CustomMap.TKCustomMapPin> e)
        {
            double lat = e.Value.Position.Latitude;
            double lng = e.Value.Position.Longitude;

            Xamarin.Forms.Maps.Geocoder geoCoder = new Xamarin.Forms.Maps.Geocoder();
            TK.CustomMap.Position position = new TK.CustomMap.Position(lat, lng);
            var vm = (MainViewModel)BindingContext;
            vm.Maps.Coordenadas = position.Latitude + "," + position.Longitude;
            var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude));
            vm.Maps.Direccion = "";
            foreach (var a in possibleAddresses)
            {
                vm.Maps.Direccion += a;
                break;
            }
        } 

        private async void loadCurrentPosition(bool fromButton)
        {
            //if (fromButton)
            //{
                await Task.Delay(1500);
            //}

            if (!this.IsVisible)
            {
                return;
            }
            

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {

                    CancellationTokenSource ctx = new CancellationTokenSource();
                    var locator = CrossGeolocator.Current;

                    //CrossGeolocator.Current.PositionChanged += CrossGeolocator_Current_PositionChanged;
                    locator.DesiredAccuracy = 15;
                    if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
                    {
                        var location = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                        TK.CustomMap.Position position = new TK.CustomMap.Position(location.Latitude, location.Longitude);

                        // MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.25)));

                        _pins.Clear();

                        var pin = new TKCustomMapPin
                        {
                            IsVisible = true,
                            IsDraggable = true,
                            //Type =  TKCustomMapPin.Place,
                            Position = position,
                            Title = "Posición Actual"
                            //Label = "Posición Actual",
                        };

                        _pins.Add(pin);
                        if (MyMap.Pins == null)
                        {
                            MyMap.Pins = _pins;
                        }


                        MyMap.MoveToMapRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.25)));

                        Xamarin.Forms.Maps.Geocoder geoCoder = new Xamarin.Forms.Maps.Geocoder();

                        var vm = (MainViewModel)BindingContext;
                        vm.Maps.Coordenadas = position.Latitude + "," + position.Longitude;
                        var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude));
                        vm.Maps.Direccion = "";
                        foreach (var a in possibleAddresses)
                        {
                            vm.Maps.Direccion += a;
                            break;
                        }
                    }
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Localización denegada", "No se puede continuar, intentar nuevamente.", "OK");
                }
            }
            catch (Exception ex)
            {

            }

        }

        void CrossGeolocator_Current_PositionChanged(object sender, PositionEventArgs e)
        {

            Device.BeginInvokeOnMainThread(async () =>
            {
                /*MyMap.Pins.Clear();

                var position = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "Posición Actual",
                };
                MyMap.Pins.Add(pin);

                Geocoder geoCoder = new Geocoder();

                var vm = (MainViewModel)BindingContext;
                vm.Maps.Coordenadas = position.Latitude + "," + position.Longitude;
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                vm.Maps.Direccion = "";
                foreach (var a in possibleAddresses)
                {
                    vm.Maps.Direccion += a;
                    break;
                }*/
            });
        }

        private async void enabledGPS()
        {
            
            if (this.IsVisible)
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
                    }
                    else if (status != PermissionStatus.Unknown)
                    {
                        await DisplayAlert("Localización denegada", "No se puede continuar, intentar nuevamente.", "OK");
                    }
                }
                catch (Exception ex)
                {

                }
            }   
        }
    }
}