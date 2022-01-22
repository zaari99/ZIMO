using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZIMOAPI.Models
{
    public class InfoClient
    {
        public int IDClient { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
    }
}