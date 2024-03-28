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
    public partial class PasswordUpdate : Form
    {
        public PasswordUpdate()
        {
            InitializeComponent();
            UpdatePasswordGeneratorControl.OnTextChangedEventHandler(UpdatePasswordFieldsChecker);

        }

        private void UpdatePasswordButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdatePasswordGeneratorControl_Load(object sender, EventArgs e)
        {

        }
        private void UpdatePasswordFieldsChecker(object sender, EventArgs e)
        {
            bool PasswordFields = UpdatePasswordGeneratorControl.DoesAllFieldsHaveValue();
            bool UsernameField = UsernameCustomTextBox.IsContainingValue();
            if ((PasswordFields) && (UsernameField))
            {
                UpdatePasswordCustomButton.Enabled = true;
            }
            else
            {
                UpdatePasswordCustomButton.Enabled = false;
            }
        }

        private void UsernameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {

        }

        private void UpdatePasswordCustomButton_Click(object sender, EventArgs e)
        {
            bool SameNewPassword = UpdatePasswordGeneratorControl.IsSamePassword();
            if (SameNewPassword)
            {
                string OldPassword = UpdatePasswordGeneratorControl.GetOldPassword();
                string NewPassword = UpdatePasswordGeneratorControl.GetNewPassword();
                string Username = UsernameCustomTextBox.TextContent;
                string UserInformation = Username + "#" + NewPassword + "#" + OldPassword;
                UpdatePasswordGeneratorControl.Enabled = false;
                UsernameCustomTextBox.Enabled = false;
                UpdatePasswordCustomButton.Enabled = false;
                ServerCommunication.SendMessage(ServerCommunication.PasswordUpdateRequest, UserInformation);
            }
            else
            {
                MessageBox.Show("Check again the provided details", "Unmatched Provided Detailds");
            }
        }
    }
}
