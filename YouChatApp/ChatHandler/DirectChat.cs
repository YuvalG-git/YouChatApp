using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.ContactHandler;
using YouChatApp.UserProfile;

namespace YouChatApp.ChatHandler
{
    public class DirectChat : ChatDetails
    {
        private Contact _contact;
        public DirectChat(string chatTagLineId, string messageHistory, DateTime? lastMessageTime, string lastMessageContent, string lastMessageSenderName, List<ChatParticipant> chatParticipants, Contact contact) : base(chatTagLineId, messageHistory, lastMessageTime, lastMessageContent, lastMessageSenderName,  chatParticipants)
        {
            _contact = contact;
        }
        public DirectChat(DirectChatDetails directChatDetails, Contact contact) : base(directChatDetails.ChatTagLineId, directChatDetails.MessageHistory, directChatDetails.LastMessageTime, directChatDetails.LastMessageContent, directChatDetails.LastMessageSenderName, directChatDetails.ChatParticipants)
        {
            _contact = contact;
        }
        public Contact Contact
        {
            get
            { 
                return _contact;
            }
            set 
            { 
                _contact = value;
            }
        }
        public string GetContactName()
        {
            if (_contact != null)
            {
                return _contact.Name;
            }
            else
            {
                string name;
                foreach (ChatParticipant chatParticipant in ChatParticipants)
                {
                    name = chatParticipant.Username;
                    if (name != ProfileDetailsHandler.Name)
                    {
                        return name;
                    }
                }
                return "";
            }
        }
    }
}
