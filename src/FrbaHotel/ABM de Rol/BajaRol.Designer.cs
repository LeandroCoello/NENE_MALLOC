namespace FrbaHotel.ABM_de_Rol
{
    partial class BajaRol
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
            this.cBRolesActuales = new System.Windows.Forms.ComboBox();
            this.btnBaja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Roles actuales:";
            // 
            // cBRolesActuales
            // 
            this.cBRolesActuales.FormattingEnabled = true;
            this.cBRolesActuales.Location = new System.Drawing.Point(99, 10);
            this.cBRolesActuales.Name = "cBRolesActuales";
            this.cBRolesActuales.Size = new System.Drawing.Size(121, 21);
            this.cBRolesActuales.TabIndex = 1;
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(99, 53);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 2;
            this.btnBaja.Text = "Eliminar";
            this.btnBaja.UseVisualStyleBackColor = true;
            // 
            // BajaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 112);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.cBRolesActuales);
            this.Controls.Add(this.label1);
            this.Name = "BajaRol";
            this.Text = "BajaRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBRolesActuales;
        private System.Windows.Forms.Button btnBaja;
    }
}