using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Estudios_G7.Tests
{
    interface Interface1
    {

    }

    public interface ILog
    {
        void Log(string message);
    }
    public interface Sesion
    {
        bool IsValid(string usuario, string contraseña);
    }
    public class BlogService
    {
        ILog _log;
        Sesion _sesion;
        public BlogService(Sesion correcto, ILog respuesta)
        {
            _sesion = correcto;
        }


        private void Log(string message)
        {
            if (_log != null)
                _log.Log(message);
        }

        public bool EsCorrecto(string name, string pass)
        {
            if (_sesion.IsValid(name, pass))
            {
                Log("Usuario Correcto");
                return true;
            }
            else
            {
                Log("No existe el Usuario");
                throw new ArgumentException("No es valido el usuario");
            }
        }
    }
}
