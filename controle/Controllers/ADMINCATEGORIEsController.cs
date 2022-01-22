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
    public class ADMINCATEGORIEsController : Controller
    {
        private FORMATIONEntities db = new FORMATIONEntities();

        // GET: CATEGORIEs
        public ActionResult Index()
        {
            return View(db.CATEGORIEs.ToList());
        }


        public ActionResult GetCategories()
        {
            try
            {
                var prod = db.CATEGORIEs.Select(l => new AdminCategorie {CategorieID=l.CategorieID,libelle=l.libelle }).ToList();

                return Json(new { success = true, data = prod }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Probleme acces à la base" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: CATEGORIEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIE cATEGORIE = db.CATEGORIEs.Find(id);
            if (cATEGORIE == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIE);
        }

        // GET: CATEGORIEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATEGORIEs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategorieID,libelle")] CATEGORIE cATEGORIE)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIEs.Add(cATEGORIE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORIE);
        }

        // GET: CATEGORIEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIE cATEGORIE = db.CATEGORIEs.Find(id);
            if (cATEGORIE == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIE);
        }

        // POST: CATEGORIEs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategorieID,libelle")] CATEGORIE cATEGORIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORIE);
        }

        // GET: CATEGORIEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIE cATEGORIE = db.CATEGORIEs.Find(id);
            if (cATEGORIE == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIE);
        }

        // POST: CATEGORIEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORIE cATEGORIE = db.CATEGORIEs.Find(id);
            db.CATEGORIEs.Remove(cATEGORIE);
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
