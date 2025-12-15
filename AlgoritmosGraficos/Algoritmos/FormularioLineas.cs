using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class FormularioLineas : Form
    {
        private static FormularioLineas instancia = null;

        public static FormularioLineas Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new FormularioLineas();
                return instancia;
            }
        }
        private CDDA algoritmoDDA = new CDDA();
        private CBresenham bresenham = new CBresenham();
        private CPuntooMedio puntooMedio = new CPuntooMedio();
        public FormularioLineas()
        {
            InitializeComponent();
        }

        private void btncalculardda_Click(object sender, EventArgs e)
        {
            algoritmoDDA.ReadData(txtxinicial, txtxfinal, txtyinicial, txtyfinal);
            algoritmoDDA.DrawLineDDAAsync(picBox);

        }

        private void btnbresenham_Click(object sender, EventArgs e)
        {
            bresenham.ReadData(txtxinicial, txtxfinal, txtyinicial, txtyfinal);
            bresenham.DrawLineBresenhamAsync(picBox);
        }

        private void btnpuntomedio_Click(object sender, EventArgs e)
        {
            puntooMedio.ReadData(txtxinicial, txtxfinal, txtyinicial, txtyfinal);
            puntooMedio.DrawLinePuntoMedioAsync(picBox);
        }

        private void FormularioDDA_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Location = new Point(
                    (this.MdiParent.ClientSize.Width - this.Width) / 2,
                    (this.MdiParent.ClientSize.Height - this.Height) / 2
                );
            }
        }
    }
}
