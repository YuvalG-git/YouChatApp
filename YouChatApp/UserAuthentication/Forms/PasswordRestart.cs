using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.UserAuthentication.Forms
{
    public partial class PasswordRestart : Form
    {
        const int RegistrationMessage = 1;
        const int LoginMessage = 2;
        const int PasswordRenewalMessage = 3;
        SmtpHandler smtpHandler;

        public PasswordRestart()
        {
            InitializeComponent();
            smtpHandler = new SmtpHandler();
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

        private void CodeCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            string text = CodeCustomTextBox.TextContent;
            if (text != "")
            {
                VerifyCustomButton.Enabled = true;
            }
            else
            {
                VerifyCustomButton.Enabled = false;

            }
        }

        private void RestartCodeCustomButton_Click(object sender, EventArgs e)
        {
            SendResetPasswordEmailThroughSmtpProtocol();
        }

        public void HandleMatchingUsernameAndEmailAddress()
        {
            SendResetPasswordEmailThroughSmtpProtocol();
            UsernameCustomTextBox.Enabled = false;
            EmailAddressCustomTextBox.Enabled = false;
            CodeLabel.Visible = true;
            CodeCustomTextBox.Visible = true;
            RestartCodeCustomButton.Visible = true;
            VerifyCustomButton.Visible = true;
        }
        private void SendResetPasswordEmailThroughSmtpProtocol()
        {
            string username = UsernameCustomTextBox.TextContent;
            string emailAddress = EmailAddressCustomTextBox.TextContent;
            smtpHandler.SendCodeToUserEmail(username, emailAddress, PasswordRenewalMessage);
        }

        private void VerifyCustomButton_Click(object sender, EventArgs e)
        {
            string EnteredSmtpCode = CodeCustomTextBox.TextContent;
            if (EnteredSmtpCode == smtpHandler.GetSmtpCode())
            {
                PasswordGeneratorControl.Visible = true;
                PasswordReplacerCustomButton.Visible = true;
            }
        }

        private void LoginReturnerCustomButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ServerCommunication._passwordRestart = null;
        }
    }
}
