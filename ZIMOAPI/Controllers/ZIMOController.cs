using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;
using ZIMOAPI.Models;
namespace ZIMOAPI.Controllers
{
    public class ZIMOController : ApiController
    {
        private FORMATIONEntities3 db = new FORMATIONEntities3();

        // GET: api/zimo/GetInfoClient?Mail=...
        [HttpGet]
        public InfoClient GetInfoClient(string Mail)
        {
            if (Mail == null)
            {
                return null;
                //return NotFound();
            }
            var res = db.CLIENTs.FirstOrDefault(c => c.Mail == Mail);
            InfoClient infoclient = new InfoClient();
            infoclient.IDClient = res.IDClient;
            infoclient.Mail = Mail;
            infoclient.Nom = res.Nom;
            infoclient.Prenom = res.Prenom;
            return infoclient;
        }

        //###############################################################
        //post: api/ZIMO/AddClient
        [HttpPost]
        public void AddClient(Client client)// webapp  va  transformer string en un objet aut
        {



            if (ModelState.IsValid)
            {
                CLIENT clientdb = new CLIENT() { Mail = client.Mail, Nom = client.Nom, Prenom = client.Prenom, Pass = client.Pass };
                db.CLIENTs.Add(clientdb);
                db.SaveChanges();

            }
        }
        //###############################################################
        //get: api/ZIMO/GetProduits
        [HttpGet]
        public List<Produit> GetProduits()
        {   //.Include(p => p.CATEGORIE).Include(p => p.FOURNISSEUR)
            var res = db.PRODUITs.Select(p => new Produit { ProduitID = p.ProduitID, Nom = p.Nom, Prix = p.Prix, libelle = p.CATEGORIE.libelle, NomFournisseur = p.FOURNISSEUR.Nom }).ToList();
            return res;
        }
        //###############################################################


        //###############################################################
        // localhost/APIZIMO/Api/zimo/AddProduitCommande
        [HttpPost]
        public bool AddProduitCommande(ProduitCommade produitCommade)
        {

            var pRODUIT = db.PRODUITs.Find(produitCommade.IDProduit);
            var cOMMANDE = db.COMMANDEs.FirstOrDefault(c => c.IDClient == produitCommade.IDCommande);
            if (pRODUIT!=null&&cOMMANDE!=null){
                PRODUIT_COMMANDE res = new PRODUIT_COMMANDE();
                res.IDCommande = produitCommade.IDCommande;
                res.IDProduit = produitCommade.IDProduit;
                res.Qte = produitCommade.Qte;
                db.PRODUIT_COMMANDE.Add(res);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
           
        }
        //###############################################################
        // localhost/APIZIMO/Api/zimo/GetProduitsCommandes
        [HttpGet]
        public List<ProduitCommade> GetProduitsCommandes()
        {


            return db.PRODUIT_COMMANDE.Select(pc => new ProduitCommade { Qte = pc.Qte, IDCommande = pc.IDCommande, IDProduit = pc.IDProduit }).ToList();
        }
        //###############################################################
        // localhost/APIZIMO/Api/zimo/GetCommandes
        [HttpGet]
        public List<Commande1> GetCommandes()
        {   //Include(c => c.CLIENT).Include(c => c.Livreur).
            List<Commande1> comm = new List<Commande1>();
              comm =  db.COMMANDEs.Select(l => new Commande1 { Livreur = l.Livreur.Nom, Client = l.CLIENT.Nom, Ville = l.Ville, Longitude = l.Longitude, Laltitude = l.Laltitude, Rue = l.Rue, Status = l.Status, IDCommande = l.IDCommande, CodePostale = l.CodePostale }).ToList();
            return comm;
        }

        //#########################################
        //get: api/ZIMO/GetDetailsProduit?id=
        [HttpGet]
        public DetailProduit GetDetailsProduit(int? id)
        {   //.Include(p => p.CATEGORIE).Include(p => p.FOURNISSEUR)
            //if (id == null)
            //{
            //    return null;
            //}
            PRODUIT pRODUIT = db.PRODUITs.Find(id);
            //if (pRODUIT == null)
            //{
            //    return null;
            //}
            DetailProduit detail = new DetailProduit();
            detail.Description = pRODUIT.Description;
            detail.ProduitID = pRODUIT.ProduitID;
            detail.Nom = pRODUIT.Nom;
            detail.Prix = pRODUIT.Prix;
            detail.libelle = pRODUIT.CATEGORIE.libelle;
            detail.NomFournisseur = pRODUIT.FOURNISSEUR.Nom;

            return detail;
        }


    }
}
