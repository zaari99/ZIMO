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
    public class ADMINLIVREURsController : Controller
    {
        private FORMATIONEntities db = new FORMATIONEntities();

        // GET: ADMINLIVREURs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLivreurs()
        {
            try
            {
                var prod = db.Livreurs.Select(l => new AdminLivreur {IDLivreur=l.IDLivreur,Nom=l.Nom,Prenom=l.Prenom,Longitude=l.Longitude,Laltitude=l.Laltitude,Ville=l.Ville,Dispo=l.Dispo }).ToList();

                return Json(new { success = true, data = prod }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Probleme acces à la base" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: ADMINLIVREURs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livreur livreur = db.Livreurs.Find(id);
            if (livreur == null)
            {
                return HttpNotFound();
            }
            return View(livreur);
        }

        // GET: ADMINLIVREURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMINLIVREURs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLivreur,Nom,Prenom,Longitude,Laltitude,Ville,Dispo")] Livreur livreur)
        {
            if (ModelState.IsValid)
            {
                db.Livreurs.Add(livreur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livreur);
        }

        // GET: ADMINLIVREURs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livreur livreur = db.Livreurs.Find(id);
            if (livreur == null)
            {
                return HttpNotFound();
            }
            return View(livreur);
        }

        // POST: ADMINLIVREURs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLivreur,Nom,Prenom,Longitude,Laltitude,Ville,Dispo")] Livreur livreur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livreur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livreur);
        }

        // GET: ADMINLIVREURs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livreur livreur = db.Livreurs.Find(id);
            if (livreur == null)
            {
                return HttpNotFound();
            }
            return View(livreur);
        }

        // POST: ADMINLIVREURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livreur livreur = db.Livreurs.Find(id);
            db.Livreurs.Remove(livreur);
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
