using Newtonsoft.Json;
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
        private readonly ServerCommunicator serverCommunicator;
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
        }

        public void SendSmtpCode(object sender, EventArgs e)
        {
            string enteredSmtpCode = SmtpControl.GetCode();
            JsonObject jsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.ResetPasswordRequest_SmtpCode, enteredSmtpCode);
            string enteredSmtpCodeJson = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(enteredSmtpCodeJson);
        }
        public void HandleSendingEmailProcess(object sender, EventArgs e)
        {
            HandleSendingEmailProcess();
        }
        private void HandleSendingEmailProcess()
        {
            string Username = UsernameCustomTextBox.TextContent;
            string Email = EmailAddressCustomTextBox.TextContent;
            SmtpDetails smtpDetails = new SmtpDetails(Username, Email);
            JsonObject smtpDetailsJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.ResetPasswordRequest_SmtpMessage, smtpDetails);
            string smtpDetailsJson = JsonConvert.SerializeObject(smtpDetailsJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(smtpDetailsJson);
        }


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

        public void HandleMatchingUsernameAndEmailAddress()
        {
            SmtpControl.HandleCode();
        }


        private void LoginReturnerCustomButton_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHandler._passwordRestart = null;
        }

        private void PasswordGeneratorControl_Load(object sender, EventArgs e)
        {

        }

        private void CodeSenderCustomButton_Click(object sender, EventArgs e)
        {
            string Username = UsernameCustomTextBox.TextContent;
            string Email = EmailAddressCustomTextBox.TextContent;
            SmtpDetails smtpDetails = new SmtpDetails(Username, Email);
            JsonObject resetPasswordRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.ResetPasswordRequest, smtpDetails);
            string resetPasswordRequestJson = JsonConvert.SerializeObject(resetPasswordRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(resetPasswordRequestJson);
        }

        private void PasswordReplacerCustomButton_Click(object sender, EventArgs e)
        {
            //if the password is good...
            string username = UsernameCustomTextBox.TextContent;
            string newPassword = PasswordGeneratorControl.NewPasswordTextContent;
            LoginDetails resetPasswordDetails = new LoginDetails(username, newPassword);
            JsonObject passwordRenewalMessageJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.PasswordRenewalMessageRequest, resetPasswordDetails);
            string passwordRenewalMessageJson = JsonConvert.SerializeObject(passwordRenewalMessageJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(passwordRenewalMessageJson);
            SetPasswordGeneratorControlEnable(false);
        }
        public void RestartDetails()
        {
            CodeSenderCustomButton.Enabled = false;
            MessageBox.Show("Your details were incorrect\nPlease Check for mistakes", "Incorrect Details");
        }
        public void HandleSuccessfulPasswordRenewal()
        {
            FormHandler._passwordRestart = null;
            this.Hide();
            this.Dispose();
        }
        public void SetPasswordGeneratorControlEnable(bool enable)
        {
            PasswordGeneratorControl.SetEnable(enable);
            PasswordReplacerCustomButton.Enabled = enable;
        }
    }
}
