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
        private string passwordStrength;
        private string passwordInformation;
        private Color passwordInformationColor;
        public string PasswordStrength
        {
            get
            {
                return this.passwordStrength;
            }
            set
            {
                this.passwordStrength = value;
            }
        }
        public string PasswordInformation
        {
            get
            {
                return this.passwordInformation;
            }
            set
            {
                this.passwordInformation = value;
            }
        }
        public Color PasswordInformationColor
        {
            get
            {
                return this.passwordInformationColor;
            }
            set
            {
                this.passwordInformationColor = value;
            }
        }

        public PasswordHandler()
        {
            this.PasswordStrength = "That's a weak password";
            this.PasswordInformation = "";
            this.PasswordInformationColor = Color.Red;
        }
        private bool ContainUppercase(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsUpper(PasswordChar))
                    return true;
            }
            return false;
        }
        private bool ContainLowercase(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsLower(PasswordChar))
                    return true;
            }
            return false;
        }
        private bool ContainDigit(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsDigit(PasswordChar))
                    return true;
            }
            return false;
        }
        private bool ContainSpecial(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsSymbol(PasswordChar))
                    return true;
            }
            return false;
        }
        private int CharNumber(string Password)
        {
            return Password.Length;
        }

        public void CheckPassword(string Password)
        {
            passwordInformation = "";
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
                passwordInformation = "That's a strong password";
                passwordStrength = "That's a strong password";
                passwordInformationColor = Color.LimeGreen;

                //change color to green
            }
            else
            {
                passwordInformation = "Your password must contain at least ";
                if (CharsNotInPassword.Count == 1)
                {
                    passwordInformation += CharsNotInPassword[0];
                    passwordStrength = "That's a medium password";
                    passwordInformationColor = Color.Yellow;

                    //change color to yellow
                    //maybe add a line of : "that a Medium password and weak"

                }
                else
                {
                    int NumberOfInsertedMissingCharRequirement = 0;
                    foreach (string MissingCharRequirement in CharsNotInPassword)
                    {
                        passwordInformation += MissingCharRequirement;
                        if (CharsNotInPassword.Count - 2 == NumberOfInsertedMissingCharRequirement)
                        {
                            passwordInformation += " and ";

                        }
                        else if ((CharsNotInPassword.Count - 1 > NumberOfInsertedMissingCharRequirement))
                        {
                            passwordInformation += ", ";

                        }
                        NumberOfInsertedMissingCharRequirement++;
                    }
                    passwordStrength = "That's a weak password";
                    passwordInformationColor = Color.Red;
                }
            }
        }
    }
}
