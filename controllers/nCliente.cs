using System;
using System.Collections.Generic;
using System.Text;
using soporte_tecnico.models;

namespace soporte_tecnico.controllers
{
    internal class nCliente
    {
        private List<Cliente> clientes;
        private int proximoId;

        public nCliente()
        {
            clientes = new List<Cliente>();
            proximoId = 1;
        }

        public List<Cliente> ObtenerTodos()
        {
            return clientes;
        }

        public void Agregar(string nombre, string telefono, string email)
        {
            Cliente cliente = new Cliente(proximoId, nombre, telefono, email);
            clientes.Add(cliente);
            proximoId++;
        }

        public void Modificar(int id, string nombre, string telefono, string email)
        {
            Cliente cliente = clientes.Find(c => c.Id == id);

            if (cliente != null)
            {
                cliente.Nombre = nombre;
                cliente.Telefono = telefono;
                cliente.Email = email;
            }
        }

        public void Eliminar(int id)
        {
            Cliente cliente = clientes.Find(c => c.Id == id);

            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }
    }
}
