using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.ContactHandler;

namespace YouChatApp.ChatHandler
{
    /// <summary>
    /// The "ChatLastMessageTimeComparer" class implements the IComparer interface to compare ChatDetails objects based on their last message time.
    /// </summary>
    /// <remarks>
    /// This class provides a method to compare two ChatDetails objects based on their last message time.
    /// It considers null LastMessageTime values as less than non-null values.
    /// </remarks>
    internal class ChatLastMessageTimeComparer : IComparer<ChatDetails>
    {
        #region Public Methods

        /// <summary>
        /// The "Compare" method compares two ChatDetails objects based on their last message time.
        /// </summary>
        /// <param name="chat1">The first ChatDetails object to compare.</param>
        /// <param name="chat2">The second ChatDetails object to compare.</param>
        /// <returns>
        ///     0 if both LastMessageTime values are null (considered equal),
        ///     1 if the LastMessageTime of chat1 is null (considered greater than chat2),
        ///     -1 if the LastMessageTime of chat2 is null (considered less than chat1),
        ///     or the result of comparing non-null LastMessageTime values (-1, 0, or 1).
        /// </returns>
        /// <remarks>
        /// This method retrieves the LastMessageTime objects from the ChatDetails objects.
        /// It compares the LastMessageTime values, considering null values as less than non-null values.
        /// </remarks>
        public int Compare(ChatDetails chat1, ChatDetails chat2)
        {
            DateTime? lastMessageTime1 = chat1.GetLastMessageTimeObject();
            DateTime? lastMessageTime2 = chat2.GetLastMessageTimeObject();

            if (lastMessageTime1 == null && lastMessageTime2 == null)
            {
                return 0; // Both LastMessageTime values are null, consider them equal
            }
            else if (lastMessageTime1 == null)
            {
                return 1; // LastMessageTime of chat1 is null, consider it more than chat2
            }
            else if (lastMessageTime2 == null)
            {
                return -1; // LastMessageTime of chat2 is null, consider it less than chat1
            }
            else
            {
                // Compare non-null LastMessageTime values
                return (-1) * lastMessageTime1.Value.CompareTo(lastMessageTime2.Value);
            }
        }

        #endregion
    }
}
