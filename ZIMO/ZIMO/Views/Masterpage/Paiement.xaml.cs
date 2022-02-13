using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZIMO.Models;
using ZIMOAPI.Models;

namespace ZIMO.Views.Masterpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Paiement : ContentPage
    {
        public Paiement()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing() 
        {
            base.OnAppearing();
            Nom.Text = App.client.Nom;
            Prenom.Text = App.client.Prenom;
            Total.Text = "10000";



            try
            {
                HttpClient c;
                c = new HttpClient();
                String url = $"http://192.168.8.109/APIZIMO/api/zimo/getproduits";
                String s;
                s = await c.GetStringAsync(url);

                var r = JsonConvert.DeserializeObject<List<Produit>>(s);

                MyListView.ItemsSource = r;
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                await DisplayAlert("WebException", e.Message, "OK");
            }
        }



    }
}
//try
//{
//    HttpClient c;
//    c = new HttpClient();
//    String url = $"http://192.168.8.109/APIZIMO/api/zimo/get";

//    String s = await c.GetStringAsync(url);
//    InfoClient  res;
//    res = JsonConvert.DeserializeObject<InfoClient>(s);


//}
//catch (System.Net.Http.HttpRequestException e)
//{
//    await DisplayAlert("WebException", e.Message, "OK");
//}