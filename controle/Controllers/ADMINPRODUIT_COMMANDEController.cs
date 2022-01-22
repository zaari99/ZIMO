using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using controle;

namespace controle.Controllers
{
    public class ADMINPRODUIT_COMMANDEController : Controller
    {
        private FORMATIONEntities db = new FORMATIONEntities();

        // GET: ADMINPRODUIT_COMMANDE
        public ActionResult Index()
        {
            var pRODUIT_COMMANDE = db.PRODUIT_COMMANDE.Include(p => p.COMMANDE).Include(p => p.PRODUIT);
            return View(pRODUIT_COMMANDE.ToList());
        }

        // GET: ADMINPRODUIT_COMMANDE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT_COMMANDE pRODUIT_COMMANDE = db.PRODUIT_COMMANDE.Find(id);
            if (pRODUIT_COMMANDE == null)
            {
                return HttpNotFound();
            }
            return View(pRODUIT_COMMANDE);
        }
       

        // GET: ADMINPRODUIT_COMMANDE/Create
        public ActionResult Create()
        {
            ViewBag.IDCommande = new SelectList(db.COMMANDEs, "IDCommande", "Ville");
            ViewBag.IDProduit = new SelectList(db.PRODUITs, "ProduitID", "Nom");
            return View();
        }

        // POST: ADMINPRODUIT_COMMANDE/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCommande,IDProduit,Qte")] PRODUIT_COMMANDE pRODUIT_COMMANDE)
        {
            if (ModelState.IsValid)
            {
                db.PRODUIT_COMMANDE.Add(pRODUIT_COMMANDE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCommande = new SelectList(db.COMMANDEs, "IDCommande", "Ville", pRODUIT_COMMANDE.IDCommande);
            ViewBag.IDProduit = new SelectList(db.PRODUITs, "ProduitID", "Nom", pRODUIT_COMMANDE.IDProduit);
            return View(pRODUIT_COMMANDE);
        }

        // GET: ADMINPRODUIT_COMMANDE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT_COMMANDE pRODUIT_COMMANDE = db.PRODUIT_COMMANDE.Find(id);
            if (pRODUIT_COMMANDE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCommande = new SelectList(db.COMMANDEs, "IDCommande", "Ville", pRODUIT_COMMANDE.IDCommande);
            ViewBag.IDProduit = new SelectList(db.PRODUITs, "ProduitID", "Nom", pRODUIT_COMMANDE.IDProduit);
            return View(pRODUIT_COMMANDE);
        }

        // POST: ADMINPRODUIT_COMMANDE/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCommande,IDProduit,Qte")] PRODUIT_COMMANDE pRODUIT_COMMANDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUIT_COMMANDE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCommande = new SelectList(db.COMMANDEs, "IDCommande", "Ville", pRODUIT_COMMANDE.IDCommande);
            ViewBag.IDProduit = new SelectList(db.PRODUITs, "ProduitID", "Nom", pRODUIT_COMMANDE.IDProduit);
            return View(pRODUIT_COMMANDE);
        }

        // GET: ADMINPRODUIT_COMMANDE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT_COMMANDE pRODUIT_COMMANDE = db.PRODUIT_COMMANDE.Find(id);
            if (pRODUIT_COMMANDE == null)
            {
                return HttpNotFound();
            }
            return View(pRODUIT_COMMANDE);
        }

        // POST: ADMINPRODUIT_COMMANDE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUIT_COMMANDE pRODUIT_COMMANDE = db.PRODUIT_COMMANDE.Find(id);
            db.PRODUIT_COMMANDE.Remove(pRODUIT_COMMANDE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
