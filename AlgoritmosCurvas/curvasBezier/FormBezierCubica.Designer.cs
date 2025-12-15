namespace curvasBezier
{
    partial class FormBezierCubica
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
            this.chkConstruccion = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.chkCurva = new System.Windows.Forms.CheckBox();
            this.chkRastro = new System.Windows.Forms.CheckBox();
            this.chkAnimacion = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numP2X = new System.Windows.Forms.NumericUpDown();
            this.numP2Y = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numP1Y = new System.Windows.Forms.NumericUpDown();
            this.numP1X = new System.Windows.Forms.NumericUpDown();
            this.numP0Y = new System.Windows.Forms.NumericUpDown();
            this.numP0X = new System.Windows.Forms.NumericUpDown();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numP3X = new System.Windows.Forms.NumericUpDown();
            this.numP3Y = new System.Windows.Forms.NumericUpDown();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numP2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP0Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP0X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3Y)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 450);
            this.panel2.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkConstruccion);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.chkCurva);
            this.groupBox2.Controls.Add(this.chkRastro);
            this.groupBox2.Controls.Add(this.chkAnimacion);
            this.groupBox2.Location = new System.Drawing.Point(12, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 235);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visualización";
            // 
            // chkConstruccion
            // 
            this.chkConstruccion.AutoSize = true;
            this.chkConstruccion.Location = new System.Drawing.Point(21, 104);
            this.chkConstruccion.Name = "chkConstruccion";
            this.chkConstruccion.Size = new System.Drawing.Size(124, 17);
            this.chkConstruccion.TabIndex = 5;
            this.chkConstruccion.Text = "Líneas Construcción";
            this.chkConstruccion.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(21, 148);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(157, 23);
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
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numP3X);
            this.groupBox1.Controls.Add(this.numP3Y);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numP2X);
            this.groupBox1.Controls.Add(this.numP2Y);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numP1Y);
            this.groupBox1.Controls.Add(this.numP1X);
            this.groupBox1.Controls.Add(this.numP0Y);
            this.groupBox1.Controls.Add(this.numP0X);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puntos de Control";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "P2";
            // 
            // numP2X
            // 
            this.numP2X.Location = new System.Drawing.Point(101, 99);
            this.numP2X.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numP2X.Name = "numP2X";
            this.numP2X.Size = new System.Drawing.Size(46, 20);
            this.numP2X.TabIndex = 7;
            // 
            // numP2Y
            // 
            this.numP2Y.Location = new System.Drawing.Point(153, 99);
            this.numP2Y.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numP2Y.Name = "numP2Y";
            this.numP2Y.Size = new System.Drawing.Size(46, 20);
            this.numP2Y.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "P1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "P0";
            // 
            // numP1Y
            // 
            this.numP1Y.Location = new System.Drawing.Point(153, 68);
            this.numP1Y.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numP1Y.Name = "numP1Y";
            this.numP1Y.Size = new System.Drawing.Size(46, 20);
            this.numP1Y.TabIndex = 3;
            // 
            // numP1X
            // 
            this.numP1X.Location = new System.Drawing.Point(101, 68);
            this.numP1X.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numP1X.Name = "numP1X";
            this.numP1X.Size = new System.Drawing.Size(46, 20);
            this.numP1X.TabIndex = 2;
            // 
            // numP0Y
            // 
            this.numP0Y.Location = new System.Drawing.Point(153, 37);
            this.numP0Y.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numP0Y.Name = "numP0Y";
            this.numP0Y.Size = new System.Drawing.Size(46, 20);
            this.numP0Y.TabIndex = 1;
            // 
            // numP0X
            // 
            this.numP0X.Location = new System.Drawing.Point(101, 37);
            this.numP0X.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numP0X.Name = "numP0X";
            this.numP0X.Size = new System.Drawing.Size(46, 20);
            this.numP0X.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(266, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(522, 426);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "P3";
            // 
            // numP3X
            // 
            this.numP3X.Location = new System.Drawing.Point(101, 132);
            this.numP3X.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numP3X.Name = "numP3X";
            this.numP3X.Size = new System.Drawing.Size(46, 20);
            this.numP3X.TabIndex = 10;
            // 
            // numP3Y
            // 
            this.numP3Y.Location = new System.Drawing.Point(153, 132);
            this.numP3Y.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numP3Y.Name = "numP3Y";
            this.numP3Y.Size = new System.Drawing.Size(46, 20);
            this.numP3Y.TabIndex = 9;
            // 
            // FormBezierCubica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel2);
            this.Name = "FormBezierCubica";
            this.Text = "FormBezierCubica";
            this.Load += new System.EventHandler(this.FormBezierCubica_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numP2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP0Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP0X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3Y)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkConstruccion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.CheckBox chkCurva;
        private System.Windows.Forms.CheckBox chkRastro;
        private System.Windows.Forms.CheckBox chkAnimacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numP2X;
        private System.Windows.Forms.NumericUpDown numP2Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numP1Y;
        private System.Windows.Forms.NumericUpDown numP1X;
        private System.Windows.Forms.NumericUpDown numP0Y;
        private System.Windows.Forms.NumericUpDown numP0X;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numP3X;
        private System.Windows.Forms.NumericUpDown numP3Y;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}