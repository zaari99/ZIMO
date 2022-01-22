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
    public class ADMINCOULEURsController : Controller
    {
        private FORMATIONEntities db = new FORMATIONEntities();

        // GET: ADMINCOULEURs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCouleurs()
        {
            try
            {
                var prod = db.COULEURs.Select(c => new AdminCouleur { CouleurID=c.CouleurID,Nom=c.Nom}).ToList();

                return Json(new { success = true, data = prod }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Probleme acces à la base" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: ADMINCOULEURs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COULEUR cOULEUR = db.COULEURs.Find(id);
            if (cOULEUR == null)
            {
                return HttpNotFound();
            }
            return View(cOULEUR);
        }

        // GET: ADMINCOULEURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMINCOULEURs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CouleurID,Nom")] COULEUR cOULEUR)
        {
            if (ModelState.IsValid)
            {
                db.COULEURs.Add(cOULEUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOULEUR);
        }

        // GET: ADMINCOULEURs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COULEUR cOULEUR = db.COULEURs.Find(id);
            if (cOULEUR == null)
            {
                return HttpNotFound();
            }
            return View(cOULEUR);
        }

        // POST: ADMINCOULEURs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CouleurID,Nom")] COULEUR cOULEUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOULEUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOULEUR);
        }

        // GET: ADMINCOULEURs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COULEUR cOULEUR = db.COULEURs.Find(id);
            if (cOULEUR == null)
            {
                return HttpNotFound();
            }
            return View(cOULEUR);
        }

        // POST: ADMINCOULEURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COULEUR cOULEUR = db.COULEURs.Find(id);
            db.COULEURs.Remove(cOULEUR);
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
