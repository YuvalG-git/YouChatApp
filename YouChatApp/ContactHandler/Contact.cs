﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ContactHandler
{
    public class Contact
    {
        private string _name;
        private string _id;
        private Image _profilePicture;
        private string _status;
        private DateTime _lastSeenTime;
        private bool _online;

        public Contact(ContactDetails contact)
        {
            _name = contact.Name;
            _id = contact.Id;
            _profilePicture = ProfilePictureImageList.GetImageByImageId(contact.ProfilePicture);                                                                                     ;
            _status = contact.Status;
            _lastSeenTime = contact.LastSeenTime;
            _online = contact.Online;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public Image ProfilePicture
        {
            get
            {
                return _profilePicture;
            }
            set
            {
                _profilePicture = value;
            }
        }
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public DateTime LastSeenTime
        {
            get
            {
                return _lastSeenTime;
            }
            set
            {
                _lastSeenTime = value;
            }
        }
        public bool Online
        {
            get
            {
                return _online;
            }
            set
            {
                _online = value;
            }
        }
    }
}
