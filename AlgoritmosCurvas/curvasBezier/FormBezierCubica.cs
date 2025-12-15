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
    public partial class FormBezierCubica : Form
    {
        private static FormBezierCubica instancia = null;
        private CBezierCubica curva;
        private Timer timer;
        private float t = 0;
        private bool arrastrando = false;
        private int puntoArrastrado = -1;

        public static FormBezierCubica Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new FormBezierCubica();
                return instancia;
            }
        }
        public FormBezierCubica()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            this.Text = "Curvas de Bézier Cúbicas";
            this.WindowState = FormWindowState.Maximized;

            ConfigurarEventos();

            timer = new Timer { Interval = 30 };
            timer.Tick += (s, e) =>
            {
                t += 0.01f;
                if (t > 1.0f)
                {
                    t = 0;
                    curva?.LimpiarRastro();
                }
                ActualizarDibujo();
            };

            CrearCurvaInicial();
            ActualizarDibujo();
        }

        private void ConfigurarEventos()
        {
            btnLimpiar.Click += (s, e) => Limpiar();

            numP0X.ValueChanged += (s, e) => ActualizarPuntos();
            numP0Y.ValueChanged += (s, e) => ActualizarPuntos();
            numP1X.ValueChanged += (s, e) => ActualizarPuntos();
            numP1Y.ValueChanged += (s, e) => ActualizarPuntos();
            numP2X.ValueChanged += (s, e) => ActualizarPuntos();
            numP2Y.ValueChanged += (s, e) => ActualizarPuntos();
            numP3X.ValueChanged += (s, e) => ActualizarPuntos();
            numP3Y.ValueChanged += (s, e) => ActualizarPuntos();

            chkAnimacion.CheckedChanged += (s, e) =>
            {
                if (chkAnimacion.Checked)
                {
                    t = 0;
                    curva?.LimpiarRastro();
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                    ActualizarDibujo();
                }
            };
            chkRastro.CheckedChanged += (s, e) =>
            {
                if (!chkRastro.Checked)
                    curva?.LimpiarRastro();
                ActualizarDibujo();
            };
            chkCurva.CheckedChanged += (s, e) => ActualizarDibujo();
            chkConstruccion.CheckedChanged += (s, e) => ActualizarDibujo();

            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += (s, e) => { arrastrando = false; puntoArrastrado = -1; };
            pictureBox.Resize += (s, e) => ActualizarDibujo();
        }

        private void CrearCurvaInicial()
        {
            PointF p0 = new PointF((float)numP0X.Value, (float)numP0Y.Value);
            PointF p1 = new PointF((float)numP1X.Value, (float)numP1Y.Value);
            PointF p2 = new PointF((float)numP2X.Value, (float)numP2Y.Value);
            PointF p3 = new PointF((float)numP3X.Value, (float)numP3Y.Value);
            curva = new CBezierCubica(p0, p1, p2, p3);
        }

        private void ActualizarPuntos()
        {
            if (curva != null)
            {
                curva.P0 = new PointF((float)numP0X.Value, (float)numP0Y.Value);
                curva.P1 = new PointF((float)numP1X.Value, (float)numP1Y.Value);
                curva.P2 = new PointF((float)numP2X.Value, (float)numP2Y.Value);
                curva.P3 = new PointF((float)numP3X.Value, (float)numP3Y.Value);
                ActualizarDibujo();
            }
        }

        private void Limpiar()
        {
            timer.Stop();
            chkAnimacion.Checked = false;
            chkRastro.Checked = false;
            curva?.LimpiarRastro();
            t = 0;

            if (pictureBox.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                }
                pictureBox.Image?.Dispose();
                pictureBox.Image = bmp;
            }
        }


        private void FormBezierCubica_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Location = new Point(
                    (this.MdiParent.ClientSize.Width - this.Width) / 2,
                    (this.MdiParent.ClientSize.Height - this.Height) / 2
                );
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && curva != null)
            {
                if (curva.DistanciaAPunto(e.Location, curva.P0) < 10)
                {
                    arrastrando = true;
                    puntoArrastrado = 0;
                }
                else if (curva.DistanciaAPunto(e.Location, curva.P1) < 10)
                {
                    arrastrando = true;
                    puntoArrastrado = 1;
                }
                else if (curva.DistanciaAPunto(e.Location, curva.P2) < 10)
                {
                    arrastrando = true;
                    puntoArrastrado = 2;
                }
                else if (curva.DistanciaAPunto(e.Location, curva.P3) < 10)
                {
                    arrastrando = true;
                    puntoArrastrado = 3;
                }
            }

        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando && curva != null)
            {
                float newX = Math.Max(0, Math.Min(pictureBox.Width, e.X));
                float newY = Math.Max(0, Math.Min(pictureBox.Height, e.Y));

                switch (puntoArrastrado)
                {
                    case 0:
                        curva.P0 = new PointF(newX, newY);
                        numP0X.Value = (decimal)newX;
                        numP0Y.Value = (decimal)newY;
                        break;
                    case 1:
                        curva.P1 = new PointF(newX, newY);
                        numP1X.Value = (decimal)newX;
                        numP1Y.Value = (decimal)newY;
                        break;
                    case 2:
                        curva.P2 = new PointF(newX, newY);
                        numP2X.Value = (decimal)newX;
                        numP2Y.Value = (decimal)newY;
                        break;
                    case 3:
                        curva.P3 = new PointF(newX, newY);
                        numP3X.Value = (decimal)newX;
                        numP3Y.Value = (decimal)newY;
                        break;
                }

                ActualizarDibujo();
            }

        }

        private void ActualizarDibujo()
        {
            try
            {
                if (pictureBox.Width <= 0 || pictureBox.Height <= 0 || curva == null) return;
                if (!curva.ValidarPuntos()) return;

                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    if (chkAnimacion.Checked && chkRastro.Checked)
                    {
                        curva.AgregarRastro(curva.CalcularPunto(t));
                    }

                    curva.Dibujar(g, chkCurva.Checked, chkRastro.Checked, chkAnimacion.Checked, chkConstruccion.Checked, t);
                }

                pictureBox.Image?.Dispose();
                pictureBox.Image = bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
