namespace Algoritmos
{
    partial class FormularioRecorte
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWeilerAtherton = new System.Windows.Forms.Button();
            this.btnCohenSutherland = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.btnDefinirVentana = new System.Windows.Forms.Button();
            this.btnAgregarPoligono = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(6, 33);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(496, 337);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
            this.picBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseClick);
            this.picBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            this.picBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseMove);
            this.picBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnDefinirVentana);
            this.groupBox1.Controls.Add(this.btnAgregarPoligono);
            this.groupBox1.Location = new System.Drawing.Point(26, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 180);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // btnWeilerAtherton
            // 
            this.btnWeilerAtherton.BackColor = System.Drawing.Color.Plum;
            this.btnWeilerAtherton.FlatAppearance.BorderSize = 0;
            this.btnWeilerAtherton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeilerAtherton.Location = new System.Drawing.Point(42, 122);
            this.btnWeilerAtherton.Name = "btnWeilerAtherton";
            this.btnWeilerAtherton.Size = new System.Drawing.Size(121, 25);
            this.btnWeilerAtherton.TabIndex = 5;
            this.btnWeilerAtherton.Text = "WeilerAtherton";
            this.btnWeilerAtherton.UseVisualStyleBackColor = false;
            this.btnWeilerAtherton.Click += new System.EventHandler(this.btnWeilerAtherton_Click);
            // 
            // btnCohenSutherland
            // 
            this.btnCohenSutherland.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCohenSutherland.FlatAppearance.BorderSize = 0;
            this.btnCohenSutherland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCohenSutherland.Location = new System.Drawing.Point(42, 80);
            this.btnCohenSutherland.Name = "btnCohenSutherland";
            this.btnCohenSutherland.Size = new System.Drawing.Size(121, 25);
            this.btnCohenSutherland.TabIndex = 4;
            this.btnCohenSutherland.Text = "Cohen-Sutherland";
            this.btnCohenSutherland.UseVisualStyleBackColor = false;
            this.btnCohenSutherland.Click += new System.EventHandler(this.btnCohenSutherland_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(47, 119);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(111, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.BackColor = System.Drawing.Color.YellowGreen;
            this.btnRecortar.FlatAppearance.BorderSize = 0;
            this.btnRecortar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecortar.Location = new System.Drawing.Point(42, 37);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(121, 25);
            this.btnRecortar.TabIndex = 2;
            this.btnRecortar.Text = "Sutherland-Hodgman.";
            this.btnRecortar.UseVisualStyleBackColor = false;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // btnDefinirVentana
            // 
            this.btnDefinirVentana.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnDefinirVentana.FlatAppearance.BorderSize = 0;
            this.btnDefinirVentana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefinirVentana.Location = new System.Drawing.Point(47, 78);
            this.btnDefinirVentana.Name = "btnDefinirVentana";
            this.btnDefinirVentana.Size = new System.Drawing.Size(111, 23);
            this.btnDefinirVentana.TabIndex = 1;
            this.btnDefinirVentana.Text = "Definir Ventana";
            this.btnDefinirVentana.UseVisualStyleBackColor = false;
            this.btnDefinirVentana.Click += new System.EventHandler(this.btnDefinirVentana_Click);
            // 
            // btnAgregarPoligono
            // 
            this.btnAgregarPoligono.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnAgregarPoligono.FlatAppearance.BorderSize = 0;
            this.btnAgregarPoligono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPoligono.Location = new System.Drawing.Point(47, 39);
            this.btnAgregarPoligono.Name = "btnAgregarPoligono";
            this.btnAgregarPoligono.Size = new System.Drawing.Size(111, 23);
            this.btnAgregarPoligono.TabIndex = 0;
            this.btnAgregarPoligono.Text = "Agregar Polígono";
            this.btnAgregarPoligono.UseVisualStyleBackColor = false;
            this.btnAgregarPoligono.Click += new System.EventHandler(this.btnAgregarPoligono_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnWeilerAtherton);
            this.groupBox2.Controls.Add(this.btnRecortar);
            this.groupBox2.Controls.Add(this.btnCohenSutherland);
            this.groupBox2.Location = new System.Drawing.Point(31, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 190);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritmos de Recorte Polígonos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picBox);
            this.groupBox3.Location = new System.Drawing.Point(263, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(508, 380);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gráfico";
            // 
            // FormularioRecorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormularioRecorte";
            this.Text = "FormularioRecorte";
            this.Load += new System.EventHandler(this.FormularioRecorte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button btnDefinirVentana;
        private System.Windows.Forms.Button btnAgregarPoligono;
        private System.Windows.Forms.Button btnWeilerAtherton;
        private System.Windows.Forms.Button btnCohenSutherland;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}