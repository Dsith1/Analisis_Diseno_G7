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
            con.ConnectionString = "data source=SERGIO\\SERGIO; database=Sistema_estudios; integrated security = true;";
        }
        [HttpPost]
        public ActionResult Verificar(Cuenta cu)
        {
            if (cu.Rol.Equals("Administrador"))
            {
                conectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "select * from USUARIO where nick='" + cu.Name + "' and contra='" + cu.Password + "' and rol ='" + cu.Rol + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    Session["Rol"] = "Administrador";
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
                    Session["Rol"] = "Estudiante";
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
                    Session["Rol"] = "Maestro";
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

        //Accion del boton al registrarse
        [HttpPost]
        public ActionResult Registrarse(USUARIO usu)
        {
            string query = "INSERT INTO usuario(nick,contra,nombre_1,nombre_2,apellido_1,apellido_2, edad,correo,rol)" +
                            " values('" + usu.nick + "', '" + usu.contra + "', '" + usu.nombre_1 + "', '" + usu.nombre_2 + "'," +
                            " '" + usu.apellido_1 + "', '" + usu.apellido_2 + "', " + usu.edad + ", '" + usu.correo + "', '" + usu.rol + "');";
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
            //ViewBag.Message = "Verificar registro";
            string query = "SELECT * FROM USUARIO WHERE nick = '" + nick + "' ;";
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
                return false;
                throw new Exception("Error al insertar el usuario: ", ex);
            }

        }

        //METODO PARA REALIZAR PRUEBAS
        public bool PruebaRegistrarse(string nick, string contra, string nombre_1, string nombre_2, string apellido_1, string apellido_2, string edad, string correo, string rol)
        {
            string query = "INSERT INTO usuario(nick,contra,nombre_1,nombre_2,apellido_1,apellido_2, edad,correo,rol)" +
                            " values('" + nick + "', '" + contra + "', '" + nombre_1 + "', '" + nombre_2 + "'," +
                            " '" + apellido_1 + "', '" + apellido_2 + "', " + edad + ", '" + correo + "', '" + rol + "');";
            bool respuesta = false;
            try
            {
                if (!VerificarRegistro(nick))
                {
                    
                    conectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = query;
                    dr = com.ExecuteReader();

                    Console.WriteLine("Usuario ingresado Exitosamente");
                    //ViewBag.Consulta = "Usuario ingresado exitosamente.";

                    con.Close();
                    respuesta= true;
                }

                else
                { //ViewBag.Consulta = "El nickname ya existe";
                    Console.WriteLine("El nickname ya existe");
                    respuesta= false;
                }
            }
            catch (Exception ex)
            {
                respuesta= false;
            }

            return respuesta;
        }

        //PRUEBA INICIAR SESION
        public string PruebaInicarSesion(string usuario, string contraseña, string rol)
        {
            if (rol.Equals("Administrador"))
            {
                string query = "select * from USUARIO where nick='" + usuario + "' and contra='" + contraseña + "' and rol ='" + rol + "'";
                try
                {
                    conectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = query;
                    dr = com.ExecuteReader();

                    Console.WriteLine("Inicio de Sesion Exitosamente");
                    //ViewBag.Consulta = "Usuario ingresado exitosamente.";
                    con.Close();
                    return "Correcto";

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Inicio de Sesion Erroneo");
                    return "Incorrecto";
                }
            }
            else if (rol.Equals("Maestro"))
            {
                string query = "select * from USUARIO where nick='" + usuario + "' and contra='" + contraseña + "' and rol ='" + rol + "'";
                try
                {
                    conectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = query;
                    dr = com.ExecuteReader();

                    Console.WriteLine("Inicio de Sesion Exitosamente");
                    //ViewBag.Consulta = "Usuario ingresado exitosamente.";
                    con.Close();
                    return "Correcto";

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Inicio de Sesion Erroneo");
                    return "Incorrecto";
                }
            }
            else if (rol.Equals("Estudiante"))
            {
                string query = "select * from USUARIO where nick='" + usuario + "' and contra='" + contraseña + "' and rol ='" + rol + "'";
                try
                {
                    conectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = query;
                    dr = com.ExecuteReader();

                    Console.WriteLine("Inicio de Sesion Exitosamente");
                    //ViewBag.Consulta = "Usuario ingresado exitosamente.";
                    con.Close();
                    return "Correcto";

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Inicio de Sesion Erroneo");
                    return "Incorrecto";
                }
            }
            else {
                return "Incorrecto";
            }
           
        }
    }
}
