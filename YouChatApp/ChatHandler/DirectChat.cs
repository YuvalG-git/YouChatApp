using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.ContactHandler;

namespace YouChatApp.ChatHandler
{
    public class DirectChat : ChatDetails
    {
        private Contact _contact;
        public DirectChat(string chatTagLineId, string messageHistory, DateTime? lastMessageTime, string lastMessageContent, List<ChatParticipant> chatParticipants, Contact contact) : base(chatTagLineId, messageHistory, lastMessageTime, lastMessageContent, chatParticipants)
        {
            _contact = contact;
        }
        public DirectChat(DirectChatDetails directChatDetails, Contact contact) : base(directChatDetails.ChatTagLineId, directChatDetails.MessageHistory, directChatDetails.LastMessageTime, directChatDetails.LastMessageContent, directChatDetails.ChatParticipants)
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
    }
}
