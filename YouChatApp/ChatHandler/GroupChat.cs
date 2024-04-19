using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ChatHandler
{
    public class GroupChat : ChatDetails
    {
        private string _chatName;
        public Image _chatProfilePicture;
        public GroupChat(string chatTagLineId, string messageHistory, DateTime? lastMessageTime, string lastMessageContent, List<ChatParticipant> chatParticipants, string chatName, Image chatProfilePicture) : base(chatTagLineId, messageHistory, lastMessageTime, lastMessageContent, chatParticipants)
        {
            _chatName = chatName;
            _chatProfilePicture = chatProfilePicture;
        }
        public GroupChat(GroupChatDetails groupChatDetails) : base(groupChatDetails.ChatTagLineId, groupChatDetails.MessageHistory, groupChatDetails.LastMessageTime, groupChatDetails.LastMessageContent, groupChatDetails.ChatParticipants)
        {
            _chatName = groupChatDetails.ChatName;
            _chatProfilePicture = ConvertHandler.ConvertBytesToImage(groupChatDetails.ChatProfilePicture);
        }

        public string ChatName
        {
            get
            {
                return _chatName;
            }
            set
            {
                _chatName= value;
            }
        }
        public Image ChatProfilePicture
        {
            get
            {
                return _chatProfilePicture;
            }
            set
            {
                _chatProfilePicture = value;
            }
        }

        public string ChatParticipantsToString()
        {
            string chatParticipants = "";
            foreach (ChatParticipant chatParticipant in ChatParticipants)
            {
                chatParticipants += chatParticipant.Username + ", ";
            }
            return chatParticipants.Substring(0, chatParticipants.Length - 2);
        }
    }
}
