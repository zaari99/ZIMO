using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZIMO.Views.Masterpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPage1Flyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPage1Flyout()
        {
            InitializeComponent();
            BtnRegister_ClickedFunc();
            BindingContext = new FlyoutPage1FlyoutViewModel();
            ListView = MenuItemsListView;
            name.Text = $"{App.client.Nom} {App.client.Prenom}"; 
        }

        class FlyoutPage1FlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPage1FlyoutMenuItem> MenuItems { get; set; }

            public FlyoutPage1FlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPage1FlyoutMenuItem>(new[]
                {
                 //  new FlyoutPage1FlyoutMenuItem { Id = 0, Title = "Login Page",TargetType=typeof(LoginPage) },
                    new FlyoutPage1FlyoutMenuItem { Id = 1, Title = "Produits ",TargetType=typeof(ListProduits) },
                    new FlyoutPage1FlyoutMenuItem { Id = 2, Title = "Paiement",TargetType=typeof(Paiement) },
                    //new FlyoutPage1FlyoutMenuItem { Id = 3, Title = "Page 4" },
                    //new FlyoutPage1FlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private async void BtnRegister_ClickedFunc()
        {
            BtnRegister_Clicked.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    
                      //Navigation.PushAsync(new LoginPage());
                       Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
                   //  new NavigationPage(new LoginPage());
                    //     Navigation.PushAsync(new LoginPage());
                })
            });

        }
    }
}