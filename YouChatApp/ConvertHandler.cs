using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    /// <summary>
    /// The "ConvertHandler" class provides methods for converting images to and from byte arrays.
    /// </summary>
    internal class ConvertHandler
    {
        #region Public Static Methods

        /// <summary>
        /// The "ConvertBytesToImage" method converts a byte array to an Image object.
        /// </summary>
        /// <param name="imageBytes">The byte array representing the image.</param>
        /// <returns>An Image object created from the byte array.</returns>
        /// <remarks>
        /// This method creates a MemoryStream from the byte array and uses it to create an Image object.
        /// </remarks>
        public static Image ConvertBytesToImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }

        /// <summary>
        /// The "ConvertImageToBytes" method converts an Image object to a byte array.
        /// </summary>
        /// <param name="image">The Image object to convert.</param>
        /// <returns>A byte array representing the Image object.</returns>
        /// <remarks>
        /// This method saves the Image object to a MemoryStream as a JPEG image, then converts the MemoryStream to a byte array.
        /// </remarks>
        public static byte[] ConvertImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// The "ConvertImageToRawFormatBytes" method converts an Image object to a byte array using its raw format.
        /// </summary>
        /// <param name="image">The Image object to convert.</param>
        /// <returns>A byte array representing the Image object in its raw format.</returns>
        /// <remarks>
        /// This method saves the Image object to a MemoryStream using its raw format, then converts the MemoryStream to a byte array.
        /// </remarks>
        public static byte[] ConvertImageToRawFormatBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        #endregion
    }
}
