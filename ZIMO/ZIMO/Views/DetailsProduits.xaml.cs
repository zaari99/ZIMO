using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZIMO.Models;
using ZIMO.Views;
using ZIMO;

namespace ZIMO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsProduits : ContentPage
    {
        
        private int id;
        public DetailsProduits(int ID)
        {   
            InitializeComponent();
            id = ID;
        }
        protected async override void OnAppearing() //
        {
            base.OnAppearing();
            String s="";
            try
            {
                HttpClient c;
                c = new HttpClient();
                String url = $"http://192.168.1.15/APIZIMO/api/zimo/GetDetailsProduit?id={id}";
                
                s = await c.GetStringAsync(url);

                DetailsProduit res;

                res  = JsonConvert.DeserializeObject<DetailsProduit>(s);

               // await  DisplayAlert("WebException",res.BindingContext.ToString(), "OK");

                this.BindingContext = res;
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                await DisplayAlert("WebException", e.Message, "OK");
            }

            
        }
        void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            totalPrix.Text =(Convert.ToInt32(stepper.Value)* Convert.ToDouble(Prix.Text)).ToString();
        }
        private async void AddProduit(Object sender, EventArgs e)
        {
         
            App.dt.Rows.Add("idproduit", id);

            App.dt.Rows.Add("qte", stepper.Value);

            Navigation.PushModalAsync(new NavigationPage(new ListProduits()));

        }
        private async void Back(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync( new ListProduits());
        }
    }
}