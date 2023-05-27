using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesamientoDeImagenes
{
    public partial class WebcamControl : UserControl
    {
        private string Path = @"";
        private bool DevicesFound;
        private FilterInfoCollection MyDevices;
        private VideoCaptureDevice MyWebCamDevice;

        private Capture WebcamDisp;
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        int Personas = 0;
        bool EnabledSaveImage = false;
        EigenFaceRecognizer recognizer;


        //Variables para el guardado de imagenes
        private static bool isTrained = false;
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> FaceLabels = new List<int>();
        List<string> FaceNames = new List<string>();

        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");

        bool GrabacionDetenida;
        private bool DeteccionRostros = false;
        private bool CamaraEncendida = false;

        public WebcamControl()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            groupFaceDetection.Hide();
        }

        private void CaptureVideo(object sender, EventArgs eventArgs)
        {
            //Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            //WebCamView_PB.Image = Imagen;

            WebcamDisp.Retrieve(frame, 0);
            currentFrame = frame.ToImage<Bgr, Byte>().Resize(WebCamView_PB.Width, WebCamView_PB.Height, Inter.Cubic);

            try
            {
                if (DeteccionRostros)
                {

                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    Rectangle[] faces = cascadeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);


                    if (faces.Length > 0)
                    {
                        foreach (var face in faces)
                        {

                            CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;
                            DetectedFace_PB.SizeMode = PictureBoxSizeMode.Zoom;
                            DetectedFace_PB.Image = resultImage.Bitmap;

                            if (EnabledSaveImage)
                            {
                                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }

                                for (int i = 0; i < 10; i++)
                                {
                                    resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + TextB_Nombre.Text + "-" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".bmp");
                                    Thread.Sleep(1000);
                                }

                            }
                            EnabledSaveImage = false;
                            Personas = faces.Length;

                            //Reconocimiento de Rostros y etiquetas
                            if (isTrained == true)
                            {
                                Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                                CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                                var result = recognizer.Predict(grayFaceResult);
                                FacePB1.Image = grayFaceResult.Bitmap;
                                FacePB2.Image = TrainedFaces[result.Label].Bitmap;
                                Debug.WriteLine(result.Label + ". " + result.Distance);
                                //Here results found known faces
                                if (result.Label != -1 && result.Distance < 2000)
                                {
                                    CvInvoke.PutText(currentFrame, FaceNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                }
                                //here results did not found any know faces
                                else
                                {
                                    CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                                }
                            }
                        }


                    }
                    else if (faces.Length <= 0)
                    {

                        Personas = 0;

                    }

                }

            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Error en Capturar Imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    DeteccionRostros = false;
                }
            }
            if (GrabacionDetenida != true)
            {
                WebCamView_PB.Image = currentFrame.Bitmap;
            }
        }

        private void CloseWebCam()
        {
            if (MyWebCamDevice != null && MyWebCamDevice.IsRunning)
            {
                MyWebCamDevice.SignalToStop();
                MyWebCamDevice = null;
            }
        }

        ~WebcamControl()
        {
            //CloseWebCam();
        }

        private void btn_device_Click(object sender, EventArgs e)
        {
            if (CamaraEncendida) return;
            CamaraEncendida = true;

            GrabacionDetenida = false;

            TimerUpdate.Enabled = true;

            WebcamDisp = new Capture();

            WebcamDisp.ImageGrabbed += CaptureVideo;

            WebcamDisp.Start();
        }

        private void selected_index_change(object sender, EventArgs e)
        {
            btn_device.Enabled = true;
        }

        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            lblPersonasCount.Text = Convert.ToString(Personas);
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            if (!CamaraEncendida) return;
            CamaraEncendida = false;
            WebcamDisp.ImageGrabbed -= CaptureVideo;
            GrabacionDetenida = true;
            DeteccionRostros = false;


            //Variables
            isTrained = false;
            DeteccionRostros = false;


            TimerUpdate.Enabled = false;
            CerrarWebCam();

            WebCamView_PB.Image.Dispose();
            WebCamView_PB.Image = null;


            recognizer = null;
        }

        private void CerrarWebCam()
        {
            //try
            //{
            //    if (GrabacionDetenida == true)
            //    {
            //        WebcamDisp.Stop();
            //        WebcamDisp.Dispose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void DetectBtn_Click(object sender, EventArgs e)
        {
            groupFaceDetection.Show();
            DeteccionRostros = true;
        }
        private void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            if (TextB_Nombre.TextLength == 0 || TextB_Nombre.Text == null)
            {
                DialogResult result = MessageBox.Show("La persona tiene que registrarse con un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    EnabledSaveImage = false;
                }
            }
            else
            {
                EnabledSaveImage = true;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private bool TrainImagesFromDir()
        {
            int ImagesCount = 0;
            double Threshold = 2000;
            TrainedFaces.Clear();
            FaceLabels.Clear();
            FaceNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.bmp", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    FaceLabels.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    FaceNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);

                }

                if (TrainedFaces.Count() > 0)
                {
                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    recognizer.Train(TrainedFaces.ToArray(), FaceLabels.ToArray());

                    isTrained = true;
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return false;
            }

        }
        private void btnCompare_Click(object sender, EventArgs e)
        {
            TrainImagesFromDir();
        }
        private void btnStopCompare_Click(object sender, EventArgs e)
        {
            isTrained = false;
            FacePB1.Image = null;
            FacePB2.Image = null;
            recognizer = null;
        }
    }
}
