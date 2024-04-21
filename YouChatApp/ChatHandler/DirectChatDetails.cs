using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ChatHandler
{
    public class DirectChatDetails : ChatDetails
    {
        public DirectChatDetails(string chatTagLineId, DateTime? lastMessageTime, string lastMessageContent, string lastMessageSenderName, List<ChatParticipant> chatParticipants) : base(chatTagLineId, lastMessageTime, lastMessageContent, lastMessageSenderName, chatParticipants)
        {
        }
    }
}
