namespace FrbaHotel.Facturar_Publicaciones
{
    partial class FacturarEstadia
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
            this.cBFormaPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewEsta = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewConsu = new System.Windows.Forms.DataGridView();
            this.btnBuscarConsu = new System.Windows.Forms.Button();
            this.txtClieCod = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpieza = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEsta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forma de pago:";
            // 
            // cBFormaPago
            // 
            this.cBFormaPago.FormattingEnabled = true;
            this.cBFormaPago.Location = new System.Drawing.Point(403, 6);
            this.cBFormaPago.Name = "cBFormaPago";
            this.cBFormaPago.Size = new System.Drawing.Size(121, 21);
            this.cBFormaPago.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Consumibles utilizados:";
            // 
            // dataGridViewEsta
            // 
            this.dataGridViewEsta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEsta.Location = new System.Drawing.Point(15, 53);
            this.dataGridViewEsta.Name = "dataGridViewEsta";
            this.dataGridViewEsta.Size = new System.Drawing.Size(267, 150);
            this.dataGridViewEsta.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estadia:";
            // 
            // dataGridViewConsu
            // 
            this.dataGridViewConsu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsu.Location = new System.Drawing.Point(319, 53);
            this.dataGridViewConsu.Name = "dataGridViewConsu";
            this.dataGridViewConsu.Size = new System.Drawing.Size(250, 150);
            this.dataGridViewConsu.TabIndex = 7;
            // 
            // btnBuscarConsu
            // 
            this.btnBuscarConsu.Location = new System.Drawing.Point(15, 220);
            this.btnBuscarConsu.Name = "btnBuscarConsu";
            this.btnBuscarConsu.Size = new System.Drawing.Size(145, 23);
            this.btnBuscarConsu.TabIndex = 8;
            this.btnBuscarConsu.Text = "Buscar consumibles";
            this.btnBuscarConsu.UseVisualStyleBackColor = true;
            this.btnBuscarConsu.Click += new System.EventHandler(this.btnBuscarConsu_Click);
            // 
            // txtClieCod
            // 
            this.txtClieCod.Location = new System.Drawing.Point(60, 6);
            this.txtClieCod.Name = "txtClieCod";
            this.txtClieCod.Size = new System.Drawing.Size(100, 20);
            this.txtClieCod.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(166, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpieza
            // 
            this.btnLimpieza.Location = new System.Drawing.Point(547, 226);
            this.btnLimpieza.Name = "btnLimpieza";
            this.btnLimpieza.Size = new System.Drawing.Size(75, 23);
            this.btnLimpieza.TabIndex = 11;
            this.btnLimpieza.Text = "Limpiar";
            this.btnLimpieza.UseVisualStyleBackColor = true;
            this.btnLimpieza.Click += new System.EventHandler(this.btnLimpieza_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(15, 249);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 12;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // FacturarEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 309);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnLimpieza);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtClieCod);
            this.Controls.Add(this.btnBuscarConsu);
            this.Controls.Add(this.dataGridViewConsu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewEsta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBFormaPago);
            this.Controls.Add(this.label1);
            this.Name = "FacturarEstadia";
            this.Text = "FacturarPublicaciones";
            this.Load += new System.EventHandler(this.FacturarEstadia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEsta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBFormaPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewEsta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewConsu;
        private System.Windows.Forms.Button btnBuscarConsu;
        private System.Windows.Forms.TextBox txtClieCod;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpieza;
        private System.Windows.Forms.Button btnFacturar;
    }
}