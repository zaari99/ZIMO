using System;
using System.Collections.Generic;
using System.Text;

namespace ZIMO.Models
{
    class DetailsProduit
    {
        public int ProduitID { get; set; }
        public string Nom { get; set; }
        public double? Prix { get; set; }
        public string libelle { get; set; }
        public string NomFournisseur { get; set; }
        public string Description { get; set; }
    }
}
