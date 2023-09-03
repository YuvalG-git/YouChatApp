using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    public partial class MessageControl : UserControl
    {
        public MessageControl()
        {
            InitializeComponent();
            SetMessageControlTextSize();
        }
        public System.Windows.Forms.Label Username => UsernameLabel;
        public System.Windows.Forms.Label Message => MessageLabel;
        public System.Windows.Forms.Label Time => TimeLabel;
        public PictureBox ProfilePicture => ProfilePictureCircularPictureBox;

        public float CurrentUsernameLabelTextSize = 12F;
        public float CurrentNessageLabelTextSize = 15.75F;

        public void SetMessageControl()
        {
            int MessageControlToMessageLabelWidth = MessageLabel.Location.X - this.Location.X;
            int NewWidth = MessageLabel.Width + MessageControlToMessageLabelWidth + 10;
            if (NewWidth > this.Width)
            {
                this.Width = NewWidth;
                int TimeLabelYCoordination = MessageLabel.Height + MessageLabel.Location.Y + 5;
                int TimeLabelXCoordination = MessageLabel.Width + MessageLabel.Location.X - TimeLabel.Width + 5;
                TimeLabel.Location = new System.Drawing.Point(TimeLabelXCoordination, TimeLabelYCoordination);
                this.Height = TimeLabel.Height + TimeLabel.Location.Y + 10;
                this.Size = new System.Drawing.Size(this.Width, this.Height);
            }




        }
        //todo make sure that this function isnt on a specific control of this type...
        public void SetMessageControlTextSize()//לשנות גם את הגודל של הcontrol עצמו בהתאם...
        {
            if (ServerCommunication.SelectedMessageTextSize == 0)
            {
                CurrentUsernameLabelTextSize = 9F;
                CurrentNessageLabelTextSize = 11.00F;

            }
            else if (ServerCommunication.SelectedMessageTextSize == 1)
            {
                CurrentUsernameLabelTextSize = 10.5F;
                CurrentNessageLabelTextSize = 13.25F;
            }
            else if (ServerCommunication.SelectedMessageTextSize == 2)
            {
                CurrentUsernameLabelTextSize = 12F;
                CurrentNessageLabelTextSize = 15.75F;
            }
            else if (ServerCommunication.SelectedMessageTextSize == 3)
            {
                CurrentUsernameLabelTextSize = 14F;
                CurrentNessageLabelTextSize = 18.25F;
            }
            else 
            {
                CurrentUsernameLabelTextSize = 16F;
                CurrentNessageLabelTextSize = 21.75F;
            }
            this.UsernameLabel.Font = new System.Drawing.Font(this.UsernameLabel.Font.Name, CurrentUsernameLabelTextSize, this.UsernameLabel.Font.Style, this.UsernameLabel.Font.Unit);
            this.MessageLabel.Font = new System.Drawing.Font(this.MessageLabel.Font.Name, CurrentNessageLabelTextSize, this.MessageLabel.Font.Style, this.MessageLabel.Font.Unit);


        }
        public void SetBackColorByMessageSender()
        {
            this.BackColor = Color.MediumSeaGreen;
        }
    }
}
