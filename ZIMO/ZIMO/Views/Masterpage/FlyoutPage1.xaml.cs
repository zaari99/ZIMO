using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZIMO.Views.Masterpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPage1 : FlyoutPage
    {
        public FlyoutPage1()
        {
            InitializeComponent();
          
                FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
           
            
        }
        public FlyoutPage1(FlyoutPage1FlyoutMenuItem p)
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
            GotoPage(p);
            
            

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutPage1FlyoutMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            
            Detail = new NavigationPage(page);
            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
       
        private void GotoPage(FlyoutPage1FlyoutMenuItem item)
        {
            var page=new Page();

            if (item.parms != null) {
                 page = (Page)Activator.CreateInstance(item.TargetType, new object[] { item.parms });
            } else {
                 page = (Page)Activator.CreateInstance(item.TargetType);
            }


            Detail = new NavigationPage(page);
            IsPresented = false;
            FlyoutPage.ListView.SelectedItem = null;

        }
    }
}