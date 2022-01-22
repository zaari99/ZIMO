using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace controle.Models
{
    public class AdminCommande
    {
        public int IDCommande { get; set; }
        public string Client { get; set; }
        public string Livreur { get; set; }
        public string Ville { get; set; }
        public string Rue { get; set; }
        public double? Longitude { get; set; }
        public double? Laltitude { get; set; }
        public string Status { get; set; }
        public int? CodePostale { get; set; }
    }
}