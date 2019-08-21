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
    public class ExamenController : Controller
    {
        private Sistema_estudiosEntities db = new Sistema_estudiosEntities();

        // GET: /Examen/
        public ActionResult Index()
        {
            var examen = db.EXAMEN.Include(e => e.CURSO1);
            return View(examen.ToList());
        }

        // GET: /Examen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXAMan examan = db.EXAMEN.Find(id);
            if (examan == null)
            {
                return HttpNotFound();
            }
            return View(examan);
        }

        // GET: /Examen/Create
        public ActionResult Create()
        {
            ViewBag.curso = new SelectList(db.CURSOes, "id_curso", "nombre");
            return View();
        }

        // POST: /Examen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_examen,preguntas,Fecha,minutos,curso")] EXAMan examan)
        {
            if (ModelState.IsValid)
            {
                db.EXAMEN.Add(examan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.curso = new SelectList(db.CURSOes, "id_curso", "nombre", examan.curso);
            return View(examan);
        }

        // GET: /Examen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXAMan examan = db.EXAMEN.Find(id);
            if (examan == null)
            {
                return HttpNotFound();
            }
            ViewBag.curso = new SelectList(db.CURSOes, "id_curso", "nombre", examan.curso);
            return View(examan);
        }

        // POST: /Examen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_examen,preguntas,Fecha,minutos,curso")] EXAMan examan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.curso = new SelectList(db.CURSOes, "id_curso", "nombre", examan.curso);
            return View(examan);
        }

        // GET: /Examen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXAMan examan = db.EXAMEN.Find(id);
            if (examan == null)
            {
                return HttpNotFound();
            }
            return View(examan);
        }

        // POST: /Examen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EXAMan examan = db.EXAMEN.Find(id);
            db.EXAMEN.Remove(examan);
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
