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

        private void button3_Click(object sender, EventArgs e) //es el botodn de eliminar 
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

        private void button2_Click(object sender, EventArgs e) //boton de modificar 
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // valida qu el clic sea en al fila
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                // pasamos los datos de la fila seleccionada a los TextBox y guardamos el ID
                idSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtEmail.Text = fila.Cells["Email"].Value.ToString();
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
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = controladorCliente.ObtenerTodos();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
