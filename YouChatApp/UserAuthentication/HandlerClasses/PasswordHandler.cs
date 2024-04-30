using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    /// <summary>
    /// The "PasswordHandler" class manages password-related operations such as strength evaluation and additional information.
    /// </summary>
    /// <remarks>
    /// This class provides functionality for checking the strength of a password based on various criteria and provides additional information about the password's strength.
    /// </remarks>
    internal class PasswordHandler
    {
        #region Private Fields

        /// <summary>
        /// The string "passwordStrength" represents the strength of the password.
        /// </summary>
        private string passwordStrength;

        /// <summary>
        /// The string "passwordInformation" represents additional information about the password.
        /// </summary>
        private string passwordInformation;

        /// <summary>
        /// The Color "passwordInformationColor" represents the color of the password information.
        /// </summary>
        private Color passwordInformationColor;

        #endregion

        #region Constructors

        /// <summary>
        /// The "PasswordHandler" constructor initializes a new instance of the <see cref="PasswordHandler"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new instance of the PasswordHandler class, setting initial values for
        /// password strength, password information, and password information color.
        /// </remarks>
        public PasswordHandler()
        {
            this.PasswordStrength = "That's a weak password";
            this.PasswordInformation = "";
            this.PasswordInformationColor = Color.Red;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "PasswordStrength" property represents the strength of a password.
        /// It gets or sets the strength of a password.
        /// </summary>
        /// <value>
        /// The strength of a password.
        /// </value>
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

        /// <summary>
        /// The "PasswordInformation" property represents additional information about a password.
        /// It gets or sets the additional information about a password.
        /// </summary>
        /// <value>
        /// The additional information about a password.
        /// </value>
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

        /// <summary>
        /// The "PasswordInformationColor" property represents the color associated with additional information about a password.
        /// It gets or sets the color associated with the additional information about a password.
        /// </summary>
        /// <value>
        /// The color associated with the additional information about a password.
        /// </value>
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

        #endregion

        #region Private String Methods

        /// <summary>
        /// The "ContainUppercase" method checks if the given password contains an uppercase character.
        /// </summary>
        /// <param name="Password">The password to check.</param>
        /// <returns>True if the password contains an uppercase character, otherwise false.</returns>
        /// <remarks>
        /// This method iterates through each character in the password and checks if it is an uppercase character using char.IsUpper.
        /// If an uppercase character is found, it returns true. Otherwise, it returns false.
        /// </remarks>
        private bool ContainUppercase(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsUpper(PasswordChar))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// The "ContainLowercase" method checks if the given password contains a lowercase character.
        /// </summary>
        /// <param name="Password">The password to check.</param>
        /// <returns>True if the password contains a lowercase character, otherwise false.</returns>
        /// <remarks>
        /// This method iterates through each character in the password and checks if it is a lowercase character using char.IsLower.
        /// If a lowercase character is found, it returns true. Otherwise, it returns false.
        /// </remarks>
        private bool ContainLowercase(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsLower(PasswordChar))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// The "ContainDigit" method checks if the given password contains a digit.
        /// </summary>
        /// <param name="Password">The password to check.</param>
        /// <returns>True if the password contains a digit, otherwise false.</returns>
        /// <remarks>
        /// This method iterates through each character in the password and checks if it is a digit using char.IsDigit.
        /// If a digit is found, it returns true. Otherwise, it returns false.
        /// </remarks>
        private bool ContainDigit(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsDigit(PasswordChar))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// The "ContainSpecial" method checks if the given password contains a special character.
        /// </summary>
        /// <param name="Password">The password to check.</param>
        /// <returns>True if the password contains a special character, otherwise false.</returns>
        /// <remarks>
        /// This method iterates through each character in the password and checks if it is a special character using char.IsSymbol.
        /// If a special character is found, it returns true. Otherwise, it returns false.
        /// </remarks>
        private bool ContainSpecial(string Password)
        {
            foreach (char PasswordChar in Password)
            {
                if (char.IsSymbol(PasswordChar))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// The "CharNumber" method calculates the number of characters in the given password.
        /// </summary>
        /// <param name="Password">The password to calculate the number of characters for.</param>
        /// <returns>The number of characters in the password.</returns>
        /// <remarks>
        /// This method simply returns the length of the password, which is the number of characters it contains.
        /// </remarks>
        private int CharNumber(string Password)
        {
            return Password.Length;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "CheckPassword" method checks the strength of the provided password based on certain criteria.
        /// </summary>
        /// <param name="Password">The password to check for strength.</param>
        /// <remarks>
        /// This method checks if the password meets the following criteria:
        /// - Contains at least 8 characters.
        /// - Contains at most 50 characters.
        /// - Contains at least one lowercase letter.
        /// - Contains at least one uppercase letter.
        /// - Contains at least one digit.
        /// - Contains at least one special symbol.
        /// If the password meets all criteria, it is considered strong.
        /// If it fails to meet one or more criteria, it is considered medium or weak, depending on the number of missing criteria.
        /// </remarks>
        public void CheckPassword(string Password)
        {
            passwordInformation = "";
            List<string> CharsNotInPassword = new List<string>();
            if (CharNumber(Password) < 8)
            {
                CharsNotInPassword.Add("eight characters");
            }
            else if(CharNumber(Password) > 50)
            {
                CharsNotInPassword.Add("fifty characters");
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
            }
            else
            {
                passwordInformation = "Your password must contain at least ";
                if (CharsNotInPassword.Count == 1)
                {
                    passwordInformation += CharsNotInPassword[0];
                    passwordStrength = "That's a medium password";
                    passwordInformationColor = Color.Yellow;
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

        #endregion
    }
}
