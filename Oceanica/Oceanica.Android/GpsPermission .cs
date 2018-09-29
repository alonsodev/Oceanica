using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Locations;
using Android.Widget;
using Android.Provider;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Oceanica.Interfaces;
using Medicos.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(GpsPermission))]
namespace Medicos.Droid
{
    public class GpsPermission : Activity, IGpsPermission
    {
        public void GetGps()
        { 
            LocationManager locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);

            if (locationManager.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                Intent gpsSettingIntent = new Intent(Settings.ActionLocationSourceSettings);
                Forms.Context.StartActivity(gpsSettingIntent);
            }
        }
    }
}