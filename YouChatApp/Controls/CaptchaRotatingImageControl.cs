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
    /// <summary>
    /// The "CaptchaRotatingImageControl" class represents a custom UserControl for displaying a rotating captcha image.
    /// </summary>
    /// <remarks>
    /// This control includes a circular picture box for displaying the captcha image. It allows the image to be rotated
    /// by clicking on the picture box and provides events for custom button clicks related to captcha verification.
    /// </remarks>
    public partial class CaptchaRotatingImageControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "CaptchaCheckerCustomButtonClick" event is raised when the captcha checker custom button is clicked.
        /// </summary>
        public event EventHandler CaptchaCheckerCustomButtonClick;

        #endregion

        #region Private Fields

        /// <summary>
        /// The double "currentAngle" represents the current angle.
        /// </summary>
        private double currentAngle;

        /// <summary>
        /// The Image "captchaImage" represents the captcha image.
        /// </summary>
        private Image captchaImage;

        #endregion

        #region Constructors

        /// <summary>
        /// The "CaptchaRotatingImageControl" constructor initializes a new instance of the <see cref="CaptchaRotatingImageControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the CaptchaRotatingImageControl by initializing its components.
        /// It also initializes the captchaImage to null.
        /// </remarks>
        public CaptchaRotatingImageControl()
        {
            InitializeComponent();
            captchaImage = null;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "CaptchaCircularPictureBox_Click" method handles the click event for the CaptchaCircularPictureBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method rotates the captcha image displayed in the CaptchaCircularPictureBox when clicked.
        /// It calculates the click point relative to the control, rotates the image based on the click point,
        /// and updates the CaptchaCircularPictureBox's background image with the rotated image.
        /// </remarks>
        private void CaptchaCircularPictureBox_Click(object sender, EventArgs e)
        {
            CircularPictureBox circularPictureBox = sender as CircularPictureBox;
            if (captchaImage != null)
            {
                MouseEventArgs mouseEventArgs = e as MouseEventArgs;
                if (mouseEventArgs != null)
                {
                    Point clickPoint = mouseEventArgs.Location;
                    try
                    {
                        Image image = ImageRotationHandler.RotateImageToPoint(circularPictureBox, captchaImage, ref currentAngle, clickPoint, RefreshLabel);
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

        /// <summary>
        /// The "CaptchaCircularPictureBox_BackgroundImageChanged" method handles the BackgroundImageChanged event for the CaptchaCircularPictureBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method enables or disables the CaptchaCircularPictureBox based on the presence of a background image.
        /// If there is no background image (e.g., after rotating the captcha image), the control is disabled to prevent further interaction.
        /// </remarks>
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

        /// <summary>
        /// The "CaptchaCheckerCustomButton_Click" method handles the click event for the CaptchaCheckerCustomButton.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method hides the RefreshLabel, enables the CaptchaCircularPictureBox, and invokes the CaptchaCheckerCustomButtonClick event.
        /// It is typically used when the custom button in the captcha checker is clicked to perform a custom action.
        /// </remarks>
        private void CaptchaCheckerCustomButton_Click(object sender, EventArgs e)
        {
            RefreshLabel.Visible = false;
            CaptchaCircularPictureBox.Enabled = true;
            CaptchaCheckerCustomButtonClick?.Invoke(this, e);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "SetCaptchaImages" method sets the captcha images and handles the success rate display.
        /// </summary>
        /// <param name="captchaCircularImage">The circular captcha image to be displayed.</param>
        /// <param name="captchaImage">The captcha image to be displayed.</param>
        /// <param name="score">The score indicating the success rate of captcha verification.</param>
        /// <param name="attempts">The number of attempts made for captcha verification.</param>
        /// <remarks>
        /// This method sets the background images of the CaptchaCircularPictureBox and CaptchaPictureBox
        /// to the provided circular and regular captcha images respectively. It also updates the success rate display.
        /// </remarks>
        public void SetCaptchaImages(Image captchaCircularImage, Image captchaImage, int score, int attempts)
        {
            CaptchaCircularPictureBox.BackgroundImage = captchaCircularImage;
            this.captchaImage = (Image)captchaCircularImage.Clone();
            CaptchaPictureBox.BackgroundImage = captchaImage;
            HandleSuccessRate(score, attempts);
        }

        /// <summary>
        /// The "HandleSuccessRate" method updates the success rate display based on the provided score and attempts.
        /// </summary>
        /// <param name="score">The score indicating the success rate of captcha verification.</param>
        /// <param name="attempts">The number of attempts made for captcha verification.</param>
        /// <remarks>
        /// This method updates the text of the CaptchaPicturesScoreLabel to show the current score
        /// and the total number of attempts made for captcha verification.
        /// </remarks>
        public void HandleSuccessRate(int score, int attempts)
        {
            if (attempts != 0)
            {
                CaptchaPicturesScoreLabel.Text = "Score: " + score.ToString() + "/" + attempts.ToString();
            }
        }

        /// <summary>
        /// The "AddCaptchaCheckerCustomButtonClickHandler" method adds an event handler for the CaptchaCheckerCustomButtonClick event.
        /// </summary>
        /// <param name="handler">The event handler to be added.</param>
        /// <remarks>
        /// This method adds the provided event handler to the CaptchaCheckerCustomButtonClick event,
        /// which is triggered when the custom button in the captcha checker is clicked.
        /// </remarks>
        public void AddCaptchaCheckerCustomButtonClickHandler(EventHandler handler)
        {
            CaptchaCheckerCustomButtonClick += handler;
        }

        /// <summary>
        /// The "GetAngle" method returns the current angle of the captcha image rotation.
        /// </summary>
        /// <returns>The current angle of the captcha image rotation.</returns>
        /// <remarks>
        /// This method returns the value of the currentAngle field, which represents the current angle of rotation
        /// applied to the captcha image in the CaptchaCircularPictureBox.
        /// </remarks>
        public double GetAngle()
        {
            return currentAngle;
        }

        #endregion
    }
}
