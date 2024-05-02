using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ChatHandler
{
    /// <summary>
    /// The "DirectChatDetails" class represents the details of a direct chat between two participants.
    /// </summary>
    /// <remarks>
    /// This class inherits from the base ChatDetails class and adds functionality specific to direct chats.
    /// </remarks>
    public class DirectChatDetails : ChatDetails
    {
        #region Constructors

        /// <summary>
        /// The "DirectChatDetails" constructor initializes a new instance of the <see cref="DirectChatDetails"/> class with the specified chat tag line ID, last message time, last message content, last message sender name, and chat participants.
        /// </summary>
        /// <param name="chatTagLineId">The ID of the chat tag line.</param>
        /// <param name="lastMessageTime">The time of the last message in the chat.</param>
        /// <param name="lastMessageContent">The content of the last message in the chat.</param>
        /// <param name="lastMessageSenderName">The name of the sender of the last message in the chat.</param>
        /// <param name="chatParticipants">The list of participants in the chat.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the DirectChatDetails class, which represents the details of a direct chat between two participants.
        /// It inherits the base class constructor to initialize the chat details.
        /// </remarks>
        public DirectChatDetails(string chatTagLineId, DateTime? lastMessageTime, string lastMessageContent, string lastMessageSenderName, List<ChatParticipant> chatParticipants) : base(chatTagLineId, lastMessageTime, lastMessageContent, lastMessageSenderName, chatParticipants)
        {
        }

        #endregion
    }
}
