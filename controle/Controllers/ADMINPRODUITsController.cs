using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using controle;
using controle.Models;

namespace controle.Controllers
{
    public class ADMINPRODUITsController : Controller
    {
        private FORMATIONEntities db = new FORMATIONEntities();

        // GET: ADMINPRODUITs
        public ActionResult Index()
        {  
            return View();
        }

        //Get JSON
        public ActionResult GetProduits()
        {


            try
            {
                var prod = db.PRODUITs.Include(p => p.CATEGORIE).Include(p => p.FOURNISSEUR).Select(p => new AdminProduit {ProduitID=p.ProduitID,Nom=p.Nom ,Prix=p.Prix,Description=p.Description,libelle=p.CATEGORIE.libelle,NomFournisseur= p.FOURNISSEUR.Nom }).ToList();

                return Json(new { success = true, data = prod }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Probleme acces à la base" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: ADMINPRODUITs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT pRODUIT = db.PRODUITs.Find(id);
            if (pRODUIT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUIT);
        }

        // GET: ADMINPRODUITs/Create
        public ActionResult Create()
        {
            ViewBag.CategorieID = new SelectList(db.CATEGORIEs, "CategorieID", "libelle");
            ViewBag.FornisseurID = new SelectList(db.FOURNISSEURs, "FournisseurId", "Nom");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProduitID,Nom,Description,Prix,FornisseurID,CategorieID")] PRODUIT pRODUIT)
        {
            if (ModelState.IsValid)
            {
                db.PRODUITs.Add(pRODUIT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieID = new SelectList(db.CATEGORIEs, "CategorieID", "libelle", pRODUIT.CategorieID);
            ViewBag.FornisseurID = new SelectList(db.FOURNISSEURs, "FournisseurId", "Nom", pRODUIT.FornisseurID);
            return View(pRODUIT);
        }

        // GET: ADMINPRODUITs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT pRODUIT = db.PRODUITs.Find(id);
            if (pRODUIT == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieID = new SelectList(db.CATEGORIEs, "CategorieID", "libelle", pRODUIT.CategorieID);
            ViewBag.FornisseurID = new SelectList(db.FOURNISSEURs, "FournisseurId", "Nom", pRODUIT.FornisseurID);
            return View(pRODUIT);
        }

        // POST: ADMINPRODUITs/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProduitID,Nom,Description,Prix,FornisseurID,CategorieID")] PRODUIT pRODUIT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUIT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieID = new SelectList(db.CATEGORIEs, "CategorieID", "libelle", pRODUIT.CategorieID);
            ViewBag.FornisseurID = new SelectList(db.FOURNISSEURs, "FournisseurId", "Nom", pRODUIT.FornisseurID);
            return View(pRODUIT);
        }

        // GET: ADMINPRODUITs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT pRODUIT = db.PRODUITs.Find(id);
            if (pRODUIT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUIT);
        }

        // POST: ADMINPRODUITs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUIT pRODUIT = db.PRODUITs.Find(id);
            db.PRODUITs.Remove(pRODUIT);
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
