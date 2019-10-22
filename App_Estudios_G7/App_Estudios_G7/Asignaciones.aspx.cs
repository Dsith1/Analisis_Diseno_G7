using System;
using System.Collections.Generic;
using System.Data;
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

        public bool Verificar_curso(int curso)
        {

            string resultado="";
            try
            {
                Abrir_conn();

                cmd = new SqlCommand("BUSCAR_CURSO_INDIVIDUAL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@curso ", curso);
                SqlDataReader lector = cmd.ExecuteReader();
                

                while (lector.Read())
                {
                    resultado = lector["id_curso"].ToString();
                }

                if (resultado.Equals(curso.ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }catch(Exception ex)
            {
                return false;
            }

        }
    }
}