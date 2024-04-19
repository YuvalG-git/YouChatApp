using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YouChatApp.Controls;
using YouChatApp.ContactHandler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;

namespace YouChatApp.AttachedFiles
{
    public partial class ContactSharing : Form
    {
        int LastContactControlHeightLocation = 0;
        int LastProfileControlWidthLocation = 0;
        int ProfileControlNumber = 0;
        int ContactNumber = 0;
        string SelectedUsers;
        List<string> SelectedContactsList = new List<string>();
        Image AnonymousProfile = global::YouChatApp.Properties.Resources.AnonymousProfile;
        public static string contactData;
        public ContactSharing() //can be use for sending messages from other chats as well - maybe i can send a string or int that represents the event and act accordinglly
        {
            InitializeComponent();
            ContactControlList = new List<ContactSharingControl>();
            ProfileControlList = new List<ProfileControl>();
            SearchBar.AddSearchOnClickHandler(SearchContacts);
            //passwordGeneratorControl1.OnTextChangedEventHandler(PasswordFieldsValueChecker);
            RestartContactSharing();
            SetContactControlList();
            PanelHandler.DeletePanelScrollBars(ChosenContactsPanel);
            ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y);
            ContactPanel.Size = new Size(ContactPanel.Width, ContactPanel.Height + ChosenContactsPanel.Height);

        }
        private void RestartContactSharing()
        {
            SearchBar.SeacrhBar.TextContent = "";
            SearchBar.SeacrhBar.TextContent = "Search...";
            Restart();

        }
        private void AddProfileControl(string name, Image profilePicture)
        {
            Image profilePictureTobeUsed;
            if (profilePicture != null)
            {
                profilePictureTobeUsed = profilePicture;
            }
            else
            {
                profilePictureTobeUsed = AnonymousProfile;
            }
            if (this.ChosenContactsPanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            {
                Control LastControl = this.ProfileControlList[0];
                this.ChosenContactsPanel.ScrollControlIntoView(LastControl);
            }
            else
            {
                ContactPanel.Size = new Size(ContactPanel.Width, ContactPanel.Height - ChosenContactsPanel.Height);
                RestartCustomButton.Enabled = true;
                ShareContactsCustomButton.Enabled = true;
            }
            ProfileControlList.Add(new ProfileControl());
            ProfileControlList[ProfileControlNumber].Location = new System.Drawing.Point(LastProfileControlWidthLocation, 0);
            ProfileControlList[ProfileControlNumber].Name = name;
            ProfileControlList[ProfileControlNumber].Size = new System.Drawing.Size(90, 90);
            ProfileControlList[ProfileControlNumber].TabIndex = 0;
            ProfileControlList[ProfileControlNumber].SetProfilePicture(profilePictureTobeUsed);
            ProfileControlList[ProfileControlNumber].SetUserName(name);

            ProfileControlList[ProfileControlNumber].SetToolTip();
            this.Controls.Add(this.ProfileControlList[ProfileControlNumber]);

            ChosenContactsPanel.Controls.Add(ProfileControlList[ProfileControlNumber]);
            LastProfileControlWidthLocation += ProfileControlList[ProfileControlNumber].Width + 10;
            ProfileControlNumber++;
            ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y + ChosenContactsPanel.Height);

        }
        private void RemoveProfileControl(string name)
        {
            foreach (ProfileControl profile in ProfileControlList)
            {
                if (profile.Name == name)
                {
                    ProfileControlList.Remove(profile);
                    ChosenContactsPanel.Controls.Remove(profile);
                    profile.Dispose();
                    ProfileControlNumber--;
                    break;
                }
            }
            RestartProfileControlListLocation();
            if (this.ChosenContactsPanel.Controls.Count > 0)
            {
                ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y + ChosenContactsPanel.Height);
            }
            else
            {
                ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y);
                ContactPanel.Size = new Size(ContactPanel.Width, ContactPanel.Height + ChosenContactsPanel.Height);
                RestartCustomButton.Enabled = false;
                ShareContactsCustomButton.Enabled = false;
            }

        }
        private void RemoveAllProfileControls()
        {
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.Dispose();
            }
            ProfileControlList.Clear();
            ChosenContactsPanel.Controls.Clear();
            ProfileControlNumber = 0;
            LastProfileControlWidthLocation = 0;
            ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y);
            ContactPanel.Size = new Size(ContactPanel.Width, ContactPanel.Height + ChosenContactsPanel.Height);
        }
        private void RestartProfileControlListLocation()
        {
            LastProfileControlWidthLocation = 0;
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.Location = new System.Drawing.Point(LastProfileControlWidthLocation, 0);
                LastProfileControlWidthLocation += profile.Width + 10;
            }
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
            if (this.ChosenContactsPanel.Controls.Count > 0)
            {
                ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y + ChosenContactsPanel.Height);
            }
            else
            {
                ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y);

            }
            string Text = SearchBar.SeacrhBar.TextContent;
            while (Text.EndsWith(" "))
            {
                Text = Text.Substring(0, Text.Length - 1);
            }
            string ContactName;
            LastContactControlHeightLocation = 0;
            if (Text.Length == 0)
            {
                foreach (ContactSharingControl Contact in ContactControlList)
                {
                    Contact.Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                    LastContactControlHeightLocation += Contact.Height;
                    Contact.Visible = true;

                }
            }
            else
            {
                foreach (ContactSharingControl Contact in ContactControlList) //this works for every contact. maybe it would be better to create for all the contacts a control and then just view the correct ones...
                {
                    bool IsVisible = false;
                    ContactName = Contact.ContactName.Text;
                    if (Text.ToLower().Contains(" "))
                    {
                        if (ContactName.ToLower().StartsWith(Text.ToLower())) //wont work because of text - should set that the text of the textbox is the text of the control or to do a method that returns the textbox text...
                        {
                            Contact.Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                            IsVisible = true;
                        }
                    }
                    else
                    {
                        string[] NameParts = ContactName.Split(' ');
                        foreach (string NamePart in NameParts)
                        {
                            if (NamePart.ToLower().StartsWith(Text.ToLower())) //wont work because of text - should set that the text of the textbox is the text of the control or to do a method that returns the textbox text...
                            {
                                Contact.Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                                IsVisible = true;
                            }
                        }
                    }
                    if (IsVisible)
                    {
                        LastContactControlHeightLocation += Contact.Height;
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
            foreach (Contact Contact in ContactManager.UserContacts)
            {
                if (ContactNumber != 0)
                    LastContactControlHeightLocation = this.ContactControlList[ContactNumber - 1].Location.Y + this.ContactControlList[ContactNumber - 1].Size.Height;
                this.ContactControlList.Add(new ContactSharingControl());
                this.ContactControlList[ContactNumber].Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                this.ContactControlList[ContactNumber].Name = Contact.Name;
                this.ContactControlList[ContactNumber].TabIndex = 0;
                this.ContactControlList[ContactNumber].ContactName.Text = Contact.Name;
                this.ContactControlList[ContactNumber].ProfilePicture.Image = Contact.ProfilePicture;
                this.ContactControlList[ContactNumber].ContactId = Contact.Id;

                this.ContactControlList[ContactNumber].OnCheckBoxClickAcceptedHandler(IsChecked);
                this.ContactControlList[ContactNumber].OnCheckBoxClickDeniedHandler(IsNotChecked);


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
        private void IsChecked(object sender, System.EventArgs e)
        {
            string ContactName = ((ContactSharingControl)(sender)).ContactName.Text;
            SelectedContactsList.Add(ContactName);
            Contact contact = ContactManager.GetContact(ContactName);
            Image ContactProfilePicture = contact.ProfilePicture;
            AddProfileControl(ContactName, ContactProfilePicture);
        }
        private void IsNotChecked(object sender, System.EventArgs e)
        {
            string ContactName = ((ContactSharingControl)(sender)).ContactName.Text;
            SelectedContactsList.Remove(ContactName);
            RemoveProfileControl(ContactName);
        }
        private void RestartButton_Click(object sender, System.EventArgs e)
        {
            foreach (ContactSharingControl Contact in ContactControlList)
            {
                Contact.ContactSelection.Checked = false;
            }
            ServerCommunication.SelectedContacts = 0;

        }

        private void SendButton_Click(object sender, System.EventArgs e)
        {
            string ContactNameList = "";
            foreach (ContactSharingControl Contact in ContactControlList) //maybe i need to add a function here on click on the button that will add this to a string of selected users...
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

        private void messageControl1_Load(object sender, EventArgs e)
        {

        }

        private void ChosenContactsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contactControl1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("show");
        }

        private void SendCustomButton_Click(object sender, EventArgs e)
        {
            contactData = "Contact Information:\n";
            foreach (ContactSharingControl Contact in ContactControlList) //maybe i need to add a function here on click on the button that will add this to a string of selected users...
            {
                if (Contact.ContactSelection.Checked)
                {
                    contactData += $"{Contact.ContactName.Text}#{Contact.ContactId}\n";
                }
            }
            if (contactData != "")
            {
                contactData = contactData.Substring(0, contactData.Length - 1);
                this.DialogResult = DialogResult.OK;
                MessageBox.Show(contactData);
                this.Close();
            }
        }

        private void RestartCustomButton_Click(object sender, EventArgs e)
        {
            Restart();
        }
        private void Restart()
        {
            if (ServerCommunication.SelectedContacts != 0)
            {
                foreach (ContactSharingControl Contact in ContactControlList)
                {
                    Contact.ContactSelection.Checked = false;
                }
                ServerCommunication.SelectedContacts = 0;
                RemoveAllProfileControls();
                RestartCustomButton.Enabled = false;
                ShareContactsCustomButton.Enabled = false;
            }
        }

        private void CancelCustomButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
