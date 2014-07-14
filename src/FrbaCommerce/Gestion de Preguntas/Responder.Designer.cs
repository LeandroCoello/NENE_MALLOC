namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class Responder
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnEnvioRespuesta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 58);
            this.textBox1.TabIndex = 0;
            // 
            // btnEnvioRespuesta
            // 
            this.btnEnvioRespuesta.Location = new System.Drawing.Point(114, 76);
            this.btnEnvioRespuesta.Name = "btnEnvioRespuesta";
            this.btnEnvioRespuesta.Size = new System.Drawing.Size(75, 23);
            this.btnEnvioRespuesta.TabIndex = 1;
            this.btnEnvioRespuesta.Text = "Enviar";
            this.btnEnvioRespuesta.UseVisualStyleBackColor = true;
            this.btnEnvioRespuesta.Click += new System.EventHandler(this.btnEnvioRespuesta_Click);
            // 
            // Responder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 120);
            this.Controls.Add(this.btnEnvioRespuesta);
            this.Controls.Add(this.textBox1);
            this.Name = "Responder";
            this.Text = "Responder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnEnvioRespuesta;
    }
}