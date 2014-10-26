namespace FrbaHotel.ABM_de_Rol
{
    partial class ListadoRol
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpieza = new System.Windows.Forms.Button();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.txtNomRol = new System.Windows.Forms.TextBox();
            this.cBEstadoRol = new System.Windows.Forms.ComboBox();
            this.cBFuncionalidades = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Rol:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estado Rol:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Funcionalidad:";
            // 
            // btnLimpieza
            // 
            this.btnLimpieza.Location = new System.Drawing.Point(15, 71);
            this.btnLimpieza.Name = "btnLimpieza";
            this.btnLimpieza.Size = new System.Drawing.Size(75, 23);
            this.btnLimpieza.TabIndex = 3;
            this.btnLimpieza.Text = "Limpieza";
            this.btnLimpieza.UseVisualStyleBackColor = true;
            this.btnLimpieza.Click += new System.EventHandler(this.btnLimpieza_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(319, 71);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(75, 23);
            this.btnBusqueda.TabIndex = 4;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtNomRol
            // 
            this.txtNomRol.Location = new System.Drawing.Point(84, 6);
            this.txtNomRol.Name = "txtNomRol";
            this.txtNomRol.Size = new System.Drawing.Size(100, 20);
            this.txtNomRol.TabIndex = 5;
            // 
            // cBEstadoRol
            // 
            this.cBEstadoRol.FormattingEnabled = true;
            this.cBEstadoRol.Location = new System.Drawing.Point(84, 37);
            this.cBEstadoRol.Name = "cBEstadoRol";
            this.cBEstadoRol.Size = new System.Drawing.Size(100, 21);
            this.cBEstadoRol.TabIndex = 6;
            // 
            // cBFuncionalidades
            // 
            this.cBFuncionalidades.FormattingEnabled = true;
            this.cBFuncionalidades.Location = new System.Drawing.Point(294, 6);
            this.cBFuncionalidades.Name = "cBFuncionalidades";
            this.cBFuncionalidades.Size = new System.Drawing.Size(100, 21);
            this.cBFuncionalidades.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(446, 192);
            this.dataGridView1.TabIndex = 8;
            // 
            // ListadoRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 304);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cBFuncionalidades);
            this.Controls.Add(this.cBEstadoRol);
            this.Controls.Add(this.txtNomRol);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnLimpieza);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ListadoRol";
            this.Text = "ListadoRol";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimpieza;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.TextBox txtNomRol;
        private System.Windows.Forms.ComboBox cBEstadoRol;
        private System.Windows.Forms.ComboBox cBFuncionalidades;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}