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
        private readonly ServerCommunicator serverCommunicator;
        private EnumHandler.PasswordResetPhases_Enum resetPasswordPhase;

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
        private SmtpDetails GetSmtpDetailsObject()
        {
            string Username = UsernameCustomTextBox.TextContent;
            bool afterFail = SmtpControl.IsAfterFail();
            string Email = EmailAddressCustomTextBox.TextContent;
            SmtpVerification smtpVerification = new SmtpVerification(Username, afterFail);
            SmtpDetails smtpDetails = new SmtpDetails(Email, smtpVerification);
            return smtpDetails;
        }
        private void HandleSendingEmailProcess()
        {
            SmtpDetails smtpDetails = GetSmtpDetailsObject();
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
            resetPasswordPhase = EnumHandler.PasswordResetPhases_Enum.Smtp;
            SmtpControl.HandleCode();
            CodeSenderCustomButton.Enabled = false;
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
            SmtpDetails smtpDetails = GetSmtpDetailsObject();
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
            string newPassword = PasswordGeneratorControl.GetNewPassword();
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
            PasswordReplacerCustomButton.Enabled = false;
        }
        public void HandleBan(double banDuration)
        {
            BanControl.Visible = true;
            BanControl.HandleBan(banDuration);
            PasswordResetPanel.Visible = false;
        }
        public void HandleBanOver()
        {
            BanControl.Visible = false;
            PasswordResetPanel.Visible = true;
            SetFormByState();
        }
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
    }
}
