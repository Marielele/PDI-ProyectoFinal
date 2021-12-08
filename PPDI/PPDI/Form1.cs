﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ttFiltro.SetToolTip(this.filtro1, "Filtro escala de grises");
            this.ttFiltro.SetToolTip(this.filtro2, "Filtro degradado");
            this.ttFiltro.SetToolTip(this.filtro3, "Filtro binario");
            this.ttFiltro.SetToolTip(this.filtro5, "Filtro rojizo");
            this.ttFiltro.SetToolTip(this.filtro6, "Filtro frío");
            this.ttFiltro.SetToolTip(this.filtro7, "Filtro glitch");
            this.ttFiltro.SetToolTip(this.filtro9, "Filtro sepia");
            this.ttFiltro.SetToolTip(this.filtro11, "Filtro negativo");
            if (pictureBox1.Image == null) 
            {
                filtro1.Enabled = false;
                filtro2.Enabled = false;
                filtro3.Enabled = false;
                filtro4.Enabled = false;
                filtro5.Enabled = false;
                filtro6.Enabled = false;
                filtro7.Enabled = false;
                filtro8.Enabled = false;
                filtro9.Enabled = false;
                filtro10.Enabled = false;
                filtro11.Enabled = false;
                filtro12.Enabled = false;
                Button1.Enabled = false;
                button5.Enabled = false;
            }
        }

        private void agregarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogImg.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialogImg.FileName;
                pbImgNoEdit.ImageLocation = openFileDialogImg.FileName;
                tbNombreArchivo.Text = openFileDialogImg.FileName;
                filtro1.Enabled = true;
                filtro2.Enabled = true;
                filtro3.Enabled = true;
                filtro4.Enabled = true;
                filtro5.Enabled = true;
                filtro6.Enabled = true;
                filtro7.Enabled = true;
                filtro8.Enabled = true;
                filtro9.Enabled = true;
                filtro10.Enabled = true;
                filtro11.Enabled = true;
                filtro12.Enabled = true;
                Button1.Enabled = true;
                button5.Enabled = true;
            }
        }

        private void tamañoCompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new Form2();
            if (pictureBox1.Image == null)
            {
                formulario.Text = "Suba una imagen";
            }
                ((PictureBox)formulario.Controls["pictureBox1"]).Image = this.pictureBox1.Image;
                formulario.Show();

        }

        private void agregarVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (openFileDialogVid.ShowDialog() == DialogResult.OK)
            //{
            //    axWindowsMediaPlayer1.Visible = true;
            //    axWindowsMediaPlayer1.URL = openFileDialogVid.FileName;
            //    tbNombreArchivo.Text = openFileDialogVid.FileName;
            //    axWindowsMediaPlayer1.settings.autoStart = true;
            //    axWindowsMediaPlayer1.settings.setMode("loop", true);
            //    filtro1.Enabled = true;
            //    filtro2.Enabled = true;
            //    filtro3.Enabled = true;
            //    filtro4.Enabled = true;
            //    filtro5.Enabled = true;
            //    filtro6.Enabled = true;
            //    filtro7.Enabled = true;
            //    filtro8.Enabled = true;
            //    filtro9.Enabled = true;
            //    filtro10.Enabled = true;
            //    filtro11.Enabled = true;
            //    filtro12.Enabled = true;
            //    Button1.Enabled = true;
            //    button5.Enabled = true; ;
            //}
            Form formulario = new Form4();
            formulario.Show();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
                Image imagen = pictureBox1.Image;
                saveFileDialogImg.ShowDialog();
                imagen.Save(saveFileDialogImg.FileName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
            pictureBox1.Image = copyBitmap;
            histoAcumulado = histogramaAcumulado(copyBitmap);
            button2_Click(sender, e);
            button3_Click(sender, e);
            button4_Click(sender, e);
        }

        private void filtro3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
                Binario(copyBitmap);
                pictureBox1.Image = copyBitmap;
                histoAcumulado = histogramaAcumulado(copyBitmap);
                button2_Click(sender, e);
                button3_Click(sender, e);
                button4_Click(sender, e);
            }
        }

        private void filtro1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
                Grises(copyBitmap);
                pictureBox1.Image = copyBitmap;
                //Cargamos los histogramas
                //Bitmap bmp = new Bitmap(pictureBox1.Image);
                histoAcumulado = histogramaAcumulado(copyBitmap);
                //Ejecutamos el botón del histograma rojo
                button2_Click(sender, e);
                button3_Click(sender, e);
                button4_Click(sender, e);
            }

        }

        private void borrarFiltrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pbImgNoEdit.Image;
        }

        private void filtro11_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
                Negativo(copyBitmap);
                pictureBox1.Image = copyBitmap;
                //Cargamos los histogramas
                //Bitmap bmp = new Bitmap(pictureBox1.Image);
                histoAcumulado = histogramaAcumulado(copyBitmap);
                //Ejecutamos el botón del histograma rojo
                button2_Click(sender, e);
                button3_Click(sender, e);
                button4_Click(sender, e);
            }

        }

        private void filtro9_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
            Sepia(copyBitmap);
            pictureBox1.Image = copyBitmap;
            //Cargamos los histogramas
            //Bitmap bmp = new Bitmap(pictureBox1.Image);
            histoAcumulado = histogramaAcumulado(copyBitmap);
            //Ejecutamos el botón del histograma rojo
            button2_Click(sender, e);
            button3_Click(sender, e);
            button4_Click(sender, e);
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new Form3();
            formulario.Show();
        }

        private void filtro2_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
            Degradado(copyBitmap);
            pictureBox1.Image = copyBitmap;
            //Cargamos los histogramas
            //Bitmap bmp = new Bitmap(pictureBox1.Image);
            histoAcumulado = histogramaAcumulado(copyBitmap);
            //Ejecutamos el botón del histograma rojo
            button2_Click(sender, e);
            button3_Click(sender, e);
            button4_Click(sender, e);
        }

        private void filtro5_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
            Rojizo(copyBitmap);
            pictureBox1.Image = copyBitmap;
            //Cargamos los histogramas
            histoAcumulado = histogramaAcumulado(copyBitmap);
            //Ejecutamos el botón del histograma rojo
            button2_Click(sender, e);
            button3_Click(sender, e);
            button4_Click(sender, e);
        }

        private void filtro6_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
            Frio(copyBitmap);
            pictureBox1.Image = copyBitmap;
            histoAcumulado = histogramaAcumulado(copyBitmap);
            button2_Click(sender, e);
            button3_Click(sender, e);
            button4_Click(sender, e);
        }

        private void filtro10_Click(object sender, EventArgs e)
        {

        }

        private void filtro7_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
            Glitch(copyBitmap);
            pictureBox1.Image = copyBitmap;
            histoAcumulado = histogramaAcumulado(copyBitmap);
            button2_Click(sender, e);
            button3_Click(sender, e);
            button4_Click(sender, e);
        }

        private void borrarVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void borrarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pbImgNoEdit.Image = null;
            filtro1.Enabled = false;
            filtro2.Enabled = false;
            filtro3.Enabled = false;
            filtro4.Enabled = false;
            filtro5.Enabled = false;
            filtro6.Enabled = false;
            filtro7.Enabled = false;
            filtro8.Enabled = false;
            filtro9.Enabled = false;
            filtro10.Enabled = false;
            filtro11.Enabled = false;
            filtro12.Enabled = false;
            Button1.Enabled = false;
            button5.Enabled = false;
        }

        //////////////////////////////////////Filtros////////////////////////////////////////

        //Filtro 1 - Escala de grises
        public void Grises(Bitmap imagen)
        {
            for (int i = 0; i < imagen.Width; i++)
            {
                for (int j = 0; j < imagen.Height; j++)
                {
                    Color bmpColor = imagen.GetPixel(i, j);

                    int red = bmpColor.R;
                    int green = bmpColor.G;
                    int blue = bmpColor.B;

                    int pixel = (red + green + blue) / 3;

                    imagen.SetPixel(i, j, Color.FromArgb(pixel, pixel, pixel));
                }
            }
        }

        //Filtro 2 - Degradado
        public void Degradado(Bitmap imagen)
        {
            float r1 = 163;
            float g1 = 127;
            float b1 = 235;

            float r2 = 88;
            float g2 = 219;
            float b2 = 215;

            int r, g, b = 0;

            float dr = (r2 - r1) / imagen.Width;
            float dg = (g2 - g1) / imagen.Width;
            float db = (b2 - b1) / imagen.Width;

            Grises(imagen);

            for (int i = 0; i < imagen.Width; i++)
            {
                for (int j = 0; j < imagen.Height; j++)
                {
                    Color bmpColor = imagen.GetPixel(i, j);

                    r = (int)((r1 / 255.0f) * bmpColor.R);
                    g = (int)((g1 / 255.0f) * bmpColor.G);
                    b = (int)((b1 / 255.0f) * bmpColor.B);

                    if (r > 255) r = 255;
                    else if (r < 0) r = 0;

                    if (g > 255) g = 255;
                    else if (g < 0) g = 0;

                    if (b > 255) b = 255;
                    else if (b < 0) b = 0;

                    imagen.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
                r1 = (r1 + dr);
                g1 = (g1 + dg);
                b1 = (b1 + db);
            }
        }

        //Filtro 3 - Binario
        public void Binario(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color bmpColor = bmp.GetPixel(i, j);

                    int red = bmpColor.R;
                    int green = bmpColor.G;
                    int blue = bmpColor.B;

                    int gray = (red + green + blue) / 3;

                    if (gray > 127)
                    {
                        gray = 255;
                    }
                    else
                    {
                        gray = 0;
                    }

                    red = gray;
                    green = gray;
                    blue = gray;

                    bmp.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }
        }

        //Filtro 5 - Rojizo
        public void Rojizo(Bitmap imagen)
        {
            double colorr = 150 / 255.0;
            double colorg = 15 / 255.0;
            double colorb = 40 / 255.0;

            int r, g, b = 0;
            Grises(imagen);

            for (int i = 0; i < imagen.Width; i++)
            {
                for (int j = 0; j < imagen.Height; j++)
                {
                    Color bmpColor = imagen.GetPixel(i, j);

                    r = (int)(bmpColor.R * colorr);
                    g = (int)(bmpColor.G * colorg);
                    b = (int)(bmpColor.B * colorb);

                    imagen.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
        }

        //Filtro 6 - Frio
        public void Frio(Bitmap imagen)
        {
            double colorr = 130 / 255.0;
            double colorg = 172 / 255.0;
            double colorb = 245 / 255.0;

            int r, g, b = 0;

            for (int i = 0; i < imagen.Width; i++)
            {
                for (int j = 0; j < imagen.Height; j++)
                {
                    Color bmpColor = imagen.GetPixel(i, j);

                    r = (int)(bmpColor.R * colorr);
                    g = (int)(bmpColor.G * colorg);
                    b = (int)(bmpColor.B * colorb);

                    imagen.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
        }

        //Filtro 7 - Glitch
        public void Glitch(Bitmap imagen)
        {
            int desfase = 4;
            int r = 0;
            int g = 0;
            int b = 0;

            for (int i = 0; i < imagen.Width; i++)
            {
                for (int j = 0; j < imagen.Height; j++)
                {
                    g = imagen.GetPixel(i, j).G;
                    if (i + desfase < imagen.Width)
                    {
                        r = imagen.GetPixel(i + desfase, j).R;
                    }
                    else
                    {
                        r = 0;
                    }
                    if (i - desfase >= 0)
                    {
                        b = imagen.GetPixel(i - desfase, j).B;
                    }
                    else
                    {
                        b = 0;
                    }
                    imagen.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
        }

        //Filtro 9 - Sepia
        public void Sepia(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color bmpColor = bmp.GetPixel(i, j);

                    int A = bmpColor.A;
                    int R = bmpColor.R;
                    int G = bmpColor.G;
                    int B = bmpColor.B;

                    int tr = (int)(0.393 * R + 0.769 * G + 0.189 * B);
                    int tg = (int)(0.349 * R + 0.686 * G + 0.168 * B);
                    int tb = (int)(0.272 * R + 0.534 * G + 0.131 * B);

                    if (tr > 255)
                    {
                        R = 255;
                    }
                    else
                    {
                        R = tr;
                    }

                    if (tg > 255)
                    {
                        G = 255;
                    }
                    else
                    {
                        G = tg;
                    }

                    if (tb > 255)
                    {
                        B = 255;
                    }
                    else
                    {
                        B = tb;
                    }
                    bmp.SetPixel(i, j, Color.FromArgb(A, R, G, B));
                }
            }
        }

        //Filtro 10 - Sobel
        public void Sobel(Bitmap imagen)
        {

        }

        //Filtro 11 - Negativo
        public void Negativo(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color bmpColor = bmp.GetPixel(i, j);

                    int red = bmpColor.R;
                    int green = bmpColor.G;
                    int blue = bmpColor.B;

                    //int gray = (byte)(.299 * red + .587 * green + .114 * blue);
                    int pixel = (red + green + blue) / 3;
                    pixel = pixel - 255;

                    red = red - 255;
                    green = green - 255;
                    blue = blue - 255;

                    bmp.SetPixel(i, j, Color.FromArgb(red * -1, green * -1, blue * -1));
                }
            }
        }

        //////////////////////////////////////Fin filtros////////////////////////////////////////


        //////////////////////////////////////HISTOGRAMA////////////////////////////////////////
        public int[,] histogramaAcumulado(Bitmap bmp)
        {
            //Creamos una matriz que contendrá el histograma acumulado
            byte Rojo = 0;
            byte Verde = 0;
            byte Azul = 0;
            //Declaramos tres variables que almacenarán los colores
            int[,] matrizAcumulada = new int[3, 256];
            //Recorremos la matriz
            for (int i = 0; i <= bmp.Width - 1; i++)
            {
                for (int j = 0; j <= bmp.Height - 1; j++)
                {
                    Rojo = bmp.GetPixel(i, j).R;
                    //Asignamos el color
                    Verde = bmp.GetPixel(i, j).G;
                    Azul = bmp.GetPixel(i, j).B;
                    //ACumulamos los valores.
                    matrizAcumulada[0, Rojo] += 1;
                    matrizAcumulada[1, Verde] += 1;
                    matrizAcumulada[2, Azul] += 1;
                }
            }
            return matrizAcumulada;
        }
        int[,] histoAcumulado;

        private void button2_Click(object sender, EventArgs e)
        {
            //Borramos el posible contenido del chart
            chart1.Series["Histograma"].Points.Clear();
            //Los ponesmos del colores correspondiente
            chart1.Series["Histograma"].Color = Color.Red;
            for (int i = 0; i <= 255; i++)
            {
                chart1.Series["Histograma"].Points.AddXY(i + 1, histoAcumulado[0, i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Borramos el posible contenido del chart
            chart2.Series["Histograma"].Points.Clear();
            //Los ponesmos del colores correspondiente
            chart2.Series["Histograma"].Color = Color.Green;
            for (int i = 0; i <= 255; i++)
            {
                chart2.Series["Histograma"].Points.AddXY(i + 1, histoAcumulado[1, i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Borramos el posible contenido del chart
            chart3.Series["Histograma"].Points.Clear();
            //Los ponesmos del colores correspondiente
            chart3.Series["Histograma"].Color = Color.Blue;
            for (int i = 0; i <= 255; i++)
            {
                chart3.Series["Histograma"].Points.AddXY(i + 1, histoAcumulado[2, i]);
            }
        }

    }
}
