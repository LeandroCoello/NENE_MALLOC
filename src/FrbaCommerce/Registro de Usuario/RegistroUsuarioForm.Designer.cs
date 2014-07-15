namespace FrbaCommerce.Registro_de_Usuario
{
    partial class RegistroUsuarioForm
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
            this.lblEleccionRol = new System.Windows.Forms.Label();
            this.LBEleccionDeRol = new System.Windows.Forms.ListBox();
            this.btnConfirmacion = new System.Windows.Forms.Button();
            this.lblMostrarUsuario = new System.Windows.Forms.Label();
            this.lblMostrarContraseña = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(117, 212);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 23);
            this.btnContinuar.TabIndex = 0;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // lblEleccionRol
            // 
            this.lblEleccionRol.AutoSize = true;
            this.lblEleccionRol.Location = new System.Drawing.Point(12, 9);
            this.lblEleccionRol.Name = "lblEleccionRol";
            this.lblEleccionRol.Size = new System.Drawing.Size(57, 13);
            this.lblEleccionRol.TabIndex = 3;
            this.lblEleccionRol.Text = "Elija su rol:";
            // 
            // LBEleccionDeRol
            // 
            this.LBEleccionDeRol.FormattingEnabled = true;
            this.LBEleccionDeRol.Location = new System.Drawing.Point(92, 39);
            this.LBEleccionDeRol.Name = "LBEleccionDeRol";
            this.LBEleccionDeRol.Size = new System.Drawing.Size(122, 43);
            this.LBEleccionDeRol.TabIndex = 6;
            this.LBEleccionDeRol.SelectedIndexChanged += new System.EventHandler(this.LBEleccionDeRol_SelectedIndexChanged);
            // 
            // btnConfirmacion
            // 
            this.btnConfirmacion.Location = new System.Drawing.Point(107, 105);
            this.btnConfirmacion.Name = "btnConfirmacion";
            this.btnConfirmacion.Size = new System.Drawing.Size(98, 23);
            this.btnConfirmacion.TabIndex = 8;
            this.btnConfirmacion.Text = "Confirmar";
            this.btnConfirmacion.UseVisualStyleBackColor = true;
            this.btnConfirmacion.Click += new System.EventHandler(this.btnConfirmacion_Click);
            // 
            // lblMostrarUsuario
            // 
            this.lblMostrarUsuario.AutoSize = true;
            this.lblMostrarUsuario.Location = new System.Drawing.Point(63, 144);
            this.lblMostrarUsuario.Name = "lblMostrarUsuario";
            this.lblMostrarUsuario.Size = new System.Drawing.Size(209, 13);
            this.lblMostrarUsuario.TabIndex = 9;
            this.lblMostrarUsuario.Text = "Se muestra el nombre del usuario asignado";
            // 
            // lblMostrarContraseña
            // 
            this.lblMostrarContraseña.AutoSize = true;
            this.lblMostrarContraseña.Location = new System.Drawing.Point(63, 183);
            this.lblMostrarContraseña.Name = "lblMostrarContraseña";
            this.lblMostrarContraseña.Size = new System.Drawing.Size(188, 13);
            this.lblMostrarContraseña.TabIndex = 10;
            this.lblMostrarContraseña.Text = "Se muestra la pass asignada asignada";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 262);
            this.Controls.Add(this.lblMostrarContraseña);
            this.Controls.Add(this.lblMostrarUsuario);
            this.Controls.Add(this.btnConfirmacion);
            this.Controls.Add(this.LBEleccionDeRol);
            this.Controls.Add(this.lblEleccionRol);
            this.Controls.Add(this.btnContinuar);
            this.Name = "Form1";
            this.Text = "Registrar Usuario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label lblEleccionRol;
        private System.Windows.Forms.ListBox LBEleccionDeRol;
        private System.Windows.Forms.Button btnConfirmacion;
        private System.Windows.Forms.Label lblMostrarUsuario;
        private System.Windows.Forms.Label lblMostrarContraseña;
    }
}