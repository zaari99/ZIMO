using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using ZIMO.Models;
using ZIMO.Services;
using ZIMO.Views;
using ZIMO.Views.Masterpage;
using ZIMOAPI.Models;

namespace ZIMO
{
    public partial class App : Application
    {
        public static  DataTable dt = new DataTable("Produits");
        public static Position Pos=new Position();
        public static string adresse = null;

        //public static Paniers Paniers = new Paniers();
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
            dt.Columns.Add("idproduit");
            
            dt.Columns.Add("Nomproduit");
            dt.Columns.Add("prix");
            


        }
       

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
