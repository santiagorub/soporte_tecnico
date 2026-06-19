using soporte_tecnico.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace soporte_tecnico.forms
{
    public partial class frmTecnico : Form
    {
        private nTecnico controlador;
        private int idSeleccionado = -1; //id del tecnico seleccionado en la grilla, -1 significa "ninguno"

        public frmTecnico()
        {
            InitializeComponent();
            controlador = new nTecnico(); //crear el controlador que vamos a usar para agregar/modificar/borrar
            ActualizarGrilla();
        }

        // cuando cambia la seleccion, tomamos el tecnico seleccionado y mostramos sus datos
        private void dgvTecnicos_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvTecnicos.SelectedRows.Count == 0)
            {
                idSeleccionado = -1;
                return;
            }

            var fila = dgvTecnicos.SelectedRows[0];

            // esperamos que la grilla este enlazada a objetos Tecnico
            if (fila.DataBoundItem is soporte_tecnico.models.Tecnico tecnico)
            {
                idSeleccionado = tecnico.Id;
                txtNombre.Text = tecnico.Nombre ?? string.Empty;
                txtEspecialidad.Text = tecnico.Especialidad ?? string.Empty;
                txtEmail.Text = tecnico.Email ?? string.Empty;
            }
            else
            {
                // si por algun motivo no esta enlazada, dejamos id en -1
                idSeleccionado = -1;
            }
        }

        private void ActualizarGrilla()
        {
            //asegurar que el DataGridView genera columnas desde las propiedades del modelo
            dgvTecnicos.AutoGenerateColumns = true;

            //usar BindingList para que el DataSource sea un IList vinculable
            var lista = controlador.ObtenerTodos();
            dgvTecnicos.DataSource = null;
            dgvTecnicos.DataSource = new System.ComponentModel.BindingList<soporte_tecnico.models.Tecnico>(lista);

            dgvTecnicos.ClearSelection();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEspecialidad.Clear();
            txtEmail.Clear();

            idSeleccionado = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" || txtEspecialidad.Text.Trim() == "" || txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            controlador.Agregar(txtNombre.Text, txtEspecialidad.Text, txtEmail.Text);
            ActualizarGrilla();
            LimpiarCampos();

            MessageBox.Show("Técnico agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un técnico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            controlador.Modificar(idSeleccionado, txtNombre.Text, txtEspecialidad.Text, txtEmail.Text);
            ActualizarGrilla();
            LimpiarCampos();

            MessageBox.Show("Técnico modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un técnico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Desea eliminar el técnico seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                controlador.Eliminar(idSeleccionado);

                ActualizarGrilla();
                LimpiarCampos();

                MessageBox.Show("Técnico eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvTecnicos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                //seleccionar la fila completa
                dgvTecnicos.ClearSelection();
                dgvTecnicos.Rows[e.RowIndex].Selected = true;

                DataGridViewRow fila = dgvTecnicos.Rows[e.RowIndex];

                //si la fila esta vinculada a un objeto tecnico, usarlo (mas seguro)
                if (fila.DataBoundItem is soporte_tecnico.models.Tecnico tecnico)
                {
                    idSeleccionado = tecnico.Id;
                    txtNombre.Text = tecnico.Nombre ?? string.Empty;
                    txtEspecialidad.Text = tecnico.Especialidad ?? string.Empty;
                    txtEmail.Text = tecnico.Email ?? string.Empty;
                    return;
                }

                //buscar indice de columna 'Id' de forma segura
                int idColIndex = -1;
                var col = dgvTecnicos.Columns["Id"];
                if (col != null) idColIndex = col.Index;

                object? idVal = null;
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

                //rellenar campos por indices seguros (si existen)
                int nombreIdx = (dgvTecnicos.Columns["Nombre"]?.Index) ?? 1;
                int especialidadIdx = (dgvTecnicos.Columns["Especialidad"]?.Index) ?? 2;
                int emailIdx = (dgvTecnicos.Columns["Email"]?.Index) ?? 3;

                txtNombre.Text = (nombreIdx >= 0 && nombreIdx < fila.Cells.Count) ? fila.Cells[nombreIdx].Value?.ToString() ?? string.Empty : string.Empty;
                txtEspecialidad.Text = (especialidadIdx >= 0 && especialidadIdx < fila.Cells.Count) ? fila.Cells[especialidadIdx].Value?.ToString() ?? string.Empty : string.Empty;
                txtEmail.Text = (emailIdx >= 0 && emailIdx < fila.Cells.Count) ? fila.Cells[emailIdx].Value?.ToString() ?? string.Empty : string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la fila: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTecnicos_Load(object sender, EventArgs e)
        {
            dgvTecnicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTecnicos.MultiSelect = false;
            dgvTecnicos.ReadOnly = true;
            dgvTecnicos.AllowUserToAddRows = false;
        }
    }
}
