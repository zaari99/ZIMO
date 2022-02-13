using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZIMO.Models;
using ZIMO.Services;
using ZIMO.Views.Masterpage;

namespace ZIMO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
            BtnRegister_ClickedFunc();
        }
      
        private async void BtnEnresiter_Clicked(Object sender, EventArgs e)
        {
            String url = $"http://192.168.8.108/APIZIMO/api/zimo/AddClient";
            string mail = txtMAil.Text;
            string pass = txtPass0.Text;
            string pass1 = txtPass1.Text;
            string nom = Nom.Text;
            string prenom = Prenom.Text;
            if (pass == pass1 && !String.IsNullOrEmpty(nom) && !String.IsNullOrEmpty(prenom)&&!String.IsNullOrEmpty(pass))
            {
                var fbLogin = DependencyService.Get<IFirebaseZIMO>();
                string[] res = await fbLogin.DoRegisterWithEP(mail, pass);
               
                if (res[0] == "token")
                {

                    //########################################################
                    Client client = new Client();
                    client.Nom = nom;
                    client.Prenom = prenom;
                    client.Pass = pass;
                    client.Mail = mail;
                    string json = JsonConvert.SerializeObject(client);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    var inputMessage = new HttpRequestMessage
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };
                   
                    HttpClient httpclient = new HttpClient();
                    try
                    {
                        var message = httpclient.PostAsync(url, inputMessage.Content).Result;

                        if (message.IsSuccessStatusCode)
                        {
                            var apiResponse = message.Content.ReadAsStringAsync();
                            await this.DisplayToastAsync("This is a Toast Message");
                            await this.DisplayToastAsync("This is a Toast Message for 5 seconds", 5000);


                        }
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert(ex.Message, "An error has occurred. Please contact support if the error persists.", "OK");
                       
                    }
                



                //########################################################
                FlyoutPage1FlyoutMenuItem item = new FlyoutPage1FlyoutMenuItem
                    {
                        Id = 2,
                        Title = "ListProduits",
                        TargetType = typeof(ListProduits)
                    };
                    await Navigation.PushModalAsync(new FlyoutPage1(item));

                }
                else if (res[0] == "NotFound")
                {
                    await DisplayAlert("NotFound", res[1], "OK");
                }
                else
                {
                    await DisplayAlert("Error", res[1], "OK");
                }
            }
            else
            {
                await DisplayAlert("erreur", "verifiez les champs", "OK");
            }

           
        }

        private async void BtnRegister_ClickedFunc()
        {
            BtnRegister_Clicked.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
                })
            });

        }





    }
}