namespace FrbaCommerce.Abm_Cliente
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
            this.btnALTA = new System.Windows.Forms.Button();
            this.btnMODIF = new System.Windows.Forms.Button();
            this.btnBAJA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnALTA
            // 
            this.btnALTA.Location = new System.Drawing.Point(97, 12);
            this.btnALTA.Name = "btnALTA";
            this.btnALTA.Size = new System.Drawing.Size(75, 47);
            this.btnALTA.TabIndex = 0;
            this.btnALTA.Text = "Dar de alta";
            this.btnALTA.UseVisualStyleBackColor = true;
            this.btnALTA.Click += new System.EventHandler(this.btnALTA_Click);
            // 
            // btnMODIF
            // 
            this.btnMODIF.Location = new System.Drawing.Point(97, 65);
            this.btnMODIF.Name = "btnMODIF";
            this.btnMODIF.Size = new System.Drawing.Size(75, 47);
            this.btnMODIF.TabIndex = 1;
            this.btnMODIF.Text = "Modificar";
            this.btnMODIF.UseVisualStyleBackColor = true;
            this.btnMODIF.Click += new System.EventHandler(this.btnMODIF_Click);
            // 
            // btnBAJA
            // 
            this.btnBAJA.Location = new System.Drawing.Point(97, 118);
            this.btnBAJA.Name = "btnBAJA";
            this.btnBAJA.Size = new System.Drawing.Size(75, 47);
            this.btnBAJA.TabIndex = 2;
            this.btnBAJA.Text = "Dar de baja";
            this.btnBAJA.UseVisualStyleBackColor = true;
            this.btnBAJA.Click += new System.EventHandler(this.btnBAJA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 201);
            this.Controls.Add(this.btnBAJA);
            this.Controls.Add(this.btnMODIF);
            this.Controls.Add(this.btnALTA);
            this.Name = "Form1";
            this.Text = "ABM Cliente";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnALTA;
        private System.Windows.Forms.Button btnMODIF;
        private System.Windows.Forms.Button btnBAJA;
    }
}