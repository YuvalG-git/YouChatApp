using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    internal class PasswordHandler
    {
        public static string PasswordStrength { get; set; }
        public static string PasswordInformation { get; set; }
        public static Color PasswordInformationColor { get; set; }
        public static bool ContainUppercase(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsUpper(PasswordChar))
                    return true;
            }
            return false;
        }
        public static bool ContainLowercase(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsLower(PasswordChar))
                    return true;
            }
            return false;
        }
        public static bool ContainDigit(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsDigit(PasswordChar))
                    return true;
            }
            return false;
        }
        public static bool ContainSpecial(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsSymbol(PasswordChar))
                    return true;
            }
            return false;
        }
        public static int CharNumber(string Password)
        {
            return Password.Length;
        }

        public static string CheckPassword(string Password)
        {
            PasswordInformation = "";
            string PasswordAcceptanceText = "";
            List<string> CharsNotInPassword = new List<string>();
            if (CharNumber(Password) < 8) //also need to make sure the password is shorter than some value (20,24 for example...) - need to add it...
            {
                CharsNotInPassword.Add("eight characters");
            }
            else if(CharNumber(Password) > 24)
            {
                CharsNotInPassword.Add("twenty four characters"); //how  to change the at least to max of...

            }
            if (!ContainLowercase(Password))
            {
                CharsNotInPassword.Add("one lowercase");
            }
            if (!ContainUppercase(Password))
            {
                CharsNotInPassword.Add("one uppercase");

            }
            if (!ContainDigit(Password))
            {
                CharsNotInPassword.Add("one digit");

            }
            if (!ContainSpecial(Password))
            {
                CharsNotInPassword.Add("one special symbol");
            }
            if (CharsNotInPassword.Count == 0)
            {
                PasswordAcceptanceText = "That's a strong password";
                PasswordInformation = "That's a strong password";
                PasswordInformationColor = Color.Green;

                //change color to green
            }
            else
            {
                PasswordAcceptanceText = "Your password must contain at least";
                if (CharsNotInPassword.Count == 1)
                {
                    PasswordAcceptanceText += CharsNotInPassword[0];
                    PasswordInformation = "That's a medium password";
                    PasswordInformationColor = Color.Yellow;

                    //change color to yellow
                    //maybe add a line of : "that a Medium password and weak"

                }
                else
                {
                    int NumberOfInsertedMissingCharRequirement = 0;
                    foreach (string MissingCharRequirement in CharsNotInPassword)
                    {
                        PasswordAcceptanceText += MissingCharRequirement;
                        if (CharsNotInPassword.Count - 2 == NumberOfInsertedMissingCharRequirement)
                        {
                            PasswordAcceptanceText += MissingCharRequirement + " And ";

                        }
                        else if ((CharsNotInPassword.Count - 1 > NumberOfInsertedMissingCharRequirement))
                        {
                            PasswordAcceptanceText += MissingCharRequirement + ", ";

                        }
                        NumberOfInsertedMissingCharRequirement++;
                    }
                    PasswordInformation = "That's a weak password";
                    PasswordInformationColor = Color.Red;

                }

            }
            return PasswordAcceptanceText;
        }
    }
}
