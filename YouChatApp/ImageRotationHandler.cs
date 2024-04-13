using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    internal class ImageRotationHandler
    {
        private static Graphics graphics;
        private static double CalculateRotationAngle(CircularPictureBox circularPictureBox, Point clickPoint)
        {
            double deltaX = clickPoint.X - circularPictureBox.Width / 2;
            double deltaY = clickPoint.Y - circularPictureBox.Height / 2;

            double angleInRadians = Math.Atan2(deltaY, deltaX);
            double angleInDegrees = angleInRadians * (180.0 / Math.PI);
            return angleInDegrees + 90; // Add 90 degrees to align with clicked point
        }
        public static Bitmap RotateImageToPoint(CircularPictureBox circularPictureBox, Image captchaImage, ref double captchaImageAngle, Point clickPoint)
        {
            Bitmap rotatedImage = new Bitmap(circularPictureBox.BackgroundImage.Width, circularPictureBox.BackgroundImage.Height);
            try
            {
                captchaImageAngle = CalculateRotationAngle(circularPictureBox, clickPoint);

                Console.WriteLine(circularPictureBox.BackgroundImage.Width + " " + circularPictureBox.BackgroundImage.Height);
                Console.WriteLine(captchaImage.Width + " " + captchaImage.Height);

                graphics = Graphics.FromImage(rotatedImage);
                graphics.TranslateTransform(rotatedImage.Width / 2, rotatedImage.Height / 2);
                graphics.RotateTransform((float)captchaImageAngle);
                graphics.TranslateTransform(-rotatedImage.Width / 2, -rotatedImage.Height / 2);
                graphics.DrawImage(captchaImage, new PointF(0, 0));
                if (circularPictureBox.BackgroundImage != null)
                {
                    circularPictureBox.BackgroundImage.Dispose();
                }
                // Assign the rotated image to BackgroundImage
                return new Bitmap(rotatedImage);
            }
            catch (OutOfMemoryException ex)
            {
                // Handle the exception, e.g., log it or show an error message.
                Console.WriteLine($"Out of memory exception: {ex.Message}");
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
    }
}
