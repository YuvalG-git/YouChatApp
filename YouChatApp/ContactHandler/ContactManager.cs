using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Drawing;

namespace YouChatApp.ContactHandler
{
    /// <summary>
    /// The "ContactManager" class manages the collection of user contacts.
    /// </summary>
    /// <remarks>
    /// This class provides methods to add contacts to the collection and retrieve contacts by name.
    /// </remarks>
    public class ContactManager
    {
        #region Private Static Fields

        /// <summary>
        /// The static List<Contact> "_userContacts" represents the list of user contacts.
        /// </summary>
        private static List<Contact> _userContacts = new List<Contact>();

        #endregion

        #region Static Properties

        /// <summary>
        /// The "UserContacts" property represents the list of contacts for a user.
        /// It gets or sets the list of contacts for the user.
        /// </summary>
        /// <value>
        /// The list of contacts for the user.
        /// </value>
        public static List<Contact> UserContacts
        {
            get
            {
                return _userContacts;
            }
            set
            {
                _userContacts = value;
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// The "InsertAlphabetically" method inserts a Contact into the _userContacts list in alphabetical order.
        /// </summary>
        /// <param name="contact">The Contact to insert.</param>
        /// <remarks>
        /// This method uses the BinarySearch method with a custom comparer to find the correct insertion index for the Contact.
        /// If the Contact is not found, it converts the index to the insertion point.
        /// It then inserts the Contact at the calculated index to maintain alphabetical order.
        /// </remarks>
        private static void InsertAlphabetically(Contact contact)
        {
            int index = _userContacts.BinarySearch(contact, new ContactHandler.ContactNameComparer());

            if (index < 0)
            {
                // If the element is not found, convert the index to the insertion point
                index = ~index;
            }

            // Insert the new string at the calculated index
            _userContacts.Insert(index, contact);
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// The "AddContact" method adds a Contact to the collection, ensuring it is inserted alphabetically.
        /// </summary>
        /// <param name="contact">The Contact to add.</param>
        /// <remarks>
        /// This method inserts the Contact into the collection at the correct position to maintain alphabetical order.
        /// It uses the InsertAlphabetically method to ensure the Contact is inserted in the correct order.
        /// </remarks>
        public static void AddContact(Contact contact)
        {
            InsertAlphabetically(contact);
        }

        /// <summary>
        /// The "GetContact" method retrieves a Contact from the _userContacts list based on the contact's name.
        /// </summary>
        /// <param name="ContactName">The name of the Contact to retrieve.</param>
        /// <returns>The Contact with the specified name, or null if not found.</returns>
        /// <remarks>
        /// This method iterates through the _userContacts list and checks each Contact's name.
        /// If a Contact with the specified name is found, it is returned.
        /// If no Contact is found with the specified name, null is returned.
        /// </remarks>
        public static Contact GetContact(string ContactName)
        {
            foreach (Contact contact in _userContacts)
            {
                if (contact.Name == ContactName)
                    return contact;
            }
            return null;
        }

        #endregion
    }
}
