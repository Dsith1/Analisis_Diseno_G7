using App_Estudios_G7.Models;
using App_Estudios_G7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_Estudios_G7.Controllers
{
    public class CursoController : Controller
    {
        Sistema_estudiosEntities BD = new Sistema_estudiosEntities();

        public ActionResult CursoIndex()
        {
            List<ListaCursos> listCursos = new List<ListaCursos>();

            try
            {
                using (Sistema_estudiosEntities db = new Sistema_estudiosEntities())
                {
                    listCursos = db.Database.SqlQuery<ListaCursos>("OBTENER_CURSOS").ToList();
                }   
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la lista: ", ex);
            }

            return View(listCursos);
        }

        public ActionResult CrearCurso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCurso(CursoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Sistema_estudiosEntities db = new Sistema_estudiosEntities())
                    {
                        db.Database.ExecuteSqlCommand("INSERTAR_CURSO @name, @autor",
                            new SqlParameter("name", model.nombre),
                            new SqlParameter("autor", model.usuario)
                        );
                    }

                    return Redirect("/Curso/CursoIndex");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ActionResult CursoDetalle(string txtBuscarCurso)
        {
            List<ListaCursos> listCursos = new List<ListaCursos>();

            try
            {
                using (Sistema_estudiosEntities db = new Sistema_estudiosEntities())
                {
                    listCursos = db.Database.SqlQuery<ListaCursos>("BUSCAR_CURSO @name",
                        new SqlParameter("name", txtBuscarCurso)
                        ).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(listCursos);
        }

    }
}