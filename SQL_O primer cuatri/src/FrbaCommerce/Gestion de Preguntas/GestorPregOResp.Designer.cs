namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class GestorPregOResp
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
            this.dGVPreguntas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dGVRespuestas = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPreguntas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVRespuestas)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVPreguntas
            // 
            this.dGVPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVPreguntas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dGVPreguntas.Enabled = false;
            this.dGVPreguntas.Location = new System.Drawing.Point(12, 42);
            this.dGVPreguntas.Name = "dGVPreguntas";
            this.dGVPreguntas.Size = new System.Drawing.Size(445, 150);
            this.dGVPreguntas.TabIndex = 0;
            this.dGVPreguntas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVPreguntas_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cod. Publicacion";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Desc. Publicacion";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Pregunta";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Responder";
            this.Column4.Name = "Column4";
            this.Column4.Text = "Seleccionar";
            // 
            // dGVRespuestas
            // 
            this.dGVRespuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVRespuestas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dGVRespuestas.Enabled = false;
            this.dGVRespuestas.Location = new System.Drawing.Point(12, 54);
            this.dGVRespuestas.Name = "dGVRespuestas";
            this.dGVRespuestas.Size = new System.Drawing.Size(445, 150);
            this.dGVRespuestas.TabIndex = 1;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Cod. Publicacion";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Desc. Publicacion";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Pregunta";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Respuesta";
            this.Column8.Name = "Column8";
            // 
            // GestorPregOResp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 233);
            this.Controls.Add(this.dGVRespuestas);
            this.Controls.Add(this.dGVPreguntas);
            this.Name = "GestorPregOResp";
            this.Text = "LevantarInformacion";
            ((System.ComponentModel.ISupportInitialize)(this.dGVPreguntas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVRespuestas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVPreguntas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridView dGVRespuestas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;


    }
}