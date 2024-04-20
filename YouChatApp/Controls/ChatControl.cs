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
        public CircularPictureBox ProfilePicture => ProfilePicturePictureBox;

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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ChatNameLabel = new System.Windows.Forms.Label();
            this.LastMessageLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.OptionalMessageOrAddUserButton = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ProfilePicturePictureBox = new YouChatApp.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicturePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChatNameLabel
            // 
            this.ChatNameLabel.AutoEllipsis = true;
            this.ChatNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatNameLabel.Location = new System.Drawing.Point(80, 15);
            this.ChatNameLabel.MaximumSize = new System.Drawing.Size(165, 22);
            this.ChatNameLabel.MinimumSize = new System.Drawing.Size(165, 22);
            this.ChatNameLabel.Name = "ChatNameLabel";
            this.ChatNameLabel.Size = new System.Drawing.Size(165, 22);
            this.ChatNameLabel.TabIndex = 1;
            this.ChatNameLabel.Text = "Name";
            // 
            // LastMessageLabel
            // 
            this.LastMessageLabel.AutoEllipsis = true;
            this.LastMessageLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastMessageLabel.Location = new System.Drawing.Point(81, 44);
            this.LastMessageLabel.MaximumSize = new System.Drawing.Size(175, 17);
            this.LastMessageLabel.MinimumSize = new System.Drawing.Size(175, 17);
            this.LastMessageLabel.Name = "LastMessageLabel";
            this.LastMessageLabel.Size = new System.Drawing.Size(175, 17);
            this.LastMessageLabel.TabIndex = 2;
            this.LastMessageLabel.Text = "Last Message";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(260, 15);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(36, 14);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = "Time";
            this.TimeLabel.TextChanged += new System.EventHandler(this.TimeLabel_TextChanged);
            // 
            // OptionalMessageOrAddUserButton
            // 
            this.OptionalMessageOrAddUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionalMessageOrAddUserButton.Location = new System.Drawing.Point(279, 54);
            this.OptionalMessageOrAddUserButton.Name = "OptionalMessageOrAddUserButton";
            this.OptionalMessageOrAddUserButton.Size = new System.Drawing.Size(33, 23);
            this.OptionalMessageOrAddUserButton.TabIndex = 4;
            this.OptionalMessageOrAddUserButton.UseVisualStyleBackColor = true;
            this.OptionalMessageOrAddUserButton.Visible = false;
            this.OptionalMessageOrAddUserButton.Click += new System.EventHandler(this.OptionalMessageOrAddUserButton_Click);
            // 
            // ProfilePicturePictureBox
            // 
            this.ProfilePicturePictureBox.BackgroundImage = global::YouChatApp.Properties.Resources.AnonymousProfile;
            this.ProfilePicturePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfilePicturePictureBox.BorderColor = System.Drawing.Color.Gray;
            this.ProfilePicturePictureBox.BorderSize = 1;
            this.ProfilePicturePictureBox.HasBorder = false;
            this.ProfilePicturePictureBox.Location = new System.Drawing.Point(10, 10);
            this.ProfilePicturePictureBox.Name = "ProfilePicturePictureBox";
            this.ProfilePicturePictureBox.Size = new System.Drawing.Size(60, 60);
            this.ProfilePicturePictureBox.TabIndex = 6;
            this.ProfilePicturePictureBox.TabStop = false;
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProfilePicturePictureBox);
            this.Controls.Add(this.OptionalMessageOrAddUserButton);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.LastMessageLabel);
            this.Controls.Add(this.ChatNameLabel);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(315, 80);
            this.Enter += new System.EventHandler(this.ChatControl_Enter);
            this.MouseEnter += new System.EventHandler(this.ChatControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ChatControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicturePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
