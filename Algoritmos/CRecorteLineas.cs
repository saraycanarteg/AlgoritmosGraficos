using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    internal class CRecorteLineas
    {
        public enum EstadoApp { Inicial, DibujandoLineas, DefiniendoVentana, VentanaDefinida }
        public enum TipoAlgoritmo { CohenSutherland, LiangBarsky, NichollLeeNichol }

        [Flags]
        private enum CodigoRegion { Dentro = 0, Izquierda = 1, Derecha = 2, Abajo = 4, Arriba = 8 }

        private CGraficarLineas canvas;
        private List<CGraficarLineas.Linea> lineasOriginales;
        private List<CGraficarLineas.Linea> lineasRecortadas;
        private Rectangle ventanaRecorte;
        private EstadoApp estadoActual;
        private Point puntoTemporal;
        private bool esperandoSegundoPunto;
        private Point puntoInicioVentana;
        private bool arrastrando;
        public EstadoApp Estado => estadoActual;
        public int CantidadLineas => lineasOriginales.Count;
        public bool TieneVentana => ventanaRecorte.Width > 0 && ventanaRecorte.Height > 0;

        public CRecorteLineas(PictureBox pic)
        {
            canvas = new CGraficarLineas(pic);
            lineasOriginales = new List<CGraficarLineas.Linea>();
            lineasRecortadas = new List<CGraficarLineas.Linea>();
            ventanaRecorte = Rectangle.Empty;
            estadoActual = EstadoApp.Inicial;
        }
        public void IniciarDibujoLineas()
        {
            estadoActual = EstadoApp.DibujandoLineas;
            esperandoSegundoPunto = false;
        }

        public void TerminarDibujoLineas()
        {
            if (lineasOriginales.Count > 0)
            {
                estadoActual = EstadoApp.Inicial;
                esperandoSegundoPunto = false;
            }
        }

        public void IniciarDefinicionVentana()
        {
            if (lineasOriginales.Count > 0)
                estadoActual = EstadoApp.DefiniendoVentana;
        }
        public void LimpiarTodo()
        {
            lineasOriginales.Clear();
            lineasRecortadas.Clear();
            ventanaRecorte = Rectangle.Empty;
            estadoActual = EstadoApp.Inicial;
            esperandoSegundoPunto = false;
            arrastrando = false;
            canvas.Limpiar();
        }

        public void Reset()
        {
            lineasRecortadas.Clear();
            Dibujar();
        }
        public void OnMouseDown(MouseEventArgs e)
        {
            if (estadoActual == EstadoApp.DibujandoLineas)
            {
                if (!esperandoSegundoPunto)
                {
                    puntoTemporal = e.Location;
                    esperandoSegundoPunto = true;
                }
                else
                {
                    lineasOriginales.Add(new CGraficarLineas.Linea(puntoTemporal, e.Location));
                    esperandoSegundoPunto = false;
                    Dibujar();
                }
            }
            else if (estadoActual == EstadoApp.DefiniendoVentana)
            {
                puntoInicioVentana = e.Location;
                arrastrando = true;
                ventanaRecorte = new Rectangle(e.Location, new Size(0, 0));
            }
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            if (estadoActual == EstadoApp.DibujandoLineas && esperandoSegundoPunto)
            {
                Dibujar();
                canvas.DibujarLineaTemporal(puntoTemporal, e.Location);
                canvas.Refrescar();
            }
            else if (estadoActual == EstadoApp.DefiniendoVentana && arrastrando)
            {
                int x = Math.Min(puntoInicioVentana.X, e.X);
                int y = Math.Min(puntoInicioVentana.Y, e.Y);
                int width = Math.Abs(e.X - puntoInicioVentana.X);
                int height = Math.Abs(e.Y - puntoInicioVentana.Y);
                ventanaRecorte = new Rectangle(x, y, width, height);
                Dibujar();
            }
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            if (estadoActual == EstadoApp.DefiniendoVentana && arrastrando)
            {
                arrastrando = false;
                if (ventanaRecorte.Width >= 10 && ventanaRecorte.Height >= 10)
                    estadoActual = EstadoApp.VentanaDefinida;
                else
                    ventanaRecorte = Rectangle.Empty;
                Dibujar();
            }
        }

        public void AplicarRecorte(TipoAlgoritmo algoritmo)
        {
            if (!TieneVentana) return;

            lineasRecortadas.Clear();

            switch (algoritmo)
            {
                case TipoAlgoritmo.CohenSutherland: AplicarCohenSutherland(); break;
                case TipoAlgoritmo.LiangBarsky: AplicarLiangBarsky(); break;
                case TipoAlgoritmo.NichollLeeNichol: AplicarNichollLeeNichol(); break;
            }

            Dibujar(algoritmo);
        }

        // Algoritmo Cohen-Sutherland: divide el plano en 9 regiones
        private void AplicarCohenSutherland()
        {
            foreach (CGraficarLineas.Linea linea in lineasOriginales)
            {
                Point p1 = linea.P1, p2 = linea.P2;
                CodigoRegion codigo1 = CalcularCodigo(p1);
                CodigoRegion codigo2 = CalcularCodigo(p2);
                bool aceptar = false;

                while (true)
                {
                    if ((codigo1 | codigo2) == CodigoRegion.Dentro)
                    {
                        aceptar = true;
                        break;
                    }
                    else if ((codigo1 & codigo2) != CodigoRegion.Dentro)
                        break;
                    else
                    {
                        CodigoRegion codigoFuera = codigo1 != CodigoRegion.Dentro ? codigo1 : codigo2;
                        Point puntoInterseccion = new Point();

                        if ((codigoFuera & CodigoRegion.Arriba) != 0)
                        {
                            puntoInterseccion.X = p1.X + (p2.X - p1.X) * (ventanaRecorte.Top - p1.Y) / (p2.Y - p1.Y);
                            puntoInterseccion.Y = ventanaRecorte.Top;
                        }
                        else if ((codigoFuera & CodigoRegion.Abajo) != 0)
                        {
                            puntoInterseccion.X = p1.X + (p2.X - p1.X) * (ventanaRecorte.Bottom - p1.Y) / (p2.Y - p1.Y);
                            puntoInterseccion.Y = ventanaRecorte.Bottom;
                        }
                        else if ((codigoFuera & CodigoRegion.Derecha) != 0)
                        {
                            puntoInterseccion.Y = p1.Y + (p2.Y - p1.Y) * (ventanaRecorte.Right - p1.X) / (p2.X - p1.X);
                            puntoInterseccion.X = ventanaRecorte.Right;
                        }
                        else if ((codigoFuera & CodigoRegion.Izquierda) != 0)
                        {
                            puntoInterseccion.Y = p1.Y + (p2.Y - p1.Y) * (ventanaRecorte.Left - p1.X) / (p2.X - p1.X);
                            puntoInterseccion.X = ventanaRecorte.Left;
                        }

                        if (codigoFuera == codigo1)
                        {
                            p1 = puntoInterseccion;
                            codigo1 = CalcularCodigo(p1);
                        }
                        else
                        {
                            p2 = puntoInterseccion;
                            codigo2 = CalcularCodigo(p2);
                        }
                    }
                }

                if (aceptar)
                    lineasRecortadas.Add(new CGraficarLineas.Linea(p1, p2));
            }
        }

        private CodigoRegion CalcularCodigo(Point p)
        {
            CodigoRegion codigo = CodigoRegion.Dentro;
            if (p.X < ventanaRecorte.Left) codigo |= CodigoRegion.Izquierda;
            else if (p.X > ventanaRecorte.Right) codigo |= CodigoRegion.Derecha;
            if (p.Y < ventanaRecorte.Top) codigo |= CodigoRegion.Arriba;
            else if (p.Y > ventanaRecorte.Bottom) codigo |= CodigoRegion.Abajo;
            return codigo;
        }

        // Algoritmo Liang-Barsky: usa ecuaciones paramétricas
        private void AplicarLiangBarsky()
        {
            foreach (CGraficarLineas.Linea linea in lineasOriginales)
            {
                float x1 = linea.P1.X, y1 = linea.P1.Y;
                float x2 = linea.P2.X, y2 = linea.P2.Y;
                float dx = x2 - x1, dy = y2 - y1;

                float[] p = { -dx, dx, -dy, dy };
                float[] q = { x1 - ventanaRecorte.Left, ventanaRecorte.Right - x1,
                             y1 - ventanaRecorte.Top, ventanaRecorte.Bottom - y1 };

                float u1 = 0.0f, u2 = 1.0f;
                bool dibujar = true;

                for (int i = 0; i < 4; i++)
                {
                    if (p[i] == 0)
                    {
                        if (q[i] < 0) { dibujar = false; break; }
                    }
                    else
                    {
                        float r = q[i] / p[i];
                        if (p[i] < 0)
                        {
                            if (r > u2) { dibujar = false; break; }
                            else if (r > u1) u1 = r;
                        }
                        else
                        {
                            if (r < u1) { dibujar = false; break; }
                            else if (r < u2) u2 = r;
                        }
                    }
                }

                if (dibujar && u1 <= u2)
                {
                    int nx1 = (int)(x1 + u1 * dx);
                    int ny1 = (int)(y1 + u1 * dy);
                    int nx2 = (int)(x1 + u2 * dx);
                    int ny2 = (int)(y1 + u2 * dy);
                    lineasRecortadas.Add(new CGraficarLineas.Linea(new Point(nx1, ny1), new Point(nx2, ny2)));
                }
            }
        }

        // Algoritmo Nicholl-Lee-Nichol: optimización de regiones
        private void AplicarNichollLeeNichol()
        {
            foreach (CGraficarLineas.Linea linea in lineasOriginales)
            {
                Point p1 = linea.P1, p2 = linea.P2;

                if (ventanaRecorte.Contains(p1) && ventanaRecorte.Contains(p2))
                    lineasRecortadas.Add(new CGraficarLineas.Linea(p1, p2));
                else if (RecortarLineaNLN(ref p1, ref p2))
                    lineasRecortadas.Add(new CGraficarLineas.Linea(p1, p2));
            }
        }

        private bool RecortarLineaNLN(ref Point p1, ref Point p2)
        {
            float x1 = p1.X, y1 = p1.Y, x2 = p2.X, y2 = p2.Y;
            float dx = x2 - x1, dy = y2 - y1;

            if (dx == 0 && dy == 0) return ventanaRecorte.Contains(p1);

            float tmin = 0.0f, tmax = 1.0f;

            if (!PruebaRecorte(-dx, x1 - ventanaRecorte.Left, ref tmin, ref tmax)) return false;
            if (!PruebaRecorte(dx, ventanaRecorte.Right - x1, ref tmin, ref tmax)) return false;
            if (!PruebaRecorte(-dy, y1 - ventanaRecorte.Top, ref tmin, ref tmax)) return false;
            if (!PruebaRecorte(dy, ventanaRecorte.Bottom - y1, ref tmin, ref tmax)) return false;

            p1 = new Point((int)(x1 + tmin * dx), (int)(y1 + tmin * dy));
            p2 = new Point((int)(x1 + tmax * dx), (int)(y1 + tmax * dy));
            return true;
        }

        private bool PruebaRecorte(float p, float q, ref float tmin, ref float tmax)
        {
            if (p == 0) return q >= 0;
            float r = q / p;
            if (p < 0)
            {
                if (r > tmax) return false;
                if (r > tmin) tmin = r;
            }
            else
            {
                if (r < tmin) return false;
                if (r < tmax) tmax = r;
            }
            return true;
        }

        private void Dibujar(TipoAlgoritmo? algoritmo = null)
        {
            canvas.Limpiar();

            canvas.DibujarLineas(lineasOriginales, Color.LightGray, 2);

            if (TieneVentana)
            {
                Color colorVentana = algoritmo.HasValue ?
                    (algoritmo == TipoAlgoritmo.CohenSutherland ? Color.Red :
                     algoritmo == TipoAlgoritmo.LiangBarsky ? Color.Purple : Color.Cyan)
                    : Color.Black;

                canvas.DibujarRectangulo(ventanaRecorte, colorVentana,
                    algoritmo.HasValue ? 3 : 2, !algoritmo.HasValue);
            }

            if (lineasRecortadas.Count > 0 && algoritmo.HasValue)
            {
                Color colorLinea = algoritmo == TipoAlgoritmo.CohenSutherland ? Color.Blue :
                                  algoritmo == TipoAlgoritmo.LiangBarsky ? Color.Green : Color.Orange;

                canvas.DibujarLineas(lineasRecortadas, colorLinea, 3);
            }

            canvas.Refrescar();
        }

        public string ObtenerMensajeEstado()
        {
            switch (estadoActual)
            {
                case EstadoApp.Inicial:
                    return "Haz clic en 'Dibujar Líneas' para comenzar";
                case EstadoApp.DibujandoLineas:
                    return esperandoSegundoPunto ?
                        $"Dibujando línea... Clic 2 de 2 (Líneas: {lineasOriginales.Count})" :
                        $"Dibujando línea... Clic 1 de 2 (Líneas: {lineasOriginales.Count})";
                case EstadoApp.DefiniendoVentana:
                    return arrastrando ? "Arrastra para definir la ventana..." :
                        "Haz clic y arrastra para definir la ventana de recorte";
                case EstadoApp.VentanaDefinida:
                    return $"Ventana definida. Selecciona un algoritmo (Líneas: {lineasOriginales.Count})";
                default:
                    return "Listo";
            }
        }

        public void Dispose()
        {
            canvas?.Dispose();
        }
    }
}