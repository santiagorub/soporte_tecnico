using System;
using System.Collections.Generic;
using System.Text;

namespace soporte_tecnico.models
{
    public class HistorialEstado
    {
        public DateTime Fecha { get; set; }
        public string EstadoAnterior { get; set; }
        public string EstadoNuevo { get; set; }
        public string Autor { get; set; }
        public HistorialEstado(DateTime fecha, string estadoAnterior, string estadoNuevo, string autor)
        {
            Fecha = fecha;
            EstadoAnterior = estadoAnterior;
            EstadoNuevo = estadoNuevo;
            Autor = autor;
        }
    }

}