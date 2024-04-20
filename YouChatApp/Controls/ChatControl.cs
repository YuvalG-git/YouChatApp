using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.Controls;

namespace YouChatApp
{
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            InitializeComponent();
            foreach(Control control in this.Controls)
            {
                control.Click += new System.EventHandler(this.OnControlClick);
                control.MouseEnter += new System.EventHandler(this.ChatControl_MouseEnter);
                control.MouseLeave += new System.EventHandler(this.ChatControl_MouseLeave);
            }
        }
        public CircularPictureBox ProfilePicture => ProfilePictureCircularPictureBox;

        public System.Windows.Forms.Label ChatName => ChatNameLabel;

        public System.Windows.Forms.Label LastMessageContent => LastMessageLabel;
        public System.Windows.Forms.Label LastMessageTime => TimeLabel;

        private string ChatControlMode = "Regular";
        private Color _backgroundColor = Color.Transparent;
        private Color _onFocusBackgroundColor = Color.CornflowerBlue;
        private Color _borderColor = Color.CornflowerBlue;
        private string _chatId;
        private bool firstClick = true;
        public string ChatId
        {
            get { return _chatId; }
            set
            {
                _chatId = value;
            }
        }
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
        private void TimeLabel_TextChanged(object sender, EventArgs e) //doesnt work for somereason - it update the width at the end of this?
        {
            //this.TimeLabel.Location = new System.Drawing.Point(this.Width - TimeLabel.Size.Width - 5, TimeLabel.Location.Y);
        }
        public void SetLastMessageTimeLocation()
        {
            this.TimeLabel.Location = new System.Drawing.Point(this.Width - TimeLabel.Size.Width - 5, TimeLabel.Location.Y);

        }
        public void SetToolTip()
        {
            ToolTipSetter.SetToolTip(ChatNameLabel, ToolTip);
            ToolTipSetter.SetToolTip(LastMessageLabel, ToolTip);

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics Graphics = e.Graphics;
            using (Pen BorderPen = new Pen(_onFocusBackgroundColor, 1))
            {
                this.Region = new Region(this.ClientRectangle);
                BorderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                Graphics.DrawLine(BorderPen, this.ChatNameLabel.Location.X, this.Height-1, this.Width, this.Height-1);
            }
        }

        private void ChatControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = _onFocusBackgroundColor;
        }

        private void ChatControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _backgroundColor;
        }

        private void ChatControl_Enter(object sender, EventArgs e)
        {

        }
        private void OnControlClick(object sender, EventArgs e)
        {
            this.OnClick(e);
            if (!firstClick)
                firstClick = true;
        }
        public bool GetFirstClick()
        {
            return firstClick;
        }

    }
}
