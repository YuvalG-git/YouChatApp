using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.ContactHandler;

namespace YouChatApp.ChatHandler
{
    internal class ChatManager
    {
        public static List<Chat> _chats = new List<Chat>();
        private static string _currentChatName = "";
        public static string CurrentChatName
        {
            get { return _currentChatName; }
            set { _currentChatName = value; }
        }
        public static void AddChat(string name, string chatParticipants, string chatManagers, DateTime lastMessageTime, Image chatProfilePicture, string lastMessageContent)
        {
            Chat newChat = new GroupChat(name, chatParticipants, chatManagers, lastMessageTime, chatProfilePicture, lastMessageContent);
            //UserContacts.Add(NewContact);
            InsertByLastMessageTime(newChat);
        }
        public static void AddChat(string Name)
        {
            //Chat newChat = new GroupChat(Name);
            //UserContacts.Add(NewContact);
            //InsertByLastMessageTime(newChat);
        }
        private static void InsertByLastMessageTime(Chat chat)
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
        public static Chat GetChat(string chatName)
        {
            foreach (Chat chat in _chats)
            {
                if (chat._chatName == chatName)
                    return chat;
            }
            return null; //wont get here beacuse i will call iscontactexist method before...
        }

        public static bool IsContactExist(string chatName)
        {
            foreach (Chat chat in _chats)
            {
                if (chat._chatName == chatName)
                    return true;
            }
            return false;
        }
    }
}
