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
        private static double CalculateRotationAngle(CircularPictureBox circularPictureBox, Point clickPoint)
        {
            double deltaX = clickPoint.X - circularPictureBox.Width / 2;
            double deltaY = clickPoint.Y - circularPictureBox.Height / 2;

            double angleInRadians = Math.Atan2(deltaY, deltaX);
            double angleInDegrees = angleInRadians * (180.0 / Math.PI);
            return angleInDegrees + 90; // Add 90 degrees to align with clicked point
        }
        public static void RotateImageToPoint(CircularPictureBox circularPictureBox, Image captchaImage, double captchaImageAngle, Point clickPoint)
        {
            captchaImageAngle = CalculateRotationAngle(circularPictureBox, clickPoint);

            Bitmap rotatedImage = new Bitmap(circularPictureBox.BackgroundImage.Width, circularPictureBox.BackgroundImage.Height);
            using (Graphics graphics = Graphics.FromImage(rotatedImage))
            {
                graphics.TranslateTransform(rotatedImage.Width / 2, rotatedImage.Height / 2);
                graphics.RotateTransform((float)captchaImageAngle);
                graphics.TranslateTransform(-rotatedImage.Width / 2, -rotatedImage.Height / 2);
                graphics.DrawImage(captchaImage, new PointF(0, 0));
            }

            circularPictureBox.BackgroundImage = rotatedImage;
        }
        //private void RotateImage(Control control) //try to use it - if doesnt work 2 parmeters: picturebox and circularpicturebox - to check which one and act accordinglly
        //{
        //    Bitmap rotatedImage = new Bitmap(control.BackgroundImage.Width, control.BackgroundImage.Height);
        //    using (Graphics graphics = Graphics.FromImage(rotatedImage))
        //    {
        //        graphics.TranslateTransform(rotatedImage.Width / 2, rotatedImage.Height / 2);
        //        graphics.RotateTransform((float)CaptchaCircularPictureBoxAngle);
        //        graphics.TranslateTransform(-rotatedImage.Width / 2, -rotatedImage.Height / 2);
        //        graphics.DrawImage(CaptchaPicturesImageList.Images[CurrentPictureIndex], new PointF(0, 0));
        //    }
        //    control.BackgroundImage = rotatedImage;
        //}
    }
}
