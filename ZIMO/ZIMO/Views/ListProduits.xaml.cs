using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZIMO.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using ZIMO.Models;

namespace ZIMO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListProduits : ContentPage
    {
        HttpClient client;
        public ListProduits()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing() //
        {
            base.OnAppearing();
            client = new HttpClient();
             Uri uri = new Uri("http://");
             HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                List<Produit>  Items = JsonConvert.DeserializeObject<List<Produit>>(content);
                this.BindingContext = Items;
            }

        }
    }
}