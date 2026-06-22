using soporte_tecnico.controllers;
using soporte_tecnico.models;
using System;
using System.Windows.Forms;

namespace soporte_tecnico.forms
{
    internal partial class frmSeguimiento : Form
    {
        private nPedido gestorPedidos;
        private PedidoSoporte? pedidoSeleccionado;

        internal frmSeguimiento(nPedido controladorPedido)
        {
            InitializeComponent();
            gestorPedidos = controladorPedido;
        }

        private void frmSeguimiento_Load(object sender, EventArgs e)
        {
            cmbEstado.DataSource = Enum.GetValues(typeof(Estado));
            CargarPedidos();
        }

        private void CargarPedidos()
        {
            dgvSeguimiento.DataSource = null;
            dgvSeguimiento.DataSource = gestorPedidos.ObtenerTodos();

            dgvSeguimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSeguimiento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSeguimiento.MultiSelect = false;
            dgvSeguimiento.ReadOnly = true;
            dgvSeguimiento.AllowUserToAddRows = false;
        }

        private void dgvSeguimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                pedidoSeleccionado =
                    (PedidoSoporte)dgvSeguimiento.Rows[e.RowIndex].DataBoundItem;

                cmbEstado.SelectedItem = pedidoSeleccionado.EstadoActual;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pedidoSeleccionado != null)
            {
                Estado nuevoEstado = (Estado)cmbEstado.SelectedItem;

                gestorPedidos.RegistrarSeguimiento(
                    pedidoSeleccionado.Id,
                    nuevoEstado,
                    txtComentario.Text,
                    "Administrador"
                );

                CargarPedidos();
                txtComentario.Clear();

                MessageBox.Show("Seguimiento registrado exitosamente.");
            }
            else
            {
                MessageBox.Show("Seleccione un pedido.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;

            if (int.TryParse(txtBuscar.Text, out id))
            {
                foreach (DataGridViewRow fila in dgvSeguimiento.Rows)
                {
                    if (fila.DataBoundItem != null)
                    {
                        PedidoSoporte pedido =
                            (PedidoSoporte)fila.DataBoundItem;

                        if (pedido.Id == id)
                        {
                            fila.Selected = true;
                            dgvSeguimiento.FirstDisplayedScrollingRowIndex = fila.Index;

                            pedidoSeleccionado = pedido;
                            cmbEstado.SelectedItem = pedido.EstadoActual;

                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}