using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.UserProfile;

namespace YouChatApp.ChatHandler
{
    /// <summary>
    /// The "GroupChat" class represents a group chat with multiple participants.
    /// It inherits from the ChatDetails class and includes information about the chat's name and profile picture.
    /// </summary>
    /// <remarks>
    /// This class provides constructors to create a new instance of the GroupChat class with the specified parameters or GroupChatDetails object.
    /// It also includes properties to access the chat's name and profile picture, and a method to convert the list of chat participants into a comma-separated string.
    /// </remarks>
    public class GroupChat : ChatDetails
    {
        #region Private Fields

        /// <summary>
        /// The string "_chatName" represents the name of the chat.
        /// </summary>
        private string _chatName;

        /// <summary>
        /// The Image "_chatProfilePicture" represents the profile picture of the chat.
        /// </summary>
        public Image _chatProfilePicture;

        #endregion

        #region Constructors

        /// <summary>
        /// The "GroupChat" constructor initializes a new instance of the <see cref="GroupChat"/> class with the specified parameters.
        /// </summary>
        /// <param name="chatTagLineId">The tagline ID of the group chat.</param>
        /// <param name="lastMessageTime">The timestamp of the last message in the group chat.</param>
        /// <param name="lastMessageContent">The content of the last message in the group chat.</param>
        /// <param name="lastMessageSenderName">The name of the sender of the last message in the group chat.</param>
        /// <param name="chatParticipants">The list of participants in the group chat.</param>
        /// <param name="chatName">The name of the group chat.</param>
        /// <param name="chatProfilePicture">The profile picture of the group chat.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the GroupChat class, representing a group chat with multiple participants.
        /// It initializes the group chat's tagline ID, last message details, participants, name, and profile picture using the provided parameters.
        /// </remarks>
        public GroupChat(string chatTagLineId, DateTime? lastMessageTime, string lastMessageContent, string lastMessageSenderName, List<ChatParticipant> chatParticipants, string chatName, Image chatProfilePicture) : base(chatTagLineId, lastMessageTime, lastMessageContent, lastMessageSenderName, chatParticipants)
        {
            _chatName = chatName;
            _chatProfilePicture = chatProfilePicture;
        }

        /// <summary>
        /// The "GroupChat" constructor initializes a new instance of the <see cref="GroupChat"/> class with the specified parameters.
        /// </summary>
        /// <param name="groupChatDetails">An instance of <see cref="GroupChatDetails"/> containing details of the group chat.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the GroupChat class, representing a group chat with multiple participants,
        /// using the details provided in the <paramref name="groupChatDetails"/> parameter.
        /// It initializes the group chat's tagline ID, last message details, participants, name, and profile picture using the details from the <paramref name="groupChatDetails"/>.
        /// </remarks>
        public GroupChat(GroupChatDetails groupChatDetails) : base(groupChatDetails.ChatTagLineId, groupChatDetails.LastMessageTime, groupChatDetails.LastMessageContent, groupChatDetails.LastMessageSenderName, groupChatDetails.ChatParticipants)
        {
            _chatName = groupChatDetails.ChatName;
            _chatProfilePicture = ConvertHandler.ConvertBytesToImage(groupChatDetails.ChatProfilePicture);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "ChatName" property represents the name of a chat.
        /// It gets or sets the name of the chat.
        /// </summary>
        /// <value>
        /// The name of the chat.
        /// </value>
        public string ChatName
        {
            get
            {
                return _chatName;
            }
            set
            {
                _chatName = value;
            }
        }

        /// <summary>
        /// The "ChatProfilePicture" property represents the profile picture of a chat.
        /// It gets or sets the profile picture of the chat.
        /// </summary>
        /// <value>
        /// The profile picture of the chat.
        /// </value>
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

        #endregion

        #region Public Methods

        /// <summary>
        /// The "ChatParticipantsToString" method converts the list of chat participants into a comma-separated string,
        /// excluding the current user's username ("you").
        /// </summary>
        /// <returns>A comma-separated string of chat participants, excluding the current user's username. Returns an empty string if there are no other participants.</returns>
        /// <remarks>
        /// This method initializes the chatParticipants string with "you, " to include the current user's username as the first participant.
        /// It then iterates through the ChatParticipants list to add each participant's username to the string, separated by commas.
        /// The method skips adding the current user's username to the string.
        /// Finally, it removes the trailing ", " from the string before returning it.
        /// If there are no other participants besides the current user, the method returns an empty string.
        /// </remarks>
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

        #endregion
    }
}
