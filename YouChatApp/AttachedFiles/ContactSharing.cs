using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace YouChatApp.AttachedFiles
{
    public partial class ContactSharing : Form
    {
        int LastContactControlHeightLocation = 20;
        int ContactNumber = 0;
        public ContactSharing()
        {
            InitializeComponent();
            ContactControlList = new List<ContactControl>();
            SetContactControlList();
        }
        private void SetContactControlList()
        {
            //foreach()
            for (ContactNumber = 0; ContactNumber<6; ContactNumber++)
            {
                if (ContactNumber != 0)
                    LastContactControlHeightLocation = this.ContactControlList[ContactNumber - 1].Location.Y + this.ContactControlList[ContactNumber - 1].Size.Height + 10;
                this.ContactControlList.Add(new ContactControl());
                this.ContactControlList[ContactNumber].Location = new System.Drawing.Point(30, LastContactControlHeightLocation);
                this.ContactControlList[ContactNumber].Name = "ContactControlNumber:" + ContactNumber;
                this.ContactControlList[ContactNumber].TabIndex = 0;
                this.ContactControlList[ContactNumber].BackColor = SystemColors.Control;
                this.ContactControlList[ContactNumber].ContactName.Text += ContactNumber;

                this.Controls.Add(this.ContactControlList[ContactNumber]);
                this.ContactPanel.Controls.Add(this.ContactControlList[ContactNumber]);

                if (this.ContactPanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
                {
                    //Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
                    Control LastControl = this.ContactControlList[ContactNumber];
                    this.ContactPanel.ScrollControlIntoView(LastControl);
                }
                //ContactNumber++;

            }

        }

        private void RestartButton_Click(object sender, System.EventArgs e)
        {
            foreach (ContactControl Contact in ContactControlList)
            {
                Contact.ContactSelection.Checked = false;
            }
            ServerCommunication.SelectedContacts = 0;

        }

        private void SendButton_Click(object sender, System.EventArgs e)
        {
            string ContactNameList = "";
            foreach (ContactControl Contact in ContactControlList)
            {
                if (Contact.ContactSelection.Checked)
                {
                    ContactNameList += Contact.ContactName.Text + "#";
                }
            }
            if (ContactNameList != "")
            {
                ContactNameList += DateTime.Now.ToString("HH:mm");
                //ServerCommunication.SendMessage(ServerCommunication.SendContactMessage + "$" + ContactNameList);
                MessageBox.Show(ContactNameList);
            }
        }
    }
}
