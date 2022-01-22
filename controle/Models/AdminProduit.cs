using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace controle.Models
{
    public class AdminProduit
    {
        public int ProduitID { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public Nullable<double> Prix { get; set; }
        public string libelle { get; set; }
        public string NomFournisseur { get; set; }
    }
}
