using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageResizer
{
    public partial class ResizerForm : Form
    {
        public ResizerForm()
        {
            InitializeComponent();
        }
        private void AddImage_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (DefaultPicture.Image != null)
                    {
                        DefaultPicture.Image.Dispose();
                    }

                    DefaultPicture.Image = Image.FromFile(openFileDialog.FileName);
                }
            }

            ClearButton.Enabled = DefaultPicture.Image != null;
            
            AddImage.Enabled = false;
        }

        private void ParallelBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DefaultPicture.Image == null)
            {
                MessageBox.Show("Please select an image first.");
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            double scaleFactor = (double)(ImageAdjustment.Value / 100);

            // Calculate the new dimensions
            int newWidth = (int)(DefaultPicture.Image.Width * scaleFactor);
            int newHeight = (int)(DefaultPicture.Image.Height * scaleFactor);

            Bitmap originalBitmap = (Bitmap)DefaultPicture.Image;
            Bitmap resizedBitmap = Resizer.ParallelImageResizer(originalBitmap, newWidth, newHeight);

            stopwatch.Stop();

            if (NewPicture.Image != null)
            {
                NewPicture.Image.Dispose();
            }
            NewPicture.Image = resizedBitmap;

            MessageBox.Show($"Parallel resizing took {stopwatch.ElapsedMilliseconds} ms");

            ClearButton.Enabled = true;
        }

        private void ConsequentialBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DefaultPicture.Image == null)
            {
                MessageBox.Show("Please select an image first.");
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            double scaleFactor = (double)(ImageAdjustment.Value / 100);

            Bitmap resizedBitmap = Resizer.SequentiallyImageResizer((Bitmap)DefaultPicture.Image, scaleFactor);

            stopwatch.Stop();

            if (NewPicture.Image != null)
            {
                NewPicture.Image.Dispose();
            }
            NewPicture.Image = resizedBitmap;

            MessageBox.Show($"Sequential resizing took {stopwatch.ElapsedMilliseconds} ms");

            ClearButton.Enabled = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (DefaultPicture.Image != null)
            {
                DefaultPicture.Image.Dispose();
                DefaultPicture.Image = null;
            }

            if (NewPicture.Image != null)
            {
                NewPicture.Image.Dispose();
                NewPicture.Image = null;
            }

            ClearButton.Enabled = false;
            ParallelBox.Checked = false;
            ConsequentialBox.Checked = false;
            AddImage.Enabled = true;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (NewPicture.Image == null)
            {
                MessageBox.Show("There is no image to save.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpeg;*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|GIF Image|*.gif|TIFF Image|*.tiff";
                saveFileDialog.Title = "Save image as...";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Jpeg;
                    string extension = Path.GetExtension(saveFileDialog.FileName).ToLowerInvariant();
                    switch (extension)
                    {
                        case ".jpg":
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case ".gif":
                            format = ImageFormat.Gif;
                            break;
                        case ".tiff":
                            format = ImageFormat.Tiff;
                            break;
                    }

                    NewPicture.Image.Save(saveFileDialog.FileName, format);
                    MessageBox.Show("Image saved succesfuly.");
                }
            }
        }
    }
}
