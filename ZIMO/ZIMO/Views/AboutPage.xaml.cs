using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

namespace ZIMO.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
           // var map = new Map(MapSpan.FromCenterAndRadius(new Position(36.8961, 10.1865), Distance.FromMiles(0.5)){
            //    IsShowingUser = true;
           //     VerticalOptions =L
           // };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Xamarin.Essentials.Map.OpenAsync(47.4593,-122.1422);

        }
    }
}