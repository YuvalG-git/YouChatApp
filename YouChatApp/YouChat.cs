using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
        public static DateTime Time;
        public YouChat()
        {
            InitializeComponent();
            ServerCommunication.BeginRead();
            MessageLabels = new List<Label>();
            MessageControls = new List<MessageControl>();

            IDNameLabel.Text = ServerCommunication.name;
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            profile = new Profile(this);
            profile.Show();
            ProfileButton.Enabled = false;
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            string message = MessageTextBox.Text;
            ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest + "$" + message);
            MessageTextBox.Text = "Here You Write Your Message";
            MessageTextBox.ForeColor = Color.Silver;
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
        //public void Message2(string MessageInfo)
        //{
        //    this.MessageGroupBoxs.Add(new System.Windows.Forms.GroupBox());
        //    this.Controls.Add(this.MessageLabels[MessageNumber]);
        //    this.MessagePanel.Controls.Add(this.MessageLabels[MessageNumber]);
        //    this.MessageGroupBoxs.Add()

        //}
        public void SetProfileButtonEnabled()
        {
            ProfileButton.Enabled = true;
        }

        public void Message3(string MessageInfo)
        {
            string[] MessageDetails = MessageInfo.Split('#');
            string SenderUsername = MessageDetails[0];
            string MessageContent = MessageDetails[1];
            if (MessageNumber != 0)
                height = this.MessageControls[MessageNumber - 1].Location.Y + this.MessageControls[MessageNumber - 1].Size.Height + messageGap;
            this.MessageControls.Add(new MessageControl());
            this.MessageControls[MessageNumber].Location = new System.Drawing.Point(30, height);
            this.MessageControls[MessageNumber].Name = "MessageControlNumber:" + MessageNumber;
            this.MessageControls[MessageNumber].TabIndex = 0;
            this.MessageControls[MessageNumber].BackColor = SystemColors.Control;
            this.MessageControls[MessageNumber].Username.Text = SenderUsername;
            this.MessageControls[MessageNumber].Message.Text = MessageContent;
            this.MessageControls[MessageNumber].Time.Text = DateTime.Now.ToString("HH:mm");
            this.MessageControls[MessageNumber].SetMessageControl();
            this.Controls.Add(this.MessageControls[MessageNumber]);
            this.MessagePanel.Controls.Add(this.MessageControls[MessageNumber]);
            MessageNumber++;

            if (this.MessagePanel.Controls.Count > 0)
            {
                Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
                this.MessagePanel.ScrollControlIntoView(lastControl);
            }
        }
        private void YouChat_MouseDown(object sender, MouseEventArgs e)
        {
            if (ContactManagementPanel.Visible && !ContactManagementPanel.Bounds.Contains(e.Location))
            {
                ContactManagementPanel.Visible = false;
            }
        }

        private void NewContactButton_Click(object sender, EventArgs e)
        {
            ContactManagementPanel.Visible = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString();
        }

        private void UserIDTextBox_Enter(object sender, EventArgs e)
        {
            if (UserIDTextBox.Text == "YouChat ID")
            {
                UserIDTextBox.Text = "";
                UserIDTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void UserIDTextBox_Leave(object sender, EventArgs e)
        {
            if (UserIDTextBox.Text == "")
            {
                UserIDTextBox.Text = "YouChat ID";
                UserIDTextBox.ForeColor = Color.Silver;
            }
        }

        private void UserTagLineTextBox_Enter(object sender, EventArgs e)
        {
            if (UserTagLineTextBox.Text == "TAGLINE")
            {
                UserTagLineTextBox.Text = "";
                UserTagLineTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void UserTagLineTextBox_Leave(object sender, EventArgs e)
        {
            if (UserTagLineTextBox.Text == "")
            {
                UserTagLineTextBox.Text = "TAGLINE";
                UserTagLineTextBox.ForeColor = Color.Silver;
            }
        }

        private void MessageTextBox_Enter(object sender, EventArgs e)
        {
            if (MessageTextBox.Text == "Here You Write Your Message")
            {
                MessageTextBox.Text = "";
                MessageTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void MessageTextBox_Leave(object sender, EventArgs e)
        {
            if (MessageTextBox.Text == "")
            {
                MessageTextBox.Text = "Here You Write Your Message";
                MessageTextBox.ForeColor = Color.Silver;
            }
        }

        private void YouChat_Load(object sender, EventArgs e)
        {
            
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                MessageTextBox.Text = "Here You Write Your Message";
                MessageTextBox.ForeColor = Color.Silver;
            }
            else if ((e.KeyCode == Keys.Shift) && (MessageTextBox.Text !=""))
            {
                string message = MessageTextBox.Text;
                ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest + "$" + message);
                MessageTextBox.Text = "Here You Write Your Message";
                MessageTextBox.ForeColor = Color.Silver;
            }
        }
    }
}
