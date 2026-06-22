using System;
using System.Collections.Generic;
using System.Text;

namespace soporte_tecnico.models
{
    public class Comentario
    {
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public string Autor { get; set; }

        public Comentario( DateTime fecha, string texto, string autor )
        {
            Fecha = fecha;
            Texto = texto;
            Autor = autor;
        }
    }
}
