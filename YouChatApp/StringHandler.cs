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
    /// The class provides methods for handling and validating strings.
    /// </summary>
    internal class StringHandler
    {
        /// <summary>
        /// The method checks if the given string consists of only numeric characters.
        /// </summary>
        /// <param name="number">The string to check.</param>
        /// <returns>True if the string is numeric, false otherwise.</returns>
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
        /// The method checks if the given string consists of only alphabetical characters.
        /// </summary>
        /// <param name="text">The string to check.</param>
        /// <returns>True if the string is alphabetical, false otherwise.</returns>
        public static bool IsAlpha(string text)
        {
            foreach (char charValue in text)
            {
                if (!char.IsLetter(charValue))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The method checks if the given string consists of only alphabetical characters or whitespaces.
        /// </summary>
        /// <param name="text">The string to check.</param>
        /// <returns>True if the string is alphabetical or contains only whitespaces, false otherwise.</returns>
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
        /// The method checks if the given string consists of only alphanumeric characters or whitespaces.
        /// </summary>
        /// <param name="text">The string to check.</param>
        /// <returns>True if the string is alphanumeric or contains only whitespaces, false otherwise.</returns>
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
        /// The method calculates the length of the given string excluding whitespaces.
        /// </summary>
        /// <param name="text">The string to calculate the length for.</param>
        /// <returns>The length of the string excluding whitespaces.</returns>
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
    }
}
