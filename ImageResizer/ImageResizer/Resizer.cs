using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ImageResizer
{
    public class Resizer
    {
        public static Bitmap SequentiallyImageResizer(Bitmap originalImage, double scaleFactor)
        {
            int newWidth = (int)(originalImage.Width * scaleFactor);
            int newHeight = (int)(originalImage.Height * scaleFactor);

            Bitmap downscaledImage = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);

            BitmapData originalData = originalImage.LockBits(
                new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            BitmapData downscaledData = downscaledImage.LockBits(
                new Rectangle(0, 0, newWidth, newHeight),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int bytesPerPixel = 4;

            unsafe
            {
                byte* originalPtr = (byte*)originalData.Scan0;
                byte* downscaledPtr = (byte*)downscaledData.Scan0;

                for (int y = 0; y < newHeight; y++)
                {
                    for (int x = 0; x < newWidth; x++)
                    {
                        int originalX = (int)(x / scaleFactor);
                        int originalY = (int)(y / scaleFactor);
                        int rangeWidth = Math.Min((int)Math.Ceiling(1 / scaleFactor), originalImage.Width - originalX);
                        int rangeHeight = Math.Min((int)Math.Ceiling(1 / scaleFactor), originalImage.Height - originalY);

                        // Variables to hold the sum of colors and alpha
                        long sumR = 0, sumG = 0, sumB = 0, sumA = 0;

                        // Sum up the color values of the pixels in the range
                        for (int offsetY = 0; offsetY < rangeHeight; offsetY++)
                        {
                            byte* originalRow = originalPtr + ((originalY + offsetY) * originalData.Stride);
                            for (int offsetX = 0; offsetX < rangeWidth; offsetX++)
                            {
                                byte* pixel = originalRow + ((originalX + offsetX) * bytesPerPixel);
                                sumB += pixel[0]; // Blue
                                sumG += pixel[1]; // Green
                                sumR += pixel[2]; // Red
                                sumA += pixel[3]; // Alpha
                            }
                        }

                        // Calculate the average color and alpha
                        int pixelCount = rangeWidth * rangeHeight;
                        int avgR = (int)(sumR / pixelCount);
                        int avgG = (int)(sumG / pixelCount);
                        int avgB = (int)(sumB / pixelCount);
                        int avgA = (int)(sumA / pixelCount);

                        // Write the average color and alpha to the resized image
                        byte* downscaledRow = downscaledPtr + (y * downscaledData.Stride);
                        byte* downscaledPixel = downscaledRow + (x * bytesPerPixel);
                        downscaledPixel[0] = (byte)avgB; // Blue
                        downscaledPixel[1] = (byte)avgG; // Green
                        downscaledPixel[2] = (byte)avgR; // Red
                        downscaledPixel[3] = (byte)avgA; // Alpha
                    }
                }
            }

            originalImage.UnlockBits(originalData);
            downscaledImage.UnlockBits(downscaledData);

            return downscaledImage;
        }
        public static Bitmap ParallelImageResizer(Bitmap originalImage, int width, int height)
        {
            try
            {
                int originalWidth = originalImage.Width;
                int originalHeight = originalImage.Height;

                var resizedImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

                BitmapData originalData = null;
                BitmapData resizedData = null;
                try
                {
                    originalData = originalImage.LockBits(new Rectangle(0, 0, originalWidth, originalHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                    resizedData = resizedImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                    int bytesPerPixel = Image.GetPixelFormatSize(PixelFormat.Format24bppRgb) / 8;

                    byte[] originalPixels = new byte[originalData.Stride * originalHeight];
                    byte[] resizedPixels = new byte[resizedData.Stride * height];

                    Marshal.Copy(originalData.Scan0, originalPixels, 0, originalPixels.Length);

                    float widthRatio = (float)originalWidth / width;
                    float heightRatio = (float)originalHeight / height;

                    Parallel.For(0, height, y =>
                    {
                        int resizedYOffset = y * resizedData.Stride;
                        for (int x = 0; x < width; x++)
                        {
                            int originalX = Math.Min((int)(x * widthRatio), originalWidth - 1);
                            int originalY = Math.Min((int)(y * heightRatio), originalHeight - 1);
                            int originalOffset = (originalY * originalData.Stride) + (originalX * bytesPerPixel);

                            for (int byteIndex = 0; byteIndex < bytesPerPixel; byteIndex++)
                            {
                                int index = resizedYOffset + (x * bytesPerPixel) + byteIndex;
                                resizedPixels[index] = originalPixels[originalOffset + byteIndex];
                            }
                        }
                    });

                    Marshal.Copy(resizedPixels, 0, resizedData.Scan0, resizedPixels.Length);
                }
                finally
                {
                    if (originalData != null)
                        originalImage.UnlockBits(originalData);
                    if (resizedData != null)
                        resizedImage.UnlockBits(resizedData);
                }

                return resizedImage;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
