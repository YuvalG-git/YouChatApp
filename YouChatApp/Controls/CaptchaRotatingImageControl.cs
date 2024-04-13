using Spire.Pdf.Exporting.XPS.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    public partial class CaptchaRotatingImageControl : UserControl
    {
        public event EventHandler CaptchaCheckerCustomButtonClick;

        private double currentAngle;
        private Image captchaImage;
        public CaptchaRotatingImageControl()
        {
            InitializeComponent();
            captchaImage = null;
        }

        private void CaptchaPictureBox_Click(object sender, EventArgs e)
        {
            //maybe i will send the rotated picture and the number of the picture i have rotated so i will be able to put it in the background...
        }

        private void CaptchaPicturesScoreLabel_Click(object sender, EventArgs e)
        {

        }
        public void SetCaptchaImages(Image captchaCircularImage, Image captchaImage, int score, int attempts)
        {
            CaptchaCircularPictureBox.BackgroundImage = captchaCircularImage;
            this.captchaImage = (Image)captchaCircularImage.Clone();
            CaptchaPictureBox.BackgroundImage = captchaImage;
            HandleSuccessRate(score, attempts);
        }
        public void HandleSuccessRate(int score, int attempts)
        {
            if (attempts != 0)
            {
                CaptchaPicturesScoreLabel.Text = "Score: " + score.ToString() + "/" + attempts.ToString();
            }
        }

        private void CaptchaCircularPictureBox_Click(object sender, EventArgs e)
        {
            //CircularPictureBox circularPictureBox = sender as CircularPictureBox;
            ////Image captchaImage = circularPictureBox.BackgroundImage;
            //if (captchaImage != null)
            //{
            //    MouseEventArgs mouseEventArgs = e as MouseEventArgs;
            //    if (mouseEventArgs != null)
            //    {
            //        Point clickPoint = mouseEventArgs.Location;
            //        Image image = ImageRotationHandler.RotateImageToPoint(circularPictureBox, captchaImage, ref currentAngle, clickPoint);
            //        if (image != null)
            //        {
            //            circularPictureBox.BackgroundImage.Dispose();

            //            circularPictureBox.BackgroundImage = image;
            //        }
            //    }
            //}

            CircularPictureBox circularPictureBox = sender as CircularPictureBox;
            if (captchaImage != null)
            {
                MouseEventArgs mouseEventArgs = e as MouseEventArgs;
                if (mouseEventArgs != null)
                {
                    Point clickPoint = mouseEventArgs.Location;
                    try
                    {
                        Image image = ImageRotationHandler.RotateImageToPoint(circularPictureBox, captchaImage, ref currentAngle, clickPoint);
                        if (image != null)
                        {
                            // Dispose of the original BackgroundImage
                            if (circularPictureBox.BackgroundImage != null)
                            {
                                circularPictureBox.BackgroundImage.Dispose();
                            }

                            circularPictureBox.BackgroundImage = image;
                        }
                    }
                    catch (OutOfMemoryException ex)
                    {
                        // Handle the exception, e.g., log it or show an error message.
                        Console.WriteLine($"Out of memory exception: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void CaptchaCircularPictureBox_BackgroundImageChanged(object sender, EventArgs e)
        {
            CircularPictureBox circularPictureBox = sender as CircularPictureBox;
            Image captchaImage = circularPictureBox.BackgroundImage;
            if (captchaImage == null)
            {
                circularPictureBox.Enabled = false;
            }
            else
            {
                circularPictureBox.Enabled = true;

            }
        }

        private void CaptchaCheckerCustomButton_Click(object sender, EventArgs e)
        {
            CaptchaCheckerCustomButtonClick?.Invoke(this, e);

        }
        public void AddCaptchaCheckerCustomButtonClickHandler(EventHandler handler)
        {
            CaptchaCheckerCustomButtonClick += handler;
        }
        public double GetAngle()
        {
            return currentAngle;
        }
    }
}
