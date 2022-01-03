using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gif
{
    public partial class Form1 : Form
    {
        PictureBox imagen = new PictureBox();
        static Graphics g;
        int heightWindow = Screen.PrimaryScreen.WorkingArea.Height;
        int widthWindow = Screen.PrimaryScreen.WorkingArea.Width;
        static int frameWidth = 200;
        static int frameHeight = 326;

        public Form1()
        {
            InitializeComponent();

            int localWidth = widthWindow - frameWidth;
            int localHeight = heightWindow - frameHeight + 15;

            ShowInTaskbar = false;
            TopMost = true;
            Width = frameWidth + 40;
            Height = frameHeight + 40;
            BackColor = Color.DarkGray;
            TransparencyKey = Color.DarkGray;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(localWidth, localHeight);

            FormBorderStyle = FormBorderStyle.None;

            imagen.Width = frameWidth;
            imagen.Height = frameHeight;
            imagen.SizeMode = PictureBoxSizeMode.Zoom;
            var res = Image.FromFile(Application.StartupPath+@"\imagenes\EMT.gif");
            ScaleImage(res, frameWidth, frameHeight);
            imagen.Image = res;
            this.Controls.Add(imagen);
        }

        static void ScaleImage(Image res, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / res.Width;
            var ratioY = (double)maxHeight / res.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(res.Width * ratio);
            var newHeight = (int)(res.Height * ratio);
            Bitmap mapa = new Bitmap(newWidth, newHeight);
            g = Graphics.FromImage(mapa);
            g.DrawImage(res, 0, 0, newWidth, newHeight);
            g.Dispose();
        }

        private void ocultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
              
            if (this.Visible)
            {
                this.Hide();
                ocultarToolStripMenuItem.Text = "Mostrar";
            }
            else if (!this.Visible)
            {
                this.Show();
                this.ShowInTaskbar = false;
                ocultarToolStripMenuItem.Text = "Ocultar";
            }
            
        }

        private void configuracionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pausarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imagen.Enabled)
            {
                imagen.Enabled = false;
                pausarToolStripMenuItem.Text = "Reproducir";
            }
            else if (!imagen.Enabled)
            {
                imagen.Enabled = true;
                pausarToolStripMenuItem.Text = "Pausar";
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
