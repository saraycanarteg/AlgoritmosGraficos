using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    /// <summary>
    /// CBresenham
    /// Implementa una versión animada del algoritmo de Bresenham para rasterizar (trazar)
    /// una línea entre dos puntos en coordenadas enteras.
    ///
    /// Comportamiento:
    /// - Lee los puntos inicial y final desde TextBoxes (ReadData).
    /// - Calcula el conjunto de puntos enteros que aproximan la línea mediante Bresenham.
    /// - Dibuja incrementalmente la línea en un PictureBox, escalando y centrando la vista.
    /// - Usa await Task.Delay para animar paso a paso.
    /// 
    /// Notas:
    /// - Maneja líneas con pendiente pronunciada intercambiando dx y dy.
    /// - Considera signos sx/sy para avanzar en direcciones negativas.
    /// - Convierte coordenadas del "sistema de celdas" a coordenadas de pantalla.
    /// </summary>
    internal class CBresenham
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

            using (Pen pen = new Pen(Color.Blue, 3))
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
        /// DrawLineBresenhamAsync
        /// Implementación principal del algoritmo de Bresenham con animación:
        /// - Prepara el lienzo (Bitmap) y calcula escala/offset para que la línea quepa en el PictureBox.
        /// - Inicializa variables (dx, dy, sx, sy) y detecta si la pendiente es pronunciada.
        /// - Recorre dx pasos (después de intercambiar si pendiente pronunciada) y realiza las decisiones
        ///   sobre cuando incrementar la coordenada secundaria según la variable de decisión D.
        /// - En cada iteración agrega el punto calculado a puntosLinea y redibuja la imagen.
        /// </summary>
        public async Task DrawLineBresenhamAsync(PictureBox pb)
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

            int x = xinicial;
            int y = yinicial;
            int dx = Math.Abs(xfinal - xinicial);
            int dy = Math.Abs(yfinal - yinicial);
            int sx = (xfinal >= xinicial) ? 1 : -1;
            int sy = (yfinal >= yinicial) ? 1 : -1;

            bool pendientePronunciada = dy > dx;

            if (pendientePronunciada)
            {
                int temp = dx;
                dx = dy;
                dy = temp;
            }

            int D = 2 * dy - dx;

            puntosLinea.Add(new Point(x, y));
            g.Clear(Color.White);
            DibujarLinea(g, escala, offsetX, offsetY, pb.Height);
            pb.Refresh();
            await Task.Delay(50);

            for (int i = 1; i <= dx; i++)
            {
                if (pendientePronunciada)
                    y += sy;
                else
                    x += sx;

                if (D > 0)
                {
                    if (pendientePronunciada)
                        x += sx;
                    else
                        y += sy;

                    D = D + 2 * dy - 2 * dx;
                }
                else
                {
                    D = D + 2 * dy;
                }

                puntosLinea.Add(new Point(x, y));
                g.Clear(Color.White);
                DibujarLinea(g, escala, offsetX, offsetY, pb.Height);
                pb.Refresh();
                await Task.Delay(50);
            }

            g.Dispose();
        }
    }
}
