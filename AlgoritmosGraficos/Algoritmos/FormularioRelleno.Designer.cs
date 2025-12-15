namespace AlgoritmoRelleno
{
    partial class FormularioRelleno
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.grbHerramientas = new System.Windows.Forms.GroupBox();
            this.btnCancelarRelleno = new System.Windows.Forms.Button();
            this.radioDibujoLibre = new System.Windows.Forms.RadioButton();
            this.radioFigurasPredef = new System.Windows.Forms.RadioButton();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnDibujar = new System.Windows.Forms.Button();
            this.btnPentagono = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnTriangulo = new System.Windows.Forms.Button();
            this.btnCuadrado = new System.Windows.Forms.Button();
            this.txtPixeles = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRellenoBFS = new System.Windows.Forms.Button();
            this.btnRellenoScanline = new System.Windows.Forms.Button();
            this.btnRellenoRecursivo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.grbHerramientas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(31, 25);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(321, 364);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            this.picBox.Click += new System.EventHandler(this.picBox_Click);
            this.picBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseClick);
            // 
            // grbHerramientas
            // 
            this.grbHerramientas.Controls.Add(this.btnCancelarRelleno);
            this.grbHerramientas.Controls.Add(this.radioDibujoLibre);
            this.grbHerramientas.Controls.Add(this.radioFigurasPredef);
            this.grbHerramientas.Controls.Add(this.btnFinalizar);
            this.grbHerramientas.Controls.Add(this.btnDibujar);
            this.grbHerramientas.Controls.Add(this.btnPentagono);
            this.grbHerramientas.Controls.Add(this.btnLimpiar);
            this.grbHerramientas.Controls.Add(this.btnTriangulo);
            this.grbHerramientas.Controls.Add(this.btnCuadrado);
            this.grbHerramientas.Location = new System.Drawing.Point(12, 17);
            this.grbHerramientas.Name = "grbHerramientas";
            this.grbHerramientas.Size = new System.Drawing.Size(382, 146);
            this.grbHerramientas.TabIndex = 1;
            this.grbHerramientas.TabStop = false;
            this.grbHerramientas.Text = "Herramientas de Dibujo";
            // 
            // btnCancelarRelleno
            // 
            this.btnCancelarRelleno.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnCancelarRelleno.FlatAppearance.BorderSize = 0;
            this.btnCancelarRelleno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarRelleno.Location = new System.Drawing.Point(288, 82);
            this.btnCancelarRelleno.Name = "btnCancelarRelleno";
            this.btnCancelarRelleno.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarRelleno.TabIndex = 11;
            this.btnCancelarRelleno.Text = "Cancelar";
            this.btnCancelarRelleno.UseVisualStyleBackColor = false;
            this.btnCancelarRelleno.Click += new System.EventHandler(this.btnCancelarRelleno_Click);
            // 
            // radioDibujoLibre
            // 
            this.radioDibujoLibre.AutoSize = true;
            this.radioDibujoLibre.Location = new System.Drawing.Point(149, 30);
            this.radioDibujoLibre.Name = "radioDibujoLibre";
            this.radioDibujoLibre.Size = new System.Drawing.Size(86, 17);
            this.radioDibujoLibre.TabIndex = 8;
            this.radioDibujoLibre.TabStop = true;
            this.radioDibujoLibre.Text = "Figuras libres";
            this.radioDibujoLibre.UseVisualStyleBackColor = true;
            this.radioDibujoLibre.CheckedChanged += new System.EventHandler(this.radioDibujoLibre_CheckedChanged);
            // 
            // radioFigurasPredef
            // 
            this.radioFigurasPredef.AutoSize = true;
            this.radioFigurasPredef.Location = new System.Drawing.Point(7, 30);
            this.radioFigurasPredef.Name = "radioFigurasPredef";
            this.radioFigurasPredef.Size = new System.Drawing.Size(119, 17);
            this.radioFigurasPredef.TabIndex = 7;
            this.radioFigurasPredef.TabStop = true;
            this.radioFigurasPredef.Text = "Figuras predefinidas";
            this.radioFigurasPredef.UseVisualStyleBackColor = true;
            this.radioFigurasPredef.CheckedChanged += new System.EventHandler(this.radioFigurasPredef_CheckedChanged);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.Wheat;
            this.btnFinalizar.FlatAppearance.BorderSize = 0;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Location = new System.Drawing.Point(160, 82);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 4;
            this.btnFinalizar.Text = "Cerrar Figura";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnDibujar
            // 
            this.btnDibujar.BackColor = System.Drawing.Color.Wheat;
            this.btnDibujar.FlatAppearance.BorderSize = 0;
            this.btnDibujar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDibujar.Location = new System.Drawing.Point(160, 53);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(75, 23);
            this.btnDibujar.TabIndex = 3;
            this.btnDibujar.Text = "Dibujo Libre";
            this.btnDibujar.UseVisualStyleBackColor = false;
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // btnPentagono
            // 
            this.btnPentagono.BackColor = System.Drawing.Color.Khaki;
            this.btnPentagono.FlatAppearance.BorderSize = 0;
            this.btnPentagono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPentagono.Location = new System.Drawing.Point(30, 111);
            this.btnPentagono.Name = "btnPentagono";
            this.btnPentagono.Size = new System.Drawing.Size(75, 23);
            this.btnPentagono.TabIndex = 2;
            this.btnPentagono.Text = "Pentágono";
            this.btnPentagono.UseVisualStyleBackColor = false;
            this.btnPentagono.Click += new System.EventHandler(this.btnPentagono_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(288, 53);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnTriangulo
            // 
            this.btnTriangulo.BackColor = System.Drawing.Color.Khaki;
            this.btnTriangulo.FlatAppearance.BorderSize = 0;
            this.btnTriangulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTriangulo.Location = new System.Drawing.Point(31, 82);
            this.btnTriangulo.Name = "btnTriangulo";
            this.btnTriangulo.Size = new System.Drawing.Size(75, 23);
            this.btnTriangulo.TabIndex = 1;
            this.btnTriangulo.Text = "Triángulo";
            this.btnTriangulo.UseVisualStyleBackColor = false;
            this.btnTriangulo.Click += new System.EventHandler(this.btnTriangulo_Click);
            // 
            // btnCuadrado
            // 
            this.btnCuadrado.BackColor = System.Drawing.Color.Khaki;
            this.btnCuadrado.FlatAppearance.BorderSize = 0;
            this.btnCuadrado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuadrado.Location = new System.Drawing.Point(31, 53);
            this.btnCuadrado.Name = "btnCuadrado";
            this.btnCuadrado.Size = new System.Drawing.Size(75, 23);
            this.btnCuadrado.TabIndex = 0;
            this.btnCuadrado.Text = "Cuadrado";
            this.btnCuadrado.UseVisualStyleBackColor = false;
            this.btnCuadrado.Click += new System.EventHandler(this.btnCuadrado_Click);
            // 
            // txtPixeles
            // 
            this.txtPixeles.Location = new System.Drawing.Point(7, 19);
            this.txtPixeles.Multiline = true;
            this.txtPixeles.Name = "txtPixeles";
            this.txtPixeles.Size = new System.Drawing.Size(369, 108);
            this.txtPixeles.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRellenoBFS);
            this.groupBox1.Controls.Add(this.btnRellenoScanline);
            this.groupBox1.Controls.Add(this.btnRellenoRecursivo);
            this.groupBox1.Location = new System.Drawing.Point(12, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 83);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relleno";
            // 
            // btnRellenoBFS
            // 
            this.btnRellenoBFS.BackColor = System.Drawing.Color.Plum;
            this.btnRellenoBFS.FlatAppearance.BorderSize = 0;
            this.btnRellenoBFS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRellenoBFS.Location = new System.Drawing.Point(278, 38);
            this.btnRellenoBFS.Name = "btnRellenoBFS";
            this.btnRellenoBFS.Size = new System.Drawing.Size(85, 23);
            this.btnRellenoBFS.TabIndex = 10;
            this.btnRellenoBFS.Text = "BFS";
            this.btnRellenoBFS.UseVisualStyleBackColor = false;
            this.btnRellenoBFS.Click += new System.EventHandler(this.btnRellenoBFS_Click);
            // 
            // btnRellenoScanline
            // 
            this.btnRellenoScanline.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRellenoScanline.FlatAppearance.BorderSize = 0;
            this.btnRellenoScanline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRellenoScanline.Location = new System.Drawing.Point(150, 38);
            this.btnRellenoScanline.Name = "btnRellenoScanline";
            this.btnRellenoScanline.Size = new System.Drawing.Size(85, 23);
            this.btnRellenoScanline.TabIndex = 9;
            this.btnRellenoScanline.Text = "Scanline";
            this.btnRellenoScanline.UseVisualStyleBackColor = false;
            this.btnRellenoScanline.Click += new System.EventHandler(this.btnRellenoScanline_Click);
            // 
            // btnRellenoRecursivo
            // 
            this.btnRellenoRecursivo.BackColor = System.Drawing.Color.YellowGreen;
            this.btnRellenoRecursivo.FlatAppearance.BorderSize = 0;
            this.btnRellenoRecursivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRellenoRecursivo.Location = new System.Drawing.Point(20, 38);
            this.btnRellenoRecursivo.Name = "btnRellenoRecursivo";
            this.btnRellenoRecursivo.Size = new System.Drawing.Size(85, 23);
            this.btnRellenoRecursivo.TabIndex = 8;
            this.btnRellenoRecursivo.Text = "Floodfill";
            this.btnRellenoRecursivo.UseVisualStyleBackColor = false;
            this.btnRellenoRecursivo.Click += new System.EventHandler(this.btnRellenoRecursivo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPixeles);
            this.groupBox2.Location = new System.Drawing.Point(12, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 141);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Puntos de relleno";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picBox);
            this.groupBox3.Location = new System.Drawing.Point(410, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 421);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gráfico";
            // 
            // FormularioRelleno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbHerramientas);
            this.Name = "FormularioRelleno";
            this.Text = "Algoritmos de Relleno";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.grbHerramientas.ResumeLayout(false);
            this.grbHerramientas.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.GroupBox grbHerramientas;
        private System.Windows.Forms.Button btnPentagono;
        private System.Windows.Forms.Button btnTriangulo;
        private System.Windows.Forms.Button btnCuadrado;
        private System.Windows.Forms.TextBox txtPixeles;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnDibujar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioDibujoLibre;
        private System.Windows.Forms.RadioButton radioFigurasPredef;
        private System.Windows.Forms.Button btnRellenoRecursivo;
        private System.Windows.Forms.Button btnCancelarRelleno;
        private System.Windows.Forms.Button btnRellenoBFS;
        private System.Windows.Forms.Button btnRellenoScanline;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

