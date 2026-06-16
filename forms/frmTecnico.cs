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
        private int idSeleccionado = 0;

        public frmTecnico()
        {
            InitializeComponent();

            controlador = new nTecnico();

            ActualizarGrilla();
        }

        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtEspecialidad = new TextBox();
            txtEmail = new TextBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            dgvTecnicos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((ISupportInitialize)dgvTecnicos).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 65);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(194, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Location = new Point(12, 117);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(194, 23);
            txtEspecialidad.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 172);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(194, 23);
            txtEmail.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(207, 338);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(301, 338);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(398, 338);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dgvTecnicos
            // 
            dgvTecnicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTecnicos.Location = new Point(223, 12);
            dgvTecnicos.Name = "dgvTecnicos";
            dgvTecnicos.Size = new Size(443, 295);
            dgvTecnicos.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 47);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 7;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 99);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 8;
            label2.Text = "Especialidad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 154);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 9;
            label3.Text = "Email:";
            // 
            // frmTecnico
            // 
            ClientSize = new Size(678, 373);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvTecnicos);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(txtEmail);
            Controls.Add(txtEspecialidad);
            Controls.Add(txtNombre);
            Name = "frmTecnico";
            ((ISupportInitialize)dgvTecnicos).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private void ActualizarGrilla()
        {
            dgvTecnicos.DataSource = null;
            dgvTecnicos.DataSource = controlador.ObtenerTodos();

            dgvTecnicos.ClearSelection();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEspecialidad.Clear();
            txtEmail.Clear();

            idSeleccionado = 0;
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

        private void btnModificar_Click(Object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
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
            if (idSeleccionado == 0)
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

        private void dgvTecnicos_CellClick(object serder, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvTecnicos.Rows[e.RowIndex];

                idSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);

                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtEspecialidad.Text = fila.Cells["Especialidad"].Value.ToString();
                txtEmail.Text = fila.Cells["Email"].Value.ToString();
            }
        }

        private void frmTecnicos_Load(object sender, EventArgs e)
        {
            dgvTecnicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTecnicos.MultiSelect = false;
            dgvTecnicos.ReadOnly = true;
            dgvTecnicos.AllowUserToAddRows = false;
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
