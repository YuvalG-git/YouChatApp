using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.ContactHandler;

namespace YouChatApp.ChatHandler2
{
    internal class ChatLastMessageTimeComparer : IComparer<Chat>
    {
        /// <summary>
        /// In this code, we use the DateTime.CompareTo method to compare the lastmessagetime of chat1 with the lastmessagetime of chat2. This method returns a negative value if chat1.LastMessageTime is earlier than chat2.LastMessageTime, a positive value if it's later, and zero if they are equal, which is the expected behavior for a comparer.
        /// </summary>
        /// <param name="chat1"></param>
        /// <param name="chat2"></param>
        /// <returns></returns>
        public int Compare(Chat chat1, Chat chat2)
        {
            return (-1) * chat1.GetLastMessageTimeObject().CompareTo(chat2.GetLastMessageTimeObject());//needs to understand why -1 (without it not working..
        }

    }
}
