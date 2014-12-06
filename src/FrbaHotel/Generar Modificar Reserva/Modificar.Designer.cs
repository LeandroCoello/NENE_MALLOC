namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class Modificar
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
            this.txtCodReser = new System.Windows.Forms.TextBox();
            this.btnBuscarReserva = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRegimenActual = new System.Windows.Forms.TextBox();
            this.btnCambiarRegimen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnQuitarHab = new System.Windows.Forms.Button();
            this.btnAgregarHab = new System.Windows.Forms.Button();
            this.btnModificarReser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de reserva:";
            // 
            // txtCodReser
            // 
            this.txtCodReser.Location = new System.Drawing.Point(115, 10);
            this.txtCodReser.Name = "txtCodReser";
            this.txtCodReser.Size = new System.Drawing.Size(157, 20);
            this.txtCodReser.TabIndex = 1;
            // 
            // btnBuscarReserva
            // 
            this.btnBuscarReserva.Location = new System.Drawing.Point(278, 8);
            this.btnBuscarReserva.Name = "btnBuscarReserva";
            this.btnBuscarReserva.Size = new System.Drawing.Size(101, 23);
            this.btnBuscarReserva.TabIndex = 2;
            this.btnBuscarReserva.Text = "Buscar";
            this.btnBuscarReserva.UseVisualStyleBackColor = true;
            this.btnBuscarReserva.Click += new System.EventHandler(this.btnBuscarReserva_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(33, 71);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(33, 110);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha fin:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tipo regimen actual";
            // 
            // txtRegimenActual
            // 
            this.txtRegimenActual.Location = new System.Drawing.Point(359, 72);
            this.txtRegimenActual.Name = "txtRegimenActual";
            this.txtRegimenActual.ReadOnly = true;
            this.txtRegimenActual.Size = new System.Drawing.Size(100, 20);
            this.txtRegimenActual.TabIndex = 11;
            // 
            // btnCambiarRegimen
            // 
            this.btnCambiarRegimen.Location = new System.Drawing.Point(474, 70);
            this.btnCambiarRegimen.Name = "btnCambiarRegimen";
            this.btnCambiarRegimen.Size = new System.Drawing.Size(75, 23);
            this.btnCambiarRegimen.TabIndex = 12;
            this.btnCambiarRegimen.Text = "Cambiar";
            this.btnCambiarRegimen.UseVisualStyleBackColor = true;
            this.btnCambiarRegimen.Click += new System.EventHandler(this.btnCambiarRegimen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Habitaciones reservadas";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(874, 185);
            this.dataGridView1.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Habitaciones libres";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 418);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(874, 158);
            this.dataGridView2.TabIndex = 16;
            // 
            // btnQuitarHab
            // 
            this.btnQuitarHab.Location = new System.Drawing.Point(815, 357);
            this.btnQuitarHab.Name = "btnQuitarHab";
            this.btnQuitarHab.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarHab.TabIndex = 17;
            this.btnQuitarHab.Text = "Quitar";
            this.btnQuitarHab.UseVisualStyleBackColor = true;
            this.btnQuitarHab.Click += new System.EventHandler(this.btnQuitarHab_Click);
            // 
            // btnAgregarHab
            // 
            this.btnAgregarHab.Location = new System.Drawing.Point(815, 582);
            this.btnAgregarHab.Name = "btnAgregarHab";
            this.btnAgregarHab.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarHab.TabIndex = 18;
            this.btnAgregarHab.Text = "Agregar";
            this.btnAgregarHab.UseVisualStyleBackColor = true;
            this.btnAgregarHab.Click += new System.EventHandler(this.btnAgregarHab_Click);
            // 
            // btnModificarReser
            // 
            this.btnModificarReser.Location = new System.Drawing.Point(16, 593);
            this.btnModificarReser.Name = "btnModificarReser";
            this.btnModificarReser.Size = new System.Drawing.Size(75, 23);
            this.btnModificarReser.TabIndex = 19;
            this.btnModificarReser.Text = "Modificar";
            this.btnModificarReser.UseVisualStyleBackColor = true;
            this.btnModificarReser.Click += new System.EventHandler(this.btnModificarReser_Click);
            // 
            // Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 628);
            this.Controls.Add(this.btnModificarReser);
            this.Controls.Add(this.btnAgregarHab);
            this.Controls.Add(this.btnQuitarHab);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCambiarRegimen);
            this.Controls.Add(this.txtRegimenActual);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnBuscarReserva);
            this.Controls.Add(this.txtCodReser);
            this.Controls.Add(this.label1);
            this.Name = "Modificar";
            this.Text = "Modificar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodReser;
        private System.Windows.Forms.Button btnBuscarReserva;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRegimenActual;
        private System.Windows.Forms.Button btnCambiarRegimen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnQuitarHab;
        private System.Windows.Forms.Button btnAgregarHab;
        private System.Windows.Forms.Button btnModificarReser;
    }
}