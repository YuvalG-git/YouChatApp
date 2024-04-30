using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.UserProfile
{
    /// <summary>
    /// The "ProfileDetailsHandler" class manages user profile details such as name, tagline, profile picture, and status.
    /// </summary>
    /// <remarks>
    /// This class provides properties to get or set the user's name, tagline, profile picture ID, profile picture, and status.
    /// </remarks>
    internal class ProfileDetailsHandler
    {
        #region Private Static Fields

        /// <summary>
        /// The static string "name" represents the name.
        /// </summary>
        private static string name;

        /// <summary>
        /// The static string "tagLine" represents the tagline.
        /// </summary>
        private static string tagLine;

        /// <summary>
        /// The static string "profilePictureId" represents the profile picture ID.
        /// </summary>
        private static string profilePictureId;

        /// <summary>
        /// The static Image "profilePicture" represents the profile picture.
        /// </summary>
        private static Image profilePicture;

        /// <summary>
        /// The static string "status" represents the status.
        /// </summary>
        private static string status;

        #endregion

        #region Static Properties

        /// <summary>
        /// The "Name" property represents the user's name.
        /// It gets or sets the user's name.
        /// </summary>
        /// <value>
        /// The user's name.
        /// </value>
        public static string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// The "TagLine" property represents the user's tag line.
        /// It gets or sets the user's tag line.
        /// </summary>
        /// <value>
        /// The user's tag line.
        /// </value>
        public static string TagLine
        {
            get
            {
                return tagLine;
            }
            set
            {
                tagLine = value;
            }
        }

        /// <summary>
        /// The "ProfilePictureId" property represents the user's profile picture ID.
        /// It gets or sets the user's profile picture ID.
        /// </summary>
        /// <value>
        /// The user's profile picture ID.
        /// </value>
        public static string ProfilePictureId
        {
            get
            {
                return profilePictureId;
            }
            set
            {
                profilePictureId = value;
            }
        }

        /// <summary>
        /// The "ProfilePicture" property represents the user's profile picture.
        /// It gets or sets the user's profile picture.
        /// </summary>
        /// <value>
        /// The user's profile picture.
        /// </value>
        public static Image ProfilePicture
        {
            get
            {
                return profilePicture;
            }
            set
            {
                profilePicture = value;
            }
        }

        /// <summary>
        /// The "Status" property represents the user's status.
        /// It gets or sets the user's status.
        /// </summary>
        /// <value>
        /// The user's status.
        /// </value>
        public static string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        #endregion
    }
}
