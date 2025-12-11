namespace Algoritmos
{
    partial class FormRecorteLineas
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDibujarLineas = new System.Windows.Forms.Button();
            this.btnTerminarLineas = new System.Windows.Forms.Button();
            this.btnDefinirVentana = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grbRecorte = new System.Windows.Forms.GroupBox();
            this.btnCohenSutherland = new System.Windows.Forms.Button();
            this.btnLiangBarsky = new System.Windows.Forms.Button();
            this.btnNichollLeeNichol = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbRecorte.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(17, 31);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(392, 362);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnDefinirVentana);
            this.groupBox1.Controls.Add(this.btnTerminarLineas);
            this.groupBox1.Controls.Add(this.btnDibujarLineas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Botones de control";
            // 
            // btnDibujarLineas
            // 
            this.btnDibujarLineas.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnDibujarLineas.FlatAppearance.BorderSize = 0;
            this.btnDibujarLineas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDibujarLineas.Location = new System.Drawing.Point(88, 31);
            this.btnDibujarLineas.Name = "btnDibujarLineas";
            this.btnDibujarLineas.Size = new System.Drawing.Size(118, 23);
            this.btnDibujarLineas.TabIndex = 0;
            this.btnDibujarLineas.Text = "Dibujar Lineas";
            this.btnDibujarLineas.UseVisualStyleBackColor = false;
            this.btnDibujarLineas.Click += new System.EventHandler(this.btnDibujarLineas_Click);
            // 
            // btnTerminarLineas
            // 
            this.btnTerminarLineas.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnTerminarLineas.FlatAppearance.BorderSize = 0;
            this.btnTerminarLineas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminarLineas.Location = new System.Drawing.Point(88, 69);
            this.btnTerminarLineas.Name = "btnTerminarLineas";
            this.btnTerminarLineas.Size = new System.Drawing.Size(118, 23);
            this.btnTerminarLineas.TabIndex = 1;
            this.btnTerminarLineas.Text = "Terminar Lineas";
            this.btnTerminarLineas.UseVisualStyleBackColor = false;
            this.btnTerminarLineas.Click += new System.EventHandler(this.btnTerminarLineas_Click);
            // 
            // btnDefinirVentana
            // 
            this.btnDefinirVentana.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnDefinirVentana.FlatAppearance.BorderSize = 0;
            this.btnDefinirVentana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefinirVentana.Location = new System.Drawing.Point(88, 109);
            this.btnDefinirVentana.Name = "btnDefinirVentana";
            this.btnDefinirVentana.Size = new System.Drawing.Size(118, 23);
            this.btnDefinirVentana.TabIndex = 2;
            this.btnDefinirVentana.Text = "Definir Ventana";
            this.btnDefinirVentana.UseVisualStyleBackColor = false;
            this.btnDefinirVentana.Click += new System.EventHandler(this.btnDefinirVentana_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(88, 145);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(118, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(88, 179);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(118, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grbRecorte
            // 
            this.grbRecorte.Controls.Add(this.btnNichollLeeNichol);
            this.grbRecorte.Controls.Add(this.btnLiangBarsky);
            this.grbRecorte.Controls.Add(this.btnCohenSutherland);
            this.grbRecorte.Location = new System.Drawing.Point(12, 235);
            this.grbRecorte.Name = "grbRecorte";
            this.grbRecorte.Size = new System.Drawing.Size(296, 150);
            this.grbRecorte.TabIndex = 1;
            this.grbRecorte.TabStop = false;
            this.grbRecorte.Text = "Botones de recorte";
            // 
            // btnCohenSutherland
            // 
            this.btnCohenSutherland.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCohenSutherland.FlatAppearance.BorderSize = 0;
            this.btnCohenSutherland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCohenSutherland.Location = new System.Drawing.Point(77, 30);
            this.btnCohenSutherland.Name = "btnCohenSutherland";
            this.btnCohenSutherland.Size = new System.Drawing.Size(132, 25);
            this.btnCohenSutherland.TabIndex = 0;
            this.btnCohenSutherland.Text = "Cohen Sutherland";
            this.btnCohenSutherland.UseVisualStyleBackColor = false;
            this.btnCohenSutherland.Click += new System.EventHandler(this.btnCohenSutherland_Click);
            // 
            // btnLiangBarsky
            // 
            this.btnLiangBarsky.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLiangBarsky.FlatAppearance.BorderSize = 0;
            this.btnLiangBarsky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiangBarsky.Location = new System.Drawing.Point(77, 68);
            this.btnLiangBarsky.Name = "btnLiangBarsky";
            this.btnLiangBarsky.Size = new System.Drawing.Size(132, 25);
            this.btnLiangBarsky.TabIndex = 1;
            this.btnLiangBarsky.Text = "Liang Barsky";
            this.btnLiangBarsky.UseVisualStyleBackColor = false;
            this.btnLiangBarsky.Click += new System.EventHandler(this.btnLiangBarsky_Click);
            // 
            // btnNichollLeeNichol
            // 
            this.btnNichollLeeNichol.BackColor = System.Drawing.Color.Plum;
            this.btnNichollLeeNichol.FlatAppearance.BorderSize = 0;
            this.btnNichollLeeNichol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNichollLeeNichol.Location = new System.Drawing.Point(77, 105);
            this.btnNichollLeeNichol.Name = "btnNichollLeeNichol";
            this.btnNichollLeeNichol.Size = new System.Drawing.Size(132, 25);
            this.btnNichollLeeNichol.TabIndex = 2;
            this.btnNichollLeeNichol.Text = "Nicholl Lee Nichol";
            this.btnNichollLeeNichol.UseVisualStyleBackColor = false;
            this.btnNichollLeeNichol.Click += new System.EventHandler(this.btnNichollLeeNichol_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(9, 414);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(209, 13);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Haz clic en \'Dibujar Líneas\' para comenzar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.grbRecorte);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 450);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picCanvas);
            this.groupBox2.Location = new System.Drawing.Point(344, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 415);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gráfica";
            // 
            // FormRecorteLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Name = "FormRecorteLineas";
            this.Text = "FormRecorteLineas";
            this.Load += new System.EventHandler(this.FormRecorteLineas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grbRecorte.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnDefinirVentana;
        private System.Windows.Forms.Button btnTerminarLineas;
        private System.Windows.Forms.Button btnDibujarLineas;
        private System.Windows.Forms.GroupBox grbRecorte;
        private System.Windows.Forms.Button btnNichollLeeNichol;
        private System.Windows.Forms.Button btnLiangBarsky;
        private System.Windows.Forms.Button btnCohenSutherland;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}