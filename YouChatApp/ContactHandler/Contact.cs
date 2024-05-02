using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ContactHandler
{
    /// <summary>
    /// The "Contact" class represents a contact in the application.
    /// </summary>
    /// <remarks>
    /// This class stores information about a contact, including their name, ID, profile picture, status, last seen time, and online status.
    /// </remarks>
    public class Contact
    {
        #region Private Fields

        /// <summary>
        /// The string "_name" represents the name of the user.
        /// </summary>
        private string _name;

        /// <summary>
        /// The string "_id" represents the ID of the user.
        /// </summary>
        private string _id;

        /// <summary>
        /// The Image "_profilePicture" represents the profile picture of the user.
        /// </summary>
        private Image _profilePicture;

        /// <summary>
        /// The string "_status" represents the status of the user.
        /// </summary>
        private string _status;

        /// <summary>
        /// The DateTime "_lastSeenTime" represents the last seen time of the user.
        /// </summary>
        private DateTime _lastSeenTime;

        /// <summary>
        /// The bool "_online" indicates whether the user is currently online.
        /// </summary>
        private bool _online;

        #endregion

        #region Constructors

        /// <summary>
        /// The "Contact" constructor initializes a new instance of the <see cref="Contact"/> class with the specified parameters.
        /// </summary>
        /// <param name="contact">An instance of <see cref="ContactDetails"/> containing details of the contact.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the Contact class, representing a contact in the application,
        /// using the details provided in the <paramref name="contact"/> parameter.
        /// It initializes the contact's name, ID, profile picture, status, last seen time, and online status using the details from the <paramref name="contact"/>.
        /// </remarks>
        public Contact(ContactDetails contact)
        {
            _name = contact.Name;
            _id = contact.Id;
            _profilePicture = ProfilePictureImageList.GetImageByImageId(contact.ProfilePicture);                                                                                     ;
            _status = contact.Status;
            _lastSeenTime = contact.LastSeenTime;
            _online = contact.Online;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "Name" property represents the name of a user.
        /// It gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
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

        /// <summary>
        /// The "Id" property represents the unique identifier of a user.
        /// It gets or sets the unique identifier of the user.
        /// </summary>
        /// <value>
        /// The unique identifier of the user.
        /// </value>
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

        /// <summary>
        /// The "ProfilePicture" property represents the profile picture of a user.
        /// It gets or sets the profile picture of the user.
        /// </summary>
        /// <value>
        /// The profile picture of the user.
        /// </value>
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

        /// <summary>
        /// The "Status" property represents the status message of a user.
        /// It gets or sets the status message of the user.
        /// </summary>
        /// <value>
        /// The status message of the user.
        /// </value>
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

        /// <summary>
        /// The "LastSeenTime" property represents the last seen time of a user.
        /// It gets or sets the last seen time of the user.
        /// </summary>
        /// <value>
        /// The last seen time of the user.
        /// </value>
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

        /// <summary>
        /// The "Online" property represents whether a user is currently online.
        /// It gets or sets the online status of the user.
        /// </summary>
        /// <value>
        /// true if the user is online; otherwise, false.
        /// </value>
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

        #endregion
    }
}
