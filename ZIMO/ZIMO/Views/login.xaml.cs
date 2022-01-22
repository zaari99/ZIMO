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

        //public async void LoginMethod()
        //{
        //    if (string.IsNullOrEmpty("ibijb"))
        //    {
        //        await Application.Current.MainPage.DisplayAlert(
        //            "Error",
        //            "You must enter an email.",
        //            "Accept");
        //        return;
        //    }
        //    if (string.IsNullOrEmpty("iguuyb"))
        //    {
        //        await Application.Current.MainPage.DisplayAlert(
        //            "Error",
        //            "You must enter a password.",
        //            "Accept");
        //        return;
        //    }

        //    string WebAPIkey = "AIzaSyDewQerdzU0rAZIcpETYdr-jOAeeHc2RUE";


        //    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
        //    try
        //    {
        //        var auth = await authProvider.SignInWithEmailAndPasswordAsync(EmailTxt.ToString(), PasswordTxt.ToString());
        //        var content = await auth.GetFreshAuthAsync();
        //        var serializedcontnet = JsonConvert.SerializeObject(content);

        //        Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
        //    }
        //    catch (Exception ex)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
        //    }

        //    await Task.Delay(20);


          
        //}



    }
}