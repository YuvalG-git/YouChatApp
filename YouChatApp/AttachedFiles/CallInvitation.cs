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
using YouChatApp.ContactHandler;
using YouChatApp.JsonClasses;

namespace YouChatApp.AttachedFiles
{
    public partial class CallInvitation : Form
    {
        private string _friendName;
        private string _chatId;
        private readonly ServerCommunicator serverCommunicator;
        public CallInvitation(string chatId, string friendName)
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            //ServerCommunication.BeginRead();
            //Contact friendContact = ContactHandler.ContactManager.GetContact(friendName);
            //Image friendImage = friendContact.ProfilePicture;
            //FriendCircularPictureBox.Image = friendImage;
            _friendName = friendName;
            _chatId = chatId;
            ContentLabel.Text = _friendName + " is calling you";
            ContentLabel.Location = new System.Drawing.Point((FriendInformationPanel.Width - ContentLabel.Width)/2, ContentLabel.Location.Y);
        }

        private void FriendCircularPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void JoinCallCustomButton_Click(object sender, EventArgs e)
        {
            HandleOptionButtonClick(EnumHandler.CommunicationMessageID_Enum.VideoCallAcceptanceRequest);
            this.Hide();
        }


        private void DeclineCallCustomButton_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => FormHandler._youChat.EnableDirectChatFeaturesPanel()));
            HandleOptionButtonClick(EnumHandler.CommunicationMessageID_Enum.VideoCallDenialRequest);
            this.Hide();
        }

        private void MessageSenderCustomButton_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => FormHandler._youChat.HandleCallMessageSelection(_chatId)));
            this.Invoke(new Action(() => FormHandler._youChat.EnableDirectChatFeaturesPanel()));
            HandleOptionButtonClick(EnumHandler.CommunicationMessageID_Enum.VideoCallDenialRequest);
            this.Hide();
        }
        private void HandleOptionButtonClick(EnumHandler.CommunicationMessageID_Enum callResponse)
        {
            JsonObject videoCallResponseJsonObject = new JsonObject(callResponse, _chatId);
            string videoCallResponseJson = JsonConvert.SerializeObject(videoCallResponseJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(videoCallResponseJson);
        }

        private void CallInvitation_Load(object sender, EventArgs e)
        {
            JoinCallCustomButton.BorderRadius = 40;
            DeclineCallCustomButton.BorderRadius = 40;
            MessageSenderCustomButton.BorderRadius = 40;
        }
    }
}
