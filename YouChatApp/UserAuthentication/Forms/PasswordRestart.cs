using Newtonsoft.Json;
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
using YouChatApp.Controls;
using YouChatApp.JsonClasses;

namespace YouChatApp.UserAuthentication.Forms
{
    public partial class PasswordRestart : Form
    {
        #region Private Readonly Fields

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" is used for communicating with the server.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        #endregion

        #region Private Fields

        /// <summary>
        /// The EnumHandler.PasswordResetPhases_Enum "resetPasswordPhase" represents the current phase of the password reset process.
        /// </summary>
        private EnumHandler.PasswordResetPhases_Enum resetPasswordPhase;

        #endregion

        #region Constructors

        /// <summary>
        /// The "PasswordRestart" constructor initializes a new instance of the <see cref="PasswordRestart"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new PasswordRestart instance and set up its components.
        /// It initializes the server communicator instance, adds a text changed event handler to the PasswordGeneratorControl,
        /// adds event handlers for restarting the SMTP code sending process, and sets the restart SMTP code custom button to disabled.
        /// </remarks>
        public PasswordRestart()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            PasswordGeneratorControl.OnTextChangedEventHandler(UpdatePasswordFieldsChecker);
            SmtpControl.AddRestartSmtpCodeCustomButtonClickHandler(HandleSendingEmailProcess);
            SmtpControl.AddVerifyCustomButtonClickHandler(SendSmtpCode);
            SmtpControl.SetRestartSmtpCodeCustomButtonDisable();
        }
        public void HandleRecievedEmail()
        {
            SmtpControl.HandleCode();
        }
        public void HandleWrongCodeResponse()
        {
            SmtpControl.HandleWrongCodeCase();
        }
        public void HandleCorrectCodeResponse()
        {
            PasswordGeneratorControl.Enabled = true;
            resetPasswordPhase = EnumHandler.PasswordResetPhases_Enum.PasswordReset;
            SmtpControl.SetDisabled();
        }

        private void SendSmtpCode(object sender, EventArgs e)
        {
            string enteredSmtpCode = SmtpControl.GetCode();

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.ResetPasswordRequest_SmtpCode;
            object messageContent = enteredSmtpCode;
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        private void HandleSendingEmailProcess(object sender, EventArgs e)
        {
            HandleSendingEmailProcess();
        }
        /// <summary>
        /// The "GetSmtpDetailsObject" method retrieves SMTP details from the UI controls and constructs a SmtpDetails object.
        /// </summary>
        /// <returns>A SmtpDetails object containing the SMTP details.</returns>
        /// <remarks>
        /// This method gets the username, email address, and verification status from the respective UI controls.
        /// It then creates a SmtpVerification object with the username and verification status.
        /// Finally, it constructs a SmtpDetails object with the email address and the SmtpVerification object.
        /// </remarks>
        private SmtpDetails GetSmtpDetailsObject()
        {
            string Username = UsernameCustomTextBox.TextContent;
            bool afterFail = SmtpControl.IsAfterFail();
            string Email = EmailAddressCustomTextBox.TextContent;
            SmtpVerification smtpVerification = new SmtpVerification(Username, afterFail);
            SmtpDetails smtpDetails = new SmtpDetails(Email, smtpVerification);
            return smtpDetails;
        }

        /// <summary>
        /// The "HandleSendingEmailProcess" method is used to handle the process of sending an email for resetting the password.
        /// </summary>
        /// <remarks>
        /// This method retrieves the SMTP details object using the GetSmtpDetailsObject method.
        /// It then sends a reset password request to the server with the SMTP details object as the message content.
        /// </remarks>
        private void HandleSendingEmailProcess()
        {
            SmtpDetails smtpDetails = GetSmtpDetailsObject();

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.ResetPasswordRequest_SmtpMessage;
            object messageContent = smtpDetails;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "ResetPasswordFieldsChecker" method checks if the username field and the email address field have values.
        /// If both fields have values, it enables the CodeSenderCustomButton; otherwise, it disables the button.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void ResetPasswordFieldsChecker(object sender, EventArgs e)
        {
            bool UsernameField = UsernameCustomTextBox.IsContainingValue();
            bool EmailAddressField = EmailAddressCustomTextBox.IsContainingValue();

            if ((UsernameField) && (EmailAddressField))
            {
                CodeSenderCustomButton.Enabled = true;
            }
            else
            {
                CodeSenderCustomButton.Enabled = false;
            }
        }

        /// <summary>
        /// The "UpdatePasswordFieldsChecker" method checks if all password fields have values and if the passwords match.
        /// It also checks if the username field has a value.
        /// If both conditions are true, it enables the PasswordReplacerCustomButton; otherwise, it disables the button.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void UpdatePasswordFieldsChecker(object sender, EventArgs e)
        {
            bool PasswordFields = PasswordGeneratorControl.DoesAllFieldsHaveValue() && PasswordGeneratorControl.IsSamePassword();
            bool UsernameField = UsernameCustomTextBox.IsContainingValue();
            if ((PasswordFields) && (UsernameField))
            {
                PasswordReplacerCustomButton.Enabled = true;
            }
            else
            {
                PasswordReplacerCustomButton.Enabled = false;
            }
        }

        /// <summary>
        /// The "HandleMatchingUsernameAndEmailAddress" method handles the case when the username and email address match during the password reset process.
        /// </summary>
        /// <remarks>
        /// This method sets the reset password phase to Smtp, handles the code in the SmtpControl, and disables the CodeSenderCustomButton.
        /// </remarks>
        public void HandleMatchingUsernameAndEmailAddress()
        {
            resetPasswordPhase = EnumHandler.PasswordResetPhases_Enum.Smtp;
            SmtpControl.HandleCode();
            CodeSenderCustomButton.Enabled = false;
        }

        /// <summary>
        /// The "LoginReturnerCustomButton_Click" method handles the click event of the LoginReturnerCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method closes the current form and resets the password restart form reference to null.
        /// </remarks>
        private void LoginReturnerCustomButton_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHandler._passwordRestart = null;
        }

        /// <summary>
        /// The "CodeSenderCustomButton_Click" method handles the click event of the CodeSenderCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the SMTP details object using the GetSmtpDetailsObject method.
        /// It then sends a reset password request to the server with the SMTP details object as the message content.
        /// </remarks>
        private void CodeSenderCustomButton_Click(object sender, EventArgs e)
        {
            SmtpDetails smtpDetails = GetSmtpDetailsObject();

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.ResetPasswordRequest;
            object messageContent = smtpDetails;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "PasswordReplacerCustomButton_Click" method handles the click event of the PasswordReplacerCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the username and new password from the UsernameCustomTextBox and PasswordGeneratorControl, respectively.
        /// It then creates a new LoginDetails object with the username and new password.
        /// Next, it sends a password renewal message request to the server with the LoginDetails object as the message content.
        /// Finally, it disables the PasswordGeneratorControl.
        /// </remarks>
        private void PasswordReplacerCustomButton_Click(object sender, EventArgs e)
        {
            string username = UsernameCustomTextBox.TextContent;
            string newPassword = PasswordGeneratorControl.GetNewPassword();
            LoginDetails resetPasswordDetails = new LoginDetails(username, newPassword);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.PasswordRenewalMessageRequest;
            object messageContent = resetPasswordDetails;
            serverCommunicator.SendMessage(messageType, messageContent);
            SetPasswordGeneratorControlEnable(false);
        }
        /// <summary>
        /// The "RestartDetails" method restarts the password reset process by disabling the CodeSenderCustomButton and showing a message box indicating incorrect details.
        /// </summary>
        /// <remarks>
        /// This method is called when the user's details are incorrect during the password reset process. It disables the CodeSenderCustomButton to prevent further actions and displays a message box instructing the user to check for mistakes in their details.
        /// </remarks>
        public void RestartDetails()
        {
            CodeSenderCustomButton.Enabled = false;
            MessageBox.Show("Your details were incorrect\nPlease Check for mistakes", "Incorrect Details");
        }
        /// <summary>
        /// The "HandleSuccessfulPasswordRenewal" method handles a successful password renewal by resetting the password restart form, hiding the current form, and disposing of it.
        /// </summary>
        /// <remarks>
        /// This method is called when a user successfully renews their password. It resets the password restart form, hides the current form, and disposes of it to clean up resources.
        /// </remarks>
        public void HandleSuccessfulPasswordRenewal()
        {
            this.Hide();
            this.Dispose();
            FormHandler._passwordRestart = null;
        }

        /// <summary>
        /// The "SetPasswordGeneratorControlEnable" method enables or disables the PasswordGeneratorControl and disables the PasswordReplacerCustomButton.
        /// </summary>
        /// <param name="enable">True to enable the PasswordGeneratorControl, false to disable it.</param>
        /// <remarks>
        /// This method is used to enable or disable the PasswordGeneratorControl based on the provided parameter. It also disables the PasswordReplacerCustomButton to prevent its use while the PasswordGeneratorControl is enabled.
        /// </remarks>
        public void SetPasswordGeneratorControlEnable(bool enable)
        {
            PasswordGeneratorControl.SetEnable(enable);
            PasswordReplacerCustomButton.Enabled = false;
        }

        /// <summary>
        /// The "HandleBan" method handles a ban by showing the BanControl with the specified ban duration, and hiding the PasswordResetPanel.
        /// </summary>
        /// <param name="banDuration">The duration of the ban in seconds.</param>
        /// <remarks>
        /// This method is called when a user is banned. It shows the BanControl with the specified ban duration and hides the PasswordResetPanel.
        /// </remarks>
        public void HandleBan(double banDuration)
        {
            BanControl.Visible = true;
            BanControl.HandleBan(banDuration);
            PasswordResetPanel.Visible = false;
        }

        /// <summary>
        /// The "HandleBanOver" method handles the end of a ban by hiding the BanControl, showing the PasswordResetPanel, and setting the form's state based on the current resetPasswordPhase.
        /// </summary>
        /// <remarks>
        /// This method is called when a user's ban is over. It hides the BanControl, shows the PasswordResetPanel, and sets the form's state based on the current phase of the password reset process using the SetFormByState method.
        /// </remarks>
        public void HandleBanOver()
        {
            BanControl.Visible = false;
            PasswordResetPanel.Visible = true;
            SetFormByState();
        }

        /// <summary>
        /// The "SetFormByState" method sets the form's state based on the current resetPasswordPhase.
        /// </summary>
        /// <remarks>
        /// This method is used to update the form's appearance and behavior based on the current phase of the password reset process.
        /// It switches between different cases of the EnumHandler.PasswordResetPhases_Enum to determine which actions to take.
        /// </remarks>
        public void SetFormByState()
        {
            switch (resetPasswordPhase)
            {
                case EnumHandler.PasswordResetPhases_Enum.UserData:
                    RestartDetails();
                    break;
                case EnumHandler.PasswordResetPhases_Enum.Smtp:
                    SmtpControl.HandleWrongCodeCase();
                    break;
                case EnumHandler.PasswordResetPhases_Enum.PasswordReset:
                    SetPasswordGeneratorControlEnable(true);
                    break;
            }
        }

        #endregion
    }
}
