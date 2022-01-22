using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace controle.Models
{
    public class AdminLivreur
    {
        public int IDLivreur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public double? Longitude { get; set; }
        public double? Laltitude { get; set; }
        public string Ville { get; set; }
        public string Dispo { get; set; }
    }
}