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
    public partial class ProfilePictureSelector : Form
    {
        private readonly ServerCommunicator serverCommunicator;
        public ProfilePictureSelector()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            ProfilePictureControl.AddButtonClickHandler(SetConfirmButtonEnabled);
        }
        public void OpenApp()
        {
            this.Hide();
            FormHandler._youChat = new YouChat();
            this.Invoke(new Action(() => FormHandler._youChat.Show()));
        }

        public void SetConfirmButtonEnabled(object sender, EventArgs e)
        {
            if (ProfilePictureControl.ImageChosenAtTheMoment != null)
            {
                ConfirmCustomButton.Enabled = true;
            }
            else
            {
                ConfirmCustomButton.Enabled = false;
            }
        }
        public void SetConfirmButtonEnabledToFalse()
        {
            ConfirmCustomButton.Enabled = false;
        }
        public void SetConfirmButtonEnabledToTrue()
        {
            ConfirmCustomButton.Enabled = true;
        }
        public void OpenStatusSelector()
        {
            this.Hide();
            FormHandler._profileStatusSelector = new ProfileStatusSelector();
            this.Invoke(new Action(() => FormHandler._profileStatusSelector.Show()));
        }

        private void ConfirmCustomButton_Click(object sender, EventArgs e)
        {
            string ProfilePictureId = ProfilePictureControl.GetImageNameID();
            JsonObject profilePictureIdJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.UploadProfilePictureRequest, ProfilePictureId);
            string profilePictureIdJson = JsonConvert.SerializeObject(profilePictureIdJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(profilePictureIdJson);
        }
    }
}

