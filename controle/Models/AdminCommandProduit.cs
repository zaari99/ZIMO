using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace controle.Models
{
    public class AdminCommandProduit
    {
        public int IDCommande { get; set; }

        public string Commande { get; set; }

        public string produit { get; set; }

        public int IDProduit { get; set; }
        public Nullable<int> Qte { get; set; }
    }
}