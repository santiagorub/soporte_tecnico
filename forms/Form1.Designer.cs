namespace soporte_tecnico
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button btnClientes;
        private Button btnTecnicos;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnClientes = new Button();
            btnTecnicos = new Button();
            SuspendLayout();
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(30, 30);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(120, 30);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnTecnicos
            // 
            btnTecnicos.Location = new Point(30, 70);
            btnTecnicos.Name = "btnTecnicos";
            btnTecnicos.Size = new Size(120, 30);
            btnTecnicos.TabIndex = 1;
            btnTecnicos.Text = "Técnicos";
            btnTecnicos.UseVisualStyleBackColor = true;
            btnTecnicos.Click += btnTecnicos_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClientes);
            Controls.Add(btnTecnicos);
            Name = "Form1";
            Text = "Soporte Técnico";
            ResumeLayout(false);
        }

        #endregion
    }
}
