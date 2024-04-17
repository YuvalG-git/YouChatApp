using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ChatHandler2
{
    internal class GroupChat : Chat
    {
        public GroupChat(string name, string chatParticipants, string chatManagers, DateTime lastMessageTime, Image chatProfilePicture, string lastMessageContent)
        {
            this._chatName = name;
            this._chatParticipants = new List<string>();
            string[] chatParticipantsArray = chatParticipants.Split('#');
            foreach (string chatParticipant in chatParticipantsArray)
            {
                this._chatParticipants.Add(chatParticipant);

            }
            this._chatManagers = new List<string>();
            string[] chatManagersArray = chatManagers.Split('#');
            foreach (string chatManager in chatManagersArray)
            {
                this._chatManagers.Add(chatManager);

            }
            this.SetLastMessageTime(lastMessageTime);
            this._chatProfilePicture = chatProfilePicture;
            this._lastMessageContent = lastMessageContent;
            this._isGroupChat = (_chatParticipants.Count > 1);
        }
        //public List<ContactHandler.Contact> _chatParticipants{ get; set; } //could be nice to save this but the problem is that could be users that arent my friends.. so for now i will use string
        public List<string> _chatParticipants { get; set; }
        public List<string> _chatManagers { get; set; }

    
        public void addParticipant(string chatParticipant)
        {
            this._chatParticipants.Add(chatParticipant); //needs to make sure he isnt already there...

        }
        public void removeParticipant(string chatParticipant)
        {
            this._chatParticipants.Remove(chatParticipant); //needs to make sure he isnt already there...

        }
        public void addManager(string chatParticipant)
        {
            this._chatParticipants.Add(chatParticipant); //needs to make sure he isnt already there...

        }
        public void removeManager(string chatParticipant)
        {
            this._chatParticipants.Remove(chatParticipant); //needs to make sure he isnt already there...

        }
    }
}
