namespace Algoritmos
{
    partial class FormularioCirculo
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnPolar = new System.Windows.Forms.Button();
            this.btnDDA = new System.Windows.Forms.Button();
            this.btnPuntoMedio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtradio = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picBox);
            this.groupBox2.Location = new System.Drawing.Point(303, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 380);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gráfico";
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(7, 20);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(472, 354);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtradio);
            this.groupBox1.Location = new System.Drawing.Point(23, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entradas";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(47, 97);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(176, 23);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnPolar
            // 
            this.btnPolar.BackColor = System.Drawing.Color.Plum;
            this.btnPolar.FlatAppearance.BorderSize = 0;
            this.btnPolar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPolar.Location = new System.Drawing.Point(47, 153);
            this.btnPolar.Name = "btnPolar";
            this.btnPolar.Size = new System.Drawing.Size(176, 23);
            this.btnPolar.TabIndex = 12;
            this.btnPolar.Text = "Algoritmo Polar";
            this.btnPolar.UseVisualStyleBackColor = false;
            this.btnPolar.Click += new System.EventHandler(this.btnPolar_Click);
            // 
            // btnDDA
            // 
            this.btnDDA.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDDA.FlatAppearance.BorderSize = 0;
            this.btnDDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDDA.Location = new System.Drawing.Point(47, 102);
            this.btnDDA.Name = "btnDDA";
            this.btnDDA.Size = new System.Drawing.Size(176, 23);
            this.btnDDA.TabIndex = 11;
            this.btnDDA.Text = "Algoritmo DDA";
            this.btnDDA.UseVisualStyleBackColor = false;
            this.btnDDA.Click += new System.EventHandler(this.btnDDA_Click);
            // 
            // btnPuntoMedio
            // 
            this.btnPuntoMedio.BackColor = System.Drawing.Color.YellowGreen;
            this.btnPuntoMedio.FlatAppearance.BorderSize = 0;
            this.btnPuntoMedio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPuntoMedio.Location = new System.Drawing.Point(47, 55);
            this.btnPuntoMedio.Name = "btnPuntoMedio";
            this.btnPuntoMedio.Size = new System.Drawing.Size(176, 23);
            this.btnPuntoMedio.TabIndex = 10;
            this.btnPuntoMedio.Text = "Algoritmo Punto Medio";
            this.btnPuntoMedio.UseVisualStyleBackColor = false;
            this.btnPuntoMedio.Click += new System.EventHandler(this.btnPuntoMedio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Radio:";
            // 
            // txtradio
            // 
            this.txtradio.Location = new System.Drawing.Point(117, 36);
            this.txtradio.Name = "txtradio";
            this.txtradio.Size = new System.Drawing.Size(106, 20);
            this.txtradio.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPuntoMedio);
            this.groupBox3.Controls.Add(this.btnDDA);
            this.groupBox3.Controls.Add(this.btnPolar);
            this.groupBox3.Location = new System.Drawing.Point(23, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 215);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Algoritmos de Trazado de Círculos";
            // 
            // FormularioCirculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormularioCirculo";
            this.Text = "FormularioBresenham";
            this.Load += new System.EventHandler(this.FormularioCirculo_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPuntoMedio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtradio;
        private System.Windows.Forms.Button btnPolar;
        private System.Windows.Forms.Button btnDDA;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}