using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZIMOAPI.Models;
namespace ZIMOAPI.Controllers
{
    public class ZIMOController : ApiController
    {
        private FORMATIONEntities db = new FORMATIONEntities();

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


    }
}
