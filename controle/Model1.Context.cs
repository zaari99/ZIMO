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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FORMATIONEntities1 : DbContext
    {
        public FORMATIONEntities1()
            : base("name=FORMATIONEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CATEGORIE> CATEGORIEs { get; set; }
        public virtual DbSet<CLIENT> CLIENTs { get; set; }
        public virtual DbSet<COMMANDE> COMMANDEs { get; set; }
        public virtual DbSet<COULEUR> COULEURs { get; set; }
        public virtual DbSet<FOURNISSEUR> FOURNISSEURs { get; set; }
        public virtual DbSet<Livreur> Livreurs { get; set; }
        public virtual DbSet<PRODUIT> PRODUITs { get; set; }
        public virtual DbSet<PRODUIT_COMMANDE> PRODUIT_COMMANDE { get; set; }
    }
}
