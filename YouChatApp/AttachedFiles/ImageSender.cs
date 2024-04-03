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
    public partial class ImageSender : Form
    {
        private Image uploadedImage;
        public ImageSender()
        {
            InitializeComponent();
        }



        private void LoadedImagePictureBox_Click(object sender, EventArgs e)
        {
            Image image = LoadedImagePictureBox.BackgroundImage;
            if (image != null)
            {
                ImageViewer imageViewer = new ImageViewer(image);
                imageViewer.Show();
            }
        }

        private void LoadPictureCustomButton_Click(object sender, EventArgs e)
        {
            Image selectedImage = OpenFileDialogHandler.HandleOpenFileDialog(UploadedPictureOpenFileDialog);
            uploadedImage = selectedImage;
            LoadedImagePictureBox.BackgroundImage = uploadedImage;
            RestartPictureCustomButton.Enabled = true;
            SendPictureCustomButton.Enabled = true;
        }

        private void RestartPictureCustomButton_Click(object sender, EventArgs e)
        {
            uploadedImage = null;
            LoadedImagePictureBox.BackgroundImage = null;
            RestartPictureCustomButton.Enabled = false;
            SendPictureCustomButton.Enabled = false;
        }

        private void SendPictureCustomButton_Click(object sender, EventArgs e)
        {
            //to return to the main chat and send the image...
            HandleClosing();

        }

        private void ReturnCustomButton_Click(object sender, EventArgs e)
        {
            HandleClosing();
        }
        private void HandleClosing()
        {
            this.Close();
            this.Dispose();
            ServerCommunication._imageSender = null;
        }

        private void ImageSender_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerCommunication._imageSender = null;
        }
    }
}
