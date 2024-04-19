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
    public partial class Registration : Form
    {
        private readonly ServerCommunicator serverCommunicator;
        EnumHandler.RegistrationPhases_Enum registrationPhase;
        bool isApprovedUsername = false, isApprovedPassword = false, isApprovedFirstName = false, isApprovedLastName = false, isApprovedEmailAddress = false, isApprovedCityName = false;
        bool MaleButtonIsChecked = false, FemaleButtonIsChecked = false, AnotherGenderButtonIsChecked = false;
        string Gender = "";
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
        }
        public void SendSmtpCode(object sender, EventArgs e)
        {
            string enteredSmtpCode = SmtpControl.GetCode();
            JsonObject jsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.RegistrationRequest_SmtpRegistrationCode, enteredSmtpCode);
            string enteredSmtpCodeJson = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(enteredSmtpCodeJson);
        }


        public void PasswordGeneratorControl_TextChanged(object sender, EventArgs e)
        {
            ContinueCustomButtonSetEnabled();
        }
        public void HandleSendingEmailProcess(object sender, EventArgs e)
        {
            SmtpControl.Visible = true;
            HandleSendingEmailProcess();
        }
        public void HandleProblematicDetails()
        {
            SmtpControl.SetDisabled();
            ResetFormAppearance();
        }
        private void HandleSendingEmailProcess()
        {
            string username = UsernameCustomTextBox.TextContent;
            string emailAddress = EmailAddressCustomTextBox.TextContent;
            SmtpDetails userUsernameAndEmailAddress = new SmtpDetails(username, emailAddress);
            JsonObject jsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.RegistrationRequest_SmtpRegistrationMessage, userUsernameAndEmailAddress);
            string userUsernameAndEmailAddressJson = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(userUsernameAndEmailAddressJson);
        }
        public void HandleRecievedEmail()
        {
            SmtpControl.HandleCode();
        }
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

                SmtpControl.SetDisabled();
            }
        }

        public void HandleBan(double banDuration)
        {
            BanControl.Visible = true;
            BanControl.HandleBan(banDuration);
            SetVisibility(false);
        }
        public void HandleBanOver()
        {
            BanControl.Visible = false;
            SetVisibility(true);
        }
        public void SetVisibility(bool visible, Image captchaCircularImage = null, Image captchaImage = null, int score = 0, int attempts = 5)
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
        private void UsernameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleUsernameContent();
            ContinueCustomButtonSetEnabled();
        }

        private void UsernameCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleUsernameContent();
        }
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
                if (length < 4)
                {
                    error += "The username must be longer than 4 letters";
                }
                else if (length >= 30)
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
        public void OpenInitialProfileSelectionForm(Boolean IsPhaseOne)
        {
            this.Hide();
            FormHandler._initialProfileSelection = new InitialProfileSelection(IsPhaseOne);
            this.Invoke(new Action(() => FormHandler._initialProfileSelection.ShowDialog()));
        }

        private void FirstNameCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleFirstNameContent();
        }
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
                if (length < 3)
                {
                    error += "The first name must be longer than 3 letters";
                }
                else if (length >= 30)
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

                if (length < 3)
                {
                    error += "The last name must be longer than 3 letters\r\n";
                }
                else if (length >= 30)
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
                if (error=="" && Regex.IsMatch(emailAddress, pattern))
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

                if (length < 4)
                {
                    error += "The city name must be longer than 4 letters";
                }
                else if (length >= 60)
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

        private void LastNameCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleLastNameContent();
        }


        private void GenderOptionsCustomComboBox_Enter(object sender, EventArgs e)
        {
            if (GenderOptionsCustomComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                GenderOptionsCustomComboBox.TextContent = "";
            }
        }

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

        private void GenderOptionsCustomComboBox_OnTextUpdate(object sender, EventArgs e)
        {
            if (GenderOptionsCustomComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                GenderOptionsCustomComboBox.TextContent = "";
            }
        }

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

            MessageBox.Show("good job");
            List<string[]> VerificationQuestionsAndAnswers = GenerateVerificationQuestionListOfArrays();
            RegistrationInformation registrationInformation = new RegistrationInformation(username, password, firstname, lastname, email, city, Gender, dateOfBirth, RegistrationDate, VerificationQuestionsAndAnswers);
            JsonObject jsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.RegistrationRequest_Registration, registrationInformation);
            string registrationInformationJson = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(registrationInformationJson);
            SignUpCustomButton.Visible = false;
        }
        private List<string[]> GenerateVerificationQuestionListOfArrays()
        {
            List<string[]> VerificationQuestionsAndAnswers = new List<string[]>();
            VerificationQuestionDetails verificationQuestionDetails;
            string Question;
            string Answer;
            for (int i = 0; i < 5; i++)
            {
                verificationQuestionDetails = VerificationQuestionHandler.VerificationQuestionDetails[i];
                Question = verificationQuestionDetails.Question;
                Answer = verificationQuestionDetails.Answer;
                VerificationQuestionsAndAnswers.Add(new string[] { Question, Answer });
            }
            return VerificationQuestionsAndAnswers;
        }
        private void ContinueCustomButtonSetEnabled()
        {
            if ((UsernameCustomTextBox.BorderColor == Color.LimeGreen) && (PasswordGeneratorControl.IsSamePassword()) && (FirstNameCustomTextBox.BorderColor == Color.LimeGreen) && (LastNameCustomTextBox.BorderColor == Color.LimeGreen) && (EmailAddressCustomTextBox.BorderColor == Color.LimeGreen) && (CityCustomTextBox.BorderColor == Color.LimeGreen) && (BirthDateCustomDateTimePicker.CustomFormat != " ")  && (RadioButtonIsChecked()))
                ContinueCustomButton.Enabled = true;
            else
                ContinueCustomButton.Enabled = false;
        }

        private void ContinueCustomButton_Click(object sender, EventArgs e)
        {
            PersonalVerificationQuestionsControl.Visible = true;
            UserDetailsPanel.Enabled = false;
        }

        private void LoginReturnerCustomButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHandler._login = new Login();
            FormHandler._login.ShowDialog();
        }

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

        private void CityCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleCityNameContent();
        }

        private void FirstNameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleFirstNameContent();
            ContinueCustomButtonSetEnabled();
        }

        private void LastNameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleLastNameContent();
            ContinueCustomButtonSetEnabled();
        }

        private void EmailAddressCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleEmailAddressContent();
        }

        private void CityCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleCityNameContent();
            ContinueCustomButtonSetEnabled();
        }

        private void BirthDateCustomDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            BirthDateCustomDateTimePicker.CustomFormat = "dd/MM/yyyy";
            ContinueCustomButtonSetEnabled();
        }

        private void BirthDateCustomDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                RestartBirthDateCustomDateTimePickerContent();
            }
        }

        private void RestartBirthDateCustomButton_Click(object sender, EventArgs e)
        {
            RestartBirthDateCustomDateTimePickerContent();
        }
        private void RestartBirthDateCustomDateTimePickerContent()
        {
            BirthDateCustomDateTimePicker.CustomFormat = " ";
            ContinueCustomButtonSetEnabled();
        }

        private void MaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NewSMTPCodeOptionCustomButton_Click(object sender, EventArgs e)
        {

        }

        private void SmtpControl_Load(object sender, EventArgs e)
        {

        }

        private void ChangeEmailOptionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetFormAppearance();
            HideLinkLabels();
        }
        private void ResetFormAppearance()
        {
            UserDetailsPanel.Enabled = true;
            PersonalVerificationQuestionsControl.Enabled = true;
            PersonalVerificationQuestionsControl.Visible = false;
            SmtpControl.Visible = false;
            registrationPhase = EnumHandler.RegistrationPhases_Enum.Smtp;
        }


        private void NewSMTPCodeOptionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HandleSendingEmailProcess();
            HideLinkLabels();
        }
        private void HideLinkLabels()
        {
            ChangeEmailOptionLinkLabel.Visible = false;
            NewSMTPCodeOptionLinkLabel.Visible = false;
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            GenderOptionsCustomComboBox.SelectedIndex = 0; // Automatically select the placeholder item
        }

        private void PersonalVerificationQuestionsControl_Load(object sender, EventArgs e)
        {

        }


        private void EmailAddressCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleEmailAddressContent();
            ContinueCustomButtonSetEnabled();
        }

        private void PasswordGeneratorControl_TextChangedEvent(object sender, EventArgs e)
        {
            ContinueCustomButtonSetEnabled();
        }

        private void LastNameExclamationCustomButton_Click(object sender, EventArgs e)
        {

        }

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

        private Boolean RadioButtonIsChecked()
        {
            return (MaleButtonIsChecked || FemaleButtonIsChecked || (AnotherGenderButtonIsChecked && (GenderOptionsCustomComboBox.TextContent != "<Select A Gender>")));
        }
    }
}
