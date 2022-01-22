using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZIMO.Services;
using ZIMO.Views;

namespace ZIMO
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
             // MainPage = new map();
              MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
