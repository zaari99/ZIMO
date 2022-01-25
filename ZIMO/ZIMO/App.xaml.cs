using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZIMO.Services;
using ZIMO.Views;
using ZIMO.Views.Masterpage;

namespace ZIMO
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
             // MainPage = new map();
             // MainPage = new AppShell();
              MainPage = new FlyoutPage1();
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
