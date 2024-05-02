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
    /// The "CaptchaCodeControl" class represents a custom UserControl for entering captcha codes.
    /// </summary>
    /// <remarks>
    /// This control includes a text box for entering the captcha code, a picture box for displaying the captcha image,
    /// and custom buttons for checking the code and restarting the captcha. It provides events for custom button clicks
    /// and methods for interacting with the captcha control.
    /// </remarks>
    public partial class CaptchaCodeControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "CaptchaCheckerCustomButtonClick" event is raised when the captcha checker custom button is clicked.
        /// </summary>
        public event EventHandler CaptchaCheckerCustomButtonClick;

        /// <summary>
        /// The EventHandler "RestartCaptchaCustomButtonClick" event is raised when the restart captcha custom button is clicked.
        /// </summary>
        public event EventHandler RestartCaptchaCustomButtonClick;

        #endregion

        #region Constructors

        /// <summary>
        /// The "CaptchaCodeControl" constructor initializes a new instance of the <see cref="CaptchaCodeControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the CaptchaCodeControl by initializing its components.
        /// </remarks>
        public CaptchaCodeControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "CaptchaCheckerCustomButton_Click" method handles the click event for the CaptchaCheckerCustomButton.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method disables the CaptchaCodeCustomTextBox, CaptchaCheckerCustomButton, and RestartCaptchaCustomButton
        /// controls and invokes the CaptchaCheckerCustomButtonClick event, typically used to check the entered captcha code.
        /// </remarks>
        private void CaptchaCheckerCustomButton_Click(object sender, EventArgs e)
        {
            CaptchaCodeCustomTextBox.Enabled = false;
            CaptchaCheckerCustomButton.Enabled = false;
            RestartCaptchaCustomButton.Enabled = false;
            CaptchaCheckerCustomButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// The "RestartCaptchaCustomButton_Click" method handles the click event for the RestartCaptchaCustomButton.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method clears the text in the CaptchaCodeCustomTextBox, disables the CaptchaCodeCustomTextBox and
        /// CaptchaCheckerCustomButton controls, sets the CaptchaPictureBox's image to null, hides the NotificationLabel,
        /// and invokes the RestartCaptchaCustomButtonClick event, typically used to restart the captcha verification process.
        /// </remarks>
        private void RestartCaptchaCustomButton_Click(object sender, EventArgs e)
        {
            CaptchaCodeCustomTextBox.TextContent = "";
            CaptchaCodeCustomTextBox.Enabled = false;
            CaptchaCheckerCustomButton.Enabled = false;
            CaptchaPictureBox.Image = null;
            RestartCaptchaCustomButtonClick?.Invoke(this, e);
            NotificationLabel.Visible = false;
        }

        /// <summary>
        /// The "CaptchaCodeCustomTextBox_TextChangedEvent" method handles the TextChangedEvent for the CaptchaCodeCustomTextBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method enables or disables the CaptchaCheckerCustomButton based on whether the CaptchaCodeCustomTextBox
        /// contains a value. It is typically used to enable the captcha check button when the user enters a captcha code.
        /// </remarks>
        private void CaptchaCodeCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            if (CaptchaCodeCustomTextBox.IsContainingValue())
            {
                CaptchaCheckerCustomButton.Enabled = true;
            }
            else
            {
                CaptchaCheckerCustomButton.Enabled = false;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "GetCaptchaCode" method retrieves the text content of the CaptchaCodeCustomTextBox.
        /// </summary>
        /// <returns>The text content of the CaptchaCodeCustomTextBox.</returns>
        public string GetCaptchaCode()
        {
            return CaptchaCodeCustomTextBox.TextContent;
        }

        /// <summary>
        /// The "AddCaptchaCheckerCustomButtonClickHandler" method adds an event handler to the CaptchaCheckerCustomButtonClick event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        public void AddCaptchaCheckerCustomButtonClickHandler(EventHandler handler)
        {
            CaptchaCheckerCustomButtonClick += handler;
        }

        /// <summary>
        /// The "HandleWrongCodeCase" method handles the case when the entered captcha code is incorrect.
        /// </summary>
        /// <remarks>
        /// This method makes the NotificationLabel visible, enables the RestartCaptchaCustomButton, and clears the text in the CaptchaCodeCustomTextBox.
        /// It is typically called when the captcha verification fails.
        /// </remarks>
        public void HandleWrongCodeCase()
        {
            NotificationLabel.Visible = true;
            RestartCaptchaCustomButton.Enabled = true;
            CaptchaCodeCustomTextBox.TextContent = "";
        }

        /// <summary>
        /// The "IsNotificationLabelVisible" method checks if the NotificationLabel is currently visible.
        /// </summary>
        /// <returns>True if the NotificationLabel is visible, otherwise false.</returns>
        public bool IsNotificationLabelVisible()
        {
            return NotificationLabel.Visible;
        }

        /// <summary>
        /// The "AddRestartCaptchaCustomButtonClickHandler" method adds an event handler to the RestartCaptchaCustomButtonClick event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        public void AddRestartCaptchaCustomButtonClickHandler(EventHandler handler)
        {
            RestartCaptchaCustomButtonClick += handler;
        }

        /// <summary>
        /// The "SetCaptchaImage" method sets the image of the CaptchaPictureBox and enables the CaptchaCodeCustomTextBox.
        /// </summary>
        /// <param name="captchaImage">The image to set as the captcha image.</param>
        /// <remarks>
        /// This method also clears the text in the CaptchaCodeCustomTextBox.
        /// </remarks>
        public void SetCaptchaImage(Image captchaImage)
        {
            CaptchaPictureBox.Image = captchaImage;
            CaptchaCodeCustomTextBox.TextContent = "";
            CaptchaCodeCustomTextBox.Enabled = true;
        }

        #endregion
    }
}
