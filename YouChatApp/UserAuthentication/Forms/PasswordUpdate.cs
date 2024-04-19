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
using YouChatApp.JsonClasses;

namespace YouChatApp.UserAuthentication.Forms
{
    public partial class PasswordUpdate : Form
    {
        private readonly ServerCommunicator serverCommunicator;

        public PasswordUpdate()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            UpdatePasswordGeneratorControl.OnTextChangedEventHandler(UpdatePasswordFieldsChecker);
        }


        private void UpdatePasswordGeneratorControl_Load(object sender, EventArgs e)
        {

        }
        private void UpdatePasswordFieldsChecker(object sender, EventArgs e)
        {
            bool PasswordFields = UpdatePasswordGeneratorControl.DoesAllFieldsHaveValue() && UpdatePasswordGeneratorControl.IsSamePassword();
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
                JsonObject passwordUpdateDetailsJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.PasswordUpdateRequest, passwordUpdateDetails);
                string passwordUpdateDetailsJson = JsonConvert.SerializeObject(passwordUpdateDetailsJsonObject, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                serverCommunicator.SendMessage(passwordUpdateDetailsJson);
            }
            else
            {
                MessageBox.Show("Check again the provided details", "Unmatched Provided Details");
            }
        }
        public void HandleSuccessfulPasswordUpdate()
        {
            JsonObject initialProfileSettingsCheckJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckRequest, null);
            string initialProfileSettingsCheckJson = JsonConvert.SerializeObject(initialProfileSettingsCheckJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(initialProfileSettingsCheckJson);
        }
        public void SetEnable(bool enable)
        {
            UpdatePasswordGeneratorControl.Enabled = enable;
            UsernameCustomTextBox.Enabled = enable;
            UpdatePasswordCustomButton.Enabled = enable;
        }
    }
}
