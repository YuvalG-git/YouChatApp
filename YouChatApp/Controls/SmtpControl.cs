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
using YouChatApp.JsonClasses;

namespace YouChatApp.Controls
{
    public partial class SmtpControl : UserControl
    {
        public event EventHandler RestartSmtpCodeCustomButtonClick;
        public event EventHandler VerifyCustomButtonClick;
        private const string sentVerificationCodeMessage = "The verification code was sent to your email";
        private const string sendRequest = "Press refresh button to send another verification code";

        public SmtpControl(/*EnumHandler.LoginForms loginFormType*/) //this is one option - second option is to set a control property that will start with login and will be able to be changed due to what i select
        {
            //controlType = loginFormType;
            InitializeComponent();
            this.SmtpCodeCustomTextBox.PlaceHolderText = "Enter Verification Code";
            SetEmailNotificationLabelLocation();
        }
        public void HandleWrongCodeCase()
        {
            EmailNotificationLabel.Text = sendRequest;
            SetEmailNotificationLabelLocation();
            RestartSmtpCodeCustomButton.Enabled = true;
            SmtpCodeCustomTextBox.TextContent = "";
        }
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
        public string GetCode()
        {
            string enteredSmtpCode = SmtpCodeCustomTextBox.TextContent;
            return enteredSmtpCode;
        }
        private void SetEmailNotificationLabelLocation()
        {
            int width = RestartSmtpCodeCustomButton.Location.X + RestartSmtpCodeCustomButton.Width - SmtpCodeCustomTextBox.Location.X;
            EmailNotificationLabel.Location = new Point(SmtpCodeCustomTextBox.Location.X + (width - EmailNotificationLabel.Width)/2, EmailNotificationLabel.Location.Y);
        }

        private void RestartSmtpCodeCustomButton_Click(object sender, EventArgs e)
        {
            SetDisabled();
            EmailNotificationLabel.Text = sentVerificationCodeMessage;
            SetEmailNotificationLabelLocation();
            RestartSmtpCodeCustomButtonClick?.Invoke(this, e);
        }
        public void AddRestartSmtpCodeCustomButtonClickHandler(EventHandler handler)
        {
            RestartSmtpCodeCustomButtonClick += handler;
        }
        public void AddVerifyCustomButtonClickHandler(EventHandler handler)
        {
            VerifyCustomButtonClick += handler;
        }
        private void VerifyCustomButton_Click(object sender, EventArgs e)
        {
            SmtpCodeCustomTextBox.Enabled = false;
            VerifyCustomButton.Enabled = false;
            RestartSmtpCodeCustomButton.Enabled = false;
            VerifyCustomButtonClick?.Invoke(this, e);

        }
        public void HandleCode() //todo - use alert the server sent the email...
        {
            EmailNotificationLabel.Visible = true;
            SmtpCodeCustomTextBox.Enabled = true;
            RestartSmtpCodeCustomButton.Enabled = true;
        }
        public void SetDisabled()
        {
            SmtpCodeCustomTextBox.TextContent = "";
            EmailNotificationLabel.Visible = false;
            SmtpCodeCustomTextBox.Enabled = false;
            VerifyCustomButton.Enabled = false;
        }
    }
}
