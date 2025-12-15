using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace curvasBezier
{
    /// <summary>
    /// Implementa curvas B-Spline con grado variable
    /// B-Spline es una generalización de las curvas de Bézier
    /// </summary>
    public class CBSpline
    {
        public List<PointF> PuntosControl { get; set; }
        public int Grado { get; set; }
        public List<float> VectorNudos { get; private set; }
        public List<PointF> Rastro { get; private set; } = new List<PointF>();

        public CBSpline(List<PointF> puntosControl, int grado)
        {
            if (puntosControl == null || puntosControl.Count < grado + 1)
                throw new ArgumentException($"Se necesitan al menos {grado + 1} puntos de control para grado {grado}");

            PuntosControl = puntosControl;
            Grado = grado;
            GenerarVectorNudos();
        }

        /// <summary>
        /// Genera el vector de nudos con clamping (nudos repetidos en extremos)
        /// Esto hace que la curva pase por el primer y último punto de control
        /// </summary>
        private void GenerarVectorNudos()
        {
            int n = PuntosControl.Count - 1;
            int m = n + Grado + 1;
            VectorNudos = new List<float>();

            // Vector de nudos con clamping (open uniform)
            // Repite los nudos en los extremos k+1 veces
            for (int i = 0; i <= m; i++)
            {
                if (i <= Grado)
                    VectorNudos.Add(0);
                else if (i >= n + 1)
                    VectorNudos.Add(n - Grado + 1);
                else
                    VectorNudos.Add(i - Grado);
            }
        }

        /// <summary>
        /// Calcula la función base B-Spline usando el algoritmo de Cox-de Boor
        /// </summary>
        private float FuncionBase(int i, int k, float t)
        {
            if (k == 0)
            {
                return (t >= VectorNudos[i] && t < VectorNudos[i + 1]) ? 1.0f : 0.0f;
            }

            float denom1 = VectorNudos[i + k] - VectorNudos[i];
            float denom2 = VectorNudos[i + k + 1] - VectorNudos[i + 1];

            float term1 = 0, term2 = 0;

            if (denom1 > 0.0001f)
                term1 = ((t - VectorNudos[i]) / denom1) * FuncionBase(i, k - 1, t);

            if (denom2 > 0.0001f)
                term2 = ((VectorNudos[i + k + 1] - t) / denom2) * FuncionBase(i + 1, k - 1, t);

            return term1 + term2;
        }

        /// <summary>
        /// Calcula un punto en la curva B-Spline para un parámetro t dado
        /// </summary>
        public PointF CalcularPunto(float t)
        {
            int n = PuntosControl.Count - 1;
            float tMin = VectorNudos[Grado - 1];
            float tMax = VectorNudos[n + 1];

            if (t < tMin) t = tMin;
            if (t >= tMax) t = tMax - 0.0001f;

            float x = 0, y = 0;

            for (int i = 0; i <= n; i++)
            {
                float basis = FuncionBase(i, Grado, t);
                x += PuntosControl[i].X * basis;
                y += PuntosControl[i].Y * basis;
            }

            return new PointF(x, y);
        }

        /// <summary>
        /// Genera todos los puntos de la curva B-Spline
        /// </summary>
        public List<PointF> GenerarCurva(int pasos = 100)
        {
            if (pasos < 2)
                throw new ArgumentException("Mínimo 2 pasos", nameof(pasos));

            List<PointF> puntos = new List<PointF>();
            int n = PuntosControl.Count - 1;
            float tMin = VectorNudos[Grado - 1];
            float tMax = VectorNudos[n + 1];

            for (int i = 0; i <= pasos; i++)
            {
                float t = tMin + (tMax - tMin) * i / pasos;
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
            if (PuntosControl == null || PuntosControl.Count < Grado + 1)
                return false;

            foreach (var p in PuntosControl)
            {
                if (p.X < 0 || p.Y < 0)
                    return false;
            }
            return true;
        }

        public float DistanciaAPunto(PointF punto, PointF control)
        {
            float dx = punto.X - control.X;
            float dy = punto.Y - control.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public int ObtenerPuntoMasCercano(PointF punto)
        {
            int indice = -1;
            float distMin = float.MaxValue;

            for (int i = 0; i < PuntosControl.Count; i++)
            {
                float dist = DistanciaAPunto(punto, PuntosControl[i]);
                if (dist < 15 && dist < distMin)
                {
                    distMin = dist;
                    indice = i;
                }
            }

            return indice;
        }

        /// <summary>
        /// Dibuja la curva completa
        /// </summary>
        public void Dibujar(Graphics g, bool mostrarCurva, bool mostrarRastro, bool mostrarAnimacion,
                           bool mostrarPoligono, bool mostrarPuntos, float t)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // Polígono de control
            if (mostrarPoligono && PuntosControl.Count > 1)
            {
                using (Pen pen = new Pen(Color.LightGray, 1) { DashStyle = DashStyle.Dash })
                {
                    for (int i = 0; i < PuntosControl.Count - 1; i++)
                        g.DrawLine(pen, PuntosControl[i], PuntosControl[i + 1]);
                }
            }

            // Curva B-Spline
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
            if (mostrarPuntos)
            {
                for (int i = 0; i < PuntosControl.Count; i++)
                {
                    Color color = (i == 0 || i == PuntosControl.Count - 1) ? Color.Red : Color.Blue;
                    DibujarPuntoControl(g, PuntosControl[i], color, $"P{i}");
                }
            }

            // Animación
            if (mostrarAnimacion)
            {
                DibujarAnimacion(g, t);
            }
        }

        private void DibujarCurva(Graphics g)
        {
            List<PointF> puntos = GenerarCurva(150);
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
            try
            {
                PointF actual = CalcularPunto(t);

                using (Brush b = new SolidBrush(Color.DarkGreen))
                {
                    g.FillEllipse(b, actual.X - 7, actual.Y - 7, 14, 14);
                }
                using (Pen pen = new Pen(Color.White, 2))
                {
                    g.DrawEllipse(pen, actual.X - 7, actual.Y - 7, 14, 14);
                }

                using (Font f = new Font("Arial", 9, FontStyle.Bold))
                using (Brush bt = new SolidBrush(Color.Black))
                {
                    g.DrawString($"t = {t:F2}", f, bt, actual.X + 10, actual.Y - 10);
                }
            }
            catch { }
        }
    }
}