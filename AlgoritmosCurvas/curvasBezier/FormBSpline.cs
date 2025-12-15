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
    public partial class FormBSpline : Form
    {
        private static FormBSpline instancia = null;
        private CBSpline curva;
        private Timer timer;
        private float t = 0;
        private bool arrastrando = false;
        private int puntoArrastrado = -1;
        private List<PointF> puntosControl;

        public static FormBSpline Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new FormBSpline();
                return instancia;
            }
        }

        public FormBSpline()
        {
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            this.Text = "Curvas B-Spline";
            this.WindowState = FormWindowState.Maximized;

            puntosControl = new List<PointF>();
            ConfigurarEventos();

            timer = new Timer { Interval = 30 };
            timer.Tick += (s, e) =>
            {
                if (curva == null) return;
                int n = curva.PuntosControl.Count - 1;
                float tMin = curva.VectorNudos[curva.Grado];
                float tMax = curva.VectorNudos[n + 1];

                t += (tMax - tMin) * 0.01f;
                if (t >= tMax)
                {
                    t = tMin;
                    curva?.LimpiarRastro();
                }
                ActualizarDibujo();
            };

            GenerarPuntosIniciales();
            ActualizarListaPuntos();
        }

        private void ConfigurarEventos()
        {
            btnGenerarPuntos.Click += (s, e) =>
            {
                GenerarPuntosIniciales();
                ActualizarListaPuntos();
            };

            btnDibujar.Click += (s, e) =>
            {
                CrearCurva();
                curva?.LimpiarRastro();
                if (curva != null)
                {
                    int n = curva.PuntosControl.Count - 1;
                    t = curva.VectorNudos[curva.Grado];
                }
                ActualizarDibujo();
            };

            btnLimpiar.Click += (s, e) => Limpiar();

            numGrado.ValueChanged += (s, e) =>
            {
                ActualizarInfoGrado();
                if (curva != null)
                {
                    CrearCurva();
                    ActualizarDibujo();
                }
            };

            chkAnimacion.CheckedChanged += (s, e) =>
            {
                if (chkAnimacion.Checked)
                {
                    if (curva != null)
                    {
                        int n = curva.PuntosControl.Count - 1;
                        t = curva.VectorNudos[curva.Grado];
                    }
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
            chkPoligono.CheckedChanged += (s, e) => ActualizarDibujo();
            chkPuntos.CheckedChanged += (s, e) => ActualizarDibujo();

            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += (s, e) => { arrastrando = false; puntoArrastrado = -1; };
            pictureBox.Resize += (s, e) => ActualizarDibujo();

            ActualizarInfoGrado();
        }

        private void GenerarPuntosIniciales()
        {
            puntosControl.Clear();
            int cantidad = (int)numCantidadPuntos.Value;
            int width = pictureBox.Width > 0 ? pictureBox.Width : 800;
            int height = pictureBox.Height > 0 ? pictureBox.Height : 600;

            Random rand = new Random();

            for (int i = 0; i < cantidad; i++)
            {
                float x = 100 + (width - 200) * i / (cantidad - 1);
                float y = height / 2 + rand.Next(-150, 150);
                puntosControl.Add(new PointF(x, y));
            }

            CrearCurva();
            ActualizarDibujo();
        }

        private void ActualizarListaPuntos()
        {
            lstPuntos.Items.Clear();
            for (int i = 0; i < puntosControl.Count; i++)
            {
                lstPuntos.Items.Add($"P{i}: ({puntosControl[i].X:F0}, {puntosControl[i].Y:F0})");
            }
        }

        private void ActualizarInfoGrado()
        {
            int grado = (int)numGrado.Value;
            switch (grado)
            {
                case 2:
                    lblInfo.Text = "Grado 2 = B-Spline Cuadrática";
                    break;
                case 3:
                    lblInfo.Text = "Grado 3 = B-Spline Cúbica";
                    break;
                case 4:
                    lblInfo.Text = "Grado 4 = B-Spline de orden 5";
                    break;
            }
        }

        private void CrearCurva()
        {
            try
            {
                int grado = (int)numGrado.Value;
                if (puntosControl.Count < grado + 1)
                {
                    MessageBox.Show($"Se necesitan al menos {grado + 1} puntos para grado {grado}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                curva = new CBSpline(new List<PointF>(puntosControl), grado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear curva: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            timer.Stop();
            chkAnimacion.Checked = false;
            chkRastro.Checked = false;
            curva?.LimpiarRastro();
            if (curva != null)
            {
                int n = curva.PuntosControl.Count - 1;
                t = curva.VectorNudos[curva.Grado];
            }

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
        private void FormBSpline_Load(object sender, EventArgs e)
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
                puntoArrastrado = curva.ObtenerPuntoMasCercano(e.Location);
                if (puntoArrastrado >= 0)
                {
                    arrastrando = true;
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando && puntoArrastrado >= 0 && curva != null)
            {
                float newX = Math.Max(0, Math.Min(pictureBox.Width, e.X));
                float newY = Math.Max(0, Math.Min(pictureBox.Height, e.Y));

                puntosControl[puntoArrastrado] = new PointF(newX, newY);
                curva.PuntosControl[puntoArrastrado] = new PointF(newX, newY);

                ActualizarListaPuntos();
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

                    curva.Dibujar(g, chkCurva.Checked, chkRastro.Checked, chkAnimacion.Checked,
                                 chkPoligono.Checked, chkPuntos.Checked, t);
                }

                pictureBox.Image?.Dispose();
                pictureBox.Image = bmp;
            }
            catch (Exception ex)
            {

            }
        }
    }
    
}
