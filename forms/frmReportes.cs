using soporte_tecnico.controllers;
using soporte_tecnico.models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace soporte_tecnico.forms
{
    public partial class frmReportes : Form
    {
        private nPedido gestorPedidos;
        public frmReportes(nPedido controladorPedido)
        {
            InitializeComponent();
            // marcar por defecto el botón 'Todos' como seleccionado visualmente
            gestorPedidos = controladorPedido;
        }

        private void SetEstadoSeleccionado(Button seleccionado)
        {
            // lista de botones de estado
            var estados = new[] { btnPendientes, btnEnProceso, btnResueltos, btnTodos };
            foreach (var b in estados)
            {
                if (b == seleccionado)
                {
                    b.BackColor = Color.LightBlue; // seleccionado
                }
                else
                {
                    b.BackColor = Color.LightCyan; // no seleccionado
                }
            }
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            SetEstadoSeleccionado(btnPendientes);
            MostrarPedidos(gestorPedidos.ObtenerTodos().Where(p => p.EstadoActual == Estado.Pendiente));
        }

        private void btnEnProceso_Click(object sender, EventArgs e)
        {
            SetEstadoSeleccionado(btnEnProceso);
            MostrarPedidos(gestorPedidos.ObtenerTodos().Where(p => p.EstadoActual == Estado.EnProgreso));
        }

        private void btnResueltos_Click(object sender, EventArgs e)
        {
            SetEstadoSeleccionado(btnResueltos);
            MostrarPedidos(gestorPedidos.ObtenerTodos().Where(p => p.EstadoActual == Estado.Resuelto));
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            SetEstadoSeleccionado(btnTodos);
            MostrarPedidos(gestorPedidos.ObtenerTodos());
        }

        private void MostrarPedidos(IEnumerable<PedidoSoporte> pedidos)
        {
            var pedidosMostrar = pedidos
                .Select(p => new
                {
                    p.Id,
                    Cliente = p.ClienteAsignado.Nombre,
                    Tecnico = p.TecnicoAsignado.Nombre,
                    p.Descripcion,
                    FechaIngreso = p.FechaIngreso.ToString("dd/MM/yyyy HH:mm"),
                    Estado = p.EstadoActual.ToString()
                })
                .ToList();

            dgvSeguimiento.DataSource = null;
            dgvSeguimiento.DataSource = pedidosMostrar;

            dgvSeguimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSeguimiento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSeguimiento.MultiSelect = false;
            dgvSeguimiento.ReadOnly = true;
            dgvSeguimiento.AllowUserToAddRows = false;
        }
    }
}
