namespace FrbaCommerce.Menu_Principal
{
    partial class Form1MenuPrincipal
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
            this.btnCompraOferta = new System.Windows.Forms.Button();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.btnEditPub = new System.Windows.Forms.Button();
            this.btnCrearPub = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.lblPublicacion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPreguntas = new System.Windows.Forms.Button();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCompraOferta
            // 
            this.btnCompraOferta.Location = new System.Drawing.Point(171, 222);
            this.btnCompraOferta.Name = "btnCompraOferta";
            this.btnCompraOferta.Size = new System.Drawing.Size(126, 32);
            this.btnCompraOferta.TabIndex = 0;
            this.btnCompraOferta.Text = "Comprar / Ofertar";
            this.btnCompraOferta.UseVisualStyleBackColor = true;
            this.btnCompraOferta.Visible = false;
            this.btnCompraOferta.Click += new System.EventHandler(this.btnCompraOferta_Click);
            // 
            // btnCalificar
            // 
            this.btnCalificar.Location = new System.Drawing.Point(52, 182);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(75, 23);
            this.btnCalificar.TabIndex = 1;
            this.btnCalificar.Text = "Calificar";
            this.btnCalificar.UseVisualStyleBackColor = true;
            this.btnCalificar.Visible = false;
            // 
            // btnEditPub
            // 
            this.btnEditPub.Location = new System.Drawing.Point(52, 54);
            this.btnEditPub.Name = "btnEditPub";
            this.btnEditPub.Size = new System.Drawing.Size(75, 23);
            this.btnEditPub.TabIndex = 2;
            this.btnEditPub.Text = "Editar ";
            this.btnEditPub.UseVisualStyleBackColor = true;
            this.btnEditPub.Click += new System.EventHandler(this.btnEditPub_Click);
            // 
            // btnCrearPub
            // 
            this.btnCrearPub.Location = new System.Drawing.Point(52, 25);
            this.btnCrearPub.Name = "btnCrearPub";
            this.btnCrearPub.Size = new System.Drawing.Size(75, 23);
            this.btnCrearPub.TabIndex = 3;
            this.btnCrearPub.Text = "Crear ";
            this.btnCrearPub.UseVisualStyleBackColor = true;
            this.btnCrearPub.Click += new System.EventHandler(this.btnCrearPub_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(52, 153);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(75, 23);
            this.btnHistorial.TabIndex = 5;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            // 
            // lblPublicacion
            // 
            this.lblPublicacion.AutoSize = true;
            this.lblPublicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPublicacion.Location = new System.Drawing.Point(12, 9);
            this.lblPublicacion.Name = "lblPublicacion";
            this.lblPublicacion.Size = new System.Drawing.Size(65, 13);
            this.lblPublicacion.TabIndex = 6;
            this.lblPublicacion.Text = "Publicacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Reputación:";
            // 
            // btnPreguntas
            // 
            this.btnPreguntas.Location = new System.Drawing.Point(52, 83);
            this.btnPreguntas.Name = "btnPreguntas";
            this.btnPreguntas.Size = new System.Drawing.Size(75, 25);
            this.btnPreguntas.TabIndex = 8;
            this.btnPreguntas.Text = "Preguntas";
            this.btnPreguntas.UseVisualStyleBackColor = true;
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Location = new System.Drawing.Point(15, 222);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(99, 32);
            this.btnFacturacion.TabIndex = 9;
            this.btnFacturacion.Text = "Facturación";
            this.btnFacturacion.UseVisualStyleBackColor = true;
            // 
            // Form1MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 272);
            this.Controls.Add(this.btnFacturacion);
            this.Controls.Add(this.btnPreguntas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPublicacion);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrearPub);
            this.Controls.Add(this.btnEditPub);
            this.Controls.Add(this.btnCalificar);
            this.Controls.Add(this.btnCompraOferta);
            this.Name = "Form1MenuPrincipal";
            this.Text = "Form1MenuPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompraOferta;
        private System.Windows.Forms.Button btnCalificar;
        private System.Windows.Forms.Button btnEditPub;
        private System.Windows.Forms.Button btnCrearPub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Label lblPublicacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPreguntas;
        private System.Windows.Forms.Button btnFacturacion;
    }
}