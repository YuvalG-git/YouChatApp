using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using YouChatApp.Controls;
using YouChatApp.JsonClasses;
using YouChatApp.VerificationQuestion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace YouChatApp.UserAuthentication.Forms
{
    /// <summary>
    /// The "Registration" class represents the registration form for new users.
    /// It handles various aspects of the registration process, including email verification, password generation, and user information entry.
    /// </summary>
    /// <remarks>
    /// This class provides methods for validating user inputs, generating secure passwords, and sending verification emails.
    /// </remarks>
    public partial class Registration : Form
    {
        #region Private Readonly Fields

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" represents the server communicator instance.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        #endregion

        #region Private Fields

        /// <summary>
        /// The bool "smtpFail" indicates whether there was an SMTP failure.
        /// </summary>
        private bool smtpFail;

        /// <summary>
        /// The EnumHandler.RegistrationPhases_Enum "registrationPhase" represents the registration phase.
        /// </summary>
        private EnumHandler.RegistrationPhases_Enum registrationPhase;

        /// <summary>
        /// The bool "MaleButtonIsChecked" indicates whether the male button is checked.
        /// </summary>
        private bool MaleButtonIsChecked = false;

        /// <summary>
        /// The bool "FemaleButtonIsChecked" indicates whether the female button is checked.
        /// </summary>
        private bool FemaleButtonIsChecked = false;

        /// <summary>
        /// The bool "AnotherGenderButtonIsChecked" indicates whether another gender button is checked.
        /// </summary>
        private bool AnotherGenderButtonIsChecked = false;

        /// <summary>
        /// The string "Gender" represents the selected gender.
        /// </summary>
        private string Gender = "";

        #endregion

        #region Constructors

        /// <summary>
        /// The "Registration" constructor initializes a new instance of the <see cref="Registration"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up various components for the Registration form, including initializing the form,
        /// setting the default gender option, adding button click handlers for verification and password generation,
        /// setting up the SMTP control for email verification, setting the birth date range, and initializing registration phase variables.
        /// </remarks>
        public Registration()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            GenderOptionsCustomComboBox.SelectedIndex = 0;
            PersonalVerificationQuestionsControl.AddButtonClickHandler(HandleSendingEmailProcess);
            PasswordGeneratorControl.OnTextChangedEventHandler(PasswordGeneratorControl_TextChanged);

            SmtpControl.AddRestartSmtpCodeCustomButtonClickHandler(HandleSendingEmailProcess);
            SmtpControl.AddVerifyCustomButtonClickHandler(SendSmtpCode);

            BirthDateCustomDateTimePicker.MinDate = new DateTime(DateTime.Today.Year - 100, DateTime.Today.Month, DateTime.Today.Day);
            BirthDateCustomDateTimePicker.MaxDate = DateTime.Now;
            registrationPhase = EnumHandler.RegistrationPhases_Enum.Smtp;
            smtpFail = true;
        }

        #endregion

        #region Private Personal Verification Methods

        /// <summary>
        /// The "GenerateVerificationQuestionListOfArrays" method generates a list of string arrays containing verification questions and answers.
        /// </summary>
        /// <returns>A list of string arrays where each array contains a verification question at index 0 and its corresponding answer at index 1.</returns>
        /// <remarks>
        /// Retrieves verification questions and answers from the PersonalVerificationQuestionsControl.
        /// Iterates through the verification questions and answers, adding them to the list of string arrays.
        /// Returns the list of string arrays containing verification questions and answers.
        /// </remarks>
        private List<string[]> GenerateVerificationQuestionListOfArrays()
        {
            List<string[]> VerificationQuestionsAndAnswers = new List<string[]>();
            VerificationQuestionDetails verificationQuestionDetails;
            string Question;
            string Answer;
            VerificationQuestionHandler verificationQuestionHandler = PersonalVerificationQuestionsControl.GetVerificationQuestionHandler();
            for (int i = 0; i < 5; i++)
            {
                verificationQuestionDetails = verificationQuestionHandler.VerificationQuestionDetails[i];
                Question = verificationQuestionDetails.Question;
                Answer = verificationQuestionDetails.Answer;
                VerificationQuestionsAndAnswers.Add(new string[] { Question, Answer });
            }
            return VerificationQuestionsAndAnswers;
        }

        /// <summary>
        /// The "ContinueCustomButton_Click" method handles the event when the ContinueCustomButton is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method makes the PersonalVerificationQuestionsControl visible and disables the UserDetailsPanel.
        /// </remarks>
        private void ContinueCustomButton_Click(object sender, EventArgs e)
        {
            PersonalVerificationQuestionsControl.Visible = true;
            UserDetailsPanel.Enabled = false;
        }

        #endregion

        #region Smtp Methods

        /// <summary>
        /// The "SendSmtpCode" method sends the SMTP code for registration verification to the server.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the SMTP code entered by the user from the SmtpControl object.
        /// It then creates a message of type "RegistrationRequest_SmtpRegistrationCode" using the EnumHandler.CommunicationMessageID_Enum enumeration.
        /// The message content is set to the entered SMTP code.
        /// Finally, it sends the message to the server using the serverCommunicator object.
        /// </remarks>
        private void SendSmtpCode(object sender, EventArgs e)
        {
            string enteredSmtpCode = SmtpControl.GetCode();
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.RegistrationRequest_SmtpRegistrationCode;
            object messageContent = enteredSmtpCode;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "HandleSendingEmailProcess" method handles the process of sending an email.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method sets the SmtpControl to be visible and then calls another method named "HandleSendingEmailProcess" to continue the email sending process.
        /// </remarks>
        private void HandleSendingEmailProcess(object sender, EventArgs e)
        {
            SmtpControl.Visible = true;
            HandleSendingEmailProcess();
        }

        /// <summary>
        /// The "HandleProblematicDetails" method handles problematic details during the email sending process.
        /// </summary>
        /// <remarks>
        /// This method sets the SmtpControl to be disabled using the SetDisabled method.
        /// It also resets the form appearance to its default state using the ResetFormAppearance method.
        /// </remarks>
        public void HandleProblematicDetails()
        {
            SmtpControl.SetDisabled();
            ResetFormAppearance();
        }

        /// <summary>
        /// The "HandleSendingEmailProcess" method handles the process of sending an email registration request message to the server.
        /// </summary>
        /// <remarks>
        /// This method retrieves the username from the UsernameCustomTextBox and initializes a variable to track if the email sending failed previously.
        /// It then creates a SmtpVerification object with the username and the fail status.
        /// Next, it retrieves the email address from the EmailAddressCustomTextBox and creates a SmtpDetails object with the email address and the SmtpVerification object.
        /// It creates a message of type "RegistrationRequest_SmtpRegistrationMessage" using the EnumHandler.CommunicationMessageID_Enum enumeration.
        /// The message content is set to the SmtpDetails object containing the email address and verification details.
        /// Finally, it sends the message to the server using the serverCommunicator object.
        /// </remarks>
        private void HandleSendingEmailProcess()
        {
            string username = UsernameCustomTextBox.TextContent;
            bool afterFail = smtpFail;
            smtpFail = false;
            SmtpVerification smtpVerification = new SmtpVerification(username, afterFail);
            string emailAddress = EmailAddressCustomTextBox.TextContent;
            SmtpDetails userUsernameAndEmailAddress = new SmtpDetails(emailAddress, smtpVerification);
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.RegistrationRequest_SmtpRegistrationMessage;
            object messageContent = userUsernameAndEmailAddress;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "HandleRecievedEmail" method handles the process of receiving and handling an email verification code.
        /// </summary>
        /// <remarks>
        /// This method calls the HandleCode method of the SmtpControl object to handle the verification code received in the email.
        /// </remarks>
        public void HandleRecievedEmail()
        {
            SmtpControl.HandleCode();
        }

        /// <summary>
        /// The "HandleCodeResponse" method handles the response to the SMTP code verification process.
        /// </summary>
        /// <param name="correctCode">A boolean indicating whether the SMTP code was correct.</param>
        /// <remarks>
        /// If the correctCode parameter is true, this method makes the SignUpCustomButton visible and sets the registrationPhase to Registration.
        /// If the correctCode parameter is false, this method makes the ChangeEmailOptionLinkLabel and NewSMTPCodeOptionLinkLabel visible,
        /// sets smtpFail to true, and disables the SmtpControl.
        /// </remarks>
        public void HandleCodeResponse(bool correctCode)
        {
            if (correctCode)
            {
                SignUpCustomButton.Visible = true;
                registrationPhase = EnumHandler.RegistrationPhases_Enum.Registration;
            }
            else
            {
                ChangeEmailOptionLinkLabel.Visible = true;
                NewSMTPCodeOptionLinkLabel.Visible = true;
                smtpFail = true;
                SmtpControl.SetDisabled();
            }
        }

        /// <summary>
        /// The "ChangeEmailOptionLinkLabel_LinkClicked" method handles the event when the ChangeEmailOptionLinkLabel is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method resets the form appearance and hides the link labels.
        /// </remarks>
        private void ChangeEmailOptionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetFormAppearance();
            HideLinkLabels();
        }

        /// <summary>
        /// The "NewSMTPCodeOptionLinkLabel_LinkClicked" method handles the event when the NewSMTPCodeOptionLinkLabel is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event, which is the NewSMTPCodeOptionLinkLabel.</param>
        /// <param name="e">The event arguments, which provide information about the link click event.</param>
        /// <remarks>
        /// This method is used in the registration process to resend the SMTP verification email in case the user did not receive it or needs to request a new code.
        /// It first triggers the HandleSendingEmailProcess method to initiate the email sending process, and then hides the link labels to keep the interface clean and focused on the current step.
        /// </remarks>
        private void NewSMTPCodeOptionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HandleSendingEmailProcess();
            HideLinkLabels();
        }

        /// <summary>
        /// The "HideLinkLabels" method hides the ChangeEmailOptionLinkLabel and NewSMTPCodeOptionLinkLabel link labels.
        /// </summary>
        /// <remarks>
        /// This method is used to hide the link labels after certain actions in the registration process, such as when the user requests a new SMTP code or changes their email address.
        /// Hiding the link labels helps maintain a clean and focused interface for the user.
        /// </remarks>
        private void HideLinkLabels()
        {
            ChangeEmailOptionLinkLabel.Visible = false;
            NewSMTPCodeOptionLinkLabel.Visible = false;
        }

        #endregion

        #region Private Username Field Methods

        /// <summary>
        /// The "HandleUsernameContent" method handles the validation of the username entered in the UsernameCustomTextBox.
        /// </summary>
        /// <remarks>
        /// This method checks if the username is a placeholder and adjusts the border color and visibility of the UsernameExclamationCustomButton accordingly.
        /// If the username is not a placeholder, it checks if the username contains only letters and numbers, and if its length is within the valid range.
        /// If the username is invalid, it sets the border color to red, displays the UsernameExclamationCustomButton with an error tooltip, and sets the error message.
        /// If the username is valid, it sets the border color to LimeGreen and hides the UsernameExclamationCustomButton.
        /// </remarks>
        private void HandleUsernameContent()
        {
            string username = UsernameCustomTextBox.TextContent;
            string error = "";
            if (UsernameCustomTextBox.isPlaceHolder())
            {
                UsernameCustomTextBox.BorderColor = Color.MediumSlateBlue;
                UsernameExclamationCustomButton.Visible = false;
            }
            else
            {
                if (!StringHandler.IsAlphanumeric(username))
                {
                    error += "The username can only contain letters and numbers\r\n";
                }
                int length = StringHandler.LengthWithoutWhiteSpace(username);
                int realLength = username.Length;
                if (length < 4)
                {
                    error += "The username must be longer than 4 letters";
                }
                else if (realLength > 30)
                {
                    error += "The username must be shorter than 31 letters";
                }

                if (error != "")
                {
                    UsernameCustomTextBox.BorderColor = Color.Red;
                    UsernameExclamationCustomButton.Visible = true;
                    ToolTip.SetToolTip(UsernameExclamationCustomButton, error);
                }
                else
                {
                    UsernameExclamationCustomButton.Visible = false;
                    UsernameCustomTextBox.BorderColor = Color.LimeGreen;
                }
            }
        }

        /// <summary>
        /// The "UsernameCustomTextBox_TextChangedEvent" method handles the event when the text in the UsernameCustomTextBox changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandleUsernameContent method to handle the username content and enables or disables the ContinueCustomButton based on the username content.
        /// </remarks>
        private void UsernameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleUsernameContent();
            ContinueCustomButtonSetEnabled();
        }

        /// <summary>
        /// The "UsernameCustomTextBox_Leave" method handles the event when the UsernameCustomTextBox loses focus.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandleUsernameContent method to validate the username content when the UsernameCustomTextBox loses focus.
        /// </remarks>
        private void UsernameCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleUsernameContent();
        }

        #endregion

        #region Private Password Field Methods

        /// <summary>
        /// The "PasswordGeneratorControl_TextChanged" method handles the text changed event of the PasswordGeneratorControl to enable the ContinueCustomButton based on the text content.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the text in the PasswordGeneratorControl changes.
        /// It calls the "ContinueCustomButtonSetEnabled" method to enable or disable the ContinueCustomButton based on the text content of the PasswordGeneratorControl.
        /// </remarks>
        private void PasswordGeneratorControl_TextChanged(object sender, EventArgs e)
        {
            ContinueCustomButtonSetEnabled();
        }

        /// <summary>
        /// The "PasswordGeneratorControl_TextChangedEvent" method handles the event when the content of the PasswordGeneratorControl changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method updates the state of the ContinueCustomButton based on the validity of the password generated by the PasswordGeneratorControl.
        /// </remarks>
        private void PasswordGeneratorControl_TextChangedEvent(object sender, EventArgs e)
        {
            ContinueCustomButtonSetEnabled();
        }

        #endregion

        #region Private First Name Field Methods

        /// <summary>
        /// The "HandleFirstNameContent" method validates the content of the FirstNameCustomTextBox.
        /// </summary>
        /// <remarks>
        /// This method checks if the first name contains only letters and white spaces.
        /// It also validates the length of the first name, ensuring it is between 3 and 30 characters.
        /// If the content is invalid, it sets the border color of the FirstNameCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// </remarks>
        private void HandleFirstNameContent()
        {
            string firstName = FirstNameCustomTextBox.TextContent;
            string error = "";
            if (FirstNameCustomTextBox.isPlaceHolder())
            {
                FirstNameCustomTextBox.BorderColor = Color.MediumSlateBlue;
                FirstNameExclamationCustomButton.Visible = false;
            }
            else
            {
                if (!StringHandler.IsAlphaOrWhiteSpace(firstName))
                {
                    error += "The first name can only contain letters and white spaces\r\n";
                }
                int length = StringHandler.LengthWithoutWhiteSpace(firstName);
                int realLength = firstName.Length;
                if (length < 3)
                {
                    error += "The first name must be longer than 3 letters";
                }
                else if (realLength > 30)
                {
                    error += "The first name must be shorter than 31 letters";
                }

                if (error != "")
                {
                    FirstNameCustomTextBox.BorderColor = Color.Red;
                    FirstNameExclamationCustomButton.Visible = true;
                    ToolTip.SetToolTip(FirstNameExclamationCustomButton, error);
                }
                else
                {
                    FirstNameExclamationCustomButton.Visible = false;
                    FirstNameCustomTextBox.BorderColor = Color.LimeGreen;
                }
            }
        }

        /// <summary>
        /// The "FirstNameCustomTextBox_Leave" method handles the event when the FirstNameCustomTextBox loses focus.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandleFirstNameContent method to validate the first name content when the FirstNameCustomTextBox loses focus.
        /// </remarks>
        private void FirstNameCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleFirstNameContent();
        }

        /// <summary>
        /// The "FirstNameCustomTextBox_TextChangedEvent" method handles the event when the FirstNameCustomTextBox text changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method validates the content of the FirstNameCustomTextBox to ensure it contains only letters and white spaces and falls within a specified length range.
        /// If the content is invalid, it sets the border color of the FirstNameCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// It also enables or disables the ContinueCustomButton based on the validity of the FirstNameCustomTextBox content.
        /// </remarks>
        private void FirstNameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleFirstNameContent();
            ContinueCustomButtonSetEnabled();
        }

        #endregion

        #region Private Last Name Field Methods

        /// <summary>
        /// The "HandleLastNameContent" method validates the content of the LastNameCustomTextBox.
        /// </summary>
        /// <remarks>
        /// This method checks if the last name contains only letters.
        /// It also validates the length of the last name, ensuring it is between 3 and 30 characters.
        /// If the content is invalid, it sets the border color of the LastNameCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// </remarks>
        private void HandleLastNameContent()
        {
            string lastName = LastNameCustomTextBox.TextContent;
            string error = "";
            if (LastNameCustomTextBox.isPlaceHolder())
            {
                LastNameCustomTextBox.BorderColor = Color.MediumSlateBlue;
                LastNameExclamationCustomButton.Visible = false;
            }
            else
            {
                if (!StringHandler.IsAlphaOrWhiteSpace(lastName))
                {
                    error += "The last name can only contain letters\r\n";
                }
                int length = StringHandler.LengthWithoutWhiteSpace(lastName);
                int realLength = lastName.Length;

                if (length < 3)
                {
                    error += "The last name must be longer than 3 letters\r\n";
                }
                else if (realLength > 30)
                {
                    error += "The last name must be shorter than 31 letters\r\n";
                }


                if (error != "")
                {
                    LastNameCustomTextBox.BorderColor = Color.Red;
                    LastNameExclamationCustomButton.Visible = true;
                    ToolTip.SetToolTip(LastNameExclamationCustomButton, error);
                }
                else
                {
                    LastNameExclamationCustomButton.Visible = false;
                    LastNameCustomTextBox.BorderColor = Color.LimeGreen;
                }
            }
        }

        /// <summary>
        /// The "LastNameCustomTextBox_Leave" method handles the event when the LastNameCustomTextBox loses focus.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method validates the content of the LastNameCustomTextBox to ensure it contains only letters and falls within a specified length range.
        /// If the content is invalid, it sets the border color of the LastNameCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// </remarks>
        private void LastNameCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleLastNameContent();
        }

        /// <summary>
        /// The "LastNameCustomTextBox_TextChangedEvent" method handles the event when the LastNameCustomTextBox text changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method validates the content of the LastNameCustomTextBox to ensure it contains only letters and falls within a specified length range.
        /// If the content is invalid, it sets the border color of the LastNameCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// It also enables or disables the ContinueCustomButton based on the validity of the LastNameCustomTextBox content.
        /// </remarks>
        private void LastNameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleLastNameContent();
            ContinueCustomButtonSetEnabled();
        }

        #endregion

        #region Private City Name Field Methods

        /// <summary>
        /// The "HandleCityNameContent" method validates the content of the CityCustomTextBox.
        /// </summary>
        /// <remarks>
        /// This method checks that the city name contains only letters and white spaces.
        /// It also checks the length of the city name, ensuring it is between 4 and 60 characters.
        /// If the content is invalid, it sets the border color of the CityCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// </remarks>
        private void HandleCityNameContent()
        {
            string cityName = CityCustomTextBox.TextContent;
            string error = "";
            if (CityCustomTextBox.isPlaceHolder())
            {
                CityCustomTextBox.BorderColor = Color.MediumSlateBlue;
                CityExclamationCustomButton.Visible = false;
            }
            else
            {
                if (!StringHandler.IsAlphaOrWhiteSpace(cityName))
                {
                    error += "The city can only contain letters and white spaces\r\n";
                }
                int length = StringHandler.LengthWithoutWhiteSpace(cityName);
                int realLength = cityName.Length;
                if (length < 4)
                {
                    error += "The city name must be longer than 4 letters";
                }
                else if (realLength > 60)
                {
                    error += "The city name must be shorter than 60 letters (included)";
                }

                if (error != "")
                {
                    CityCustomTextBox.BorderColor = Color.Red;
                    CityExclamationCustomButton.Visible = true;
                    ToolTip.SetToolTip(CityExclamationCustomButton, error);
                }
                else
                {
                    CityExclamationCustomButton.Visible = false;
                    CityCustomTextBox.BorderColor = Color.LimeGreen;
                }
            }
        }

        /// <summary>
        /// The "CityCustomTextBox_Leave" method handles the event when the CityCustomTextBox loses focus.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method validates the content of the CityCustomTextBox to ensure it contains only letters and white spaces and falls within a specified length range.
        /// If the content is invalid, it sets the border color of the CityCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// </remarks>
        private void CityCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleCityNameContent();
        }

        /// <summary>
        /// The "CityCustomTextBox_TextChangedEvent" method handles the event when the CityCustomTextBox text changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method validates the content of the CityCustomTextBox to ensure it contains only letters and falls within a specified length range.
        /// If the content is invalid, it sets the border color of the CityCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// </remarks>
        private void CityCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleCityNameContent();
            ContinueCustomButtonSetEnabled();
        }

        #endregion

        #region Private Email Address Field Methods

        /// <summary>
        /// The "HandleEmailAddressContent" method validates the content of the EmailAddressCustomTextBox.
        /// </summary>
        /// <remarks>
        /// This method checks the format of the email address, ensuring it meets standard email address criteria.
        /// It checks for the presence of an '@' symbol, a domain after the '@' symbol, and a top-level domain (TLD) with at least two characters.
        /// It also validates the prefix, domain, and top-level domain for length and character restrictions.
        /// If the content is invalid, it sets the border color of the EmailAddressCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// </remarks>
        private void HandleEmailAddressContent()
        {
            string emailAddress = EmailAddressCustomTextBox.TextContent;
            string error = "";
            // Regular expression pattern for a valid email address
            string pattern = @"^[a-zA-Z0-9]+([._-][a-zA-Z0-9]+)*@[a-zA-Z0-9-]+\.[a-zA-Z0-9-]{2,}$";

            if (EmailAddressCustomTextBox.isPlaceHolder())
            {
                EmailAddressCustomTextBox.BorderColor = Color.MediumSlateBlue;
                EmailAddressExclamationCustomButton.Visible = false;
            }
            else
            {
                if (emailAddress.Length > 60)
                {
                    error += "The email address must not exceed 60 characters\r\n";
                }
                // Check for problematic parts in the email address
                int atIndex = emailAddress.IndexOf('@');
                int dotIndex = emailAddress.LastIndexOf('.');
                if (atIndex == -1)
                {
                    error += "The email address must contain an '@' symbol\r\n";
                }
                else if (dotIndex == -1)
                {
                    error += "The email address must contain an '.' symbol in the domain\r\n";
                }
                else if (dotIndex <= atIndex + 1)
                {
                    error += "The email address must have a domain after the '@' symbol\r\n";
                }
                else
                {
                    string prefix = emailAddress.Substring(0, atIndex);
                    if (prefix.Length < 1)
                    {
                        error += "The email address must have a prefix\r\n";
                    }

                    // Check the domain after the '@' symbol
                    string domain = emailAddress.Substring(atIndex + 1, dotIndex - atIndex - 1);
                    if (domain.Length < 1)
                    {
                        error += "The email address must have a domain\r\n";
                    }

                    // Check the top-level domain after the last dot
                    string topLevelDomain = emailAddress.Substring(dotIndex + 1);
                    if (topLevelDomain.Length < 2)
                    {
                        error += "The top-level domain must have at least two characters\r\n";
                    }

                    // Check if the prefix contains only allowed characters
                    if (!Regex.IsMatch(prefix, @"^[a-zA-Z0-9_.-]+$"))
                    {
                        error += "The email address prefix contains invalid characters\r\n";
                    }

                    // Check if special characters (underscore, period, dash) are followed by at least one letter or number in the prefix
                    if (Regex.IsMatch(prefix, @"[._-](?![a-zA-Z0-9]+$)"))
                    {
                        error += "Special characters (underscore, period, dash) in the prefix must be followed by at least one letter or number\r\n";
                    }
                    if (!char.IsLetterOrDigit(prefix[0]))
                    {
                        error += "The email address must start with a letter or number\r\n";
                    }

                    // Check if the domain contains only allowed characters
                    if (!Regex.IsMatch(domain, @"^[a-zA-Z0-9-]+$"))
                    {
                        error += "The email address domain contains invalid characters\r\n";
                    }

                    // Validate the domain against a list of known top-level domains (TLDs) to ensure it is valid
                    string[] validTLDs = { "com", "org", "net", "edu", "gov" }; // Add more if needed
                    string[] domainParts = topLevelDomain.Split('.');
                    if (!validTLDs.Contains(domainParts[domainParts.Length - 1].ToLower()))
                    {
                        error += "The email address domain has an invalid top-level domain (com, org, net, edu, gov)\r\n";
                    }
                }
                if (error == "" && Regex.IsMatch(emailAddress, pattern))
                {
                    EmailAddressExclamationCustomButton.Visible = false;
                    EmailAddressCustomTextBox.BorderColor = Color.LimeGreen;
                }
                else
                {
                    EmailAddressCustomTextBox.BorderColor = Color.Red;
                    EmailAddressExclamationCustomButton.Visible = true;
                    ToolTip.SetToolTip(EmailAddressExclamationCustomButton, error);
                }
            }
        }

        /// <summary>
        /// The "EmailAddressCustomTextBox_Leave" method handles the event when the EmailAddressCustomTextBox loses focus.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method validates the content of the EmailAddressCustomTextBox to ensure it is a valid email address.
        /// If the content is invalid, it sets the border color of the EmailAddressCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// </remarks>
        private void EmailAddressCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleEmailAddressContent();
        }

        /// <summary>
        /// The "EmailAddressCustomTextBox_TextChangedEvent" method handles the event when the content of the EmailAddressCustomTextBox changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method validates the content of the EmailAddressCustomTextBox to ensure it is a valid email address.
        /// If the content is invalid, it sets the border color of the EmailAddressCustomTextBox to red and displays an error message.
        /// Otherwise, it sets the border color to green.
        /// </remarks>
        private void EmailAddressCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleEmailAddressContent();
            ContinueCustomButtonSetEnabled();
        }

        #endregion

        #region Private Date Of Birth Field Methods

        /// <summary>
        /// The "BirthDateCustomDateTimePicker_ValueChanged" method handles the event when the BirthDateCustomDateTimePicker value changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method sets the custom format of the BirthDateCustomDateTimePicker to "dd/MM/yyyy" when the value changes.
        /// It also calls the ContinueCustomButtonSetEnabled method to enable or disable the continue button based on the form's validity.
        /// </remarks>
        private void BirthDateCustomDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            BirthDateCustomDateTimePicker.CustomFormat = "dd/MM/yyyy";
            ContinueCustomButtonSetEnabled();
        }

        /// <summary>
        /// The "BirthDateCustomDateTimePicker_KeyDown" method handles the event when a key is pressed while the BirthDateCustomDateTimePicker has focus.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The key event arguments.</param>
        /// <remarks>
        /// This method checks if the Backspace key was pressed. If it was, it restarts the content of the BirthDateCustomDateTimePicker.
        /// </remarks>
        private void BirthDateCustomDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                RestartBirthDateCustomDateTimePickerContent();
            }
        }

        /// <summary>
        /// The "RestartBirthDateCustomButton_Click" method handles the event when the RestartBirthDateCustomButton is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method restarts the content of the BirthDateCustomDateTimePicker.
        /// </remarks>
        private void RestartBirthDateCustomButton_Click(object sender, EventArgs e)
        {
            RestartBirthDateCustomDateTimePickerContent();
        }

        /// <summary>
        /// The "RestartBirthDateCustomDateTimePickerContent" method restarts the content of the BirthDateCustomDateTimePicker.
        /// </summary>
        /// <remarks>
        /// This method is called when the user presses the backspace key while the BirthDateCustomDateTimePicker has focus.
        /// It resets the CustomFormat of the BirthDateCustomDateTimePicker to a space character (" ") and updates the state of the ContinueCustomButton.
        /// </remarks>
        private void RestartBirthDateCustomDateTimePickerContent()
        {
            BirthDateCustomDateTimePicker.CustomFormat = " ";
            ContinueCustomButtonSetEnabled();
        }

        #endregion

        #region Private Gender Field Methods

        /// <summary>
        /// The "FemaleRadioButton_Click" method handles the event when the FemaleRadioButton is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method sets the MaleButtonIsChecked and AnotherGenderButtonIsChecked flags to false.
        /// It hides the GenderOptionsCustomComboBox.
        /// If the FemaleRadioButton is not checked, it sets the FemaleButtonIsChecked flag to true and sets the Gender property to "Female".
        /// If the FemaleRadioButton is already checked, it sets the FemaleButtonIsChecked flag to false and clears the Gender property.
        /// Finally, it updates the FemaleRadioButton's Checked property and calls ContinueCustomButtonSetEnabled method.
        /// </remarks>
        private void FemaleRadioButton_Click(object sender, EventArgs e)
        {
            MaleButtonIsChecked = false;
            AnotherGenderButtonIsChecked = false;
            GenderOptionsCustomComboBox.Visible = false;
            if (FemaleButtonIsChecked == false)
            {
                FemaleButtonIsChecked = true;
                Gender = "Female";
            }
            else
            {
                FemaleButtonIsChecked = false;
                Gender = "";
            }
            if (FemaleButtonIsChecked == true)
            {
                FemaleRadioButton.Checked = true;
            }
            else
            {
                FemaleRadioButton.Checked = false;
            }
            ContinueCustomButtonSetEnabled();
        }

        /// <summary>
        /// The "AnotherGenderRadioButton_Click" method handles the event when the AnotherGenderRadioButton is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method sets the MaleButtonIsChecked and FemaleButtonIsChecked flags to false.
        /// If the AnotherGenderButtonIsChecked flag is false, it sets the GenderOptionsCustomComboBox to visible and sets AnotherGenderButtonIsChecked to true.
        /// If the AnotherGenderButtonIsChecked flag is true, it sets the GenderOptionsCustomComboBox to hidden and sets AnotherGenderButtonIsChecked to false.
        /// It then clears the Gender property and updates the AnotherGenderRadioButton's Checked property.
        /// Finally, it calls the ContinueCustomButtonSetEnabled method to update the ContinueCustomButton's Enabled property.
        /// </remarks>
        private void AnotherGenderRadioButton_Click(object sender, EventArgs e)
        {
            MaleButtonIsChecked = false;
            FemaleButtonIsChecked = false;
            if (AnotherGenderButtonIsChecked == false)
            {
                GenderOptionsCustomComboBox.Visible = true;
                AnotherGenderButtonIsChecked = true;
            }
            else
            {
                GenderOptionsCustomComboBox.Visible = false;
                AnotherGenderButtonIsChecked = false;
            }
            Gender = "";
            if (AnotherGenderButtonIsChecked == true)
            {
                AnotherGenderRadioButton.Checked = true;
            }
            else
            {
                AnotherGenderRadioButton.Checked = false;
            }
            ContinueCustomButtonSetEnabled();
        }

        /// <summary>
        /// The "MaleRadioButton_Click" method handles the event when the MaleRadioButton is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method updates the state of the Gender variable and sets the visibility of the GenderOptionsCustomComboBox based on the MaleRadioButton state.
        /// It also updates the state of the ContinueCustomButton based on the selected gender.
        /// </remarks>
        private void MaleRadioButton_Click(object sender, EventArgs e)
        {
            FemaleButtonIsChecked = false;
            AnotherGenderButtonIsChecked = false;
            GenderOptionsCustomComboBox.Visible = false;
            if (MaleButtonIsChecked == false)
            {
                MaleButtonIsChecked = true;
                Gender = "Male";
            }
            else
            {
                MaleButtonIsChecked = false;
                Gender = "";
            }
            if (MaleButtonIsChecked == true)
            {
                MaleRadioButton.Checked = true;

            }
            else
            {
                MaleRadioButton.Checked = false;

            }
            ContinueCustomButtonSetEnabled();
        }

        /// <summary>
        /// The "RadioButtonIsChecked" method checks if any gender radio button is checked or if the custom gender option is selected.
        /// </summary>
        /// <returns>True if a gender radio button is checked or the custom gender option is selected, otherwise false.</returns>
        private bool RadioButtonIsChecked()
        {
            return (MaleButtonIsChecked || FemaleButtonIsChecked || (AnotherGenderButtonIsChecked && (GenderOptionsCustomComboBox.TextContent != "<Select A Gender>")));
        }

        /// <summary>
        /// The "GenderOptionsCustomComboBox_Enter" method handles the event when the GenderOptionsCustomComboBox receives focus.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// If the GenderOptionsCustomComboBox's DropDownStyle is DropDown, clears the text content of the GenderOptionsCustomComboBox.
        /// </remarks>
        private void GenderOptionsCustomComboBox_Enter(object sender, EventArgs e)
        {
            if (GenderOptionsCustomComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                GenderOptionsCustomComboBox.TextContent = "";
            }
        }

        /// <summary>
        /// The "GenderOptionsCustomComboBox_OnSelectedIndexChanged" method handles the event when the selected index of GenderOptionsCustomComboBox changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Updates the Gender property based on the selected item in GenderOptionsCustomComboBox.
        /// Enables or disables the ContinueCustomButton based on the selected item.
        /// Changes the DropDownStyle of GenderOptionsCustomComboBox to DropDown if "Other..." is selected, otherwise sets it to DropDownList.
        /// </remarks>
        private void GenderOptionsCustomComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenderOptionsCustomComboBox.TextContent != "<Select A Gender>")
            {
                Gender = GenderOptionsCustomComboBox.TextContent;
            }
            else
            {
                Gender = "";
            }
            ContinueCustomButtonSetEnabled();
            if (GenderOptionsCustomComboBox.TextContent == "Other...")
            {
                GenderOptionsCustomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            }
            else
            {
                GenderOptionsCustomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
        }

        /// <summary>
        /// The "GenderOptionsCustomComboBox_OnTextUpdate" method handles the event when the text is updated in GenderOptionsCustomComboBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Clears the text content of GenderOptionsCustomComboBox if its DropDownStyle is set to DropDown.
        /// </remarks>
        private void GenderOptionsCustomComboBox_OnTextUpdate(object sender, EventArgs e)
        {
            if (GenderOptionsCustomComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                GenderOptionsCustomComboBox.TextContent = "";
            }
        }

        #endregion

        #region Ban Handling Methods

        /// <summary>
        /// The "HandleBan" method handles the process of banning a user.
        /// </summary>
        /// <param name="banDuration">The duration of the ban in seconds.</param>
        /// <remarks>
        /// This method makes the BanControl visible and calls its HandleBan method to set the ban duration.
        /// It also calls the SetVisibility method with a parameter of false to hide other controls.
        /// </remarks>
        public void HandleBan(double banDuration)
        {
            BanControl.Visible = true;
            BanControl.HandleBan(banDuration);
            SetVisibility(false);
        }

        /// <summary>
        /// The "HandleBanOver" method handles the process when a user's ban is over.
        /// </summary>
        /// <remarks>
        /// This method hides the BanControl and calls the SetVisibility method with a parameter of true to show other controls.
        /// </remarks>
        public void HandleBanOver()
        {
            BanControl.Visible = false;
            SetVisibility(true);
        }

        /// <summary>
        /// The "SetVisibility" method sets the visibility of various controls based on the current registration phase.
        /// </summary>
        /// <param name="visible">A boolean indicating whether the controls should be visible or not.</param>
        /// <param name="captchaCircularImage">An optional circular image for the CAPTCHA.</param>
        /// <param name="captchaImage">An optional image for the CAPTCHA.</param>
        /// <param name="score">An optional score for the CAPTCHA.</param>
        /// <param name="attempts">An optional number of attempts for the CAPTCHA.</param>
        /// <remarks>
        /// This method iterates over the registration phases and sets the visibility of controls based on the current phase.
        /// For the Smtp phase, it sets the visibility of UserDetailsPanel, PersonalVerificationQuestionsControl, SmtpControl, and LoginReturnerCustomButton.
        /// If the controls should be visible and the current phase is the Smtp phase, it calls the HandleCodeResponse method with a false parameter
        /// to reset the SMTP code response and disables the SmtpControl.
        /// For the Registration phase, it hides the SignUpCustomButton.
        /// If the controls should be visible and the current phase is the Registration phase, it disables the SmtpControl and resets the form appearance.
        /// </remarks>
        private void SetVisibility(bool visible, Image captchaCircularImage = null, Image captchaImage = null, int score = 0, int attempts = 5)
        {
            for (int i = 0; i <= (int)registrationPhase; i++)
            {
                EnumHandler.RegistrationPhases_Enum currentEnumValue = (EnumHandler.RegistrationPhases_Enum)i;
                switch (currentEnumValue)
                {
                    case EnumHandler.RegistrationPhases_Enum.Smtp:
                        UserDetailsPanel.Visible = visible;
                        PersonalVerificationQuestionsControl.Visible = visible;
                        SmtpControl.Visible = visible;
                        LoginReturnerCustomButton.Visible = visible;
                        if (visible && currentEnumValue == registrationPhase)
                        {
                            HandleCodeResponse(false);
                            SmtpControl.SetDisabled();
                        }
                        break;
                    case EnumHandler.RegistrationPhases_Enum.Registration:
                        SignUpCustomButton.Visible = false;
                        if (visible && currentEnumValue == registrationPhase)
                        {
                            SmtpControl.SetDisabled();
                            ResetFormAppearance();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// The "ResetFormAppearance" method resets the appearance of the form to its initial state.
        /// </summary>
        /// <remarks>
        /// This method enables the UserDetailsPanel and PersonalVerificationQuestionsControl, hides the PersonalVerificationQuestionsControl and SmtpControl,
        /// and sets the registrationPhase to EnumHandler.RegistrationPhases_Enum.Smtp.
        /// </remarks>
        private void ResetFormAppearance()
        {
            UserDetailsPanel.Enabled = true;
            PersonalVerificationQuestionsControl.Enabled = true;
            PersonalVerificationQuestionsControl.Visible = false;
            SmtpControl.Visible = false;
            registrationPhase = EnumHandler.RegistrationPhases_Enum.Smtp;
        }

        #endregion

        #region Form Opening Methods

        /// <summary>
        /// The "OpenProfilePictureSelector" method hides the current form and opens the ProfilePictureSelector form.
        /// </summary>
        /// <remarks>
        /// This method creates a new instance of the ProfilePictureSelector form and shows it using Invoke to ensure it's executed on the UI thread.
        /// </remarks>
        public void OpenProfilePictureSelector()
        {
            this.Hide();
            FormHandler._profilePictureSelector = new ProfilePictureSelector();
            this.Invoke(new Action(() => FormHandler._profilePictureSelector.Show()));
        }

        /// <summary>
        /// The "LoginReturnerCustomButton_Click" method handles the event when the LoginReturnerCustomButton is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method hides the current form and shows the login form.
        /// </remarks>
        private void LoginReturnerCustomButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHandler._login = new Login();
            FormHandler._login.ShowDialog();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "ContinueCustomButtonSetEnabled" method enables or disables the ContinueCustomButton based on the validation status of various input fields.
        /// </summary>
        /// <remarks>
        /// The ContinueCustomButton is enabled if the following conditions are met:
        /// - UsernameCustomTextBox.BorderColor is Color.LimeGreen
        /// - PasswordGeneratorControl.IsSamePassword() is true
        /// - FirstNameCustomTextBox.BorderColor is Color.LimeGreen
        /// - LastNameCustomTextBox.BorderColor is Color.LimeGreen
        /// - EmailAddressCustomTextBox.BorderColor is Color.LimeGreen
        /// - CityCustomTextBox.BorderColor is Color.LimeGreen
        /// - BirthDateCustomDateTimePicker.CustomFormat is not " "
        /// - RadioButtonIsChecked() returns true
        /// Otherwise, the ContinueCustomButton is disabled.
        /// </remarks>
        private void ContinueCustomButtonSetEnabled()
        {
            if ((UsernameCustomTextBox.BorderColor == Color.LimeGreen) && (PasswordGeneratorControl.IsSamePassword()) && (FirstNameCustomTextBox.BorderColor == Color.LimeGreen) && (LastNameCustomTextBox.BorderColor == Color.LimeGreen) && (EmailAddressCustomTextBox.BorderColor == Color.LimeGreen) && (CityCustomTextBox.BorderColor == Color.LimeGreen) && (BirthDateCustomDateTimePicker.CustomFormat != " ") && (RadioButtonIsChecked()))
                ContinueCustomButton.Enabled = true;
            else
                ContinueCustomButton.Enabled = false;
        }

        /// <summary>
        /// The "SignUpCustomButton_Click" method handles the event when the SignUpCustomButton is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Retrieves the user's registration information, including username, password, first name, last name, email, city, gender, date of birth,
        /// and registration date. Generates a list of verification questions and answers. Sends a registration request message to the server.
        /// Hides the SignUpCustomButton after the registration request is sent.
        /// </remarks>
        private void SignUpCustomButton_Click(object sender, EventArgs e)
        {
            string username = UsernameCustomTextBox.TextContent;
            string password = PasswordGeneratorControl.GetNewPassword();
            string firstname = FirstNameCustomTextBox.TextContent;
            string lastname = LastNameCustomTextBox.TextContent;
            string email = EmailAddressCustomTextBox.TextContent;
            string city = CityCustomTextBox.TextContent;
            DateTime dateOfBirth = BirthDateCustomDateTimePicker.Value;
            DateTime RegistrationDate = DateTime.Today;

            List<string[]> VerificationQuestionsAndAnswers = GenerateVerificationQuestionListOfArrays();
            RegistrationInformation registrationInformation = new RegistrationInformation(username, password, firstname, lastname, email, city, Gender, dateOfBirth, RegistrationDate, VerificationQuestionsAndAnswers);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.RegistrationRequest_Registration;
            object messageContent = registrationInformation;
            serverCommunicator.SendMessage(messageType, messageContent);
            SignUpCustomButton.Visible = false;
        }

        /// <summary>
        /// The "Registration_Load" event handler method initializes the GenderOptionsCustomComboBox with the first item selected.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the Registration form is loaded. It ensures that the GenderOptionsCustomComboBox is initialized with a default selection, which is the first item in the list.
        /// </remarks>
        private void Registration_Load(object sender, EventArgs e)
        {
            GenderOptionsCustomComboBox.SelectedIndex = 0;
        }

        #endregion   
    }
}
