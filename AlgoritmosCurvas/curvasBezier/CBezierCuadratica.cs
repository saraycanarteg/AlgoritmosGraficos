using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace curvasBezier
{
    /// <summary>
    /// Implementa curvas de Bézier cuadráticas: B(t) = (1-t)²P0 + 2(1-t)tP1 + t²P2, donde t ∈ [0,1]
    /// </summary>
    public class CBezierCuadratica
    {
        public PointF P0 { get; set; }
        public PointF P1 { get; set; }
        public PointF P2 { get; set; }
        public List<PointF> Rastro { get; private set; } = new List<PointF>();

        public CBezierCuadratica(PointF p0, PointF p1, PointF p2)
        {
            P0 = p0;
            P1 = p1;
            P2 = p2;
        }

        /// <summary>
        /// Calcula punto en la curva: B(t) = (1-t)²P0 + 2(1-t)tP1 + t²P2
        /// </summary>
        public PointF CalcularPunto(float t)
        {
            if (t < 0 || t > 1)
                throw new ArgumentOutOfRangeException(nameof(t), "t debe estar en [0,1]");

            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;

            float x = uu * P0.X + 2 * u * t * P1.X + tt * P2.X;
            float y = uu * P0.Y + 2 * u * t * P1.Y + tt * P2.Y;

            return new PointF(x, y);
        }

        /// <summary>
        /// Calcula puntos intermedios de construcción para visualización
        /// </summary>
        public (PointF q0, PointF q1) CalcularPuntosConstruccion(float t)
        {
            float u = 1 - t;

            PointF q0 = new PointF(u * P0.X + t * P1.X, u * P0.Y + t * P1.Y);
            PointF q1 = new PointF(u * P1.X + t * P2.X, u * P1.Y + t * P2.Y);

            return (q0, q1);
        }

        /// <summary>
        /// Genera todos los puntos de la curva
        /// </summary>
        public List<PointF> GenerarCurva(int pasos = 50)
        {
            if (pasos < 2)
                throw new ArgumentException("Mínimo 2 pasos", nameof(pasos));

            List<PointF> puntos = new List<PointF>();
            for (int i = 0; i <= pasos; i++)
            {
                float t = (float)i / pasos;
                puntos.Add(CalcularPunto(t));
            }
            return puntos;
        }

        public void AgregarRastro(PointF p)
        {
            Rastro.Add(p);
        }

        public void LimpiarRastro()
        {
            Rastro.Clear();
        }

        public bool ValidarPuntos()
        {
            if (P0.X < 0 || P0.Y < 0 || P1.X < 0 || P1.Y < 0 || P2.X < 0 || P2.Y < 0)
                return false;
            return true;
        }

        public float DistanciaAPunto(PointF punto, PointF control)
        {
            float dx = punto.X - control.X;
            float dy = punto.Y - control.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Dibuja la curva completa en el Graphics proporcionado
        /// </summary>
        public void Dibujar(Graphics g, bool mostrarCurva, bool mostrarRastro, bool mostrarAnimacion, bool mostrarConstruccion, float t)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // Líneas de control
            if (mostrarConstruccion)
            {
                using (Pen pen = new Pen(Color.LightGray, 1) { DashStyle = DashStyle.Dash })
                {
                    g.DrawLine(pen, P0, P1);
                    g.DrawLine(pen, P1, P2);
                }
            }

            // Curva
            if (mostrarCurva)
            {
                DibujarCurva(g);
            }

            // Rastro
            if (mostrarRastro && Rastro.Count > 1)
            {
                DibujarRastro(g);
            }

            // Puntos de control
            DibujarPuntoControl(g, P0, Color.Red, "P0");
            DibujarPuntoControl(g, P1, Color.Blue, "P1");
            DibujarPuntoControl(g, P2, Color.Red, "P2");

            // Animación
            if (mostrarAnimacion)
            {
                DibujarAnimacion(g, t, mostrarConstruccion);
            }
        }

        private void DibujarCurva(Graphics g)
        {
            List<PointF> puntos = GenerarCurva(100);
            using (Pen pen = new Pen(Color.DarkBlue, 3))
            {
                for (int i = 0; i < puntos.Count - 1; i++)
                    g.DrawLine(pen, puntos[i], puntos[i + 1]);
            }
        }

        private void DibujarRastro(Graphics g)
        {
            using (Pen pen = new Pen(Color.Orange, 2))
            {
                for (int i = 0; i < Rastro.Count - 1; i++)
                    g.DrawLine(pen, Rastro[i], Rastro[i + 1]);
            }
        }

        private void DibujarPuntoControl(Graphics g, PointF punto, Color color, string label)
        {
            using (Brush b = new SolidBrush(color))
            using (Pen pen = new Pen(Color.Black, 1))
            using (Font f = new Font("Arial", 10, FontStyle.Bold))
            using (Brush bt = new SolidBrush(Color.Black))
            {
                g.FillEllipse(b, punto.X - 6, punto.Y - 6, 12, 12);
                g.DrawEllipse(pen, punto.X - 6, punto.Y - 6, 12, 12);
                g.DrawString(label, f, bt, punto.X + 10, punto.Y - 10);
            }
        }

        private void DibujarAnimacion(Graphics g, float t, bool mostrarConstruccion)
        {
            PointF actual = CalcularPunto(t);

            // Dibujar proceso de construcción
            if (mostrarConstruccion)
            {
                var (q0, q1) = CalcularPuntosConstruccion(t);

                using (Pen penConstruccion = new Pen(Color.FromArgb(150, Color.Green), 2))
                {
                    g.DrawLine(penConstruccion, q0, q1);
                }

                using (Brush b = new SolidBrush(Color.FromArgb(150, Color.Green)))
                {
                    g.FillEllipse(b, q0.X - 4, q0.Y - 4, 8, 8);
                    g.FillEllipse(b, q1.X - 4, q1.Y - 4, 8, 8);
                }
            }

            using (Brush b = new SolidBrush(Color.DarkGreen))
            {
                g.FillEllipse(b, actual.X - 7, actual.Y - 7, 14, 14);
            }
            using (Pen pen = new Pen(Color.White, 2))
            {
                g.DrawEllipse(pen, actual.X - 7, actual.Y - 7, 14, 14);
            }

            using (Font f = new Font("Arial", 10, FontStyle.Bold))
            using (Brush b = new SolidBrush(Color.Black))
            {
                g.DrawString($"t = {t:F2}", f, b, actual.X + 12, actual.Y - 12);
            }
        }
    }
}