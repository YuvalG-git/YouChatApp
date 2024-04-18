using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.ContactHandler;

namespace YouChatApp.ChatHandler
{
    internal class ChatLastMessageTimeComparer : IComparer<ChatDetails>
    {
        /// <summary>
        /// In this code, we use the DateTime.CompareTo method to compare the lastmessagetime of chat1 with the lastmessagetime of chat2. This method returns a negative value if chat1.LastMessageTime is earlier than chat2.LastMessageTime, a positive value if it's later, and zero if they are equal, which is the expected behavior for a comparer.
        /// </summary>
        /// <param name="chat1"></param>
        /// <param name="chat2"></param>
        /// <returns></returns>
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
                return -1; // LastMessageTime of chat1 is null, consider it less than chat2
            }
            else if (lastMessageTime2 == null)
            {
                return 1; // LastMessageTime of chat2 is null, consider it greater than chat1
            }
            else
            {
                // Compare non-null LastMessageTime values
                return (-1) * lastMessageTime1.Value.CompareTo(lastMessageTime2.Value);
            }
            //return (-1) * chat1.GetLastMessageTimeObject().CompareTo(chat2.GetLastMessageTimeObject());//needs to understand why -1 (without it not working..
        }

    }
}
