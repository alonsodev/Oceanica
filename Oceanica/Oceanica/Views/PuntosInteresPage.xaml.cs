﻿using Oceanica.Interfaces;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;


namespace Oceanica.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PuntosInteresPage : ContentPage
	{
        bool windowFirstTime = true;
        Pin oPin = new Pin();
		public PuntosInteresPage ()
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

        private async void loadCurrentPosition(bool fromButton)
        {
            if (fromButton)
            {
                await Task.Delay(1500);
            }
            //windowFirstTime = false;
            /*if (this.IsVisible)
            {*/
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
                    /**/

                    if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
                    {

                        ctx.CancelAfter(30000);
                        var location = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));//TimeSpan.FromTicks(10000)
                        Xamarin.Forms.Maps.Position position = new Xamarin.Forms.Maps.Position(location.Latitude, location.Longitude);

                        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.25)));

                        MyMap.Pins.Clear();

                        oPin = new Pin
                        {
                            Type = PinType.Place,
                            Position = position,
                            Label = "Posición Actual",
                        };
                        MyMap.Pins.Add(oPin);
                    }
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Localización denegada", "No se puede continuar, intentar nuevamente.", "OK");
                }
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
                
            //}
        }

        void CrossGeolocator_Current_PositionChanged(object sender, PositionEventArgs e)
        {

            Device.BeginInvokeOnMainThread(() =>
            {
                MyMap.Pins.Clear();

                var position = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
                oPin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "Posición Actual",
                };
                MyMap.Pins.Add(oPin);
            });
        }

        private async void enabledGPS()
        {
            if (this.IsVisible) {
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