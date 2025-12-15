using System;
using System.Drawing;
using System.Windows.Forms;

namespace Algoritmos
{
    internal class CCircunferencia
    {
        private int radio;
        private Graphics g;

        private SolidBrush drawBrush = new SolidBrush(Color.Black);
        private int pointSize = 1;

        public void ReadData(TextBox txtradio)
        {
            try
            {
                radio = int.Parse(txtradio.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no válido...", "Mensaje de error");
            }
        }

        private (int xcentro, int ycentro) calcularCentro(PictureBox picBox)
        {
            int xcentro = picBox.Width / 2;
            int ycentro = picBox.Height / 2;
            return (xcentro, ycentro);
        }

        public void SetGraphics(Graphics graphics)
        {
            g = graphics;
        }

        public void DrawPoint(int x, int y)
        {
            if (g == null)
                return;

            int half = Math.Max(0, pointSize / 2);
            try
            {
                g.FillRectangle(drawBrush, x - half, y - half, pointSize, pointSize);
            }
            catch
            {
                // Defensive: do not throw from low-level plotting.
            }
        }

        public void Limpiar(PictureBox pic)
        {
            g = pic.CreateGraphics();
            try
            {
                g.Clear(Color.White);
            }
            catch
            {
                // Ignore drawing errors on clear.
            }
        }

        private void SetDrawStyle(Color color, int size)
        {
            try
            {
                drawBrush?.Dispose();
            }
            catch { }
            drawBrush = new SolidBrush(color);
            pointSize = Math.Max(1, size);
        }

        /// <summary>
        /// ALGORITMO 1: Punto Medio (Midpoint Circle Algorithm)
        /// - Variante entera del algoritmo del punto medio para circunferencias.
        /// - Dibuja los 8 octantes aprovechando la simetría del círculo (Plot8Points).
        /// </summary>
        public void DibujarMidpoint(PictureBox pic)
        {
            g = pic.CreateGraphics();
            try { g.Clear(Color.White); } catch { }

            if (radio <= 0)
            {
                MessageBox.Show("Ingrese un radio válido.");
                return;
            }

            // Set a distinct visual style for this algorithm
            SetDrawStyle(Color.DarkBlue, 3);

            var centro = calcularCentro(pic);
            CircleMidPoint(centro.xcentro, centro.ycentro, radio);
        }
        /// <summary>
        /// CircleMidPoint
        /// - Implementa el bucle principal del algoritmo del punto medio para círculos.
        /// - Variables:
        ///     x, y: coordenadas del primer octante (x inicia en 0, y en r).
        ///     p: variable de decisión p = 1 - r (forma entera).
        /// - En cada iteración se actualiza p según la elección entre E (este) o SE (sudeste) y se llaman
        ///   a Plot8Points para dibujar los 8 puntos simétricos.
        /// - Se incluye un pequeño retardo para ver la animación paso a paso.
        /// </summary>
        public void CircleMidPoint(int xc, int yc, int r)
        {
            int x = 0;
            int y = r;
            int p = 1 - r;

            Plot8Points(xc, yc, x, y);

            while (x < y)
            {
                x = x + 1;
                if (p < 0)
                {
                    p += 2 * x + 1;
                }
                else
                {
                    y = y - 1;
                    p += 2 * (x - y) + 1;
                }
                System.Threading.Thread.Sleep(20);
                Application.DoEvents();
                Plot8Points(xc, yc, x, y);
            }
        }

        /// <summary>
        /// ALGORITMO 2: DDA (Digital Differential Analyzer) para Círculos
        /// - Aquí DDA se usa de forma paramétrica: avanzamos por ángulo y calculamos (x,y) con cos/sin.
        /// - Visual: color rojo; punto "mediano" (grosor 2).
        /// - Ventajas: simple y directo, controla la densidad de puntos mediante la cantidad de pasos.
        /// - Limitaciones: usa trigonometría (cos/sin) en cada paso — más costoso que Midpoint para renderizar píxeles.
        /// </summary>
        public void DibujarDDA(PictureBox pic)
        {
            g = pic.CreateGraphics();
            try { g.Clear(Color.White); } catch { }

            if (radio <= 0)
            {
                MessageBox.Show("Ingrese un radio válido.");
                return;
            }

            SetDrawStyle(Color.Red, 2);

            var centro = calcularCentro(pic);
            CircleDDA(centro.xcentro, centro.ycentro, radio);
        }

        /// <summary>
        /// CircleDDA
        /// - Calcula el número de pasos en base al perímetro aproximado (2πr) para obtener una densidad de puntos adecuada.
        /// - angleStep = 2π / steps asegura cubrir el círculo completo.
        /// - En cada iteración calcula:
        ///     x = r * cos(angle)
        ///     y = r * sin(angle)
        ///   y dibuja el punto en (xc + x, yc + y).
        /// </summary>
        public void CircleDDA(int xc, int yc, int r)
        {
            // Número de pasos basado en el perímetro.
            int steps = Math.Max(8, (int)(2 * Math.PI * Math.Abs(r)));
            double angleStep = (2 * Math.PI) / steps;

            double angle = 0;
            for (int i = 0; i <= steps; i++)
            {
                int x = (int)(r * Math.Cos(angle));
                int y = (int)(r * Math.Sin(angle));

                DrawPoint(xc + x, yc + y);

                angle += angleStep;

                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }
        }


        /// <summary>
        /// ALGORITMO 3: Polar (Ecuación Paramétrica)
        /// - Similar a DDA paramétrico, pero aquí se controla explícitamente el incremento del ángulo (step).
        /// - Paso (step) controla suavidad; step pequeño -> círculo más suave, más costoso computacionalmente.
        /// </summary>

        public void DibujarPolar(PictureBox pic)
        {
            g = pic.CreateGraphics();
            try { g.Clear(Color.White); } catch { }

            if (radio <= 0)
            {
                MessageBox.Show("Ingrese un radio válido.");
                return;
            }

            SetDrawStyle(Color.Green, 2);

            var centro = calcularCentro(pic);
            CirclePolar(centro.xcentro, centro.ycentro, radio);
        }
        /// <summary>
        /// CirclePolar
        /// - Recorre el ángulo theta desde 0 hasta 2π con un incremento fijo (step).
        /// - Para cada theta calcula x = r*cos(theta), y = r*sin(theta) y dibuja el punto correspondiente.
        /// - step = 0.01 es razonable para radios moderados; ajusta según precisión/velocidad requerida.
        /// </summary>
        public void CirclePolar(int xc, int yc, int r)
        {
            double step = 0.01; 

            for (double theta = 0; theta <= 2 * Math.PI; theta += step)
            {
                int x = (int)(r * Math.Cos(theta));
                int y = (int)(r * Math.Sin(theta));

                DrawPoint(xc + x, yc + y);

                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }
        }

        public void Plot8Points(int xc, int yc, int x, int y)
        {
            DrawPoint(xc + x, yc + y);
            DrawPoint(xc - x, yc + y);
            DrawPoint(xc + x, yc - y);
            DrawPoint(xc - x, yc - y);
            DrawPoint(xc + y, yc + x);
            DrawPoint(xc - y, yc + x);
            DrawPoint(xc + y, yc - x);
            DrawPoint(xc - y, yc - x);
        }
    }
}
