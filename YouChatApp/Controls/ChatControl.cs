using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            InitializeComponent();
        }
        public CircularPictureBox ProfilePicture => ProfilePictureCircularPictureBox;

        public System.Windows.Forms.Label ChatName => ChatNameLabel;

        public System.Windows.Forms.Label LastMessageContent => LastMessageLabel;
        public System.Windows.Forms.Label LastMessageTime => TimeLabel;

        private string ChatControlMode = "Regular";
        private void OptionalMessageOrAddUserButton_Click(object sender, EventArgs e) //todo - add (not here) a method that checks the position of the control - if it will be display in contacts list so there is no need to show it, else there is a need to check if the user is in the friend list of the user - if use button press will move to the chat with him (maybe i dont need this for this reason and pressing all over the control will lead to it), otherwise it will send him a friend request
        {
            if (ChatControlMode == "Add User")
            {
                if (MessageBox.Show("Are you sure you want to send this user a friend request?", "Friend Request Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) // maybe to show a little bit of the message
                {
                }
            }
            else if (ChatControlMode == "Message User")
            {

            }    
        }
    }
}
