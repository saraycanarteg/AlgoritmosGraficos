using AlgoritmoRelleno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class Menu : Form
    {
        private void CerrarFormulariosHijos()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }
        public Menu()
        {
            InitializeComponent();
        }

        private void algoritmolineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FormularioLineas FormularioDDA = FormularioLineas.Instancia;
            FormularioDDA.MdiParent = this;
            FormularioDDA.BringToFront();
            FormularioDDA.Show();
        }

        private void algoritmocircunferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FormularioCirculo FormularioCirculo = FormularioCirculo.Instancia;
            FormularioCirculo.MdiParent = this;
            FormularioCirculo.BringToFront();
            FormularioCirculo.Show();
        }

        private void algoritmorellenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FormularioRelleno formulariorelleno = FormularioRelleno.Instancia;
            formulariorelleno.MdiParent = this;
            formulariorelleno.BringToFront();
            formulariorelleno.Show();
        }

        private void algoritmorecorteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FormularioRecorte FormularioRecorte = FormularioRecorte.Instancia;
            FormularioRecorte.MdiParent = this;
            FormularioRecorte.BringToFront();
            FormularioRecorte.Show();
        }

        private void recortelineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FormRecorteLineas FormRecorteLineas = FormRecorteLineas.Instancia;
            FormRecorteLineas.MdiParent = this;
            FormRecorteLineas.BringToFront();
            FormRecorteLineas.Show();
        }
    }
}
