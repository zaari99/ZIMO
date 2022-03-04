using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZIMO.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using System.Net.Http;

using Newtonsoft.Json;
using ZIMO.Models;
using System.Net;
using System.IO;
using System.Collections.ObjectModel;
using System.Net.Http;
using ZIMO.Views.Masterpage;
using System.Data;

namespace ZIMO.Views
{

    
        

    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class ListProduits : ContentPage
    {
         
         protected List<Produit> res;

        // HttpClient client;
        public ListProduits()
        {
            InitializeComponent();
           
        }

       

        protected async  override void OnAppearing() //
        {
            

            base.OnAppearing();
            try
            {
                HttpClient c;
                c = new HttpClient();
                String url = $"http://192.168.8.102/APIZIMO/api/zimo/getproduits";
                String s;
                s = await c.GetStringAsync(url);
               
                res = JsonConvert.DeserializeObject<List<Produit>>(s);
               
                MyListView.ItemsSource = res;
            } catch (System.Net.Http.HttpRequestException e) {
                await DisplayAlert("WebException", e.Message, "OK"); 
            }
        }
        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
             await Navigation.PushAsync(new DetailsProduits(res[e.SelectedItemIndex].ProduitID));
            
        }

        private async void Allez(object sender, EventArgs e)
        {

            FlyoutPage1FlyoutMenuItem item = new FlyoutPage1FlyoutMenuItem
            {
                Id = 2,
                Title = "Map",
                TargetType = typeof(map)
            };
            await Navigation.PushModalAsync(new FlyoutPage1(item));
        }
    }
}