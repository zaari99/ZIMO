using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using ZIMO.Views.Masterpage;
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
        







        private async void Map_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            await DisplayAlert("Coordonnes", $"lat:{e.Position.Latitude},long:{e.Position.Longitude}", "OK");
            var addresse = await geo.GetAddressesForPositionAsync(e.Position);
            Mymap.MoveToRegion(MapSpan.FromCenterAndRadius(e.Position, Distance.FromKilometers(0.3)));
            var pin = new Pin
            {
                Label = "Emplacement",
                Address = addresse.FirstOrDefault()?.ToString(),
                Type = PinType.Place,
                Position = e.Position
            };
            Mymap.Pins.Add(pin);

             await Task.Delay(5000);

            var result =  await DisplayAlert("Adresse", addresse.FirstOrDefault()?.ToString(), "OK", "No");
            
            if (result)
            {
                App.adresse = addresse.FirstOrDefault()?.ToString();
                await Task.Delay(2000);
            }
            else
            {
                Mymap.Pins.Clear();
            }
            FlyoutPage1FlyoutMenuItem item = new FlyoutPage1FlyoutMenuItem
            {
                Id = 2,
                Title = "ListProduits",
                TargetType = typeof(Paiement)
            };
            await Navigation.PushModalAsync(new FlyoutPage1(item));






        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var location = await Geolocation.GetLocationAsync();
            var position = new Position(location.Latitude, location.Longitude);
            
            var addresse = await geo.GetAddressesForPositionAsync(position);
            

            Mymap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.3)));

            var pin = new Pin
            {
                Label = "Emplacement",
                Address = addresse.FirstOrDefault()?.ToString(),
                Type = PinType.Place,
                Position = position
            };
            Mymap.Pins.Add(pin);
             await Task.Delay(5000);

            var result = await DisplayAlert("Adresse", addresse.FirstOrDefault()?.ToString(), "OK", "No");

            if (result)
            {
                App.adresse = addresse.FirstOrDefault()?.ToString();
                await Task.Delay(2000);


            }
            else
            {
                Mymap.Pins.Clear();
            }
           
            App.Pos = position;

            FlyoutPage1FlyoutMenuItem item = new FlyoutPage1FlyoutMenuItem
            {
                Id = 2,
                Title = "ListProduits",
                TargetType = typeof(Paiement)
            };
            await Navigation.PushModalAsync(new FlyoutPage1(item));


        }

     





    }
}