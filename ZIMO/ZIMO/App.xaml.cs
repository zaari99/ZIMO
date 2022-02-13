using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZIMO.Services;
using ZIMO.Views;
using ZIMO.Views.Masterpage;
using ZIMOAPI.Models;

namespace ZIMO
{
    public partial class App : Application
    {
        public static  DataTable dt = new DataTable("Produits");
        public static InfoClient client = new InfoClient();

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            // MainPage = new map();
            // MainPage = new AppShell();
             MainPage = new NavigationPage(new LoginPage());
            //  MainPage = new ListProduits();
           
        }

        protected  override void OnStart()
        {
            dt.Columns.Add("qte");
           // dt.Get["qte"].Unique = true;



            dt.Columns.Add("idproduit");
           
        }
       

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
