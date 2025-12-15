namespace curvasBezier
{
    partial class FormBSpline
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPoligono = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.chkCurva = new System.Windows.Forms.CheckBox();
            this.chkRastro = new System.Windows.Forms.CheckBox();
            this.chkAnimacion = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numCantidadPuntos = new System.Windows.Forms.NumericUpDown();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnGenerarPuntos = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numGrado = new System.Windows.Forms.NumericUpDown();
            this.lstPuntos = new System.Windows.Forms.ListBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.chkPuntos = new System.Windows.Forms.CheckBox();
            this.btnDibujar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadPuntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGrado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 450);
            this.panel2.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDibujar);
            this.groupBox2.Controls.Add(this.chkPuntos);
            this.groupBox2.Controls.Add(this.chkPoligono);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.chkCurva);
            this.groupBox2.Controls.Add(this.chkRastro);
            this.groupBox2.Controls.Add(this.chkAnimacion);
            this.groupBox2.Location = new System.Drawing.Point(12, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 188);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visualización";
            // 
            // chkPoligono
            // 
            this.chkPoligono.AutoSize = true;
            this.chkPoligono.Location = new System.Drawing.Point(21, 104);
            this.chkPoligono.Name = "chkPoligono";
            this.chkPoligono.Size = new System.Drawing.Size(105, 17);
            this.chkPoligono.TabIndex = 5;
            this.chkPoligono.Text = "Polígono Control";
            this.chkPoligono.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(125, 150);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(82, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // chkCurva
            // 
            this.chkCurva.AutoSize = true;
            this.chkCurva.Location = new System.Drawing.Point(21, 81);
            this.chkCurva.Name = "chkCurva";
            this.chkCurva.Size = new System.Drawing.Size(92, 17);
            this.chkCurva.TabIndex = 2;
            this.chkCurva.Text = "Mostrar Curva";
            this.chkCurva.UseVisualStyleBackColor = true;
            // 
            // chkRastro
            // 
            this.chkRastro.AutoSize = true;
            this.chkRastro.Location = new System.Drawing.Point(21, 58);
            this.chkRastro.Name = "chkRastro";
            this.chkRastro.Size = new System.Drawing.Size(92, 17);
            this.chkRastro.TabIndex = 1;
            this.chkRastro.Text = "Mostrar Rasto";
            this.chkRastro.UseVisualStyleBackColor = true;
            // 
            // chkAnimacion
            // 
            this.chkAnimacion.AutoSize = true;
            this.chkAnimacion.Location = new System.Drawing.Point(21, 35);
            this.chkAnimacion.Name = "chkAnimacion";
            this.chkAnimacion.Size = new System.Drawing.Size(113, 17);
            this.chkAnimacion.TabIndex = 0;
            this.chkAnimacion.Text = "Mostrar Animación";
            this.chkAnimacion.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstPuntos);
            this.groupBox1.Controls.Add(this.btnGenerarPuntos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numCantidadPuntos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puntos de Control";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Número de puntos";
            // 
            // numCantidadPuntos
            // 
            this.numCantidadPuntos.Location = new System.Drawing.Point(143, 24);
            this.numCantidadPuntos.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCantidadPuntos.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numCantidadPuntos.Name = "numCantidadPuntos";
            this.numCantidadPuntos.Size = new System.Drawing.Size(46, 20);
            this.numCantidadPuntos.TabIndex = 1;
            this.numCantidadPuntos.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(266, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(522, 426);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // btnGenerarPuntos
            // 
            this.btnGenerarPuntos.Location = new System.Drawing.Point(32, 50);
            this.btnGenerarPuntos.Name = "btnGenerarPuntos";
            this.btnGenerarPuntos.Size = new System.Drawing.Size(157, 23);
            this.btnGenerarPuntos.TabIndex = 6;
            this.btnGenerarPuntos.Text = "Generar Puntos";
            this.btnGenerarPuntos.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblInfo);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.numGrado);
            this.groupBox3.Location = new System.Drawing.Point(12, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 76);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grado de la Curva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grado (k)";
            // 
            // numGrado
            // 
            this.numGrado.Location = new System.Drawing.Point(143, 26);
            this.numGrado.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numGrado.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numGrado.Name = "numGrado";
            this.numGrado.Size = new System.Drawing.Size(46, 20);
            this.numGrado.TabIndex = 1;
            this.numGrado.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lstPuntos
            // 
            this.lstPuntos.FormattingEnabled = true;
            this.lstPuntos.Location = new System.Drawing.Point(32, 70);
            this.lstPuntos.Name = "lstPuntos";
            this.lstPuntos.Size = new System.Drawing.Size(157, 56);
            this.lstPuntos.TabIndex = 7;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(46, 49);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(132, 13);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Grado 3 = B-Spline Cúbica";
            // 
            // chkPuntos
            // 
            this.chkPuntos.AutoSize = true;
            this.chkPuntos.Location = new System.Drawing.Point(21, 125);
            this.chkPuntos.Name = "chkPuntos";
            this.chkPuntos.Size = new System.Drawing.Size(95, 17);
            this.chkPuntos.TabIndex = 6;
            this.chkPuntos.Text = "Puntos Control";
            this.chkPuntos.UseVisualStyleBackColor = true;
            // 
            // btnDibujar
            // 
            this.btnDibujar.Location = new System.Drawing.Point(21, 150);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(82, 23);
            this.btnDibujar.TabIndex = 7;
            this.btnDibujar.Text = "Dibujar";
            this.btnDibujar.UseVisualStyleBackColor = true;
            // 
            // FormBSpline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel2);
            this.Name = "FormBSpline";
            this.Text = "FormBSpline";
            this.Load += new System.EventHandler(this.FormBSpline_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadPuntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGrado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkPoligono;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.CheckBox chkCurva;
        private System.Windows.Forms.CheckBox chkRastro;
        private System.Windows.Forms.CheckBox chkAnimacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCantidadPuntos;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numGrado;
        private System.Windows.Forms.Button btnGenerarPuntos;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ListBox lstPuntos;
        private System.Windows.Forms.CheckBox chkPuntos;
        private System.Windows.Forms.Button btnDibujar;
    }
}