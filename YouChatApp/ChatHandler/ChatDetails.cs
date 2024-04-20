﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ChatHandler
{
    public class ChatDetails
    {
        private string _chatTagLineId;
        private string _messageHistory;
        private DateTime? _lastMessageTime;
        private string _lastMessageContent;
        private List<ChatParticipant> _chatParticipants;

        public ChatDetails(string chatTagLineId, string messageHistory, DateTime? lastMessageTime, string lastMessageContent, List<ChatParticipant> chatParticipants)
        {
            _chatTagLineId = chatTagLineId;
            _messageHistory = messageHistory;
            _lastMessageTime = lastMessageTime;
            _lastMessageContent = lastMessageContent;
            _chatParticipants = chatParticipants;
        }

        public string ChatTagLineId
        {
            get
            {
                return _chatTagLineId;
            }
            set
            {
                _chatTagLineId = value;
            }
        }
        public string MessageHistory
        {
            get
            {
                return _messageHistory;
            }
            set
            {
                _messageHistory = value;
            }
        }
        public DateTime? LastMessageTime
        {
            get
            {
                return _lastMessageTime;
            }
            set
            {
                _lastMessageTime = value;
            }
        }
        public string LastMessageContent
        {
            get
            {
                return _lastMessageContent;
            }
            set
            {
                _lastMessageContent = value;
            }
        }
        public List<ChatParticipant> ChatParticipants
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
        public bool UserExist(string username)
        {
            string chatParticipantName;
            foreach (ChatParticipant chatParticipant in _chatParticipants)
            {
                chatParticipantName = chatParticipant.Username;
                if (chatParticipantName == username)
                {
                    return true;
                }
            }
            return false;
        }
        public string GetLastMessageTime()
        {
            return TimeHandler.GetFormatTime(_lastMessageTime);
        }
        public void SetLastMessageTime(DateTime lastMessageSentTime)
        {
            _lastMessageTime = lastMessageSentTime;
        }
        public DateTime? GetLastMessageTimeObject()
        {
            return _lastMessageTime;
        }
    }
}