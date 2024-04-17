﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.ContactHandler;
using YouChatServer.ChatHandler;
using YouChatServer.ContactHandler;

namespace YouChatApp.JsonClasses
{
    public class ContactAndChat
    {
        private ChatHandler.Chat _chat;
        private ContactDetails _contactDetails;

        public ContactAndChat(ChatHandler.Chat chat, ContactDetails contactDetails)
        {
            _chat = chat;
            _contactDetails = contactDetails;
        }

        public ChatHandler.Chat Chat
        {
            get
            {
                return _chat;
            }
            set
            {
                _chat = value;
            }
        }
        public ContactDetails ContactDetails
        {
            get
            {
                return _contactDetails;
            }
            set
            {
                _contactDetails = value;
            }
        }
    }
}
