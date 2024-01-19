namespace AppDemoCliente
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSolicitar = new System.Windows.Forms.Button();
            this.tbRespuesta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.Location = new System.Drawing.Point(168, 137);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(274, 82);
            this.btnSolicitar.TabIndex = 0;
            this.btnSolicitar.Text = "Consumir API";
            this.btnSolicitar.UseVisualStyleBackColor = true;
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // tbRespuesta
            // 
            this.tbRespuesta.Location = new System.Drawing.Point(25, 34);
            this.tbRespuesta.Multiline = true;
            this.tbRespuesta.Name = "tbRespuesta";
            this.tbRespuesta.Size = new System.Drawing.Size(569, 86);
            this.tbRespuesta.TabIndex = 1;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 231);
            this.Controls.Add(this.tbRespuesta);
            this.Controls.Add(this.btnSolicitar);
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSolicitar;
        private System.Windows.Forms.TextBox tbRespuesta;
    }
}

