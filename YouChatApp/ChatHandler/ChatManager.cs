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
    internal class ChatManager
    {
        public static List<ChatDetails> _chats = new List<ChatDetails>();
        private static string _currentChatId = "";
        public static string CurrentChatId
        {
            get { return _currentChatId; }
            set { _currentChatId = value; }
        }
        public static void AddChat(ChatDetails newChat)
        {
            if (newChat is GroupChatDetails)
            {
                GroupChatDetails groupChatDetails = (GroupChatDetails)newChat;
                GroupChat groupChat = new GroupChat(groupChatDetails);
                InsertByLastMessageTime(groupChat);

                // Handle GroupChat specific actions
                // For example:
                // Chat newChat = new GroupChat(groupChat.Name, groupChat.ChatParticipants, groupChat.LastMessageTime, groupChat.LastMessageContent);
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

            //UserContacts.Add(NewContact);
        }
        public static void AddChat(string Name)
        {
            //Chat newChat = new GroupChat(Name);
            //UserContacts.Add(NewContact);
            //InsertByLastMessageTime(newChat);
        }
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
        //public static ChatDetails GetChat(string chatName)
        //{
        //    //foreach (ChatDetails chat in _chats)
        //    //{
        //    //    if (chat._chatName == chatName)
        //    //        return chat;
        //    //}
        //    //return null; //wont get here beacuse i will call iscontactexist method before...
        //    string name = "";

        //    foreach (ChatDetails chat in _chats)
        //    {
        //        if (chat is GroupChat groupChat)
        //        {
        //            name = groupChat.ChatName;
        //        }
        //        else if (chat is DirectChat directChat)
        //        {
        //            name = directChat.Contact.Name;
        //        }
        //        if (name == chatName)
        //        {
        //            return chat;

        //        }
        //    }
        //    return null;

        //}
        public static ChatDetails GetChat(string chatId)
        {
            //foreach (ChatDetails chat in _chats)
            //{
            //    if (chat._chatName == chatName)
            //        return chat;
            //}
            //return null; //wont get here beacuse i will call iscontactexist method before...
            string id = "";

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
        public static bool IsContactExist(string chatName)
        {
            //foreach (ChatDetails chat in _chats)
            //{
            //    if (chat._chatName == chatName)
            //        return true;
            //}
            return false;
        }
    }
}
