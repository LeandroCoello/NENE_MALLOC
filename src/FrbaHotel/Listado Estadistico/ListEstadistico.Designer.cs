﻿namespace FrbaHotel.Listado_Estadistico
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
            this.label2 = new System.Windows.Forms.Label();
            this.cBanios = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMINI = new System.Windows.Forms.TextBox();
            this.txtMFIN = new System.Windows.Forms.TextBox();
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
            this.cBListado.Location = new System.Drawing.Point(15, 68);
            this.cBListado.Name = "cBListado";
            this.cBListado.Size = new System.Drawing.Size(529, 21);
            this.cBListado.TabIndex = 1;
            // 
            // btnLanzarConsulta
            // 
            this.btnLanzarConsulta.Location = new System.Drawing.Point(463, 133);
            this.btnLanzarConsulta.Name = "btnLanzarConsulta";
            this.btnLanzarConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnLanzarConsulta.TabIndex = 2;
            this.btnLanzarConsulta.Text = "Consultar";
            this.btnLanzarConsulta.UseVisualStyleBackColor = true;
            this.btnLanzarConsulta.Click += new System.EventHandler(this.btnLanzarConsulta_Click);
            // 
            // btnLimpieza
            // 
            this.btnLimpieza.Location = new System.Drawing.Point(12, 133);
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
            this.dGVListEsta.Location = new System.Drawing.Point(12, 162);
            this.dGVListEsta.Name = "dGVListEsta";
            this.dGVListEsta.Size = new System.Drawing.Size(526, 374);
            this.dGVListEsta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Año:";
            // 
            // cBanios
            // 
            this.cBanios.FormattingEnabled = true;
            this.cBanios.Location = new System.Drawing.Point(47, 30);
            this.cBanios.Name = "cBanios";
            this.cBanios.Size = new System.Drawing.Size(82, 21);
            this.cBanios.TabIndex = 6;
            this.cBanios.SelectedIndexChanged += new System.EventHandler(this.cBanios_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mes Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mes Fin:";
            // 
            // txtMINI
            // 
            this.txtMINI.Enabled = false;
            this.txtMINI.Location = new System.Drawing.Point(226, 30);
            this.txtMINI.Name = "txtMINI";
            this.txtMINI.Size = new System.Drawing.Size(86, 20);
            this.txtMINI.TabIndex = 9;
            // 
            // txtMFIN
            // 
            this.txtMFIN.Enabled = false;
            this.txtMFIN.Location = new System.Drawing.Point(389, 30);
            this.txtMFIN.Name = "txtMFIN";
            this.txtMFIN.Size = new System.Drawing.Size(100, 20);
            this.txtMFIN.TabIndex = 10;
            // 
            // ListEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 548);
            this.Controls.Add(this.txtMFIN);
            this.Controls.Add(this.txtMINI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBanios);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBanios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMINI;
        private System.Windows.Forms.TextBox txtMFIN;
    }
}