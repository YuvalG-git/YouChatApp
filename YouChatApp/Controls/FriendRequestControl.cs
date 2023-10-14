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
            foreach (Control control in this.Controls)
            {
                control.MouseEnter += new System.EventHandler(this.FriendRequestControl_MouseEnter);
                control.MouseLeave += new System.EventHandler(this.FriendRequestControl_MouseLeave);
            }
        }
        public event EventHandler OnFriendRequestApproval;
        public event EventHandler OnFriendRequestRefusal;
        private Color _backgroundColor = Color.Transparent;
        private Color _onFocusBackgroundColor = Color.CornflowerBlue;
        private Color _borderColor = Color.CornflowerBlue;
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                this.Invalidate();
            }
        }
        public Color OnFocusBackgroundColor
        {
            get { return _onFocusBackgroundColor; }
            set
            {
                _onFocusBackgroundColor = value;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics Graphics = e.Graphics;
            using (Pen BorderPen = new Pen(_onFocusBackgroundColor, 1))
            {
                this.Region = new Region(this.ClientRectangle);
                BorderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                Graphics.DrawLine(BorderPen, this.ChatNameLabel.Location.X, this.Height - 1, this.Width, this.Height - 1);
            }
        }
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

        private void FriendRequestControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundColor = _onFocusBackgroundColor;
        }

        private void FriendRequestControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundColor = _backgroundColor;

        }
    }
    
}
