namespace FrbaHotel.ABM_de_Habitacion
{
    partial class HabitacionAlta
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cBTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.txtNroHabi = new System.Windows.Forms.TextBox();
            this.txtPisoHotel = new System.Windows.Forms.TextBox();
            this.txtConVista = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHotel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro Habitación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Piso en el hotel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ubicación(con vista):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo Habitación:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Descripción:";
            // 
            // cBTipoHabitacion
            // 
            this.cBTipoHabitacion.FormattingEnabled = true;
            this.cBTipoHabitacion.Location = new System.Drawing.Point(127, 73);
            this.cBTipoHabitacion.Name = "cBTipoHabitacion";
            this.cBTipoHabitacion.Size = new System.Drawing.Size(121, 21);
            this.cBTipoHabitacion.TabIndex = 5;
            // 
            // txtNroHabi
            // 
            this.txtNroHabi.Location = new System.Drawing.Point(127, 6);
            this.txtNroHabi.Name = "txtNroHabi";
            this.txtNroHabi.Size = new System.Drawing.Size(121, 20);
            this.txtNroHabi.TabIndex = 6;
            // 
            // txtPisoHotel
            // 
            this.txtPisoHotel.Location = new System.Drawing.Point(127, 28);
            this.txtPisoHotel.Name = "txtPisoHotel";
            this.txtPisoHotel.Size = new System.Drawing.Size(121, 20);
            this.txtPisoHotel.TabIndex = 7;
            // 
            // txtConVista
            // 
            this.txtConVista.Location = new System.Drawing.Point(127, 51);
            this.txtConVista.Name = "txtConVista";
            this.txtConVista.Size = new System.Drawing.Size(121, 20);
            this.txtConVista.TabIndex = 8;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(127, 95);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(121, 20);
            this.txtDesc.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(93, 179);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Dar Alta";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Hotel:";
            // 
            // txtHotel
            // 
            this.txtHotel.Location = new System.Drawing.Point(127, 119);
            this.txtHotel.Name = "txtHotel";
            this.txtHotel.Size = new System.Drawing.Size(121, 20);
            this.txtHotel.TabIndex = 12;
            // 
            // HabitacionAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 214);
            this.Controls.Add(this.txtHotel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtConVista);
            this.Controls.Add(this.txtPisoHotel);
            this.Controls.Add(this.txtNroHabi);
            this.Controls.Add(this.cBTipoHabitacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HabitacionAlta";
            this.Text = "HabitacionAlta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBTipoHabitacion;
        private System.Windows.Forms.TextBox txtNroHabi;
        private System.Windows.Forms.TextBox txtPisoHotel;
        private System.Windows.Forms.TextBox txtConVista;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHotel;
    }
}