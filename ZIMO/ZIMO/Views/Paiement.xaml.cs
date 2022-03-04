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
            BtnRegister_ClickedFunc();
        }
        public Paiement(string adress)
        {
            InitializeComponent();
            BtnRegister_ClickedFunc();
            App.adresse = adress;

        }
        protected async override void OnAppearing() 
        {
            base.OnAppearing();
            Nom.Text = App.client.Nom;
            Prenom.Text = App.client.Prenom;
            Total.Text = "10000";

            if (App.adresse == null)
            {
                adressVisible.IsVisible = false;
                adressVisibleName.IsVisible = false;
            }
            else
            {
                adressVisible.IsVisible = true;
                adressVisibleName.IsVisible = true;
                labeladresse.Text = App.adresse;
            }

            var paniers =App.dt.Select().ToList().Select(r => new Panier { NomProduit = r["Nomproduit"] as string, idProduit = r["idproduit"] as string, Qte = r["qte"] as string, prix = r["prix"] as string }); ;
            MyListView.ItemsSource = paniers;
            //App.dt.DefaultView;
        }

        private async  void Button_Clicked(object sender, EventArgs e)
        {
            Commande commande = new Commande();
            commande.IDClient= App.client.IDClient;
            commande.paniers= App.dt.Select().ToList().Select(r => new Panier { NomProduit = r["Nomproduit"] as string, idProduit = r["idproduit"] as string, Qte = r["qte"] as string, prix = r["prix"] as string }).ToList();;
            commande.Laltitude = App.Pos.Latitude;
            commande.Longitude = App.Pos.Longitude;




            //try
            //{
            //    HttpClient c;
            //    c = new HttpClient();
            //    String url = $"http://192.168.8.109/APIZIMO/api/zimo/SetCommande";



            //    var client = new HttpClient();
            //    var content = new StringContent(
            //        JsonConvert.SerializeObject(commande));
            //    var result = await client.PostAsync(url, content);




            //}
            //catch (System.Net.Http.HttpRequestException e)
            //{
            //    await DisplayAlert("WebException", e.Message, "OK");
            //}
            FlyoutPage1FlyoutMenuItem item = new FlyoutPage1FlyoutMenuItem
            {
                Id = 2,
                Title = "ListProduits",
                TargetType = typeof(ListProduits)
            };
            await Navigation.PushModalAsync(new FlyoutPage1(item));
        }

        private async void BtnRegister_ClickedFunc()
        {
            BtnAdres_Clicked.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    Navigation.PushModalAsync(new NavigationPage(new map()));
                })
            });

        }
    }
}
