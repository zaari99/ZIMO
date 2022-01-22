using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZIMO.Services;
using ZIMO.ViewModels;

namespace ZIMO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        private async void BtnLogin_Clicked(Object sender, EventArgs e)
        {
            string mail = txtMAil.Text;
            string pass = txtPass.Text;

            var fbLogin = DependencyService.Get<IFirebaseZIMO>();
            string token = await fbLogin.LoginWithEmailPassword(mail, pass);
            await DisplayAlert("toi", token, "OK");
           
            //using (var httpClient = new HttpClient { DefaultRequestHeaders = { Authorization = AuthenticationHeaderValue(token) } })
            //{
            //    var res = await httpClient.GetAsync("http://localhost:5001/api/data&#8221");
            //    var content = await res.Content.ReadAsStringAsync();
            //}

        }

        private AuthenticationHeaderValue AuthenticationHeaderValue(string token)
        {
            throw new NotImplementedException();
        }
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