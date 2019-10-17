using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Estudios_G7
{
    public partial class Asignaciones : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public string cadena;

        protected void Page_Load(object sender, EventArgs e)
        {
            cadena = "algo";
        }

        public bool Abrir_conn()
        {
            try
            {
                con = new SqlConnection(cadena);
                con.Open();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}