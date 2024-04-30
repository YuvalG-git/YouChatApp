using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    /// <summary>
    /// The "OpenFileDialogHandler" class provides methods for handling OpenFileDialog to select and load image files.
    /// </summary>
    /// <remarks>
    /// This class includes a method for setting the initial directory and filter for the OpenFileDialog,
    /// as well as a method for displaying the OpenFileDialog to allow the user to select an image file.
    /// If a file is selected and successfully loaded as an Image object, it returns the Image object.
    /// If an exception occurs during the process, it displays an error message and returns null.
    /// </remarks>
    internal class OpenFileDialogHandler
    {
        #region Private Const Fields

        /// <summary>
        /// The constant string "_openFileDialogFilter" represents the filter for the open file dialog, allowing JPG, PNG, and Bitmap files.
        /// </summary>
        private const string _openFileDialogFilter = "jpg Files(*.jpg)|*.jpg|PNG Files (*.png)|*.png|Bitmap Files (*.bmp)|*.bmp";

        #endregion

        #region Private Static Fields

        /// <summary>
        /// The static string "_openFileDialogInitialDirectory" represents the initial directory for the open file dialog, obtained from the "GetPicturesFolderPath()" method.
        /// </summary>
        private static string _openFileDialogInitialDirectory = GetPicturesFolderPath();

        #endregion

        #region Private Static Methods

        /// <summary>
        /// The "GetPicturesFolderPath" method retrieves the path to the user's "My Pictures" folder.
        /// </summary>
        /// <returns>The path to the "My Pictures" folder.</returns>
        /// <remarks>
        /// This method uses the Environment.GetFolderPath method with the Environment.SpecialFolder.MyPictures enum value
        /// to retrieve the path to the user's "My Pictures" folder. This folder is typically used for storing image files.
        /// </remarks>
        private static string GetPicturesFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// The "HandleOpenFileDialog" method handles the OpenFileDialog to select and load an image file.
        /// </summary>
        /// <param name="openFileDialog">The OpenFileDialog instance used to select the image file.</param>
        /// <returns>The loaded image if successful, or null otherwise.</returns>
        /// <remarks>
        /// This method sets the initial directory and filter for the OpenFileDialog based on predefined values.
        /// It then displays the OpenFileDialog to allow the user to select an image file.
        /// If a file is selected and successfully loaded as an Image object, it returns the Image object.
        /// If an exception occurs during the process, it displays an error message and returns null.
        /// </remarks>
        public static Image HandleOpenFileDialog(OpenFileDialog openFileDialog)
        {
            string ImageLocation = "";
            Image image = null;
            try
            {
                openFileDialog.InitialDirectory = _openFileDialogInitialDirectory;
                openFileDialog.Filter = _openFileDialogFilter;
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ImageLocation = openFileDialog.FileName;
                    image = Image.FromFile(ImageLocation);
                }
                return image;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured");
                return image;
            }
        }

        #endregion
    }
}
