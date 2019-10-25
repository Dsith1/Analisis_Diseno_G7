using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Estudios_G7.Tests
{
    interface Interface2
    {
    }
    public interface Respuesta
    {
        void Respuesta(string message);
    }
    public interface Registrarse
    {
        bool IsValid(string usuario, string contraseña, string telefono, string correo, string direccion);
    }
    public class RegistrarsePrueba
    {
        Respuesta _log;
        Registrarse _registro;
        public RegistrarsePrueba(Registrarse correcto, Respuesta respuesta)
        {
            _registro = correcto;
        }


        private void Log(string message)
        {
            if (_log != null)
                _log.Respuesta(message);
        }

        public bool EsCorrecto(string name, string pass, string tel, string corr, string direc)
        {
            if (_registro.IsValid(name, pass, tel, corr, direc))
            {
                Log("Registrado Correctamente");
                return true;
            }
            else
            {
                Log("Error al Registro");
                throw new ArgumentException("No es valido el usuario");
            }
        }
    }
}
