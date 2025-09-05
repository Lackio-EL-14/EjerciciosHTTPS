using System;

namespace EjerciciosHttps.Models
{
    public class MiExcepcion : Exception
    {
        public MiExcepcion(string mensaje) : base(mensaje) { }
    }
}
    