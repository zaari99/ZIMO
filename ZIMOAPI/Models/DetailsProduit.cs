using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZIMOAPI.Models
{
    public class DetailProduit
    {
        public int ProduitID { get; set; }
        public string Nom { get; set; }
        public double? Prix { get; set; }
        public string libelle { get; set; }
        public string NomFournisseur { get; set; }
        public string Description { get; set; }
    }
}