using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ContactHandler
{
    internal class Contact //will be used for managing the users information...
    {
        public string Name { get; set; }
        public Image ProfilePicture { get; set; }
        public string Status { get; set; }
        public DateTime LastSeenTime { get; set; }
        public bool LastSeenProperty { get; set; }
        public bool OnlineProperty { get; set; }
        public bool ProfilePictureProperty { get; set; }
        public bool StatusProperty { get; set; }
        public bool IsContact { get; set; } //most of them will be contacts but some of them won't be - for example someone sent me a contact and i can see his stats...

        public Contact(string Name, Image ProfilePicture, string Status, DateTime LastSeenTime, bool LastSeenProperty, bool OnlineProperty, bool ProfilePictureProperty, bool StatusProperty, bool IsContact)
        {
            this.Name = Name;
            this.ProfilePicture = ProfilePicture;
            this.Status = Status;
            this.LastSeenTime = LastSeenTime;
            this.LastSeenProperty = LastSeenProperty;
            this.OnlineProperty = OnlineProperty;
            this.ProfilePictureProperty = ProfilePictureProperty;
            this.StatusProperty = StatusProperty;
            this.IsContact = IsContact;
        }



    }
}
