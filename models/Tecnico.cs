using System;
using System.Collections.Generic;
using System.Text;

namespace soporte_tecnico.models
{
    internal class Tecnico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Email { get; set; }
        public Tecnico(int id, string nombre, string especialidad, string email)
        {
            Id = id;
            Nombre = nombre;
            Especialidad = especialidad;
            Email = email;
        }
    }
}
