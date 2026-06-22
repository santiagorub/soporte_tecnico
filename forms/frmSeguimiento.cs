using soporte_tecnico.controllers;
using soporte_tecnico.models;
using System;
using System.Windows.Forms;
using System.Linq;

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
            var pedidosMostrar = gestorPedidos.ObtenerTodos()
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

        private void dgvSeguimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idPedido = Convert.ToInt32(dgvSeguimiento.Rows[e.RowIndex].Cells["Id"].Value);

                pedidoSeleccionado = gestorPedidos.ObtenerTodos()
                    .FirstOrDefault(p => p.Id == idPedido);

                if (pedidoSeleccionado != null)
                {
                    cmbEstado.SelectedItem = pedidoSeleccionado.EstadoActual;
                }
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
            if (!int.TryParse(txtBuscar.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            foreach (DataGridViewRow fila in dgvSeguimiento.Rows)
            {
                if (fila.Cells["Id"].Value != null &&
                    Convert.ToInt32(fila.Cells["Id"].Value) == id)
                {
                    fila.Selected = true;
                    dgvSeguimiento.FirstDisplayedScrollingRowIndex = fila.Index;

                    pedidoSeleccionado = gestorPedidos.ObtenerTodos()
                        .FirstOrDefault(p => p.Id == id);

                    if (pedidoSeleccionado != null)
                    {
                        cmbEstado.SelectedItem = pedidoSeleccionado.EstadoActual;
                    }

                    return;
                }
            }

            MessageBox.Show("No se encontró un pedido con ese ID.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}