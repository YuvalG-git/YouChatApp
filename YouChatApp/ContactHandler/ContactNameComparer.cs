using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.ContactHandler
{
    /// <summary>
    /// The "ContactNameComparer" class implements the IComparer<Contact> interface to compare Contact objects based on their names.
    /// </summary>
    /// <remarks>
    /// This class provides a Compare method that compares the names of two Contact objects using string.Compare with StringComparison.Ordinal.
    /// The Compare method returns a value that indicates the relative order of the names: less than zero if contact1.Name is less than contact2.Name, zero if they are equal, or greater than zero if contact1.Name is greater than contact2.Name.
    /// </remarks>
    public class ContactNameComparer : IComparer<Contact>
    {
        #region Public Methods

        /// <summary>
        /// The "Compare" method compares two Contact objects based on their names.
        /// </summary>
        /// <param name="contact1">The first Contact object to compare.</param>
        /// <param name="contact2">The second Contact object to compare.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared.
        /// The return value has the following meanings:
        /// - Less than zero: contact1.Name is less than contact2.Name.
        /// - Zero: contact1.Name equals contact2.Name.
        /// - Greater than zero: contact1.Name is greater than contact2.Name.
        /// </returns>
        /// <remarks>
        /// This method compares the names of the two Contact objects using the string.Compare method with StringComparison.Ordinal.
        /// It returns a value that indicates the relative order of the names.
        /// </remarks>
        public int Compare(Contact contact1, Contact contact2)
        {
            return string.Compare(contact1.Name, contact2.Name, StringComparison.Ordinal);
        }

        #endregion
    }
}
