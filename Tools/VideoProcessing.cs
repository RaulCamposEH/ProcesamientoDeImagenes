using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Drawing;

public class VideoProcessing
{
    public void ApplyFilterToVideo(string inputFilePath, string outputFilePath)
    {
        // Cargar el video de entrada
        VideoFileReader reader = new VideoFileReader();
        reader.Open(inputFilePath);

        // Crear el escritor de video de salida
        VideoFileWriter writer = new VideoFileWriter();
        writer.Open(outputFilePath, reader.Width, reader.Height, reader.FrameRate, VideoCodec.MPEG4);

        // Lista para almacenar los frames con filtro
        List<Image> filteredFrames = new List<Image>();

        // Iterar sobre cada frame del video
        while (reader.IsOpen)
        {
            // Leer el siguiente frame
            Bitmap frame = reader.ReadVideoFrame();

            if (frame == null)
                break;

            // Aplicar el filtro deseado al frame
            Bitmap filteredFrame = ApplyFilter(frame);

            // Agregar el frame filtrado a la lista
            filteredFrames.Add(filteredFrame);

            // Guardar el frame filtrado en el video de salida
            writer.WriteVideoFrame(filteredFrame);

            // Liberar recursos del frame actual
            frame.Dispose();
        }

        // Cerrar el lector y escritor de video
        reader.Close();
        writer.Close();

        // Liberar memoria de los frames filtrados
        foreach (Image filteredFrame in filteredFrames)
        {
            filteredFrame.Dispose();
        }
    }

    private Bitmap ApplyFilter(Bitmap frame)
    {
        // Aquí puedes aplicar el filtro deseado al frame utilizando AForge o cualquier otra biblioteca de procesamiento de imágenes
        // Por ejemplo, aplicar un filtro de blanco y negro
        Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
        Bitmap filteredFrame = grayscaleFilter.Apply(frame);

        return filteredFrame;
    }
}
