namespace FrbaHotel.Listado_Estadistico
{
    partial class ListEstadistico
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
            this.cBListado = new System.Windows.Forms.ComboBox();
            this.btnLanzarConsulta = new System.Windows.Forms.Button();
            this.btnLimpieza = new System.Windows.Forms.Button();
            this.dGVListEsta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGVListEsta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione su consulta";
            // 
            // cBListado
            // 
            this.cBListado.FormattingEnabled = true;
            this.cBListado.Location = new System.Drawing.Point(12, 25);
            this.cBListado.Name = "cBListado";
            this.cBListado.Size = new System.Drawing.Size(529, 21);
            this.cBListado.TabIndex = 1;
            // 
            // btnLanzarConsulta
            // 
            this.btnLanzarConsulta.Location = new System.Drawing.Point(466, 52);
            this.btnLanzarConsulta.Name = "btnLanzarConsulta";
            this.btnLanzarConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnLanzarConsulta.TabIndex = 2;
            this.btnLanzarConsulta.Text = "Consultar";
            this.btnLanzarConsulta.UseVisualStyleBackColor = true;
            this.btnLanzarConsulta.Click += new System.EventHandler(this.btnLanzarConsulta_Click);
            // 
            // btnLimpieza
            // 
            this.btnLimpieza.Location = new System.Drawing.Point(12, 52);
            this.btnLimpieza.Name = "btnLimpieza";
            this.btnLimpieza.Size = new System.Drawing.Size(75, 23);
            this.btnLimpieza.TabIndex = 3;
            this.btnLimpieza.Text = "Limpiar";
            this.btnLimpieza.UseVisualStyleBackColor = true;
            this.btnLimpieza.Click += new System.EventHandler(this.btnLimpieza_Click);
            // 
            // dGVListEsta
            // 
            this.dGVListEsta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVListEsta.Location = new System.Drawing.Point(15, 81);
            this.dGVListEsta.Name = "dGVListEsta";
            this.dGVListEsta.Size = new System.Drawing.Size(526, 374);
            this.dGVListEsta.TabIndex = 4;
            // 
            // ListEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 467);
            this.Controls.Add(this.dGVListEsta);
            this.Controls.Add(this.btnLimpieza);
            this.Controls.Add(this.btnLanzarConsulta);
            this.Controls.Add(this.cBListado);
            this.Controls.Add(this.label1);
            this.Name = "ListEstadistico";
            this.Text = "Listado Estadistico";
            ((System.ComponentModel.ISupportInitialize)(this.dGVListEsta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBListado;
        private System.Windows.Forms.Button btnLanzarConsulta;
        private System.Windows.Forms.Button btnLimpieza;
        private System.Windows.Forms.DataGridView dGVListEsta;
    }
}