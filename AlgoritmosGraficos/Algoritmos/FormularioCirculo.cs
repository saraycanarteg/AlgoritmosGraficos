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
    public partial class FormularioCirculo : Form
    {
        private static FormularioCirculo instancia = null;

        public static FormularioCirculo Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new FormularioCirculo();
                return instancia;
            }
        }

        CCircunferencia circunferencia = new CCircunferencia();
        public FormularioCirculo()
        {
            InitializeComponent();
        }

        private void FormularioCirculo_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Location = new Point(
                    (this.MdiParent.ClientSize.Width - this.Width) / 2,
                    (this.MdiParent.ClientSize.Height - this.Height) / 2
                );
            }
        }

        private void btnPuntoMedio_Click(object sender, EventArgs e)
        {
            circunferencia.ReadData(txtradio);
            circunferencia.DibujarMidpoint(picBox);
        }

        private void btnPolar_Click(object sender, EventArgs e)
        {
            circunferencia.ReadData(txtradio);
            circunferencia.DibujarPolar(picBox);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            circunferencia.Limpiar(picBox);
        }

        private void btnDDA_Click(object sender, EventArgs e)
        {
            circunferencia.ReadData(txtradio);
            circunferencia.DibujarDDA(picBox);
        }
    }
}
