namespace Algoritmos
{
    partial class FormularioLineas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtyfinal = new System.Windows.Forms.TextBox();
            this.txtxfinal = new System.Windows.Forms.TextBox();
            this.txtyinicial = new System.Windows.Forms.TextBox();
            this.txtxinicial = new System.Windows.Forms.TextBox();
            this.btnpuntomedio = new System.Windows.Forms.Button();
            this.btnbresenham = new System.Windows.Forms.Button();
            this.btncalculardda = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtyfinal);
            this.groupBox1.Controls.Add(this.txtxfinal);
            this.groupBox1.Controls.Add(this.txtyinicial);
            this.groupBox1.Controls.Add(this.txtxinicial);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(22, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entradas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Coordenada final:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Coordenada inicial:";
            // 
            // txtyfinal
            // 
            this.txtyfinal.Location = new System.Drawing.Point(198, 93);
            this.txtyfinal.Name = "txtyfinal";
            this.txtyfinal.Size = new System.Drawing.Size(49, 20);
            this.txtyfinal.TabIndex = 3;
            // 
            // txtxfinal
            // 
            this.txtxfinal.Location = new System.Drawing.Point(137, 93);
            this.txtxfinal.Name = "txtxfinal";
            this.txtxfinal.Size = new System.Drawing.Size(49, 20);
            this.txtxfinal.TabIndex = 2;
            // 
            // txtyinicial
            // 
            this.txtyinicial.Location = new System.Drawing.Point(198, 50);
            this.txtyinicial.Name = "txtyinicial";
            this.txtyinicial.Size = new System.Drawing.Size(49, 20);
            this.txtyinicial.TabIndex = 1;
            // 
            // txtxinicial
            // 
            this.txtxinicial.Location = new System.Drawing.Point(137, 50);
            this.txtxinicial.Name = "txtxinicial";
            this.txtxinicial.Size = new System.Drawing.Size(49, 20);
            this.txtxinicial.TabIndex = 0;
            // 
            // btnpuntomedio
            // 
            this.btnpuntomedio.BackColor = System.Drawing.Color.Plum;
            this.btnpuntomedio.FlatAppearance.BorderSize = 0;
            this.btnpuntomedio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpuntomedio.Location = new System.Drawing.Point(44, 129);
            this.btnpuntomedio.Name = "btnpuntomedio";
            this.btnpuntomedio.Size = new System.Drawing.Size(176, 27);
            this.btnpuntomedio.TabIndex = 11;
            this.btnpuntomedio.Text = "Algoritmo Punto Medio";
            this.btnpuntomedio.UseVisualStyleBackColor = false;
            this.btnpuntomedio.Click += new System.EventHandler(this.btnpuntomedio_Click);
            // 
            // btnbresenham
            // 
            this.btnbresenham.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnbresenham.FlatAppearance.BorderSize = 0;
            this.btnbresenham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbresenham.Location = new System.Drawing.Point(44, 80);
            this.btnbresenham.Name = "btnbresenham";
            this.btnbresenham.Size = new System.Drawing.Size(176, 27);
            this.btnbresenham.TabIndex = 10;
            this.btnbresenham.Text = "Algoritmo Bresenham";
            this.btnbresenham.UseVisualStyleBackColor = false;
            this.btnbresenham.Click += new System.EventHandler(this.btnbresenham_Click);
            // 
            // btncalculardda
            // 
            this.btncalculardda.BackColor = System.Drawing.Color.YellowGreen;
            this.btncalculardda.FlatAppearance.BorderSize = 0;
            this.btncalculardda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncalculardda.Location = new System.Drawing.Point(44, 28);
            this.btncalculardda.Name = "btncalculardda";
            this.btncalculardda.Size = new System.Drawing.Size(176, 27);
            this.btncalculardda.TabIndex = 8;
            this.btncalculardda.Text = "Algoritmo DDA";
            this.btncalculardda.UseVisualStyleBackColor = false;
            this.btncalculardda.Click += new System.EventHandler(this.btncalculardda_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picBox);
            this.groupBox2.Location = new System.Drawing.Point(290, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 380);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gráfico";
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(6, 19);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(472, 354);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnpuntomedio);
            this.groupBox3.Controls.Add(this.btncalculardda);
            this.groupBox3.Controls.Add(this.btnbresenham);
            this.groupBox3.Location = new System.Drawing.Point(22, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 181);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Controles";
            // 
            // FormularioLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormularioLineas";
            this.Text = "Algoritmos Trazado de Líneas";
            this.Load += new System.EventHandler(this.FormularioDDA_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtyfinal;
        private System.Windows.Forms.TextBox txtxfinal;
        private System.Windows.Forms.TextBox txtyinicial;
        private System.Windows.Forms.TextBox txtxinicial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btncalculardda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button btnpuntomedio;
        private System.Windows.Forms.Button btnbresenham;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

