namespace FrbaHotel.ABM_de_Rol
{
    partial class AltaRol
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
            this.txtNomRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rBtnActivo = new System.Windows.Forms.RadioButton();
            this.rBtnInactivo = new System.Windows.Forms.RadioButton();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese nombre:";
            // 
            // txtNomRol
            // 
            this.txtNomRol.Location = new System.Drawing.Point(116, 10);
            this.txtNomRol.Name = "txtNomRol";
            this.txtNomRol.Size = new System.Drawing.Size(100, 20);
            this.txtNomRol.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Funcionalidades:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Estado:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(116, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // rBtnActivo
            // 
            this.rBtnActivo.AutoSize = true;
            this.rBtnActivo.Location = new System.Drawing.Point(63, 86);
            this.rBtnActivo.Name = "rBtnActivo";
            this.rBtnActivo.Size = new System.Drawing.Size(55, 17);
            this.rBtnActivo.TabIndex = 5;
            this.rBtnActivo.TabStop = true;
            this.rBtnActivo.Text = "Activo";
            this.rBtnActivo.UseVisualStyleBackColor = true;
            // 
            // rBtnInactivo
            // 
            this.rBtnInactivo.AutoSize = true;
            this.rBtnInactivo.Location = new System.Drawing.Point(124, 86);
            this.rBtnInactivo.Name = "rBtnInactivo";
            this.rBtnInactivo.Size = new System.Drawing.Size(63, 17);
            this.rBtnInactivo.TabIndex = 6;
            this.rBtnInactivo.TabStop = true;
            this.rBtnInactivo.Text = "Inactivo";
            this.rBtnInactivo.UseVisualStyleBackColor = true;
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.Location = new System.Drawing.Point(94, 121);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(75, 23);
            this.btnCrearRol.TabIndex = 7;
            this.btnCrearRol.Text = "Crear";
            this.btnCrearRol.UseVisualStyleBackColor = true;
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 175);
            this.Controls.Add(this.btnCrearRol);
            this.Controls.Add(this.rBtnInactivo);
            this.Controls.Add(this.rBtnActivo);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomRol);
            this.Controls.Add(this.label1);
            this.Name = "AltaRol";
            this.Text = "AltaRol";
            this.Load += new System.EventHandler(this.AltaRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton rBtnActivo;
        private System.Windows.Forms.RadioButton rBtnInactivo;
        private System.Windows.Forms.Button btnCrearRol;
    }
}