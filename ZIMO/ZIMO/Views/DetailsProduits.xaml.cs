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
using ZIMO.Views.Masterpage;

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
                String url = $"http://192.168.8.102/APIZIMO/api/zimo/GetDetailsProduit?id={id}";
                
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
         
            //App.dt.Rows.Add("idproduit", id);

            //App.dt.Rows.Add("qte", stepper.Value);
            //App.dt.Rows.Add("Nomproduit",nom.Text);
            //App.dt.Rows.Add("prix",totalPrix.Text);
            DataRow row3 = App.dt.NewRow();

            row3["idproduit"] = IDProduit.Text ;
            row3["qte"] = stepper.Value;
            row3["Nomproduit"] = nom.Text;
            row3["prix"] = totalPrix.Text;
            App.dt.Rows.Add(row3);
            vers_pageListe();

        }
        //private async void Back(Object sender, EventArgs e)
        //{
        //    vers_pageListe();
        //}

        private async void vers_pageListe()
        {
            FlyoutPage1FlyoutMenuItem item = new FlyoutPage1FlyoutMenuItem
            {
                Id = 2,
                Title = "ListProduits",
                TargetType = typeof(ListProduits)
            };
            await Navigation.PushModalAsync(new FlyoutPage1(item));
        }
    }
}