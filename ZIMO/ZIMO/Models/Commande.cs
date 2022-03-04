using System;
using System.Collections.Generic;
using System.Text;

namespace ZIMO.Models
{
    class Commande
    {
        public int IDClient { get; set; }
        public string Ville { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Laltitude { get; set; }
        public Nullable<int> CodePostale { get; set; }
        public List<Panier> paniers { get; set; }
    }
}
