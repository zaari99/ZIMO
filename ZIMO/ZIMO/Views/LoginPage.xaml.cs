using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZIMO.Models;
using ZIMO.Services;
using ZIMO.Views.Masterpage;
using ZIMOAPI.Models;

namespace ZIMO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BtnRegister_ClickedFunc();


        }
        private async void BtnLogin_Clicked(Object sender, EventArgs e)
        {
            string mail = txtMAil.Text;
            string pass = txtPass.Text;
            if (string.IsNullOrEmpty(mail))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(pass))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password.",
                    "Accept");
                return;
            }
            else {
                var fbLogin = DependencyService.Get<IFirebaseZIMO>();
                //string token = await fbLogin.LoginWithEmailPassword(mail, pass);
                string[] res = await fbLogin.LoginWithEmailPassword(mail, pass);
                if (res[0] == "token") {
                  
                    FlyoutPage1FlyoutMenuItem item = new FlyoutPage1FlyoutMenuItem
                    {
                        Id = 2,
                        Title = "ListProduits",
                        TargetType = typeof(ListProduits)
                    };

                    HttpClient c;
                    c = new HttpClient();
                    String url = $"http://192.168.8.102/APIZIMO/api/zimo/GetInfoClient?Mail={mail}";
                    String s = await c.GetStringAsync(url);
                    var client = JsonConvert.DeserializeObject<InfoClient>(s);
                    App.client = client;

                    await this.DisplayToastAsync("Bienvenue "+client.Nom +" "+ client.Prenom );
                    await Navigation.PushModalAsync(new  FlyoutPage1(item));

                } else if(res[0]=="NotFound") {
                    await DisplayAlert("NotFound", res[1], "OK");
                }
                else
                {
                    await DisplayAlert("Error", res[1], "OK");
                }
               
             
            }
           



               

            }
        private async void BtnRegister_ClickedFunc()
        {
            BtnRegister_Clicked.GestureRecognizers.Add (new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    Navigation.PushAsync(new NavigationPage(new Register()));
                })
            });
           
        }
       


    }
}