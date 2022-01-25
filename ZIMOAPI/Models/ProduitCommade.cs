using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZIMOAPI.Models
{
    public class ProduitCommade
    {
        public int IDCommande { get; set; }
        public int IDProduit { get; set; }
        public int? Qte { get; set; }
    }
}