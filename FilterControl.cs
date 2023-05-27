using ProcesamientoDeImagenesFil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using AForge.Video;
using AForge.Video.FFMPEG;
using AForge.Imaging.Filters;
using System.Threading;

namespace ProcesamientoDeImagenes
{
    public partial class FilterControl : UserControl
    {
        Bitmap imagenOriginal = null;
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 256;

        string rutaVideoLoad = null;
        VideoFileSource videoSource;
        List<Bitmap> framesList = new List<Bitmap>();
        string pathTempFrames;
        static int opcionFiltros = 0;
        static bool guardarFrames = false;

        //Filtros
        Bitmap bitmap;
        Grayscale Gray = new Grayscale(0.2125, 0.7154, 0.0721);
        Invert invert = new Invert();
        HistogramEqualization heFiltro = new HistogramEqualization();
        //private float[] DataValues = new float[10];
        PictureBox selectedBox;
        string VideoInputPath;
        string VideoOutputPath;

        bool VideoLoaded = false;
        public FilterControl()
        {
            InitializeComponent();
        }
        private void FilterControl_Load(object sender, EventArgs e)
        {
            selectedBox = pbPreviewBtn_00;
        }
        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaImagen = openFileDialog.FileName;

                    using (FileStream stream = new FileStream(rutaImagen, FileMode.Open))
                    {
                        Image imagen = Image.FromStream(stream);
                        pbPreview.Image = imagen;
                        imagenOriginal = (Bitmap)imagen;
                        btnSaveImage.Enabled = true;
                        updateHistogram(pbPreview.Image);
                        pbPreviewBtn_03.Image = Properties.Resources.girasoles_GaussainBlur;
                        pbPreviewBtn_04.Visible = true;
                        pbPreviewBtn_05.Visible = true;
                        VideoLoaded = false;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pbPreviewBtn_00_Click(object sender, EventArgs e)
        {

            selectedBox.BackColor = Color.FromArgb(64, 64, 64);
            pbPreviewBtn_00.BackColor = Color.White;
            selectedBox = pbPreviewBtn_00;
            if (VideoLoaded)
            {
                opcionFiltros = 6;
            }
            else
            {
                opcionFiltros = 0;
            }
        }
        private void pbPreviewBtn_01_Click(object sender, EventArgs e)
        {
            selectedBox.BackColor = Color.FromArgb(64, 64, 64);
            pbPreviewBtn_01.BackColor = Color.White;
            selectedBox = pbPreviewBtn_01;
            if (VideoLoaded)
            {
                opcionFiltros = 7;
                return;
            }
            else
            {
                opcionFiltros = 1;
            }
        }
        private void pbPreviewBtn_02_Click(object sender, EventArgs e)
        {
            selectedBox.BackColor = Color.FromArgb(64, 64, 64);
            pbPreviewBtn_02.BackColor = Color.White;
            selectedBox = pbPreviewBtn_02;
            if (VideoLoaded)
            {
                opcionFiltros = 8;
                return;
            }
            else
            {
                opcionFiltros = 2;
            }
        }
        private void pbPreviewBtn_03_Click(object sender, EventArgs e)
        {
            selectedBox.BackColor = Color.FromArgb(64, 64, 64);
            pbPreviewBtn_03.BackColor = Color.White;
            selectedBox = pbPreviewBtn_03;
            if (VideoLoaded)
            {
                opcionFiltros = 9;
                return;
            }
            else
            {
                opcionFiltros = 3;
            }

        }
        private void pbPreviewBtn_04_Click(object sender, EventArgs e)
        {
            selectedBox.BackColor = Color.FromArgb(64, 64, 64);
            pbPreviewBtn_04.BackColor = Color.White;
            selectedBox = pbPreviewBtn_04;
            if (VideoLoaded)
            {
                opcionFiltros = 10;
                return;
            }
            else
            {
                opcionFiltros = 4;
            }

        }
        private void pbPreviewBtn_05_Click(object sender, EventArgs e)
        {
            selectedBox.BackColor = Color.FromArgb(64, 64, 64);
            pbPreviewBtn_05.BackColor = Color.White;
            selectedBox = pbPreviewBtn_05;
            if (VideoLoaded)
            {
                opcionFiltros = 11;
                return;
            }
            else
            {
                opcionFiltros = 5;
            }
        }
        private void updateHistogram(Image image)
        {
            float[] values = GetRGBTotals(image);
            Graphics graphics = pbHist.CreateGraphics();
            DrawHistogram(graphics, pbHist.BackColor, values, pbHist.Width, pbHist.Height);
        }
        private void DrawHistogram(Graphics gr, Color back_color, float[] values, int width, int height)
        {
            Color[] Colors = new Color[] {
                Color.Red, Color.Green, Color.Blue,
            };

            gr.Clear(back_color);

            // Make a transformation to the PictureBox.
            RectangleF data_bounds = new RectangleF(0, 0, values.Length, MAX_VALUE);
            PointF[] points =
            {
                new PointF(0, height),
                new PointF(width, height),
                new PointF(0, 0)
            };
            Matrix transformation = new Matrix(data_bounds, points);
            gr.Transform = transformation;

            // Draw the histogram.
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    RectangleF rect = new RectangleF(i + 0.3f, 0, 0.25f, values[i]);
                    using (Brush the_brush = new SolidBrush(Colors[i % Colors.Length]))
                    {
                        gr.FillRectangle(the_brush, rect);
                        gr.DrawRectangle(thin_pen, rect.X, rect.Y, rect.Width, rect.Height);
                    }
                }
            }

            gr.ResetTransform();
            gr.DrawRectangle(Pens.Black, 0, 0, width - 1, height - 1);
            lblHistRGB.Text = "red:" + Math.Floor(values[0]) + "\n" + "green:" + Math.Floor(values[1]) + "\n" + "blue:" + Math.Floor(values[2]) + "\n";
        }
        public static float[] GetRGBTotals(Image image)
        {
            // Crea un objeto Bitmap a partir de la imagen
            Bitmap bitmap = new Bitmap(image);

            // Obtiene el ancho y alto de la imagen
            int width = bitmap.Width;
            int height = bitmap.Height;

            // Variables para almacenar los totales de cada canal RGB
            float redTotal = 0;
            float greenTotal = 0;
            float blueTotal = 0;

            // Itera a través de cada píxel de la imagen
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Obtiene el color del píxel en la posición (x, y)
                    Color pixelColor = bitmap.GetPixel(x, y);

                    // Agrega los valores del canal RGB al total correspondiente
                    redTotal += pixelColor.R;
                    greenTotal += pixelColor.G;
                    blueTotal += pixelColor.B;
                }
            }

            // Calcula el número total de píxeles en la imagen
            int numPixels = width * height;

            // Calcula los promedios de cada canal RGB dividiendo los totales por el número de píxeles
            float redAverage = redTotal / numPixels;
            float greenAverage = greenTotal / numPixels;
            float blueAverage = blueTotal / numPixels;

            // Almacena los totales de cada canal RGB en un arreglo de flotantes
            float[] rgbTotals = { redAverage, greenAverage, blueAverage };

            // Devuelve los totales de cada canal RGB
            return rgbTotals;
        }
        private void pbHist_Paint(object sender, PaintEventArgs e)
        {
        }
        private void pbHist_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            Bitmap ImageSave = new Bitmap(pbPreview.Image);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivos de imagen (*.png;*.jpeg;*.bmp)|*.png;*.jpeg;*.bmp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                ImageSave.Save(fileName);
            }

        }
        private void btnOpenVideo_Click(object sender, EventArgs e)
        {
            cleanImg();
            try
            {
                framesList.Clear();

                rutaVideoLoad = null;

                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Establecer las propiedades del FileDialog
                openFileDialog.Filter = "Archivos de video (*.mp4;*.avi;*.wmv)|*.mp4;*.avi;*.wmv";

                // Mostrar el FileDialog y obtener el resultado
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    rutaVideoLoad = openFileDialog.FileName;

                    panelVideoControls.Visible = true;

                    videoSource = new VideoFileSource(rutaVideoLoad);

                    VideoLoaded = true;
                    //pbPreviewBtn_03.Image = Properties.Resources.girasoles_HistEq;
                    //pbPreviewBtn_04.Visible = false;
                    //pbPreviewBtn_05.Visible = false;
                    opcionFiltros = 6;

                    pathTempFrames = Directory.GetCurrentDirectory() + @"\FramesTemp";

                    if (!Directory.Exists(pathTempFrames))
                    {
                        Directory.CreateDirectory(pathTempFrames);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar y reproducir el archivo de video: " + ex.Message);
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            //cleanImg();
            videoSource.Stop();

            videoSource.Start();

            videoSource.NewFrame += new NewFrameEventHandler(newFrame);
            //videoSource.PlayingFinished += new PlayingFinishedEventHandler(PlayerFinished);
        }
        private void cleanImg()
        {
            pbPreview.Image = null;
            if (videoSource != null)
            {
                videoSource.Stop();
            }
        }
        private void newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                if (pbPreview.Image != null)
                {
                    pbPreview.Image.Dispose();
                }

                bitmap = (Bitmap)eventArgs.Frame.Clone();

                switch (opcionFiltros)
                {
                    case 6:
                        pbPreview.Image = (Bitmap)eventArgs.Frame.Clone();
                        break;
                    case 7:
                        pbPreview.Image = Gray.Apply(bitmap);
                        break;
                    case 8:
                        pbPreview.Image = invert.Apply(bitmap);
                        break;
                    case 9:
                        pbPreview.Image = Filters.Convolve(bitmap, Filters.GaussianBlur(5, 5.4));
                        break;
                    case 10:
                        pbPreview.Image = Filters.HistEq(bitmap);
                        break;
                    case 11:
                        pbPreview.Image = Filters.ExponentialNoise(bitmap);
                        break;
                }

                bitmap.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar y reproducir el archivo de video: " + ex.Message);
            }

        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.Stop();
            }
            pbPreview.Image.Dispose();
            pbPreview.Image = null;

        }

        private void btn_aplicar_Click(object sender, EventArgs e)
        {
            switch (opcionFiltros)
            {
                case 0:
                    {
                        if (imagenOriginal == null) return;
                        pbPreview.Image = imagenOriginal;
                        updateHistogram(pbPreview.Image);
                        break;
                    }
                case 1:
                    {
                        if (imagenOriginal == null) return;
                        pbPreview.Image = Properties.Resources.LoadingAnim;
                        Image result = Gray.Apply(imagenOriginal);
                        pbPreview.Image = result;
                        updateHistogram(pbPreview.Image);
                        break;
                    }
                case 2:
                    {
                        if (imagenOriginal == null) return;
                        pbPreview.Image = Properties.Resources.LoadingAnim;
                        Image result = invert.Apply(imagenOriginal);
                        updateHistogram(result);
                        pbPreview.Image = result;
                        break;  
                    }
                case 3:
                    {
                        if (imagenOriginal == null) return;
                        pbPreview.Image = Properties.Resources.LoadingAnim;
                        Image result = Filters.ConvolveParallel((Bitmap)imagenOriginal, Filters.GaussianBlur(10, 5.4));
                        updateHistogram(result);
                        pbPreview.Image = result;
                        break;
                    }
                case 4:
                    {
                        if (imagenOriginal == null) return;
                        pbPreview.Image = Properties.Resources.LoadingAnim;
                        Image result = Filters.HistEq(imagenOriginal);
                        updateHistogram(result);
                        pbPreview.Image = result;
                        break;
                    }
                case 5:
                    {
                        if (imagenOriginal == null) return;
                        pbPreview.Image = Properties.Resources.LoadingAnim;
                        Image result = Filters.ExponentialNoise(imagenOriginal);
                        updateHistogram(result);
                        pbPreview.Image = result;
                        break;
                    }
            }
        }

        private void FilterControl_Leave(object sender, EventArgs e)
        {
            cleanImg();
            if(VideoLoaded) videoSource.Source = null;
            framesList.Clear();
        }
    }


}
