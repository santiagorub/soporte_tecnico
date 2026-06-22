using System;
using System.Collections.Generic;
using System.Text;

namespace soporte_tecnico.models
{
    internal class PedidoSoporte
    {
        public int Id { get; set; }
        public Cliente ClienteAsignado { get; set; }
        public Tecnico TecnicoAsignado { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Estado EstadoActual { get; set; }

        public List<Comentario> Comentarios { get; set; }
        public List<HistorialEstado> HistorialEstados { get; set; }
        public DateTime? FechaResolucion { get; set; } // Puede ser null hasta que se resuelva
        public PedidoSoporte(int id, Cliente cliente, Tecnico tecnico, string descripcion, DateTime fechaIngreso, Estado estado)
        {
            Id = id;
            ClienteAsignado = cliente;
            TecnicoAsignado = tecnico;
            Descripcion = descripcion;
            FechaIngreso = fechaIngreso;
            EstadoActual = estado;
        }
    }
}