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
    public class ADMINCOMMANDEsController : Controller
    {
        private FORMATIONEntities db = new FORMATIONEntities();

        // GET: ADMINCOMMANDEs
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GetCommandes()
        {
            try
            {
                var prod = db.COMMANDEs.Include(c => c.CLIENT).Include(c => c.Livreur).Select(l => new AdminCommande { Livreur = l.Livreur.Nom, Client = l.CLIENT.Nom, Ville = l.Ville, Longitude = l.Longitude, Laltitude = l.Laltitude, Rue = l.Rue, Status = l.Status ,IDCommande=l.IDCommande,CodePostale=l.CodePostale}).ToList();

                return Json(new { success = true, data = prod }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Probleme acces à la base" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Map(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var c = db.COMMANDEs.Include(l => l.CLIENT).Include(l => l.Livreur).FirstOrDefault(k=>k.IDCommande==id);
            if (c == null)
            {
                return HttpNotFound();
            }
            
            return View("Map");
        }

        // GET: ADMINCOMMANDEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMANDE cOMMANDE = db.COMMANDEs.Find(id);
            if (cOMMANDE == null)
            {
                return HttpNotFound();
            }
            return View(cOMMANDE);
        }

        // GET: ADMINCOMMANDEs/Create
        public ActionResult Create()
        {
            ViewBag.IDClient = new SelectList(db.CLIENTs, "IDClient", "Nom");
            ViewBag.IDLivreur = new SelectList(db.Livreurs, "IDLivreur", "Nom");
            return View();
        }

        // POST: ADMINCOMMANDEs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCommande,IDClient,IDLivreur,Ville,Rue,Longitude,Laltitude,Status,CodePostale")] COMMANDE cOMMANDE)
        {
            if (ModelState.IsValid)
            {
                db.COMMANDEs.Add(cOMMANDE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDClient = new SelectList(db.CLIENTs, "IDClient", "Nom", cOMMANDE.IDClient);
            ViewBag.IDLivreur = new SelectList(db.Livreurs, "IDLivreur", "Nom", cOMMANDE.IDLivreur);
            return View(cOMMANDE);
        }

        // GET: ADMINCOMMANDEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMANDE cOMMANDE = db.COMMANDEs.Find(id);
            if (cOMMANDE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDClient = new SelectList(db.CLIENTs, "IDClient", "Nom", cOMMANDE.IDClient);
            ViewBag.IDLivreur = new SelectList(db.Livreurs, "IDLivreur", "Nom", cOMMANDE.IDLivreur);
            return View(cOMMANDE);
        }

        // POST: ADMINCOMMANDEs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCommande,IDClient,IDLivreur,Ville,Rue,Longitude,Laltitude,Status,CodePostale")] COMMANDE cOMMANDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMMANDE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDClient = new SelectList(db.CLIENTs, "IDClient", "Nom", cOMMANDE.IDClient);
            ViewBag.IDLivreur = new SelectList(db.Livreurs, "IDLivreur", "Nom", cOMMANDE.IDLivreur);
            return View(cOMMANDE);
        }

        // GET: ADMINCOMMANDEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMANDE cOMMANDE = db.COMMANDEs.Find(id);
            if (cOMMANDE == null)
            {
                return HttpNotFound();
            }
            return View(cOMMANDE);
        }

        // POST: ADMINCOMMANDEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMMANDE cOMMANDE = db.COMMANDEs.Find(id);
            db.COMMANDEs.Remove(cOMMANDE);
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
