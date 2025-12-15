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
    public partial class FormularioRecorte : Form
    {
        private List<Point> poligono = new List<Point>();
        private List<Point> poligonoRecortado = null;
        private Rectangle ventana;
        private bool dibujandoVentana = false;
        private Point puntoInicioVentana;
        private Bitmap bmp;
        private bool poligonoCerrado = false;
        private CRecortePoligono.TipoAlgoritmo? algoritmoActual = null;

        private static FormularioRecorte instancia = null;

        public static FormularioRecorte Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new FormularioRecorte();
                return instancia;
            }
        }

        public FormularioRecorte()
        {
            InitializeComponent();
            bmp = new Bitmap(picBox.Width, picBox.Height);
            picBox.Image = bmp;

            picBox.MouseDown += picBox_MouseDown;
            picBox.MouseMove += picBox_MouseMove;
            picBox.MouseUp += picBox_MouseUp;
            picBox.Paint += picBox_Paint;
        }

        private void FormularioRecorte_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Location = new Point(
                    (this.MdiParent.ClientSize.Width - this.Width) / 2,
                    (this.MdiParent.ClientSize.Height - this.Height) / 2
                );
            }
        }

        private void btnAgregarPoligono_Click(object sender, EventArgs e)
        {
            poligonoCerrado = false;
            dibujandoVentana = false;
            MessageBox.Show("Haz clics para agregar puntos del polígono.\nCuando termines, presiona 'Definir Ventana'.");
        }

        private void picBox_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
        private Rectangle CrearRectangulo(Point p1, Point p2)
        {
            int x = Math.Min(p1.X, p2.X);
            int y = Math.Min(p1.Y, p2.Y);
            int width = Math.Abs(p2.X - p1.X);
            int height = Math.Abs(p2.Y - p1.Y);
            return new Rectangle(x, y, width, height);
        }

        private void btnDefinirVentana_Click(object sender, EventArgs e)
        {
            if (poligono.Count < 3)
            {
                MessageBox.Show("Primero debes agregar al menos 3 puntos al polígono.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            poligonoCerrado = true;
            dibujandoVentana = true;
            ventana = Rectangle.Empty;
            poligonoRecortado = null;
            algoritmoActual = null;

            picBox.Invalidate();
            MessageBox.Show("Mantén presionado el botón y arrastra para definir la ventana de recorte.",
                "Definir Ventana", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ALGORITMO 1: Sutherland-Hodgman (Original)
        private void btnRecortar_Click(object sender, EventArgs e)
        {
            if (!ValidarRecorte()) return;

            try
            {
                CRecortePoligono algoritmo = new CRecortePoligono(ventana);
                poligonoRecortado = algoritmo.RecortarSutherlandHodgman(poligono);
                algoritmoActual = CRecortePoligono.TipoAlgoritmo.SutherlandHodgman;

                MostrarResultado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            poligono.Clear();
            poligonoRecortado = null;
            ventana = Rectangle.Empty;
            puntoInicioVentana = Point.Empty;
            dibujandoVentana = false;
            poligonoCerrado = false;
            picBox.Invalidate();
        }
        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (dibujandoVentana && e.Button == MouseButtons.Left)
            {
                picBox.Invalidate();
            }
        }


        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Dibujar polígono original
            if (poligono.Count > 0)
            {
                foreach (Point p in poligono)
                {
                    g.FillEllipse(Brushes.LightGray, p.X - 3, p.Y - 3, 6, 6);
                }

                if (poligono.Count > 1)
                {
                    for (int i = 0; i < poligono.Count - 1; i++)
                    {
                        g.DrawLine(new Pen(Color.LightGray, 2), poligono[i], poligono[i + 1]);
                    }
                }

                if (poligonoCerrado && poligono.Count > 2)
                {
                    g.DrawLine(new Pen(Color.LightGray, 2), poligono[poligono.Count - 1], poligono[0]);
                    using (Brush brush = new SolidBrush(Color.FromArgb(30, Color.LightGray)))
                    {
                        g.FillPolygon(brush, poligono.ToArray());
                    }
                }
            }

            // Dibujar ventana de recorte
            if (!ventana.IsEmpty)
            {
                Color colorVentana = algoritmoActual.HasValue ?
                    CRecortePoligono.ObtenerColorVentana(algoritmoActual.Value) :
                    Color.Red;

                using (Pen penVentana = new Pen(colorVentana, algoritmoActual.HasValue ? 3 : 2))
                {
                    if (!algoritmoActual.HasValue)
                        penVentana.DashStyle = DashStyle.Dash;
                    g.DrawRectangle(penVentana, ventana);
                }
            }

            // Preview de ventana mientras se dibuja
            if (dibujandoVentana && Control.MouseButtons == MouseButtons.Left)
            {
                Point mousePos = picBox.PointToClient(Cursor.Position);
                Rectangle previewRect = CrearRectangulo(puntoInicioVentana, mousePos);

                using (Pen penPreview = new Pen(Color.Orange, 2))
                {
                    penPreview.DashStyle = DashStyle.Dot;
                    g.DrawRectangle(penPreview, previewRect);
                }

                using (Font font = new Font("Arial", 8))
                using (Brush brush = new SolidBrush(Color.Orange))
                {
                    g.DrawString($"{previewRect.Width}x{previewRect.Height}", font, brush,
                        mousePos.X + 10, mousePos.Y - 15);
                }
            }

            // Dibujar polígono recortado con color según algoritmo
            if (poligonoRecortado != null && poligonoRecortado.Count > 2 && algoritmoActual.HasValue)
            {
                Color colorAlgoritmo = CRecortePoligono.ObtenerColorAlgoritmo(algoritmoActual.Value);

                // Relleno semi-transparente
                using (Brush brush = new SolidBrush(Color.FromArgb(100, colorAlgoritmo)))
                {
                    g.FillPolygon(brush, poligonoRecortado.ToArray());
                }

                // Borde del polígono recortado
                g.DrawPolygon(new Pen(colorAlgoritmo, 3), poligonoRecortado.ToArray());

                // Vértices del polígono recortado
                Color colorVertices = Color.FromArgb(
                    Math.Max(0, colorAlgoritmo.R - 50),
                    Math.Max(0, colorAlgoritmo.G - 50),
                    Math.Max(0, colorAlgoritmo.B - 50)
                );

                using (Brush brushVertices = new SolidBrush(colorVertices))
                {
                    foreach (Point p in poligonoRecortado)
                    {
                        g.FillEllipse(brushVertices, p.X - 4, p.Y - 4, 8, 8);
                    }
                }
            }
        }

        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (dibujandoVentana)
            {
                puntoInicioVentana = e.Location;
            }
            else if (!poligonoCerrado)
            {
                poligono.Add(e.Location);
                picBox.Invalidate();
            }

        }

        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (dibujandoVentana)
            {
                ventana = CrearRectangulo(puntoInicioVentana, e.Location);

                if (ventana.Width < 10 || ventana.Height < 10)
                {
                    MessageBox.Show("La ventana es demasiado pequeña. Debe ser al menos 10x10 píxeles.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ventana = Rectangle.Empty;
                }
                else
                {
                    MessageBox.Show($"Ventana definida: {ventana.Width}x{ventana.Height}\nAhora presiona 'Recortar'.",
                        "Ventana Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dibujandoVentana = false;
                picBox.Invalidate();
            }
        }

        private void btnCohenSutherland_Click(object sender, EventArgs e)
        {
            if (!ValidarRecorte()) return;

            try
            {
                CRecortePoligono algoritmo = new CRecortePoligono(ventana);
                poligonoRecortado = algoritmo.RecortarCohenSutherland(poligono);
                algoritmoActual = CRecortePoligono.TipoAlgoritmo.CohenSutherland;

                MostrarResultado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWeilerAtherton_Click(object sender, EventArgs e)
        {
            if (!ValidarRecorte()) return;

            try
            {
                CRecortePoligono algoritmo = new CRecortePoligono(ventana);
                poligonoRecortado = algoritmo.RecortarWeilerAtherton(poligono);
                algoritmoActual = CRecortePoligono.TipoAlgoritmo.WeilerAtherton;

                MostrarResultado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarRecorte()
        {
            if (poligono.Count < 3)
            {
                MessageBox.Show("Debes tener un polígono con al menos 3 puntos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ventana.IsEmpty || ventana.Width <= 0 || ventana.Height <= 0)
            {
                MessageBox.Show("Debes definir una ventana de recorte válida primero.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void MostrarResultado()
        {
            if (poligonoRecortado.Count == 0)
            {
                MessageBox.Show($"Algoritmo: {algoritmoActual}\n\nEl polígono está completamente fuera de la ventana de recorte.",
                    "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Algoritmo: {algoritmoActual}\n\n" +
                    $"Vértices originales: {poligono.Count}\n" +
                    $"Vértices recortados: {poligonoRecortado.Count}",
                    "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            picBox.Invalidate();
        }
    }
}
