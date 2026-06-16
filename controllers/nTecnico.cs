using System;
using System.Collections.Generic;
using System.Text;
using soporte_tecnico.models;

namespace soporte_tecnico.controllers
{
    internal class nTecnico
    {
        private List<Tecnico> tecnicos;
        private int proximoId;
        
        public nTecnico()
        {
            tecnicos = new List<Tecnico>();
            proximoId = 1;
        }

        public List<Tecnico> ObtenerTodos()
        {
            return tecnicos;
        }

        public void Agregar(string nombre, string especialidad, string email)
        {
            Tecnico tecnico = new Tecnico(proximoId, nombre, especialidad, email);
            tecnicos.Add(tecnico);
            proximoId++;
        }

        public void Modificar(int id, string nombre, string especialidad, string email)
        {
            Tecnico tecnico = tecnicos.Find(t => t.Id == id);

            if(tecnico != null)
            {
                tecnico.Nombre = nombre;
                tecnico.Especialidad = especialidad;
                tecnico.Email = email;
            }
        }

        public void Eliminar(int id)
        {
            Tecnico tecnico = tecnicos.Find(t => t.Id == id);

            if(tecnico != null)
            {
                tecnicos.Remove(tecnico);
            }
        }
    }
}
