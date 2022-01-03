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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        //private async void BtnLogin_Clicked(Object sender ,EventArgs e)
        //{
        //    string mail = txtMAil.Text;
        //    string pass = txtPass.Text;

        //    var fbLogin = DependencyService.Get<IFirebaseZIMO>();
        //    string token = await fbLogin.LoginWithEmailPassword(mail, pass);
        //    await DisplayAlert("toi", token, "OK");

        //}
        //private async void BtnEnresiter_Clicked(Object sender ,EventArgs e)
        //{
        //    string mail = txtMAil.Text;
        //    string pass = txtPass.Text;

        //    var fbLogin = DependencyService.Get<IFirebaseZIMO>();
        //    string token = await fbLogin.DoRegisterWithEP(mail, pass);
        //    await DisplayAlert("toi", token, "OK");
        //}
    }
}