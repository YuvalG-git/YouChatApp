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
    public partial class FriendRequestControl : UserControl
    {
        public FriendRequestControl()
        {
            InitializeComponent();
        }
        public event EventHandler OnFriendRequestApproval;
        public event EventHandler OnFriendRequestRefusal;
        public CircularPictureBox ProfilePicture => ProfilePictureCircularPictureBox;

        public System.Windows.Forms.Label ContactName => ChatNameLabel;

        private void AddFriendCustomButton_Click(object sender, EventArgs e)
        {
            string FriendRequestResponseContent = ChatNameLabel.Text + "#" + ServerCommunication.FriendRequestResponseSender1;
            ServerCommunication.SendMessage(ServerCommunication.FriendRequestResponseSender, FriendRequestResponseContent);
            OnFriendRequestApproval?.Invoke(this, e);


        }
        public void OnFriendRequestApprovalHandler(EventHandler handler)
        {
            OnFriendRequestApproval += handler;
        }

        private void DenyFriendRequestCustomButton_Click(object sender, EventArgs e)
        {
            string FriendRequestResponseContent = ChatNameLabel.Text + "#" + ServerCommunication.FriendRequestResponseSender2;
            ServerCommunication.SendMessage(ServerCommunication.FriendRequestResponseSender, FriendRequestResponseContent);
            OnFriendRequestRefusal?.Invoke(this, e);

        }
        public void OnFriendRequestRefusalHandler(EventHandler handler)
        {
            OnFriendRequestApproval += handler;
        }
    }
    
}
