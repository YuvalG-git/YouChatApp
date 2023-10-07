using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ContactHandler
{
    internal class ContactNameComparer : IComparer<Contact>
    {
        public int Compare(Contact contact1, Contact contact2)
        {
            return string.Compare(contact1.Name, contact2.Name, StringComparison.Ordinal);
        }
    }
}
