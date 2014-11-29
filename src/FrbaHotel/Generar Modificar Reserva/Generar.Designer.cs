namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class Generar
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
            this.label6 = new System.Windows.Forms.Label();
            this.cBtiposHabs = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBHoteles = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnConfirmacion = new System.Windows.Forms.Button();
            this.dGVRegimen = new System.Windows.Forms.DataGridView();
            this.inicioDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.finDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVRegimen)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tipo Regimen:";
            // 
            // cBtiposHabs
            // 
            this.cBtiposHabs.FormattingEnabled = true;
            this.cBtiposHabs.Location = new System.Drawing.Point(343, 9);
            this.cBtiposHabs.Name = "cBtiposHabs";
            this.cBtiposHabs.Size = new System.Drawing.Size(204, 21);
            this.cBtiposHabs.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo Habitación:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Hoteles:";
            // 
            // cBHoteles
            // 
            this.cBHoteles.FormattingEnabled = true;
            this.cBHoteles.Location = new System.Drawing.Point(64, 9);
            this.cBHoteles.Name = "cBHoteles";
            this.cBHoteles.Size = new System.Drawing.Size(136, 21);
            this.cBHoteles.TabIndex = 16;
            this.cBHoteles.SelectedIndexChanged += new System.EventHandler(this.cBHoteles_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Fecha inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Fecha fin:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(195, 146);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(75, 23);
            this.btnBusqueda.TabIndex = 21;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(536, 166);
            this.dataGridView1.TabIndex = 22;
            // 
            // btnConfirmacion
            // 
            this.btnConfirmacion.Location = new System.Drawing.Point(195, 391);
            this.btnConfirmacion.Name = "btnConfirmacion";
            this.btnConfirmacion.Size = new System.Drawing.Size(99, 23);
            this.btnConfirmacion.TabIndex = 23;
            this.btnConfirmacion.Text = "Confirmar";
            this.btnConfirmacion.UseVisualStyleBackColor = true;
            // 
            // dGVRegimen
            // 
            this.dGVRegimen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVRegimen.Location = new System.Drawing.Point(272, 61);
            this.dGVRegimen.Name = "dGVRegimen";
            this.dGVRegimen.Size = new System.Drawing.Size(275, 61);
            this.dGVRegimen.TabIndex = 24;
            // 
            // inicioDateTimePicker1
            // 
            this.inicioDateTimePicker1.Location = new System.Drawing.Point(12, 62);
            this.inicioDateTimePicker1.Name = "inicioDateTimePicker1";
            this.inicioDateTimePicker1.Size = new System.Drawing.Size(219, 20);
            this.inicioDateTimePicker1.TabIndex = 25;
            // 
            // finDateTimePicker
            // 
            this.finDateTimePicker.Location = new System.Drawing.Point(15, 101);
            this.finDateTimePicker.Name = "finDateTimePicker";
            this.finDateTimePicker.Size = new System.Drawing.Size(216, 20);
            this.finDateTimePicker.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Habitaciones disponibles:";
            // 
            // Generar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 487);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.finDateTimePicker);
            this.Controls.Add(this.inicioDateTimePicker1);
            this.Controls.Add(this.dGVRegimen);
            this.Controls.Add(this.btnConfirmacion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBHoteles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cBtiposHabs);
            this.Controls.Add(this.label5);
            this.Name = "Generar";
            this.Text = "Generar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVRegimen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cBtiposHabs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBHoteles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnConfirmacion;
        private System.Windows.Forms.DataGridView dGVRegimen;
        private System.Windows.Forms.DateTimePicker inicioDateTimePicker1;
        private System.Windows.Forms.DateTimePicker finDateTimePicker;
        private System.Windows.Forms.Label label4;
    }
}