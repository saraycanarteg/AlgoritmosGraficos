using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    /// <summary>
    /// Implementa una versión animada del algoritmo del Punto Medio (Midpoint) para trazar líneas.
    ///
    /// Comportamiento:
    /// - Lee los puntos inicial y final desde TextBoxes (ReadData).
    /// - Calcula los puntos enteros que aproximan la línea usando el método del punto medio.
    /// - Escala y centra la línea dentro del PictureBox para que se vea correctamente.
    /// - Dibuja incrementalmente la línea con pequeñas pausas para mostrar la animación.
    ///
    /// Notas:
    /// - Maneja pendientes en cualquier cuadrante mediante incX / incY (pasos con signo).
    /// - Se distingue el caso dx >= dy (iteración por X) y dx < dy (iteración por Y).
    /// - La conversión a coordenadas de pantalla invierte el eje Y (sistema GDI+).
    /// </summary>
    internal class CPuntooMedio
    {
        private int xinicial;
        private int yinicial;
        private int xfinal;
        private int yfinal;
        private List<Point> puntosLinea = new List<Point>();

        public void ReadData(TextBox txtxinicial, TextBox txtxfinal, TextBox txtyinicial, TextBox txtyfinal)
        {
            try
            {
                xinicial = int.Parse(txtxinicial.Text);
                xfinal = int.Parse(txtxfinal.Text);
                yinicial = int.Parse(txtyinicial.Text);
                yfinal = int.Parse(txtyfinal.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no válido...", "Mensaje de error");
            }
        }

        private Point ConvertirCoordenadas(int x, int y, float escala, int offsetX, int offsetY, int pbHeight)
        {
            int screenX = (int)((x + offsetX) * escala);
            int screenY = (int)(pbHeight - (y + offsetY) * escala);
            return new Point(screenX, screenY);
        }

        private void DibujarLinea(Graphics g, float escala, int offsetX, int offsetY, int pbHeight)
        {
            if (puntosLinea.Count < 2) return;

            using (Pen pen = new Pen(Color.HotPink, 3))
            {
                for (int i = 0; i < puntosLinea.Count - 1; i++)
                {
                    Point p1 = ConvertirCoordenadas(puntosLinea[i].X, puntosLinea[i].Y, escala, offsetX, offsetY, pbHeight);
                    Point p2 = ConvertirCoordenadas(puntosLinea[i + 1].X, puntosLinea[i + 1].Y, escala, offsetX, offsetY, pbHeight);
                    g.DrawLine(pen, p1, p2);
                }
            }
        }

        /// <summary>
        /// DrawLinePuntoMedioAsync
        /// Implementación animada del algoritmo del punto medio:
        /// - Prepara escala y offsets para que la línea quepa en el PictureBox con un margen.
        /// - Calcula dx, dy y los signos de avance incX/incY.
        /// - Dependiendo de la relación dx >= dy se itera por X o por Y.
        /// - En cada paso actualiza la variable de decisión 'd' y agrega el punto calculado a puntosLinea.
        /// - Redibuja el bitmap y refresca el PictureBox con una pequeña espera para animación.
        /// </summary>
        public async Task DrawLinePuntoMedioAsync(PictureBox pb)
        {
            puntosLinea.Clear();

            int minX = Math.Min(xinicial, xfinal);
            int maxX = Math.Max(xinicial, xfinal);
            int minY = Math.Min(yinicial, yfinal);
            int maxY = Math.Max(yinicial, yfinal);

            int rangoX = maxX - minX;
            int rangoY = maxY - minY;

            int margen = 20;
            int totalX = rangoX + margen * 2;
            int totalY = rangoY + margen * 2;

            float escalaX = (float)pb.Width / totalX;
            float escalaY = (float)pb.Height / totalY;
            float escala = Math.Min(escalaX, escalaY);

            int offsetX = margen - minX;
            int offsetY = margen - minY;

            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            pb.Image = bmp;

            int dx = xfinal - xinicial;
            int dy = yfinal - yinicial;

            int incX = (dx >= 0) ? 1 : -1;
            int incY = (dy >= 0) ? 1 : -1;

            dx = Math.Abs(dx);
            dy = Math.Abs(dy);

            int x = xinicial;
            int y = yinicial;

            puntosLinea.Add(new Point(x, y));
            g.Clear(Color.White);
            DibujarLinea(g, escala, offsetX, offsetY, pb.Height);
            pb.Refresh();
            await Task.Delay(50);

            if (dx >= dy)
            {
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);

                for (int i = 0; i < dx; i++)
                {
                    x += incX;

                    if (d <= 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        y += incY;
                        d += incrNE;
                    }

                    puntosLinea.Add(new Point(x, y));
                    g.Clear(Color.White);
                    DibujarLinea(g, escala, offsetX, offsetY, pb.Height);
                    pb.Refresh();
                    await Task.Delay(50);
                }
            }
            else
            {
                int d = 2 * dx - dy;
                int incrN = 2 * dx;
                int incrNE = 2 * (dx - dy);

                for (int i = 0; i < dy; i++)
                {
                    y += incY;

                    if (d <= 0)
                    {
                        d += incrN;
                    }
                    else
                    {
                        x += incX;
                        d += incrNE;
                    }

                    puntosLinea.Add(new Point(x, y));
                    g.Clear(Color.White);
                    DibujarLinea(g, escala, offsetX, offsetY, pb.Height);
                    pb.Refresh();
                    await Task.Delay(50);
                }
            }

            g.Dispose();
        }
    }
      
}
