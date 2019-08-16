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
            con.ConnectionString = "data source=HILBERTPC; database=Sistema_estudios; integrated security = SSPI;";
        }
        [HttpPost]
        public ActionResult Verificar(Cuenta cu)
        {
            conectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from USUARIO where nick='"+cu.Name+"' and contra='"+cu.Password+"' ";
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
    }
}
