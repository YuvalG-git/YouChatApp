using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    internal class OpenFileDialogHandler
    {
        private const string _openFileDialogFilter = "jpg Files(*.jpg)|*.jpg|PNG Files (*.png)|*.png|Bitmap Files (*.bmp)|*.bmp";
        private static string _openFileDialogInitialDirectory = GetPicturesFolderPath();
        private static string GetPicturesFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

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
       
    }
}
