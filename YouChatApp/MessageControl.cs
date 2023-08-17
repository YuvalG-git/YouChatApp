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
        }
        public System.Windows.Forms.Label Username => UsernameLabel;
        public System.Windows.Forms.Label Message => MessageLabel;
        public System.Windows.Forms.Label Time => TimeLabel;
        public PictureBox ProfilePicture => ProfilePictureCircularPictureBox;
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
    }
}
