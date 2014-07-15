namespace FrbaCommerce.Generar_Publicacion
{
    partial class GenPubForm
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
            this.lblSeleccion = new System.Windows.Forms.Label();
            this.lBTiposDePub = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(82, 140);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 23);
            this.btnContinuar.TabIndex = 0;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            // 
            // lblSeleccion
            // 
            this.lblSeleccion.AutoSize = true;
            this.lblSeleccion.Location = new System.Drawing.Point(13, 13);
            this.lblSeleccion.Name = "lblSeleccion";
            this.lblSeleccion.Size = new System.Drawing.Size(166, 13);
            this.lblSeleccion.TabIndex = 1;
            this.lblSeleccion.Text = "Seleccione el tipo de publicacion:";
            // 
            // lBTiposDePub
            // 
            this.lBTiposDePub.FormattingEnabled = true;
            this.lBTiposDePub.Location = new System.Drawing.Point(59, 39);
            this.lBTiposDePub.Name = "lBTiposDePub";
            this.lBTiposDePub.Size = new System.Drawing.Size(120, 56);
            this.lBTiposDePub.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 186);
            this.Controls.Add(this.lBTiposDePub);
            this.Controls.Add(this.lblSeleccion);
            this.Controls.Add(this.btnContinuar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label lblSeleccion;
        private System.Windows.Forms.ListBox lBTiposDePub;
    }
}