﻿using App_Estudios_G7.Models;
using App_Estudios_G7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_Estudios_G7.Controllers
{
    public class CursoController : Controller
    {
        Sistema_estudiosEntities BD = new Sistema_estudiosEntities();
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        /**
         * Metodo que da una lista al view para desplegar todos los cursos, unicamente visible para el admin
         */
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


        /*
         * Solo me retorna el view para crear un curso
         */
        public ActionResult CrearCurso()
        {
            ViewBag.creador = new SelectList(BD.USUARIOs, "id_usuario", "nick");
            return View();
        }

        /**
         * Metodo que tiene como objetivo ya realizar la operacion
         * sobre la bd para crear un curso
         */
        [HttpPost]
        public ActionResult CrearCurso(CURSO model)
        {
            string rol = Session["Rol"].ToString();// variable seteada en el login
            if(rol != null && rol.Equals("Maestro") == false)
                return Redirect("/Curso/CursoIndex");

            try
            {
                if (ModelState.IsValid)
                {
                    using (Sistema_estudiosEntities db = new Sistema_estudiosEntities())
                    {
                        db.Database.ExecuteSqlCommand("INSERTAR_CURSO @name, @autor",
                            new SqlParameter("name", model.nombre),
                            new SqlParameter("autor", model.creador)
                        );
                    }
                    return Redirect("/Curso/CursoIndex");
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            ViewBag.creador = new SelectList(BD.USUARIOs, "id_usuario", "nick", model.creador);
            return View(model);
        }

        //METODO PARA PRUEBA DE BDD
        //autor: ID DEL USUARIO
        public string PruebaCrearCurso(string nombre, int autor)
        {
            string query = "INSERT INTO curso(nombre,creador)" +
                            " values('" + nombre + "', '" + autor + "');";
            try
            {
                conectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = query;
                dr = com.ExecuteReader();

                Console.WriteLine("Curso Creado Exitosamente");
                //ViewBag.Consulta = "Usuario ingresado exitosamente.";
                con.Close();
                return "Correcto";
                                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Curso Erroneo");
                return "Incorrecto";
            }

            //return "Correcto";
        }

        /**
         * Busca un curso y me regresa todas sus cualidades
         */
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



        //Controlador que me retorna la vista de todos los cursos del usuario
        public ActionResult MisCursos(/*int id_usuario*/) {
            //Antes que regresar tengo que hacer una revision del rol del usuario, tiene que ser profesor

            //Pendiente hasta el siguiente sprint

            //Buscoi la lista de todos los cursos
            List<ListaCursos> listCursos = new List<ListaCursos>();

            //por ahora voy a usar un raw query para trabajar, no es el metodo mas seguro
            string query = "Select c.id_curso, c.nombre from Curso c where c.creador = 1;"; //cambiar el 1 por el id_usuario cuando se integre esa parte
            try
            {
                using (Sistema_estudiosEntities db = new Sistema_estudiosEntities())
                {
                    listCursos = db.Database.SqlQuery<ListaCursos>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la lista: ", ex);
            }

            return View(listCursos);
        }

        /*
         * Controlador que me retorna el detalle del contenido de un curso, busco cada cosa con el id que mando
         */
         public ActionResult ContenidoCurso(int id)
        {
            //listas de examenes, tareas, actividades (Ubicacion: Models/ViewModels )
            List<ListaExamen> listaExamen = new List<ListaExamen>();
            List<ListaTareas> listaTareas = new List<ListaTareas>();
            List<ListaActividad> listaActividades = new List<ListaActividad>();

            //querys para llenar las listas
            string query_examen =   "Select id_examen, preguntas, fecha, minutos from EXAMEN Where curso =  "
                                    + id
                                    + ";";

            string query_tarea =    "Select id_tarea, enunciado, entrega from TAREA Where curso = "
                                    + id
                                    + ";";

            string query_actividad =    "Select id_Actividad, tipo, id_evento from ACTIVIDAD Where curso = "
                                        + id
                                        + ";";

            try
            {
                using (Sistema_estudiosEntities db = new Sistema_estudiosEntities())
                {
                    listaExamen = db.Database.SqlQuery<ListaExamen>(query_examen).ToList();
                    listaTareas = db.Database.SqlQuery<ListaTareas>(query_tarea).ToList();
                    listaActividades = db.Database.SqlQuery<ListaActividad>(query_actividad).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la lista: ", ex);
            }

            //viewbag es una list de parametros que se le pasa a la vista
            ViewBag.examenes = listaExamen;
            ViewBag.tareas = listaTareas;
            ViewBag.actividades = listaActividades;

            //y ahora mando el view
            return View();
        }

        /**
         * Controlador de creacion de examen
         */
         public ActionResult CrearExamen()
        {
            return View();
        }

        //Acciones cuando se sube la plantilla de crear examen
        [HttpPost]
        public ActionResult CrearExamen(ExamenViewModel examen)
        {
            return View();
        }

        /*
         * Controlador de creacion de tarea
         */
         public ActionResult CrearTarea()
        {
            return View();
        }

        /*
         * Controlador de creacion de actividad
         */
         public ActionResult CrearActividad()
        {
            return View();
        }
        void conectionString()
        {
            con.ConnectionString = "data source=SERGIO\\SERGIO; database=Sistema_estudios; integrated security = true;";
        }

    }
}