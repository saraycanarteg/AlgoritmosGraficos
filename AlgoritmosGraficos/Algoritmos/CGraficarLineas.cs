using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    internal class CGraficarLineas
    {
        public class Linea
        {
            public Point P1 { get; set; }
            public Point P2 { get; set; }
            public Linea(Point p1, Point p2) { P1 = p1; P2 = p2; }
        }

        private PictureBox pictureBox;
        private Bitmap bitmap;
        private Graphics graphics;

        public CGraficarLineas(PictureBox pic)
        {
            pictureBox = pic;
            bitmap = new Bitmap(pic.Width, pic.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Limpiar();
        }

        public void Limpiar()
        {
            graphics.Clear(Color.White);
            Actualizar();
        }

        public void DibujarLineas(List<Linea> lineas, Color color, float grosor, bool punteada = false)
        {
            using (Pen pen = new Pen(color, grosor))
            {
                if (punteada)
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                foreach (Linea linea in lineas)
                    graphics.DrawLine(pen, linea.P1, linea.P2);
            }
        }

        public void DibujarLineaTemporal(Point p1, Point p2)
        {
            using (Pen pen = new Pen(Color.Gray, 1))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                graphics.DrawLine(pen, p1, p2);
            }
        }

        public void DibujarRectangulo(Rectangle rect, Color color, float grosor, bool punteada = false)
        {
            using (Pen pen = new Pen(color, grosor))
            {
                if (punteada)
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                graphics.DrawRectangle(pen, rect);
            }
        }

        private void Actualizar()
        {
            if (pictureBox.Image != null)
                pictureBox.Image.Dispose();
            pictureBox.Image = (Bitmap)bitmap.Clone();
        }

        public void Refrescar()
        {
            Actualizar();
        }

        public void Dispose()
        {
            graphics?.Dispose();
            bitmap?.Dispose();
        }
    }
}
