using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace curvasBezier
{
    /// <summary>
    /// Implementa curvas de Bézier lineales: B(t) = (1-t)P0 + tP1, donde t ∈ [0,1]
    /// </summary>
    public class CBezierLineal
    {
        public PointF P0 { get; set; }
        public PointF P1 { get; set; }
        public List<PointF> Rastro { get; private set; } = new List<PointF>();

        public CBezierLineal(PointF p0, PointF p1)
        {
            P0 = p0;
            P1 = p1;
        }

        /// <summary>
        /// Calcula punto en la curva: B(t) = (1-t)P0 + tP1
        /// </summary>
        public PointF CalcularPunto(float t)
        {
            if (t < 0 || t > 1)
                throw new ArgumentOutOfRangeException(nameof(t), "t debe estar en [0,1]");

            float x = (1 - t) * P0.X + t * P1.X;
            float y = (1 - t) * P0.Y + t * P1.Y;
            return new PointF(x, y);
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
            if (P0.X == P1.X && P0.Y == P1.Y) return false;
            if (P0.X < 0 || P0.Y < 0 || P1.X < 0 || P1.Y < 0) return false;
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
        public void Dibujar(Graphics g, bool mostrarCurva, bool mostrarRastro, bool mostrarAnimacion, float t)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // Línea de control
            using (Pen pen = new Pen(Color.LightGray, 1) { DashStyle = DashStyle.Dash })
            {
                g.DrawLine(pen, P0, P1);
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
            DibujarPuntoControl(g, P0, "P0");
            DibujarPuntoControl(g, P1, "P1");

            // Animación
            if (mostrarAnimacion)
            {
                DibujarAnimacion(g, t);
            }
        }

        private void DibujarCurva(Graphics g)
        {
            List<PointF> puntos = GenerarCurva(50);
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                for (int i = 0; i < puntos.Count - 1; i++)
                    g.DrawLine(pen, puntos[i], puntos[i + 1]);
            }
        }

        private void DibujarRastro(Graphics g)
        {
            using (Pen pen = new Pen(Color.Orange, 1))
            {
                for (int i = 0; i < Rastro.Count - 1; i++)
                    g.DrawLine(pen, Rastro[i], Rastro[i + 1]);
            }
        }

        private void DibujarPuntoControl(Graphics g, PointF punto, string label)
        {
            using (Brush b = new SolidBrush(Color.Red))
            using (Pen pen = new Pen(Color.Black, 1))
            using (Font f = new Font("Arial", 9, FontStyle.Bold))
            using (Brush bt = new SolidBrush(Color.Black))
            {
                g.FillEllipse(b, punto.X - 5, punto.Y - 5, 10, 10);
                g.DrawEllipse(pen, punto.X - 5, punto.Y - 5, 10, 10);
                g.DrawString(label, f, bt, punto.X + 8, punto.Y - 8);
            }
        }

        private void DibujarAnimacion(Graphics g, float t)
        {
            PointF actual = CalcularPunto(t);

            using (Brush b = new SolidBrush(Color.Green))
            {
                g.FillEllipse(b, actual.X - 6, actual.Y - 6, 12, 12);
            }

            using (Font f = new Font("Arial", 9))
            using (Brush b = new SolidBrush(Color.Black))
            {
                g.DrawString($"t = {t:F2}", f, b, actual.X + 10, actual.Y - 10);
            }
        }
    }
}