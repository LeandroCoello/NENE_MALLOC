namespace FrbaCommerce.Registro_de_Usuario
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
            this.btnContinuar = new System.Windows.Forms.Button();
            this.lblIngresoDeUsuario = new System.Windows.Forms.Label();
            this.lblIngresoDeContraseña = new System.Windows.Forms.Label();
            this.lblEleccionRol = new System.Windows.Forms.Label();
            this.txtIngreDeContraseña = new System.Windows.Forms.TextBox();
            this.LBEleccionDeRol = new System.Windows.Forms.ListBox();
            this.txtIngresoDeUsuario = new System.Windows.Forms.TextBox();
            this.btnConfirmacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(339, 180);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 23);
            this.btnContinuar.TabIndex = 0;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // lblIngresoDeUsuario
            // 
            this.lblIngresoDeUsuario.AutoSize = true;
            this.lblIngresoDeUsuario.Location = new System.Drawing.Point(31, 16);
            this.lblIngresoDeUsuario.Name = "lblIngresoDeUsuario";
            this.lblIngresoDeUsuario.Size = new System.Drawing.Size(96, 13);
            this.lblIngresoDeUsuario.TabIndex = 1;
            this.lblIngresoDeUsuario.Text = "Ingrese su usuario:";
            // 
            // lblIngresoDeContraseña
            // 
            this.lblIngresoDeContraseña.AutoSize = true;
            this.lblIngresoDeContraseña.Location = new System.Drawing.Point(31, 46);
            this.lblIngresoDeContraseña.Name = "lblIngresoDeContraseña";
            this.lblIngresoDeContraseña.Size = new System.Drawing.Size(115, 13);
            this.lblIngresoDeContraseña.TabIndex = 2;
            this.lblIngresoDeContraseña.Text = "Ingrese su contraseña:";
            // 
            // lblEleccionRol
            // 
            this.lblEleccionRol.AutoSize = true;
            this.lblEleccionRol.Location = new System.Drawing.Point(31, 77);
            this.lblEleccionRol.Name = "lblEleccionRol";
            this.lblEleccionRol.Size = new System.Drawing.Size(57, 13);
            this.lblEleccionRol.TabIndex = 3;
            this.lblEleccionRol.Text = "Elija su rol:";
            // 
            // txtIngreDeContraseña
            // 
            this.txtIngreDeContraseña.Location = new System.Drawing.Point(175, 43);
            this.txtIngreDeContraseña.Name = "txtIngreDeContraseña";
            this.txtIngreDeContraseña.Size = new System.Drawing.Size(122, 20);
            this.txtIngreDeContraseña.TabIndex = 5;
            this.txtIngreDeContraseña.TextChanged += new System.EventHandler(this.txtIngreDeContraseña_TextChanged);
            // 
            // LBEleccionDeRol
            // 
            this.LBEleccionDeRol.FormattingEnabled = true;
            this.LBEleccionDeRol.Location = new System.Drawing.Point(175, 77);
            this.LBEleccionDeRol.Name = "LBEleccionDeRol";
            this.LBEleccionDeRol.Size = new System.Drawing.Size(122, 43);
            this.LBEleccionDeRol.TabIndex = 6;
            this.LBEleccionDeRol.SelectedIndexChanged += new System.EventHandler(this.LBEleccionDeRol_SelectedIndexChanged);
            // 
            // txtIngresoDeUsuario
            // 
            this.txtIngresoDeUsuario.Location = new System.Drawing.Point(175, 9);
            this.txtIngresoDeUsuario.Name = "txtIngresoDeUsuario";
            this.txtIngresoDeUsuario.Size = new System.Drawing.Size(122, 20);
            this.txtIngresoDeUsuario.TabIndex = 7;
            this.txtIngresoDeUsuario.TextChanged += new System.EventHandler(this.txtIngresoDeUsuario_TextChanged);
            // 
            // btnConfirmacion
            // 
            this.btnConfirmacion.Location = new System.Drawing.Point(175, 150);
            this.btnConfirmacion.Name = "btnConfirmacion";
            this.btnConfirmacion.Size = new System.Drawing.Size(98, 23);
            this.btnConfirmacion.TabIndex = 8;
            this.btnConfirmacion.Text = "Confirmar";
            this.btnConfirmacion.UseVisualStyleBackColor = true;
            this.btnConfirmacion.Click += new System.EventHandler(this.btnConfirmacion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 226);
            this.Controls.Add(this.btnConfirmacion);
            this.Controls.Add(this.txtIngresoDeUsuario);
            this.Controls.Add(this.LBEleccionDeRol);
            this.Controls.Add(this.txtIngreDeContraseña);
            this.Controls.Add(this.lblEleccionRol);
            this.Controls.Add(this.lblIngresoDeContraseña);
            this.Controls.Add(this.lblIngresoDeUsuario);
            this.Controls.Add(this.btnContinuar);
            this.Name = "Form1";
            this.Text = "Registrar Usuario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label lblIngresoDeUsuario;
        private System.Windows.Forms.Label lblIngresoDeContraseña;
        private System.Windows.Forms.Label lblEleccionRol;
        private System.Windows.Forms.TextBox txtIngreDeContraseña;
        private System.Windows.Forms.ListBox LBEleccionDeRol;
        private System.Windows.Forms.TextBox txtIngresoDeUsuario;
        private System.Windows.Forms.Button btnConfirmacion;
    }
}