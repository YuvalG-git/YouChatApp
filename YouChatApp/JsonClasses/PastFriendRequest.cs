﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.JsonClasses
{
    public class PastFriendRequest
    {
        private string _username;
        private string _profilePicture;
        private DateTime _friendRequestDate;

        public PastFriendRequest(string username, string profilePicture, DateTime friendRequestDate)
        {
            _username = username;
            _profilePicture = profilePicture;
            _friendRequestDate = friendRequestDate;
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string ProfilePicture
        {
            get { return _profilePicture; }
            set { _profilePicture = value; }
        }
        public DateTime FriendRequestDate
        {
            get { return _friendRequestDate; }
            set { _friendRequestDate = value; }
        }
    }
}
