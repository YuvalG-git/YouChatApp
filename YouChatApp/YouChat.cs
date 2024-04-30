﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YouChatApp.AttachedFiles;
using YouChatApp.ChatHandler;
using YouChatApp.ContactHandler;
using YouChatApp.Controls;
using YouChatApp.UserProfile;
using YouChatApp.JsonClasses;
using ChatManager = YouChatApp.ChatHandler.ChatManager;
using GroupChat = YouChatApp.ChatHandler.GroupChat;
using ChatCreator = YouChatApp.ChatHandler.ChatCreator;
using Message = YouChatApp.JsonClasses.Message;
using Contact = YouChatApp.ContactHandler.Contact;
using ContactManager = YouChatApp.ContactHandler.ContactManager;
using YouChatApp.AttachedFiles.CameraHandler;
using YouChatApp.AttachedFiles.CallHandler;

namespace YouChatApp
{
    public partial class YouChat : Form
    {
        #region Private Fields

        private int heightForMessages = 10;
        private int heightForChats;
        private int heightForFriendRequests = 10;
        private int heightForContacts;
        private int widthForProfileControl = 0;
        private bool _firstTimeEnteringFriendRequestZone = true;
        private int ContactChatNumber = 0;
        private int ContactNumber = 0;
        private int profileControlNumber = 0;
        private int FriendRequestsNumber = 0;
        private Panel currentMessagePanel;
        private Dictionary<string, int> messageCount;
        private Dictionary<string, bool> messageHistoryReceieved;
        private string currentChatId = "";

        #endregion

        #region Readonly Fields & Constants

        private readonly Image AnonymousProfile = global::YouChatApp.Properties.Resources.AnonymousProfile; 
        private readonly ServerCommunicator serverCommunicator;
        private const int messageGap = 10;
        private const string ApprovalFriendRequestResponse = "Approval";
        private const string RejectionFriendRequestResponse = "Rejection";

        #endregion

        #region Constructors

        public YouChat()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            MessageLabels = new List<Label>();
            ChatControlListOfContacts = new List<ChatControl>();
            ListOfFriendRequestControl = new List<FriendRequestControl>();
            ContactControlList = new List<ContactControl>();
            ProfileControlList = new List<ProfileControl>();
            MessagePanels = new Dictionary<string, Panel>();
            messageCount = new Dictionary<string, int>();
            messageHistoryReceieved = new Dictionary<string, bool>();
            AdvancedMessageControls = new Dictionary<string, List<AdvancedMessageControl>>();
            ChatSearchBar.AddSearchOnClickHandler(SearchChats);
            GroupCreatorSearchBar.AddSearchOnClickHandler(SearchContacts);

            UserIdCustomTextBox.PlaceHolderText = "YouChat ID";
            UserTaglineCustomTextBox.PlaceHolderText = "TAGLINE";

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.UserDetailsRequest;
            object messageContent = null;
            serverCommunicator.SendMessage(messageType, messageContent);

            PanelHandler.DeletePanelScrollBars(SelectedContactsPanel);
            PanelHandler.DeletePanelHorizontalScrollBar(GroupCreatorPanel);
            PanelHandler.DeletePanelHorizontalScrollBar(FriendRequestIdPanel);

            GroupCreatorPanel.Location = new System.Drawing.Point(GroupCreatorPanel.Location.X, SelectedContactsPanel.Location.Y);
            GroupCreatorPanel.Size = new Size(GroupCreatorPanel.Width, GroupCreatorPanel.Height + SelectedContactsPanel.Height);

            CurrentChatNameLabel.Text = "";
            ChatStatusLabel.Text = "";
            ChatParticipantsLabel.Text = "";
            LastSeenOnlineLabel.Text = "";
        }

        #endregion



        #region User Details Methods


        public void SetProfilePicture()
        {
            ProfileCustomButton.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture;

            UserIDLabel.Text += " " + UserProfile.ProfileDetailsHandler.Name + "#" + UserProfile.ProfileDetailsHandler.TagLine;

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.ContactInformationRequest;
            object messageContent = null;
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        public void SetProfileButtonEnabled()
        {
            ProfileCustomButton.Enabled = true;
            ProfileCustomButton.BackgroundImageLayout = ImageLayout.Zoom;
            ProfileCustomButton.BackgroundImage = ProfileDetailsHandler.ProfilePicture;
        }

        #endregion

        #region Chat Methods
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
            this.ChatControlListOfContacts[ContactChatNumber].LastMessageDateTime = chat.LastMessageTime;
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
            AdvancedMessageControls.Add(chatId, new List<AdvancedMessageControl>());
            messageHistoryReceieved.Add(chatId, false);
        }
        public void SetChatControlListOfContacts()
        {
            foreach (ChatDetails chat in ChatManager._chats)
            {
                AddChatControl(chat);
            }
        }
        public void HandleNewGroupChatCreation(ChatDetails chat)
        {
            AddChatControl(chat);
        }

        private void SearchChats(object sender, System.EventArgs e)
        {
            string Text = ChatSearchBar.SeacrhBar.TextContent;
            while (Text.EndsWith(" "))
            {
                Text = Text.Substring(0, Text.Length - 1);
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
                foreach (ChatControl chat in ChatControlListOfContacts)
                {
                    bool IsVisible = false;
                    ContactName = chat.ChatName.Text;
                    if (Text.ToLower().Contains(" "))
                    {
                        if (ContactName.ToLower().StartsWith(Text.ToLower()))
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
                            if (NamePart.ToLower().StartsWith(Text.ToLower()))
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
        private void ChatControl_Click(object sender, EventArgs e)
        {
            ChatControl chatControl = (ChatControl)sender;
            string chatId = chatControl.ChatId;
            HandleChats(chatControl, chatId);
        }
        public void HandleChats(ChatControl chatControl, string chatId)
        {
            MessageCustomTextBox.TextContent = "";
            chatControl.Focus();
            if (chatControl.GetFirstClick())
            {
                EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.MessageHistoryRequest;
                object messageContent = chatId;
                serverCommunicator.SendMessage(messageType, messageContent);
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
                SetFeaturePanelsVisibility(true);
                chatName = directChat.GetContactName();
                Contact contact = directChat.Contact;
                if (contact != null)
                {
                    chatProfilePicture = contact.ProfilePicture;
                    ChatStatusLabel.Text = $"status: {contact.Status}";
                    ChatStatusLabel.Visible = true;
                    LastSeenOnlineLabel.Visible = true;
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
                else
                {
                    ChatStatusLabel.Visible = false;
                    LastSeenOnlineLabel.Visible = false;
                    chatProfilePicture = null;
                }
                ChatParticipantsLabel.Visible = false;

            }
            else if (chat is GroupChat groupChat)
            {
                chatName = groupChat.ChatName;
                chatProfilePicture = groupChat.ChatProfilePicture;

                SetFeaturePanelsVisibility(false);
                ChatParticipantsLabel.Visible = true;
                ChatParticipantsLabel.Text = groupChat.ChatParticipantsToString();
                LastSeenOnlineLabel.Visible = false;
                ChatStatusLabel.Visible = false;
            }
            CurrentChatNameLabel.Text = chatName;
            CurrentPictureChatPictureBox.BackgroundImage = chatProfilePicture;
        }
        public void HandleCallMessageSelection(string chatId)
        {
            foreach (ChatControl chatControl in ChatControlListOfContacts)
            {
                if (chatControl.ChatId == chatId)
                {
                    HandleChats(chatControl, chatId);
                }
            }
        }
        private void HandleChatControlProcessForSendingMessage(ChatControl chatControl)
        {
            PanelHandler.SetPanelToSide(ChatPanel, ChatControlListOfContacts, true);
            this.ChatControlListOfContacts.Remove(chatControl);
            this.ChatControlListOfContacts.Insert(0, chatControl);
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



        #endregion

        #region Message Methods
        public void HandleYourMessages(string MessageContent, string chatId, DateTime SendMessageTime)
        {
            string username = UserProfile.ProfileDetailsHandler.Name;
            string time = TimeHandler.GetFormatTime(SendMessageTime);
            ChangeChatLastMessageInformation(chatId, SendMessageTime, MessageContent, username, time);
            AddMessageByUser(MessageContent, chatId, time, username, SendMessageTime);
        }
        public void HandleYourImageMessages(Image messageImage, string chatId, DateTime SendMessageTime)
        {
            string username = UserProfile.ProfileDetailsHandler.Name;
            string time = TimeHandler.GetFormatTime(SendMessageTime);
            ChangeChatLastMessageInformation(chatId, SendMessageTime, "Image", username, time);
            AddImageMessageByUser(messageImage, chatId, time, username, SendMessageTime);
        }

        private void AddImageMessageByUser(Image messageImage, string chatId, string time, string username, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByUser(chatId, time, username, messageDateTime);
            advancedMessageControl.Image.BackgroundImage = messageImage;
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.Image;
            advancedMessageControl.AddMessageDeleteHandler(DeleteMessage);
            advancedMessageControl.AddAfterMessageDeleteHandler(AfterDeleteMessage);
        }
        private void AddMessageByUser(string MessageContent, string chatId, string time, string username, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByUser(chatId, time, username, messageDateTime);
            advancedMessageControl.MessageContent.Text = MessageContent;
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.Text;
            advancedMessageControl.AddMessageDeleteHandler(DeleteMessage);
            advancedMessageControl.AddAfterMessageDeleteHandler(AfterDeleteMessage);
        }
        private void AddDeletedMessageByUser(string chatId, string time, string username, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByUser(chatId, time, username, messageDateTime);
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.DeletedMessage;
            advancedMessageControl.HandleDelete();
            advancedMessageControl.BringToFront();
        }

        private void DeleteMessage(object sender, EventArgs e)
        {
            AdvancedMessageControl advancedMessageControl = sender as AdvancedMessageControl;
            string username = ProfileDetailsHandler.Name;
            string chatId = currentChatId;
            object messageContentValue = null;
            DateTime messageTime = advancedMessageControl.MessageTime;
            string messageValue = "";
            if (advancedMessageControl.MessageType == EnumHandler.MessageType_Enum.Text)
            {
                messageContentValue = advancedMessageControl.MessageContent.Text;
                messageValue = advancedMessageControl.MessageContent.Text;
            }
            else if (advancedMessageControl.MessageType == EnumHandler.MessageType_Enum.Image)
            {
                Image image = advancedMessageControl.Image.BackgroundImage;
                byte[] imageBytes = ConvertHandler.ConvertImageToBytes(image);
                messageContentValue = new ImageContent(imageBytes);
                messageValue = "Image";
            }
            Message message = new Message(username, chatId, messageContentValue, messageTime);


            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.DeleteMessageRequest;
            object messageContent = message;
            serverCommunicator.SendMessage(messageType, messageContent);
            ChatDetails chatDetails = ChatManager.GetChat(chatId);
            if (chatDetails.LastMessageTime.Equals(messageTime) && chatDetails.LastMessageContent == messageValue && chatDetails.LastMessageSenderName == username)
            {
                chatDetails.LastMessageContent = "Deleted Message";
                List<ChatControl> ChatControlListOfContactsCopy = new List<ChatControl>(ChatControlListOfContacts);
                foreach (ChatControl chat in ChatControlListOfContactsCopy)
                {
                    if (chat.ChatId == chatId)
                    {
                        chat.LastMessageContent.Text = chatDetails.GetLastMessageData();
                    }
                }
            }

        }
        private void AfterDeleteMessage(object sender, EventArgs e)
        {
            string chatId = currentChatId;
            RestartChatMessages(chatId);
        }
        public void HandleMessagesByOthers(string messageSenderName, string chatId, DateTime messageDateTime, string messageContent)
        {
            string time = TimeHandler.GetFormatTime(messageDateTime);
            ChangeChatLastMessageInformation(chatId, messageDateTime, messageContent, messageSenderName, time);
            if (messageHistoryReceieved[chatId])
                AddTextMessageByOthers(messageContent, chatId, time, messageSenderName, messageDateTime);
        }
        public void HandleDeletedMessage(string messageSenderName, string chatId, DateTime messageDateTime, string messageContent)
        {
            ChatDetails chatDetails = ChatManager.GetChat(chatId);
            if (chatDetails.LastMessageTime.Equals(messageDateTime) && chatDetails.LastMessageContent == messageContent && chatDetails.LastMessageSenderName == messageSenderName)
            {
                chatDetails.LastMessageContent = "Deleted Message";
                List<ChatControl> ChatControlListOfContactsCopy = new List<ChatControl>(ChatControlListOfContacts);
                foreach (ChatControl chat in ChatControlListOfContactsCopy)
                {
                    if (chat.ChatId == chatId)
                    {
                        chat.LastMessageContent.Text = chatDetails.GetLastMessageData();
                    }
                }
            }

            List<AdvancedMessageControl> currentMessageControls = AdvancedMessageControls[chatId];

            foreach (AdvancedMessageControl advancedMessageControl in currentMessageControls)
            {
                if (messageSenderName == advancedMessageControl.Username.Text)
                {
                    if (messageDateTime.Equals(advancedMessageControl.MessageTime))
                        advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.DeletedMessage;
                    advancedMessageControl.HandleDelete();
                    advancedMessageControl.Invalidate();
                }
            }
            RestartChatMessages(chatId);

        }
        public void HandleImageMessagesByOthers(string messageSenderName, string chatId, DateTime messageDateTime, Image messageImage)
        {
            string time = TimeHandler.GetFormatTime(messageDateTime);
            ChangeChatLastMessageInformation(chatId, messageDateTime, "Image", messageSenderName, time);
            if (messageHistoryReceieved[chatId])
                AddImageMessageByOthers(messageImage, chatId, time, messageSenderName, messageDateTime);

        }
        private void AddDeletedMessageByOthers(string chatId, string time, string messageSenderName, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByOthers(chatId, time, messageSenderName, messageDateTime);
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.DeletedMessage;
            advancedMessageControl.HandleDelete();
            advancedMessageControl.BringToFront();
        }
        private void AddImageMessageByOthers(Image messageImage, string chatId, string time, string messageSenderName, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByOthers(chatId, time, messageSenderName, messageDateTime);
            advancedMessageControl.Image.BackgroundImage = messageImage;
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.Image;
        }
        private AdvancedMessageControl AddMessage(string chatId, string time, string username, DateTime messageDateTime, Panel chatPanel)
        {
            int messageNumber = messageCount[chatId];
            List<AdvancedMessageControl> currentMessageControls = AdvancedMessageControls[chatId];

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
            currentMessageControls[messageNumber].Username.Text = username;
            currentMessageControls[messageNumber].Time.Text = time;
            currentMessageControls[messageNumber].MessageTime = messageDateTime;

            currentMessageControls[messageNumber].SetMessageControl();
            this.Controls.Add(currentMessageControls[messageNumber]);
            chatPanel.Controls.Add(currentMessageControls[messageNumber]);

            if (chatPanel.Controls.Count > 0)
            {
                Control LastControl = currentMessageControls[messageNumber];
                chatPanel.ScrollControlIntoView(LastControl);
            }
            messageNumber++;
            messageCount[chatId] = messageNumber;
            return currentMessageControls[messageNumber - 1];
        }

        private AdvancedMessageControl AddMessageByUser(string chatId, string time, string username, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessage(chatId, time, username, messageDateTime, currentMessagePanel);
            advancedMessageControl.ProfilePicture.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture;
            advancedMessageControl.IsYourMessage = true;
            advancedMessageControl.SetBackColorByMessageSender();
            return advancedMessageControl;
        }
        private AdvancedMessageControl AddMessageByOthers(string chatId, string time, string messageSenderName, DateTime messageDateTime)
        {
            Panel messagePanel = MessagePanels[chatId];
            Contact SenderContact = ContactManager.GetContact(messageSenderName);
            Image profilePicture = null;
            if (SenderContact == null)
            {
                ChatDetails chatDetails = ChatManager.GetChat(chatId);
                string profilePictureId = "";
                foreach (ChatParticipant chatParticipant in chatDetails.ChatParticipants)
                {
                    if (chatParticipant.Username == messageSenderName)
                    {
                        profilePictureId = chatParticipant.ProfilePicture;
                    }
                }
                if (profilePictureId != "")
                    profilePicture = ProfilePictureImageList.GetImageByImageId(profilePictureId);
            }
            else
            {
                profilePicture = SenderContact.ProfilePicture;
            }
            AdvancedMessageControl advancedMessageControl = AddMessage(chatId, time, messageSenderName, messageDateTime, messagePanel);
            advancedMessageControl.ProfilePicture.BackgroundImage = profilePicture;
            advancedMessageControl.IsYourMessage = false;
            advancedMessageControl.SetBackColorByOtherSender();
            return advancedMessageControl;
        }
        private void AddTextMessageByOthers(string messageContent, string chatId, string time, string messageSenderName, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByOthers(chatId, time, messageSenderName, messageDateTime);
            advancedMessageControl.MessageContent.Text = messageContent;
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.Text;
        }
        public void HandleMessageHistory(List<JsonClasses.Message> messages)
        {
            string messageSenderName;
            string chatId;
            DateTime messageDateTime;
            string time;
            object messageContent;
            string username = ProfileDetailsHandler.Name;
            if (messages != null && messages.Count > 0)
            {
                chatId = messages[0].ChatId;
                messageCount[chatId] = 0;
                messageHistoryReceieved[chatId] = true;
                List<AdvancedMessageControl> currentMessageControls = AdvancedMessageControls[chatId];
                List<AdvancedMessageControl> messageControlsToRemove = new List<AdvancedMessageControl>();

                for (int i = currentMessageControls.Count - 1; i >= 0; i--)
                {
                    AdvancedMessageControl messageControl = currentMessageControls[i];
                    messageControl.Name = "1";
                    messageControlsToRemove.Add(messageControl);
                }

                foreach (AdvancedMessageControl messageControl in messageControlsToRemove)
                {
                    currentMessageControls.Remove(messageControl);
                    currentMessagePanel.Controls.Remove(messageControl);
                    this.Controls.Remove(messageControl);
                }
            }
            foreach (JsonClasses.Message message in messages)
            {
                messageSenderName = message.MessageSenderName;
                chatId = message.ChatId;
                messageDateTime = message.MessageDateAndTime;
                time = TimeHandler.GetFormatTime(messageDateTime);
                messageContent = message.MessageContent;

                if (messageContent is string textMessageContent)
                {
                    if (message.MessageSenderName == ProfileDetailsHandler.Name)
                    {
                        AddMessageByUser(textMessageContent, chatId, time, username, messageDateTime);
                    }
                    else
                    {
                        AddTextMessageByOthers(textMessageContent, chatId, time, messageSenderName, messageDateTime);
                    }
                }
                else if (messageContent is ImageContent imageMessageContent)
                {
                    byte[] imageBytes = imageMessageContent.ImageBytes;
                    Image image = ConvertHandler.ConvertBytesToImage(imageBytes);
                    if (message.MessageSenderName == ProfileDetailsHandler.Name)
                    {
                        AddImageMessageByUser(image, chatId, time, username, messageDateTime);
                    }
                    else
                    {
                        AddImageMessageByOthers(image, chatId, time, messageSenderName, messageDateTime);
                    }
                }
                else if (messageContent is null)
                {
                    if (message.MessageSenderName == ProfileDetailsHandler.Name)
                    {
                        AddDeletedMessageByUser(chatId, time, username, messageDateTime);
                    }
                    else
                    {
                        AddDeletedMessageByOthers(chatId, time, messageSenderName, messageDateTime);
                    }
                }

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
                    chat.LastMessageDateTime = messageDateTime;
                    chat.LastMessageContent.Text = chatDetails.GetLastMessageData();
                    chat.LastMessageTime.Text = displayTime;
                    chat.SetLastMessageTimeLocation();
                    HandleChatControlProcessForSendingMessage(chat);
                }
            }
        }
        private void RestartChatMessages(string chatId)
        {
            Panel currentMessagePanel = MessagePanels[chatId];
            List<AdvancedMessageControl> currentMessageControls = AdvancedMessageControls[chatId];
            PanelHandler.SetPanelToSide(currentMessagePanel, currentMessageControls, true);

            int height;
            bool firstMessageControl = true;
            AdvancedMessageControl previousAdvancedMessageControl = null;
            foreach (AdvancedMessageControl advancedMessageControl in currentMessageControls)
            {
                if (firstMessageControl)
                {
                    height = 0;
                    firstMessageControl = false;
                }
                else
                {
                    height = previousAdvancedMessageControl.Location.Y + previousAdvancedMessageControl.Size.Height + messageGap;
                }
                previousAdvancedMessageControl = advancedMessageControl;
                advancedMessageControl.Location = new System.Drawing.Point(30, height);
            }
            PanelHandler.SetPanelToSide(currentMessagePanel, currentMessageControls, false);

        }
        #endregion

        #region Contact Methods

        private void AddContactControl(Contact contact, int location)
        {
            ContactControl contactControl = new ContactControl();
            contactControl.Location = new System.Drawing.Point(0, heightForContacts);
            contactControl.Name = contact.Name;
            contactControl.TabIndex = 0;
            contactControl.ContactName.Text = contact.Name;
            contactControl.ContactStatus.Text = contact.Status;
            contactControl.ProfilePicture.Image = contact.ProfilePicture;
            contactControl.Click += new EventHandler(this.ContactControl_Click);

            this.ContactControlList.Insert(location, contactControl);
            this.Controls.Add(contactControl);
            this.GroupCreatorPanel.Controls.Add(contactControl);
            ContactNumber++;
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
                AddContactControl(Contact, ContactNumber);
            }
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
            }
            else
            {
                PanelHandler.SetPanelToSide(GroupCreatorPanel, ContactControlList, true);
                foreach (ContactControl Contact in ContactControlList)
                {
                    bool IsVisible = false;
                    if (!Contact.WasSelected)
                    {
                        ContactName = Contact.ContactName.Text;
                        if (Text.ToLower().Contains(" "))
                        {
                            if (ContactName.ToLower().StartsWith(Text.ToLower()))
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
                                if (NamePart.ToLower().StartsWith(Text.ToLower()))
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
        private void RestartContactControlListLocation()
        {
            foreach (ContactControl Contact in ContactControlList)
            {
                if (!Contact.WasSelected)
                {
                    PanelHandler.SetPanelToSide(GroupCreatorPanel, ContactControlList, true);
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

        #endregion

        #region Friend Requests Methods

        public void HandleSuccessfulFriendRequest(Contact contact, ChatDetails chat)
        {
            int location = ContactManager.UserContacts.IndexOf(contact);
            if (this.ContactControlList.Count == 0)
            {
                heightForContacts = 0;
            }
            else if (location == ContactManager.UserContacts.Count - 1)
            {
                heightForContacts = this.ContactControlList[location - 1].Location.Y + ContactControlList[location - 1].Size.Height;
            }
            else
            {
                heightForContacts = this.ContactControlList[location].Location.Y;
            }
            if (location >= 0)
            {
                AddContactControl(contact, location);
            }
            for (int i = location + 1; i < ContactControlList.Count; i++)
            {
                heightForContacts = this.ContactControlList[i - 1].Location.Y + this.ContactControlList[i - 1].Size.Height;
                this.ContactControlList[i].Location = new System.Drawing.Point(0, heightForContacts);
            }

            AddChatControl(chat);
        }
        public void SetListOfFriendRequestControl(PastFriendRequests pastFriendRequests)
        {
            List<PastFriendRequest> friendRequests = pastFriendRequests.FriendRequests;
            foreach (PastFriendRequest pastFriendRequest in friendRequests)
            {
                AddFriendRequest(pastFriendRequest);
            }
        }
        public void HandleNewFriendRequest(PastFriendRequest pastFriendRequest)
        {
            if (!_firstTimeEnteringFriendRequestZone)
                AddFriendRequest(pastFriendRequest);
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
            string friendRequestStatus = ApprovalFriendRequestResponse;
            HandleFriendRequestResponse(friendRequestControl, friendRequestStatus);
            HandleFriendRequest(friendRequestControl);
        }
        public void HandleFriendRequestRefusal(object sender, EventArgs e)
        {
            FriendRequestControl friendRequestControl = ((FriendRequestControl)(sender));
            string friendRequestStatus = RejectionFriendRequestResponse;
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

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.FriendRequestResponseSender;
            object messageContent = friendRequestResponseDetails;
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        private void FriendRequestSenderCustomButton_Click(object sender, EventArgs e)
        {
            string usernameId = UserIdCustomTextBox.TextContent;
            string usernameTagLine = UserTaglineCustomTextBox.TextContent;

            FriendRequestDetails friendRequestDetails = new FriendRequestDetails(usernameId, usernameTagLine);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.FriendRequestSender;
            object messageContent = friendRequestDetails;
            serverCommunicator.SendMessage(messageType, messageContent);

            FriendRequestControl friendRequestControlToRemove = null;
            foreach (FriendRequestControl friendRequestControl in ListOfFriendRequestControl)
            {
                if (friendRequestControl.ContactName.Text == usernameId)
                {
                    friendRequestControlToRemove = friendRequestControl;
                    break;
                }
            }
            if (friendRequestControlToRemove != null)
            {
                HandleFriendRequest(friendRequestControlToRemove);
            }

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
        #endregion

        #region Group Chat Creation Methods
        private void NewContactCustomButton_Click(object sender, EventArgs e)
        {
            if (_firstTimeEnteringFriendRequestZone)
            {
                _firstTimeEnteringFriendRequestZone = false;
                EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.PastFriendRequestsRequest;
                object messageContent = null;
                serverCommunicator.SendMessage(messageType, messageContent);
            }
            GroupCreatorBackgroundPanel.Visible = false;
            ContactManagementPanel.Visible = true;
            ChatBackgroundPanel.Visible = false;
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
            if (this.SelectedContactsPanel.Controls.Count > 0)
            {
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
            RestartContactControlListLocation();
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

        private void RemoveProfileControl(object sender, System.EventArgs e)
        {
            ProfileControl profileControl = sender as ProfileControl;
        }
        private void RestartGroupCreator()
        {
            List<ProfileControl> profileControlsCopy = new List<ProfileControl>(ProfileControlList);
            foreach (ProfileControl profileControl in profileControlsCopy)
            {
                HandleRemoveProfileControl(profileControl);
            }
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

        private void RestartProfileControlListLocation()
        {
            widthForProfileControl = 0;
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.Location = new System.Drawing.Point(widthForProfileControl, 0);
                widthForProfileControl += profile.Width + 10;
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

        private void GroupCreatorCustomButton_Click(object sender, EventArgs e)
        {
            //will create a new group and refresh everything about the last group created...
            string groupSubject = GroupSubjectCustomTextBox.TextContent;
            Image groupIcon = GroupIconCircularPictureBox.BackgroundImage;
            List<string> groupParticipants = new List<string>
            {
                ProfileDetailsHandler.Name
            };
            foreach (ProfileControl profileControl in ProfileControlList)
            {
                groupParticipants.Add(profileControl.Name);
            }
            byte[] groupIconBytes = ConvertHandler.ConvertImageToRawFormatBytes(groupIcon);
            ChatCreator chatCreator = new ChatCreator(groupSubject, groupParticipants, groupIconBytes);


            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.GroupCreatorRequest;
            object messageContent = chatCreator;
            serverCommunicator.SendMessage(messageType, messageContent);
            SetChatPanelVisible();
            RestartGroupCreator();
            HandleSwitchToGroupContactsSelection();

            GroupCreatorCustomButton.Enabled = false;
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
            this.SelectedContactsPanel.Location = new System.Drawing.Point(0, 100);
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
            GroupIconCircularPictureBox.BackgroundImage = null;
            GroupSubjectCustomTextBox.TextContent = "";
            GroupCreatorBackgroundPanel.Visible = true;
            this.GroupCreatorBackgroundPanel.Controls.Add(this.SelectedContactsPanel);
            this.SelectedContactsPanel.Location = new System.Drawing.Point(0, 100);
            EnableCloseForProfileControls();
            PanelHandler.SetPanelToSide(SelectedContactsPanel, ProfileControlList, true);
        }

        private void RestartGroupSubjectCustomButton_Click(object sender, EventArgs e)
        {
            GroupSubjectCustomTextBox.TextContent = "";
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
            GroupIconContextMenuStrip.Show(GroupIconCircularPictureBox, new System.Drawing.Point(GroupIconCircularPictureBox.Width / 2, GroupIconCircularPictureBox.Height * 3 / 4));
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
        private void EmojiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormHandler._emojiKeyboard == null)
            {
                FormHandler._emojiKeyboard = new EmojiKeyboard();
            }
            FormHandler._emojiKeyboard._isText = false;
            DialogResult result = FormHandler._emojiKeyboard.ShowDialog();

            if (result == DialogResult.OK)
            {
                GroupIconCircularPictureBox.BackgroundImage = FormHandler._emojiKeyboard.ImageToSend;
            }
        }

        private void TakePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleImageTaking(true);
        }
        #endregion

        #region Current Chat Methods
        private void SetFeaturePanelsVisibility(bool directChatVisible)
        {
            DirectChatFeaturesPanel.Visible = directChatVisible;
        }

        public void SetChatOnline(string contactName, bool toOnline, DateTime? lastSeenTime = null)
        {
            if (CurrentChatNameLabel.Text == contactName)
            {
                if (ChatStatusLabel.Visible) //to check it is a direct chat with that name...
                {
                    if (toOnline)
                    {
                        LastSeenOnlineLabel.Text = "Online";
                    }
                    else
                    {
                        LastSeenOnlineLabel.Text = TimeHandler.GetFormatTime(lastSeenTime);
                    }
                }
            }
        }
        public void ChangeUserStatus(string contactName, string status)
        {
            if (CurrentChatNameLabel.Text == contactName)
            {
                if (ChatStatusLabel.Visible) //to check it is a direct chat with that name...
                {
                    ChatStatusLabel.Text = $"status: {status}";
                }
            }
            foreach (ContactControl contactControl in ContactControlList)
            {
                if (contactControl.ContactName.Text == contactName)
                {
                    contactControl.ContactStatus.Text = status;
                }
            }
        }
        public void EnableDirectChatFeaturesPanel()
        {
            DirectChatFeaturesPanel.Enabled = true;
        }

        private void AudioCallCustomButton_Click(object sender, EventArgs e)
        {
            HandleCallRequest(EnumHandler.CommunicationMessageID_Enum.AudioCallRequest);
        }
        private void VideoCallCustomButton_Click(object sender, EventArgs e)
        {
            HandleCallRequest(EnumHandler.CommunicationMessageID_Enum.VideoCallRequest);
        }
        private void HandleCallRequest(EnumHandler.CommunicationMessageID_Enum callType)
        {
            EnumHandler.CommunicationMessageID_Enum messageType = callType;
            object messageContent = currentChatId;
            serverCommunicator.SendMessage(messageType, messageContent);
            DirectChatFeaturesPanel.Enabled = false;
        }
        #endregion
        #region Profile Piuture Reset Methods

        public void ChangeUserProfilePicture(string contactName, string profilePictureId, Image profilePicture)
        {
            if (CurrentChatNameLabel.Text == contactName)
            {
                if (ChatStatusLabel.Visible) //to check it is a direct chat with that name...
                {
                    CurrentPictureChatPictureBox.BackgroundImage = profilePicture;
                }
            }
            foreach (ChatControl chatControl in ChatControlListOfContacts)
            {
                if (chatControl.ChatName.Text == contactName)
                {
                    string chatId = chatControl.ChatId;
                    ChatDetails chat = ChatManager.GetChat(chatId);
                    if (chat is DirectChat)
                    {
                        chatControl.ProfilePicture.BackgroundImage = profilePicture;
                    }
                }
            }
            foreach (ContactControl contactControl in ContactControlList)
            {
                if (contactControl.ContactName.Text == contactName)
                {
                    contactControl.ProfilePicture.Image = profilePicture;
                }
            }
            HandleProfilePictureChange(contactName, profilePictureId);
        }
        public void HandleProfilePictureChange(string contactName, string profilePictureId)
        {
            Queue<string> chatIdsToChange = new Queue<string>();
            string name;
            foreach (ChatDetails chatDetails in ChatManager._chats)
            {
                if (chatDetails.UserExist(contactName))
                {
                    foreach (ChatParticipant chatParticipant in chatDetails.ChatParticipants)
                    {
                        name = chatParticipant.Username;
                        if (contactName == name)
                        {
                            chatParticipant.ProfilePicture = profilePictureId;
                        }
                    }
                    chatIdsToChange.Enqueue(chatDetails.ChatTagLineId);
                }
            }
            string chatId;
            while (chatIdsToChange.Count > 0)
            {
                chatId = chatIdsToChange.Dequeue();
                List<AdvancedMessageControl> currentMessageControls = AdvancedMessageControls[chatId];
                foreach (AdvancedMessageControl advancedMessageControl in currentMessageControls)
                {
                    if (advancedMessageControl.Username.Text == contactName)
                    {
                        advancedMessageControl.ProfilePicture.BackgroundImage = ProfilePictureImageList.GetImageByImageId(profilePictureId);
                    }
                }
            }
        }
        #endregion

        #region YouChat Option Methods

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


        #endregion

        #region Form Methods
        private void HandleImageTaking(bool isForGroupChat)
        {
            FormHandler._camera = new Camera
            {
                IsImageForGroupChat = isForGroupChat
            };
            DialogResult result = FormHandler._camera.ShowDialog();

            // Check if Form2 was closed successfully
            if (result == DialogResult.OK)
            {
                if (isForGroupChat)
                {
                    GroupIconCircularPictureBox.BackgroundImage = Camera.ImageToSend;
                }
                else
                {
                    Image imageData = Camera.ImageToSend;
                    SendImage(imageData);
                    Camera.ImageToSend = null;
                }
            }
        }


        private void UserFileCustomButton_Click(object sender, EventArgs e)
        {

            FormHandler._contactSharing = new ContactSharing();
            DialogResult result = FormHandler._contactSharing.ShowDialog();

            string contactData;
            if (result == DialogResult.OK)
            {
                contactData = ContactSharing.contactData;
                SendMessage(contactData);
            }
        }


        public void OpenWaitingForm()
        {
            FormHandler._waitingForm = new WaitingForm();
            this.Invoke(new Action(() => FormHandler._waitingForm.Show()));
        }
        public void CloseVideoCall()
        {
            FormHandler._videoCall.Close();
            FormHandler._videoCall.Dispose();
            EnableDirectChatFeaturesPanel();
        }
        public void CloseAudioCall()
        {
            FormHandler._audioCall.Close();
            FormHandler._audioCall.Dispose();
            EnableDirectChatFeaturesPanel();
        }
        public void StartAudioUdpConnection(string chatId, string friendName)
        {
            Contact contact = ContactManager.GetContact(friendName);
            Image profilePicture = contact.ProfilePicture;
            FormHandler._audioCall = new AudioCall(chatId, friendName, profilePicture);

            int portNumber = AudioServerCommunication.ConnectUdp("10.100.102.3", FormHandler._audioCall);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.UdpAudioConnectionRequest;
            object messageContent = portNumber.ToString();
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        public void StartVideoUdpConnection(string chatId, string friendName)
        {
            Contact contact = ContactManager.GetContact(friendName);
            Image profilePicture = contact.ProfilePicture;
            FormHandler._videoCall = new VideoCall(chatId, friendName, profilePicture);
            int audioPortNumber = AudioServerCommunication.ConnectUdp("10.100.102.3", FormHandler._videoCall);
            int videoPortNumber = VideoServerCommunication.ConnectUdp("10.100.102.3", FormHandler._videoCall);
            UdpPorts udpPorts = new UdpPorts(audioPortNumber, videoPortNumber);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.UdpVideoConnectionRequest;
            object messageContent = udpPorts;
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        private void CloseForm(Form form)
        {
            if (form != null)
            {
                this.Invoke(new Action(() => form.Hide()));
                form.Close();
                form.Dispose();
                form = null;
            }
        }
        public void OpenAudioCall()
        {
            CloseForm(FormHandler._waitingForm);
            CloseForm(FormHandler._profile);
            this.Invoke(new Action(() => FormHandler._audioCall.Show()));
            this.Invoke((Action)delegate { FormHandler._audioCall.SetIsAbleToSendToTrue(); });
            this.Hide();
        }
        public void OpenVideoCall()
        {
            CloseForm(FormHandler._waitingForm);
            CloseForm(FormHandler._profile);
            this.Invoke(new Action(() => FormHandler._videoCall.Show()));
            this.Invoke((Action)delegate { FormHandler._videoCall.SetIsAbleToSendToTrue(); });

            this.Hide();
        }
        public void CloseWaitingForm()
        {
            FormHandler._waitingForm.Hide();
            FormHandler._waitingForm.Close();
            FormHandler._waitingForm.Dispose();
            EnableDirectChatFeaturesPanel();
        }
        public void OpenCallInvitation(string chatId, string friendName, bool isVideoCall)
        {
            Contact contact = ContactManager.GetContact(friendName);
            Image profilePicture = contact.ProfilePicture;
            FormHandler._callInvitation = new CallInvitation(chatId, friendName, profilePicture, isVideoCall);
            FormHandler._callInvitation.Show();
            DirectChatFeaturesPanel.Enabled = false;

        }
        private void DrawingFileCustomButton_Click(object sender, EventArgs e)
        {
            FormHandler._paint = new AttachedFiles.PaintHandler.Paint();

            FormHandler._contactSharing = new ContactSharing();
            //ServerCommunication._contactSharing._isText = false;
            DialogResult result = FormHandler._paint.ShowDialog();

            Image imageData;
            if (result == DialogResult.OK)
            {
                imageData = AttachedFiles.PaintHandler.Paint.finalImage;
                SendImage(imageData);
                AttachedFiles.PaintHandler.Paint.finalImage = null;
            }
        }


        private void EmojiKeyBoardCustomButton_Click(object sender, EventArgs e)
        {
            if (FormHandler._emojiKeyboard == null)
            {
                FormHandler._emojiKeyboard = new EmojiKeyboard();
            }
            FormHandler._emojiKeyboard._isText = false;
            DialogResult result = FormHandler._emojiKeyboard.ShowDialog();

            Image imageData;
            if (result == DialogResult.OK)
            {
                imageData = FormHandler._emojiKeyboard.ImageToSend;
                FormHandler._emojiKeyboard.ImageToSend = null;
                SendImage(imageData);
            }
        }
        private void TakenImageFile_Click(object sender, EventArgs e)
        {
            HandleImageTaking(false);
        }

        private void ImageFileCustomButton_Click(object sender, EventArgs e)
        {
            FormHandler._imageSender = new ImageSender();
            DialogResult result = FormHandler._imageSender.ShowDialog();

            Image imageData;
            if (result == DialogResult.OK)
            {
                imageData = ImageSender.selectedImage;
                ImageSender.selectedImage = null;
                SendImage(imageData);
            }
        }

        private void ProfileCustomButton_Click(object sender, EventArgs e)
        {
            FormHandler._profile = new Profile();
            this.Invoke(new Action(() => FormHandler._profile.Show()));
            ProfileCustomButton.Enabled = false;
        }

        #endregion
        #region Message Sending Methods
        private void MessageSenderCustomButton_Click(object sender, EventArgs e)
        {
            if (MessageCustomTextBox.IsContainingValue())
            {
                string Message = MessageCustomTextBox.TextContent;
                SendMessage(Message);
                MessageCustomTextBox.TextContent = "";
            }
        }
        private void SendMessage(string messageContentValue)
        {
            DateTime messageTime = DateTime.Now;
            HandleYourMessages(messageContentValue, currentChatId, messageTime);
            JsonClasses.Message message = new JsonClasses.Message(ProfileDetailsHandler.Name, currentChatId, messageContentValue, messageTime);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.SendMessageRequest;
            object messageContent = message;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        private void SendImage(Image image)
        {
            DateTime messageTime = DateTime.Now;
            Image resizedImage = ResizeImage(image, 280, 180);
            HandleYourImageMessages(resizedImage, currentChatId, messageTime);
            byte[] imageBytes = ConvertHandler.ConvertImageToBytes(resizedImage);
            ImageContent imageContent = new ImageContent(imageBytes);
            JsonClasses.Message message = new JsonClasses.Message(ProfileDetailsHandler.Name, currentChatId, imageContent, messageTime);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.SendMessageRequest;
            object messageContent = message;
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        private void MessageCustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                MessageCustomTextBox.TextContent = "";
            }
        }
        #endregion
        
        #region Drawing Method

        private Image ResizeImage(Image originalImage, int desiredWidth, int desiredHeight)
        {
            return new Bitmap(originalImage, desiredWidth, desiredHeight);
        }

        #endregion



        #region Form Closing Method

        private void YouChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.Disconnect;
            object messageContent = null;
            serverCommunicator.SendMessage(messageType, messageContent);
            serverCommunicator.Disconnect();
            System.Windows.Forms.Application.ExitThread();
        }

        #endregion
    }
}
