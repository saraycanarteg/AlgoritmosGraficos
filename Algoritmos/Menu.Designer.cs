namespace Algoritmos
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.algoritmolineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmocircunferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmorellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmorecorteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recortelineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algoritmolineasToolStripMenuItem,
            this.algoritmocircunferenciaToolStripMenuItem,
            this.algoritmorellenoToolStripMenuItem,
            this.algoritmorecorteToolStripMenuItem,
            this.recortelineasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // algoritmolineasToolStripMenuItem
            // 
            this.algoritmolineasToolStripMenuItem.Name = "algoritmolineasToolStripMenuItem";
            this.algoritmolineasToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.algoritmolineasToolStripMenuItem.Text = "Algoritmos de Lineas";
            this.algoritmolineasToolStripMenuItem.Click += new System.EventHandler(this.algoritmolineasToolStripMenuItem_Click);
            // 
            // algoritmocircunferenciaToolStripMenuItem
            // 
            this.algoritmocircunferenciaToolStripMenuItem.Name = "algoritmocircunferenciaToolStripMenuItem";
            this.algoritmocircunferenciaToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.algoritmocircunferenciaToolStripMenuItem.Text = "Algoritmo Circunferencia";
            this.algoritmocircunferenciaToolStripMenuItem.Click += new System.EventHandler(this.algoritmocircunferenciaToolStripMenuItem_Click);
            // 
            // algoritmorellenoToolStripMenuItem
            // 
            this.algoritmorellenoToolStripMenuItem.Name = "algoritmorellenoToolStripMenuItem";
            this.algoritmorellenoToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.algoritmorellenoToolStripMenuItem.Text = "Algoritmos Relleno";
            this.algoritmorellenoToolStripMenuItem.Click += new System.EventHandler(this.algoritmorellenoToolStripMenuItem_Click);
            // 
            // algoritmorecorteToolStripMenuItem
            // 
            this.algoritmorecorteToolStripMenuItem.Name = "algoritmorecorteToolStripMenuItem";
            this.algoritmorecorteToolStripMenuItem.Size = new System.Drawing.Size(172, 20);
            this.algoritmorecorteToolStripMenuItem.Text = "Algoritmo Recorte Polígonos";
            this.algoritmorecorteToolStripMenuItem.Click += new System.EventHandler(this.algoritmorecorteToolStripMenuItem_Click);
            // 
            // recortelineasToolStripMenuItem
            // 
            this.recortelineasToolStripMenuItem.Name = "recortelineasToolStripMenuItem";
            this.recortelineasToolStripMenuItem.Size = new System.Drawing.Size(157, 20);
            this.recortelineasToolStripMenuItem.Text = "Algoritmos Recorte Lineas";
            this.recortelineasToolStripMenuItem.Click += new System.EventHandler(this.recortelineasToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(834, 551);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem algoritmolineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmocircunferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmorellenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmorecorteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recortelineasToolStripMenuItem;
    }
}