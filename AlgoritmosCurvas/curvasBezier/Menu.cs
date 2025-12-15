using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curvasBezier
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void CerrarFormulariosHijos()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }
        private void Menu_Load(object sender, EventArgs e)
        {
        }

        private void linealToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FormBezierLineal FormBezierLineal = FormBezierLineal.Instancia;
            FormBezierLineal.MdiParent = this;
            FormBezierLineal.BringToFront();
            FormBezierLineal.Show();
        }

        private void cuadraticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FormBezierCuadratico FormBezierCuadratico = FormBezierCuadratico.Instancia;
            FormBezierCuadratico.MdiParent = this;
            FormBezierCuadratico.BringToFront();
            FormBezierCuadratico.Show();
        }

        private void cubicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FormBezierCubica FormBezierCubica = FormBezierCubica.Instancia;
            FormBezierCubica.MdiParent = this;
            FormBezierCubica.BringToFront();
            FormBezierCubica.Show();
        }

        private void splineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FormBSpline FormBSpline = FormBSpline.Instancia;
            FormBSpline.MdiParent = this;
            FormBSpline.BringToFront();
            FormBSpline.Show();
        }
    }
}
