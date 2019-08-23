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
    public class TareaController : Controller
    {
        private Sistema_estudiosEntities db = new Sistema_estudiosEntities();

        // GET: Tarea
        public ActionResult TareaIndex()
        {
            var tAREAs = db.TAREAs.Include(t => t.CURSO1);
            return View(tAREAs.ToList());
        }

        // GET: Tarea/Details/5
        public ActionResult TareaDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAREA tAREA = db.TAREAs.Find(id);
            if (tAREA == null)
            {
                return HttpNotFound();
            }
            return View(tAREA);
        }

        // GET: Tarea/Create
        public ActionResult TareaCreate()
        {
            ViewBag.curso = new SelectList(db.CURSOes, "id_curso", "nombre");
            return View();
        }

        // POST: Tarea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TareaCreate([Bind(Include = "id_tarea,Enunciado,Entrega,Ponderacion,curso")] TAREA tAREA)
        {
            if (ModelState.IsValid)
            {
                db.TAREAs.Add(tAREA);
                db.SaveChanges();
                return RedirectToAction("TareaIndex");
            }

            ViewBag.curso = new SelectList(db.CURSOes, "id_curso", "nombre", tAREA.curso);
            return View(tAREA);
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
