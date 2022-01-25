using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZIMO.Services;

namespace ZIMO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }
      
        private async void BtnEnresiter_Clicked(Object sender, EventArgs e)
        {
            string mail = txtMAil.Text;
            string pass = txtPass0.Text;
            string pass1 = txtPass1.Text;
            if (pass == pass1)
            {
                var fbLogin = DependencyService.Get<IFirebaseZIMO>();
                string token = await fbLogin.DoRegisterWithEP(mail, pass);
                await DisplayAlert("toi", token, "OK");
            }
            else
            {
                await DisplayAlert("erreur", "le mot de passe est different", "OK");
            }

           
        }

      



    }
}