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
    public partial class SmtpControl : UserControl
    {
        EnumHandler.UserAuthentication_Enum controlType = EnumHandler.UserAuthentication_Enum.Login;
        public EnumHandler.UserAuthentication_Enum ControlType
        {
            get { return controlType; }
            set { controlType = value; }
        }
        public SmtpControl(/*EnumHandler.LoginForms loginFormType*/) //this is one option - second option is to set a control property that will start with login and will be able to be changed due to what i select
        {
            //controlType = loginFormType;
            InitializeComponent();
            this.SmtpCodeCustomTextBox.PlaceHolderText = "Enter Verification Code";
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

        private void RestartSmtpCodeCustomButton_Click(object sender, EventArgs e)
        {
            SmtpCodeCustomTextBox.TextContent = "";
            switch (controlType) //to send the message according to the form i am currently in...
            {
                case EnumHandler.UserAuthentication_Enum.Login:
                    return;
                case EnumHandler.UserAuthentication_Enum.Registration:
                    return;
                case EnumHandler.UserAuthentication_Enum.PasswordUpdate:
                    return;
                case EnumHandler.UserAuthentication_Enum.PasswordRestart:
                    return;
            }
        }

        private void VerifyCustomButton_Click(object sender, EventArgs e)
        {

        }
    }
}
