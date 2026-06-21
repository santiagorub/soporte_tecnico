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
                MessageBox.Show("El nombre es obligatorio.");
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
            try
            {
                if (e.RowIndex < 0)
                    return;

                // seleccionar la fila completa
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;

                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                // si la fila esta vinculada a un objeto Cliente, usarlo (más seguro)
                if (fila.DataBoundItem is soporte_tecnico.models.Cliente cliente)
                {
                    idSeleccionado = cliente.Id;
                    txtNombre.Text = cliente.Nombre ?? string.Empty;
                    txtTelefono.Text = cliente.Telefono ?? string.Empty;
                    txtEmail.Text = cliente.Email ?? string.Empty;
                    return;
                }

                // buscar indice de columna 'Id' de forma segura
                int idColIndex = -1;
                var col = dataGridView1.Columns["Id"];
                if (col != null) idColIndex = col.Index;

                object idVal = null;
                if (idColIndex >= 0 && idColIndex < fila.Cells.Count)
                    idVal = fila.Cells[idColIndex].Value;
                else if (fila.Cells.Count > 0)
                    idVal = fila.Cells[0].Value;

                if (idVal == null || idVal == DBNull.Value)
                {
                    idSeleccionado = -1;
                    return;
                }

                idSeleccionado = Convert.ToInt32(idVal);

                // rellenar campos por indices seguros (si existen)
                int nombreIdx = (dataGridView1.Columns["Nombre"]?.Index) ?? 1;
                int telefonoIdx = (dataGridView1.Columns["Telefono"]?.Index) ?? 2;
                int emailIdx = (dataGridView1.Columns["Email"]?.Index) ?? 3;

                txtNombre.Text = (nombreIdx >= 0 && nombreIdx < fila.Cells.Count) ? fila.Cells[nombreIdx].Value?.ToString() ?? string.Empty : string.Empty;
                txtTelefono.Text = (telefonoIdx >= 0 && telefonoIdx < fila.Cells.Count) ? fila.Cells[telefonoIdx].Value?.ToString() ?? string.Empty : string.Empty;
                txtEmail.Text = (emailIdx >= 0 && emailIdx < fila.Cells.Count) ? fila.Cells[emailIdx].Value?.ToString() ?? string.Empty : string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la fila: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
