using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.AttachedFiles
{
    public partial class ImageHandler : Form
    {
        public ImageHandler()
        {
            InitializeComponent();
            UploadedPictureOpenFileDialog.InitialDirectory = Application.StartupPath;
            UploadedPictureOpenFileDialog.Filter = "*.png|*.png|*.jpg|*.jpg";
            if (UploadedPictureOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadedImagePictureBox.BackgroundImage = Image.FromFile(UploadedPictureOpenFileDialog.FileName);
            }
        }

        private void UploadedPictureRotationButton_Click(object sender, EventArgs e)
        {
            if (LoadedImagePictureBox.BackgroundImage != null)
            {
                Bitmap RotatedPicture = new Bitmap(LoadedImagePictureBox.BackgroundImage.Width, LoadedImagePictureBox.BackgroundImage.Height);
                using (Graphics graphics = Graphics.FromImage(RotatedPicture))
                {
                    graphics.TranslateTransform(RotatedPicture.Width / 2, RotatedPicture.Height / 2);
                    graphics.RotateTransform((float)90);
                    graphics.TranslateTransform(-RotatedPicture.Width / 2, -RotatedPicture.Height / 2);
                    graphics.DrawImage(LoadedImagePictureBox.BackgroundImage, new PointF(0, 0));
                }

                LoadedImagePictureBox.BackgroundImage = RotatedPicture;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadedImagePictureBox_Click(object sender, EventArgs e)
        {
            ImageViewer image = new ImageViewer(Properties.MaleProfilePicture.BoyCharacter16);
            image.Show();

        }
    }
}
