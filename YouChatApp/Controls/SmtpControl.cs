using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.JsonClasses;

namespace YouChatApp.Controls
{
    /// <summary>
    /// The "SmtpControl" class represents a user control for managing SMTP settings.
    /// </summary>
    /// <remarks>
    /// This class provides functionality for handling SMTP verification codes and related UI interactions.
    /// </remarks>
    public partial class SmtpControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "RestartSmtpCodeCustomButtonClick" event is raised when the restart SMTP code custom button is clicked.
        /// </summary>
        public event EventHandler RestartSmtpCodeCustomButtonClick;

        /// <summary>
        /// The EventHandler "VerifyCustomButtonClick" event is raised when the verify custom button is clicked.
        /// </summary>
        public event EventHandler VerifyCustomButtonClick;

        #endregion

        #region Private Const Fields

        /// <summary>
        /// The constant string "sentVerificationCodeMessage" represents the message indicating that the verification code was sent to the email.
        /// </summary>
        private const string sentVerificationCodeMessage = "The verification code was sent to your email";

        /// <summary>
        /// The constant string "sendRequest" represents the message prompting the user to press the refresh button to send another verification code.
        /// </summary>
        private const string sendRequest = "Press refresh button to send another verification code";

        #endregion

        #region Constructors

        /// <summary>
        /// The "SmtpControl" constructor initializes a new instance of the <see cref="SmtpControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new instance of the SmtpControl class, initializing its components and setting the placeholder text for the SMTP code input field.
        /// </remarks>
        public SmtpControl()
        {
            InitializeComponent();
            this.SmtpCodeCustomTextBox.PlaceHolderText = "Enter Verification Code";
            SetEmailNotificationLabelLocation();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "SmtpCodeCustomTextBox_TextChangedEvent" method handles the TextChanged event of the SmtpCodeCustomTextBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the SmtpCodeCustomTextBox contains a value.
        /// If it does, it enables the VerifyCustomButton; otherwise, it disables the VerifyCustomButton.
        /// </remarks>
        private void SmtpCodeCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            if (SmtpCodeCustomTextBox.IsContainingValue())
            {
                VerifyCustomButton.Enabled = true;
            }
            else
            {
                VerifyCustomButton.Enabled = false;
            }
        }

        /// <summary>
        /// The "RestartSmtpCodeCustomButton_Click" method handles the Click event of the RestartSmtpCodeCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method disables the RestartSmtpCodeCustomButton, sets the form's state to disabled, sets the location of the email notification label,
        /// invokes the RestartSmtpCodeCustomButtonClick event, updates the email notification label's text, waits for 500 milliseconds, and then enables the RestartSmtpCodeCustomButton.
        /// </remarks>
        private void RestartSmtpCodeCustomButton_Click(object sender, EventArgs e)
        {
            RestartSmtpCodeCustomButton.Enabled = false;
            SetDisabled();
            SetEmailNotificationLabelLocation();
            RestartSmtpCodeCustomButtonClick?.Invoke(this, e);
            EmailNotificationLabel.Text = sentVerificationCodeMessage;
            Thread.Sleep(500);
            RestartSmtpCodeCustomButton.Enabled = true;
        }

        /// <summary>
        /// The "VerifyCustomButton_Click" method handles the Click event of the VerifyCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method disables the SmtpCodeCustomTextBox, VerifyCustomButton, and RestartSmtpCodeCustomButton controls.
        /// It then invokes the VerifyCustomButtonClick event.
        /// </remarks>
        private void VerifyCustomButton_Click(object sender, EventArgs e)
        {
            SmtpCodeCustomTextBox.Enabled = false;
            VerifyCustomButton.Enabled = false;
            RestartSmtpCodeCustomButton.Enabled = false;
            VerifyCustomButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// The "SetEmailNotificationLabelLocation" method adjusts the position of the EmailNotificationLabel to be centered horizontally
        /// relative to the SmtpCodeCustomTextBox and aligned vertically with its original position.
        /// </summary>
        private void SetEmailNotificationLabelLocation()
        {
            int width = RestartSmtpCodeCustomButton.Location.X + RestartSmtpCodeCustomButton.Width - SmtpCodeCustomTextBox.Location.X;
            EmailNotificationLabel.Location = new Point(SmtpCodeCustomTextBox.Location.X + (width - EmailNotificationLabel.Width) / 2, EmailNotificationLabel.Location.Y);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "AddRestartSmtpCodeCustomButtonClickHandler" method adds an event handler to the RestartSmtpCodeCustomButtonClick event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        /// <remarks>
        /// This method allows external code to subscribe to the RestartSmtpCodeCustomButtonClick event by providing an event handler.
        /// </remarks>
        public void AddRestartSmtpCodeCustomButtonClickHandler(EventHandler handler)
        {
            RestartSmtpCodeCustomButtonClick += handler;
        }

        /// <summary>
        /// The "AddVerifyCustomButtonClickHandler" method adds an event handler to the VerifyCustomButtonClick event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        /// <remarks>
        /// This method allows external code to subscribe to the VerifyCustomButtonClick event by providing an event handler.
        /// </remarks>
        public void AddVerifyCustomButtonClickHandler(EventHandler handler)
        {
            VerifyCustomButtonClick += handler;
        }

        /// <summary>
        /// The "HandleWrongCodeCase" method handles the case where an incorrect SMTP code is entered.
        /// </summary>
        /// <remarks>
        /// This method sets the text of the EmailNotificationLabel to the value of the "sendRequest" variable,
        /// makes the EmailNotificationLabel visible, sets its location using the SetEmailNotificationLabelLocation method,
        /// enables the RestartSmtpCodeCustomButton, and clears the text of the SmtpCodeCustomTextBox.
        /// </remarks>
        public void HandleWrongCodeCase()
        {
            EmailNotificationLabel.Text = sendRequest;
            EmailNotificationLabel.Visible = true;
            SetEmailNotificationLabelLocation();
            RestartSmtpCodeCustomButton.Enabled = true;
            SmtpCodeCustomTextBox.TextContent = "";
        }

        /// <summary>
        /// The "IsAfterFail" method checks if the current state is after a failed attempt.
        /// </summary>
        /// <returns>True if the EmailNotificationLabel text is equal to the "sendRequest" variable; otherwise, false.</returns>
        public bool IsAfterFail()
        {
            return EmailNotificationLabel.Text == sendRequest;
        }

        /// <summary>
        /// The "SetRestartSmtpCodeCustomButtonDisable" method disables the RestartSmtpCodeCustomButton.
        /// </summary>
        public void SetRestartSmtpCodeCustomButtonDisable()
        {
            RestartSmtpCodeCustomButton.Enabled = false;
        }

        /// <summary>
        /// The "GetCode" method retrieves the entered SMTP code from the SmtpCodeCustomTextBox.
        /// </summary>
        /// <returns>The entered SMTP code as a string.</returns>
        public string GetCode()
        {
            string enteredSmtpCode = SmtpCodeCustomTextBox.TextContent;
            return enteredSmtpCode;
        }

        /// <summary>
        /// The "HandleCode" method handles the code verification process.
        /// </summary>
        /// <remarks>
        /// This method makes the EmailNotificationLabel visible, enables the SmtpCodeCustomTextBox,
        /// and enables the RestartSmtpCodeCustomButton for handling code verification.
        /// </remarks>
        public void HandleCode()
        {
            EmailNotificationLabel.Visible = true;
            SmtpCodeCustomTextBox.Enabled = true;
            RestartSmtpCodeCustomButton.Enabled = true;
        }

        /// <summary>
        /// The "SetDisabled" method disables the code verification controls.
        /// </summary>
        /// <remarks>
        /// This method clears the text content of the SmtpCodeCustomTextBox, hides the EmailNotificationLabel,
        /// and disables the SmtpCodeCustomTextBox and VerifyCustomButton controls.
        /// </remarks>
        public void SetDisabled()
        {
            SmtpCodeCustomTextBox.TextContent = "";
            EmailNotificationLabel.Visible = false;
            SmtpCodeCustomTextBox.Enabled = false;
            VerifyCustomButton.Enabled = false;
        }

        #endregion
    }
}
