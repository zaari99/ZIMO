using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace controle.Models
{
    public class AdminClient
    {
        public int IDClient { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Pass { get; set; }
    }
}