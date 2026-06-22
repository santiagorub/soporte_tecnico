using System;
using System.Windows.Forms;
using soporte_tecnico.controllers;
using soporte_tecnico.models;

namespace soporte_tecnico.forms
{
    internal partial class frmPedidos : Form
    {
        private nCliente _controladorCliente;
        private nTecnico _controladorTecnico;
        private nPedido _controladorPedido;

        // Constructor que recibe los controladores de tus compañeros
        internal frmPedidos(nCliente nCli, nTecnico nTec, nPedido nPed)
        {
            InitializeComponent();
            _controladorCliente = nCli;
            _controladorTecnico = nTec;
            _controladorPedido = nPed;

            // Asociamos el evento Load manualmente por seguridad
            this.Load += new EventHandler(frmPedidos_Load);
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            CargarCombos();
            ActualizarGrid();
        }

        private void CargarCombos()
        {
            cmbClientes.DataSource = null;
            cmbClientes.DataSource = _controladorCliente.ObtenerTodos();
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "Id";
            cmbTecnicos.DataSource = null;
            cmbTecnicos.DataSource = _controladorTecnico.ObtenerTodos();
            cmbTecnicos.DisplayMember = "Nombre";
            cmbTecnicos.ValueMember = "Id";
            cmbEstados.DataSource = Enum.GetValues(typeof(Estado));
        }

        private void ActualizarGrid()
        {
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = _controladorPedido.ObtenerTodos();
        }

        private void btnCrearPedido_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem == null || cmbTecnicos.SelectedItem == null || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente clienteSeleccionado = (Cliente)cmbClientes.SelectedItem;
            Tecnico tecnicoSeleccionado = (Tecnico)cmbTecnicos.SelectedItem;
            string descripcion = txtDescripcion.Text;

            _controladorPedido.Agregar(clienteSeleccionado, tecnicoSeleccionado, descripcion);

            txtDescripcion.Clear();
            ActualizarGrid();
            MessageBox.Show("Pedido creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pedido de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PedidoSoporte pedidoSeleccionado = (PedidoSoporte)dgvPedidos.CurrentRow.DataBoundItem;
            Estado nuevoEstado = (Estado)cmbEstados.SelectedItem;

            _controladorPedido.RegistrarSeguimiento(
                pedidoSeleccionado.Id, 
                nuevoEstado,
                "",
                "Sistema"
                );

            ActualizarGrid();
            MessageBox.Show("Estado actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}