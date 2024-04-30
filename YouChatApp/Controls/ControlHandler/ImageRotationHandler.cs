using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    /// <summary>
    /// The "ImageRotationHandler" class provides methods for rotating images around a specified point.
    /// </summary>
    /// <remarks>
    /// This class includes a method for calculating the rotation angle for an image around the center of a CircularPictureBox,
    /// as well as a method for rotating the image to the specified point.
    /// If an exception occurs during the rotation process, the method handles it and returns null, displaying an error message.
    /// </remarks>
    internal class ImageRotationHandler
    {
        #region Private Static Fields

        /// <summary>
        /// The static Graphics "graphics" represents the graphics object.
        /// </summary>
        private static Graphics graphics;

        #endregion

        #region Private Static Methods

        /// <summary>
        /// The "CalculateRotationAngle" method calculates the rotation angle for a point around the center of a CircularPictureBox.
        /// </summary>
        /// <param name="circularPictureBox">The CircularPictureBox to calculate the rotation angle for.</param>
        /// <param name="clickPoint">The point around which to calculate the rotation angle.</param>
        /// <returns>The rotation angle in degrees.</returns>
        /// <remarks>
        /// This method calculates the angle between the horizontal axis and the line connecting the center of the CircularPictureBox
        /// and the specified point (clickPoint). The angle is adjusted by 90 degrees to align with the typical orientation of angles
        /// in a circular context, where 0 degrees is at the top.
        /// </remarks>
        private static double CalculateRotationAngle(CircularPictureBox circularPictureBox, Point clickPoint)
        {
            double deltaX = clickPoint.X - circularPictureBox.Width / 2;
            double deltaY = clickPoint.Y - circularPictureBox.Height / 2;
            double angleInRadians = Math.Atan2(deltaY, deltaX);
            double angleInDegrees = angleInRadians * (180.0 / Math.PI);
            return angleInDegrees + 90;
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// The "RotateImageToPoint" method rotates the given captchaImage to a specified point around the center of a CircularPictureBox.
        /// </summary>
        /// <param name="circularPictureBox">The CircularPictureBox used for reference.</param>
        /// <param name="captchaImage">The image to rotate.</param>
        /// <param name="captchaImageAngle">The angle of rotation for the captchaImage.</param>
        /// <param name="clickPoint">The point around which to rotate the image.</param>
        /// <param name="errorLabel">The label used to display an error message if an exception occurs.</param>
        /// <returns>The rotated image as a Bitmap, or null if an exception occurs.</returns>
        /// <remarks>
        /// This method calculates the rotation angle for the captchaImage based on the clickPoint and the center of the CircularPictureBox.
        /// It then rotates the image using the calculated angle and returns the rotated image as a Bitmap.
        /// If an exception occurs during the rotation process, the method handles it and returns null, displaying an error message in the errorLabel.
        /// </remarks>
        public static Bitmap RotateImageToPoint(CircularPictureBox circularPictureBox, Image captchaImage, ref double captchaImageAngle, Point clickPoint, Label errorLabel)
        {
            Bitmap rotatedImage = new Bitmap(circularPictureBox.BackgroundImage.Width, circularPictureBox.BackgroundImage.Height);
            try
            {
                captchaImageAngle = CalculateRotationAngle(circularPictureBox, clickPoint);
                graphics = Graphics.FromImage(rotatedImage);
                graphics.TranslateTransform(rotatedImage.Width / 2, rotatedImage.Height / 2);
                graphics.RotateTransform((float)captchaImageAngle);
                graphics.TranslateTransform(-rotatedImage.Width / 2, -rotatedImage.Height / 2);
                graphics.DrawImage(captchaImage, new PointF(0, 0));
                if (circularPictureBox.BackgroundImage != null)
                {
                    circularPictureBox.BackgroundImage.Dispose();
                }
                return new Bitmap(rotatedImage);
            }
            catch (OutOfMemoryException ex)
            {
                // Handle the exception, e.g., log it or show an error message.
                Console.WriteLine($"Out of memory exception: {ex.Message}");
                errorLabel.Visible = true;
                circularPictureBox.Enabled = false;
                return null;
            }
            catch (ExternalException ex)
            {
                // Handle the exception
                Console.WriteLine($"GDI+ Exception: {ex.Message}");
                errorLabel.Visible = true;
                circularPictureBox.Enabled = false;
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                rotatedImage.Dispose();
                graphics.Dispose();
            } 
        }

        #endregion
    }
}
