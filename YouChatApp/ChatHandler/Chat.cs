using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ChatHandler
{
    internal class Chat
    {
        public string _chatName { get; set; }
        //public List<ContactHandler.Contact> _chatParticipants{ get; set; } //could be nice to save this but the problem is that could be users that arent my friends.. so for now i will use string
        public List<string> _chatParticipants { get; set; }
        public List<string> _chatManagers { get; set; }
        //message history?
        private DateTime _lastMessageTime;
        public Image _chatProfilePicture { get; set; }
        public string _lastMessageContent { get; set; }
        public bool _isGroupChat { get; set; } //can create group chat only if you insert more than two...
        public Chat(string name, string chatParticipants, string chatManagers, DateTime lastMessageTime, Image chatProfilePicture, string lastMessageContent)
        {
            this._chatName = name;
            this._chatParticipants = new List<string>();
            string[] chatParticipantsArray = chatParticipants.Split('#');
            foreach (string chatParticipant in chatParticipantsArray)
            {
                this._chatParticipants.Add(chatParticipant);

            }
            //in case i will switch to list of contacts... ->
            //foreach (string chatParticipant in chatParticipantsArray)
            //{
            //    this._chatParticipants.Add(ContactHandler.ContactManager.GetContact(chatParticipant));

            //} 
            this._chatManagers = new List<string>();
            string[] chatManagersArray = chatManagers.Split('#');
            foreach (string chatManager in chatManagersArray)
            {
                this._chatManagers.Add(chatManager);

            }
            this._lastMessageTime = lastMessageTime;
            this._chatProfilePicture = chatProfilePicture;
            this._lastMessageContent = lastMessageContent;
            this._isGroupChat = (_chatParticipants.Count > 1);
        }
        public Chat(string Name)
        {
            this._chatName = Name;
        }
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
        public string GetLastMessageTime()
        {
            DateTime CurrentDate = DateTime.Now;
            DateTime yesterdayDate = DateTime.Now.AddDays(-1);
            DateTime lastWeekDate = DateTime.Now.AddDays(-7);

            if (_lastMessageTime.Date == CurrentDate.Date)
            {
                return _lastMessageTime.ToString("HH:mm");
            }
            else if(_lastMessageTime.Date == yesterdayDate.Date)
            {
                return "yesterday";

            }
            else if ((_lastMessageTime.Date >= lastWeekDate.Date) && (_lastMessageTime.Date < yesterdayDate.Date))
            {
                return _lastMessageTime.DayOfWeek.ToString();
            }
            else if (_lastMessageTime.Year == CurrentDate.Year)
            {
                return _lastMessageTime.ToString("MM/dd");
            }
            else
            {
                return _lastMessageTime.ToString("dd/MM/yyyy");
            }
        }
        public void SetLastMessageTime(DateTime lastMessageSentTime)
        {
            _lastMessageTime = lastMessageSentTime;
        }
        public DateTime GetLastMessageTimeObject()
        {
            return _lastMessageTime;
        }

    }
}
