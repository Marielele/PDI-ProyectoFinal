using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing.Imaging;

namespace PPDI
{
    public partial class Form4 : Form
    {
        VideoCapture grabber;
        Bitmap video;
        Image<Bgr, Byte> currentFrame;
        double duracion;
        double FrameCount;
        bool videoload = false;
        string filterName;
        public Form4()
        {
            InitializeComponent();
            this.ttfilter.SetToolTip(this.filtro1, "Filtro escala de grises");
            this.ttfilter.SetToolTip(this.filtro5, "Rojizo");
            this.ttfilter.SetToolTip(this.filtro4, "Filtro rosa-azulado");
            this.ttfilter.SetToolTip(this.filtro9, "Filtro sepia");
            this.ttfilter.SetToolTip(this.filtro11, "Filtro negativo");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Files (* .mp4) | * .mp4";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                grabber = new VideoCapture(ofd.FileName);
                grabber.QueryFrame();

                Mat m = new Mat();
                grabber.Read(m);
                //pictureBox1.Image = m.Bitmap;

                currentFrame = new Image<Bgr, byte>(m.Bitmap);
                currentFrame.Resize(pictureBox1.Width, pictureBox1.Height, Inter.Cubic);

                //current frame 
                pictureBox1.Image = currentFrame.Bitmap;

                duracion = grabber.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);

                //capprop posicion de los frames
                FrameCount = grabber.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames);
                videoload = true;
                pictureBox1.BackgroundImage = null;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (videoload)
            {
                Application.Idle += new EventHandler(CargarVideo);
            }
            else
            {
                MessageBox.Show("No se carga el video", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVideo(object sender, EventArgs e)
        {
            if (FrameCount < duracion - 2)
            {
                Mat m = new Mat();
                grabber.Read(m);

                currentFrame = new Image<Bgr, byte>(m.Bitmap);
                currentFrame.Resize(pictureBox1.Width, pictureBox1.Height, Inter.Cubic);
                FrameCount = grabber.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames);
            }
            else
            {
                FrameCount = 0;
                grabber.SetCaptureProperty(CapProp.PosFrames, 0);
            }

            switch (filterName)
            {
                case "Sepia":
                    {
                        Image img = currentFrame.Bitmap;
                        Bitmap bmpinverted = new Bitmap(img.Width, img.Height);

                        ImageAttributes Ia = new ImageAttributes();
                        ColorMatrix cmPicture = new ColorMatrix(new float[][]
                            {
                                new float []{.349f, .349f, .272f, 0, 0 },
                                new float []{.769f, .686f, .534f, 0, 0 },
                                new float []{.189f, .168f, .131f, 0, 0 },
                                new float []{.0f, .0f, .0f, 1, 0 },
                                new float []{.0f, .0f, .0f, 0, 1 },
                            });
                        Ia.SetColorMatrix(cmPicture);
                        Graphics gr = Graphics.FromImage(bmpinverted);

                        gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, Ia);
                        gr.Dispose();
                        pictureBox1.Image = bmpinverted;

                        break;
                    }

                case "Gris":
                    {
                        Image img = currentFrame.Bitmap;
                        Bitmap bmpinverted = new Bitmap(img.Width, img.Height);

                        ImageAttributes Ia = new ImageAttributes();
                        ColorMatrix cmPicture = new ColorMatrix(new float[][]
                            {
                                new float []{.3f, .3f, .3f, 0, 0 },
                                new float []{.3f, .3f, .3f, 0, 0 },
                                new float []{.3f, .3f, .3f, 0, 0 },
                                new float []{0, 0, 0, 1, 0 },
                                new float []{0, 0, 0, 0, 1 },
                            });
                        Ia.SetColorMatrix(cmPicture);
                        Graphics gr = Graphics.FromImage(bmpinverted);

                        gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, Ia);
                        gr.Dispose();
                        pictureBox1.Image = bmpinverted;

                        break;
                    }
                case "Negativo":
                    {
                        Image img = currentFrame.Bitmap;
                        Bitmap bmpinverted = new Bitmap(img.Width, img.Height);

                        ImageAttributes Ia = new ImageAttributes();
                        ColorMatrix cmPicture = new ColorMatrix(new float[][]
                            {
                                new float []{-1, 0, 0, 0, 0 },
                                new float []{0, -1, 0, 0, 0 },
                                new float []{0, 0, 0, -1, 0 },
                                new float []{0, 0, 0, 1, 0 },
                                new float []{1, 1, 1, 1, 1 },
                            });
                        Ia.SetColorMatrix(cmPicture);
                        Graphics gr = Graphics.FromImage(bmpinverted);

                        gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, Ia);
                        gr.Dispose();
                        pictureBox1.Image = bmpinverted;

                        break;
                    }
                case "Rojizo":
                    {
                        Image img = currentFrame.Bitmap;

                        Bitmap bmpinverted = new Bitmap(img.Width, img.Height);

                        ImageAttributes Ia = new ImageAttributes();
                        ColorMatrix cmPicture = new ColorMatrix(new float[][]
                            {
                                new float []{.588f, 0, 0, 0, 0 },
                                new float []{0,.058f, 0, 0, 0 },
                                new float []{0, 0, 0, .156f, 0 },
                                new float []{0, 0, 0, 1, 0 },
                                new float []{ 0, 0, 0, 0, 1 },
                            });
                        Ia.SetColorMatrix(cmPicture);
                        Graphics gr = Graphics.FromImage(bmpinverted);

                        gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, Ia);
                        gr.Dispose();
                        pictureBox1.Image = bmpinverted;

                        break;
                    }
                case "RosaAzulado":
                    {
                        Image img = currentFrame.Bitmap;

                        Bitmap bmpinverted = new Bitmap(img.Width, img.Height);

                        ImageAttributes Ia = new ImageAttributes();
                        ColorMatrix cmPicture = new ColorMatrix(new float[][]
                            {
                                new float []{1, 0, 0, 0, 0 },
                                new float []{0, -2, -1, 0, 0 },
                                new float []{0, -1, 1, 1, 0 },
                                new float []{0, 0, 1, 2, 0 },
                                new float []{0, 0, 0, 0, 1 },
                            });
                        Ia.SetColorMatrix(cmPicture);
                        Graphics gr = Graphics.FromImage(bmpinverted);

                        gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, Ia);
                        gr.Dispose();
                        pictureBox1.Image = bmpinverted;

                        break;
                    }

                default:
                    {
                        pictureBox1.Image = currentFrame.Bitmap;
                        break;
                    }


            }
        }

        private void filtro1_Click(object sender, EventArgs e)
        {
            if (videoload)
            {
                filterName = "Gris";
            }
            else
            {
                MessageBox.Show("No se cargo el video", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filtro9_Click(object sender, EventArgs e)
        {
            if (videoload)
            {
                filterName = "Sepia";
            }
            else
            {
                MessageBox.Show("No se cargo el video", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filtro11_Click(object sender, EventArgs e)
        {
            if (videoload)
            {
                filterName = "Negativo";
            }
            else
            {
                MessageBox.Show("No se cargo el video", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filtro4_Click(object sender, EventArgs e)
        {
            if (videoload)
            {
                filterName = "RosaAzulado";
            }
            else
            {
                MessageBox.Show("No se cargo el video", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filtro5_Click(object sender, EventArgs e)
        {
            if (videoload)
            {
                filterName = "Rojizo";
            }
            else
            {
                MessageBox.Show("No se cargo el video", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
