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
    public partial class YouChat : Form
    {
        Profile profile;
        public static int MessageNumber = 0;
        public static int height = 10;
        public static int messageGap = 10; //לעשות שאפשר לשנות את זה  (המשתמש)

        public YouChat()
        {
            InitializeComponent();
            ServerCommunication.BeginRead();
            MessageLabels = new List<Label>();
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            profile = new Profile(this);
            profile.ShowDialog();
            ProfileButton.Enabled = false;
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            string message = MessageTextBox.Text;
            ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest + "$" + message);
            MessageTextBox.Text = "";
        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MessageTextBox.Text !="")
            {
                SendMessageButton.Enabled = true;
            }
            else
                SendMessageButton.Enabled = false;
        }

        public void Message(string MessageInfo)
        {
            if (MessageNumber != 0)
                height = this.MessageLabels[MessageNumber - 1].Location.Y + this.MessageLabels[MessageNumber - 1].Size.Height + messageGap;
            this.MessageLabels.Add(new System.Windows.Forms.Label());
            this.MessageLabels[MessageNumber].Location = new System.Drawing.Point(30, height);
            this.MessageLabels[MessageNumber].Name = "MessageLabelNumber:" + MessageNumber;
            this.MessageLabels[MessageNumber].Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177))); ;
            this.MessageLabels[MessageNumber].AutoSize = true;
            this.MessageLabels[MessageNumber].TabIndex = 0;
            this.MessageLabels[MessageNumber].Text = MessageInfo;
            this.MessageLabels[MessageNumber].BackColor = SystemColors.Control;
            this.Controls.Add(this.MessageLabels[MessageNumber]);
            this.MessagePanel.Controls.Add(this.MessageLabels[MessageNumber]);
            MessageNumber++;
            height = this.MessageLabels[MessageNumber - 1].Location.Y + this.MessageLabels[MessageNumber-1].Size.Height + messageGap;

            if (this.MessagePanel.Controls.Count > 0)
            {
                Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
                this.MessagePanel.ScrollControlIntoView(lastControl);
            }
        }

    }
}
