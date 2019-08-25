using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
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

        // pagina principal donde estan todas las tareas que el usuario ha creado
        // GET: Tarea
        public ActionResult TareaIndex()
        {
            var tAREAs = db.TAREAs.Include(t => t.CURSO1);
            return View(tAREAs.ToList());
        }

        // pagina qye muestra el detalle actual de la tarea que se selecione
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

        // metodo get donde muestra la pagina inicial para crear la tarea
        // GET: Tarea/Create
        public ActionResult TareaCreate()
        {
            ViewBag.curso = new SelectList(db.CURSOes, "id_curso", "nombre");
            return View();
        }

        // metodo que guarda la tarea que se ha creado cuando se pulsa el boton crear en el formulario
        // POST: Tarea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TareaCreate([Bind(Include = "id_tarea,Enunciado,Entrega,Ponderacion,curso")] TAREA tAREA)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Sistema_estudiosEntities db = new Sistema_estudiosEntities())
                    {
                        db.Database.ExecuteSqlCommand("INSERTAR_TAREA @enunciado,@entrega,@curso,@ponderacion",
                            new SqlParameter("@enunciado", tAREA.Enunciado),
                            new SqlParameter("@entrega", tAREA.Entrega),
                            new SqlParameter("@curso", tAREA.curso),
                            new SqlParameter("@ponderacion", tAREA.ponderacion)
                        );
                    }

                    return RedirectToAction("TareaIndex");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            ViewBag.curso = new SelectList(db.CURSOes, "id_curso", "nombre", tAREA.curso);
            return View(tAREA);
        }


        // metodo get de la pagina inicial al cargar la tarea
        public ActionResult CargarTarea(int? id)
        {
            Session["Usuario"] = 2;// solo para pruebas
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

        // metodo que carga el archivo de la tarea al servidor y guarda el usuario logueado y nombre de archivo
        // en la tabla tarea_usuario
        [HttpPost]
        public ActionResult CargarTarea(HttpPostedFileBase fileTarea, int? id)
        {
            CargaArchivo modeloArchivo = new CargaArchivo();
            if (fileTarea != null)
            {
                var id_usuario = Session["Usuario"];
                try
                {
                    if (id_usuario != null && id != null)
                    {
                        using (Sistema_estudiosEntities db = new Sistema_estudiosEntities())
                        {
                            db.Database.ExecuteSqlCommand("INSERTAR_NOTA_TAREA @estudiante,@tarea",
                                new SqlParameter("@estudiante", int.Parse(id_usuario.ToString())),
                                new SqlParameter("@tarea", id)
                            );
                        }

                        string ruta = CrearCarpetaTarea(id);
                        ruta += fileTarea.FileName;
                        modeloArchivo.subirArchivo(ruta, fileTarea);
                        ViewBag.Error = modeloArchivo.Error;
                        ViewBag.Confirmacion = modeloArchivo.Confirmacion;
                    }

                }
                catch
                {
                    ViewBag.Error = "La tarea ya fue entregada";
                }

            }
            else { ViewBag.Error = "No se ha cargado ningun archivo"; }

            if(id != null)
            {
                TAREA tAREA = db.TAREAs.Find(id);
                if (tAREA != null) { return View(tAREA); }
            }

            return RedirectToAction("CargarTarea");
        }

        private string CrearCarpetaTarea(int? id)
        {
            string path = Server.MapPath("~/Temp/");

            try
            {
                TAREA Tar = db.TAREAs.Find(id);
                USUARIO Usu = db.USUARIOs.Find(Session["Usuario"]);

                path += Tar.CURSO1.nombre + "/" + Usu.nick;
           
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
                path += "/";

                return path;
            }
            catch
            {
                return Server.MapPath("~/Temp/");
            }

        }

        // metodo que se crea automaticamente al crear la vista
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
