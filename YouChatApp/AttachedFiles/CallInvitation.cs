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
        string _friendName;
        public CallInvitation(string friendName)
        {
            InitializeComponent();
            //ServerCommunication.BeginRead();
            //Contact friendContact = ContactHandler.ContactManager.GetContact(friendName);
            //Image friendImage = friendContact.ProfilePicture;
            //FriendCircularPictureBox.Image = friendImage;
            _friendName = friendName;
            ContentLabel.Text = _friendName + "is calling you";
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
    }
}
