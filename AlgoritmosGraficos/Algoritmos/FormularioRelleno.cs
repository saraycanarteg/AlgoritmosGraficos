using Algoritmos;
using RellenoFiguras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoRelleno
{
    public partial class FormularioRelleno : Form
    {
        private static FormularioRelleno instancia = null;

        public static FormularioRelleno Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new FormularioRelleno();
                return instancia;
            }
        }
        private CAlgoritmoRelleno algoritmo;
        private List<Point> puntosPoligono;
        private Color colorRelleno;
        private Color colorBorde;
        private bool rellenoEnProceso = false;
        private bool modoLibre = false;
        private Random random;
        private const int VELOCIDAD_ANIMACION = 1;
        bool esperandoClickRelleno = false;
        int metodoSeleccionado = 0;
        bool figuraCompleta = false;

        public FormularioRelleno()
        {
            InitializeComponent();
            InicializarComponentes();
        }
        private void InicializarComponentes()
        {
            random = new Random();
            algoritmo = new CAlgoritmoRelleno(picBox.Width, picBox.Height);
            puntosPoligono = new List<Point>();

            GenerarColoresAleatorios();

            picBox.Image = algoritmo.ObtenerBitmap();
            picBox.MouseClick += picBox_MouseClick;

            btnTriangulo.Click += btnTriangulo_Click;
            btnCuadrado.Click += btnCuadrado_Click;
            btnPentagono.Click += btnPentagono_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnFinalizar.Click += btnFinalizar_Click;

            radioFigurasPredef.CheckedChanged += radioFigurasPredef_CheckedChanged;
            radioDibujoLibre.CheckedChanged += radioDibujoLibre_CheckedChanged;

            // Estado inicial: solo radio buttons habilitados
            EstadoInicial();
        }

        // ESTADO 1: INICIO - Solo radio buttons habilitados
        private void EstadoInicial()
        {
            radioFigurasPredef.Enabled = true;
            radioDibujoLibre.Enabled = true;

            btnTriangulo.Enabled = false;
            btnCuadrado.Enabled = false;
            btnPentagono.Enabled = false;
            btnLimpiar.Enabled = false;
            btnDibujar.Enabled = false;
            btnFinalizar.Enabled = false;
            btnRellenoRecursivo.Enabled = false;
            btnRellenoScanline.Enabled = false;
            btnRellenoBFS.Enabled = false;
            btnCancelarRelleno.Enabled = false;

            figuraCompleta = false;
        }
        // ESTADO 2: MODO SELECCIONADO - Habilita botones del modo + limpiar
        private void EstadoModoSeleccionado()
        {
            radioFigurasPredef.Enabled = true;
            radioDibujoLibre.Enabled = true;

            if (radioDibujoLibre.Checked)
            {
                // Modo dibujo libre
                btnTriangulo.Enabled = false;
                btnCuadrado.Enabled = false;
                btnPentagono.Enabled = false;
                btnLimpiar.Enabled = true;
                btnDibujar.Enabled = true;
                btnFinalizar.Enabled = true; // Se habilitará cuando haya suficientes puntos
            }
            else if (radioFigurasPredef.Checked)
            {
                // Modo figuras predeterminadas
                btnTriangulo.Enabled = true;
                btnCuadrado.Enabled = true;
                btnPentagono.Enabled = true;
                btnLimpiar.Enabled = true;
                btnFinalizar.Enabled = false;
                btnDibujar.Enabled = false;
                btnFinalizar.Enabled = false;
            }

            btnRellenoRecursivo.Enabled = false;
            btnRellenoScanline.Enabled = false;
            btnRellenoBFS.Enabled = false;
            btnCancelarRelleno.Enabled = false;
        }

        // ESTADO 3: FIGURA DIBUJADA - Habilita botones de relleno + limpiar + cancelar
        private void EstadoFiguraDibujada()
        {
            radioFigurasPredef.Enabled = true;
            radioDibujoLibre.Enabled = true;

            if (radioDibujoLibre.Checked)
            {
                btnTriangulo.Enabled = false;
                btnCuadrado.Enabled = false;
                btnPentagono.Enabled = false;
                btnFinalizar.Enabled = false;
            }
            else
            {
                btnTriangulo.Enabled = true;
                btnCuadrado.Enabled = true;
                btnPentagono.Enabled = true;
                btnFinalizar.Enabled = false;
            }

            btnLimpiar.Enabled = true;
            btnRellenoRecursivo.Enabled = true;
            btnRellenoScanline.Enabled = true;
            btnRellenoBFS.Enabled = true;
            btnCancelarRelleno.Enabled = true;

            figuraCompleta = true;
        }

        // ESTADO 4: RELLENO EN PROCESO - Solo botón Cancelar habilitado
        private void EstadoRellenoEnProceso()
        {
            radioFigurasPredef.Enabled = false;
            radioDibujoLibre.Enabled = false;

            btnTriangulo.Enabled = false;
            btnCuadrado.Enabled = false;
            btnPentagono.Enabled = false;
            btnLimpiar.Enabled = false;
            btnDibujar.Enabled = false;
            btnFinalizar.Enabled = false;
            btnRellenoRecursivo.Enabled = false;
            btnRellenoScanline.Enabled = false;
            btnRellenoBFS.Enabled = false;
            btnCancelarRelleno.Enabled = true;
        }

        private void GenerarColoresAleatorios()
        {
            // Generar color de borde (colores oscuros para mejor contraste)
            colorBorde = Color.FromArgb(
                random.Next(0, 128),
                random.Next(0, 128),
                random.Next(0, 128)
            );

            // Generar color de relleno (colores brillantes)
            colorRelleno = Color.FromArgb(
                random.Next(100, 255),
                random.Next(100, 255),
                random.Next(100, 255)
            );
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            algoritmo.LimpiarCanvas();
            puntosPoligono.Clear();
            ActualizarImagen();
            txtPixeles.Clear();

            GenerarColoresAleatorios();

            // Volver al estado de modo seleccionado
            EstadoModoSeleccionado();
        }

        private void picBox_Click(object sender, EventArgs e)
        {

        }

        private async void picBox_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;

            // Modo dibujo libre: agregar puntos
            if (modoLibre && !esperandoClickRelleno)
            {
                puntosPoligono.Add(p);

                using (Graphics g = Graphics.FromImage(algoritmo.ObtenerBitmap()))
                {
                    g.FillEllipse(new SolidBrush(colorBorde), p.X - 3, p.Y - 3, 6, 6);

                    if (puntosPoligono.Count > 1)
                    {
                        g.DrawLine(
                            new Pen(colorBorde, 2),
                            puntosPoligono[puntosPoligono.Count - 2],
                            p
                        );
                    }
                }

                ActualizarImagen();

                // Habilitar botón finalizar si hay al menos 3 puntos
                if (puntosPoligono.Count >= 3)
                {
                    btnFinalizar.Enabled = true;
                }

                return;
            }

            // Modo relleno: aplicar algoritmo seleccionado
            if (esperandoClickRelleno)
            {
                rellenoEnProceso = true;

                switch (metodoSeleccionado)
                {
                    case 1:
                        await algoritmo.IniciarRellenoAnimado(p, colorRelleno, colorBorde, ActualizarImagen, VELOCIDAD_ANIMACION);
                        break;

                    case 2:
                        await algoritmo.RellenoScanline(p, colorRelleno, colorBorde, ActualizarImagen);
                        break;

                    case 3:
                        await algoritmo.RellenoBFS(p, colorRelleno, colorBorde, ActualizarImagen);
                        break;
                }

                txtPixeles.Text = algoritmo.ObtenerListaPixeles();

                esperandoClickRelleno = false;
                rellenoEnProceso = false;

                // Restaurar al estado de figura dibujada
                EstadoFiguraDibujada();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (puntosPoligono.Count < 3)
            {
                MessageBox.Show(
                    "Necesitas al menos 3 puntos para crear un polígono.",
                    "Puntos Insuficientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Cerrar el polígono
            using (Graphics g = Graphics.FromImage(algoritmo.ObtenerBitmap()))
            {
                g.DrawLine(
                    new Pen(colorBorde, 2),
                    puntosPoligono[puntosPoligono.Count - 1],
                    puntosPoligono[0]
                );
            }

            ActualizarImagen();

            // Cambiar al estado de figura dibujada
            EstadoFiguraDibujada();
        }

        private void btnTriangulo_Click(object sender, EventArgs e)
        {
            algoritmo.LimpiarCanvas();
            puntosPoligono.Clear();
            txtPixeles.Clear();

            GenerarColoresAleatorios();

            List<Point> triangulo = new List<Point>
            {
                new Point(100, 50),
                new Point(50, 150),
                new Point(150, 150)
            };
            algoritmo.DibujarPoligono(triangulo, colorBorde);
            ActualizarImagen();

            // Cambiar al estado de figura dibujada
            EstadoFiguraDibujada();

        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            algoritmo.LimpiarCanvas();
            puntosPoligono.Clear();
            txtPixeles.Clear();

            GenerarColoresAleatorios();

            List<Point> cuadrado = new List<Point>
            {
                new Point(50, 50),
                new Point(150, 50),
                new Point(150, 150),
                new Point(50, 150)
            };
            algoritmo.DibujarPoligono(cuadrado, colorBorde);
            ActualizarImagen();

            // Cambiar al estado de figura dibujada
            EstadoFiguraDibujada();
        }

        private void btnPentagono_Click(object sender, EventArgs e)
        {
            algoritmo.LimpiarCanvas();
            puntosPoligono.Clear();
            txtPixeles.Clear();

            GenerarColoresAleatorios();

            List<Point> pentagono = new List<Point>();
            int lados = 5;
            int radio = 50;
            Point centro = new Point(60, 60);

            for (int i = 0; i < lados; i++)
            {
                double angulo = (2 * Math.PI * i / lados) - Math.PI / 2;
                int x = centro.X + (int)(radio * Math.Cos(angulo));
                int y = centro.Y + (int)(radio * Math.Sin(angulo));
                pentagono.Add(new Point(x, y));
            }

            algoritmo.DibujarPoligono(pentagono, colorBorde);
            ActualizarImagen();

            // Cambiar al estado de figura dibujada
            EstadoFiguraDibujada();

        }
        private void ActualizarImagen(Bitmap bitmap = null)
        {
            if (picBox.InvokeRequired)
            {
                picBox.Invoke(new Action(() => ActualizarImagen(bitmap)));
                return;
            }

            if (bitmap != null)
            {
                picBox.Image = new Bitmap(bitmap);
            }
            else
            {
                picBox.Image = new Bitmap(algoritmo.ObtenerBitmap());
            }
            picBox.Refresh();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {

        }

        private void btnRellenoRecursivo_Click(object sender, EventArgs e)
        {
            metodoSeleccionado = 1;
            esperandoClickRelleno = true;

            // Cambiar al estado de relleno en proceso
            EstadoRellenoEnProceso();

            MessageBox.Show(
                "Haz clic dentro de la figura para iniciar el relleno recursivo.",
                "Relleno Recursivo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnRellenoScanline_Click(object sender, EventArgs e)
        {
            metodoSeleccionado = 2;
            esperandoClickRelleno = true;

            // Cambiar al estado de relleno en proceso
            EstadoRellenoEnProceso();

            MessageBox.Show(
                "Haz clic dentro de la figura para iniciar el relleno Scanline.",
                "Relleno Scanline",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnRellenoBFS_Click(object sender, EventArgs e)
        {
            metodoSeleccionado = 3;
            esperandoClickRelleno = true;

            // Cambiar al estado de relleno en proceso
            EstadoRellenoEnProceso();

            MessageBox.Show(
                "Haz clic dentro de la figura para iniciar el relleno BFS.",
                "Relleno BFS",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnCancelarRelleno_Click(object sender, EventArgs e)
        {
            algoritmo.CancelarRelleno();
            esperandoClickRelleno = false;
            rellenoEnProceso = false;

            // Restaurar al estado de figura dibujada
            EstadoFiguraDibujada();
        }

        private void radioDibujoLibre_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDibujoLibre.Checked)
            {
                modoLibre = true;
                puntosPoligono.Clear();

                // Cambiar al estado de modo seleccionado
                EstadoModoSeleccionado();

                MessageBox.Show(
                    "Modo Dibujo Libre activado:\n\n" +
                    "• Haz clic en el canvas para agregar puntos\n" +
                    "• Necesitas mínimo 3 puntos para formar un polígono\n" +
                    "• Haz clic en 'Finalizar Polígono' para cerrar la figura\n" +
                    "• Luego selecciona un método de relleno\n" +
                    "• Los colores serán aleatorios automáticamente",
                    "Modo Dibujo Libre",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void radioFigurasPredef_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFigurasPredef.Checked)
            {
                modoLibre = false;
                puntosPoligono.Clear();

                // Cambiar al estado de modo seleccionado
                EstadoModoSeleccionado();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Location = new Point(
                    (this.MdiParent.ClientSize.Width - this.Width) / 2,
                    (this.MdiParent.ClientSize.Height - this.Height) / 2
                );
            }
        }
    }
}
