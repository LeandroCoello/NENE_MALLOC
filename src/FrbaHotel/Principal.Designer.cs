namespace FrbaHotel
{
    partial class Principal
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
            this.btnExecRegistro = new System.Windows.Forms.Button();
            this.btnExecLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExecRegistro
            // 
            this.btnExecRegistro.Location = new System.Drawing.Point(67, 79);
            this.btnExecRegistro.Name = "btnExecRegistro";
            this.btnExecRegistro.Size = new System.Drawing.Size(104, 44);
            this.btnExecRegistro.TabIndex = 0;
            this.btnExecRegistro.Text = "Registrar Estadia";
            this.btnExecRegistro.UseVisualStyleBackColor = true;
            this.btnExecRegistro.Click += new System.EventHandler(this.btnExecRegistro_Click);
            // 
            // btnExecLogin
            // 
            this.btnExecLogin.Location = new System.Drawing.Point(67, 29);
            this.btnExecLogin.Name = "btnExecLogin";
            this.btnExecLogin.Size = new System.Drawing.Size(104, 44);
            this.btnExecLogin.TabIndex = 1;
            this.btnExecLogin.Text = "Logearse";
            this.btnExecLogin.UseVisualStyleBackColor = true;
            this.btnExecLogin.Click += new System.EventHandler(this.btnExecLogin_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 184);
            this.Controls.Add(this.btnExecLogin);
            this.Controls.Add(this.btnExecRegistro);
            this.Name = "Principal";
            this.Text = "Bienvenido";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExecRegistro;
        private System.Windows.Forms.Button btnExecLogin;
    }
}

