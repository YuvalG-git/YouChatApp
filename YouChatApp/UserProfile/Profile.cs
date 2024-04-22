using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.Controls;
using YouChatApp.JsonClasses;
using YouChatApp.UserAuthentication.Forms;
using YouChatApp.UserProfile;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace YouChatApp
{
    public partial class Profile : Form
    {
        private readonly ServerCommunicator serverCommunicator;

        public Profile()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            CurrentProfilePicturePictureBox.Image = ProfileDetailsHandler.ProfilePicture;
            ProfileStatusControl.setStatus(ProfileDetailsHandler.Status);
            ProfilePictureControl.AddButtonClickHandler(SetConfirmButtonEnabled);
            ProfileStatusControl.AddSaveStatusCustomButtonClickHandler(SendStatus);


            //todo to set the profile picture and the status according to the server...
            //need to also change the previous messages that have been sent after a changed profile picture
        }

        
   





        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Invoke(new Action(() => FormHandler._youChat.SetProfileButtonEnabled()));
        }

        private void ProfilePictureSelectionCustomButton_Click(object sender, EventArgs e)
        {
            SetVisuality(ProfilePictureSelectionCustomButton, StatusSelectionCustomButton);

            SettingsModeLabel.Text = "Profile Picture";
            ProfilePicturePanel.Visible = true;
            ProfileStatusControl.Visible = false;
        }

        private void StatusSelectionCustomButton_Click(object sender, EventArgs e)
        {
            SetVisuality(StatusSelectionCustomButton, ProfilePictureSelectionCustomButton);

            SettingsModeLabel.Text = "Status";
            ProfilePicturePanel.Visible = false;
            ProfileStatusControl.Visible = true;
        }
        private void SetVisuality(CustomButton selectedCustomButton, CustomButton otherCustomButton)  
        {
            selectedCustomButton.Enabled = false;
            otherCustomButton.Enabled = true;
            selectedCustomButton.BorderSize = 2;
            otherCustomButton.BorderSize = 0;
            SettingsModeLabel.Visible = true;
        }

        private void SaveProfilePictureCustomButton_Click(object sender, EventArgs e)
        {
            CurrentProfilePicturePictureBox.Image = ProfilePictureControl.ImageChosenAtTheMoment;
            SaveProfilePictureCustomButton.Enabled = false;
            string ProfilePictureId = ProfilePictureControl.GetImageNameID();
            JsonObject updateProfilePictureRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.UpdateProfilePictureRequest, ProfilePictureId);
            string updateProfilePictureRequestJson = JsonConvert.SerializeObject(updateProfilePictureRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(updateProfilePictureRequestJson);
        }


        public void SetConfirmButtonEnabled(object sender, EventArgs e)
        {
            if (ProfilePictureControl.ImageChosenAtTheMoment != null)
            {
                SaveProfilePictureCustomButton.Enabled = true;
            }
            else
            {
                SaveProfilePictureCustomButton.Enabled = false;
            }
        }
        public void SendStatus(object sender, EventArgs e)
        {
            string ProfileStatus = ProfileStatusControl.GetStatus();
            JsonObject updateProfileStatusRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.UpdateProfileStatusRequest, ProfileStatus);
            string updateProfileStatusRequestJson = JsonConvert.SerializeObject(updateProfileStatusRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(updateProfileStatusRequestJson);
        }
    }
}
