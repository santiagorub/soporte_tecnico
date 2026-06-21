namespace soporte_tecnico.forms
{
    partial class frmPedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbClientes = new ComboBox();
            label1 = new Label();
            cmbTecnicos = new ComboBox();
            label2 = new Label();
            cmbEstados = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            txtDescripcion = new TextBox();
            dgvPedidos = new DataGridView();
            btnCambiarEstado = new Button();
            btnCrearPedido = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            SuspendLayout();
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(12, 30);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(335, 23);
            cmbClientes.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Cliente:";
            // 
            // cmbTecnicos
            // 
            cmbTecnicos.FormattingEnabled = true;
            cmbTecnicos.Location = new Point(12, 85);
            cmbTecnicos.Name = "cmbTecnicos";
            cmbTecnicos.Size = new Size(335, 23);
            cmbTecnicos.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 3;
            label2.Text = "Técnico Asignado:";
            // 
            // cmbEstados
            // 
            cmbEstados.FormattingEnabled = true;
            cmbEstados.Location = new Point(12, 373);
            cmbEstados.Name = "cmbEstados";
            cmbEstados.Size = new Size(335, 23);
            cmbEstados.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 355);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 5;
            label3.Text = "Estado del Pedido:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 125);
            label4.Name = "label4";
            label4.Size = new Size(145, 15);
            label4.TabIndex = 6;
            label4.Text = "Descripción del Problema:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(12, 143);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(335, 196);
            txtDescripcion.TabIndex = 7;
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(371, 30);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.Size = new Size(417, 366);
            dgvPedidos.TabIndex = 8;
            dgvPedidos.CellContentClick += dgvPedidos_CellContentClick;
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.Location = new Point(371, 415);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(198, 23);
            btnCambiarEstado.TabIndex = 9;
            btnCambiarEstado.Text = "Cambiar Estado";
            btnCambiarEstado.UseVisualStyleBackColor = true;
            btnCambiarEstado.Click += btnCambiarEstado_Click;
            // 
            // btnCrearPedido
            // 
            btnCrearPedido.Location = new Point(590, 415);
            btnCrearPedido.Name = "btnCrearPedido";
            btnCrearPedido.Size = new Size(198, 23);
            btnCrearPedido.TabIndex = 10;
            btnCrearPedido.Text = "Crear Pedido";
            btnCrearPedido.UseVisualStyleBackColor = true;
            btnCrearPedido.Click += btnCrearPedido_Click;
            // 
            // frmPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCrearPedido);
            Controls.Add(btnCambiarEstado);
            Controls.Add(dgvPedidos);
            Controls.Add(txtDescripcion);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbEstados);
            Controls.Add(label2);
            Controls.Add(cmbTecnicos);
            Controls.Add(label1);
            Controls.Add(cmbClientes);
            Name = "frmPedidos";
            Text = "frmPedidos";
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbClientes;
        private Label label1;
        private ComboBox cmbTecnicos;
        private Label label2;
        private ComboBox cmbEstados;
        private Label label3;
        private Label label4;
        private TextBox txtDescripcion;
        private DataGridView dgvPedidos;
        private Button btnCambiarEstado;
        private Button btnCrearPedido;
    }
}