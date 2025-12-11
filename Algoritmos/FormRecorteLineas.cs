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
    public partial class FormRecorteLineas : Form
    {
        private static FormRecorteLineas instancia = null;
        private CRecorteLineas recorte;

        public static FormRecorteLineas Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new FormRecorteLineas();
                return instancia;
            }
        }
        public FormRecorteLineas()
        {
            InitializeComponent();
            recorte = new CRecorteLineas(picCanvas);
            ActualizarEstadoBotones();
            ActualizarEstado();

            picCanvas.MouseDown += (s, e) => { recorte.OnMouseDown(e); ActualizarEstadoBotones(); ActualizarEstado(); };
            picCanvas.MouseMove += (s, e) => recorte.OnMouseMove(e);
            picCanvas.MouseUp += (s, e) => { recorte.OnMouseUp(e); ActualizarEstadoBotones(); ActualizarEstado(); };
        }

        private void FormRecorteLineas_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Location = new Point(
                    (this.MdiParent.ClientSize.Width - this.Width) / 2,
                    (this.MdiParent.ClientSize.Height - this.Height) / 2
                );
            }

        }

        private void btnDibujarLineas_Click(object sender, EventArgs e)
        {
            recorte.IniciarDibujoLineas();
            ActualizarEstadoBotones();
            ActualizarEstado();
        }

        private void btnTerminarLineas_Click(object sender, EventArgs e)
        {
            recorte.TerminarDibujoLineas();
            ActualizarEstadoBotones();
            ActualizarEstado();
        }

        private void btnDefinirVentana_Click(object sender, EventArgs e)
        {
            recorte.IniciarDefinicionVentana();
            ActualizarEstadoBotones();
            ActualizarEstado();
        }

        private void btnCohenSutherland_Click(object sender, EventArgs e)
        {
            recorte.AplicarRecorte(CRecorteLineas.TipoAlgoritmo.CohenSutherland);
            lblEstado.Text = "Recorte aplicado: Cohen-Sutherland (Azul)";
        }

        private void btnLiangBarsky_Click(object sender, EventArgs e)
        {
            recorte.AplicarRecorte(CRecorteLineas.TipoAlgoritmo.LiangBarsky);
            lblEstado.Text = "Recorte aplicado: Liang-Barsky (Verde)";
        }

        private void btnNichollLeeNichol_Click(object sender, EventArgs e)
        {
            recorte.AplicarRecorte(CRecorteLineas.TipoAlgoritmo.NichollLeeNichol);
            lblEstado.Text = "Recorte aplicado: Nicholl-Lee-Nichol (Naranja)";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            recorte.LimpiarTodo();
            ActualizarEstadoBotones();
            ActualizarEstado();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            recorte.Reset();
            ActualizarEstado();
        }
        private void ActualizarEstadoBotones()
        {
            CRecorteLineas.EstadoApp estado = recorte.Estado;
            bool tieneLineas = recorte.CantidadLineas > 0;
            bool tieneVentana = recorte.TieneVentana;

            btnDibujarLineas.Enabled = (estado == CRecorteLineas.EstadoApp.Inicial);
            btnTerminarLineas.Enabled = (estado == CRecorteLineas.EstadoApp.DibujandoLineas);
            btnDefinirVentana.Enabled = (estado == CRecorteLineas.EstadoApp.Inicial && tieneLineas);

            bool habilitarRecorte = (estado == CRecorteLineas.EstadoApp.VentanaDefinida && tieneVentana);
            btnCohenSutherland.Enabled = habilitarRecorte;
            btnLiangBarsky.Enabled = habilitarRecorte;
            btnNichollLeeNichol.Enabled = habilitarRecorte;

            btnReset.Enabled = tieneLineas;
        }
        private void ActualizarEstado()
        {
            lblEstado.Text = recorte.ObtenerMensajeEstado();
        }

    }
    
}
