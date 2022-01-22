using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
//using Plugin.Permissions;
//using Plugin.Permissions.Abstractions;

namespace ZIMO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class map : ContentPage
    {   
       // private Geolocation g = new Geolocation();
        private readonly Geocoder geo =new Geocoder();
        public map()
        {
            InitializeComponent();
        }
        /////////////////
        //private async void CheckLocationPermission()
        //{

        //    PermissionStatus status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
        //    if (status != PermissionStatus.Granted)
        //    {
        //        Device.BeginInvokeOnMainThread(async () =>
        //        {
        //            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
        //            {
        //                //await DisplayAlert("Need location Permission", "Location permission not available", "OK");
        //            }
        //        });
        ////////////////

        /// ////////////////







        private async void Map_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            await DisplayAlert("Coordonnes", $"lat:{e.Position.Latitude},long:{e.Position.Longitude}", "OK");
            var addresse = await geo.GetAddressesForPositionAsync(e.Position);
            await DisplayAlert("Adresse", addresse.FirstOrDefault()?.ToString(), "OK");
            
            

            var pin = new Pin
            {
                Label = "Santa Cruz",
                Address = addresse.FirstOrDefault()?.ToString(),
                Type = PinType.Place,
                Position = e.Position
            };
            Mymap.Pins.Add(pin);
            var pol= new Polyline {
                StrokeColor = Color.Blue,
                StrokeWidth = 12,
                Geopath = {

                    e.Position,
                    new Position(47.6381473, -122.1350841)} 
            };
            Mymap.MapElements.Add(pol);
        }

            //    var position = await geo.GetPositionsForAddressAsync("Maroc , casablanca ,fsac");
            //    await DisplayAlert("Position", $"{position.First().Latitude} ///{position.First().Longitude}", "OK");
            //    Mymap.MoveToRegion(MapSpan.FromCenterAndRadius(position.First(), Distance.FromKilometers(1)));

            //}





        }
}