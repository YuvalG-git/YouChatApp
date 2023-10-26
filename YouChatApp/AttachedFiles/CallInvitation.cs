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

namespace YouChatApp.AttachedFiles
{
    public partial class CallInvitation : Form
    {
        private string _friendName;
        public CallInvitation(string friendName)
        {
            InitializeComponent();
            //ServerCommunication.BeginRead();
            //Contact friendContact = ContactHandler.ContactManager.GetContact(friendName);
            //Image friendImage = friendContact.ProfilePicture;
            //FriendCircularPictureBox.Image = friendImage;
            _friendName = friendName;
            ContentLabel.Text = _friendName + " is calling you";
            ContentLabel.Location = new System.Drawing.Point((FriendInformationPanel.Width - ContentLabel.Width)/2, ContentLabel.Location.Y);
        }

        private void FriendCircularPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void JoinCallCustomButton_Click(object sender, EventArgs e)
        {
            HandleOptionButtonClick(ServerCommunication.VideoCallResponseResult1);
            ServerCommunication._videoCall = new VideoCall();
            this.Invoke(new Action(() => ServerCommunication._videoCall.Show()));
        }

        private void DeclineCallCustomButton_Click(object sender, EventArgs e)
        {
            HandleOptionButtonClick(ServerCommunication.VideoCallResponseResult2);
        }

        private void MessageSenderCustomButton_Click(object sender, EventArgs e)
        {
            HandleOptionButtonClick(ServerCommunication.VideoCallResponseResult2);
            //needs to send a message as well
        }
        private void HandleOptionButtonClick(string messageInformation)
        {
            string messageContent = messageInformation + "#" + _friendName;
            ServerCommunication.SendMessage(ServerCommunication.VideoCallResponseSender, messageContent);
        }

        private void CallInvitation_Load(object sender, EventArgs e)
        {
            JoinCallCustomButton.BorderRadius = 40;
            DeclineCallCustomButton.BorderRadius = 40;
            MessageSenderCustomButton.BorderRadius = 40;

        }
    }
}
