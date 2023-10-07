using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YouChatApp.Controls;
using YouChatApp.ContactHandler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace YouChatApp.AttachedFiles
{
    public partial class ContactSharing : Form
    {
        int LastContactControlHeightLocation = 0;
        int ContactNumber = 0;
        string SelectedUsers;
        List<string> SelectedContactsList = new List<string>();
        public ContactSharing() //can be use for sending messages from other chats as well - maybe i can send a string or int that represents the event and act accordinglly
        {
            InitializeComponent();
            ContactControlList = new List<ContactControl>();
            SearchBar.AddSearchOnClickHandler(SearchContacts);
            //passwordGeneratorControl1.OnTextChangedEventHandler(PasswordFieldsValueChecker);
            //messageControl1.SetMessageControl();

            SetContactControlList();
        }
        private void SearchContacts(object sender, System.EventArgs e)
        {
            //foreach(Contact Contact in ContactManager.UserContacts) //this works for every contact. maybe it would be better to create for all the contacts a control and then just view the correct ones...
            //{
            //    string[] NameParts = Contact.Name.Split(' ');
            //    foreach (string NamePart in NameParts)
            //    {
            //        if (SearchBar.TextContent.StartsWith(NamePart)) //wont work because of text - should set that the text of the textbox is the text of the control or to do a method that returns the textbox text...
            //        { 

            //        }
            //    }
            //}
            string Text = SearchBar.SeacrhBar.TextContent;
            LastContactControlHeightLocation = 0;
            if (Text.Length == 0)
            {
                foreach (ContactControl Contact in ContactControlList)
                {
                    Contact.Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                    LastContactControlHeightLocation += Contact.Height + 10;
                    Contact.Visible = true;

                }
            }
            else
            {
                foreach (ContactControl Contact in ContactControlList) //this works for every contact. maybe it would be better to create for all the contacts a control and then just view the correct ones...
                {
                    string[] NameParts = Contact.ContactName.Text.Split(' ');
                    bool IsVisible = false;
                    foreach (string NamePart in NameParts)
                    {
                        if (NamePart.ToLower().StartsWith(Text.ToLower())) //wont work because of text - should set that the text of the textbox is the text of the control or to do a method that returns the textbox text...
                        {
                            Contact.Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                            IsVisible = true;
                        }
                    }
                    if (IsVisible)
                    {
                        LastContactControlHeightLocation += Contact.Height + 10;
                    }
                    Contact.Visible = IsVisible;
                }
            }
          
        }
        //private void PasswordFieldsValueChecker(object sender, EventArgs e)
        //{
        //    if (passwordGeneratorControl1.DoesAllFieldsHaveValue())
        //    {
        //        SendButton.Enabled = true;
        //    }
        //    else
        //    {
        //        SendButton.Enabled = false;

        //    }
        //}



        private void SetContactControlList()
        {
            ContactHandler.ContactManager.AddContact("bett");
            ContactHandler.ContactManager.AddContact("tai");

            ContactHandler.ContactManager.AddContact("adolf");
            ContactHandler.ContactManager.AddContact("greg");
            ContactHandler.ContactManager.AddContact("denis");

            foreach (Contact Contact in ContactManager.UserContacts)
            {
                if (ContactNumber != 0)
                    LastContactControlHeightLocation = this.ContactControlList[ContactNumber - 1].Location.Y + this.ContactControlList[ContactNumber - 1].Size.Height + 10;
                this.ContactControlList.Add(new ContactControl());
                this.ContactControlList[ContactNumber].Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                this.ContactControlList[ContactNumber].Name = Contact.Name;
                this.ContactControlList[ContactNumber].TabIndex = 0;
                this.ContactControlList[ContactNumber].BackColor = SystemColors.Control;
                this.ContactControlList[ContactNumber].ContactName.Text = Contact.Name;
                this.ContactControlList[ContactNumber].OnCheckBoxCheckedChangedHandler(CheckedChanged);

                this.Controls.Add(this.ContactControlList[ContactNumber]);
                this.ContactPanel.Controls.Add(this.ContactControlList[ContactNumber]);
                ContactNumber++;
            }
            //for (ContactNumber = 0; ContactNumber<4; ContactNumber++)
            //{
            //    if (ContactNumber != 0)
            //        LastContactControlHeightLocation = this.ContactControlList[ContactNumber - 1].Location.Y + this.ContactControlList[ContactNumber - 1].Size.Height + 10;
            //    this.ContactControlList.Add(new ContactControl());
            //    this.ContactControlList[ContactNumber].Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
            //    this.ContactControlList[ContactNumber].Name = "4ContactControlNumber:" + ContactNumber;
            //    this.ContactControlList[ContactNumber].TabIndex = 0;
            //    this.ContactControlList[ContactNumber].BackColor = SystemColors.Control;
            //    this.ContactControlList[ContactNumber].ContactName.Text += ContactNumber;
            //    this.Controls.Add(this.ContactControlList[ContactNumber]);
            //    this.ContactPanel.Controls.Add(this.ContactControlList[ContactNumber]);

            //}

        }
        private void CheckedChanged(object sender, System.EventArgs e)
        {
            //if (sender is ContactControl)
            //{
            //    Contact c = ((object)(sender));
            //    SelectedContactsList.Add();

            //}
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
            foreach (ContactControl Contact in ContactControlList) //maybe i need to add a function here on click on the button that will add this to a string of selected users...
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

        private void SearchBar_Load(object sender, EventArgs e)
        {

        }
    }
}
