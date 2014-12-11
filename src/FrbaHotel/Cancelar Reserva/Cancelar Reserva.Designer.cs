namespace FrbaHotel.Cancelar_Reserva
{
    partial class CancelReser
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
            this.txtNroReserva = new System.Windows.Forms.TextBox();
            this.txtFecCancel = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnAceptarCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro de Reserva:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Motivo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Cancelación:";
            // 
            // txtNroReserva
            // 
            this.txtNroReserva.Location = new System.Drawing.Point(103, 6);
            this.txtNroReserva.Name = "txtNroReserva";
            this.txtNroReserva.Size = new System.Drawing.Size(158, 20);
            this.txtNroReserva.TabIndex = 4;
            // 
            // txtFecCancel
            // 
            this.txtFecCancel.Enabled = false;
            this.txtFecCancel.Location = new System.Drawing.Point(120, 183);
            this.txtFecCancel.Name = "txtFecCancel";
            this.txtFecCancel.ReadOnly = true;
            this.txtFecCancel.Size = new System.Drawing.Size(104, 20);
            this.txtFecCancel.TabIndex = 6;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(15, 52);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(246, 111);
            this.txtMotivo.TabIndex = 7;
            // 
            // btnAceptarCancel
            // 
            this.btnAceptarCancel.Location = new System.Drawing.Point(80, 222);
            this.btnAceptarCancel.Name = "btnAceptarCancel";
            this.btnAceptarCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarCancel.TabIndex = 8;
            this.btnAceptarCancel.Text = "Aceptar";
            this.btnAceptarCancel.UseVisualStyleBackColor = true;
            this.btnAceptarCancel.Click += new System.EventHandler(this.btnAceptarCancel_Click);
            // 
            // CancelReser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 268);
            this.Controls.Add(this.btnAceptarCancel);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.txtFecCancel);
            this.Controls.Add(this.txtNroReserva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CancelReser";
            this.Text = "Cancelar Reserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNroReserva;
        private System.Windows.Forms.TextBox txtFecCancel;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnAceptarCancel;
    }
}