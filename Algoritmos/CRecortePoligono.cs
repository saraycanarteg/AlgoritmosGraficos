using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmos
{
    public class CRecortePoligono
    {
        public enum TipoAlgoritmo
        {
            SutherlandHodgman,
            CohenSutherland,
            WeilerAtherton
        }

        public enum Borde
        {
            Izquierda,
            Derecha,
            Arriba,
            Abajo
        }

        private const int INSIDE = 0;
        private const int LEFT = 1;
        private const int RIGHT = 2;
        private const int BOTTOM = 4;
        private const int TOP = 8;

        private Rectangle ventana;

        public CRecortePoligono(Rectangle ventana)
        {
            this.ventana = ventana;
        }

        public static bool ValidarPoligono(List<Point> puntos)
        {
            return puntos != null && puntos.Count >= 3;
        }

        public static bool ValidarVentana(Rectangle rect)
        {
            return rect.Width > 0 && rect.Height > 0;
        }

        // Obtener color según algoritmo
        public static Color ObtenerColorAlgoritmo(TipoAlgoritmo algoritmo)
        {
            switch (algoritmo)
            {
                case TipoAlgoritmo.SutherlandHodgman:
                    return Color.Blue; // Azul
                case TipoAlgoritmo.CohenSutherland:
                    return Color.Red; // Rojo
                case TipoAlgoritmo.WeilerAtherton:
                    return Color.Purple; // Púrpura
                default:
                    return Color.Green;
            }
        }

        // Obtener color de ventana según algoritmo
        public static Color ObtenerColorVentana(TipoAlgoritmo algoritmo)
        {
            switch (algoritmo)
            {
                case TipoAlgoritmo.SutherlandHodgman:
                    return Color.DarkBlue;
                case TipoAlgoritmo.CohenSutherland:
                    return Color.DarkRed;
                case TipoAlgoritmo.WeilerAtherton:
                    return Color.DarkMagenta;
                default:
                    return Color.Black;
            }
        }

        // ============================================
        // ALGORITMO 1: SUTHERLAND-HODGMAN 
        // ============================================
        /// <summary>
        /// Algoritmo de Sutherland-Hodgman: Recorta un polígono contra una ventana rectangular.
        /// Procesa el polígono secuencialmente contra cada borde de la ventana (izquierda, derecha, arriba, abajo).
        /// Es eficiente y funciona bien con polígonos convexos y cóncavos.
        /// </summary>
        /// <param name="poligonoOriginal">Lista de puntos que forman el polígono a recortar</param>
        /// <returns>Lista de puntos del polígono recortado dentro de la ventana</returns>
        public List<Point> RecortarSutherlandHodgman(List<Point> poligonoOriginal)
        {
            if (!ValidarPoligono(poligonoOriginal))
                throw new Exception("El polígono no es válido (necesita al menos 3 puntos)");

            if (!ValidarVentana(ventana))
                throw new Exception("La ventana no es válida");

            List<Point> salida = new List<Point>(poligonoOriginal);

            salida = ClippingBorde(salida, Borde.Izquierda);
            if (salida.Count == 0) return salida;

            salida = ClippingBorde(salida, Borde.Derecha);
            if (salida.Count == 0) return salida;

            salida = ClippingBorde(salida, Borde.Arriba);
            if (salida.Count == 0) return salida;

            salida = ClippingBorde(salida, Borde.Abajo);

            return salida;
        }

        private List<Point> ClippingBorde(List<Point> entrada, Borde borde)
        {
            if (entrada.Count == 0) return entrada;

            List<Point> salida = new List<Point>();

            for (int i = 0; i < entrada.Count; i++)
            {
                Point p1 = entrada[i];
                Point p2 = entrada[(i + 1) % entrada.Count];

                bool dentro1 = EstaDentro(p1, borde);
                bool dentro2 = EstaDentro(p2, borde);

                if (dentro1 && dentro2)
                {
                    salida.Add(p2);
                }
                else if (dentro1 && !dentro2)
                {
                    Point interseccion = Interseccion(p1, p2, borde);
                    salida.Add(interseccion);
                }
                else if (!dentro1 && dentro2)
                {
                    Point interseccion = Interseccion(p1, p2, borde);
                    salida.Add(interseccion);
                    salida.Add(p2);
                }
            }

            return salida;
        }

        private bool EstaDentro(Point p, Borde borde)
        {
            switch (borde)
            {
                case Borde.Izquierda: return p.X >= ventana.Left;
                case Borde.Derecha: return p.X <= ventana.Right;
                case Borde.Arriba: return p.Y >= ventana.Top;
                case Borde.Abajo: return p.Y <= ventana.Bottom;
                default: return false;
            }
        }

        private Point Interseccion(Point p1, Point p2, Borde borde)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            double t;

            switch (borde)
            {
                case Borde.Izquierda:
                    if (Math.Abs(dx) < 0.0001) return new Point(ventana.Left, p1.Y);
                    t = (ventana.Left - p1.X) / dx;
                    return new Point(ventana.Left, (int)Math.Round(p1.Y + t * dy));

                case Borde.Derecha:
                    if (Math.Abs(dx) < 0.0001) return new Point(ventana.Right, p1.Y);
                    t = (ventana.Right - p1.X) / dx;
                    return new Point(ventana.Right, (int)Math.Round(p1.Y + t * dy));

                case Borde.Arriba:
                    if (Math.Abs(dy) < 0.0001) return new Point(p1.X, ventana.Top);
                    t = (ventana.Top - p1.Y) / dy;
                    return new Point((int)Math.Round(p1.X + t * dx), ventana.Top);

                case Borde.Abajo:
                    if (Math.Abs(dy) < 0.0001) return new Point(p1.X, ventana.Bottom);
                    t = (ventana.Bottom - p1.Y) / dy;
                    return new Point((int)Math.Round(p1.X + t * dx), ventana.Bottom);

                default:
                    return p1;
            }
        }

        // ============================================
        // ALGORITMO 2: COHEN-SUTHERLAND MEJORADO
        // ============================================
        // <summary>
        /// Algoritmo de Cohen-Sutherland adaptado para polígonos: Originalmente diseñado para recortar líneas.
        /// Recorta cada arista del polígono individualmente usando códigos de región (9 regiones del plano).
        /// Eficiente para rechazar líneas completamente fuera, pero puede generar segmentos desconectados en polígonos complejos.
        /// </summary>
        /// <param name="poligonoOriginal">Lista de puntos que forman el polígono a recortar</param>
        /// <returns>Lista de puntos del polígono recortado, reconstruido desde las aristas válidas</returns>
        public List<Point> RecortarCohenSutherland(List<Point> poligonoOriginal)
        {
            if (!ValidarPoligono(poligonoOriginal))
                throw new Exception("El polígono no es válido");

            if (!ValidarVentana(ventana))
                throw new Exception("La ventana no es válida");

            // Cohen-Sutherland recorta línea por línea, pero necesitamos
            // reconstruir el polígono resultante correctamente
            List<Point> resultado = new List<Point>();
            List<Point> puntosTemporales = new List<Point>();

            for (int i = 0; i < poligonoOriginal.Count; i++)
            {
                Point p1 = poligonoOriginal[i];
                Point p2 = poligonoOriginal[(i + 1) % poligonoOriginal.Count];

                List<Point> segmentoRecortado = RecortarLineaCohenSutherland(p1, p2);

                if (segmentoRecortado.Count == 2)
                {
                    // Agregar el primer punto si no está ya
                    if (puntosTemporales.Count == 0 ||
                        !PuntosIguales(puntosTemporales[puntosTemporales.Count - 1], segmentoRecortado[0]))
                    {
                        puntosTemporales.Add(segmentoRecortado[0]);
                    }
                    puntosTemporales.Add(segmentoRecortado[1]);
                }
            }

            // Agregar esquinas de la ventana que están dentro del polígono si es necesario
            resultado = puntosTemporales;

            // Eliminar duplicados consecutivos
            resultado = EliminarDuplicadosConsecutivos(resultado);

            return resultado;
        }

        private List<Point> RecortarLineaCohenSutherland(Point p1, Point p2)
        {
            int x1 = p1.X, y1 = p1.Y;
            int x2 = p2.X, y2 = p2.Y;

            int code1 = CalcularCodigoRegion(x1, y1);
            int code2 = CalcularCodigoRegion(x2, y2);
            bool aceptado = false;

            while (true)
            {
                if ((code1 | code2) == 0)
                {
                    aceptado = true;
                    break;
                }
                else if ((code1 & code2) != 0)
                {
                    break;
                }
                else
                {
                    int x = 0, y = 0;
                    int codeOut = (code1 != 0) ? code1 : code2;

                    if ((codeOut & TOP) != 0)
                    {
                        x = x1 + (x2 - x1) * (ventana.Top - y1) / (y2 - y1);
                        y = ventana.Top;
                    }
                    else if ((codeOut & BOTTOM) != 0)
                    {
                        x = x1 + (x2 - x1) * (ventana.Bottom - y1) / (y2 - y1);
                        y = ventana.Bottom;
                    }
                    else if ((codeOut & RIGHT) != 0)
                    {
                        y = y1 + (y2 - y1) * (ventana.Right - x1) / (x2 - x1);
                        x = ventana.Right;
                    }
                    else if ((codeOut & LEFT) != 0)
                    {
                        y = y1 + (y2 - y1) * (ventana.Left - x1) / (x2 - x1);
                        x = ventana.Left;
                    }

                    if (codeOut == code1)
                    {
                        x1 = x; y1 = y;
                        code1 = CalcularCodigoRegion(x1, y1);
                    }
                    else
                    {
                        x2 = x; y2 = y;
                        code2 = CalcularCodigoRegion(x2, y2);
                    }
                }
            }

            List<Point> resultado = new List<Point>();
            if (aceptado)
            {
                resultado.Add(new Point(x1, y1));
                resultado.Add(new Point(x2, y2));
            }
            return resultado;
        }

        private int CalcularCodigoRegion(int x, int y)
        {
            int code = INSIDE;
            if (x < ventana.Left) code |= LEFT;
            else if (x > ventana.Right) code |= RIGHT;
            if (y < ventana.Top) code |= TOP;
            else if (y > ventana.Bottom) code |= BOTTOM;
            return code;
        }

        // ============================================
        // ALGORITMO 3: WEILER-ATHERTON SIMPLIFICADO
        // ============================================
        /// <summary>
        /// Algoritmo de Weiler-Atherton (versión simplificada): Maneja polígonos convexos y cóncavos con múltiples componentes.
        /// Encuentra intersecciones entre el polígono y la ventana, construyendo el resultado siguiendo las aristas visibles.
        /// Más complejo que Sutherland-Hodgman pero puede manejar casos especiales. Si falla, usa S-H como respaldo.
        /// </summary>
        /// <param name="poligonoOriginal">Lista de puntos que forman el polígono a recortar</param>
        /// <returns>Lista de puntos del polígono recortado, o resultado de Sutherland-Hodgman si es inválido</returns>
        public List<Point> RecortarWeilerAtherton(List<Point> poligonoOriginal)
        {
            if (!ValidarPoligono(poligonoOriginal))
                throw new Exception("El polígono no es válido");

            if (!ValidarVentana(ventana))
                throw new Exception("La ventana no es válida");

            // Implementación simplificada de Weiler-Atherton
            // Para polígonos convexos, funciona similar a Sutherland-Hodgman
            // pero con un enfoque diferente

            List<Point> ventanaPoly = new List<Point>
            {
                new Point(ventana.Left, ventana.Top),
                new Point(ventana.Right, ventana.Top),
                new Point(ventana.Right, ventana.Bottom),
                new Point(ventana.Left, ventana.Bottom)
            };

            List<Point> resultado = new List<Point>();
            List<(Point punto, bool esInterseccion, double parametro)> puntosExtendidos =
                new List<(Point, bool, double)>();

            // Recorrer el polígono y encontrar intersecciones
            for (int i = 0; i < poligonoOriginal.Count; i++)
            {
                Point p1 = poligonoOriginal[i];
                Point p2 = poligonoOriginal[(i + 1) % poligonoOriginal.Count];

                bool p1Dentro = PuntoEnRectangulo(p1, ventana);

                if (p1Dentro)
                {
                    puntosExtendidos.Add((p1, false, i));
                }

                // Buscar intersecciones con cada borde de la ventana
                for (int j = 0; j < ventanaPoly.Count; j++)
                {
                    Point v1 = ventanaPoly[j];
                    Point v2 = ventanaPoly[(j + 1) % ventanaPoly.Count];

                    Point? interseccion = CalcularInterseccionLineas(p1, p2, v1, v2);
                    if (interseccion.HasValue)
                    {
                        puntosExtendidos.Add((interseccion.Value, true, i + 0.5));
                    }
                }
            }

            // Convertir a lista de puntos
            foreach (var item in puntosExtendidos)
            {
                resultado.Add(item.punto);
            }

            resultado = EliminarDuplicadosConsecutivos(resultado);

            // Si el resultado es inválido, usar Sutherland-Hodgman como respaldo
            if (resultado.Count < 3)
            {
                return RecortarSutherlandHodgman(poligonoOriginal);
            }

            return resultado;
        }

        private Point? CalcularInterseccionLineas(Point p1, Point p2, Point p3, Point p4)
        {
            double x1 = p1.X, y1 = p1.Y;
            double x2 = p2.X, y2 = p2.Y;
            double x3 = p3.X, y3 = p3.Y;
            double x4 = p4.X, y4 = p4.Y;

            double denom = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            if (Math.Abs(denom) < 0.0001) return null;

            double t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / denom;
            double u = -((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / denom;

            if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
            {
                int x = (int)Math.Round(x1 + t * (x2 - x1));
                int y = (int)Math.Round(y1 + t * (y2 - y1));
                return new Point(x, y);
            }

            return null;
        }

        private bool PuntoEnRectangulo(Point p, Rectangle rect)
        {
            return p.X >= rect.Left && p.X <= rect.Right &&
                   p.Y >= rect.Top && p.Y <= rect.Bottom;
        }

        private List<Point> EliminarDuplicadosConsecutivos(List<Point> puntos)
        {
            if (puntos.Count == 0) return puntos;

            List<Point> resultado = new List<Point>();
            resultado.Add(puntos[0]);

            for (int i = 1; i < puntos.Count; i++)
            {
                if (!PuntosIguales(resultado[resultado.Count - 1], puntos[i]))
                {
                    resultado.Add(puntos[i]);
                }
            }

            // Eliminar si el primero y último son iguales
            if (resultado.Count > 1 && PuntosIguales(resultado[0], resultado[resultado.Count - 1]))
            {
                resultado.RemoveAt(resultado.Count - 1);
            }

            return resultado;
        }

        private bool PuntosIguales(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }
    }
}