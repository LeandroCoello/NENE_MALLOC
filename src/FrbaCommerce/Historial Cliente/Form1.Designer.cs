namespace FrbaCommerce.Historial_Cliente
{
    partial class Form1
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
            this.dGVCompras = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCompras = new System.Windows.Forms.Label();
            this.lblOfertas = new System.Windows.Forms.Label();
            this.dGVOfertas = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCalifOtor = new System.Windows.Forms.Label();
            this.lblCalifRecib = new System.Windows.Forms.Label();
            this.dGVCalifOtor = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVCalirRecib = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVOfertas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCalifOtor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCalirRecib)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVCompras
            // 
            this.dGVCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dGVCompras.Location = new System.Drawing.Point(12, 29);
            this.dGVCompras.Name = "dGVCompras";
            this.dGVCompras.Size = new System.Drawing.Size(544, 150);
            this.dGVCompras.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cod. Publicacion";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Desc. Publicacion";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Vendedor";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Precio ";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Fecha de Venta";
            this.Column5.Name = "Column5";
            // 
            // lblCompras
            // 
            this.lblCompras.AutoSize = true;
            this.lblCompras.Location = new System.Drawing.Point(13, 10);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Size = new System.Drawing.Size(51, 13);
            this.lblCompras.TabIndex = 1;
            this.lblCompras.Text = "Compras:";
            // 
            // lblOfertas
            // 
            this.lblOfertas.AutoSize = true;
            this.lblOfertas.Location = new System.Drawing.Point(13, 191);
            this.lblOfertas.Name = "lblOfertas";
            this.lblOfertas.Size = new System.Drawing.Size(44, 13);
            this.lblOfertas.TabIndex = 2;
            this.lblOfertas.Text = "Ofertas:";
            // 
            // dGVOfertas
            // 
            this.dGVOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVOfertas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dGVOfertas.Location = new System.Drawing.Point(16, 208);
            this.dGVOfertas.Name = "dGVOfertas";
            this.dGVOfertas.Size = new System.Drawing.Size(445, 150);
            this.dGVOfertas.TabIndex = 3;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Cod. Publicacion";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Desc. Publicacion";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Monto Ofertado";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Fecha ";
            this.Column9.Name = "Column9";
            // 
            // lblCalifOtor
            // 
            this.lblCalifOtor.AutoSize = true;
            this.lblCalifOtor.Location = new System.Drawing.Point(13, 365);
            this.lblCalifOtor.Name = "lblCalifOtor";
            this.lblCalifOtor.Size = new System.Drawing.Size(127, 13);
            this.lblCalifOtor.TabIndex = 4;
            this.lblCalifOtor.Text = "Calificaciones Otorgadas:";
            // 
            // lblCalifRecib
            // 
            this.lblCalifRecib.AutoSize = true;
            this.lblCalifRecib.Location = new System.Drawing.Point(12, 555);
            this.lblCalifRecib.Name = "lblCalifRecib";
            this.lblCalifRecib.Size = new System.Drawing.Size(125, 13);
            this.lblCalifRecib.TabIndex = 5;
            this.lblCalifRecib.Text = "Calificaciones Recibidas:";
            // 
            // dGVCalifOtor
            // 
            this.dGVCalifOtor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCalifOtor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            this.dGVCalifOtor.Location = new System.Drawing.Point(16, 391);
            this.dGVCalifOtor.Name = "dGVCalifOtor";
            this.dGVCalifOtor.Size = new System.Drawing.Size(445, 150);
            this.dGVCalifOtor.TabIndex = 6;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Cod. Publicacion";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Usuario Calificado";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Descripcion";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Puntaje Otorgado";
            this.Column13.Name = "Column13";
            // 
            // dGVCalirRecib
            // 
            this.dGVCalirRecib.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCalirRecib.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dGVCalirRecib.Location = new System.Drawing.Point(16, 584);
            this.dGVCalirRecib.Name = "dGVCalirRecib";
            this.dGVCalirRecib.Size = new System.Drawing.Size(445, 150);
            this.dGVCalirRecib.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Cod. Publicacion";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Usuario que califico";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Puntaje recibido";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 773);
            this.Controls.Add(this.dGVCalirRecib);
            this.Controls.Add(this.dGVCalifOtor);
            this.Controls.Add(this.lblCalifRecib);
            this.Controls.Add(this.lblCalifOtor);
            this.Controls.Add(this.dGVOfertas);
            this.Controls.Add(this.lblOfertas);
            this.Controls.Add(this.lblCompras);
            this.Controls.Add(this.dGVCompras);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dGVCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVOfertas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCalifOtor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCalirRecib)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.Label lblOfertas;
        private System.Windows.Forms.DataGridView dGVOfertas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Label lblCalifOtor;
        private System.Windows.Forms.Label lblCalifRecib;
        private System.Windows.Forms.DataGridView dGVCalifOtor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridView dGVCalirRecib;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}