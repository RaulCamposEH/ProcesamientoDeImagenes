using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProcesamientoDeImagenesFil
{
    public class Superpixel
    {
        public int CenterX { get; }
        public int CenterY { get; }
        public Color Color { get; private set; }
        public List<Pixel> Pixels { get; }

        public Superpixel(int centerX, int centerY, Color color)
        {
            CenterX = centerX;
            CenterY = centerY;
            Color = color;
            Pixels = new List<Pixel>();
        }

        public void UpdateColor(int compactness)
        {
            int redSum = 0;
            int greenSum = 0;
            int blueSum = 0;

            foreach (Pixel pixel in Pixels)
            {
                redSum += pixel.Color.R;
                greenSum += pixel.Color.G;
                blueSum += pixel.Color.B;
            }

            int numPixels = Pixels.Count;
            int averageRed = redSum / numPixels;
            int averageGreen = greenSum / numPixels;
            int averageBlue = blueSum / numPixels;

            int diffRed = averageRed - Color.R;
            int diffGreen = averageGreen - Color.G;
            int diffBlue = averageBlue - Color.B;

            int distanceSquared = diffRed * diffRed + diffGreen * diffGreen + diffBlue * diffBlue;
            double distance = Math.Sqrt(distanceSquared);

            double scale = compactness / Math.Sqrt(numPixels);

            if (distance > scale)
            {
                int updatedRed = (int)Math.Round(Color.R + scale * (averageRed - Color.R) / distance);
                int updatedGreen = (int)Math.Round(Color.G + scale * (averageGreen - Color.G) / distance);
                int updatedBlue = (int)Math.Round(Color.B + scale * (averageBlue - Color.B) / distance);

                Color = Color.FromArgb(updatedRed, updatedGreen, updatedBlue);
            }
        }
    }
    public class Pixel
    {
        public int X { get; }
        public int Y { get; }
        public Color Color { get; }

        public Pixel(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
    internal class Filters
    {
        public static double[,] GaussianBlur(int lenght, double weight)
        {
            double[,] kernel = new double[lenght, lenght];
            double kernelSum = 0;
            int foff = (lenght - 1) / 2;
            double distance = 0;
            double constant = 1d / (2 * Math.PI * weight * weight);
            for (int y = -foff; y <= foff; y++)
            {
                for (int x = -foff; x <= foff; x++)
                {
                    distance = ((y * y) + (x * x)) / (2 * weight * weight);
                    kernel[y + foff, x + foff] = constant * Math.Exp(-distance);
                    kernelSum += kernel[y + foff, x + foff];
                }
            }
            for (int y = 0; y < lenght; y++)
            {
                for (int x = 0; x < lenght; x++)
                {
                    kernel[y, x] = kernel[y, x] * 1d / kernelSum;
                }
            }
            return kernel;
        }
        public static Bitmap Convolve(Bitmap srcImage, double[,] kernel)
        {
            int width = srcImage.Width;
            int height = srcImage.Height;
            BitmapData srcData = srcImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytes = srcData.Stride * srcData.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(srcData.Scan0, buffer, 0, bytes);
            srcImage.UnlockBits(srcData);
            int colorChannels = 3;
            double[] rgb = new double[colorChannels];
            int foff = (kernel.GetLength(0) - 1) / 2;
            int kcenter = 0;
            int kpixel = 0;
            for (int y = foff; y < height - foff; y++)
            {
                for (int x = foff; x < width - foff; x++)
                {
                    for (int c = 0; c < colorChannels; c++)
                    {
                        rgb[c] = 0.0;
                    }
                    kcenter = y * srcData.Stride + x * 4;
                    for (int fy = -foff; fy <= foff; fy++)
                    {
                        for (int fx = -foff; fx <= foff; fx++)
                        {
                            kpixel = kcenter + fy * srcData.Stride + fx * 4;
                            for (int c = 0; c < colorChannels; c++)
                            {
                                rgb[c] += (double)(buffer[kpixel + c]) * kernel[fy + foff, fx + foff];
                            }
                        }
                    }
                    for (int c = 0; c < colorChannels; c++)
                    {
                        if (rgb[c] > 255)
                        {
                            rgb[c] = 255;
                        }
                        else if (rgb[c] < 0)
                        {
                            rgb[c] = 0;
                        }
                    }
                    for (int c = 0; c < colorChannels; c++)
                    {
                        result[kcenter + c] = (byte)rgb[c];
                    }
                    result[kcenter + 3] = 255;
                }
            }
            Bitmap resultImage = new Bitmap(width, height);
            BitmapData resultData = resultImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(result, 0, resultData.Scan0, bytes);
            resultImage.UnlockBits(resultData);
            return resultImage;
        }
        public static Bitmap ConvolveParallel(Bitmap srcImage, double[,] kernel)
        {
            int width = srcImage.Width;
            int height = srcImage.Height;
            BitmapData srcData = srcImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytes = srcData.Stride * srcData.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(srcData.Scan0, buffer, 0, bytes);
            srcImage.UnlockBits(srcData);
            int colorChannels = 3;
            double[] rgb = new double[colorChannels];
            int foff = (kernel.GetLength(0) - 1) / 2;

            // Crear un arreglo de tareas para procesar diferentes secciones de la imagen en paralelo
            Task[] tasks = new Task[Environment.ProcessorCount];
            object lockObj = new object(); // Objeto para bloqueo

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    for (int y = foff + i; y < height - foff; y += tasks.Length)
                    {
                        for (int x = foff; x < width - foff; x++)
                        {
                            for (int c = 0; c < colorChannels; c++)
                            {
                                rgb[c] = 0.0;
                            }
                            int kcenter = y * srcData.Stride + x * 4;

                            for (int fy = -foff; fy <= foff; fy++)
                            {
                                for (int fx = -foff; fx <= foff; fx++)
                                {
                                    int kpixel = kcenter + fy * srcData.Stride + fx * 4;
                                    for (int c = 0; c < colorChannels; c++)
                                    {
                                        lock (lockObj) // Bloqueo para acceso exclusivo al objeto buffer
                                        {
                                            rgb[c] += (double)(buffer[kpixel + c]) * kernel[fy + foff, fx + foff];
                                        }
                                    }
                                }
                            }

                            for (int c = 0; c < colorChannels; c++)
                            {
                                if (rgb[c] > 255)
                                {
                                    rgb[c] = 255;
                                }
                                else if (rgb[c] < 0)
                                {
                                    rgb[c] = 0;
                                }
                            }

                            for (int c = 0; c < colorChannels; c++)
                            {
                                lock (lockObj) // Bloqueo para acceso exclusivo al objeto result
                                {
                                    result[kcenter + c] = (byte)rgb[c];
                                }
                            }

                            lock (lockObj) // Bloqueo para acceso exclusivo al objeto result
                            {
                                result[kcenter + 3] = 255;
                            }
                        }
                    }
                });
            }

            // Esperar a que todas las tareas se completen
            Task.WaitAll(tasks);

            Bitmap resultImage = new Bitmap(width, height);
            BitmapData resultData = resultImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(result, 0, resultData.Scan0, bytes);
            resultImage.UnlockBits(resultData);

            return resultImage;
        }
        public static Image ConvertToGrayscale(Image image)
        {
            Bitmap bitmap = new Bitmap(image);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    int average = (pixel.R + pixel.G + pixel.B) / 3;
                    Color grayscalePixel = Color.FromArgb(average, average, average);
                    bitmap.SetPixel(x, y, grayscalePixel);
                }
            }

            return bitmap;
        }
        public static Image ConvertToGrayscaleParallel(Image image)
        {
            Bitmap bitmap = new Bitmap(image);

            int width = bitmap.Width;
            int height = bitmap.Height;

            // Crear un arreglo de tareas para procesar diferentes secciones de la imagen en paralelo
            Task[] tasks = new Task[Environment.ProcessorCount];
            object lockObj = new object(); // Objeto para bloqueo

            for (int i = 0; i < tasks.Length; i++)
            {
                int startIndex = i * height / tasks.Length;
                int endIndex = (i + 1) * height / tasks.Length;

                tasks[i] = Task.Run(() =>
                {
                    for (int y = startIndex; y < endIndex; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color pixel;
                            lock (lockObj) // Bloqueo para acceso exclusivo al objeto bitmap
                            {
                                pixel = bitmap.GetPixel(x, y);
                            }

                            int average = (pixel.R + pixel.G + pixel.B) / 3;
                            Color grayscalePixel = Color.FromArgb(average, average, average);

                            lock (lockObj) // Bloqueo para acceso exclusivo al objeto bitmap
                            {
                                bitmap.SetPixel(x, y, grayscalePixel);
                            }
                        }
                    }
                });
            }

            // Esperar a que todas las tareas se completen
            Task.WaitAll(tasks);

            return bitmap;
        }
        public static Image InvertImage(Image image)
        {
            Bitmap bitmap = new Bitmap(image);

            // Obtiene el ancho y alto de la imagen
            int width = bitmap.Width;
            int height = bitmap.Height;

            // Itera a través de cada píxel de la imagen
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Obtiene el color del píxel en la posición (x, y)
                    Color pixelColor = bitmap.GetPixel(x, y);

                    // Invierte los componentes de color
                    Color invertedColor = Color.FromArgb(
                        255 - pixelColor.R,
                        255 - pixelColor.G,
                        255 - pixelColor.B
                    );

                    // Establece el nuevo color del píxel
                    bitmap.SetPixel(x, y, invertedColor);
                }
            }

            return bitmap;
        }
        public static Image InvertImageParallel(Image image)
        {
            Bitmap bitmap = new Bitmap(image);

            int width = bitmap.Width;
            int height = bitmap.Height;

            // Crear un arreglo de tareas para procesar diferentes secciones de la imagen en paralelo
            Task[] tasks = new Task[Environment.ProcessorCount];
            object lockObj = new object(); // Objeto para bloqueo

            for (int i = 0; i < tasks.Length; i++)
            {
                int startIndex = i * height / tasks.Length;
                int endIndex = (i + 1) * height / tasks.Length;

                tasks[i] = Task.Run(() =>
                {
                    for (int y = startIndex; y < endIndex; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color pixel;
                            lock (lockObj) // Bloqueo para acceso exclusivo al objeto bitmap
                            {
                                pixel = bitmap.GetPixel(x, y);
                            }
                            Color invertedColor = Color.FromArgb(
                                255 - pixel.R,
                                255 - pixel.G,
                                255 - pixel.B
                            );
                            lock (lockObj) // Bloqueo para acceso exclusivo al objeto bitmap
                            {
                                bitmap.SetPixel(x, y, invertedColor);
                            }
                        }
                    }
                });
            }

            // Esperar a que todas las tareas se completen
            Task.WaitAll(tasks);

            return bitmap;
        }
        public static Image ApplySLIC(Image image, int numSuperpixels, int compactness)
        {
            // Crea un objeto Bitmap a partir de la imagen
            Bitmap bitmap = new Bitmap(image);

            // Obtiene el ancho y alto de la imagen
            int width = bitmap.Width;
            int height = bitmap.Height;

            // Calcula el tamaño de los superpíxeles
            int superpixelSize = (int)Math.Sqrt((width * height) / numSuperpixels);

            // Calcula el número de superpíxeles en cada dirección
            int numSuperpixelsX = width / superpixelSize;
            int numSuperpixelsY = height / superpixelSize;

            // Calcula el tamaño de los bloques en los que se divide la imagen
            int blockWidth = width / numSuperpixelsX;
            int blockHeight = height / numSuperpixelsY;

            // Calcula el radio de búsqueda para la asignación de píxeles a superpíxeles
            int searchRadius = (int)Math.Sqrt(blockWidth * blockWidth + blockHeight * blockHeight) + 2;

            // Crea una lista para almacenar los superpíxeles
            List<Superpixel> superpixels = new List<Superpixel>();

            // Itera a través de cada bloque para crear los superpíxeles
            for (int y = 0; y < numSuperpixelsY; y++)
            {
                for (int x = 0; x < numSuperpixelsX; x++)
                {
                    // Calcula la posición del bloque
                    int blockX = x * blockWidth;
                    int blockY = y * blockHeight;

                    // Calcula la posición central del superpíxel
                    int centerX = blockX + blockWidth / 2;
                    int centerY = blockY + blockHeight / 2;

                    // Obtiene el color promedio del bloque
                    Color averageColor = GetAverageColor(bitmap, blockX, blockY, blockWidth, blockHeight);

                    // Crea un nuevo superpíxel
                    Superpixel superpixel = new Superpixel(centerX, centerY, averageColor);

                    // Agrega el superpíxel a la lista
                    superpixels.Add(superpixel);
                }
            }

            // Asigna cada píxel al superpíxel más cercano
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Encuentra el superpíxel más cercano al píxel
                    Superpixel nearestSuperpixel = FindNearestSuperpixel(superpixels, bitmap, x, y, searchRadius);

                    // Asigna el píxel al superpíxel
                    nearestSuperpixel.Pixels.Add(new Pixel(x, y, bitmap.GetPixel(x, y)));
                }
            }

            // Actualiza el color de cada superpíxel
            foreach (Superpixel superpixel in superpixels)
            {
                superpixel.UpdateColor(compactness);
            }

            // Crea un nuevo objeto Bitmap para almacenar la imagen con superpíxeles
            Bitmap superpixelBitmap = new Bitmap(width, height);

            // Asigna el color de cada píxel en base a los superpíxeles
            foreach (Superpixel superpixel in superpixels)
            {
                foreach (Pixel pixel in superpixel.Pixels)
                {
                    superpixelBitmap.SetPixel(pixel.X, pixel.Y, superpixel.Color);
                }
            }

            // Devuelve la imagen con superpíxeles
            return superpixelBitmap;
        }
        private static Color GetAverageColor(Bitmap bitmap, int startX, int startY, int width, int height)
        {
            int redSum = 0;
            int greenSum = 0;
            int blueSum = 0;

            for (int y = startY; y < startY + height; y++)
            {
                for (int x = startX; x < startX + width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    redSum += pixelColor.R;
                    greenSum += pixelColor.G;
                    blueSum += pixelColor.B;
                }
            }

            int numPixels = width * height;
            int averageRed = redSum / numPixels;
            int averageGreen = greenSum / numPixels;
            int averageBlue = blueSum / numPixels;

            return Color.FromArgb(averageRed, averageGreen, averageBlue);
        }
        private static Superpixel FindNearestSuperpixel(List<Superpixel> superpixels, Bitmap bitmap, int x, int y, int searchRadius)
        {
            Superpixel nearestSuperpixel = null;
            double minDistance = double.MaxValue;

            foreach (Superpixel superpixel in superpixels)
            {
                int centerX = superpixel.CenterX;
                int centerY = superpixel.CenterY;

                double distance = Math.Sqrt((centerX - x) * (centerX - x) + (centerY - y) * (centerY - y));

                if (distance < minDistance && distance <= searchRadius)
                {
                    nearestSuperpixel = superpixel;
                    minDistance = distance;
                }
            }

            return nearestSuperpixel;
        }
        public static Bitmap HistEq(Bitmap img)
        {
            int w = img.Width;
            int h = img.Height;
            BitmapData sd = img.LockBits(new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytes = sd.Stride * sd.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(sd.Scan0, buffer, 0, bytes);
            img.UnlockBits(sd);
            int current = 0;
            double[] pn = new double[256];

            var task = Task.Run(() =>
            {
                for (int p = 0; p < bytes; p += 4)
                {
                    pn[buffer[p]]++;
                }
                for (int prob = 0; prob < pn.Length; prob++)
                {
                    pn[prob] /= (w * h);
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        current = y * sd.Stride + x * 4;
                        double sum = 0;
                        for (int i = 0; i < buffer[current]; i++)
                        {
                            sum += pn[i];
                        }
                        for (int c = 0; c < 3; c++)
                        {
                            result[current + c] = (byte)Math.Floor(255 * sum);
                        }
                        result[current + 3] = 255;
                    }
                }
            });

            Task.WaitAll(task);

            Bitmap res = new Bitmap(w, h);
            BitmapData rd = res.LockBits(new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(result, 0, rd.Scan0, bytes);
            res.UnlockBits(rd);
            return res;
        }
        public static Bitmap ExponentialNoise(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);
            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            byte[] noise = new byte[bytes];
            double[] erlang = new double[256];
            double a = 5;
            Random rnd = new Random();
            double sum = 0;

            var task = Task.Run(() =>
            {
                for (int i = 0; i < 256; i++)
                {
                    double step = (double)i * 0.01;
                    if (step >= 0)
                    {
                        erlang[i] = (double)(a * Math.Exp(-a * step));
                    }
                    else
                    {
                        erlang[i] = 0;
                    }
                    sum += erlang[i];
                }

                for (int i = 0; i < 256; i++)
                {
                    erlang[i] /= sum;
                    erlang[i] *= bytes;
                    erlang[i] = (int)Math.Floor(erlang[i]);
                }

                int count = 0;
                for (int i = 0; i < 256; i++)
                {
                    for (int j = 0; j < (int)erlang[i]; j++)
                    {
                        noise[j + count] = (byte)i;
                    }
                    count += (int)erlang[i];
                }

                for (int i = 0; i < bytes - count; i++)
                {
                    noise[count + i] = 0;
                }

                noise = noise.OrderBy(x => rnd.Next()).ToArray();

                for (int i = 0; i < bytes; i++)
                {
                    result[i] = (byte)(buffer[i] + noise[i]);
                }

            });

            Task.WaitAll(task);

            Bitmap result_image = new Bitmap(w, h);
            BitmapData result_data = result_image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            Marshal.Copy(result, 0, result_data.Scan0, bytes);
            result_image.UnlockBits(result_data);

            return result_image;
        }
    }

}
