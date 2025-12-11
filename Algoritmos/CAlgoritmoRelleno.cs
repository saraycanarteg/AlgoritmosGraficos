using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RellenoFiguras
{
    public class CAlgoritmoRelleno
    {
        private Bitmap bitmap;
        private Color colorRelleno;
        private Color colorBorde;
        private List<Point> pixelesPintados;
        private bool[,] visitados;
        public bool Cancelar { get; set; } = false;
        public List<Point> PixelesPintados => pixelesPintados;

        public CAlgoritmoRelleno(int ancho, int alto)
        {
            bitmap = new Bitmap(ancho, alto);
            pixelesPintados = new List<Point>();

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
            }
        }
        /// <summary>
        /// Métodos para el manejo de dibujo y relleno de figuras en un bitmap.
        /// Clase que implementa una métodos de relleno de áreas con animación; 
        /// de dibujo de líneas y polígonos; gestión del bitmap, obtención 
        /// de pixeles pintados, y cancelación de procesos.
        /// </summary>
        public Bitmap ObtenerBitmap()
        {
            return bitmap;
        }

        public void DibujarLinea(Point inicio, Point fin, Color color)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(new Pen(color, 2), inicio, fin);
            }
        }

        public void DibujarPoligono(List<Point> puntos, Color color)
        {
            if (puntos.Count < 2) return;

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Pen pen = new Pen(color, 2);
                for (int i = 0; i < puntos.Count - 1; i++)
                {
                    g.DrawLine(pen, puntos[i], puntos[i + 1]);
                }
                if (puntos.Count > 2)
                {
                    g.DrawLine(pen, puntos[puntos.Count - 1], puntos[0]);
                }
            }
        }
        public void LimpiarCanvas()
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
            }
            pixelesPintados.Clear();
        }

        public async Task IniciarRellenoAnimado(Point puntoInicial, Color colorRelleno,
            Color colorBorde, Action<Bitmap> actualizarImagen, int retardoMs = 1)
        {
            this.colorRelleno = colorRelleno;
            this.colorBorde = colorBorde;
            pixelesPintados.Clear();
            visitados = new bool[bitmap.Width, bitmap.Height];

            if (puntoInicial.X < 0 || puntoInicial.X >= bitmap.Width ||
                puntoInicial.Y < 0 || puntoInicial.Y >= bitmap.Height)
            {
                return;
            }

            Color colorInicial = bitmap.GetPixel(puntoInicial.X, puntoInicial.Y);
            if (EsColorBorde(colorInicial) || EsColorRelleno(colorInicial))
            {
                return;
            }

            await RellenoRecursivoAnimado(puntoInicial.X, puntoInicial.Y,
                colorInicial, actualizarImagen, retardoMs);
        }
        /// <summary>
        /// Algoritmo 1: Relleno recursivo animado.
        /// El metodo rellena un área comenzando desde (x, y) con animación.
        /// Considera las direcciones arriba, abajo, izquierda y derecha (N, S, E, O)
        /// a través de llamadas recursivas.
        /// - Verifica límites del bitmap y si el píxel ya fue visitado.
        /// - Comprueba si el color actual es similar al color original y no es borde o relleno.
        /// - Cambia el color del píxel al color de relleno y lo registra.
        /// - Invoca la acción para actualizar la imagen y espera el retardo.
        /// - Llama recursivamente a los píxeles vecinos.
        /// </summary>
        private async Task RellenoRecursivoAnimado(int x, int y, Color colorOriginal,
              Action<Bitmap> actualizarImagen, int retardoMs)
        {
            if (Cancelar)
                return;

            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                return;

            if (visitados[x, y])
                return;

            visitados[x, y] = true;

            Color colorActual = bitmap.GetPixel(x, y);

            if (!EsColorSimilar(colorActual, colorOriginal) ||
                EsColorBorde(colorActual) ||
                EsColorRelleno(colorActual))
                return;

            bitmap.SetPixel(x, y, colorRelleno);
            pixelesPintados.Add(new Point(x, y));

            actualizarImagen?.Invoke(bitmap);

            if (retardoMs > 0)
                await Task.Delay(retardoMs);

            await RellenoRecursivoAnimado(x + 1, y, colorOriginal, actualizarImagen, retardoMs);
            await RellenoRecursivoAnimado(x - 1, y, colorOriginal, actualizarImagen, retardoMs);
            await RellenoRecursivoAnimado(x, y + 1, colorOriginal, actualizarImagen, retardoMs);
            await RellenoRecursivoAnimado(x, y - 1, colorOriginal, actualizarImagen, retardoMs);
        }

        /// <summary>
        /// Algoritmo 2: Relleno Scanline animado.
        /// Este algoritmo rellena un área comenzando desde un punto inicial utilizando 
        /// un enfoque de línea de escaneo. Para cada píxel, busca los límites izquierdo y derecho,
        /// luego pinta una línea horizontal completa entre esos límites. Después, agrega las líneas
        /// encima y debajo de la línea pintada a la pila para su procesamiento posterior.
        /// </summary>
        public async Task RellenoScanline(Point inicio, Color colorRelleno, Color colorBorde,
            Action<Bitmap> actualizarImagen, int retardoMs = 1)
        {
            Cancelar = false;
            pixelesPintados.Clear();

            if (EsColorBorde(bitmap.GetPixel(inicio.X, inicio.Y), colorBorde))
                return;

            Stack<Point> pila = new Stack<Point>();
            pila.Push(inicio);

            while (pila.Count > 0 && !Cancelar)
            {
                Point p = pila.Pop();
                int x = p.X;
                int y = p.Y;

                if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                    continue;

                Color actual = bitmap.GetPixel(x, y);

                if (EsColorBorde(actual, colorBorde) || EsColorRelleno(actual, colorRelleno))
                    continue;

                // Buscar izquierda
                int xl = x;
                while (xl >= 0 &&
                       !EsColorBorde(bitmap.GetPixel(xl, y), colorBorde) &&
                       !EsColorRelleno(bitmap.GetPixel(xl, y), colorRelleno))
                {
                    xl--;
                }
                xl++;

                // Buscar derecha
                int xr = x;
                while (xr < bitmap.Width &&
                       !EsColorBorde(bitmap.GetPixel(xr, y), colorBorde) &&
                       !EsColorRelleno(bitmap.GetPixel(xr, y), colorRelleno))
                {
                    xr++;
                }
                xr--;

                // Pintar línea horizontal
                for (int i = xl; i <= xr; i++)
                {
                    bitmap.SetPixel(i, y, colorRelleno);
                    pixelesPintados.Add(new Point(i, y));
                }

                actualizarImagen?.Invoke(bitmap);
                if (retardoMs > 0) await Task.Delay(retardoMs);

                // Agregar nuevas líneas arriba y abajo
                for (int i = xl; i <= xr; i++)
                {
                    if (y > 0 &&
                        !EsColorBorde(bitmap.GetPixel(i, y - 1), colorBorde) &&
                        !EsColorRelleno(bitmap.GetPixel(i, y - 1), colorRelleno))
                        pila.Push(new Point(i, y - 1));

                    if (y < bitmap.Height - 1 &&
                        !EsColorBorde(bitmap.GetPixel(i, y + 1), colorBorde) &&
                        !EsColorRelleno(bitmap.GetPixel(i, y + 1), colorRelleno))
                        pila.Push(new Point(i, y + 1));
                }
            }
        }

        /// <summary>
        /// Algoritmo 3: Relleno BFS animado.
        /// El metodo funciona de manera similar al Relleno Scanline, pero utiliza una cola (FIFO).
        /// Esto significa que los píxeles se procesan en el orden en que se agregan,
        /// generando un patrón similar a una expansión desde el punto inicial.
        /// </summary>
        public async Task RellenoBFS(Point inicio, Color colorRelleno, Color colorBorde,
         Action<Bitmap> actualizarImagen, int retardoMs = 1)
        {
            Cancelar = false;
            pixelesPintados.Clear();

            if (EsColorBorde(bitmap.GetPixel(inicio.X, inicio.Y), colorBorde))
                return;

            Queue<Point> cola = new Queue<Point>();
            cola.Enqueue(inicio);

            bool[,] visitado = new bool[bitmap.Width, bitmap.Height];

            while (cola.Count > 0 && !Cancelar)
            {
                Point p = cola.Dequeue();
                int x = p.X;
                int y = p.Y;

                if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                    continue;

                if (visitado[x, y])
                    continue;

                visitado[x, y] = true;

                Color actual = bitmap.GetPixel(x, y);
                if (EsColorBorde(actual, colorBorde) || EsColorRelleno(actual, colorRelleno))
                    continue;

                bitmap.SetPixel(x, y, colorRelleno);
                pixelesPintados.Add(new Point(x, y));

                actualizarImagen?.Invoke(bitmap);
                if (retardoMs > 0) await Task.Delay(retardoMs);

                cola.Enqueue(new Point(x + 1, y));
                cola.Enqueue(new Point(x - 1, y));
                cola.Enqueue(new Point(x, y + 1));
                cola.Enqueue(new Point(x, y - 1));
            }
        }

        private bool EsColorBorde(Color color)
        {
            return EsColorSimilar(color, colorBorde);
        }

        private bool EsColorRelleno(Color color)
        {
            return EsColorSimilar(color, colorRelleno);
        }
        private bool EsColorBorde(Color c, Color colorBorde)
        {
            return c.ToArgb() == colorBorde.ToArgb();
        }

        private bool EsColorRelleno(Color c, Color colorRelleno)
        {
            return c.ToArgb() == colorRelleno.ToArgb();
        }


        private bool EsColorSimilar(Color c1, Color c2, int tolerancia = 30)
        {
            return Math.Abs(c1.R - c2.R) <= tolerancia &&
                   Math.Abs(c1.G - c2.G) <= tolerancia &&
                   Math.Abs(c1.B - c2.B) <= tolerancia;
        }

        public string ObtenerListaPixeles()
        {
            if (pixelesPintados.Count == 0)
                return "No hay píxeles pintados";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine($"Total de píxeles pintados: {pixelesPintados.Count}\r\n");
            sb.AppendLine("Coordenadas (X, Y):");
            sb.AppendLine("-------------------");

            for (int i = 0; i < pixelesPintados.Count; i++)
            {
                sb.AppendLine($"{i + 1}. ({pixelesPintados[i].X}, {pixelesPintados[i].Y})");
            }

            return sb.ToString();
        }
        public void CancelarRelleno()
        {
            Cancelar = true;
        }

    }
}
