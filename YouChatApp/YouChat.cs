using System;
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
    /// <summary>
    /// The "YouChat" class represents a form for managing the chat.
    /// </summary>
    /// <remarks>
    /// This class provides a range of functionalities, including adding friends, creating group chats, sending text messages, images, drawings, emojis, photos, creating video and audio calls, and more.
    /// </remarks>
    public partial class YouChat : Form
    {
        #region Private Fields

        /// <summary>
        /// The int "heightForMessages" represents the height for messages.
        /// </summary>
        private int heightForMessages = 10;

        /// <summary>
        /// The int "heightForChats" represents the height for chats.
        /// </summary>
        private int heightForChats;

        /// <summary>
        /// The int "heightForFriendRequests" represents the height for friend requests.
        /// </summary>
        private int heightForFriendRequests = 10;

        /// <summary>
        /// The int "heightForContacts" represents the height for contacts.
        /// </summary>
        private int heightForContacts;

        /// <summary>
        /// The int "widthForProfileControl" represents the width for the profile control.
        /// </summary>
        private int widthForProfileControl = 0;

        /// <summary>
        /// The bool "_firstTimeEnteringFriendRequestZone" indicates whether it is the first time entering the friend request zone.
        /// </summary>
        private bool _firstTimeEnteringFriendRequestZone = true;

        /// <summary>
        /// The int "ContactChatNumber" represents the number of contact chats.
        /// </summary>
        private int ContactChatNumber = 0;

        /// <summary>
        /// The int "ContactNumber" represents the number of contacts.
        /// </summary>
        private int ContactNumber = 0;

        /// <summary>
        /// The int "profileControlNumber" represents the profile control number.
        /// </summary>
        private int profileControlNumber = 0;

        /// <summary>
        /// The int "FriendRequestsNumber" represents the number of friend requests.
        /// </summary>
        private int FriendRequestsNumber = 0;

        /// <summary>
        /// The Panel "currentMessagePanel" represents the current message panel.
        /// </summary>
        private Panel currentMessagePanel;

        /// <summary>
        /// The Dictionary<string, int> "messageCount" represents the count of messages.
        /// </summary>
        private Dictionary<string, int> messageCount;

        /// <summary>
        /// The Dictionary<string, bool> "messageHistoryReceieved" represents the history of received messages.
        /// </summary>
        private Dictionary<string, bool> messageHistoryReceieved;

        /// <summary>
        /// The string "currentChatId" represents the ID of the current chat.
        /// </summary>
        private string currentChatId = "";

        #endregion

        #region Private Readonly Fields

        /// <summary>
        /// The readonly Image "AnonymousProfile" represents the anonymous profile image.
        /// </summary>
        private readonly Image AnonymousProfile = global::YouChatApp.Properties.Resources.AnonymousProfile;

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" represents the server communicator instance.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        #endregion

        #region Private Constants

        /// <summary>
        /// The constant int "messageGap" represents the gap between messages.
        /// </summary>
        private const int messageGap = 10;

        /// <summary>
        /// The constant string "ApprovalFriendRequestResponse" represents the response for approving a friend request.
        /// </summary>
        private const string ApprovalFriendRequestResponse = "Approval";

        /// <summary>
        /// The constant string "RejectionFriendRequestResponse" represents the response for rejecting a friend request.
        /// </summary>
        private const string RejectionFriendRequestResponse = "Rejection";

        #endregion

        #region Constructors

        /// <summary>
        /// The "YouChat" constructor initializes a new instance of the <see cref="YouChat"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up various components for the YouChat application,
        /// including initializing the server communicator, creating lists and dictionaries for managing messages and contacts,
        /// setting up search bars, placeholders for text boxes, and sending a message to the server to request user details.
        /// It also adjusts the layout of panels and labels within the form.
        /// </remarks>
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

        /// <summary>
        /// The "SetProfilePicture" method sets the profile picture, user ID label, and sends a contact information request message to the server.
        /// </summary>
        /// <remarks>
        /// This method updates the UI elements to display the user's profile picture and user ID. It also sends a message to the server to request contact information.
        /// </remarks>
        public void SetProfilePicture()
        {
            ProfileCustomButton.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture;
            UserIDLabel.Text += " " + UserProfile.ProfileDetailsHandler.Name + "#" + UserProfile.ProfileDetailsHandler.TagLine;

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.ContactInformationRequest;
            object messageContent = null;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "SetProfileButtonEnabled" method enables the profile button and sets its background image to the user's profile picture.
        /// </summary>
        /// <remarks>
        /// This method updates the profile button to be enabled and displays the user's profile picture on the button.
        /// </remarks>
        public void SetProfileButtonEnabled()
        {
            ProfileCustomButton.Enabled = true;
            ProfileCustomButton.BackgroundImageLayout = ImageLayout.Zoom;
            ProfileCustomButton.BackgroundImage = ProfileDetailsHandler.ProfilePicture;
        }

        #endregion

        #region Chat Methods

        /// <summary>
        /// The "AddChatControl" method adds a new chat control to the form based on the provided chat details.
        /// </summary>
        /// <param name="chat">The chat details used for creating the chat control.</param>
        /// <remarks>
        /// This method creates a new chat control based on the type of chat (DirectChat or GroupChat) and adds it to the form's controls.
        /// It also creates a message panel for the chat to display messages.
        /// The chat control contains information such as the chat name, last message content, last message time, and profile picture.
        /// The method sets event handlers for clicking on the chat control and adds the chat control to the form's controls and chat panel.
        /// </remarks>
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

        /// <summary>
        /// The "SetChatControlListOfContacts" method sets the chat controls for each chat in the ChatManager.
        /// </summary>
        /// <remarks>
        /// This method iterates through each chat in the ChatManager's list of chats and adds a corresponding chat control
        /// using the "AddChatControl" method.
        /// </remarks>
        public void SetChatControlListOfContacts()
        {
            foreach (ChatDetails chat in ChatManager.Chats)
            {
                AddChatControl(chat);
            }
        }

        /// <summary>
        /// The "HandleNewGroupChatCreation" method handles the creation of a new group chat.
        /// </summary>
        /// <param name="chat">The chat details of the new group chat.</param>
        /// <remarks>
        /// This method adds a new chat control for the newly created group chat using the "AddChatControl" method.
        /// </remarks>
        public void HandleNewGroupChatCreation(ChatDetails chat)
        {
            AddChatControl(chat);
        }

        /// <summary>
        /// The "SearchChats" method handles the search functionality for chats.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method searches for chats based on the text entered in the ChatSearchBar.
        /// It adjusts the location and visibility of chat controls accordingly to display search results.
        /// </remarks>
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

        /// <summary>
        /// The "ChatControl_Click" method handles the event when a chat control is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the chatId from the clicked chat control and passes it to the "HandleChats" method to manage the chat interaction.
        /// </remarks>
        private void ChatControl_Click(object sender, EventArgs e)
        {
            ChatControl chatControl = (ChatControl)sender;
            string chatId = chatControl.ChatId;
            HandleChats(chatControl, chatId);
        }

        /// <summary>
        /// The "HandleChats" method manages the interaction with a chat.
        /// </summary>
        /// <param name="chatControl">The chat control associated with the chat.</param>
        /// <param name="chatId">The unique identifier of the chat.</param>
        /// <remarks>
        /// This method focuses the chat control, retrieves the chat's message history if it's the first click on the chat,
        /// updates the message panel's visibility, sets the current chat ID and message panel, and updates the chat details
        /// such as name, profile picture, status, and participants.
        /// </remarks>
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

        /// <summary>
        /// The "HandleCallMessageSelection" method handles the selection of a chat for a call message.
        /// </summary>
        /// <param name="chatId">The unique identifier of the chat.</param>
        /// <remarks>
        /// This method iterates through the list of chat controls to find the chat control with the specified chat ID
        /// and then calls the "HandleChats" method to manage the interaction with the selected chat.
        /// </remarks>
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

        /// <summary>
        /// The "HandleChatControlProcessForSendingMessage" method manages the chat control process for sending a message.
        /// </summary>
        /// <param name="chatControl">The chat control for which the process is being handled.</param>
        /// <remarks>
        /// This method sets the chat control to the side, removes it from its current position in the list of chat controls,
        /// and inserts it at the beginning of the list. It then adjusts the location of each chat control in the list accordingly.
        /// </remarks>
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

        /// <summary>
        /// The "HandleYourMessages" method handles messages sent by the current user.
        /// </summary>
        /// <param name="MessageContent">The content of the message.</param>
        /// <param name="chatId">The ID of the chat where the message is sent.</param>
        /// <param name="SendMessageTime">The time when the message is sent.</param>
        /// <remarks>
        /// This method updates the last message information for the chat, then adds the message to the chat.
        /// </remarks>
        public void HandleYourMessages(string MessageContent, string chatId, DateTime SendMessageTime)
        {
            string username = UserProfile.ProfileDetailsHandler.Name;
            string time = TimeHandler.GetFormatTime(SendMessageTime);
            ChangeChatLastMessageInformation(chatId, SendMessageTime, MessageContent, username, time);
            AddMessageByUser(MessageContent, chatId, time, username, SendMessageTime);
        }

        /// <summary>
        /// The "HandleYourImageMessages" method handles image messages sent by the current user.
        /// </summary>
        /// <param name="messageImage">The image to be sent.</param>
        /// <param name="chatId">The ID of the chat where the image is sent.</param>
        /// <param name="SendMessageTime">The time when the image is sent.</param>
        /// <remarks>
        /// This method updates the last message information for the chat, then adds the image message to the chat.
        /// </remarks>
        public void HandleYourImageMessages(Image messageImage, string chatId, DateTime SendMessageTime)
        {
            string username = UserProfile.ProfileDetailsHandler.Name;
            string time = TimeHandler.GetFormatTime(SendMessageTime);
            ChangeChatLastMessageInformation(chatId, SendMessageTime, "Image", username, time);
            AddImageMessageByUser(messageImage, chatId, time, username, SendMessageTime);
        }

        /// <summary>
        /// The "HandleYourImageMessages" method handles image messages sent by the current user.
        /// </summary>
        /// <param name="messageImage">The image to be sent.</param>
        /// <param name="chatId">The ID of the chat where the image is sent.</param>
        /// <param name="SendMessageTime">The time when the image is sent.</param>
        /// <remarks>
        /// This method updates the last message information for the chat, then adds the image message to the chat.
        /// </remarks>
        private void AddImageMessageByUser(Image messageImage, string chatId, string time, string username, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByUser(chatId, time, username, messageDateTime);
            advancedMessageControl.Image.BackgroundImage = messageImage;
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.Image;
            advancedMessageControl.AddMessageDeleteHandler(DeleteMessage);
            advancedMessageControl.AddAfterMessageDeleteHandler(AfterDeleteMessage);
        }

        /// <summary>
        /// The "AddMessageByUser" method adds a text message sent by the current user to the chat.
        /// </summary>
        /// <param name="MessageContent">The content of the text message.</param>
        /// <param name="chatId">The ID of the chat where the message is sent.</param>
        /// <param name="time">The time when the message is sent.</param>
        /// <param name="username">The username of the current user.</param>
        /// <param name="messageDateTime">The date and time when the message is sent.</param>
        /// <remarks>
        /// This method adds a text message to the chat. It creates an AdvancedMessageControl 
        /// instance with the message content, sets the message type to text, and attaches 
        /// event handlers for message deletion.
        /// </remarks>
        private void AddMessageByUser(string MessageContent, string chatId, string time, string username, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByUser(chatId, time, username, messageDateTime);
            advancedMessageControl.MessageContent.Text = MessageContent;
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.Text;
            advancedMessageControl.AddMessageDeleteHandler(DeleteMessage);
            advancedMessageControl.AddAfterMessageDeleteHandler(AfterDeleteMessage);
        }

        /// <summary>
        /// The "AddDeletedMessageByUser" method adds a deleted message sent by the current user to the chat.
        /// </summary>
        /// <param name="chatId">The ID of the chat where the message was deleted.</param>
        /// <param name="time">The time when the message was deleted.</param>
        /// <param name="username">The username of the current user.</param>
        /// <param name="messageDateTime">The date and time when the message was sent.</param>
        /// <remarks>
        /// This method adds a deleted message to the chat. It creates an AdvancedMessageControl 
        /// instance with the message type set to deleted, handles the deletion process, and brings 
        /// the message control to the front for visibility.
        /// </remarks>
        private void AddDeletedMessageByUser(string chatId, string time, string username, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByUser(chatId, time, username, messageDateTime);
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.DeletedMessage;
            advancedMessageControl.HandleDelete();
            advancedMessageControl.BringToFront();
        }

        /// <summary>
        /// The "DeleteMessage" method handles the deletion of a message by the current user.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method constructs a message object representing the deleted message and sends 
        /// a delete message request to the server. It also updates the chat's last message 
        /// information if the deleted message was the last message in the chat.
        /// </remarks>
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
                        chat.SetToolTip();
                    }
                }
            }
        }

        /// <summary>
        /// The "AfterDeleteMessage" method handles actions that occur after a message is deleted.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method restarts the display of chat messages after a message is deleted.
        /// </remarks>
        private void AfterDeleteMessage(object sender, EventArgs e)
        {
            string chatId = currentChatId;
            RestartChatMessages(chatId);
        }

        /// <summary>
        /// The "HandleMessagesByOthers" method handles messages sent by other users in a chat.
        /// </summary>
        /// <param name="messageSenderName">The username of the message sender.</param>
        /// <param name="chatId">The ID of the chat where the message is sent.</param>
        /// <param name="messageDateTime">The date and time when the message is sent.</param>
        /// <param name="messageContent">The content of the message.</param>
        /// <remarks>
        /// This method updates the last message information for the chat and adds the message to the chat's message list if the message history has been received.
        /// </remarks>
        public void HandleMessagesByOthers(string messageSenderName, string chatId, DateTime messageDateTime, string messageContent)
        {
            string time = TimeHandler.GetFormatTime(messageDateTime);
            ChangeChatLastMessageInformation(chatId, messageDateTime, messageContent, messageSenderName, time);
            if (messageHistoryReceieved[chatId])
                AddTextMessageByOthers(messageContent, chatId, time, messageSenderName, messageDateTime);
        }

        /// <summary>
        /// The "HandleDeletedMessage" method handles the deletion of a message by updating the chat's last message information and marking the message as deleted in the chat's message list.
        /// </summary>
        /// <param name="messageSenderName">The username of the message sender.</param>
        /// <param name="chatId">The ID of the chat where the message is deleted.</param>
        /// <param name="messageDateTime">The date and time when the message is deleted.</param>
        /// <param name="messageContent">The content of the deleted message.</param>
        /// <remarks>
        /// This method first checks if the deleted message is the last message in the chat, and if so, updates the chat's last message content to indicate that it was deleted.
        /// It then iterates over the chat's message controls to find the deleted message and marks it as deleted, visually updating the chat interface.
        /// Finally, it restarts the chat messages to ensure the interface reflects the most recent changes.
        /// </remarks>
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
                        chat.SetToolTip();
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

        /// <summary>
        /// The "HandleImageMessagesByOthers" method handles image messages sent by other users in the chat.
        /// </summary>
        /// <param name="messageSenderName">The username of the sender of the image message.</param>
        /// <param name="chatId">The ID of the chat where the image message is sent.</param>
        /// <param name="messageDateTime">The date and time when the image message is sent.</param>
        /// <param name="messageImage">The image sent as a message.</param>
        /// <remarks>
        /// This method updates the chat's last message information with the image message details. 
        /// If the message history has been received for the chat, it adds the image message to the chat.
        /// </remarks>
        public void HandleImageMessagesByOthers(string messageSenderName, string chatId, DateTime messageDateTime, Image messageImage)
        {
            string time = TimeHandler.GetFormatTime(messageDateTime);
            ChangeChatLastMessageInformation(chatId, messageDateTime, "Image", messageSenderName, time);
            if (messageHistoryReceieved[chatId])
                AddImageMessageByOthers(messageImage, chatId, time, messageSenderName, messageDateTime);
        }

        /// <summary>
        /// The "AddDeletedMessageByOthers" method adds a deleted message indication by another user to the chat.
        /// </summary>
        /// <param name="chatId">The ID of the chat where the message was deleted.</param>
        /// <param name="time">The time of the deleted message.</param>
        /// <param name="messageSenderName">The name of the user who sent the deleted message.</param>
        /// <param name="messageDateTime">The date and time when the message was deleted.</param>
        /// <remarks>
        /// This method creates an AdvancedMessageControl instance representing the deleted message,
        /// sets its message type to indicate deletion, and brings it to the front in the chat display.
        /// </remarks>
        private void AddDeletedMessageByOthers(string chatId, string time, string messageSenderName, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByOthers(chatId, time, messageSenderName, messageDateTime);
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.DeletedMessage;
            advancedMessageControl.HandleDelete();
            advancedMessageControl.BringToFront();
        }

        /// <summary>
        /// The "AddImageMessageByOthers" method adds an image message sent by another user to the chat.
        /// </summary>
        /// <param name="messageImage">The image sent by the other user.</param>
        /// <param name="chatId">The ID of the chat where the image message is sent.</param>
        /// <param name="time">The time when the image message is sent.</param>
        /// <param name="messageSenderName">The name of the user who sent the image message.</param>
        /// <param name="messageDateTime">The date and time when the image message is sent.</param>
        /// <remarks>
        /// This method creates an AdvancedMessageControl instance representing the image message,
        /// sets its message type to indicate an image, and adds it to the chat display.
        /// </remarks>
        private void AddImageMessageByOthers(Image messageImage, string chatId, string time, string messageSenderName, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByOthers(chatId, time, messageSenderName, messageDateTime);
            advancedMessageControl.Image.BackgroundImage = messageImage;
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.Image;
        }

        /// <summary>
        /// The "AddMessage" method adds a message to the chat panel.
        /// </summary>
        /// <param name="chatId">The ID of the chat where the message is added.</param>
        /// <param name="time">The time when the message is added.</param>
        /// <param name="username">The username of the message sender.</param>
        /// <param name="messageDateTime">The date and time of the message.</param>
        /// <param name="chatPanel">The panel where the chat is displayed.</param>
        /// <returns>The AdvancedMessageControl instance representing the added message.</returns>
        /// <remarks>
        /// This method calculates the position of the new message based on the existing messages in the chat,
        /// creates an AdvancedMessageControl instance for the new message, and adds it to the chat panel.
        /// It also ensures that the chat panel scrolls to display the new message if necessary.
        /// </remarks>
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

        /// <summary>
        /// The "AddMessageByUser" method adds a message sent by the current user to the chat panel.
        /// </summary>
        /// <param name="chatId">The ID of the chat where the message is added.</param>
        /// <param name="time">The time when the message is added.</param>
        /// <param name="username">The username of the current user.</param>
        /// <param name="messageDateTime">The date and time of the message.</param>
        /// <returns>The AdvancedMessageControl instance representing the added message.</returns>
        /// <remarks>
        /// This method adds a message to the chat panel as if it was sent by the current user.
        /// It sets the profile picture, message background color, and other properties specific to the current user's messages.
        /// </remarks>
        private AdvancedMessageControl AddMessageByUser(string chatId, string time, string username, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessage(chatId, time, username, messageDateTime, currentMessagePanel);
            advancedMessageControl.ProfilePicture.BackgroundImage = UserProfile.ProfileDetailsHandler.ProfilePicture;
            advancedMessageControl.IsYourMessage = true;
            advancedMessageControl.SetBackColorByMessageSender();
            return advancedMessageControl;
        }

        /// <summary>
        /// The "AddMessageByOthers" method adds a message sent by another user to the chat.
        /// </summary>
        /// <param name="chatId">The ID of the chat where the message is sent.</param>
        /// <param name="time">The time when the message is sent.</param>
        /// <param name="messageSenderName">The name of the user who sent the message.</param>
        /// <param name="messageDateTime">The date and time when the message is sent.</param>
        /// <returns>The AdvancedMessageControl representing the added message.</returns>
        /// <remarks>
        /// This method retrieves the sender's profile picture and adds the message to the chat display.
        /// It sets the message background color based on the sender and returns the AdvancedMessageControl instance.
        /// </remarks>
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

        /// <summary>
        /// The "AddTextMessageByOthers" method adds a text message sent by another user to the chat.
        /// </summary>
        /// <param name="messageContent">The content of the text message.</param>
        /// <param name="chatId">The ID of the chat where the message is sent.</param>
        /// <param name="time">The time when the message is sent.</param>
        /// <param name="messageSenderName">The name of the user who sent the message.</param>
        /// <param name="messageDateTime">The date and time when the message is sent.</param>
        /// <remarks>
        /// This method creates an AdvancedMessageControl instance representing the text message,
        /// sets its content and type, and adds it to the chat display.
        /// </remarks>
        private void AddTextMessageByOthers(string messageContent, string chatId, string time, string messageSenderName, DateTime messageDateTime)
        {
            AdvancedMessageControl advancedMessageControl = AddMessageByOthers(chatId, time, messageSenderName, messageDateTime);
            advancedMessageControl.MessageContent.Text = messageContent;
            advancedMessageControl.MessageType = YouChatApp.EnumHandler.MessageType_Enum.Text;
        }

        /// <summary>
        /// The "HandleMessageHistory" method handles the history of messages received from the server.
        /// </summary>
        /// <param name="messages">The list of messages received from the server.</param>
        /// <remarks>
        /// This method processes the list of messages received from the server. It first clears the existing
        /// messages in the chat to prepare for the new messages. Then, it iterates over each message in the
        /// list and determines the type of message (text, image, or deleted message) and calls the appropriate
        /// method to add the message to the chat display.
        /// </remarks>
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

        /// <summary>
        /// The "HandleMessageHistory" method handles the message history for a specific chat identified by its chatId.
        /// </summary>
        /// <param name="chatId">The unique identifier of the chat for which the message history is being handled.</param>
        /// <remarks>
        /// This method sets the message count for the specified chatId to 0 and marks the message history as received for that chat.
        /// </remarks>
        public void HandleMessageHistory(string chatId)
        {
            messageCount[chatId] = 0;
            messageHistoryReceieved[chatId] = true;
        }

        /// <summary>
        /// The "ChangeChatLastMessageInformation" method updates the last message information for a chat.
        /// </summary>
        /// <param name="chatId">The ID of the chat.</param>
        /// <param name="messageDateTime">The date and time of the message.</param>
        /// <param name="messageContent">The content of the message.</param>
        /// <param name="messageSenderName">The name of the message sender.</param>
        /// <param name="displayTime">The formatted display time of the message.</param>
        /// <remarks>
        /// This method updates the last message content, sender name, and time for the specified chat.
        /// It also updates the chat's position in the list of chats to reflect the change in last message.
        /// Additionally, it updates the last message information in the chat control for the specified chat.
        /// </remarks>
        private void ChangeChatLastMessageInformation(string chatId, DateTime messageDateTime, string messageContent, string messageSenderName, string displayTime)
        {
            ChatDetails chatDetails = ChatHandler.ChatManager.GetChat(chatId);
            chatDetails.LastMessageContent = messageContent;
            chatDetails.LastMessageTime = messageDateTime;
            chatDetails.LastMessageSenderName = messageSenderName;
            ChatManager.Chats.Remove(chatDetails);
            ChatManager.Chats.Add(chatDetails);

            List<ChatControl> ChatControlListOfContactsCopy = new List<ChatControl>(ChatControlListOfContacts);
            foreach (ChatControl chat in ChatControlListOfContactsCopy)
            {
                if (chat.ChatId == chatId)
                {
                    chat.LastMessageDateTime = messageDateTime;
                    chat.LastMessageContent.Text = chatDetails.GetLastMessageData();
                    chat.LastMessageTime.Text = displayTime;
                    chat.SetToolTip();
                    chat.SetLastMessageTimeLocation();
                    HandleChatControlProcessForSendingMessage(chat);
                }
            }
        }

        /// <summary>
        /// The "RestartChatMessages" method rearranges the chat messages in the specified chat to ensure correct display after changes.
        /// </summary>
        /// <param name="chatId">The ID of the chat whose messages need to be rearranged.</param>
        /// <remarks>
        /// This method repositions the chat messages in the specified chat panel to ensure that they are displayed correctly
        /// after changes such as adding or deleting messages.
        /// </remarks>
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

        /// <summary>
        /// The "AddContactControl" method adds a new contact control to the contact list and displays it in the specified location.
        /// </summary>
        /// <param name="contact">The contact to add.</param>
        /// <param name="location">The index in the contact list where the contact control should be inserted.</param>
        /// <remarks>
        /// This method creates a new ContactControl instance with the specified contact's details,
        /// sets its location, name, tab index, and event handler for click events, and then adds it to the contact list.
        /// Finally, it updates the contact number.
        /// </remarks>
        private void AddContactControl(Contact contact, int location)
        {
            ContactControl contactControl = new ContactControl();
            contactControl.Location = new System.Drawing.Point(0, heightForContacts);
            contactControl.Name = contact.Name;
            contactControl.TabIndex = 0;
            contactControl.ContactName.Text = contact.Name;
            contactControl.ContactStatus.Text = contact.Status;
            contactControl.ProfilePicture.Image = contact.ProfilePicture;
            contactControl.SetToolTip();
            contactControl.Click += new EventHandler(this.ContactControl_Click);

            this.ContactControlList.Insert(location, contactControl);
            this.Controls.Add(contactControl);
            this.GroupCreatorPanel.Controls.Add(contactControl);
            ContactNumber++;
        }

        /// <summary>
        /// The "SetContactControlList" method sets the contact control list with the provided list of contact details.
        /// </summary>
        /// <param name="contactDetailsList">The list of contact details to set the contact control list with.</param>
        /// <remarks>
        /// This method iterates over the provided list of contact details, creates a new Contact instance for each contact details,
        /// and adds the contact to the ContactManager. It then updates the heightForContacts based on the current contacts in the ContactManager
        /// and adds each contact to the contact control list using the AddContactControl method.
        /// </remarks>
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

        /// <summary>
        /// The "ContactControl_Click" method handles the click event of a contact control.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the ContactControl instance from the sender object, 
        /// gets the contact name from the control, and retrieves the corresponding contact 
        /// from the ContactManager. If the contact exists and a profile control for the contact 
        /// does not already exist, it sets the WasSelected property of the contact control to true 
        /// and adds a profile control for the contact.
        /// </remarks>
        private void ContactControl_Click(object sender, System.EventArgs e)
        {
            ContactControl contactControl = (ContactControl)sender;
            string ContactName = contactControl.ContactName.Text;
            Contact contact = ContactManager.GetContact(ContactName);
            if (contact != null)
            {
                Image ContactProfilePicture = contact.ProfilePicture;
                if (!ProfileControlIsExist(ContactName))
                {
                    contactControl.WasSelected = true;
                    AddProfileControl(ContactName, ContactProfilePicture);
                }
            }
        }

        /// <summary>
        /// The "SearchContacts" method handles the search functionality for contacts.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method adjusts the location of the GroupCreatorPanel based on whether there are selected contacts.
        /// It then retrieves the search text from the GroupCreatorSearchBar and removes any trailing spaces.
        /// If the search text is empty, it resets the contact control list location.
        /// Otherwise, it iterates over the ContactControlList and sets the visibility of each contact control 
        /// based on whether its name matches the search text.
        /// </remarks>
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

        /// <summary>
        /// The "CancelContactControlSelection" method cancels the selection of a contact control with the specified name.
        /// </summary>
        /// <param name="ContactName">The name of the contact control to cancel the selection for.</param>
        /// <remarks>
        /// This method iterates over the ContactControlList and sets the WasSelected property to false for the contact control
        /// with the specified name, effectively canceling its selection.
        /// </remarks>
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

        /// <summary>
        /// The "RestartContactControlListLocation" method resets the location and visibility of contact controls in the contact control list.
        /// </summary>
        /// <remarks>
        /// This method iterates over the ContactControlList and resets the location and visibility of each contact control.
        /// For each contact control that was not selected, it sets the location to a new point and updates the heightForContacts.
        /// For each contact control that was selected, it hides the control.
        /// </remarks>
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

        /// <summary>
        /// The "HandleSuccessfulFriendRequest" method handles a successful friend request by adding the contact to the user's contact list and adding a chat control for the new contact.
        /// </summary>
        /// <param name="contact">The contact that has been successfully added as a friend.</param>
        /// <param name="chat">The chat details for the new contact.</param>
        /// <remarks>
        /// This method determines the location in the user's contact list for the new contact and adjusts the heightForContacts accordingly.
        /// It then adds the new contact control to the contact list at the determined location.
        /// Finally, it adds a chat control for the new contact.
        /// </remarks>
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

        /// <summary>
        /// The "SetListOfFriendRequestControl" method sets the list of friend request controls based on the provided list of past friend requests.
        /// </summary>
        /// <param name="pastFriendRequests">The object containing the list of past friend requests.</param>
        /// <remarks>
        /// This method retrieves the list of friend requests from the provided PastFriendRequests object
        /// and iterates over each past friend request to add a friend request control for it.
        /// </remarks>
        public void SetListOfFriendRequestControl(PastFriendRequests pastFriendRequests)
        {
            List<PastFriendRequest> friendRequests = pastFriendRequests.FriendRequests;
            foreach (PastFriendRequest pastFriendRequest in friendRequests)
            {
                AddFriendRequest(pastFriendRequest);
            }
        }

        /// <summary>
        /// The "HandleNewFriendRequest" method handles a new friend request by adding a friend request control if it's not the first time entering the friend request zone.
        /// </summary>
        /// <param name="pastFriendRequest">The past friend request to handle.</param>
        /// <remarks>
        /// This method checks if it's the first time entering the friend request zone and only adds a friend request control if it's not.
        /// </remarks>
        public void HandleNewFriendRequest(PastFriendRequest pastFriendRequest)
        {
            if (!_firstTimeEnteringFriendRequestZone)
                AddFriendRequest(pastFriendRequest);
        }

        /// <summary>
        /// The "AddFriendRequest" method adds a friend request control for the specified past friend request.
        /// </summary>
        /// <param name="pastFriendRequest">The past friend request for which to add the friend request control.</param>
        /// <remarks>
        /// This method adds a new FriendRequestControl to the ListOfFriendRequestControl at the beginning of the list.
        /// It sets various properties of the control, such as location, name, tab index, contact name, friend request time, profile picture, and event handlers for approval and refusal.
        /// Additionally, it updates the FriendRequestsNumber, sets the tool tip for the control, and updates the location of all friend request controls in the list.
        /// </remarks>
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

        /// <summary>
        /// The "RestartListOfFriendRequestControlLocation" method resets the location of friend request controls in the list.
        /// </summary>
        /// <remarks>
        /// This method sets the location of each FriendRequestControl in the ListOfFriendRequestControl to stack them vertically.
        /// It also updates the heightForFriendRequests variable to reflect the total height of all friend request controls.
        /// </remarks>
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

        /// <summary>
        /// The "HandleFriendRequestApproval" method handles the approval of a friend request.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the FriendRequestControl instance from the sender object, sets the friend request status to "Approved",
        /// and then calls the HandleFriendRequestResponse and HandleFriendRequest methods to process the approval.
        /// </remarks>
        public void HandleFriendRequestApproval(object sender, EventArgs e)
        {
            FriendRequestControl friendRequestControl = ((FriendRequestControl)(sender));
            string friendRequestStatus = ApprovalFriendRequestResponse;
            HandleFriendRequestResponse(friendRequestControl, friendRequestStatus);
            HandleFriendRequest(friendRequestControl);
        }

        /// <summary>
        /// The "HandleFriendRequestRefusal" method handles the refusal of a friend request.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the FriendRequestControl instance from the sender object, sets the friend request status to "Rejected",
        /// and then calls the HandleFriendRequestResponse and HandleFriendRequest methods to process the refusal.
        /// </remarks>
        public void HandleFriendRequestRefusal(object sender, EventArgs e)
        {
            FriendRequestControl friendRequestControl = ((FriendRequestControl)(sender));
            string friendRequestStatus = RejectionFriendRequestResponse;
            HandleFriendRequestResponse(friendRequestControl, friendRequestStatus);
            HandleFriendRequest(friendRequestControl);
        }

        /// <summary>
        /// The "HandleFriendRequest" method handles the removal of a friend request control from the list and panel.
        /// </summary>
        /// <param name="friendRequestControl">The friend request control to handle.</param>
        /// <remarks>
        /// This method removes the specified friend request control from the ListOfFriendRequestControl and the FriendRequestPanel,
        /// disposes of the control, updates the FriendRequestsNumber, and then restarts the location of all friend request controls in the list.
        /// </remarks>
        private void HandleFriendRequest(FriendRequestControl friendRequestControl)
        {
            this.ListOfFriendRequestControl.Remove(friendRequestControl);
            FriendRequestPanel.Controls.Remove(friendRequestControl);
            friendRequestControl.Dispose();
            FriendRequestsNumber--;
            RestartListOfFriendRequestControlLocation();
        }

        /// <summary>
        /// The "HandleFriendRequestResponse" method handles the response to a friend request by sending a message to the server.
        /// </summary>
        /// <param name="friendRequestControl">The friend request control for which the response is being handled.</param>
        /// <param name="friendRequestStatus">The status of the friend request response ("Approved" or "Rejected").</param>
        /// <remarks>
        /// This method creates a FriendRequestResponseDetails object containing the sender name and response status,
        /// and then sends a message to the server with the message type set to FriendRequestResponseSender and the message content set to the response details.
        /// </remarks>
        private void HandleFriendRequestResponse(FriendRequestControl friendRequestControl, string friendRequestStatus)
        {
            string friendRequestSenderName = friendRequestControl.ContactName.Text;
            FriendRequestResponseDetails friendRequestResponseDetails = new FriendRequestResponseDetails(friendRequestSenderName, friendRequestStatus);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.FriendRequestResponseSender;
            object messageContent = friendRequestResponseDetails;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "FriendRequestSenderCustomButton_Click" method handles the click event of the custom button for sending a friend request.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the username ID and tagline from the custom text boxes, creates a FriendRequestDetails object with the details,
        /// and then sends a message to the server with the message type set to FriendRequestSender and the message content set to the request details.
        /// It then searches for a matching friend request control in the ListOfFriendRequestControl and removes it if found using the HandleFriendRequest method.
        /// Finally, it clears the custom text boxes for the next request.
        /// </remarks>
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

        /// <summary>
        /// The "FriendRequestFields_TextChangedEvent" method handles the text changed event for the friend request fields.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the username ID and tagline fields contain values.
        /// If both fields contain values, it enables the FriendRequestSenderCustomButton; otherwise, it disables the button.
        /// </remarks>
        private void FriendRequestFields_TextChangedEvent(object sender, EventArgs e)
        {
            bool NameIdField = UserIdCustomTextBox.IsContainingValue();
            bool TagLineField = UserTaglineCustomTextBox.IsContainingValue();
            if (NameIdField && TagLineField)
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

        /// <summary>
        /// The "NewContactCustomButton_Click" method handles the click event of the custom button for adding a new contact.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// If it's the first time entering the friend request zone, this method sends a message to the server to request past friend requests.
        /// It then hides the GroupCreatorBackgroundPanel, shows the ContactManagementPanel, and hides the ChatBackgroundPanel.
        /// </remarks>
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

        /// <summary>
        /// The "AddProfileControl" method adds a new profile control for a contact to the selected contacts panel.
        /// </summary>
        /// <param name="name">The name of the contact.</param>
        /// <param name="profilePicture">The profile picture of the contact.</param>
        /// <remarks>
        /// This method creates a new ProfileControl instance with the specified name and profile picture,
        /// sets its location, size, tab index, and event handlers, and then adds it to the ProfileControlList and SelectedContactsPanel.
        /// It also updates the layout of the GroupCreatorPanel and handles the display of current chat participants.
        /// </remarks>
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

        /// <summary>
        /// The "ProfileControlIsExist" method checks if a profile control with the specified name already exists in the ProfileControlList.
        /// </summary>
        /// <param name="name">The name of the profile control to check for existence.</param>
        /// <returns>True if a profile control with the specified name exists; otherwise, false.</returns>
        /// <remarks>
        /// This method iterates through the ProfileControlList and checks if any profile control's name matches the specified name.
        /// If a match is found, it returns true; otherwise, it returns false.
        /// </remarks>
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

        /// <summary>
        /// The "RemoveProfileControl" method handles the removal of a profile control from the selected contacts panel.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the profile control from the sender object, and then calls the HandleRemoveProfileControl method to remove it.
        /// </remarks>
        private void RemoveProfileControl(object sender, System.EventArgs e)
        {
            ProfileControl profileControl = sender as ProfileControl;
            HandleRemoveProfileControl(profileControl);
        }

        /// <summary>
        /// The "RestartGroupCreator" method clears all profile controls from the selected contacts panel.
        /// </summary>
        /// <remarks>
        /// This method creates a copy of the ProfileControlList and iterates through the copy to remove each profile control
        /// using the HandleRemoveProfileControl method, effectively clearing the selected contacts panel.
        /// </remarks>
        private void RestartGroupCreator()
        {
            List<ProfileControl> profileControlsCopy = new List<ProfileControl>(ProfileControlList);
            foreach (ProfileControl profileControl in profileControlsCopy)
            {
                HandleRemoveProfileControl(profileControl);
            }
        }

        /// <summary>
        /// The "HandleRemoveProfileControl" method handles the removal of a profile control from the selected contacts panel.
        /// </summary>
        /// <param name="profileControl">The profile control to be removed.</param>
        /// <remarks>
        /// This method sets the GroupCreatorPanel to the side of the ContactControlList, cancels the selection of the contact associated with the profile control,
        /// removes the profile control from the ProfileControlList and SelectedContactsPanel, disposes of the profile control,
        /// updates the profile control number, restarts the location of the profile controls in the list, adjusts the size of the GroupCreatorPanel if needed,
        /// and then restarts the location of the contact controls and updates the current chat participants.
        /// </remarks>
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

        /// <summary>
        /// The "RestartProfileControlListLocation" method resets the location of all profile controls in the ProfileControlList.
        /// </summary>
        /// <remarks>
        /// This method iterates through the ProfileControlList and resets the location of each profile control based on the widthForProfileControl variable,
        /// which tracks the accumulated width of the profile controls. It then updates the widthForProfileControl for the next profile control.
        /// </remarks>
        private void RestartProfileControlListLocation()
        {
            widthForProfileControl = 0;
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.Location = new System.Drawing.Point(widthForProfileControl, 0);
                widthForProfileControl += profile.Width + 10;
            }
        }

        /// <summary>
        /// The "HandleCurrentChatParticipants" method handles the enabling or disabling of the ContinueToGroupSettingsCustomButton based on the number of selected contacts.
        /// </summary>
        /// <remarks>
        /// This method checks if the number of selected contacts in the SelectedContactsPanel is greater than or equal to the specified number of participants required for a group chat.
        /// If it is, the ContinueToGroupSettingsCustomButton is enabled; otherwise, it is disabled.
        /// </remarks>
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

        /// <summary>
        /// The "GroupCreatorCustomButton_Click" method handles the creation of a new group chat when the group creator custom button is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the group subject, icon, and participants from the corresponding controls.
        /// It then creates a new ChatCreator instance with the group details and sends a group creator request message to the server.
        /// After sending the message, the method sets the chat panel to be visible, restarts the group creator panel, handles the switch to group contacts selection,
        /// and disables the group creator custom button.
        /// </remarks>
        private void GroupCreatorCustomButton_Click(object sender, EventArgs e)
        {
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

        /// <summary>
        /// The "DisableCloseForProfileControls" method disables the close button for all profile controls in the ProfileControlList.
        /// </summary>
        /// <remarks>
        /// This method iterates through the ProfileControlList and sets the IsCloseVisible property to false for each profile control,
        /// effectively hiding the close button.
        /// </remarks>
        private void DisableCloseForProfileControls()
        {
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.IsCloseVisible = false;
            }
        }

        /// <summary>
        /// The "EnableCloseForProfileControls" method enables the close button for all profile controls in the ProfileControlList.
        /// </summary>
        /// <remarks>
        /// This method iterates through the ProfileControlList and sets the IsCloseVisible property to true for each profile control,
        /// effectively showing the close button.
        /// </remarks>
        private void EnableCloseForProfileControls()
        {
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.IsCloseVisible = true;
            }
        }

        /// <summary>
        /// The "ContinueToGroupSettingsCustomButton_Click" method handles the transition to the group settings panel when the continue to group settings custom button is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method makes the group settings panel visible and hides the group creator background panel.
        /// It adds the selected contacts panel to the group settings panel and sets its location.
        /// Additionally, it disables the close button for all profile controls and adjusts the layout of the selected contacts panel.
        /// </remarks>
        private void ContinueToGroupSettingsCustomButton_Click(object sender, EventArgs e)
        {
            GroupSettingsPanel.Visible = true;
            GroupCreatorBackgroundPanel.Visible = false;
            this.GroupSettingsPanel.Controls.Add(this.SelectedContactsPanel);
            this.SelectedContactsPanel.Location = new System.Drawing.Point(0, 100);
            DisableCloseForProfileControls();
            PanelHandler.SetPanelToSide(SelectedContactsPanel, ProfileControlList, true);
        }

        /// <summary>
        /// The "ReturnToGroupContactsSelectionCustomButton_Click" method handles the return to the group contacts selection view when the button is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandleSwitchToGroupContactsSelection method to switch the view back to the group contacts selection view.
        /// </remarks>
        private void ReturnToGroupContactsSelectionCustomButton_Click(object sender, EventArgs e)
        {
            HandleSwitchToGroupContactsSelection();
        }

        /// <summary>
        /// The "HandleSwitchToGroupContactsSelection" method handles the switch to the group contacts selection view.
        /// </summary>
        /// <remarks>
        /// This method makes the group settings panel invisible, resets the group icon and subject text, and makes the group creator background panel visible.
        /// It adds the selected contacts panel to the group creator background panel and adjusts its location.
        /// Additionally, it enables the close button for all profile controls and adjusts the layout of the selected contacts panel.
        /// </remarks>
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

        /// <summary>
        /// The "RestartGroupSubjectCustomButton_Click" method handles the restart of the group subject input field when the button is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method clears the text content of the group subject custom text box.
        /// </remarks>
        private void RestartGroupSubjectCustomButton_Click(object sender, EventArgs e)
        {
            GroupSubjectCustomTextBox.TextContent = "";
        }

        /// <summary>
        /// The "GroupSubjectCustomTextBox_TextChangedEvent" method handles the text changed event for the group subject custom text box.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calculates the number of characters left in the group subject custom text box and updates the group subject length label accordingly.
        /// It also triggers the method to handle group creation fields.
        /// </remarks>
        private void GroupSubjectCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            int charLeft = GroupSubjectCustomTextBox.MaxLength - GroupSubjectCustomTextBox.TextContent.Length;
            GroupSubjectLengthLabel.Text = string.Format("({0})", charLeft);
            HandleGroupCreationFields();
        }

        /// <summary>
        /// The "HandleGroupCreationFields" method checks if the group icon and group subject have been selected or entered, enabling the group creator custom button accordingly.
        /// </summary>
        /// <remarks>
        /// This method verifies if a group icon has been selected (by checking if the background image of the group icon circular picture box is not null)
        /// and if a group subject has been entered (by checking if the group subject custom text box contains a value).
        /// If both conditions are met, it enables the group creator custom button; otherwise, it disables it.
        /// </remarks>
        private void HandleGroupCreationFields()
        {
            bool hasGroupIconBeenSelected = (GroupIconCircularPictureBox.BackgroundImage != null);
            bool hasGroupSubjectBeenSelected = GroupSubjectCustomTextBox.IsContainingValue();
            if (hasGroupIconBeenSelected && hasGroupSubjectBeenSelected)
            {
                GroupCreatorCustomButton.Enabled = true;
            }
            else
            {
                GroupCreatorCustomButton.Enabled = false;
            }
        }

        /// <summary>
        /// The "GroupIconCircularPictureBox_Click" method handles the click event for the group icon circular picture box, showing the group icon context menu strip.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void GroupIconCircularPictureBox_Click(object sender, EventArgs e)
        {
            GroupIconContextMenuStrip.Show(GroupIconCircularPictureBox, new System.Drawing.Point(GroupIconCircularPictureBox.Width / 2, GroupIconCircularPictureBox.Height * 3 / 4));
        }

        /// <summary>
        /// The "GroupIconCircularPictureBox_BackgroundImageChanged" method handles the event when the background image of the group icon circular picture box changes, updating the group creation fields.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void GroupIconCircularPictureBox_BackgroundImageChanged(object sender, EventArgs e)
        {
            HandleGroupCreationFields();
        }

        /// <summary>
        /// The "UploadPhotoToolStripMenuItem_Click" method handles the event when the "Upload Photo" context menu item is clicked. It allows users to upload a photo for the group icon circular picture box.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method first checks if the group icon circular picture box already has an icon. If it does, it allows the user to upload a new photo. If not, it sets the uploaded photo as the group icon.
        /// If the user cancels the file dialog and the group icon circular picture box does not have an icon, it sets the group icon to the default anonymous profile picture.
        /// </remarks>
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

        /// <summary>
        /// The "EmojiToolStripMenuItem_Click" method handles the event when the "Emoji" context menu item is clicked. It opens an emoji keyboard form for the user to select an emoji, which is then set as the group icon circular picture box's background image.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// If the emoji keyboard form is not yet initialized, it creates a new instance of the form. It then displays the form as a dialog, allowing the user to select an emoji.
        /// If the user selects an emoji and clicks "OK", the selected emoji's image is set as the background image of the group icon circular picture box.
        /// </remarks>
        private void EmojiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormHandler._emojiKeyboard == null)
            {
                FormHandler._emojiKeyboard = new EmojiKeyboard();
            }
            DialogResult result = FormHandler._emojiKeyboard.ShowDialog();

            if (result == DialogResult.OK)
            {
                GroupIconCircularPictureBox.BackgroundImage = FormHandler._emojiKeyboard.ImageToSend;
            }
        }

        /// <summary>
        /// The "TakePhotoToolStripMenuItem_Click" method handles the event when the "Take Photo" context menu item is clicked. It triggers the process of taking a photo using the device's camera and sets the captured image as the group icon circular picture box's background image.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the "HandleImageTaking" method with the parameter "true" to initiate the process of taking a photo. If a photo is successfully captured, the method sets the captured image as the background image of the group icon circular picture box.
        /// </remarks>
        private void TakePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleImageTaking(true);
        }

        #endregion

        #region Current Chat Methods

        /// <summary>
        /// The "SetFeaturePanelsVisibility" method controls the visibility of feature panels based on the specified parameters.
        /// </summary>
        /// <param name="directChatVisible">A boolean value indicating whether the direct chat features panel should be visible.</param>
        /// <remarks>
        /// This method sets the visibility of the DirectChatFeaturesPanel based on the value of the "directChatVisible" parameter. 
        /// If "directChatVisible" is true, the DirectChatFeaturesPanel is set to visible; otherwise, it is set to hidden.
        /// </remarks>
        private void SetFeaturePanelsVisibility(bool directChatVisible)
        {
            DirectChatFeaturesPanel.Visible = directChatVisible;
        }

        /// <summary>
        /// The "SetChatOnline" method updates the online status of a chat contact and optionally displays their last seen time.
        /// </summary>
        /// <param name="contactName">The name of the contact whose online status is being updated.</param>
        /// <param name="toOnline">A boolean value indicating whether the contact should be shown as online.</param>
        /// <param name="lastSeenTime">An optional parameter representing the last time the contact was seen online. Default is null.</param>
        /// <remarks>
        /// This method updates the online status of the chat contact specified by "contactName". 
        /// If "toOnline" is true, the contact is displayed as online; otherwise, their last seen time is displayed.
        /// If the chat with the specified contact is currently open, the LastSeenOnlineLabel is updated accordingly.
        /// </remarks>
        public void SetChatOnline(string contactName, bool toOnline, DateTime? lastSeenTime = null)
        {
            if (CurrentChatNameLabel.Text == contactName)
            {
                if (ChatStatusLabel.Visible)
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

        /// <summary>
        /// The "ChangeUserStatus" method updates the status of a chat contact.
        /// </summary>
        /// <param name="contactName">The name of the contact whose status is being updated.</param>
        /// <param name="status">The new status of the contact.</param>
        /// <remarks>
        /// This method updates the status of the chat contact specified by "contactName" to the provided "status".
        /// If the chat with the specified contact is currently open, the ChatStatusLabel is updated with the new status.
        /// Additionally, the status of the contact in the contact list is updated.
        /// </remarks>
        public void ChangeUserStatus(string contactName, string status)
        {
            if (CurrentChatNameLabel.Text == contactName)
            {
                if (ChatStatusLabel.Visible)
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

        /// <summary>
        /// The "EnableDirectChatFeaturesPanel" method enables the direct chat features panel.
        /// </summary>
        /// <remarks>
        /// This method sets the Enabled property of the DirectChatFeaturesPanel to true, allowing user interaction with the panel.
        /// </remarks>
        public void EnableDirectChatFeaturesPanel()
        {
            DirectChatFeaturesPanel.Enabled = true;
        }

        /// <summary>
        /// The "AudioCallCustomButton_Click" method handles the click event for initiating an audio call.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the "HandleCallRequest" method with the "AudioCallRequest" type to initiate an audio call.
        /// </remarks>
        private void AudioCallCustomButton_Click(object sender, EventArgs e)
        {
            HandleCallRequest(EnumHandler.CommunicationMessageID_Enum.AudioCallRequest);
        }

        /// <summary>
        /// The "VideoCallCustomButton_Click" method handles the click event for initiating a video call.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the "HandleCallRequest" method with the "VideoCallRequest" type to initiate a video call.
        /// </remarks>
        private void VideoCallCustomButton_Click(object sender, EventArgs e)
        {
            HandleCallRequest(EnumHandler.CommunicationMessageID_Enum.VideoCallRequest);
        }

        /// <summary>
        /// The "HandleCallRequest" method handles a call request of the specified type.
        /// </summary>
        /// <param name="callType">The type of call request to handle.</param>
        /// <remarks>
        /// This method sends a message of the specified callType to the server with the current chat ID as the message content.
        /// It then disables the DirectChatFeaturesPanel to prevent further interaction during the call.
        /// </remarks>
        private void HandleCallRequest(EnumHandler.CommunicationMessageID_Enum callType)
        {
            EnumHandler.CommunicationMessageID_Enum messageType = callType;
            object messageContent = currentChatId;
            serverCommunicator.SendMessage(messageType, messageContent);
            DirectChatFeaturesPanel.Enabled = false;
        }

        #endregion

        #region Profile Piuture Reset Methods

        /// <summary>
        /// The "ChangeUserProfilePicture" method updates the profile picture of a user.
        /// </summary>
        /// <param name="contactName">The name of the contact whose profile picture is being updated.</param>
        /// <param name="profilePictureId">The ID of the new profile picture.</param>
        /// <param name="profilePicture">The new profile picture image.</param>
        /// <remarks>
        /// This method updates the profile picture in the current chat if it matches the contact name.
        /// It also updates the profile picture in the chat controls list for direct chats with the contact name.
        /// Finally, it updates the profile picture in the contact control list for the contact.
        /// </remarks>
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

        /// <summary>
        /// The "HandleProfilePictureChange" method updates the profile picture of a user in all relevant chats.
        /// </summary>
        /// <param name="contactName">The name of the contact whose profile picture is being updated.</param>
        /// <param name="profilePictureId">The ID of the new profile picture.</param>
        /// <remarks>
        /// This method updates the profile picture for the specified contact in all chats where the contact is a participant.
        /// It iterates over all chats to find the relevant chat participants and updates their profile picture IDs.
        /// It then iterates over all message controls in each affected chat to update the profile picture displayed in the messages.
        /// </remarks>
        public void HandleProfilePictureChange(string contactName, string profilePictureId)
        {
            Queue<string> chatIdsToChange = new Queue<string>();
            string name;
            foreach (ChatDetails chatDetails in ChatManager.Chats)
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

        /// <summary>
        /// The "ChatCustomButton_Click" method handles the click event for the chat custom button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the chat custom button is clicked. It sets the chat panel to be visible.
        /// </remarks>
        private void ChatCustomButton_Click(object sender, EventArgs e)
        {
            SetChatPanelVisible();
        }

        /// <summary>
        /// The "NewGroupCustomButton_Click" method handles the click event for the new group custom button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the new group custom button is clicked. It sets the group creator background panel to be visible,
        /// hides the contact management panel, and hides the chat background panel.
        /// </remarks>
        private void NewGroupCustomButton_Click(object sender, EventArgs e)
        {
            GroupCreatorBackgroundPanel.Visible = true;
            ContactManagementPanel.Visible = false;
            ChatBackgroundPanel.Visible = false;
        }

        /// <summary>
        /// The "SetChatPanelVisible" method sets the visibility of the chat panel and hides other panels.
        /// </summary>
        /// <remarks>
        /// This method is used to make the chat panel visible while hiding the group creator background panel
        /// and the contact management panel.
        /// </remarks>
        private void SetChatPanelVisible()
        {
            GroupCreatorBackgroundPanel.Visible = false;
            ContactManagementPanel.Visible = false;
            ChatBackgroundPanel.Visible = true;
        }

        #endregion

        #region Form Methods

        /// <summary>
        /// The "HandleImageTaking" method handles the process of taking an image using the camera.
        /// </summary>
        /// <param name="isForGroupChat">A boolean value indicating if the image is for a group chat.</param>
        /// <remarks>
        /// This method initializes the camera form, sets the image type (group chat or personal chat),
        /// and shows the camera form to capture an image. If the image capture is successful, it sets the
        /// captured image as the background of the group icon circular picture box if it is for a group chat,
        /// otherwise, it sends the image to the current chat.
        /// </remarks>
        private void HandleImageTaking(bool isForGroupChat)
        {
            FormHandler._camera = new Camera
            {
                IsImageForGroupChat = isForGroupChat
            };
            DialogResult result = FormHandler._camera.ShowDialog();

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

        /// <summary>
        /// The "UserFileCustomButton_Click" method handles the event when the user clicks the file custom button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method initializes the contact sharing form, shows the form to select a contact,
        /// and sends the selected contact data as a message.
        /// </remarks>
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

        /// <summary>
        /// The "OpenWaitingForm" method opens a waiting form on a separate thread.
        /// </summary>
        public void OpenWaitingForm()
        {
            FormHandler._waitingForm = new WaitingForm();
            this.Invoke(new Action(() => FormHandler._waitingForm.Show()));
        }

        /// <summary>
        /// The "CloseVideoCall" method closes and disposes of the video call form and enables the direct chat features panel.
        /// </summary>
        /// <remarks>
        /// This method is called to end a video call. It closes and disposes of the video call form, stored in FormHandler._videoCall,
        /// and then enables the direct chat features panel to allow for further interaction.
        /// </remarks>
        public void CloseVideoCall()
        {
            FormHandler._videoCall.Close();
            FormHandler._videoCall.Dispose();
            EnableDirectChatFeaturesPanel();
        }

        /// <summary>
        /// The "CloseAudioCall" method closes and disposes of the audio call form and enables the direct chat features panel.
        /// </summary>
        /// <remarks>
        /// This method is called to end an audio call. It closes and disposes of the audio call form, stored in FormHandler._audioCall,
        /// and then enables the direct chat features panel to allow for further interaction.
        /// </remarks>
        public void CloseAudioCall()
        {
            FormHandler._audioCall.Close();
            FormHandler._audioCall.Dispose();
            EnableDirectChatFeaturesPanel();
        }

        /// <summary>
        /// The "StartAudioUdpConnection" method initiates an audio UDP connection with a friend for a specific chat.
        /// </summary>
        /// <param name="chatId">The ID of the chat for which the audio connection is being initiated.</param>
        /// <param name="friendName">The name of the friend with whom the audio connection is being initiated.</param>
        /// <remarks>
        /// This method retrieves the profile picture of the friend and creates a new instance of the AudioCall form,
        /// stored in FormHandler._audioCall, to handle the audio call. It then connects to the UDP server using the
        /// AudioServerCommunication class, passing the IP address and the created AudioCall instance to establish the
        /// audio connection. Finally, it sends a UDP audio connection request message to the server with the assigned
        /// port number for the connection.
        /// </remarks>
        public void StartAudioUdpConnection(string chatId, string friendName)
        {
            Contact contact = ContactManager.GetContact(friendName);
            if (contact != null)
            {
                Image profilePicture = contact.ProfilePicture;
                FormHandler._audioCall = new AudioCall(chatId, friendName, profilePicture);
            }

            int portNumber = AudioServerCommunication.ConnectUdp("10.100.102.3", FormHandler._audioCall);
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.UdpAudioConnectionRequest;
            object messageContent = portNumber.ToString();
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "StartVideoUdpConnection" method initiates a video UDP connection with a friend for a specific chat.
        /// </summary>
        /// <param name="chatId">The ID of the chat for which the video connection is being initiated.</param>
        /// <param name="friendName">The name of the friend with whom the video connection is being initiated.</param>
        /// <remarks>
        /// This method retrieves the contact information of the friend and creates a new instance of the VideoCall form,
        /// stored in FormHandler._videoCall, to handle the video call. It then connects to the UDP server using the
        /// AudioServerCommunication and VideoServerCommunication classes, passing the IP address and the created VideoCall
        /// instance to establish the audio and video connections. Finally, it sends a UDP video connection request message
        /// to the server with the assigned audio and video port numbers for the connection.
        /// </remarks>
        public void StartVideoUdpConnection(string chatId, string friendName)
        {
            Contact contact = ContactManager.GetContact(friendName);
            if (contact != null)
            {
                Image profilePicture = contact.ProfilePicture;
                FormHandler._videoCall = new VideoCall(chatId, friendName, profilePicture);
                int audioPortNumber = AudioServerCommunication.ConnectUdp("10.100.102.3", FormHandler._videoCall);
                int videoPortNumber = VideoServerCommunication.ConnectUdp("10.100.102.3", FormHandler._videoCall);
                UdpPorts udpPorts = new UdpPorts(audioPortNumber, videoPortNumber);

                EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.UdpVideoConnectionRequest;
                object messageContent = udpPorts;
                serverCommunicator.SendMessage(messageType, messageContent);
            }
        }

        /// <summary>
        /// The "CloseForm" method hides, closes, and disposes of the specified form.
        /// </summary>
        /// <param name="form">The form to be closed.</param>
        /// <remarks>
        /// This method is used to properly close a form by first hiding it, then closing and disposing of it.
        /// </remarks>
        private void CloseForm(Form form)
        {
            if (form != null)
            {
                form.Hide();
                form.Close();
                form.Dispose();
            }
        }

        /// <summary>
        /// The "OpenAudioCall" method opens the audio call form and prepares it for the call.
        /// </summary>
        /// <remarks>
        /// This method closes the waiting form and the profile form, shows the audio call form, sets the ability to send messages to true,
        /// and hides the current form to switch to the audio call interface.
        /// </remarks>
        public void OpenAudioCall()
        {
            CloseForm(FormHandler._waitingForm);
            CloseForm(FormHandler._profile);
            this.Invoke(new Action(() => FormHandler._audioCall.Show()));
            this.Invoke((Action)delegate { FormHandler._audioCall.SetIsAbleToSendToTrue(); });
            this.Hide();
        }

        /// <summary>
        /// The "OpenVideoCall" method opens the video call form and prepares it for the call.
        /// </summary>
        /// <remarks>
        /// This method closes the waiting form and the profile form, shows the video call form, sets the ability to send messages to true,
        /// and hides the current form to switch to the video call interface.
        /// </remarks>
        public void OpenVideoCall()
        {
            CloseForm(FormHandler._waitingForm);
            CloseForm(FormHandler._profile);
            this.Invoke(new Action(() => FormHandler._videoCall.Show()));
            this.Invoke((Action)delegate { FormHandler._videoCall.SetIsAbleToSendToTrue(); });
            this.Hide();
        }

        /// <summary>
        /// The "CloseWaitingForm" method hides, closes, and disposes of the waiting form.
        /// </summary>
        /// <remarks>
        /// This method is used to properly close the waiting form by hiding it, then closing and disposing of it.
        /// It also enables the direct chat features panel after closing the waiting form.
        /// </remarks>
        public void CloseWaitingForm()
        {
            FormHandler._waitingForm.Hide();
            FormHandler._waitingForm.Close();
            FormHandler._waitingForm.Dispose();
            EnableDirectChatFeaturesPanel();
        }

        /// <summary>
        /// The "OpenCallInvitation" method opens a call invitation form for a chat with a friend.
        /// </summary>
        /// <param name="chatId">The ID of the chat for which the call invitation is being sent.</param>
        /// <param name="friendName">The name of the friend to whom the call invitation is being sent.</param>
        /// <param name="isVideoCall">A flag indicating whether the call is a video call.</param>
        /// <remarks>
        /// This method retrieves the contact information of the friend, including their profile picture,
        /// and creates a new instance of the CallInvitation form to handle the call invitation.
        /// The DirectChatFeaturesPanel is disabled while the call invitation form is open.
        /// </remarks>
        public void OpenCallInvitation(string chatId, string friendName, bool isVideoCall)
        {
            Contact contact = ContactManager.GetContact(friendName);
            if (contact != null)
            {
                Image profilePicture = contact.ProfilePicture;
                FormHandler._callInvitation = new CallInvitation(chatId, friendName, profilePicture, isVideoCall);
                FormHandler._callInvitation.Show();
                DirectChatFeaturesPanel.Enabled = false;
            }
        }

        /// <summary>
        /// The "DrawingFileCustomButton_Click" method handles the click event for the drawing file custom button.
        /// It opens the PaintHandler form to allow the user to create a drawing.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method creates a new instance of the PaintHandler form and displays it as a dialog.
        /// If the user confirms the drawing by closing the PaintHandler form with DialogResult.OK,
        /// the method retrieves the final image from the PaintHandler class and sends it using the SendImage method.
        /// After sending the image, the FinalImage property of the PaintHandler class is reset to null.
        /// </remarks>
        private void DrawingFileCustomButton_Click(object sender, EventArgs e)
        {
            FormHandler._paint = new AttachedFiles.PaintHandler.Paint();
            DialogResult result = FormHandler._paint.ShowDialog();

            Image imageData;
            if (result == DialogResult.OK)
            {
                imageData = AttachedFiles.PaintHandler.Paint.FinalImage;
                SendImage(imageData);
                AttachedFiles.PaintHandler.Paint.FinalImage = null;
            }
        }

        /// <summary>
        /// The "EmojiKeyBoardCustomButton_Click" method handles the click event for the emoji keyboard custom button.
        /// It opens the EmojiKeyboard form to allow the user to select an emoji.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the emoji keyboard form is already created.
        /// If not, it creates a new instance of the EmojiKeyboard form.
        /// It then displays the EmojiKeyboard form as a dialog and retrieves the selected image from the form if the user confirms the selection.
        /// After sending the image, the ImageToSend property of the EmojiKeyboard form is reset to null.
        /// </remarks>
        private void EmojiKeyBoardCustomButton_Click(object sender, EventArgs e)
        {
            if (FormHandler._emojiKeyboard == null)
            {
                FormHandler._emojiKeyboard = new EmojiKeyboard();
            }
            DialogResult result = FormHandler._emojiKeyboard.ShowDialog();

            Image imageData;
            if (result == DialogResult.OK)
            {
                imageData = FormHandler._emojiKeyboard.ImageToSend;
                FormHandler._emojiKeyboard.ImageToSend = null;
                SendImage(imageData);
            }
        }

        /// <summary>
        /// The "TakenImageFile_Click" method handles the click event for the taken image file button.
        /// It calls the HandleImageTaking method with the parameter to indicate that the image is not from a file.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void TakenImageFile_Click(object sender, EventArgs e)
        {
            HandleImageTaking(false);
        }

        /// <summary>
        /// The "ImageFileCustomButton_Click" method handles the click event for the image file custom button.
        /// It opens the ImageSender form to allow the user to select an image file to send.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method creates a new instance of the ImageSender form and displays it as a dialog.
        /// It retrieves the selected image from the ImageSender form if the user confirms the selection.
        /// After sending the image, the selectedImage property of the ImageSender form is reset to null.
        /// </remarks>
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

        /// <summary>
        /// The "ProfileCustomButton_Click" method handles the click event for the profile custom button.
        /// It opens the Profile form to allow the user to view and edit their profile information.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method creates a new instance of the Profile form and displays it.
        /// It disables the ProfileCustomButton to prevent multiple instances of the Profile form from being opened.
        /// </remarks>
        private void ProfileCustomButton_Click(object sender, EventArgs e)
        {
            FormHandler._profile = new Profile();
            this.Invoke(new Action(() => FormHandler._profile.Show()));
            ProfileCustomButton.Enabled = false;
        }

        #endregion

        #region Message Sending Methods

        /// <summary>
        /// The "MessageSenderCustomButton_Click" method handles the click event for the message sender custom button.
        /// It sends the message entered in the message custom text box.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the message custom text box contains a value.
        /// If it does, it retrieves the message, sends it using the SendMessage method, and clears the message custom text box.
        /// </remarks>
        private void MessageSenderCustomButton_Click(object sender, EventArgs e)
        {
            if (MessageCustomTextBox.IsContainingValue())
            {
                string Message = MessageCustomTextBox.TextContent;
                SendMessage(Message);
                MessageCustomTextBox.TextContent = "";
            }
        }

        /// <summary>
        /// The "SendMessage" method sends a message to the current chat.
        /// </summary>
        /// <param name="messageContentValue">The content of the message to be sent.</param>
        /// <remarks>
        /// This method first retrieves the current date and time to timestamp the message.
        /// It then handles the message locally, such as displaying it in the chat window.
        /// Next, it creates a new message object using the provided message content, chat ID, sender name (retrieved from ProfileDetailsHandler), and message timestamp.
        /// After that, it defines the message type and content for communication with the server.
        /// Finally, it sends the message to the server using the serverCommunicator object.
        /// </remarks>
        private void SendMessage(string messageContentValue)
        {
            DateTime messageTime = DateTime.Now;
            HandleYourMessages(messageContentValue, currentChatId, messageTime);
            JsonClasses.Message message = new JsonClasses.Message(ProfileDetailsHandler.Name, currentChatId, messageContentValue, messageTime);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.SendMessageRequest;
            object messageContent = message;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "SendImage" method sends an image to the current chat.
        /// </summary>
        /// <param name="image">The image to be sent.</param>
        /// <remarks>
        /// This method first retrieves the current date and time to timestamp the image message.
        /// It then resizes the image to a specific size (280x180) to optimize for transmission and display.
        /// The resized image is then handled locally, such as displaying it in the chat window.
        /// Next, the method converts the resized image to bytes for transmission over the network.
        /// It creates an ImageContent object containing the image bytes.
        /// The method then creates a new message object with the sender name, chat ID, image content, and message timestamp.
        /// Finally, it defines the message type and content for communication with the server, and sends the message.
        /// </remarks>
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

        /// <summary>
        /// The "MessageCustomTextBox_KeyDown" method handles the KeyDown event for the message custom text box.
        /// It clears the text content of the message custom text box when the Delete key is pressed.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void MessageCustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                MessageCustomTextBox.TextContent = "";
            }
        }

        #endregion

        #region Drawing Method

        /// <summary>
        /// The "ResizeImage" method resizes an image to the specified dimensions.
        /// </summary>
        /// <param name="originalImage">The original image to be resized.</param>
        /// <param name="desiredWidth">The desired width of the resized image.</param>
        /// <param name="desiredHeight">The desired height of the resized image.</param>
        /// <returns>The resized image.</returns>
        private Image ResizeImage(Image originalImage, int desiredWidth, int desiredHeight)
        {
            return new Bitmap(originalImage, desiredWidth, desiredHeight);
        }

        #endregion

        #region Form Closing Method

        /// <summary>
        /// The "YouChat_FormClosing" method handles the FormClosing event for the YouChat form.
        /// It sends a disconnect message to the server, disconnects from the server, and exits the application.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
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
