using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App_Estudios_G7.Models;
using System.Data.SqlClient;

namespace App_Estudios_G7.Controllers
{
    public class CuentaController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Cuenta
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void conectionString()
        {
            con.ConnectionString = "data source=DESKTOP-K27HD4T\\SQLEXPRESS; database=Sistema_estudios; integrated security = true;";
        }
        [HttpPost]
        public ActionResult Verificar(Cuenta cu)
        {
            if(cu.Rol.Equals("Administrador"))
            {
                conectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "select * from USUARIO where nick='" + cu.Name + "' and contra='" + cu.Password + "' and rol ='" + cu.Rol + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    return RedirectToAction("CrearCurso", "Curso");
                }

                else
                {
                    con.Close();
                    return View("Error");
                }
            }
            else if (cu.Rol.Equals("Estudiante"))
            {
                conectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "select * from USUARIO where nick='" + cu.Name + "' and contra='" + cu.Password + "' and rol ='" + cu.Rol + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    con.Close();
                    return View("Error");
                }
            }
            else if (cu.Rol.Equals("Maestro"))
            {
                conectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "select * from USUARIO where nick='" + cu.Name + "' and contra='" + cu.Password + "' and rol ='" + cu.Rol + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    con.Close();
                    return View("Error");
                }
            }
            return View();
            
        }

        public ActionResult Registrarse()
        {
            ViewBag.Message = "Registrate :D";

            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(USUARIO usu)
        {
            ViewBag.Message = "Registrate :D";
            string query = "INSERT INTO usuario(nick,contra,nombre_1,nombre_2,apellido_1,apellido_2, edad,correo)" + 
                            " values('"+usu.nick+"', '"+usu.contra+"', '"+usu.nombre_1+"', '"+usu.nombre_2+"'," +
                            " '" + usu.apellido_1 + "', '" + usu.apellido_2+"', "+usu.edad+", '"+usu.correo+"');";
            try
            {
                if (!VerificarRegistro(usu.nick))
                {
                    conectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = query;
                    dr = com.ExecuteReader();
                    
                    ViewBag.Consulta = "Usuario ingresado exitosamente.";

                    con.Close();
                }
                else ViewBag.Consulta = "El nickname ya existe";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el usuario: ", ex);
            }

            return View();
        }


        public bool VerificarRegistro(string nick)
        {
            ViewBag.Message = "Verificar registro";
            string query = "SELECT * FROM USUARIO WHERE nick = '"+ nick +"' ;";
            try
            {
                conectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = query;
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    return true;
                }

                else
                {
                    con.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el usuario: ", ex);
            }

        }
    }
}
