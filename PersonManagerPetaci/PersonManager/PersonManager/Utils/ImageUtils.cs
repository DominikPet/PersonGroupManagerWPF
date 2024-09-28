using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PersonManager.Utils
{
    public static class ImageUtils
    {
        public static BitmapImage ByteArrayToBitmapImage(byte[] picture)
        {
            using var memoryStream = new MemoryStream(picture);
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = memoryStream;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            bitmap.Freeze();
            return bitmap;
        }
        public static byte[] BitmapImageToByteArray(BitmapImage image)
        {
            var jpegEncoder = new JpegBitmapEncoder();
            jpegEncoder.Frames.Add(BitmapFrame.Create(image));
            using var memoryStream = new MemoryStream();    
            jpegEncoder.Save(memoryStream);
            return memoryStream.ToArray();
        }

        internal static byte[] ByteArrayFromReader(SqlDataReader dr, string column)
        {
            var memoryStream = new MemoryStream();
            var binaryWriter = new BinaryWriter(memoryStream);

            int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];

            int currentBytes = 0;
            int readBytes;
            do
            {

               readBytes = (int)dr.GetBytes(
                    dr.GetOrdinal(column),
                    currentBytes,
                    buffer,
                    0, 
                    bufferSize
                    );
                binaryWriter.Write(buffer, 0, readBytes);

                currentBytes += readBytes;
            } while (readBytes == bufferSize);


            return memoryStream.ToArray();
        }
    }
}
