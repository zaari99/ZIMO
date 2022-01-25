using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using controle.Models;

namespace controle.Controllers
{
    public class ADMINFOURNISSEURsController : Controller
    {
        private FORMATIONEntities1 db = new FORMATIONEntities1();

        // GET: FOURNISSEURs
        public ActionResult Index()
        {
            return View();
        }

        //get fournisseurs
        public ActionResult GetFournisseurs()
        {
            try
            {
                var prod = db.FOURNISSEURs.Select(f => new Fournisseur { FournisseurId = f.FournisseurId, Nom = f.Nom, Adresse = f.Adresse }).ToList();
                return Json(new { success = true, data = prod }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Probleme acces à la base" }, JsonRequestBehavior.AllowGet);
            }

        }

        // GET: FOURNISSEURs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOURNISSEUR fOURNISSEUR = db.FOURNISSEURs.Find(id);
            if (fOURNISSEUR == null)
            {
                return HttpNotFound();
            }
            return View(fOURNISSEUR);
        }

        // GET: FOURNISSEURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FOURNISSEURs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FournisseurId,Nom,Adresse")] FOURNISSEUR fOURNISSEUR)
        {
            if (ModelState.IsValid)
            {
                db.FOURNISSEURs.Add(fOURNISSEUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fOURNISSEUR);
        }

        // GET: FOURNISSEURs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOURNISSEUR fOURNISSEUR = db.FOURNISSEURs.Find(id);
            if (fOURNISSEUR == null)
            {
                return HttpNotFound();
            }
            return View(fOURNISSEUR);
        }

        // POST: FOURNISSEURs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FournisseurId,Nom,Adresse")] FOURNISSEUR fOURNISSEUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fOURNISSEUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fOURNISSEUR);
        }

        // GET: FOURNISSEURs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOURNISSEUR fOURNISSEUR = db.FOURNISSEURs.Find(id);
            if (fOURNISSEUR == null)
            {
                return HttpNotFound();
            }
            return View(fOURNISSEUR);
        }

        // POST: FOURNISSEURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FOURNISSEUR fOURNISSEUR = db.FOURNISSEURs.Find(id);
            db.FOURNISSEURs.Remove(fOURNISSEUR);
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
