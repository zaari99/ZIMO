using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZIMO.Views.Masterpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPage1Detail : ContentPage
    {
        public FlyoutPage1Detail()
        {
            InitializeComponent();
        }
        public void getproduits()
        {
            String url = $"http://localhost/APIZIMO/api/zimo/getproduits";

            try
            {
                //envoyer une requête HTTP pour récupérer le fichier json  
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json; charset=utf-8";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                    //CONVERTIR le json vers un objet

                    Response R = JsonConvert.DeserializeObject<Response>(reader.ReadToEnd());

                    //l’affichage du résultat

                    resultat.Content = R.price;

                }
            }
            catch (System.Net.WebException x)
            {
                //CONVERTIR le json vers un objet qui contient un attribut error 
                BadResponse BR = JsonConvert.DeserializeObject<BadResponse>(new StreamReader(x.Response.GetResponseStream()).ReadToEnd());

                //Afficher le message d'erreur si on a une WebException
                MessageBox.Show($"erreur :  {BR.error }",
                    x.Message,
                    MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception a)
            {
                //Afficher le message d'erreur (cas generale)
                MessageBox.Show("erreur", a.Message, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
    }
}