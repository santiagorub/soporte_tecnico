using System;
using System.Collections.Generic;
using System.Text;
using soporte_tecnico.models;

namespace soporte_tecnico.controllers
{
    internal class nPedido
    {
        private List<PedidoSoporte> pedidos;
        private int proximoId;

        public nPedido()
        {
            pedidos = new List<PedidoSoporte>();
            proximoId = 1;
        }

        public List<PedidoSoporte> ObtenerTodos()
        {
            return pedidos;
        }

        // Al crear, se asigna la fecha de hoy y el estado "Pendiente" por defecto
        public void Agregar(Cliente cliente, Tecnico tecnico, string descripcion)
        {
            PedidoSoporte nuevoPedido = new PedidoSoporte(
                proximoId,
                cliente,
                tecnico,
                descripcion,
                DateTime.Now,
                Estado.Pendiente
            );

            pedidos.Add(nuevoPedido);
            proximoId++;
        }

        // Método específico para cambiar el estado del pedido
        public void CambiarEstado(int idPedido, Estado nuevoEstado)
        {
            PedidoSoporte pedido = pedidos.Find(p => p.Id == idPedido);

            if (pedido != null)
            {
                pedido.EstadoActual = nuevoEstado;
            }
        }
    }
}