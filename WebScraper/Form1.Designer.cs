namespace WebScraper
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtlog = new System.Windows.Forms.RichTextBox();
            this.txtscript = new System.Windows.Forms.RichTextBox();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.lbllog = new System.Windows.Forms.Label();
            this.lblscript = new System.Windows.Forms.Label();
            this.btnrecarga = new System.Windows.Forms.Button();
            this.fondo = new System.Windows.Forms.Panel();
            this.lblbienvenido = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Image = global::WebScraper.Properties.Resources.fondo;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button1.Location = new System.Drawing.Point(15, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Comprobantes Electronicos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(320, 72);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(999, 600);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button2.Image = global::WebScraper.Properties.Resources.fondo;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button2.Location = new System.Drawing.Point(138, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Descargar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.Image = global::WebScraper.Properties.Resources.fondo;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button3.Location = new System.Drawing.Point(218, 320);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Enviar Comprobantes";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtlog
            // 
            this.txtlog.Location = new System.Drawing.Point(12, 72);
            this.txtlog.Name = "txtlog";
            this.txtlog.Size = new System.Drawing.Size(301, 242);
            this.txtlog.TabIndex = 5;
            this.txtlog.Text = "";
            // 
            // txtscript
            // 
            this.txtscript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtscript.Location = new System.Drawing.Point(15, 361);
            this.txtscript.Name = "txtscript";
            this.txtscript.Size = new System.Drawing.Size(299, 311);
            this.txtscript.TabIndex = 6;
            this.txtscript.Text = "";
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Stencil", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbltitulo.Location = new System.Drawing.Point(542, 4);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(334, 57);
            this.lbltitulo.TabIndex = 7;
            this.lbltitulo.Text = "TRINITY RPA";
            // 
            // lbllog
            // 
            this.lbllog.AutoSize = true;
            this.lbllog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllog.Location = new System.Drawing.Point(12, 45);
            this.lbllog.Name = "lbllog";
            this.lbllog.Size = new System.Drawing.Size(131, 24);
            this.lbllog.TabIndex = 8;
            this.lbllog.Text = "Log de datos";
            // 
            // lblscript
            // 
            this.lblscript.AutoSize = true;
            this.lblscript.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblscript.Location = new System.Drawing.Point(327, 45);
            this.lblscript.Name = "lblscript";
            this.lblscript.Size = new System.Drawing.Size(170, 24);
            this.lblscript.TabIndex = 9;
            this.lblscript.Text = "Script de Usuario";
            // 
            // btnrecarga
            // 
            this.btnrecarga.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnrecarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrecarga.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnrecarga.Location = new System.Drawing.Point(1270, 32);
            this.btnrecarga.Name = "btnrecarga";
            this.btnrecarga.Size = new System.Drawing.Size(49, 37);
            this.btnrecarga.TabIndex = 11;
            this.btnrecarga.Text = "<--\r\n-->";
            this.btnrecarga.UseVisualStyleBackColor = false;
            this.btnrecarga.Click += new System.EventHandler(this.btnrecarga_Click);
            // 
            // fondo
            // 
            this.fondo.BackColor = System.Drawing.SystemColors.Window;
            this.fondo.BackgroundImage = global::WebScraper.Properties.Resources.fondo;
            this.fondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fondo.Controls.Add(this.lblbienvenido);
            this.fondo.Location = new System.Drawing.Point(320, 72);
            this.fondo.Name = "fondo";
            this.fondo.Size = new System.Drawing.Size(999, 600);
            this.fondo.TabIndex = 14;
            // 
            // lblbienvenido
            // 
            this.lblbienvenido.AutoSize = true;
            this.lblbienvenido.BackColor = System.Drawing.Color.Transparent;
            this.lblbienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbienvenido.ForeColor = System.Drawing.Color.White;
            this.lblbienvenido.Location = new System.Drawing.Point(62, 111);
            this.lblbienvenido.Name = "lblbienvenido";
            this.lblbienvenido.Size = new System.Drawing.Size(892, 365);
            this.lblbienvenido.TabIndex = 11;
            this.lblbienvenido.Text = "Bienvenidos al sistema\r\n\r\nPara iniciar presione el botón\r\n\r\nComprobantes Electrón" +
    "icos";
            this.lblbienvenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1331, 677);
            this.Controls.Add(this.fondo);
            this.Controls.Add(this.btnrecarga);
            this.Controls.Add(this.lblscript);
            this.Controls.Add(this.lbllog);
            this.Controls.Add(this.lbltitulo);
            this.Controls.Add(this.txtscript);
            this.Controls.Add(this.txtlog);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Form1";
            this.Text = "Practisis S.A.";
            this.fondo.ResumeLayout(false);
            this.fondo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox txtlog;
        private System.Windows.Forms.RichTextBox txtscript;
        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lbllog;
        private System.Windows.Forms.Label lblscript;
        private System.Windows.Forms.Button btnrecarga;
        private System.Windows.Forms.Panel fondo;
        private System.Windows.Forms.Label lblbienvenido;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

