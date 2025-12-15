using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace curvasBezier
{
    /// <summary>
    /// Implementa curvas de Bézier cúbicas: B(t) = (1-t)³P0 + 3(1-t)²tP1 + 3(1-t)t²P2 + t³P3, donde t ∈ [0,1]
    /// </summary>
    public class CBezierCubica
    {
        public PointF P0 { get; set; }
        public PointF P1 { get; set; }
        public PointF P2 { get; set; }
        public PointF P3 { get; set; }
        public List<PointF> Rastro { get; private set; } = new List<PointF>();

        public CBezierCubica(PointF p0, PointF p1, PointF p2, PointF p3)
        {
            P0 = p0;
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        /// <summary>
        /// Calcula punto en la curva: B(t) = (1-t)³P0 + 3(1-t)²tP1 + 3(1-t)t²P2 + t³P3
        /// </summary>
        public PointF CalcularPunto(float t)
        {
            if (t < 0 || t > 1)
                throw new ArgumentOutOfRangeException(nameof(t), "t debe estar en [0,1]");

            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;

            float x = uuu * P0.X + 3 * uu * t * P1.X + 3 * u * tt * P2.X + ttt * P3.X;
            float y = uuu * P0.Y + 3 * uu * t * P1.Y + 3 * u * tt * P2.Y + ttt * P3.Y;

            return new PointF(x, y);
        }

        /// <summary>
        /// Calcula puntos intermedios de construcción (algoritmo De Casteljau)
        /// </summary>
        public (PointF[] nivel1, PointF[] nivel2, PointF nivel3) CalcularPuntosConstruccion(float t)
        {
            float u = 1 - t;

            // Primer nivel de interpolación
            PointF q0 = new PointF(u * P0.X + t * P1.X, u * P0.Y + t * P1.Y);
            PointF q1 = new PointF(u * P1.X + t * P2.X, u * P1.Y + t * P2.Y);
            PointF q2 = new PointF(u * P2.X + t * P3.X, u * P2.Y + t * P3.Y);

            // Segundo nivel de interpolación
            PointF r0 = new PointF(u * q0.X + t * q1.X, u * q0.Y + t * q1.Y);
            PointF r1 = new PointF(u * q1.X + t * q2.X, u * q1.Y + t * q2.Y);

            // Tercer nivel (punto final en la curva)
            PointF s = new PointF(u * r0.X + t * r1.X, u * r0.Y + t * r1.Y);

            return (new[] { q0, q1, q2 }, new[] { r0, r1 }, s);
        }

        /// <summary>
        /// Genera todos los puntos de la curva
        /// </summary>
        public List<PointF> GenerarCurva(int pasos = 100)
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
            if (P0.X < 0 || P0.Y < 0 || P1.X < 0 || P1.Y < 0 ||
                P2.X < 0 || P2.Y < 0 || P3.X < 0 || P3.Y < 0)
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
                    g.DrawLine(pen, P2, P3);
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
            DibujarPuntoControl(g, P2, Color.Blue, "P2");
            DibujarPuntoControl(g, P3, Color.Red, "P3");

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

            // Dibujar proceso de construcción De Casteljau
            if (mostrarConstruccion)
            {
                var (nivel1, nivel2, nivel3) = CalcularPuntosConstruccion(t);

                // Nivel 1 (verde claro)
                using (Pen pen = new Pen(Color.FromArgb(100, Color.LightGreen), 2) { DashStyle = DashStyle.Dot })
                {
                    g.DrawLine(pen, nivel1[0], nivel1[1]);
                    g.DrawLine(pen, nivel1[1], nivel1[2]);
                }
                using (Brush b = new SolidBrush(Color.FromArgb(150, Color.LightGreen)))
                {
                    foreach (var p in nivel1)
                        g.FillEllipse(b, p.X - 3, p.Y - 3, 6, 6);
                }

                // Nivel 2 (verde medio)
                using (Pen pen = new Pen(Color.FromArgb(150, Color.Green), 2) { DashStyle = DashStyle.Dot })
                {
                    g.DrawLine(pen, nivel2[0], nivel2[1]);
                }
                using (Brush b = new SolidBrush(Color.FromArgb(200, Color.Green)))
                {
                    foreach (var p in nivel2)
                        g.FillEllipse(b, p.X - 4, p.Y - 4, 8, 8);
                }
            }

            // Punto final en la curva
            using (Brush b = new SolidBrush(Color.DarkGreen))
            {
                g.FillEllipse(b, actual.X - 8, actual.Y - 8, 16, 16);
            }
            using (Pen pen = new Pen(Color.White, 2))
            {
                g.DrawEllipse(pen, actual.X - 8, actual.Y - 8, 16, 16);
            }

            using (Font f = new Font("Arial", 10, FontStyle.Bold))
            using (Brush b = new SolidBrush(Color.Black))
            {
                g.DrawString($"t = {t:F2}", f, b, actual.X + 12, actual.Y - 12);
            }
        }
    }
}
