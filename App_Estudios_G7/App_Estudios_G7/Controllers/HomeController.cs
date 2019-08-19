using App_Estudios_G7.Models;
using App_Estudios_G7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace App_Estudios_G7.Controllers
{
    public class HomeController : Controller
    {
        Sistema_estudiosEntities BD = new Sistema_estudiosEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sitio Para el control de Cursos";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



    }
}