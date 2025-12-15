namespace curvasBezier
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bezierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linealToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cuadraticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bezierToolStripMenuItem,
            this.splineToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bezierToolStripMenuItem
            // 
            this.bezierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linealToolStripMenuItem1,
            this.cuadraticasToolStripMenuItem,
            this.cubicasToolStripMenuItem});
            this.bezierToolStripMenuItem.Name = "bezierToolStripMenuItem";
            this.bezierToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.bezierToolStripMenuItem.Text = "Curvas de Bezier";
            // 
            // linealToolStripMenuItem1
            // 
            this.linealToolStripMenuItem1.Name = "linealToolStripMenuItem1";
            this.linealToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.linealToolStripMenuItem1.Text = "Lineales";
            this.linealToolStripMenuItem1.Click += new System.EventHandler(this.linealToolStripMenuItem1_Click);
            // 
            // cuadraticasToolStripMenuItem
            // 
            this.cuadraticasToolStripMenuItem.Name = "cuadraticasToolStripMenuItem";
            this.cuadraticasToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.cuadraticasToolStripMenuItem.Text = "Cuadráticas";
            this.cuadraticasToolStripMenuItem.Click += new System.EventHandler(this.cuadraticasToolStripMenuItem_Click);
            // 
            // cubicasToolStripMenuItem
            // 
            this.cubicasToolStripMenuItem.Name = "cubicasToolStripMenuItem";
            this.cubicasToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.cubicasToolStripMenuItem.Text = "Cúbicas";
            this.cubicasToolStripMenuItem.Click += new System.EventHandler(this.cubicasToolStripMenuItem_Click);
            // 
            // splineToolStripMenuItem
            // 
            this.splineToolStripMenuItem.Name = "splineToolStripMenuItem";
            this.splineToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.splineToolStripMenuItem.Text = "Curvas de B-Spline";
            this.splineToolStripMenuItem.Click += new System.EventHandler(this.splineToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bezierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linealToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cuadraticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubicasToolStripMenuItem;
    }
}

