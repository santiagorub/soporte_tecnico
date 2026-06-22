using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using soporte_tecnico.models;

namespace soporte_tecnico.controllers
{
    public class nPedido
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

            nuevoPedido.HistorialEstados.Add(new HistorialEstado(DateTime.Now, "Ninguno", Estado.Pendiente.ToString(), cliente.Nombre));

            pedidos.Add(nuevoPedido);
            proximoId++;
        }

        public void CambiarEstado(int idPedido, Estado nuevoEstado, string autor)
        {
            RegistrarSeguimiento(idPedido, nuevoEstado, string.Empty, autor);
        }

        public void RegistrarSeguimiento(int idPedido, Estado nuevoEstado, string comentarioTexto, string autor)
        {
            PedidoSoporte pedido = pedidos.Find(p => p.Id == idPedido);

            if (pedido != null)
            {

                if (pedido.EstadoActual != nuevoEstado)
                {
                    string estadoAnterior = pedido.EstadoActual.ToString();
                    pedido.EstadoActual = nuevoEstado;
                    pedido.HistorialEstados.Add(new HistorialEstado(DateTime.Now, estadoAnterior, nuevoEstado.ToString(), autor));
                    if (nuevoEstado == Estado.Resuelto)
                    {
                        pedido.FechaResolucion = DateTime.Now;
                    }
                    else
                    {
                        pedido.FechaResolucion = null;
                    }
                }


                if (!string.IsNullOrWhiteSpace(comentarioTexto))
                {
                    pedido.Comentarios.Add(new Comentario(DateTime.Now, comentarioTexto, autor));
                }
            }
        }
    }
}