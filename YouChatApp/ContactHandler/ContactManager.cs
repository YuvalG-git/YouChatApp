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
    internal class ContactManager //does the server should send the contact manager all together or to send and then wait for a response and send again until there aren't more (like pingpong) in order to prevent two much being sent...
    {
        public static List<Contact> UserContacts = new List<Contact>();

        public static void AddContact(string Name, Image ProfilePicture, string Status, DateTime LastSeenTime, bool LastSeenProperty, bool OnlineProperty, bool ProfilePictureProperty, bool StatusProperty, bool IsContact)
        {
            Contact NewContact = new Contact(Name, ProfilePicture, Status, LastSeenTime, LastSeenProperty, OnlineProperty, ProfilePictureProperty, StatusProperty, IsContact);
            //UserContacts.Add(NewContact);
            InsertAlphabetically(NewContact);
        }
        public static void AddContact(string Name)
        {
            Contact NewContact = new Contact(Name);
            //UserContacts.Add(NewContact);
            InsertAlphabetically(NewContact);
        }
        private static void InsertAlphabetically(Contact contact)
        {
            int index = UserContacts.BinarySearch(contact, new ContactHandler.ContactNameComparer());

            if (index < 0)
            {
                // If the element is not found, convert the index to the insertion point
                index = ~index;
            }

            // Insert the new string at the calculated index
            UserContacts.Insert(index, contact);
        }
        public static Contact GetContact(string ContactName)
        {
            foreach (Contact contact in UserContacts)
            {
                if (contact.Name == ContactName)
                    return contact;
            }
            return null; //wont get here beacuse i will call iscontactexist method before...
        }

        public static bool IsContactExist(string ContactName)
        {
            foreach (Contact contact in UserContacts)
            {
                if (contact.Name == ContactName)
                    return true;
            }
            return false;
        }


    }
}
