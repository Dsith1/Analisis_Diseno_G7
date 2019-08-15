using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using App_Estudios_G7.Models;

namespace App_Estudios_G7.Controllers
{
    public class CURSOesController : Controller
    {
        private Sistema_estudiosEntities db = new Sistema_estudiosEntities();

        // GET: CURSOes
        public ActionResult Index()
        {
            var cURSOes = db.CURSOes.Include(c => c.USUARIO);
            return View(cURSOes.ToList());
        }

        // GET: CURSOes Al Publico
        public ActionResult IndexG()
        {
            var cURSOes = db.CURSOes.Include(c => c.USUARIO);
            return View(cURSOes.ToList());
        }

        // GET: CURSOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSO cURSO = db.CURSOes.Find(id);
            if (cURSO == null)
            {
                return HttpNotFound();
            }
            return View(cURSO);
        }

        // GET: CURSOes/Details/5 Detalles generales
        public ActionResult DetailsG(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSO cURSO = db.CURSOes.Find(id);
            if (cURSO == null)
            {
                return HttpNotFound();
            }
            return View(cURSO);
        }

        // GET: CURSOes/Create
        public ActionResult Create()
        {
            ViewBag.creador = new SelectList(db.USUARIOs, "id_usuario", "nick");
            return View();
        }

        // POST: CURSOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_curso,nombre,creador")] CURSO cURSO)
        {
            if (ModelState.IsValid)
            {
                db.CURSOes.Add(cURSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.creador = new SelectList(db.USUARIOs, "id_usuario", "nick", cURSO.creador);
            return View(cURSO);
        }

        // GET: CURSOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSO cURSO = db.CURSOes.Find(id);
            if (cURSO == null)
            {
                return HttpNotFound();
            }
            ViewBag.creador = new SelectList(db.USUARIOs, "id_usuario", "nick", cURSO.creador);
            return View(cURSO);
        }

        // POST: CURSOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_curso,nombre,creador")] CURSO cURSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cURSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.creador = new SelectList(db.USUARIOs, "id_usuario", "nick", cURSO.creador);
            return View(cURSO);
        }

        // GET: CURSOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSO cURSO = db.CURSOes.Find(id);
            if (cURSO == null)
            {
                return HttpNotFound();
            }
            return View(cURSO);
        }

        // POST: CURSOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CURSO cURSO = db.CURSOes.Find(id);
            db.CURSOes.Remove(cURSO);
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
