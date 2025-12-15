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

namespace curvasBezier
{
    public partial class FormBezierLineal : Form
    {
        private static FormBezierLineal instancia = null;
        private CBezierLineal curva;
        private Timer timer;
        private float t = 0;
        private bool arrastrando = false;
        private bool arrastandoP0 = false;


        public static FormBezierLineal Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new FormBezierLineal();
                return instancia;
            }
        }

        public FormBezierLineal()
        {
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            this.Text = "Curvas de Bézier Lineales";
            this.WindowState = FormWindowState.Maximized;

            ConfigurarEventos();

            timer = new Timer { Interval = 30 };
            timer.Tick += (s, e) => { t += 0.01f; if (t > 1.0f) { t = 0; curva?.LimpiarRastro(); } ActualizarDibujo(); };

            CrearCurvaInicial();
            ActualizarDibujo();
        }

        private void FormBezierLineal_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Location = new Point(
                    (this.MdiParent.ClientSize.Width - this.Width) / 2,
                    (this.MdiParent.ClientSize.Height - this.Height) / 2
                );
            }
        }
        private void ConfigurarEventos()
        {
            //btnDibujar.Click += (s, e) => { CrearCurvaInicial(); curva.LimpiarRastro(); t = 0; ActualizarDibujo(); };
            btnLimpiar.Click += (s, e) => Limpiar();

            numP0X.ValueChanged += (s, e) => ActualizarPuntos();
            numP0Y.ValueChanged += (s, e) => ActualizarPuntos();
            numP1X.ValueChanged += (s, e) => ActualizarPuntos();
            numP1Y.ValueChanged += (s, e) => ActualizarPuntos();

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
            chkRastro.CheckedChanged += (s, e) => { if (!chkRastro.Checked) curva?.LimpiarRastro(); ActualizarDibujo(); };
            chkCurva.CheckedChanged += (s, e) => ActualizarDibujo();

            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += (s, e) => { arrastrando = false; arrastandoP0 = false; };
            pictureBox.Resize += (s, e) => ActualizarDibujo();
        }

        private void CrearCurvaInicial()
        {
            PointF p0 = new PointF((float)numP0X.Value, (float)numP0Y.Value);
            PointF p1 = new PointF((float)numP1X.Value, (float)numP1Y.Value);
            curva = new CBezierLineal(p0, p1);
        }

        private void ActualizarPuntos()
        {
            if (curva != null)
            {
                curva.P0 = new PointF((float)numP0X.Value, (float)numP0Y.Value);
                curva.P1 = new PointF((float)numP1X.Value, (float)numP1Y.Value);
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

                    curva.Dibujar(g, chkCurva.Checked, chkRastro.Checked, chkAnimacion.Checked, t);
                }

                pictureBox.Image?.Dispose();
                pictureBox.Image = bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DibujarPunto(Graphics g, PointF punto, Color color, string label)
        {
            using (Brush b = new SolidBrush(color))
            using (Pen pen = new Pen(Color.Black, 1))
            using (Font f = new Font("Arial", 9, FontStyle.Bold))
            using (Brush bt = new SolidBrush(Color.Black))
            {
                g.FillEllipse(b, punto.X - 5, punto.Y - 5, 10, 10);
                g.DrawEllipse(pen, punto.X - 5, punto.Y - 5, 10, 10);
                g.DrawString(label, f, bt, punto.X + 8, punto.Y - 8);
            }
        }

        private void FormBezierLineal_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer?.Stop();
            timer?.Dispose();
            pictureBox.Image?.Dispose();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && curva != null)
            {
                if (curva.DistanciaAPunto(e.Location, curva.P0) < 10)
                {
                    arrastrando = true;
                    arrastandoP0 = true;
                }
                else if (curva.DistanciaAPunto(e.Location, curva.P1) < 10)
                {
                    arrastrando = true;
                    arrastandoP0 = false;
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando && curva != null)
            {
                float newX = Math.Max(0, Math.Min(pictureBox.Width, e.X));
                float newY = Math.Max(0, Math.Min(pictureBox.Height, e.Y));

                if (arrastandoP0)
                {
                    curva.P0 = new PointF(newX, newY);
                    numP0X.Value = (decimal)newX;
                    numP0Y.Value = (decimal)newY;
                }
                else
                {
                    curva.P1 = new PointF(newX, newY);
                    numP1X.Value = (decimal)newX;
                    numP1Y.Value = (decimal)newY;
                }

                ActualizarDibujo();
            }

        }
    }
}
