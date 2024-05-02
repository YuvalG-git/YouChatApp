using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.ContactHandler;
using YouChatApp.UserProfile;

namespace YouChatApp.ChatHandler
{
    /// <summary>
    /// The "DirectChat" class represents a direct chat between users.
    /// It inherits from the ChatDetails class and includes information about the associated contact.
    /// </summary>
    /// <remarks>
    /// This class provides constructors to create a new instance of the DirectChat class with the specified parameters or DirectChatDetails object and Contact.
    /// It also includes a property to access the associated contact and a method to get the name of the contact or the other chat participant.
    /// </remarks>
    public class DirectChat : ChatDetails
    {
        #region Private Fields

        /// <summary>
        /// The Contact "_contact" represents a contact.
        /// </summary>
        private Contact _contact;

        #endregion

        #region Constructors

        /// <summary>
        /// The "DirectChat" constructor initializes a new instance of the <see cref="DirectChat"/> class with the specified parameters.
        /// </summary>
        /// <param name="chatTagLineId">The tagline ID of the direct chat.</param>
        /// <param name="lastMessageTime">The timestamp of the last message in the chat.</param>
        /// <param name="lastMessageContent">The content of the last message in the chat.</param>
        /// <param name="lastMessageSenderName">The name of the sender of the last message in the chat.</param>
        /// <param name="chatParticipants">The list of participants in the chat.</param>
        /// <param name="contact">The contact associated with the direct chat.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the DirectChat class, representing a direct chat between users.
        /// It initializes the chat tagline ID, last message details, chat participants, and the associated contact.
        /// </remarks>
        public DirectChat(string chatTagLineId, DateTime? lastMessageTime, string lastMessageContent, string lastMessageSenderName, List<ChatParticipant> chatParticipants, Contact contact) : base(chatTagLineId, lastMessageTime, lastMessageContent, lastMessageSenderName,  chatParticipants)
        {
            _contact = contact;
        }

        /// <summary>
        /// The "DirectChat" constructor initializes a new instance of the <see cref="DirectChat"/> class with the specified DirectChatDetails and Contact.
        /// </summary>
        /// <param name="directChatDetails">The details of the direct chat, including tagline ID, last message details, and chat participants.</param>
        /// <param name="contact">The contact associated with the direct chat.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the DirectChat class, representing a direct chat between users.
        /// It initializes the chat tagline ID, last message details, chat participants, and the associated contact using the provided DirectChatDetails object.
        /// </remarks>
        public DirectChat(DirectChatDetails directChatDetails, Contact contact) : base(directChatDetails.ChatTagLineId, directChatDetails.LastMessageTime, directChatDetails.LastMessageContent, directChatDetails.LastMessageSenderName, directChatDetails.ChatParticipants)
        {
            _contact = contact;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "Contact" property represents a contact object.
        /// It gets or sets the contact object.
        /// </summary>
        /// <value>
        /// The contact object.
        /// </value>
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

        #endregion

        #region Public Methods

        /// <summary>
        /// The "GetContactName" method returns the name of the contact associated with the chat if it exists,
        /// otherwise it returns the username of the other chat participant.
        /// </summary>
        /// <returns>The name of the contact if it exists; otherwise, the username of the other chat participant. Returns an empty string if neither exists.</returns>
        /// <remarks>
        /// This method checks if the _contact field is not null, and if so, returns the Name property of the _contact.
        /// If _contact is null, it iterates through the ChatParticipants list to find the username of the other participant.
        /// It compares each chat participant's username with the current user's name (ProfileDetailsHandler.Name) and returns the first username that is not the current user's.
        /// If no such username is found, it returns an empty string.
        /// </remarks>
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

        #endregion
    }
}
