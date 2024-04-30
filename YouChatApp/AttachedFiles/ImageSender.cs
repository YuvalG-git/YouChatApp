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
    /// <summary>
    /// The "ImageSender" class represents a form for sending images.
    /// </summary>
    /// <remarks>
    /// This class provides functionality for selecting and sending images.
    /// It includes methods for loading images, displaying them in a picture box,
    /// and handling user interactions such as sending, restarting, and viewing images.
    /// </remarks>
    public partial class ImageSender : Form
    {
        #region Private Fields

        /// <summary>
        /// The Image "uploadedImage" represents the image that has been uploaded.
        /// </summary>
        private Image uploadedImage;

        #endregion

        #region Public Static Fields

        /// <summary>
        /// The static Image "selectedImage" represents the image that has been selected.
        /// </summary>
        public static Image selectedImage;

        #endregion

        #region Constructors

        /// <summary>
        /// The "ImageSender" constructor initializes a new instance of the <see cref="ImageSender"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new instance of the ImageSender class, initializing its components.
        /// </remarks>
        public ImageSender()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "LoadedImagePictureBox_Click" method handles the click event of the LoadedImagePictureBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method retrieves the background image of the LoadedImagePictureBox control.
        /// If the background image is not null, it creates a new ImageViewer form with the image and displays it.
        /// </remarks>
        private void LoadedImagePictureBox_Click(object sender, EventArgs e)
        {
            Image image = LoadedImagePictureBox.BackgroundImage;
            if (image != null)
            {
                ImageViewer imageViewer = new ImageViewer(image);
                imageViewer.Show();
            }
        }

        /// <summary>
        /// The "LoadPictureCustomButton_Click" method handles the click event of the LoadPictureCustomButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method opens a file dialog to allow the user to select an image file.
        /// It sets the selected image as the background image of the LoadedImagePictureBox control.
        /// It also enables the RestartPictureCustomButton and SendPictureCustomButton controls.
        /// </remarks>
        private void LoadPictureCustomButton_Click(object sender, EventArgs e)
        {
            Image selectedImage = OpenFileDialogHandler.HandleOpenFileDialog(UploadedPictureOpenFileDialog);
            uploadedImage = selectedImage;
            LoadedImagePictureBox.BackgroundImage = uploadedImage;
            RestartPictureCustomButton.Enabled = true;
            SendPictureCustomButton.Enabled = true;
        }

        /// <summary>
        /// The "RestartPictureCustomButton_Click" method handles the click event of the RestartPictureCustomButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method clears the uploaded image and resets the background image of the LoadedImagePictureBox control to null.
        /// It also disables the RestartPictureCustomButton and SendPictureCustomButton controls.
        /// </remarks>
        private void RestartPictureCustomButton_Click(object sender, EventArgs e)
        {
            uploadedImage = null;
            LoadedImagePictureBox.BackgroundImage = null;
            RestartPictureCustomButton.Enabled = false;
            SendPictureCustomButton.Enabled = false;
        }

        /// <summary>
        /// The "SendPictureCustomButton_Click" method handles the click event of the SendPictureCustomButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method sets the selectedImage variable to the uploadedImage and sets the DialogResult property of the form to DialogResult.OK.
        /// It then calls the HandleClosing method to handle the closing of the form.
        /// </remarks>
        private void SendPictureCustomButton_Click(object sender, EventArgs e)
        {
            selectedImage = uploadedImage;
            this.DialogResult = DialogResult.OK;
            HandleClosing();
        }

        /// <summary>
        /// The "ReturnCustomButton_Click" method handles the click event of the ReturnCustomButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method calls the HandleClosing method to handle the closing of the form.
        /// </remarks>
        private void ReturnCustomButton_Click(object sender, EventArgs e)
        {
            HandleClosing();
        }

        /// <summary>
        /// The "HandleClosing" method closes the current form, disposes of its resources, and sets the _imageSender reference in FormHandler to null.
        /// </summary>
        /// <remarks>
        /// This method is used to clean up resources and finalize the form before closing.
        /// </remarks>
        private void HandleClosing()
        {
            this.Close();
            this.Dispose();
            FormHandler._imageSender = null;
        }

        /// <summary>
        /// The "ImageSender_FormClosing" method handles the FormClosing event of the ImageSender form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The FormClosingEventArgs containing event data.</param>
        /// <remarks>
        /// This method sets the _imageSender reference in FormHandler to null when the ImageSender form is closing.
        /// </remarks>
        private void ImageSender_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormHandler._imageSender = null;
        }

        #endregion
    }
}
