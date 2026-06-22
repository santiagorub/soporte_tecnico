using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using soporte_tecnico.controllers;

namespace soporte_tecnico.forms
{
    public partial class frmCliente : Form
    {
        private nCliente controladorCliente = new nCliente();
        private int idSeleccionado = -1; //para saber si hay fila seleccionada a la cual vamos a eliminar o midificar 
        public frmCliente()
        {
            InitializeComponent();
            // configurar comportamiento del DataGridView para seleccionar filas completas
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            ActualizarGrid(); //para que mustre si hay datos para arrancar
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //el boton de agregar 
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("El Telefono es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("El Email es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            controladorCliente.Agregar(txtNombre.Text, txtTelefono.Text, txtEmail.Text);
            ActualizarGrid();
            LimpiarFormulario();

        }

        private void button3_Click(object sender, EventArgs e) //el boton de eliminar 
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista para eliminar.");
                return;
            }

            controladorCliente.Eliminar(idSeleccionado);
            ActualizarGrid();
            LimpiarFormulario();
        }

        private void button2_Click(object sender, EventArgs e) //el boton de modificar 
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista para modificar.");
                return;
            }

            controladorCliente.Modificar(idSeleccionado, txtNombre.Text, txtTelefono.Text, txtEmail.Text);
            ActualizarGrid();
            LimpiarFormulario();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        {

            // Valida que el clic sea en una fila válida y no en el encabezado

            if (e.RowIndex >= 0)

            {

                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];



                // Cambiado: Leemos el objeto Cliente directamente de la fila de forma segura

                if (fila.DataBoundItem is soporte_tecnico.models.Cliente cliente)

                {

                    idSeleccionado = cliente.Id;

                    txtNombre.Text = cliente.Nombre ?? string.Empty;

                    txtTelefono.Text = cliente.Telefono ?? string.Empty;

                    txtEmail.Text = cliente.Email ?? string.Empty;

                }

                else

                {

                    // Alternativa por si las columnas se crearon manualmente sin DataBoundItem

                    idSeleccionado = Convert.ToInt32(fila.Cells[0].Value);

                    txtNombre.Text = fila.Cells[1].Value?.ToString() ?? string.Empty;

                    txtTelefono.Text = fila.Cells[2].Value?.ToString() ?? string.Empty;

                    txtEmail.Text = fila.Cells[3].Value?.ToString() ?? string.Empty;

                }

            }

        }
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            idSeleccionado = -1; // rastremos por el id seleccionardo 
        }

        private void ActualizarGrid()
        {
            // asegurar que el DataGridView genera columnas desde las propiedades del modelo
            dataGridView1.AutoGenerateColumns = true;

            var lista = controladorCliente.ObtenerTodos();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new System.ComponentModel.BindingList<soporte_tecnico.models.Cliente>(lista);

            dataGridView1.ClearSelection();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
