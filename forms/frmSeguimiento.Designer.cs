namespace soporte_tecnico.forms
{
    partial class frmSeguimiento
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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            button1 = new Button();
            dgvSeguimiento = new DataGridView();
            cmbEstado = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtComentario = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSeguimiento).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(35, 23);
            lblBuscar.Margin = new Padding(4, 0, 4, 0);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(177, 32);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar pedido: ";
            lblBuscar.Click += label1_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(206, 17);
            txtBuscar.Margin = new Padding(4, 2, 4, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(201, 39);
            txtBuscar.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.LightBlue;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(418, 19);
            button1.Margin = new Padding(4, 2, 4, 2);
            button1.Name = "button1";
            button1.Size = new Size(150, 47);
            button1.TabIndex = 2;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dgvSeguimiento
            // 
            dgvSeguimiento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSeguimiento.Location = new Point(35, 111);
            dgvSeguimiento.Margin = new Padding(4, 2, 4, 2);
            dgvSeguimiento.Name = "dgvSeguimiento";
            dgvSeguimiento.RowHeadersWidth = 82;
            dgvSeguimiento.Size = new Size(1079, 540);
            dgvSeguimiento.TabIndex = 3;
            dgvSeguimiento.CellClick += dgvSeguimiento_CellClick;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(851, 17);
            cmbEstado.Margin = new Padding(4, 2, 4, 2);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(242, 40);
            cmbEstado.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(754, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(96, 32);
            label1.TabIndex = 5;
            label1.Text = "Estado: ";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 683);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(151, 32);
            label2.TabIndex = 6;
            label2.Text = "Comentario: ";
            // 
            // txtComentario
            // 
            txtComentario.Location = new Point(184, 676);
            txtComentario.Margin = new Padding(4, 2, 4, 2);
            txtComentario.Multiline = true;
            txtComentario.Name = "txtComentario";
            txtComentario.Size = new Size(908, 126);
            txtComentario.TabIndex = 7;
            // 
            // button2
            // 
            button2.BackColor = Color.LightBlue;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(661, 1075);
            button2.Margin = new Padding(4, 2, 4, 2);
            button2.Name = "button2";
            button2.Size = new Size(353, 47);
            button2.TabIndex = 8;
            button2.Text = "Guardar Cambios";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // frmSeguimiento
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 838);
            Controls.Add(button2);
            Controls.Add(txtComentario);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbEstado);
            Controls.Add(dgvSeguimiento);
            Controls.Add(button1);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Margin = new Padding(4, 2, 4, 2);
            Name = "frmSeguimiento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSeguimiento";
            Load += frmSeguimiento_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSeguimiento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button button1;
        private DataGridView dgvSeguimiento;
        private ComboBox cmbEstado;
        private Label label1;
        private Label label2;
        private TextBox txtComentario;
        private Button button2;
    }
}