using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.ContactHandler;
using YouChatApp.UserProfile;

namespace YouChatApp.ChatHandler
{
    /// <summary>
    /// The "ChatManager" class manages a list of chat details and provides methods for adding and retrieving chats.
    /// </summary>
    /// <remarks>
    /// This class provides static properties to access the list of chat details and the ID of the current chat.
    /// It also provides methods to add a new chat to the list and retrieve a chat based on its unique identifier.
    /// </remarks>
    internal class ChatManager
    {
        #region Private Static Fields

        /// <summary>
        /// The static List<ChatDetails> "_chats" represents the list of chat details.
        /// </summary>
        private static List<ChatDetails> _chats = new List<ChatDetails>();

        /// <summary>
        /// The static string "_currentChatId" represents the ID of the current chat.
        /// </summary>
        private static string _currentChatId = "";

        #endregion

        #region Static Properties

        /// <summary>
        /// The "Chats" property represents a list of chat details.
        /// It gets or sets the list of chat details.
        /// </summary>
        /// <value>
        /// The list of chat details.
        /// </value>
        public static List<ChatDetails> Chats
        {
            get
            {
                return _chats;
            }
            set
            {
                _chats = value;
            }
        }

        /// <summary>
        /// The "CurrentChatId" property represents the current chat's unique identifier.
        /// It gets or sets the unique identifier of the current chat.
        /// </summary>
        /// <value>
        /// The unique identifier of the current chat.
        /// </value>
        public static string CurrentChatId
        {
            get 
            { 
                return _currentChatId;
            }
            set 
            { 
                _currentChatId = value;
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// The "InsertByLastMessageTime" method inserts a chat into the _chats list at the correct position based on the last message time of each chat.
        /// </summary>
        /// <param name="chat">The chat to insert into the list.</param>
        /// <remarks>
        /// This method uses the BinarySearch method of the List class to find the index where the chat should be inserted.
        /// If the chat is not found in the list, BinarySearch returns a negative value that represents the bitwise complement of the index of the next element that is larger.
        /// The method then inserts the chat at the calculated index, ensuring that the _chats list remains sorted by last message time.
        /// </remarks>
        private static void InsertByLastMessageTime(ChatDetails chat)
        {
            int index = _chats.BinarySearch(chat, new ChatHandler.ChatLastMessageTimeComparer());

            if (index < 0)
            {
                // If the element is not found, convert the index to the insertion point
                index = ~index;
            }

            // Insert the new string at the calculated index
            _chats.Insert(index, chat);
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// The "AddChat" method adds a new chat to the chat list based on the type of chat (GroupChatDetails or DirectChatDetails).
        /// </summary>
        /// <param name="newChat">The new chat details to add.</param>
        /// <remarks>
        /// This method checks if the new chat is a group chat or a direct chat.
        /// If it's a group chat, it creates a GroupChat object from the GroupChatDetails and inserts it into the chat list.
        /// If it's a direct chat, it determines the chat participant (excluding the current user), retrieves the contact for the participant,
        /// and creates a DirectChat object with the DirectChatDetails and the contact. It then inserts the direct chat into the chat list.
        /// If an exception occurs while retrieving the contact for the direct chat participant, the method catches the exception and does nothing.
        /// </remarks>
        public static void AddChat(ChatDetails newChat)
        {
            if (newChat is GroupChatDetails)
            {
                GroupChatDetails groupChatDetails = (GroupChatDetails)newChat;
                GroupChat groupChat = new GroupChat(groupChatDetails);
                InsertByLastMessageTime(groupChat);
            }
            else if (newChat is DirectChatDetails)
            {
                DirectChatDetails directChatDetails = (DirectChatDetails)newChat;
                string firstChatParticipant = directChatDetails.ChatParticipants[0].Username;
                string secondChatParticipant = directChatDetails.ChatParticipants[1].Username;
                string chatParticipant = (firstChatParticipant == ProfileDetailsHandler.Name) ? secondChatParticipant : firstChatParticipant;
                try
                {
                    Contact contact = ContactManager.GetContact(chatParticipant);
                    DirectChat directChat = new DirectChat(directChatDetails, contact);
                    InsertByLastMessageTime(directChat);
                }
                catch (Exception e)
                {

                }
            }
        }

        /// <summary>
        /// The "GetChat" method retrieves a chat from the _chats list based on the provided chatId.
        /// </summary>
        /// <param name="chatId">The unique identifier of the chat to retrieve.</param>
        /// <returns>The chat with the specified chatId if found; otherwise, null.</returns>
        /// <remarks>
        /// This method iterates through the _chats list and compares each chat's ChatTagLineId with the provided chatId.
        /// If a chat with the specified chatId is found, it is returned; otherwise, null is returned.
        /// </remarks>
        public static ChatDetails GetChat(string chatId)
        {
            string id;
            foreach (ChatDetails chat in _chats)
            {
                id = chat.ChatTagLineId;
                if (id == chatId)
                {
                    return chat;
                }
            }
            return null;
        }

        #endregion
    }
}
