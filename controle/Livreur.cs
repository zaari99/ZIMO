//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace controle
{
    using System;
    using System.Collections.Generic;
    
    public partial class Livreur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Livreur()
        {
            this.COMMANDEs = new HashSet<COMMANDE>();
        }
    
        public int IDLivreur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Laltitude { get; set; }
        public string Ville { get; set; }
        public string Dispo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMANDE> COMMANDEs { get; set; }
    }
}
