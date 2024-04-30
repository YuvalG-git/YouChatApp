using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YouChatApp
{
    /// <summary>
    /// The "StringHandler" class provides static methods for handling and validating strings.
    /// </summary>
    /// <remarks>
    /// This class includes methods for checking if a string contains only numeric characters, alphabetic characters or white spaces,
    /// alphanumeric characters or white spaces, and for calculating the length of a string excluding white spaces.
    /// </remarks>
    internal class StringHandler
    {
        #region Public Static Methods

        /// <summary>
        /// The "IsNumeric" method determines whether the specified string contains only numeric characters.
        /// </summary>
        /// <param name="number">The string to check for numeric characters.</param>
        /// <returns>True if the string contains only numeric characters; otherwise, false.</returns>
        /// <remarks>
        /// This method iterates through each character in the specified string.
        /// If any character is not a numeric character, the method returns false.
        /// If all characters are numeric, the method returns true.
        /// </remarks>
        public static bool IsNumeric(string number)
        {
            foreach (char charValue in number)
            {
                if (!char.IsNumber(charValue))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The "IsAlphaOrWhiteSpace" method determines whether the specified string contains only alphabetic characters or white spaces.
        /// </summary>
        /// <param name="text">The string to check for alphabetic characters or white spaces.</param>
        /// <returns>True if the string contains only alphabetic characters or white spaces; otherwise, false.</returns>
        /// <remarks>
        /// This method iterates through each character in the specified string.
        /// If any character is not an alphabetic character or a white space, the method returns false.
        /// If all characters are alphabetic characters or white spaces, the method returns true.
        /// </remarks>
        public static bool IsAlphaOrWhiteSpace(string text)
        {
            foreach (char charValue in text)
            {
                if (!char.IsLetter(charValue) && !char.IsWhiteSpace(charValue))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The "IsAlphanumeric" method determines whether the specified string contains only alphanumeric characters or white spaces.
        /// </summary>
        /// <param name="text">The string to check for alphanumeric characters or white spaces.</param>
        /// <returns>True if the string contains only alphanumeric characters or white spaces; otherwise, false.</returns>
        /// <remarks>
        /// This method iterates through each character in the specified string.
        /// If any character is not an alphanumeric character or a white space, the method returns false.
        /// If all characters are alphanumeric characters or white spaces, the method returns true.
        /// </remarks>
        public static bool IsAlphanumeric(string text)
        {
            foreach (char charValue in text)
            {
                if (!char.IsLetterOrDigit(charValue) && !char.IsWhiteSpace(charValue))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The "LengthWithoutWhiteSpace" method calculates the length of the specified string excluding white spaces.
        /// </summary>
        /// <param name="text">The string to calculate the length of, excluding white spaces.</param>
        /// <returns>The length of the string excluding white spaces.</returns>
        /// <remarks>
        /// This method iterates through each character in the specified string.
        /// If the character is not a white space, the method increments the count.
        /// The method returns the final count, which represents the length of the string excluding white spaces.
        /// </remarks>
        public static int LengthWithoutWhiteSpace(string text)
        {
            int count = 0;
            foreach (char charValue in text)
            {
                if (!char.IsWhiteSpace(charValue))
                {
                    count++;
                }
            }
            return count;
        }

        #endregion
    }
}
