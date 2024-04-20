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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YouChatApp.UserAuthentication.Forms
{
    public partial class ProfileStatusSelector : Form
    {
        private readonly ServerCommunicator serverCommunicator;

        public ProfileStatusSelector()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            ProfileStatusControl.AddSaveStatusCustomButtonClickHandler(SendStatus);

        }
        public void SendStatus(object sender, EventArgs e)
        {
            string ProfileStatus = ProfileStatusControl.GetStatus();
            JsonObject profileStatusJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.UploadStatusRequest, ProfileStatus);
            string profileStatusJson = JsonConvert.SerializeObject(profileStatusJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(profileStatusJson);
        }
        public void OpenApp()
        {
            this.Hide();
            FormHandler._youChat = new YouChat();
            this.Invoke(new Action(() => FormHandler._youChat.Show()));
        }

    }
}
