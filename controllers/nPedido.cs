using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; // Importante para usar LINQ en los reportes más adelante
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

            // Al crearse el pedido, podemos registrar su primer estado en el historial
            nuevoPedido.HistorialEstados.Add(new HistorialEstado(DateTime.Now, "Ninguno", Estado.Pendiente.ToString()));

            pedidos.Add(nuevoPedido);
            proximoId++;
        }

        // 🔄 MÉTODO MODIFICADO: Ahora registra el historial y comentarios
        public void RegistrarSeguimiento(int idPedido, Estado nuevoEstado, string comentarioTexto, string autor)
        {
            PedidoSoporte pedido = pedidos.Find(p => p.Id == idPedido);

            if (pedido != null)
            {
                // 1. Si el estado cambia, guardamos el historial
                if (pedido.EstadoActual != nuevoEstado)
                {
                    string estadoAnterior = pedido.EstadoActual.ToString();
                    pedido.EstadoActual = nuevoEstado;

                    pedido.HistorialEstados.Add(new HistorialEstado(DateTime.Now, estadoAnterior, nuevoEstado.ToString()));

                    // 2. Si pasa a ser 'Resuelto', registramos la fecha de fin
                    if (nuevoEstado == Estado.Resuelto)
                    {
                        pedido.FechaResolucion = DateTime.Now;
                    }
                    else
                    {
                        pedido.FechaResolucion = null; // Por si vuelven a abrir un pedido resuelto
                    }
                }

                // 3. Si el usuario escribió un comentario, lo agregamos
                if (!string.IsNullOrWhiteSpace(comentarioTexto))
                {
                    pedido.Comentarios.Add(new Comentario(DateTime.Now, comentarioTexto, autor));
                }
            }
        }
    }
}