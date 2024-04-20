using Spire.Pdf.Exporting.XPS.Schema;
using System;
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
using System.Xml.Linq;
using YouChatApp.AttachedFiles;
using YouChatApp.ChatHandler;
using YouChatApp.ContactHandler;
using YouChatApp.Controls;
using YouChatApp.UserProfile;
using Newtonsoft.Json;
using System.IO;
using YouChatApp.JsonClasses;
using YouChatApp.ChatHandler2;
using ChatManager = YouChatApp.ChatHandler.ChatManager;
using GroupChat = YouChatApp.ChatHandler.GroupChat;
using ChatCreator = YouChatApp.ChatHandler.ChatCreator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        public static int widthForProfileControl = 0;
        private bool _firstTimeEnteringFriendRequestZone = true;
        Image AnonymousProfile = global::YouChatApp.Properties.Resources.AnonymousProfile; //need to change that to my profile picture...
        ChatCreator newChat;
        public static int messageGap = 10;
        public static DateTime Time;
        public static int ContactChatNumber = 0;
        public static int ContactNumber = 0;
        public static int profileControlNumber = 0;
        public static int FriendRequestsNumber = 0;
        public static ResourceSet[] resourceSetArray;
        private readonly ServerCommunicator serverCommunicator;
        Panel currentMessagePanel;
        Dictionary<string, int> messageCount;
        string currentChatId = "";
        EnumHandler.ChatType_Enum currentChatType;
        public YouChat()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            serverCommunicator.CheckSocketStatus();
            //serverCommunicator.BeginRead();
            MessageLabels = new List<Label>();
            MessageControlListOfLists = new List<List<MessageControl>>();
            ChatControlListOfContacts = new List<ChatControl>();
            ListOfFriendRequestControl = new List<FriendRequestControl>();
            MessageControlListOfLists.Add(new List<MessageControl>());
            ContactControlList = new List<ContactControl>();
            ProfileControlList = new List<ProfileControl>();
            MessagePanels = new Dictionary<string,Panel>();
            messageCount = new Dictionary<string, int>();
            MessageControls = new Dictionary<string, List<MessageControl>>();
            AdvancedMessageControls = new Dictionary<string, List<AdvancedMessageControl>>();
            //ProfilePictureImageList.InitializeImageLists();
            SetResourceSetArray();
            ChatSearchBar.AddSearchOnClickHandler(SearchChats);
            GroupCreatorSearchBar.AddSearchOnClickHandler(SearchContacts);

            SetCustomTextBoxsPlaceHolderText();
            JsonObject userDetailsRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.UserDetailsRequest, null);
            string userDetailsRequestJson = JsonConvert.SerializeObject(userDetailsRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(userDetailsRequestJson);

            PanelHandler.DeletePanelScrollBars(SelectedContactsPanel);
            PanelHandler.DeletePanelHorizontalScrollBar(GroupCreatorPanel);
            PanelHandler.DeletePanelHorizontalScrollBar(FriendRequestIdPanel);

            GroupCreatorPanel.Location = new System.Drawing.Point(GroupCreatorPanel.Location.X, SelectedContactsPanel.Location.Y);
            GroupCreatorPanel.Size = new Size(GroupCreatorPanel.Width, GroupCreatorPanel.Height + SelectedContactsPanel.Height);
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
        public void OnEmojiPress(object sender, PictureBoxEventArgs e)
        {
            PictureBox EmojiPictureBox = e.pictureBox;
            Image EmojiImage = EmojiPictureBox.Image;
            MessageRichTextBox.Select(MessageRichTextBox.Text.Length, 0);

            int IndexToAdd = MessageRichTextBox.SelectionStart;
            MessageImage messageImage = new MessageImage();
            Image ResizedImage = EmojiImage;
            Bitmap bitmap = new Bitmap(ResizedImage, 20, 20);
            Clipboard.SetDataObject(bitmap);
            messageImage.EmojiImage = EmojiImage;
            messageImage.ImageName = EmojiPictureBox.Name;
            messageImage.OnRichTextBoxImage = Clipboard.GetImage();
            MessageRichTextBox.Paste(); //the paste does " "
            Clipboard.Clear();

            if (MessageRichTextBox.Text[IndexToAdd] == ' ')
            {
                MessageRichTextBox.Text.Remove(IndexToAdd, 0);

            }
            pictureBox1.BackgroundImage = EmojiImage;
            // Do something with the background image here
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
            ProfileCustomButton.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture;

            UserIDLabel.Text += " " + UserProfile.ProfileDetailsHandler.Name + "#" + UserProfile.ProfileDetailsHandler.TagLine;
            JsonObject contactInformationRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.ContactInformationRequest, null);

            //JsonObject contactInformationRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.ChatAndContactDetailsRequest, null);
            string contactInformationRequestJson = JsonConvert.SerializeObject(contactInformationRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(contactInformationRequestJson);
            //ServerCommunication.SendMessage(ServerCommunication.FriendsProfileDetailsRequest, " ");
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
            PanelHandler.SetPanelToSide(ChatPanel, ChatControlListOfContacts, true);

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

        public void SetChatControlListOfContacts()
        {
            foreach (ChatDetails chat in ChatManager._chats)
            {
                AddChatControl(chat);
                //string chatName = "";
                //string chatId = chat.ChatTagLineId;
                //Image chatProfilePicture = null;
                //if (chat is DirectChat directChat)
                //{
                //    chatName = directChat.Contact.Name;
                //    chatProfilePicture = directChat.Contact.ProfilePicture;
                //}
                //else if (chat is GroupChat groupChat)
                //{
                //    chatName = groupChat.ChatName;
                //    chatProfilePicture = groupChat.ChatProfilePicture;
                //}
                //if (ContactChatNumber == 0)
                //    heightForChats = 0;
                //else
                //    heightForChats = this.ChatControlListOfContacts[ContactChatNumber - 1].Location.Y + this.ChatControlListOfContacts[ContactChatNumber - 1].Size.Height;
                //this.ChatControlListOfContacts.Add(new ChatControl());
                //this.ChatControlListOfContacts[ContactChatNumber].Location = new System.Drawing.Point(0, heightForChats);
                //this.ChatControlListOfContacts[ContactChatNumber].Name = chatName;
                //this.ChatControlListOfContacts[ContactChatNumber].ChatId = chatId;
                //this.ChatControlListOfContacts[ContactChatNumber].TabIndex = 0;
                //this.ChatControlListOfContacts[ContactChatNumber].ChatName.Text = chatName;
                //this.ChatControlListOfContacts[ContactChatNumber].LastMessageContent.Text = chat.LastMessageContent; //will need to crop it...
                //this.ChatControlListOfContacts[ContactChatNumber].LastMessageTime.Text = chat.GetLastMessageTime();
                //this.ChatControlListOfContacts[ContactChatNumber].SetLastMessageTimeLocation();
                //this.ChatControlListOfContacts[ContactChatNumber].SetToolTip();
                //this.ChatControlListOfContacts[ContactChatNumber].ProfilePicture.BackgroundImage = chatProfilePicture;
                //this.ChatControlListOfContacts[ContactChatNumber].Click += new System.EventHandler(this.ChatControl_Click);
                //this.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
                //this.ChatPanel.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
                //ContactChatNumber++;
            }
        }

        public void SetContactControlList(List<ContactDetails> contactDetailsList)
        {       
            Contact contact;
            foreach (ContactDetails contactDetails in contactDetailsList)
            {
                contact = new Contact(contactDetails);
                ContactManager.AddContact(contact);
            }

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
                this.ContactControlList[ContactNumber].Click += new EventHandler(this.ContactControl_Click);
                this.Controls.Add(this.ContactControlList[ContactNumber]);
                this.GroupCreatorPanel.Controls.Add(this.ContactControlList[ContactNumber]);
                ContactNumber++;
            }
        }


        public void HandleSuccessfulFriendRequest(Contact contact, ChatDetails chat)
        {
            int location = ContactManager.UserContacts.IndexOf(contact);
            if (this.ContactControlList.Count == 0)
            {
                heightForContacts = 0;
            }
            else
            {
                heightForContacts = this.ContactControlList[location].Location.Y;
            }
            if (location >= 0)
            {
                this.ContactControlList.Insert(location,new ContactControl());
                this.ContactControlList[location].Location = new System.Drawing.Point(0, heightForContacts);
                this.ContactControlList[location].Name = contact.Name;
                this.ContactControlList[location].TabIndex = 0;
                this.ContactControlList[location].ContactName.Text = contact.Name;
                this.ContactControlList[location].ContactStatus.Text = contact.Status;
                this.ContactControlList[location].ProfilePicture.Image = contact.ProfilePicture;
                this.ContactControlList[location].Click += new EventHandler(this.ContactControl_Click);
                this.Controls.Add(this.ContactControlList[location]);
                this.GroupCreatorPanel.Controls.Add(this.ContactControlList[location]);
                ContactNumber++;
            }
            for (int i = location + 1; i < ContactControlList.Count; i++)
            {
                heightForContacts = this.ContactControlList[i - 1].Location.Y + this.ContactControlList[i - 1].Size.Height;
                this.ContactControlList[i].Location = new System.Drawing.Point(0, heightForContacts);
            }
            AddChatControl(chat);
        }
        public void HandleNewGroupChatCreation(ChatDetails chat)
        {
            AddChatControl(chat);
        }
        private void AddChatControl(ChatDetails chat)
        {
            string chatName = "";
            string chatId = chat.ChatTagLineId;
            Image chatProfilePicture = null;
            if (chat is DirectChat directChat)
            {
                chatName = directChat.Contact.Name;
                chatProfilePicture = directChat.Contact.ProfilePicture;
            }
            else if (chat is GroupChat groupChat)
            {
                chatName = groupChat.ChatName;
                chatProfilePicture = groupChat.ChatProfilePicture;
            }
            if (ContactChatNumber == 0)
                heightForChats = 0;
            else
                heightForChats = this.ChatControlListOfContacts[ContactChatNumber - 1].Location.Y + this.ChatControlListOfContacts[ContactChatNumber - 1].Size.Height;
            this.ChatControlListOfContacts.Add(new ChatControl());
            this.ChatControlListOfContacts[ContactChatNumber].Location = new System.Drawing.Point(0, heightForChats);
            this.ChatControlListOfContacts[ContactChatNumber].Name = chatName;
            this.ChatControlListOfContacts[ContactChatNumber].ChatId = chatId;
            this.ChatControlListOfContacts[ContactChatNumber].TabIndex = 0;
            this.ChatControlListOfContacts[ContactChatNumber].ChatName.Text = chatName;
            this.ChatControlListOfContacts[ContactChatNumber].LastMessageContent.Text = chat.GetLastMessageData();
            this.ChatControlListOfContacts[ContactChatNumber].LastMessageTime.Text = chat.GetLastMessageTime();
            this.ChatControlListOfContacts[ContactChatNumber].SetLastMessageTimeLocation();
            this.ChatControlListOfContacts[ContactChatNumber].SetToolTip();
            this.ChatControlListOfContacts[ContactChatNumber].ProfilePicture.BackgroundImage = chatProfilePicture;
            this.ChatControlListOfContacts[ContactChatNumber].Click += new System.EventHandler(this.ChatControl_Click);
            this.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
            this.ChatPanel.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
            ContactChatNumber++;

            this.MessagePanels.Add(chatId, new Panel());
            this.MessagePanels[chatId].AutoScroll = true;
            this.MessagePanels[chatId].Location = new System.Drawing.Point(365, 95);
            this.MessagePanels[chatId].Name = "PanelId" + chatId;
            this.MessagePanels[chatId].Size = new System.Drawing.Size(1402, 775);
            this.MessagePanels[chatId].TabIndex = 8;
            this.MessagePanels[chatId].Visible = false;
            this.Controls.Add(this.MessagePanels[chatId]);

            messageCount.Add(chatId, 0);
            MessageControls.Add(chatId,new List<MessageControl>());
            AdvancedMessageControls.Add(chatId, new List<AdvancedMessageControl>());


        }
        private void ContactControl_Click(object sender, System.EventArgs e)
        {
            ContactControl contactControl = (ContactControl)sender;
            string ContactName = contactControl.ContactName.Text;
            Contact contact = ContactManager.GetContact(ContactName);
            Image ContactProfilePicture = contact.ProfilePicture;
            if (!ProfileControlIsExist(ContactName))
            {
                contactControl.WasSelected = true;
                AddProfileControl(ContactName, ContactProfilePicture);
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
                RestartContactControlListLocation();
                //foreach (ContactControl Contact in ContactControlList)
                //{
                //    if (!Contact.WasSelected)
                //    {
                //        Contact.Location = new System.Drawing.Point(0, heightForContacts);
                //        heightForContacts += Contact.Height;
                //        Contact.Visible = true;
                //    }
                //    else
                //    {
                //        Contact.Visible = false;
                //    }
                //}
            }
            else
            {
                PanelHandler.SetPanelToSide(GroupCreatorPanel, ContactControlList, true);
                foreach (ContactControl Contact in ContactControlList) //this works for every contact. maybe it would be better to create for all the contacts a control and then just view the correct ones...
                {
                    bool IsVisible = false;
                    if (!Contact.WasSelected)
                    {
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
                    }
                    Contact.Visible = IsVisible;
                }
            }
        }
        private bool ProfileControlIsExist(string name)
        {
            foreach (ProfileControl profile in ProfileControlList)
            {
                if (profile.Name == name)
                {
                    return true;
                }
            }
            return false;
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
            if (this.SelectedContactsPanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            {
                //Control LastControl = this.ProfileControlList[0];
                //this.SelectedContactsPanel.ScrollControlIntoView(LastControl);
                PanelHandler.SetPanelToSide(SelectedContactsPanel, ProfileControlList, true);

            }
            else
            {
                GroupCreatorPanel.Location = new System.Drawing.Point(GroupCreatorPanel.Location.X, SelectedContactsPanel.Location.Y + SelectedContactsPanel.Height);
                GroupCreatorPanel.Size = new Size(GroupCreatorPanel.Width, GroupCreatorPanel.Height - SelectedContactsPanel.Height);
            }
            ProfileControlList.Add(new ProfileControl());
            ProfileControlList[profileControlNumber].Location = new System.Drawing.Point(widthForProfileControl, 0);
            ProfileControlList[profileControlNumber].Name = name;
            ProfileControlList[profileControlNumber].Size = new System.Drawing.Size(90, 90);
            ProfileControlList[profileControlNumber].TabIndex = 0;
            ProfileControlList[profileControlNumber].IsCloseVisible = true;
            ProfileControlList[profileControlNumber].SetProfilePicture(profilePictureTobeUsed);
            ProfileControlList[profileControlNumber].SetUserName(name);

            ProfileControlList[profileControlNumber].SetToolTip();
            ProfileControlList[profileControlNumber].OnClickHandler(RemoveProfileControl);

            this.Controls.Add(this.ProfileControlList[profileControlNumber]);

            SelectedContactsPanel.Controls.Add(ProfileControlList[profileControlNumber]);
            widthForProfileControl += ProfileControlList[profileControlNumber].Width + 10;
            profileControlNumber++;
            GroupCreatorPanel.Location = new System.Drawing.Point(GroupCreatorPanel.Location.X, SelectedContactsPanel.Location.Y + SelectedContactsPanel.Height);
            HandleCurrentChatParticipants();
            heightForContacts = 0;
            RestartContactControlListLocation(); //there is a problem here
        }
        private void RemoveProfileControl(object sender, System.EventArgs e)
        {
            ProfileControl profileControl = sender as ProfileControl;
            HandleRemoveProfileControl(profileControl);
        }
        private void HandleRemoveProfileControl(ProfileControl profileControl)
        {
            PanelHandler.SetPanelToSide(GroupCreatorPanel, ContactControlList, true);
            string ContactName = profileControl.Name;
            CancelContactControlSelection(ContactName);
            ProfileControlList.Remove(profileControl);
            SelectedContactsPanel.Controls.Remove(profileControl);
            profileControl.Dispose();
            profileControlNumber--;
            RestartProfileControlListLocation();
            if (this.SelectedContactsPanel.Controls.Count == 0)
            {
                GroupCreatorPanel.Location = new System.Drawing.Point(GroupCreatorPanel.Location.X, SelectedContactsPanel.Location.Y);
                GroupCreatorPanel.Size = new Size(GroupCreatorPanel.Width, GroupCreatorPanel.Height + SelectedContactsPanel.Height);
            }
            heightForContacts = 0;
            RestartContactControlListLocation();
            HandleCurrentChatParticipants();
        }
        private void RestartGroupCreator()
        {
            List<ProfileControl> profileControlsCopy = new List<ProfileControl>(ProfileControlList);
            foreach (ProfileControl profileControl in profileControlsCopy)
            {
                HandleRemoveProfileControl(profileControl);
            }
        }
        private void CancelContactControlSelection(string ContactName)
        {
            foreach (ContactControl contact in ContactControlList)
            {
                if (contact.Name == ContactName)
                {
                    contact.WasSelected = false;
                }
            }
        }
        private void RestartProfileControlListLocation()
        {
            widthForProfileControl = 0;
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.Location = new System.Drawing.Point(widthForProfileControl, 0);
                widthForProfileControl += profile.Width + 10;
            }
        }
        private void RestartContactControlListLocation()
        {
            //PanelHandler.SetPanelToSide(GroupCreatorPanel, ContactControlList, true);
            foreach (ContactControl Contact in ContactControlList)
            {
                if (!Contact.WasSelected)
                {
                    PanelHandler.SetPanelToSide(GroupCreatorPanel, ContactControlList, true); //i use it here due to an error (some times it made a space between them..
                    Contact.Location = new System.Drawing.Point(0, heightForContacts);
                    heightForContacts += Contact.Height;
                    Contact.Visible = true;
                }
                else
                {
                    Contact.Visible = false;
                }
            }
        }
        private void HandleCurrentChatParticipants()
        {
            const int ParticipantsNuber = 2;
            if (this.SelectedContactsPanel.Controls.Count >= ParticipantsNuber)
            {
                ContinueToGroupSettingsCustomButton.Enabled = true;
            }
            else
            {
                ContinueToGroupSettingsCustomButton.Enabled = false;
            }
        }
        private void setFeaturePanelsVisibility(bool directChatVisible)
        {
            DirectChatFeaturesPanel.Visible = directChatVisible;
            GroupChatFeaturesPanel.Visible = !directChatVisible;
        }
        private void ChatControl_Click(object sender, EventArgs e)
        {
            //ask for message history from the server in case that was the first press since logging in...
            // set contact headline details:
            ChatControl chatControl = (ChatControl)sender;
            string chatId = chatControl.ChatId;
            if (chatControl.GetFirstClick())
            {
                //ask server for message history...
            }
            if (currentMessagePanel != null)
            {
                currentMessagePanel.Visible = false;

            }
            else
            {
                MessageOptionsPanel.Enabled = true;
            }
            currentChatId = chatId;
            currentMessagePanel = MessagePanels[chatId];
            currentMessagePanel.Visible = true;
            ChatDetails chat = ChatManager.GetChat(chatId);
            ChatManager.CurrentChatId = chatId;
            string chatName = "";
            Image chatProfilePicture = null;
            if (chat is DirectChat directChat)
            {
                chatName = directChat.Contact.Name;
                chatProfilePicture = directChat.Contact.ProfilePicture;

                setFeaturePanelsVisibility(true);

                Contact contact = directChat.Contact;
                if (contact != null)
                {
                    if (contact.Online)
                    {
                        LastSeenOnlineLabel.Text = "Online";
                    }
                    else
                    {
                        DateTime ContactLastSeenTime = contact.LastSeenTime;
                        LastSeenOnlineLabel.Text = TimeHandler.GetFormatTime(ContactLastSeenTime);
                    }
                }
                ChatParticipantsLabel.Visible = false;
                LastSeenOnlineLabel.Visible = true;
                currentChatType = EnumHandler.ChatType_Enum.Direct; 
            }
            else if (chat is GroupChat groupChat)
            {
                chatName = groupChat.ChatName;
                chatProfilePicture = groupChat.ChatProfilePicture;

                setFeaturePanelsVisibility(false);
                ChatParticipantsLabel.Visible = true;
                ChatParticipantsLabel.Text = groupChat.ChatParticipantsToString();
                LastSeenOnlineLabel.Visible = false;
                currentChatType = EnumHandler.ChatType_Enum.Group;


            }
            CurrentChatNameLabel.Text = chatName;
            CurrentPictureChatPictureBox.BackgroundImage = chatProfilePicture;    
        }


        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            //if (MessageTextBox.Text != "")
            //{
            //    string Message = MessageTextBox.Text;
            //    string SendMessageTime = DateTime.Now.ToString("HH:mm");
            //    string MessageContant = Message + "#" + SendMessageTime;
            //    HandleYourMessages(Message, SendMessageTime);
            //    ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest, MessageContant);
            //    //ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest + "$" + MessageContant);
            //    MessageTextBox.Text = "Here You Write Your Message";
            //    MessageTextBox.ForeColor = Color.Silver;
            //}
            ////else if (LoadedPicturePictureBox.BackgroundImage != null)
            ////{
            ////    //ServerCommunication.SendImage(ServerCommunication.sendMessageRequest + "$" + MessageContant); need to figure out how to send a message as well - not nesserally perhaps - could use the username from the server and take the time the message got to the server...

            ////}

        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MessageRichTextBox.Text != "")
            {
                MessageSenderCustomButton.Enabled = true;
            }
            else
                MessageSenderCustomButton.Enabled = false;
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
            ProfileCustomButton.Enabled = true;
        }
        public void SetListOfFriendRequestControl(PastFriendRequests pastFriendRequests)
        {
            List<PastFriendRequest> friendRequests = pastFriendRequests.FriendRequests;
            foreach (PastFriendRequest pastFriendRequest in friendRequests)
            {
                AddFriendRequest(pastFriendRequest);
            }
        }
        public void AddFriendRequest(PastFriendRequest pastFriendRequest)
        {
            if (this.FriendRequestPanel.Controls.Count > 0)
            {
                PanelHandler.SetPanelToSide(FriendRequestPanel, ListOfFriendRequestControl, true);
            }
            string ContactUsername = pastFriendRequest.Username;
            DateTime FriendRequestDateTime = pastFriendRequest.FriendRequestDate;
            string ContactProfilePictureID = pastFriendRequest.ProfilePicture;

            this.ListOfFriendRequestControl.Insert(0, new FriendRequestControl());
            this.ListOfFriendRequestControl[0].Location = new System.Drawing.Point(0, 0);
            this.ListOfFriendRequestControl[0].Name = "FriendRequestControlNumber:" + FriendRequestsNumber;
            this.ListOfFriendRequestControl[0].TabIndex = 0;
            this.ListOfFriendRequestControl[0].ContactName.Text = ContactUsername;
            this.ListOfFriendRequestControl[0].FriendRequestTime.Text = TimeHandler.GetFormatTime(FriendRequestDateTime);
            this.ListOfFriendRequestControl[0].ProfilePicture.BackgroundImage = ProfilePictureImageList.GetImageByImageId(ContactProfilePictureID);
            this.ListOfFriendRequestControl[0].OnFriendRequestApprovalHandler(HandleFriendRequestApproval);
            this.ListOfFriendRequestControl[0].OnFriendRequestRefusalHandler(HandleFriendRequestRefusal);
            this.ListOfFriendRequestControl[0].SetFriendRequestTimeLocation();
            this.ListOfFriendRequestControl[0].SetToolTip();
            this.Controls.Add(this.ListOfFriendRequestControl[0]);
            this.FriendRequestPanel.Controls.Add(this.ListOfFriendRequestControl[0]);
            FriendRequestsNumber++;
            RestartListOfFriendRequestControlLocation();

        }
        //public void SetListOfFriendRequestControl(string ChatInformation)
        //{
        //    string[] ContactsInformation = ChatInformation.Split('#'); //todo check how i can allow the users to send # and more without the split activating - i thing maybe i need to put / or something before 
        //    //string ContactUsername;
        //    //string ContactProfilePictureID;
        //    ////string ContactProfilePictureKind;
        //    ////string ContactProfilePictureNumber;
        //    for (int i = 0; i < ContactsInformation.Length; i++)
        //    {
        //        AddFriendRequest(ContactsInformation[i]);
        //        //string[] ContactDetails = ContactsInformation[i].Split('^');
        //        //ContactUsername = ContactDetails[0];
        //        //ContactProfilePictureID = ContactDetails[1];
        //        ////string[] ContactProfilePictureInformation = SeparateLettersAndNumbers(ContactProfilePictureID);
        //        ////ContactProfilePictureKind = ContactProfilePictureInformation[0];
        //        ////ContactProfilePictureNumber = ContactProfilePictureInformation[1]; // to understand how to seperate them

        //        //if (FriendRequestsNumber == 0)
        //        //    heightForFriendRequests = 0;
        //        //else
        //        //    heightForFriendRequests = this.ListOfFriendRequestControl[FriendRequestsNumber - 1].Location.Y + this.ListOfFriendRequestControl[FriendRequestsNumber - 1].Size.Height;
        //        //this.ListOfFriendRequestControl.Add(new FriendRequestControl());
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].Location = new System.Drawing.Point(0, heightForFriendRequests);
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].Name = "FriendRequestControlNumber:" + FriendRequestsNumber;
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].TabIndex = 0;
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].ContactName.Text = ContactUsername;
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].OnFriendRequestApprovalHandler(HandleFriendRequestApproval);
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].OnFriendRequestRefusalHandler(HandleFriendRequestRefusal);
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.GetImageByImageId(ContactProfilePictureID);
        //        ////todo - for this code i should maybe create a genric method:
        //        ////if (ContactProfilePictureKind == "Male") //need to use that when getting a user imageid - but here i just take from the contacts list - by recieving the contact object and then its profileimage property...
        //        ////{
        //        ////    this.ListOfFriendRequestControl[FriendRequestsNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.MaleProfilePictureImageList.Images[ContactProfilePictureNumber];
        //        ////}
        //        ////else if (ContactProfilePictureKind == "Female")
        //        ////{
        //        ////    this.ListOfFriendRequestControl[FriendRequestsNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.FemaleProfilePictureImageList.Images[ContactProfilePictureNumber];

        //        ////}
        //        ////else if (ContactProfilePictureKind == "Animal")
        //        ////{
        //        ////    this.ListOfFriendRequestControl[FriendRequestsNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.AnimalProfilePictureImageList.Images[ContactProfilePictureNumber];
        //        ////}
        //        //this.Controls.Add(this.ListOfFriendRequestControl[FriendRequestsNumber]);
        //        //this.FriendRequestPanel.Controls.Add(this.ListOfFriendRequestControl[FriendRequestsNumber]);
        //        //if (this.FriendRequestPanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
        //        //{
        //        //    PanelHandler.SetPanelToSide(FriendRequestPanel, ListOfFriendRequestControl, true);
        //        //}
        //        //FriendRequestsNumber++;
        //    }
        //}
        //public void AddFriendRequest(string FriendRequestContent)
        //{
        //    if (this.FriendRequestPanel.Controls.Count > 0)
        //    {
        //        PanelHandler.SetPanelToSide(FriendRequestPanel, ListOfFriendRequestControl, true);
        //    }
        //    string[] ContactDetails = FriendRequestContent.Split('^');
        //    string ContactUsername = ContactDetails[0];
        //    string FriendRequestDateTimeAsString = ContactDetails[1];
        //    string ContactProfilePictureID = ContactDetails[2];

        //    DateTime FriendRequestTime;
        //    if (DateTime.TryParse(FriendRequestDateTimeAsString, out FriendRequestTime))
        //    {
        //        //if (FriendRequestsNumber == 0)
        //        //    heightForFriendRequests = 0;
        //        //else
        //        //    heightForFriendRequests = this.ListOfFriendRequestControl[FriendRequestsNumber - 1].Location.Y + this.ListOfFriendRequestControl[FriendRequestsNumber - 1].Size.Height;
        //        //this.ListOfFriendRequestControl.Add(new FriendRequestControl());
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].Location = new System.Drawing.Point(0, heightForFriendRequests);
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].Name = "FriendRequestControlNumber:" + FriendRequestsNumber;
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].TabIndex = 0;
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].ContactName.Text = ContactUsername;
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].FriendRequestTime.Text = TimeHandler.GetFormatTime(FriendRequestTime);
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.GetImageByImageId(ContactProfilePictureID);
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].OnFriendRequestApprovalHandler(HandleFriendRequestApproval);
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].OnFriendRequestRefusalHandler(HandleFriendRequestRefusal);
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].SetFriendRequestTimeLocation();
        //        //this.ListOfFriendRequestControl[FriendRequestsNumber].SetToolTip();
        //        //this.Controls.Add(this.ListOfFriendRequestControl[FriendRequestsNumber]);
        //        //this.FriendRequestPanel.Controls.Add(this.ListOfFriendRequestControl[FriendRequestsNumber]);
        //        //FriendRequestsNumber++;


        //        this.ListOfFriendRequestControl.Insert(0, new FriendRequestControl());
        //        this.ListOfFriendRequestControl[0].Location = new System.Drawing.Point(0, 0);
        //        this.ListOfFriendRequestControl[0].Name = "FriendRequestControlNumber:" + FriendRequestsNumber;
        //        this.ListOfFriendRequestControl[0].TabIndex = 0;
        //        this.ListOfFriendRequestControl[0].ContactName.Text = ContactUsername;
        //        this.ListOfFriendRequestControl[0].FriendRequestTime.Text = TimeHandler.GetFormatTime(FriendRequestTime);
        //        this.ListOfFriendRequestControl[0].ProfilePicture.BackgroundImage = ProfilePictureImageList.GetImageByImageId(ContactProfilePictureID);
        //        this.ListOfFriendRequestControl[0].OnFriendRequestApprovalHandler(HandleFriendRequestApproval);
        //        this.ListOfFriendRequestControl[0].OnFriendRequestRefusalHandler(HandleFriendRequestRefusal);
        //        this.ListOfFriendRequestControl[0].SetFriendRequestTimeLocation();
        //        this.ListOfFriendRequestControl[0].SetToolTip();
        //        this.Controls.Add(this.ListOfFriendRequestControl[0]);
        //        this.FriendRequestPanel.Controls.Add(this.ListOfFriendRequestControl[0]);
        //        FriendRequestsNumber++;
        //        RestartListOfFriendRequestControlLocation();
        //    }
        //    else
        //    {
        //        // Handle the case where the parsing fails
        //        // For example, display an error message to the user
        //        MessageBox.Show("Invalid date format");
        //    }
        //    //string ContactProfilePictureID = ContactDetails[2];
        //    //if (FriendRequestsNumber == 0)
        //    //    heightForFriendRequests = 0;
        //    //else
        //    //    heightForFriendRequests = this.ListOfFriendRequestControl[FriendRequestsNumber - 1].Location.Y + this.ListOfFriendRequestControl[FriendRequestsNumber - 1].Size.Height;
        //    //this.ListOfFriendRequestControl.Add(new FriendRequestControl());
        //    //this.ListOfFriendRequestControl[FriendRequestsNumber].Location = new System.Drawing.Point(0, heightForFriendRequests);
        //    //this.ListOfFriendRequestControl[FriendRequestsNumber].Name = "FriendRequestControlNumber:" + FriendRequestsNumber;
        //    //this.ListOfFriendRequestControl[FriendRequestsNumber].TabIndex = 0;
        //    //this.ListOfFriendRequestControl[FriendRequestsNumber].ContactName.Text = ContactUsername;
        //    //this.ListOfFriendRequestControl[FriendRequestsNumber].OnFriendRequestApprovalHandler(HandleFriendRequestApproval);
        //    //this.ListOfFriendRequestControl[FriendRequestsNumber].OnFriendRequestRefusalHandler(HandleFriendRequestRefusal);
        //    //this.ListOfFriendRequestControl[FriendRequestsNumber].SetFriendRequestTimeLocation();

        //    //this.ListOfFriendRequestControl[FriendRequestsNumber].SetToolTip();
        //    //this.ListOfFriendRequestControl[FriendRequestsNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.GetImageByImageId(ContactProfilePictureID);
        //    //this.Controls.Add(this.ListOfFriendRequestControl[FriendRequestsNumber]);
        //    //this.FriendRequestPanel.Controls.Add(this.ListOfFriendRequestControl[FriendRequestsNumber]);
        //    //FriendRequestsNumber++;
        //}
        private void RestartListOfFriendRequestControlLocation()
        {
            PanelHandler.SetPanelToSide(FriendRequestPanel, ListOfFriendRequestControl, true);
            heightForFriendRequests = 0;
            foreach (FriendRequestControl friendRequestControl in ListOfFriendRequestControl)
            {
                friendRequestControl.Location = new System.Drawing.Point(0, heightForFriendRequests);
                heightForFriendRequests += friendRequestControl.Height;
            }
        }
        public void HandleFriendRequestApproval(object sender, EventArgs e)
        {
            FriendRequestControl friendRequestControl = ((FriendRequestControl)(sender));
            string friendRequestStatus = ServerCommunication.FriendRequestResponseSender1;
            HandleFriendRequestResponse(friendRequestControl, friendRequestStatus);
            HandleFriendRequest(friendRequestControl);


        }
        public void HandleFriendRequestRefusal(object sender, EventArgs e)
        {
            FriendRequestControl friendRequestControl = ((FriendRequestControl)(sender));
            string friendRequestStatus = ServerCommunication.FriendRequestResponseSender2;
            HandleFriendRequestResponse(friendRequestControl, friendRequestStatus);
            HandleFriendRequest(friendRequestControl);
        }
        private void HandleFriendRequest(FriendRequestControl friendRequestControl)
        {
            //todo -needs to remove it from the list of friend requests...
            this.ListOfFriendRequestControl.Remove(friendRequestControl);
            FriendRequestPanel.Controls.Remove(friendRequestControl);
            friendRequestControl.Dispose();
            //also needs to restart height
            FriendRequestsNumber--;
            RestartListOfFriendRequestControlLocation();
        }
        private void HandleFriendRequestResponse(FriendRequestControl friendRequestControl, string friendRequestStatus)
        {
            string friendRequestSenderName = friendRequestControl.ContactName.Text;
            FriendRequestResponseDetails friendRequestResponseDetails = new FriendRequestResponseDetails(friendRequestSenderName, friendRequestStatus);
            JsonObject friendRequestResponseDetailsJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.FriendRequestResponseSender, friendRequestResponseDetails);
            string friendRequestResponseDetailsJson = JsonConvert.SerializeObject(friendRequestResponseDetailsJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(friendRequestResponseDetailsJson);
        }
        public void HandleYourMessages(string MessageContent, DateTime SendMessageTime) //maybe i should the same function just with if or something like that (to ask if name == my name...)
        {
            //if (MessageNumber != 0)
            //    heightForMessages = this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Location.Y + this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Size.Height + messageGap;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID].Add(new MessageControl());
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Location = new System.Drawing.Point(30, heightForMessages);
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Name = "MessageControlNumber:" + MessageNumber;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].TabIndex = 0;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].BackColor = SystemColors.Control;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Username.Text = UserProfile.ProfileDetailsHandler.Name;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text = MessageContent;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Time.Text = SendMessageTime;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].ProfilePicture.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture; 
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].SetMessageControl();
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].SetBackColorByMessageSender();
            //this.Controls.Add(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber]);
            //currentMessagePanel.Controls.Add(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber]);

            //if (currentMessagePanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            //{
            //    //Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
            //    Control LastControl = this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber];
            //    currentMessagePanel.ScrollControlIntoView(LastControl);
            //}
            //MessageNumber++;
            //int messageNumber = messageCount[currentChatId];
            //List<MessageControl> currentMessageControls = MessageControls[currentChatId];

            //if (messageNumber != 0)
            //    heightForMessages = currentMessageControls[messageNumber - 1].Location.Y + currentMessageControls[messageNumber - 1].Size.Height + messageGap;
            //else
            //{
            //    heightForMessages = 0;
            //}
            //currentMessageControls.Add(new MessageControl());
            //currentMessageControls[messageNumber].Location = new System.Drawing.Point(30, heightForMessages);
            //currentMessageControls[messageNumber].Name = $"Id:{currentChatId}-number:{messageNumber}";
            //currentMessageControls[messageNumber].TabIndex = 0;
            //currentMessageControls[messageNumber].BackColor = SystemColors.Control;
            //currentMessageControls[messageNumber].Username.Text = UserProfile.ProfileDetailsHandler.Name;
            //currentMessageControls[messageNumber].Message.Text = MessageContent;
            //currentMessageControls[messageNumber].Time.Text = TimeHandler.GetFormatTime(SendMessageTime);
            //currentMessageControls[messageNumber].ProfilePicture.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture;
            //currentMessageControls[messageNumber].SetMessageControl();
            //currentMessageControls[messageNumber].SetBackColorByMessageSender();
            //this.Controls.Add(currentMessageControls[messageNumber]);
            //currentMessagePanel.Controls.Add(currentMessageControls[messageNumber]);

            //if (currentMessagePanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            //{
            //    //Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
            //    Control LastControl = currentMessageControls[messageNumber];
            //    currentMessagePanel.ScrollControlIntoView(LastControl);
            //}
            //messageNumber++;
            //messageCount[currentChatId] = messageNumber;

            int messageNumber = messageCount[currentChatId];
            List<AdvancedMessageControl> currentMessageControls = AdvancedMessageControls[currentChatId];
            string username = UserProfile.ProfileDetailsHandler.Name;
            string time = TimeHandler.GetFormatTime(SendMessageTime);
            ChangeChatLastMessageInformation(currentChatId, SendMessageTime, MessageContent, username, time);

            if (messageNumber != 0)
                heightForMessages = currentMessageControls[messageNumber - 1].Location.Y + currentMessageControls[messageNumber - 1].Size.Height + messageGap;
            else
            {
                heightForMessages = 0;
            }
            currentMessageControls.Add(new AdvancedMessageControl());
            currentMessageControls[messageNumber].Location = new System.Drawing.Point(30, heightForMessages);
            currentMessageControls[messageNumber].Name = $"Id:{currentChatId}-number:{messageNumber}";
            currentMessageControls[messageNumber].TabIndex = 0;
            currentMessageControls[messageNumber].BackColor = SystemColors.Control;
            currentMessageControls[messageNumber].Username.Text = username;
            currentMessageControls[messageNumber].MessageContent.Text = MessageContent;
            currentMessageControls[messageNumber].Time.Text = time;
            currentMessageControls[messageNumber].ProfilePicture.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture;
            currentMessageControls[messageNumber].IsYourMessage = true;
            currentMessageControls[messageNumber].MessageType = YouChatApp.EnumHandler.MessageType_Enum.Text;

            currentMessageControls[messageNumber].SetMessageControl();
            currentMessageControls[messageNumber].SetBackColorByMessageSender();
            this.Controls.Add(currentMessageControls[messageNumber]);
            currentMessagePanel.Controls.Add(currentMessageControls[messageNumber]);

            if (currentMessagePanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            {
                //Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
                Control LastControl = currentMessageControls[messageNumber];
                currentMessagePanel.ScrollControlIntoView(LastControl);
            }
            messageNumber++;
            messageCount[currentChatId] = messageNumber;
        }
        private void HandleChatControlProcessForSendingMessage(ChatControl chatControl)
        {
            PanelHandler.SetPanelToSide(ChatPanel, ChatControlListOfContacts, true);
            this.ChatControlListOfContacts.Remove(chatControl);
            this.ChatControlListOfContacts.Insert(0, chatControl);
            //this.ChatControlListOfContacts[ContactChatNumber].Location = new System.Drawing.Point(0, heightForChats);
            ChatControl previousChatControl = null;

            foreach (ChatControl chat in ChatControlListOfContacts)
            {
                if (chat == chatControl)
                    heightForContacts = 0;
                else
                    heightForContacts = previousChatControl.Location.Y + previousChatControl.Size.Height;
                previousChatControl = chat;
                chat.Location = new System.Drawing.Point(0, heightForContacts);
            }
        }
        private void ChangeChatLastMessageInformation(string chatId, DateTime messageDateTime, string messageContent, string messageSenderName, string displayTime)
        {
            ChatDetails chatDetails = ChatHandler.ChatManager.GetChat(chatId);
            chatDetails.LastMessageContent = messageContent;
            chatDetails.LastMessageTime = messageDateTime;
            chatDetails.LastMessageSenderName = messageSenderName;
            ChatManager._chats.Remove(chatDetails);
            ChatManager._chats.Add(chatDetails);


            List<ChatControl> ChatControlListOfContactsCopy = new List<ChatControl>(ChatControlListOfContacts);
            foreach (ChatControl chat in ChatControlListOfContactsCopy)
            {
                if (chat.ChatId == chatId)
                {
                    chat.LastMessageContent.Text = chatDetails.GetLastMessageData();
                    chat.LastMessageTime.Text = displayTime;
                    chat.SetLastMessageTimeLocation();
                    HandleChatControlProcessForSendingMessage(chat);
                }
            }
        }
        public void HandleMessagesByOthers(string messageSenderName, string chatId, DateTime messageDateTime, string messageContent)
        {
            int messageNumber = messageCount[chatId];
            List<AdvancedMessageControl> currentMessageControls = AdvancedMessageControls[chatId];
            Panel messagePanel = MessagePanels[chatId];
            Contact SenderContact = ContactHandler.ContactManager.GetContact(messageSenderName);
            string time = TimeHandler.GetFormatTime(messageDateTime);

            ChangeChatLastMessageInformation(chatId,messageDateTime,messageContent, messageSenderName, time);


            if (messageNumber != 0)
                heightForMessages = currentMessageControls[messageNumber - 1].Location.Y + currentMessageControls[messageNumber - 1].Size.Height + messageGap;
            else
            {
                heightForMessages = 0;
            }
            currentMessageControls.Add(new AdvancedMessageControl());
            currentMessageControls[messageNumber].Location = new System.Drawing.Point(30, heightForMessages);
            currentMessageControls[messageNumber].Name = $"Id:{chatId}-number:{messageNumber}";
            currentMessageControls[messageNumber].TabIndex = 0;
            currentMessageControls[messageNumber].BackColor = SystemColors.Control;
            currentMessageControls[messageNumber].Username.Text = messageSenderName;
            currentMessageControls[messageNumber].MessageContent.Text = messageContent;
            currentMessageControls[messageNumber].Time.Text = time;
            currentMessageControls[messageNumber].ProfilePicture.BackgroundImage = SenderContact.ProfilePicture;
            currentMessageControls[messageNumber].IsYourMessage = false;
            currentMessageControls[messageNumber].MessageType = YouChatApp.EnumHandler.MessageType_Enum.Text;

            currentMessageControls[messageNumber].SetMessageControl();
            currentMessageControls[messageNumber].SetBackColorByMessageSender();
            this.Controls.Add(currentMessageControls[messageNumber]);
            messagePanel.Controls.Add(currentMessageControls[messageNumber]);

            if (messagePanel.Controls.Count > 0)
            {
                //Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
                Control LastControl = currentMessageControls[messageNumber];
                messagePanel.ScrollControlIntoView(LastControl);
            }
            messageNumber++;
            messageCount[chatId] = messageNumber;


            //Contact SenderContact = ContactHandler.ContactManager.GetContact(messageSenderName);
            //if (MessageNumber != 0)
            //    heightForMessages = this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Location.Y + this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Size.Height + messageGap;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID].Add(new MessageControl());
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Location = new System.Drawing.Point(30, heightForMessages);
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Name = "MessageControlNumber:" + MessageNumber;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].TabIndex = 0;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].BackColor = SystemColors.Control;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Username.Text = messageSenderName;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text = messageContent;
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Time.Text = TimeHandler.GetFormatTime(messageDateTime);
            ////this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].ProfilePicture.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture; //shouldn't use that... should receive the user image from the contact class...
            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].ProfilePicture.BackgroundImage = SenderContact.ProfilePicture;

            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].SetMessageControl();
            //this.Controls.Add(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber]);
            //this.MessagePanel.Controls.Add(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber]);

            //if (this.MessagePanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            //{
            //    //Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
            //    Control LastControl = this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber];
            //    this.MessagePanel.ScrollControlIntoView(LastControl);
            //}
            //MessageNumber++;

        }
        public void HandlePastMessages(string MessageCollection) //will be used in messages arrived from xml doc. needs to decide about symbol like # ^...
        {
            string[] MessageDetails = MessageCollection.Split('^');
            foreach (string Message in MessageDetails)
            {
                //HandleMessagesByOthers(Message);
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


        private void MessageRichTextBox_Enter(object sender, EventArgs e)
        {
            if (MessageRichTextBox.Text == "Here You Write Your Message")
            {
                MessageRichTextBox.Text = "";
                MessageRichTextBox.ForeColor = Color.White;
            }
        }
    

        private void MessageRichTextBox_Leave(object sender, EventArgs e)
        {
            if (MessageRichTextBox.Text == "")
            {
                MessageRichTextBox.Text = "Here You Write Your Message";
                MessageRichTextBox.ForeColor = Color.Silver;
            }
        }

        private void YouChat_Load(object sender, EventArgs e)
        {
            //JsonObject contactInformationRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.ContactInformationRequest, null);
            //string contactInformationRequestJson = JsonConvert.SerializeObject(contactInformationRequestJsonObject, new JsonSerializerSettings
            //{
            //    TypeNameHandling = TypeNameHandling.Auto
            //});
            //ServerCommunication.SendMessage(contactInformationRequestJson);
        }

        private void MessageRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                MessageRichTextBox.Text = "Here You Write Your Message";
                MessageRichTextBox.ForeColor = Color.Silver;
            }
            else if ((e.KeyCode == Keys.Enter) && (MessageRichTextBox.Text != ""))
            {
                string message = MessageRichTextBox.Text;
                SendMessage(message);
                //ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest + "$" + message);
                MessageRichTextBox.Text = "Here You Write Your Message";
                MessageRichTextBox.ForeColor = Color.Silver;
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
            if (_firstTimeEnteringFriendRequestZone)
            {
                _firstTimeEnteringFriendRequestZone = false;
                JsonObject pastFriendRequestsRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.PastFriendRequestsRequest, null);
                string pastFriendRequestsRequestJson = JsonConvert.SerializeObject(pastFriendRequestsRequestJsonObject, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                serverCommunicator.SendMessage(pastFriendRequestsRequestJson);
            }
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
            SetChatPanelVisible();
        }

        private void NewGroupCustomButton_Click(object sender, EventArgs e)
        {
            GroupCreatorBackgroundPanel.Visible = true;
            ContactManagementPanel.Visible = false;
            ChatBackgroundPanel.Visible = false;
        }
        private void SetChatPanelVisible()
        {
            GroupCreatorBackgroundPanel.Visible = false;
            ContactManagementPanel.Visible = false;
            ChatBackgroundPanel.Visible = true;
        }

        private void FriendRequestSenderCustomButton_Click(object sender, EventArgs e)
        {
            string usernameId = UserIdCustomTextBox.TextContent;
            string usernameTagLine = UserTaglineCustomTextBox.TextContent;
            //string userIdDetails = usernameId + "#" + usernameTagLine;
            //ServerCommunication.SendMessage(ServerCommunication.FriendRequestSender, userIdDetails);

            FriendRequestDetails friendRequestDetails = new FriendRequestDetails(usernameId,usernameTagLine);
            JsonObject friendRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.FriendRequestSender, friendRequestDetails);
            string friendRequestJson = JsonConvert.SerializeObject(friendRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(friendRequestJson);
            UserIdCustomTextBox.TextContent = "";
            UserTaglineCustomTextBox.TextContent = "";
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
            string groupSubject = GroupSubjectCustomTextBox.TextContent;
            Image groupIcon = GroupIconCircularPictureBox.BackgroundImage;
            List<string> groupParticipants = new List<string>();
            groupParticipants.Add(ProfileDetailsHandler.Name); //the first which is who created the group will be the manager...
            foreach (ProfileControl profileControl in ProfileControlList)
            {
                groupParticipants.Add(profileControl.Name);
            }
            byte[] groupIconBytes = ConvertHandler.ConvertImageToRawFormatBytes(groupIcon);
            ChatCreator chatCreator = new ChatCreator(groupSubject, groupParticipants, groupIconBytes);
            JsonObject chatCreatorJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.GroupCreatorRequest, chatCreator);
            string chatCreatorJson = JsonConvert.SerializeObject(chatCreatorJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(chatCreatorJson);
            SetChatPanelVisible();
            RestartGroupCreator();
            HandleSwitchToGroupContactsSelection();

            //string chatDetailsJson = JsonConvert.SerializeObject(chatCreator);


            //newChat = JsonConvert.DeserializeObject<ChatCreator>(chatDetailsJson);
            //ServerCommunication.SendMessage(ServerCommunication.GroupCreatorRequest, chatDetailsJson);

            GroupCreatorCustomButton.Enabled = false;
            //needs to close everything that is connected to opening groups..
        }
        public void HandleGroupCreation()
        {
            AddGroup(newChat);
            newChat = null;
            //this is for me
            //needs to take the data of the created group and create a new chat object plus to add it to 
        }
        public void AddGroup(ChatCreator chat)
        {
            //to add to chat list and to add the visuallity to the chat list on youchat platform...
        }
        private void GroupSubjectCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            int charLeft = GroupSubjectCustomTextBox.MaxLength - GroupSubjectCustomTextBox.TextContent.Length;
            GroupSubjectLengthLabel.Text = string.Format("({0})", charLeft);
            HandleGroupCreationFields();
        }
        private void HandleGroupCreationFields()
        {
            bool hasGroupIconBeenSelected = (GroupIconCircularPictureBox.BackgroundImage != null);
            bool hasGroupSubjectBeenSelected = GroupSubjectCustomTextBox.IsContainingValue();
            if ((hasGroupIconBeenSelected) && (hasGroupSubjectBeenSelected))
            {
                GroupCreatorCustomButton.Enabled = true;
            }
            else
            {
                GroupCreatorCustomButton.Enabled = false;
            }
        }
        private void GroupIconCircularPictureBox_Click(object sender, EventArgs e)
        {
            GroupIconContextMenuStrip.Show(GroupIconCircularPictureBox, new Point(GroupIconCircularPictureBox.Width/2, GroupIconCircularPictureBox.Height * 3 / 4));

            //bool GroupIconCircularPictureBoxHasIcon = (GroupIconCircularPictureBox.BackgroundImage != AnonymousProfile);
            //Image groupIcon = OpenFileDialogHandler.HandleOpenFileDialog(UploadedPictureOpenFileDialog);
            //if ((groupIcon == null) && (!GroupIconCircularPictureBoxHasIcon))
            //{
            //    groupIcon = AnonymousProfile;
            //}
            //if (groupIcon != null)
            //{
            //    GroupIconCircularPictureBox.BackgroundImage = groupIcon;
            //}
        }

        private void GroupIconCircularPictureBox_BackgroundImageChanged(object sender, EventArgs e)
        {
            HandleGroupCreationFields();
        }

        private void UploadPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool GroupIconCircularPictureBoxHasIcon = (GroupIconCircularPictureBox.BackgroundImage != AnonymousProfile);
            Image groupIcon = OpenFileDialogHandler.HandleOpenFileDialog(UploadedPictureOpenFileDialog);
            if ((groupIcon == null) && (!GroupIconCircularPictureBoxHasIcon))
            {
                groupIcon = AnonymousProfile;
            }
            if (groupIcon != null)
            {
                GroupIconCircularPictureBox.BackgroundImage = groupIcon;
            }
        }

        private void TakePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleImageTaking();
        }
        private void HandleImageTaking()
        {
            if (ServerCommunication._camera == null)
            {
                ServerCommunication._camera = new Camera();
            }

            DialogResult result = ServerCommunication._camera.ShowDialog();

            // Check if Form2 was closed successfully
            if (result == DialogResult.OK)
            {
                // Retrieve the image from Form2 and update the PictureBox in Form1
                GroupIconCircularPictureBox.BackgroundImage = ServerCommunication._camera.ImageToSend;
            }
        }

        private void EmojiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ServerCommunication._emojiKeyboard == null)
            {
                ServerCommunication._emojiKeyboard = new EmojiKeyboard();
            }
            ServerCommunication._emojiKeyboard._isText = false;
            DialogResult result = ServerCommunication._emojiKeyboard.ShowDialog();

            // Check if Form2 was closed successfully
            if (result == DialogResult.OK)
            {
                // Retrieve the image from Form2 and update the PictureBox in Form1
                GroupIconCircularPictureBox.BackgroundImage = ServerCommunication._emojiKeyboard.ImageToSend;
            }
        }
        private void DisableCloseForProfileControls()
        {
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.IsCloseVisible = false;
            }
        }
        private void EnableCloseForProfileControls()
        {
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.IsCloseVisible = true;
            }
        }
        private void ContinueToGroupSettingsCustomButton_Click(object sender, EventArgs e)
        {
            GroupSettingsPanel.Visible = true;
            GroupCreatorBackgroundPanel.Visible = false;
            this.GroupSettingsPanel.Controls.Add(this.SelectedContactsPanel);
            this.SelectedContactsPanel.Location = new Point(0, 100);
            DisableCloseForProfileControls();
            PanelHandler.SetPanelToSide(SelectedContactsPanel, ProfileControlList, true);
        }

        private void ReturnToGroupContactsSelectionCustomButton_Click(object sender, EventArgs e)
        {
            HandleSwitchToGroupContactsSelection();
        }
        private void HandleSwitchToGroupContactsSelection()
        {
            GroupSettingsPanel.Visible = false;
            GroupCreatorBackgroundPanel.Visible = true;
            this.GroupCreatorBackgroundPanel.Controls.Add(this.SelectedContactsPanel);
            this.SelectedContactsPanel.Location = new Point(0, 100);
            EnableCloseForProfileControls();
            PanelHandler.SetPanelToSide(SelectedContactsPanel, ProfileControlList, true);
        }

        private void RestartGroupSubjectCustomButton_Click(object sender, EventArgs e)
        {
            GroupSubjectCustomTextBox.TextContent = "";
        }

        private void UserFileButton_Click(object sender, EventArgs e)
        {

        }

        private void UserFileCustomButton_Click(object sender, EventArgs e)
        {
            //if (ServerCommunication._contactSharing == null)
            //{
            //    ServerCommunication._contactSharing = new ContactSharing();
            //}
            //this.Invoke(new Action(() => ServerCommunication._contactSharing.ShowDialog()));

            FormHandler._contactSharing = new ContactSharing();
            //ServerCommunication._contactSharing._isText = false;
            DialogResult result = FormHandler._contactSharing.ShowDialog();

            string contactData;
            if (result == DialogResult.OK)
            {
                contactData = ContactSharing.contactData;
                SendMessage(contactData);
            }
        }

        private void VideoCallCustomButton_Click(object sender, EventArgs e)
        {
            string chatName = CurrentChatNameLabel.Text;
            ServerCommunication._waitingForm = new WaitingForm();
            this.Invoke(new Action(() => ServerCommunication._waitingForm.ShowDialog()));
            ServerCommunication.SendMessage(ServerCommunication.VideoCallRequest, chatName);
           
        }

        private void DrawingFileCustomButton_Click(object sender, EventArgs e)
        {
            if (ServerCommunication._paint == null)
            {
                ServerCommunication._paint = new Paint();
            }
            this.Invoke(new Action(() => ServerCommunication._paint.ShowDialog()));
        }

        private void EmojiFileButton_Click(object sender, EventArgs e)
        {

        }

        private void EmojiKeyBoardCustomButton_Click(object sender, EventArgs e)
        {
            if (ServerCommunication._emojiKeyboard == null)
            {
                ServerCommunication._emojiKeyboard = new EmojiKeyboard();
            }
            ServerCommunication._emojiKeyboard._isText = true;
            this.Invoke(new Action(() => ServerCommunication._emojiKeyboard.Show()));
        }

        private void MessageSenderCustomButton_Click(object sender, EventArgs e)
        {
            if (MessageCustomTextBox.IsContainingValue())
            {
                string Message = MessageCustomTextBox.TextContent;
                string SendMessageTime = DateTime.Now.ToString("HH:mm");
                string MessageContant = Message + "#" + SendMessageTime;
                SendMessage(Message);
                //ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest + "$" + MessageContant);
                MessageCustomTextBox.TextContent = "";
            }
            //else if (LoadedPicturePictureBox.BackgroundImage != null)
            //{
            //    //ServerCommunication.SendImage(ServerCommunication.sendMessageRequest + "$" + MessageContant); need to figure out how to send a message as well - not nesserally perhaps - could use the username from the server and take the time the message got to the server...

            //}
            // Check if Form2 is open and not disposed before trying to close it
            EmojiKeyboard emojiKeyboard = ServerCommunication._emojiKeyboard;
            if (emojiKeyboard != null && !emojiKeyboard.IsDisposed && emojiKeyboard.Visible)
            {
                emojiKeyboard.Hide();
            }
        }
        private void SendMessage(string messageContent)
        {
            DateTime messageTime = DateTime.Now;
            HandleYourMessages(messageContent, messageTime);
            JsonClasses.Message message = new JsonClasses.Message(ProfileDetailsHandler.Name, currentChatId, messageContent, messageTime);
            JsonObject messageJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.SendMessageRequest, message);
            string messageJson = JsonConvert.SerializeObject(messageJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(messageJson);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TakenImageFile_Click(object sender, EventArgs e)
        {
            HandleImageTaking();

        }

        private void ImageFileCustomButton_Click(object sender, EventArgs e)
        {
            if (ServerCommunication._imageSender == null)
            {
                ServerCommunication._imageSender = new ImageSender();
            }
            this.Invoke(new Action(() => ServerCommunication._imageSender.ShowDialog()));
        }

        private void ProfileCustomButton_Click(object sender, EventArgs e)
        {
            profile = new Profile(this);
            profile.Show();
            ProfileCustomButton.Enabled = false;
        }

        private void MessageOptionsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GroupChatExitCustomButton_Click(object sender, EventArgs e)
        {
            //delete chat control
            //clear all the chat history from the client side
            //send a message to the server to handle it (remove from group and send message to the online members to remove him...)
        }

        private void GroupChatAddMemberCustomButton_Click(object sender, EventArgs e)
        {
            ServerCommunication._contactSharing = new ContactSharing();
            //ServerCommunication._contactSharing._isText = false;
            DialogResult result = ServerCommunication._contactSharing.ShowDialog();

            //todo - to show only those who aren't currently in the group...

            //if (result == DialogResult.OK)
            //{
            //    // Retrieve the image from Form2 and update the PictureBox in Form1
            //    GroupIconCircularPictureBox.BackgroundImage = ServerCommunication._emojiKeyboard.ImageToSend;
            //}
        }
        private void MoveChatControlToFront()
        {
            //todo - handle message sent in chat...
        }

        private void YouChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            JsonObject disconnectJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.Disconnect, null);
            string disconnectJson = JsonConvert.SerializeObject(disconnectJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(disconnectJson);
            serverCommunicator.Disconnect();
            System.Windows.Forms.Application.ExitThread();
        }

        private void MessageCustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                MessageCustomTextBox.TextContent = "";
            }
        }
    }
}
