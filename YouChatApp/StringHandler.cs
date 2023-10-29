using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YouChatApp
{
    internal class StringHandler
    {
        //public static bool IsNumeric(string number)
        //{
        //    return number.All(char.IsNumber);
        //}
        //public static  bool IsAlpha(string text)
        //{
        //    return text.All(char.IsLetter);

        //}
        //public static bool IsAlphanumeric(string text)
        //{
        //    //return number.All(char.IsLetterOrDigit);
        //    return text.All(Char => char.IsLetterOrDigit(Char) || char.IsWhiteSpace(Char));

        //}
        public static bool IsNumeric(string number)
        {
            foreach (char charValue in number)
            {
                // Check if the character is not a letter.
                if (!char.IsNumber(charValue))
                {
                    return false;
                }
            }
            return true;
        }
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
        //static bool IsAlphanumeric(string input)
        //{
        //    // Define a regular expression pattern that matches only letters and numbers.
        //    string pattern = "^[a-zA-Z0-9]+$";

        //    // Use Regex.IsMatch to check if the input matches the pattern.
        //    return Regex.IsMatch(input, pattern);
        //}
        //public static bool IsAlphanumeric(string input)
        //{
        //    foreach (char c in input)
        //    {
        //        // Check if the character is not a letter or a digit.
        //        if (!char.IsLetterOrDigit(c))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
