using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Algoritmos
{
    /// <summary>
    /// CDDA
    /// Clase que implementa una versión visual y animada del algoritmo DDA (Digital Differential Analyzer)
    /// para el trazado de una línea en una rejilla discreta (celdas).
    /// 
    /// - Lee puntos inicial y final desde TextBoxes (ReadData).
    /// - Calcula los incrementos necesarios según la pendiente.
    /// - Dibuja una malla (grid) y va coloreando las celdas que atraviesa la línea.
    /// - También dibuja una línea conectando los centros de las celdas para referencia.
    /// - El método DrawLineDDAAsync realiza la animación paso a paso usando await Task.Delay.
    /// </summary>
    /// 
    internal class CDDA
    {
        private int xinicial;
        private int yinicial;
        private int xfinal;
        private int yfinal;
        private int cellSize = 20; 
        private List<PointF> puntosLinea = new List<PointF>(); 

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

        private (int dx, int dy) CalcularDxDy()
        {
            int dx = xfinal - xinicial;
            int dy = yfinal - yinicial;
            return (dx, dy);
        }

        private float CalcularPendiente()
        {
            var (dx, dy) = CalcularDxDy();
            float pendiente = (float)dy / dx;
            return pendiente;
        }

        private void DibujarGrid(Graphics g, int width, int height, int gridCols, int gridRows)
        {
            Pen gridPen = new Pen(Color.LightGray, 1);

            for (int x = 0; x <= gridCols; x++)
            {
                g.DrawLine(gridPen, x * cellSize, 0, x * cellSize, height);
            }

            for (int y = 0; y <= gridRows; y++)
            {
                g.DrawLine(gridPen, 0, y * cellSize, width, y * cellSize);
            }

            gridPen.Dispose();
        }

        private PointF ConvertirCoordenadas(float x, float y, int gridRows)
        {
            float screenX = x * cellSize + cellSize / 2;
            float screenY = (gridRows - y - 1) * cellSize + cellSize / 2;
            return new PointF(screenX, screenY);
        }

        private void DibujarCelda(Graphics g, float x, float y, int gridRows)
        {
            int pixelX = (int)Math.Round(x);
            int pixelY = (int)Math.Round(y);

            int screenX = pixelX * cellSize;
            int screenY = (gridRows - pixelY - 1) * cellSize;

            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                g.FillRectangle(brush, screenX + 1, screenY + 1, cellSize - 2, cellSize - 2);
            }
        }

        private void DibujarLinea(Graphics g, int gridRows)
        {
            if (puntosLinea.Count < 2) return;

            using (Pen pen = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < puntosLinea.Count - 1; i++)
                {
                    PointF p1 = ConvertirCoordenadas(puntosLinea[i].X, puntosLinea[i].Y, gridRows);
                    PointF p2 = ConvertirCoordenadas(puntosLinea[i + 1].X, puntosLinea[i + 1].Y, gridRows);
                    g.DrawLine(pen, p1, p2);
                }
            }
        }
        /// <summary>
        /// DrawLineDDAAsync
        /// Método principal que aplica el algoritmo DDA para trazar la línea entre (xinicial,yinicial) y (xfinal,yfinal).
        /// - Prepara un bitmap en base al tamaño de la malla.
        /// - Calcula la pendiente y decide si iterar por X (|m| <= 1) o por Y (|m| > 1).
        /// - En cada paso añade la celda actual a puntosLinea, redespliega la rejilla y las celdas ya atravesadas
        ///   y dibuja una línea conectando los centros (para referencia visual).
        /// - Usa await Task.Delay para animar paso a paso (100ms entre pasos).
        /// </summary>
        public async Task DrawLineDDAAsync(PictureBox picBox)
        {
            puntosLinea.Clear();

            int maxX = Math.Max(xinicial, xfinal);
            int maxY = Math.Max(yinicial, yfinal);

            int gridCols = maxX + 3;
            int gridRows = maxY + 3;

            int bmpWidth = gridCols * cellSize;
            int bmpHeight = gridRows * cellSize;

            picBox.SizeMode = PictureBoxSizeMode.AutoSize;

            Bitmap bmp = new Bitmap(bmpWidth, bmpHeight);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.Clear(Color.White);
            DibujarGrid(g, bmpWidth, bmpHeight, gridCols, gridRows);
            picBox.Image = bmp;

            float m = CalcularPendiente();
            float x = xinicial;
            float y = yinicial;
            var (dx, dy) = CalcularDxDy();

            if (Math.Abs(m) <= 1)
            {
                float yInc = m;
                int xPaso = 1;
                for (int k = 0; k <= Math.Abs(dx); k++)
                {
                    puntosLinea.Add(new PointF(x, y));

                    g.Clear(Color.White);
                    DibujarGrid(g, bmpWidth, bmpHeight, gridCols, gridRows);
                    foreach (var punto in puntosLinea)
                    {
                        DibujarCelda(g, punto.X, punto.Y, gridRows);
                    }
                    DibujarLinea(g, gridRows);
                    picBox.Refresh();
                    await Task.Delay(100);

                    x += xPaso;
                    y += yInc;
                }
            }
            else
            {
                float xInc = 1 / m;
                int yPaso = 1;
                for (int k = 0; k <= Math.Abs(dy); k++)
                {
                    puntosLinea.Add(new PointF(x, y));
                    g.Clear(Color.White);
                    DibujarGrid(g, bmpWidth, bmpHeight, gridCols, gridRows);
                    
                    foreach (var punto in puntosLinea)
                    {
                        DibujarCelda(g, punto.X, punto.Y, gridRows);
                    }
                    DibujarLinea(g, gridRows);

                    picBox.Refresh();
                    await Task.Delay(100);

                    y += yPaso;
                    x += xInc;
                }
            }

            g.Dispose();
        }
    }  
}
