﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Messaging;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.AttachedFiles;
using YouChatApp.ChatHandler;
using YouChatApp.ContactHandler;
using YouChatApp.Controls;
using YouChatApp.UserProfile;

namespace YouChatApp
{
    public partial class YouChat : Form
    {
        Profile profile;
        public static int MessageNumber = 0;
        public static int heightForMessages = 10;
        public static int heightForChats;
        public static int heightForFriendRequests = 10;
        public static int heightForContacts;

        public static int messageGap = 10;
        public static DateTime Time;
        public static int ContactChatNumber = 0;
        public static int ContactNumber = 0;
        public static int FriendRequestsNumber = 0;
        public static ResourceSet[] resourceSetArray;

        public YouChat()
        {
            InitializeComponent();
            ServerCommunication.BeginRead();
            MessageLabels = new List<Label>();
            MessageControlListOfLists = new List<List<MessageControl>>();
            ChatControlListOfContacts = new List<ChatControl>();
            ListOfFriendRequestControl = new List<FriendRequestControl>();
            MessageControlListOfLists.Add(new List<MessageControl>());
            ContactControlList = new List<ContactControl>();

            //ProfilePictureImageList.InitializeImageLists();
            SetResourceSetArray();
            ChatSearchBar.AddSearchOnClickHandler(SearchChats);
            GroupCreatorSearchBar.AddSearchOnClickHandler(SearchContacts);

            SetCustomTextBoxsPlaceHolderText();
            ServerCommunication.SendMessage(ServerCommunication.UserDetailsRequest, " ");

        }
        private void SetCustomTextBoxsPlaceHolderText()
        {
            UserIdCustomTextBox.PlaceHolderText = "YouChat ID";
            UserTaglineCustomTextBox.PlaceHolderText = "TAGLINE";
        }

        private void SetResourceSetArray()
        {
            resourceSetArray = new ResourceSet[9];
            {
                resourceSetArray[0] = Properties.Activities_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[1] = Properties.AnimalsAndNature_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[2] = Properties.Flags_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[3] = Properties.FoodAndDrink_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[4] = Properties.Objects_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[5] = Properties.People_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[6] = Properties.Smileys_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[7] = Properties.Symbols_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[8] = Properties.TravelAndPlaces_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                //maybe i can send the needed location when i send the image name... this way i wouldn't need to check all of them
                // i can send something like that: "¥2¥_43af"
            }
        }

        private string[] SeparateLettersAndNumbers(string Text)
        {
            string[] LettersAndNumbersArray = new string[2];
            for (int i = 0; i < LettersAndNumbersArray.Length; i++)
            {
                LettersAndNumbersArray[i] = "";
            }
            string Letters = "";
            string Numbers = "";

            foreach (char Character in Text)
            {
                if (char.IsLetter(Character))
                {
                    Letters += Character;
                }
                else if (char.IsDigit(Character))
                {
                    Numbers += Character;
                }
            }
            LettersAndNumbersArray[0] = Letters;
            LettersAndNumbersArray[1] = Numbers;
            return LettersAndNumbersArray;
        }
        public void SetProfilePicture()
        {
            ProfileButton.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture;
            UserIDLabel.Text += " " + UserProfile.ProfileDetailsHandler.Name + "#" + UserProfile.ProfileDetailsHandler.TagLine;
            ServerCommunication.SendMessage(ServerCommunication.FriendsProfileDetailsRequest, " ");
        }
        private void SearchChats(object sender, System.EventArgs e) //אפשר לעשות פעולה גנרית שתקבל רשימה של הcontrols והיא תהיה גנרית...
        {
            string Text = ChatSearchBar.SeacrhBar.TextContent;
            while (Text.EndsWith(" "))
            {
                Text = Text.Substring(0, Text.Length-1);
            }
            string ContactName;
            heightForChats = 0;
            if (Text.Length == 0)
            {
                foreach (ChatControl chat in ChatControlListOfContacts)
                {
                    chat.Location = new System.Drawing.Point(0, heightForChats);
                    heightForChats += chat.Height;
                    chat.Visible = true;

                }
            }
            else
            {
                foreach (ChatControl chat in ChatControlListOfContacts) //this works for every contact. maybe it would be better to create for all the contacts a control and then just view the correct ones...
                {
                    bool IsVisible = false;
                    ContactName = chat.ChatName.Text;
                    if (Text.ToLower().Contains(" "))
                    {
                        if (ContactName.ToLower().StartsWith(Text.ToLower())) //wont work because of text - should set that the text of the textbox is the text of the control or to do a method that returns the textbox text...
                        {
                            chat.Location = new System.Drawing.Point(0, heightForChats);
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
                                chat.Location = new System.Drawing.Point(0, heightForChats);
                                IsVisible = true;
                            }
                        }
                    }
                    if (IsVisible)
                    {
                        heightForChats += chat.Height;
                    }
                    chat.Visible = IsVisible;
                }
            }

        }

        public void SetChatControlListOfContacts(string ChatInformation)
        {
            //string[] ContactsInformation = ChatInformation.Split('#'); //todo check how i can allow the users to send # and more without the split activating - i thing maybe i need to put / or something before 
            //string ContactUsername;
            //string ContactLastMessageContent;
            //string ContactLastMessageTime;
            //string ContactProfilePictureID;
            //string ContactProfilePictureKind;
            //string ContactProfilePictureNumber;
            //for (int i = 0; i < ContactsInformation.Length; i++)
            //{
            //    string[] ContactDetails = ContactsInformation[i].Split('^');
            //    ContactUsername = ContactDetails[0];
            //    ContactLastMessageContent = ContactDetails[1];
            //    ContactLastMessageTime = ContactDetails[2];
            //    ContactProfilePictureID = ContactDetails[3];
            //    string[] ContactProfilePictureInformation = SeparateLettersAndNumbers(ContactProfilePictureID);
            //    ContactProfilePictureKind = ContactProfilePictureInformation[0];
            //    ContactProfilePictureNumber = ContactProfilePictureInformation[1]; // to understand how to seperate them

            //    if (ContactChatNumber == 0)
            //        heightForChats = 0;
            //    else
            //        heightForChats = this.ChatControlListOfContacts[ContactChatNumber - 1].Location.Y + this.ChatControlListOfContacts[ContactChatNumber - 1].Size.Height;
            //    this.ChatControlListOfContacts.Add(new ChatControl());
            //    this.ChatControlListOfContacts[ContactChatNumber].Location = new System.Drawing.Point(0, heightForChats);
            //    this.ChatControlListOfContacts[ContactChatNumber].Name = "ChatControlNumber:" + ContactChatNumber;
            //    this.ChatControlListOfContacts[ContactChatNumber].TabIndex = 0;
            //    this.ChatControlListOfContacts[ContactChatNumber].BackColor = SystemColors.Control;
            //    this.ChatControlListOfContacts[ContactChatNumber].ChatName.Text = ContactUsername;
            //    this.ChatControlListOfContacts[ContactChatNumber].LastMessageContent.Text = ContactLastMessageContent;
            //    this.ChatControlListOfContacts[ContactChatNumber].LastMessageTime.Text = ContactLastMessageTime;
            //    this.ChatControlListOfContacts[ContactChatNumber].Click += new System.EventHandler(this.ChatControl_Click);


            //    if (ContactProfilePictureKind == "Male")
            //    {
            //        this.ChatControlListOfContacts[ContactChatNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.MaleProfilePictureImageList.Images[ContactProfilePictureNumber];
            //    }
            //    else if (ContactProfilePictureKind == "Female")
            //    {
            //        this.ChatControlListOfContacts[ContactChatNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.FemaleProfilePictureImageList.Images[ContactProfilePictureNumber];

            //    }
            //    else if (ContactProfilePictureKind == "Animal")
            //    {
            //        this.ChatControlListOfContacts[ContactChatNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.AnimalProfilePictureImageList.Images[ContactProfilePictureNumber];


            //    }
            //    this.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
            //    this.ChatPanel.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
            //    if (this.ChatPanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            //    {
            //        Control LastControl = this.ChatPanel.Controls[this.ChatPanel.Controls.Count - 1];
            //        this.ChatPanel.ScrollControlIntoView(LastControl);
            //    }
            //    ContactChatNumber++;
            //}


            ChatManager.AddChat("Noam Sfadia", "Noam", "Noam", DateTime.Now.AddMonths(-2), ProfilePictureImageList.MaleProfilePictureImageList.Images[2],"hi");
            ChatManager.AddChat("Bill Gates", "Noam", "Noam", DateTime.Now.AddYears(-2), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");


            ChatManager.AddChat("Ben Raviv", "Noam", "Noam", DateTime.Now.AddDays(-1), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");

            ChatManager.AddChat("Alon Tamir", "Noam", "Noam", DateTime.Now.AddDays(-4), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");

            ChatManager.AddChat("Yuval Gur", "Noam", "Noam", DateTime.Now.AddHours(-2), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");
            ChatManager.AddChat("Noam Salomon", "Noam", "Noam", DateTime.Now.AddMonths(-5).AddHours(3), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");
            ChatManager.AddChat("Yonathan Gal", "Noam", "Noam", DateTime.Now.AddYears(-1), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");


            ChatManager.AddChat("Nir Spinzi", "Noam", "Noam", DateTime.Now.AddDays(-7), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");

            ChatManager.AddChat("Yotam Limor", "Noam", "Noam", DateTime.Now.AddDays(-4), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");

            ChatManager.AddChat("Yaniv Ilan", "Noam", "Noam", DateTime.Now.AddMonths(-11).AddHours(234).AddMinutes(43), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");
            ChatManager.AddChat("Ariel Shiff", "Noam", "Noam", DateTime.Now.AddHours(-3).AddMinutes(3), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");
            ChatManager.AddChat("Amir Lavi", "Noam", "Noam", DateTime.Now.AddHours(-6).AddMinutes(4), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");
            ChatManager.AddChat("Omer Drori", "Noam", "Noam", DateTime.Now.AddHours(-2).AddMinutes(-7), ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "hi");

            foreach (Chat chat in ChatManager._chats)
            {
                if (ContactChatNumber == 0)
                    heightForChats = 0;
                else
                    heightForChats = this.ChatControlListOfContacts[ContactChatNumber - 1].Location.Y + this.ChatControlListOfContacts[ContactChatNumber - 1].Size.Height;
                this.ChatControlListOfContacts.Add(new ChatControl());
                this.ChatControlListOfContacts[ContactChatNumber].Location = new System.Drawing.Point(0, heightForChats);
                this.ChatControlListOfContacts[ContactChatNumber].Name = chat._chatName;
                this.ChatControlListOfContacts[ContactChatNumber].TabIndex = 0;
                this.ChatControlListOfContacts[ContactChatNumber].ChatName.Text = chat._chatName;
                this.ChatControlListOfContacts[ContactChatNumber].LastMessageContent.Text = chat._lastMessageContent; //will need to crop it...
                this.ChatControlListOfContacts[ContactChatNumber].LastMessageTime.Text = chat.GetLastMessageTime();
                this.ChatControlListOfContacts[ContactChatNumber].SetLastMessageTimeLocation();
                this.ChatControlListOfContacts[ContactChatNumber].ProfilePicture.BackgroundImage = chat._chatProfilePicture;

                this.ChatControlListOfContacts[ContactChatNumber].Click += new System.EventHandler(this.ChatControl_Click);
                this.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
                this.ChatPanel.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
                ContactChatNumber++;

            }
            SetContactControlList();
        }
        private void SetContactControlList()
        {
            ContactManager.AddContact("Noam Sfadia", ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "I am cool", DateTime.Now, true, true, true, true, true);
            ContactManager.AddContact("Noam Salomon", ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "I am cool", DateTime.Now, true, true, true, true, true);

            ContactManager.AddContact("Alon Tamir", ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "I am cool", DateTime.Now, true, true, true, true, true);
            ContactManager.AddContact("Ben Raviv", ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "I am cool", DateTime.Now, true, true, true, true, true);
            ContactManager.AddContact("Yuval Gur", ProfilePictureImageList.MaleProfilePictureImageList.Images[2], "I am cool", DateTime.Now, true, true, true, true, true);

            foreach (Contact Contact in ContactManager.UserContacts)
            {
                if (ContactNumber == 0)
                    heightForContacts = 0;
                else
                    heightForContacts = this.ContactControlList[ContactNumber - 1].Location.Y + this.ContactControlList[ContactNumber - 1].Size.Height;
                this.ContactControlList.Add(new ContactControl());
                this.ContactControlList[ContactNumber].Location = new System.Drawing.Point(0, heightForContacts);
                this.ContactControlList[ContactNumber].Name = Contact.Name;
                this.ContactControlList[ContactNumber].TabIndex = 0;
                this.ContactControlList[ContactNumber].ContactName.Text = Contact.Name;
                this.ContactControlList[ContactNumber].ContactStatus.Text = Contact.Status;
                this.ContactControlList[ContactNumber].ProfilePicture.Image = Contact.ProfilePicture;
                this.Controls.Add(this.ContactControlList[ContactNumber]);
                this.GroupCreatorPanel.Controls.Add(this.ContactControlList[ContactNumber]);
                ContactNumber++;
            }
        }
        private void SearchContacts(object sender, System.EventArgs e)
        {

            if (this.SelectedContactsPanel.Controls.Count > 0)
            {
                GroupCreatorPanel.Location = new System.Drawing.Point(GroupCreatorPanel.Location.X, SelectedContactsPanel.Location.Y + SelectedContactsPanel.Height);
            }
            else
            {
                GroupCreatorPanel.Location = new System.Drawing.Point(GroupCreatorPanel.Location.X, SelectedContactsPanel.Location.Y);

            }
            string Text = GroupCreatorSearchBar.SeacrhBar.TextContent;
            while (Text.EndsWith(" "))
            {
                Text = Text.Substring(0, Text.Length - 1);
            }
            string ContactName;
            heightForContacts = 0;
            if (Text.Length == 0)
            {
                foreach (ContactControl Contact in ContactControlList)
                {
                    Contact.Location = new System.Drawing.Point(0, heightForContacts);
                    heightForContacts += Contact.Height;
                    Contact.Visible = true;

                }
            }
            else
            {
                foreach (ContactControl Contact in ContactControlList) //this works for every contact. maybe it would be better to create for all the contacts a control and then just view the correct ones...
                {
                    bool IsVisible = false;
                    ContactName = Contact.ContactName.Text;
                    if (Text.ToLower().Contains(" "))
                    {
                        if (ContactName.ToLower().StartsWith(Text.ToLower())) //wont work because of text - should set that the text of the textbox is the text of the control or to do a method that returns the textbox text...
                        {
                            Contact.Location = new System.Drawing.Point(0, heightForContacts);
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
                                Contact.Location = new System.Drawing.Point(0, heightForContacts);
                                IsVisible = true;
                            }
                        }
                    }
                    if (IsVisible)
                    {
                        heightForContacts += Contact.Height;
                    }
                    Contact.Visible = IsVisible;
                }
            }

        }

        private void ChatControl_Click(object sender, EventArgs e)
        {
            //ask for message history from the server in case that was the first press since logging in...
            // set contact headline details:
            string username = ((ChatControl)(sender)).ChatName.Text;
            ContactHandler.Contact contact = ContactHandler.ContactManager.GetContact(username); //will works for users only and not for groups...
            ChatHandler.Chat chat = ChatHandler.ChatManager.GetChat(username); //will works for users only and not for groups...

            CurrentChatNameLabel.Text = contact.Name;
            CurrentPictureChatPictureBox.BackgroundImage = contact.ProfilePicture;
            if (contact.OnlineProperty) //todo - handle case the user blocked those options.. //this also not true beacause i am using his property that he let us or not see if he is online and not if he really is online..
            {
                //if (contact is online == true)
                //{
                //    LastSeenOnlineLabel.Text = "Online"; //should be is online..

                //}
            }
            else
            {
                if (contact.LastSeenProperty)
                {
                    DateTime ContactLastSeenTime = contact.LastSeenTime;
                    if (ContactLastSeenTime.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        LastSeenOnlineLabel.Text = contact.LastSeenTime.ToString("yyyy-MM-dd");

                    }
                    else
                    {
                        LastSeenOnlineLabel.Text = contact.LastSeenTime.ToString("yyyy-MM-dd   HH:mm");

                    }
                }
            }
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            profile = new Profile(this);
            profile.Show();
            ProfileButton.Enabled = false;
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            if (MessageTextBox.Text != "")
            {
                string Message = MessageTextBox.Text;
                string SendMessageTime = DateTime.Now.ToString("HH:mm");
                string MessageContant = Message + "#" + SendMessageTime;
                HandleYourMessages(Message, SendMessageTime);
                ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest, MessageContant);
                //ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest + "$" + MessageContant);
                MessageTextBox.Text = "Here You Write Your Message";
                MessageTextBox.ForeColor = Color.Silver;
            }
            //else if (LoadedPicturePictureBox.BackgroundImage != null)
            //{
            //    //ServerCommunication.SendImage(ServerCommunication.sendMessageRequest + "$" + MessageContant); need to figure out how to send a message as well - not nesserally perhaps - could use the username from the server and take the time the message got to the server...

            //}

        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MessageTextBox.Text != "")
            {
                SendMessageButton.Enabled = true;
            }
            else
                SendMessageButton.Enabled = false;
        }

        //public void Message(string MessageInfo)
        //{
        //    if (MessageNumber != 0)
        //        height = this.MessageLabels[MessageNumber - 1].Location.Y + this.MessageLabels[MessageNumber - 1].Size.Height + messageGap;
        //    this.MessageLabels.Add(new System.Windows.Forms.Label());
        //    this.MessageLabels[MessageNumber].Location = new System.Drawing.Point(30, height);
        //    this.MessageLabels[MessageNumber].Name = "MessageLabelNumber:" + MessageNumber;
        //    this.MessageLabels[MessageNumber].Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177))); ;
        //    this.MessageLabels[MessageNumber].AutoSize = true;
        //    this.MessageLabels[MessageNumber].TabIndex = 0;
        //    this.MessageLabels[MessageNumber].Text = MessageInfo;
        //    this.MessageLabels[MessageNumber].BackColor = SystemColors.Control;
        //    this.Controls.Add(this.MessageLabels[MessageNumber]);
        //    this.MessagePanel.Controls.Add(this.MessageLabels[MessageNumber]);
        //    MessageNumber++;
        //    height = this.MessageLabels[MessageNumber - 1].Location.Y + this.MessageLabels[MessageNumber-1].Size.Height + messageGap;

        //    if (this.MessagePanel.Controls.Count > 0)
        //    {
        //        Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
        //        this.MessagePanel.ScrollControlIntoView(lastControl);
        //    }
        //}
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
        public void SetListOfFriendRequestControl(string ChatInformation)
        {
            string[] ContactsInformation = ChatInformation.Split('#'); //todo check how i can allow the users to send # and more without the split activating - i thing maybe i need to put / or something before 
            string ContactUsername;
            string ContactProfilePictureID;
            string ContactProfilePictureKind;
            string ContactProfilePictureNumber;
            for (int i = 0; i < ContactsInformation.Length; i++)
            {
                string[] ContactDetails = ContactsInformation[i].Split('^');
                ContactUsername = ContactDetails[0];
                ContactProfilePictureID = ContactDetails[1];
                string[] ContactProfilePictureInformation = SeparateLettersAndNumbers(ContactProfilePictureID);
                ContactProfilePictureKind = ContactProfilePictureInformation[0];
                ContactProfilePictureNumber = ContactProfilePictureInformation[1]; // to understand how to seperate them

                if (FriendRequestsNumber == 0)
                    heightForFriendRequests = 0;
                else
                    heightForFriendRequests = this.ListOfFriendRequestControl[FriendRequestsNumber - 1].Location.Y + this.ListOfFriendRequestControl[FriendRequestsNumber - 1].Size.Height;
                this.ListOfFriendRequestControl.Add(new FriendRequestControl());
                this.ListOfFriendRequestControl[FriendRequestsNumber].Location = new System.Drawing.Point(0, heightForFriendRequests);
                this.ListOfFriendRequestControl[FriendRequestsNumber].Name = "FriendRequestControlNumber:" + FriendRequestsNumber;
                this.ListOfFriendRequestControl[FriendRequestsNumber].TabIndex = 0;
                this.ListOfFriendRequestControl[FriendRequestsNumber].BackColor = SystemColors.Control;
                this.ListOfFriendRequestControl[FriendRequestsNumber].ContactName.Text = ContactUsername;
                this.ListOfFriendRequestControl[FriendRequestsNumber].OnFriendRequestApprovalHandler(HandleFriendRequestApproval);
                this.ListOfFriendRequestControl[FriendRequestsNumber].OnFriendRequestRefusalHandler(HandleFriendRequestRefusal);

                //todo - for this code i should maybe create a genric method:
                if (ContactProfilePictureKind == "Male") //need to use that when getting a user imageid - but here i just take from the contacts list - by recieving the contact object and then its profileimage property...
                {
                    this.ListOfFriendRequestControl[FriendRequestsNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.MaleProfilePictureImageList.Images[ContactProfilePictureNumber];
                }
                else if (ContactProfilePictureKind == "Female")
                {
                    this.ListOfFriendRequestControl[FriendRequestsNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.FemaleProfilePictureImageList.Images[ContactProfilePictureNumber];

                }
                else if (ContactProfilePictureKind == "Animal")
                {
                    this.ListOfFriendRequestControl[FriendRequestsNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.AnimalProfilePictureImageList.Images[ContactProfilePictureNumber];


                }
                this.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
                this.FriendRequestPanel.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
                FriendRequestsNumber++;



            }
        }
        public void HandleFriendRequestApproval(object sender, EventArgs e)
        {
            //todo -needs to remove it from the list of friend requests...
            this.ListOfFriendRequestControl.Remove((FriendRequestControl)(sender));
            //also needs to restart height
            FriendRequestsNumber--;
        }
        public void HandleFriendRequestRefusal(object sender, EventArgs e)
        {
            FriendRequestsNumber--;
        }
        public void HandleYourMessages(string MessageContent, string SendMessageTime) //maybe i should the same function just with if or something like that (to ask if name == my name...)
        {
            if (MessageNumber != 0)
                heightForMessages = this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Location.Y + this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Size.Height + messageGap;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID].Add(new MessageControl());
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Location = new System.Drawing.Point(30, heightForMessages);
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Name = "MessageControlNumber:" + MessageNumber;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].TabIndex = 0;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].BackColor = SystemColors.Control;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Username.Text = UserProfile.ProfileDetailsHandler.Name;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text = MessageContent;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Time.Text = SendMessageTime;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].ProfilePicture.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture; 

            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].SetBackColorByMessageSender();
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].SetMessageControl();
            this.Controls.Add(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber]);
            this.MessagePanel.Controls.Add(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber]);

            if (this.MessagePanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            {
                //Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
                Control LastControl = this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber];
                this.MessagePanel.ScrollControlIntoView(LastControl);
            }
            MessageNumber++;

        }
        public void HandleMessagesByOthers(string MessageInfo)
        {
            string[] MessageDetails = MessageInfo.Split('#');
            string SenderUsername = MessageDetails[0];
            string MessageContent = MessageDetails[1];
            string SendMessageTime = MessageDetails[2];
            ContactHandler.Contact SenderContact = ContactHandler.ContactManager.GetContact(SenderUsername);
            if (MessageNumber != 0)
                heightForMessages = this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Location.Y + this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Size.Height + messageGap;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID].Add(new MessageControl());
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Location = new System.Drawing.Point(30, heightForMessages);
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Name = "MessageControlNumber:" + MessageNumber;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].TabIndex = 0;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].BackColor = SystemColors.Control;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Username.Text = SenderUsername;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text = MessageContent;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Time.Text = SendMessageTime;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].ProfilePicture.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture; //shouldn't use that... should receive the user image from the contact class...
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].ProfilePicture.BackgroundImage = SenderContact.ProfilePicture;

            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].SetMessageControl();
            this.Controls.Add(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber]);
            this.MessagePanel.Controls.Add(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber]);

            if (this.MessagePanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            {
                //Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
                Control LastControl = this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber];
                this.MessagePanel.ScrollControlIntoView(LastControl);
            }
            MessageNumber++;

        }
        public void HandlePastMessages(string MessageCollection) //will be used in messages arrived from xml doc. needs to decide about symbol like # ^...
        {
            string[] MessageDetails = MessageCollection.Split('^');
            foreach (string Message in MessageDetails)
            {
                HandleMessagesByOthers(Message);
            }
        }

        private void MessageContentBuilder(string MessageContent)
        {
            if (MessageContent.Contains("€"))
            {
                string[] MessageParts = MessageContent.Split('€');
                foreach (string part in MessageParts)
                {
                    if (part.StartsWith("¥"))
                    {
                        Image EmojiImage = SearchEmojiImageInAllResources(part.Substring(1));
                        if (EmojiImage != null)
                        {
                            Bitmap bitmap = new Bitmap(EmojiImage, 20, 20);
                            Clipboard.SetDataObject(bitmap);
                            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Paste(); //will work when i switch the label to richtextbox
                            Clipboard.Clear();
                        }

                    }
                    else
                    {
                        this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text += MessageContent;
                        //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Select(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text.Length, 0);


                    }
                }


            }
            else
            {
                this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text = MessageContent;

            }
        }

        private Image SearchEmojiImageInAllResources(string ImageName)
        {
            foreach (ResourceSet ResourceSetObject in resourceSetArray)
            {
                if (ResourceSetObject != null)
                {
                    foreach (DictionaryEntry entry in ResourceSetObject)
                    {
                        string resourceName = entry.Key.ToString();
                        if (entry.Value is Image image)
                        {
                            if (resourceName == ImageName)
                            {
                                return ResourceSetObject.GetObject(resourceName) as Image;

                            }
                        }
                    }
                }
            }
            return null;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString();
        }

        //private void UserIDTextBox_Enter(object sender, EventArgs e)
        //{
        //    if (UserIDTextBox.Text == "YouChat ID")
        //    {
        //        UserIDTextBox.Text = "";
        //        UserIDTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
        //    }
        //}

        //private void UserIDTextBox_Leave(object sender, EventArgs e)
        //{
        //    if (UserIDTextBox.Text == "")
        //    {
        //        UserIDTextBox.Text = "YouChat ID";
        //        UserIDTextBox.ForeColor = Color.Silver;
        //    }
        //}

        //private void UserTagLineTextBox_Enter(object sender, EventArgs e)
        //{
        //    if (UserTagLineTextBox.Text == "TAGLINE")
        //    {
        //        UserTagLineTextBox.Text = "";
        //        UserTagLineTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
        //    }
        //}

        //private void UserTagLineTextBox_Leave(object sender, EventArgs e)
        //{
        //    if (UserTagLineTextBox.Text == "")
        //    {
        //        UserTagLineTextBox.Text = "TAGLINE";
        //        UserTagLineTextBox.ForeColor = Color.Silver;
        //    }
        //}

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
            //ServerCommunication.SendMessage(ServerCommunication.ContactInformationRequest + "$" + "Chat Information");
            ServerCommunication.SendMessage(ServerCommunication.ContactInformationRequest, "Chat Information");

        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                MessageTextBox.Text = "Here You Write Your Message";
                MessageTextBox.ForeColor = Color.Silver;
            }
            else if ((e.KeyCode == Keys.Enter) && (MessageTextBox.Text != "") && (ServerCommunication.EnterKeyPress))
            {
                string message = MessageTextBox.Text;
                //ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest + "$" + message);
                ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest, message);
                MessageTextBox.Text = "Here You Write Your Message";
                MessageTextBox.ForeColor = Color.Silver;
            }

        }

        private void ChatButton_Click(object sender, EventArgs e)
        {
            GroupCreatorBackgroundPanel.Visible = false;
            ContactManagementPanel.Visible = false;
            ChatBackgroundPanel.Visible = true;
        }
        private void NewContactCustomButton_Click(object sender, EventArgs e)
        {
            GroupCreatorBackgroundPanel.Visible = false;
            ContactManagementPanel.Visible = true;
            ChatBackgroundPanel.Visible = false;
        }

        private void NewGroupButton_Click(object sender, EventArgs e)
        {
            GroupCreatorBackgroundPanel.Visible = true;
            ContactManagementPanel.Visible = false;
            ChatBackgroundPanel.Visible = false;
        }

        private void PhotoFileButton_Click(object sender, EventArgs e)
        {
            //LoadedPictureGroupBox.Visible = true;

            //UploadedPictureOpenFileDialog.InitialDirectory = Application.StartupPath;
            //UploadedPictureOpenFileDialog.Filter = "*.png|*.png|*.jpg|*.jpg";
            //if (UploadedPictureOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    LoadedPicturePictureBox.BackgroundImage = Image.FromFile(UploadedPictureOpenFileDialog.FileName);
            //}
        }

        private void UploadedPictureRotationButton_Click(object sender, EventArgs e)
        {
            //if (LoadedPicturePictureBox.BackgroundImage != null)
            //{
            //    Bitmap RotatedPicture = new Bitmap(LoadedPicturePictureBox.BackgroundImage.Width, LoadedPicturePictureBox.BackgroundImage.Height);
            //    using (Graphics graphics = Graphics.FromImage(RotatedPicture))
            //    {
            //        graphics.TranslateTransform(RotatedPicture.Width / 2, RotatedPicture.Height / 2);
            //        graphics.RotateTransform((float)90);
            //        graphics.TranslateTransform(-RotatedPicture.Width / 2, -RotatedPicture.Height / 2);
            //        graphics.DrawImage(LoadedPicturePictureBox.BackgroundImage, new PointF(0, 0));
            //    }

            //    LoadedPicturePictureBox.BackgroundImage = RotatedPicture;
            //}
        }
        public void ChangeMessagesAppearance()
        {
            heightForMessages = 10;
            int NumberOfMessage = 0;
            foreach (List<MessageControl> MessageList in MessageControlListOfLists)
            {
                NumberOfMessage = 0;
                foreach (MessageControl Message in MessageList)
                {
                    Message.SetMessageControlTextSize();
                    if (MessageNumber != 0)
                        heightForMessages = this.MessageControlListOfLists[MessageList.Count][NumberOfMessage - 1].Location.Y + this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Size.Height + messageGap;
                    this.MessageControlListOfLists[MessageList.Count][NumberOfMessage].SetMessageControl();
                    this.MessageControlListOfLists[MessageList.Count][NumberOfMessage].Location = new System.Drawing.Point(30, heightForMessages);

                    NumberOfMessage++;
                }
            }
            //foreach (MessageControl Message in MessagePanel.Controls)
            //{

            //}
        }

        private void VideoFileButton_Click(object sender, EventArgs e)
        {

        }

        //private void RequestSender_Click(object sender, EventArgs e)
        //{
        //    string usernameId = UserIDTextBox.Text;
        //    string usernameTagLine = UserTagLineTextBox.Text;
        //    string userIdDetails = usernameId + "#" + usernameTagLine;
        //    ServerCommunication.SendMessage(ServerCommunication.FriendRequestSender, userIdDetails);
        //}

        private void ChatCustomButton_Click(object sender, EventArgs e)
        {
            GroupCreatorBackgroundPanel.Visible = false;
            ContactManagementPanel.Visible = false;
            ChatBackgroundPanel.Visible = true;
        }

        private void NewGroupCustomButton_Click(object sender, EventArgs e)
        {
            GroupCreatorBackgroundPanel.Visible = true;
            ContactManagementPanel.Visible = false;
            ChatBackgroundPanel.Visible = false;
        }

        private void FriendRequestSenderCustomButton_Click(object sender, EventArgs e)
        {
            string usernameId = UserIdCustomTextBox.Text;
            string usernameTagLine = UserTaglineCustomTextBox.Text;
            string userIdDetails = usernameId + "#" + usernameTagLine;
            ServerCommunication.SendMessage(ServerCommunication.FriendRequestSender, userIdDetails);
        }

        private void FriendRequestFields_TextChangedEvent(object sender, EventArgs e)
        {
            bool NameIdField = UserIdCustomTextBox.IsContainingValue();
            bool TagLineField = UserTaglineCustomTextBox.IsContainingValue();
            if ((NameIdField) && (TagLineField))
            {
                FriendRequestSenderCustomButton.Enabled = true;
            }
            else
            {
                FriendRequestSenderCustomButton.Enabled = false;

            }
        }

        private void GroupCreatorSearchBar_Load(object sender, EventArgs e)
        {

        }

        private void GroupCreatorCustomButton_Click(object sender, EventArgs e)
        {
            //will create a new group and refresh everything about the last group created...
        }
    }
}
