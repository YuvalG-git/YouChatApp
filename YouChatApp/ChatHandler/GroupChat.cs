using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.UserProfile;

namespace YouChatApp.ChatHandler
{
    public class GroupChat : ChatDetails
    {
        private string _chatName;
        public Image _chatProfilePicture;
        private string _chatParticipants;
        public GroupChat(string chatTagLineId, string messageHistory, DateTime? lastMessageTime, string lastMessageContent, List<ChatParticipant> chatParticipants, string chatName, Image chatProfilePicture) : base(chatTagLineId, messageHistory, lastMessageTime, lastMessageContent, chatParticipants)
        {
            _chatName = chatName;
            _chatProfilePicture = chatProfilePicture;
            _chatParticipants = ChatParticipantsToString();
        }
        public GroupChat(GroupChatDetails groupChatDetails) : base(groupChatDetails.ChatTagLineId, groupChatDetails.MessageHistory, groupChatDetails.LastMessageTime, groupChatDetails.LastMessageContent, groupChatDetails.ChatParticipants)
        {
            _chatName = groupChatDetails.ChatName;
            _chatProfilePicture = ConvertHandler.ConvertBytesToImage(groupChatDetails.ChatProfilePicture);
            _chatParticipants = ChatParticipantsToString();
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
        public string ChatParticiapntsValue
        {
            get
            {
                return _chatParticipants;
            }
            set
            {
                _chatParticipants = value;
            }
        }

        public string ChatParticipantsToString()
        {
            string chatParticipants = "you, ";
            string username;
            foreach (ChatParticipant chatParticipant in ChatParticipants)
            {
                username = chatParticipant.Username;
                if (username != ProfileDetailsHandler.Name)
                {
                    chatParticipants += username + ", ";
                }
            }
            return chatParticipants.Substring(0, chatParticipants.Length - 2);
        }
    }
}
