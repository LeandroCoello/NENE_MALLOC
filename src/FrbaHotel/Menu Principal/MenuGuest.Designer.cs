namespace FrbaHotel.Menu_Principal
{
    partial class MenuGuest
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
            this.btnGENMODRESER = new System.Windows.Forms.Button();
            this.bnCancelGuest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGENMODRESER
            // 
            this.btnGENMODRESER.Location = new System.Drawing.Point(39, 12);
            this.btnGENMODRESER.Name = "btnGENMODRESER";
            this.btnGENMODRESER.Size = new System.Drawing.Size(109, 51);
            this.btnGENMODRESER.TabIndex = 1;
            this.btnGENMODRESER.Text = "Generar o Modificar Reserva";
            this.btnGENMODRESER.UseVisualStyleBackColor = true;
            this.btnGENMODRESER.Click += new System.EventHandler(this.btnGENMODRESER_Click);
            // 
            // bnCancelGuest
            // 
            this.bnCancelGuest.Location = new System.Drawing.Point(154, 12);
            this.bnCancelGuest.Name = "bnCancelGuest";
            this.bnCancelGuest.Size = new System.Drawing.Size(109, 51);
            this.bnCancelGuest.TabIndex = 2;
            this.bnCancelGuest.Text = "Cancelar Reserva";
            this.bnCancelGuest.UseVisualStyleBackColor = true;
            this.bnCancelGuest.Click += new System.EventHandler(this.bnCancelGuest_Click);
            // 
            // MenuGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 80);
            this.Controls.Add(this.bnCancelGuest);
            this.Controls.Add(this.btnGENMODRESER);
            this.Name = "MenuGuest";
            this.Text = "Guest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGENMODRESER;
        private System.Windows.Forms.Button bnCancelGuest;
    }
}