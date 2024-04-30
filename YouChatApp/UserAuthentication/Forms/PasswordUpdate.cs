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
    /// <summary>
    /// The "PasswordUpdate" class represents a form for updating user passwords.
    /// </summary>
    /// <remarks>
    /// This class provides functionality for updating user passwords.
    /// It includes methods for initializing the form, checking if all required fields for updating the password have values and if the passwords match,
    /// handling the click event of the update password button to update the password,
    /// handling the successful update of the password by sending a message to the server to request an initial profile settings check,
    /// enabling or disabling the update password form controls based on the specified parameter,
    /// handling a ban by displaying the ban control with the specified ban duration and hiding the password update panel,
    /// and handling the end of a ban by hiding the ban control, showing the password update panel, and enabling the update password form controls.
    /// </remarks>
    public partial class PasswordUpdate : Form
    {
        #region Private Readonly Fields

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" is used for communicating with the server.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        #endregion

        #region Constructors

        /// <summary>
        /// The "PasswordUpdate" constructor initializes a new instance of the <see cref="PasswordUpdate"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new PasswordUpdate instance and set up its components.
        /// It initializes the server communicator instance and adds a text changed event handler to the UpdatePasswordGeneratorControl.
        /// </remarks>
        public PasswordUpdate()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            UpdatePasswordGeneratorControl.OnTextChangedEventHandler(UpdatePasswordFieldsChecker);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "UpdatePasswordFieldsChecker" method checks if all required fields for updating the password have values and if the passwords match.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if all fields in the UpdatePasswordGeneratorControl have values and if the passwords match.
        /// It also checks if the UsernameCustomTextBox contains a value.
        /// If all conditions are met, it enables the UpdatePasswordCustomButton; otherwise, it disables the button.
        /// </remarks>
        private void UpdatePasswordFieldsChecker(object sender, EventArgs e)
        {
            bool PasswordFields = UpdatePasswordGeneratorControl.DoesAllFieldsHaveValue() && UpdatePasswordGeneratorControl.IsSamePassword();
            bool UsernameField = UsernameCustomTextBox.IsContainingValue();
            if (PasswordFields && UsernameField)
            {
                UpdatePasswordCustomButton.Enabled = true;
            }
            else
            {
                UpdatePasswordCustomButton.Enabled = false;
            }
        }

        /// <summary>
        /// The "UpdatePasswordCustomButton_Click" method handles the Click event of the UpdatePasswordCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the new passwords match using the UpdatePasswordGeneratorControl.
        /// If the passwords match, it retrieves the old and new passwords along with the username, creates a PasswordUpdateDetails object,
        /// and sends a message to the server to update the password.
        /// If the passwords do not match, it shows a message box indicating the mismatch.
        /// </remarks>
        private void UpdatePasswordCustomButton_Click(object sender, EventArgs e)
        {
            bool SameNewPassword = UpdatePasswordGeneratorControl.IsSamePassword();
            if (SameNewPassword)
            {
                string OldPassword = UpdatePasswordGeneratorControl.GetOldPassword();
                string NewPassword = UpdatePasswordGeneratorControl.GetNewPassword();
                string Username = UsernameCustomTextBox.TextContent;
                PasswordUpdateDetails passwordUpdateDetails = new PasswordUpdateDetails(OldPassword, NewPassword, Username);
                SetEnable(false);

                EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.PasswordUpdateRequest;
                object messageContent = passwordUpdateDetails;
                serverCommunicator.SendMessage(messageType, messageContent);
            }
            else
            {
                MessageBox.Show("Check again the provided details", "Unmatched Provided Details");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "HandleSuccessfulPasswordUpdate" method handles the successful update of the password.
        /// </summary>
        /// <remarks>
        /// This method sends a message to the server to request an initial profile settings check after a successful password update.
        /// </remarks>
        public void HandleSuccessfulPasswordUpdate()
        {
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckRequest;
            object messageContent = null;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "SetEnable" method enables or disables the UpdatePasswordGeneratorControl, UsernameCustomTextBox, and UpdatePasswordCustomButton based on the specified parameter.
        /// </summary>
        /// <param name="enable">A boolean value indicating whether to enable (true) or disable (false) the controls.</param>
        public void SetEnable(bool enable)
        {
            UpdatePasswordGeneratorControl.Enabled = enable;
            UsernameCustomTextBox.Enabled = enable;
            UpdatePasswordCustomButton.Enabled = enable;
        }

        /// <summary>
        /// The "HandleBan" method handles a ban by displaying the BanControl with the specified ban duration and hiding the PasswordUpdatePanel.
        /// </summary>
        /// <param name="banDuration">The duration of the ban in seconds.</param>
        /// <remarks>
        /// This method is called when a user is banned. It shows the BanControl with the specified ban duration and hides the PasswordUpdatePanel to prevent the user from updating their password during the ban period.
        /// </remarks>
        public void HandleBan(double banDuration)
        {
            BanControl.Visible = true;
            BanControl.HandleBan(banDuration);
            PasswordUpdatePanel.Visible = false;
        }

        /// <summary>
        /// The "HandleBanOver" method handles the end of a ban by hiding the BanControl, showing the PasswordUpdatePanel, and enabling the UpdatePasswordGeneratorControl, UsernameCustomTextBox, and UpdatePasswordCustomButton.
        /// </summary>
        /// <remarks>
        /// This method is called when a user's ban is over. It hides the BanControl, shows the PasswordUpdatePanel, and enables the controls that were disabled during the ban, allowing the user to update their password again.
        /// </remarks>
        public void HandleBanOver()
        {
            BanControl.Visible = false;
            PasswordUpdatePanel.Visible = true;
            SetEnable(true);
        }

        #endregion
    }
}
