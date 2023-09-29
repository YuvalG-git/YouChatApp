using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Runtime.InteropServices;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Threading;

namespace YouChatApp
{
    public partial class LoginAndRegistration : Form
    {
        const int RegistrationMessage = 1;
        const int LoginMessage = 2;
        const int PasswordRenewalMessage = 3;

        /// <summary>
        /// Declares a variable of type RulesPage
        /// </summary>
        //RulesPage rulesPage;

        /// <summary>
        /// Represents how the password will be displayed
        /// </summary>
        Boolean passwordIsShown = false;

        //private const string SiteKey = "6LdNtZMnAAAAABqAjpD4ZeVBU3zQTKG0_euLI83-";  

        int NumberOfFailedCaptchaTests = 0;
        Queue<double> CaptchaFailureWaitingTimeQueue;
        double CountDownTime;
        double CaptchaPictureBoxAngle;
        double CaptchaCircularPictureBoxAngle;
        Queue<int> NumbersForCaptchaPictures;
        int CaptchaPicturesScore = 0;
        int CaptchaPictureAttempts = 0;
        int CurrentPictureIndex;
        TimeSpan TimerTickTimeSpan;
        List<int> NumbersList;
        SmtpHandler smtpHandler;

        DateTime CountDownDateTime = new DateTime();
        TimeSpan CountDownTimeSpan;

        string SmtpCode;
        /// <summary>
        /// Both declare an Image variable and assigns it the value of the image resource
        /// </summary>
        Image passwordNotShown = global::YouChatApp.Properties.Resources.showPassword;
        Image passwordShown = global::YouChatApp.Properties.Resources.dontShowPassword;

        Boolean MaleButtonIsChecked = false, FemaleButtonIsChecked = false, AnotherGenderButtonIsChecked = false;
        string Gender = "";
        /// <summary>
        /// The LoginRegistPage constructor initializes the form components, and establishes a connection to a server 
        /// It also sets the loginRegistPage variable of the ClientClass to refer to the current instance of LoginRegistPage, allowing for communication between the two
        /// </summary>
        public LoginAndRegistration()
        {
            InitializeComponent();
            ServerCommunication.Connect("10.100.102.3");
            ServerCommunication.loginAndRegistration = this;
            smtpHandler = new SmtpHandler();
        }

        /// <summary>
        /// The method "OpenColorChoiceForm" sets the "name" variable in the ClientClass to the value entered in the "usernameloginTextbox" field
        /// It then hides the current form and creates a new instance of the ColorChoice form
        /// Then it invokes a method to show the ColorChoice Dialog
        /// </summary>
        public void OpenApp()
        {
            ServerCommunication.name = usernameTextbox.Text;
            this.Hide();
            ServerCommunication.youChat = new YouChat();
            this.Invoke(new Action(() => ServerCommunication.youChat.ShowDialog()));
        }
        public void OpenInitialProfileSelection(Boolean IsPhaseOne)
        {
            ServerCommunication.name = usernameTextbox.Text;
            this.Hide();
            ServerCommunication.InitialProfileSelection = new InitialProfileSelection(IsPhaseOne);
            this.Invoke(new Action(() => ServerCommunication.InitialProfileSelection.ShowDialog()));
        }

        private void SetCaptchaCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int Length = random.Next(6, 8);
            string CaptchaCode = "";
            do
            {
                CaptchaCode += chars[random.Next(chars.Length)];
            }
            while (CaptchaCode.Length < Length);
            CaptchaLabel.Text = CaptchaCode;
            CaptchaLabel.Image = CaptchaImageList.Images[random.Next(CaptchaImageList.Images.Count)];

        }

        private string CheckPassword(string Password)
        {
            string PasswordAcceptanceText = "";
            List<string> CharsNotInPassword = new List<string>();
            if (PasswordHandler.CharNumber(Password) < 8)
            {
                CharsNotInPassword.Add("eight characters");
            }
            if (!PasswordHandler.ContainLowercase(Password))
            {
                CharsNotInPassword.Add("one lowercase");
            }
            if (!PasswordHandler.ContainUppercase(Password))
            {
                CharsNotInPassword.Add("one uppercase");

            }
            if (!PasswordHandler.ContainDigit(Password))
            {
                CharsNotInPassword.Add("one digit");

            }
            if (!PasswordHandler.ContainSpecial(Password))
            {
                CharsNotInPassword.Add("one special symbol");
            }
            if (CharsNotInPassword.Count == 0)
            {
                PasswordAcceptanceText = "That's a strong password";
                //change color to green
            }
            else 
            {
                PasswordAcceptanceText = "Your password must contain at least ";
                if (CharsNotInPassword.Count == 1)
                {
                    PasswordAcceptanceText += CharsNotInPassword[0];
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
                            PasswordAcceptanceText += " and ";

                        }
                        else if ((CharsNotInPassword.Count - 1 > NumberOfInsertedMissingCharRequirement))
                        {
                            PasswordAcceptanceText += ", ";

                        }
                        NumberOfInsertedMissingCharRequirement++;
                    }
                }

            }
            return PasswordAcceptanceText;

        }

            /// <summary>
            /// The "registButton_Click" event handler collects user input from textboxes and performs validation checks, displaying error messages if necessary
            /// However, If all inputs are valid, the code disables the registButton, combines the user details into a string, and sends a register request message to the server using the ClientClass
            /// </summary>
            /// <param name="sender">The object that raised the event</param>
            /// <param name="e">The event arguments</param>
            private void registButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passwordTextbox.Text;
            string firstname = firstnameTextbox.Text;
            string lastname = lastnameTextbox.Text;
            string email = emailTextbox.Text;
            string city = cityTextbox.Text;
            string dateOfBirth = BirthDateDateTimePicker.Value.ToShortDateString();
            if (!CodeLabel.Visible)
            {
                if (username.Contains("#"))
                    MessageBox.Show("choose an username which doesn't conatain '#'");
                if (password.Contains("#"))
                    MessageBox.Show("choose a password which doesn't conatain '#'");
                if (firstname.Contains("#"))
                    MessageBox.Show("choose a firstname which doesn't conatain '#'");
                if (lastname.Contains("#"))
                    MessageBox.Show("choose a lastname which doesn't conatain '#'");
                if (email.Contains("#"))
                    MessageBox.Show("choose an email which doesn't conatain '#'");
                if (city.Contains("#"))
                    MessageBox.Show("choose a city which doesn't conatain '#'");
                if (email.Contains("@"))
                {
                    int Index = email.IndexOf("@");
                    if (Index == 0)
                        MessageBox.Show("That's not an email address");
                    else
                    {
                        int count = GetSpecificCharNumberFromString(email, '@');
                        if (count != 1)
                        {
                            MessageBox.Show("That's not an email address");
                        }
                        else
                        {
                            string[] GmailInfo = email.Split('@');
                            string GmailEnd = GmailInfo[1];
                            if (GmailEnd != "gmail.com")
                            {
                                MessageBox.Show("That's not an email address");
                            }
                            else
                            {
                                CodeLabel.Visible = true;
                                CodeTextBox.Visible = true;
                                usernameTextbox.Enabled = false;
                                passwordTextbox.Enabled = false;
                                firstnameTextbox.Enabled = false;
                                lastnameTextbox.Enabled = false;
                                emailTextbox.Enabled = false;
                                cityTextbox.Enabled = false;
                                BirthDateDateTimePicker.Enabled = false;
                                MaleRadioButton.Enabled = false;
                                FemaleRadioButton.Enabled = false;
                                AnotherGenderRadioButton.Enabled = false;
                                
                                //string RegistrationDate = DateTime.Today.ToString("yyyy-MM-dd"); ;
                                //string userDetails = username + "#" + password + "#" + firstname + "#" + lastname + "#" + email + "#" + city + "#" + dateOfBirth + "#" + Gender + "#" + RegistrationDate; //to add in the server side the handle of theRegistrationDate 
                                //ServerCommunication.SendMessage(ServerCommunication.registerRequest + "$" + userDetails + "$" + userDetails.Length);
                                registButton.Text = "Verify";
                                registButton.Enabled = false;
                                Thread.Sleep(500);
                                smtpHandler.SendCodeToUserEmail(username, email,RegistrationMessage);
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("That's not an email address");
            }
            else
            {
                CodeTextBox.Enabled = false;

                if (CodeTextBox.Text == smtpHandler.GetSmtpCode())
                {
                    MessageBox.Show("good job");
                    string RegistrationDate = DateTime.Today.ToString("yyyy-MM-dd"); ;
                    string userDetails = username + "#" + password + "#" + firstname + "#" + lastname + "#" + email + "#" + city + "#" + dateOfBirth + "#" + Gender + "#" + RegistrationDate; //to add in the server side the handle of theRegistrat
                    ServerCommunication.SendMessage(ServerCommunication.registerRequest + "$" + userDetails + "$" + userDetails.Length);
                }
                else
                {
                    CodeTextBox.Text = "";
                    registButton.Visible = false;
                    ChangeEmailOptionButton.Visible = true;
                    NewSMTPCodeOptionButton.Visible = true;
                }
            }

        }

        private void CheckLegalEmailAddress()
        {
            //to check if the email address is allowed here instead in registButton_Click
        }

        private void NewSMTPCodeOptionButton_Click(object sender, EventArgs e)
        {
            SetFormAfterWrongSMTPCode();
            string Username = usernameTextbox.Text;
            string DestinationEmail = emailTextbox.Text;
            smtpHandler.SendCodeToUserEmail(Username, DestinationEmail, RegistrationMessage);
            //SendCodeToUserEmail();
        }

        private void ChangeEmailOptionButton_Click(object sender, EventArgs e)
        {
            SetFormAfterWrongSMTPCode();
            usernameTextbox.Enabled = true;
            passwordTextbox.Enabled = true;
            firstnameTextbox.Enabled = true;
            lastnameTextbox.Enabled = true;
            emailTextbox.Enabled = true;
            cityTextbox.Enabled = true;
            BirthDateDateTimePicker.Enabled = true;
            MaleRadioButton.Enabled = true;
            FemaleRadioButton.Enabled = true;
            AnotherGenderRadioButton.Enabled = true;
            CodeLabel.Visible = false;
            CodeTextBox.Visible = false;
            registButton.Text = "Sign Up";
            registButton.Enabled = true;
        }
        
        private void SetFormAfterWrongSMTPCode()
        {
            CodeTextBox.Enabled = true;
            ChangeEmailOptionButton.Visible = false;
            NewSMTPCodeOptionButton.Visible = false;
            registButton.Visible = true;
        }

        private int GetSpecificCharNumberFromString(string MyString, char MyChar)
        {
            int count = 0;
            foreach (char ch in MyString)
            {
                if (ch.Equals(MyChar))
                {
                    count++;
                }
            }
            return count;
        }

        public void HandleMatchingUsernameAndPassword(string EmailAddress)
        {
            SendLoginEmailThroughSmtpProtocol(EmailAddress);
            //todo - make everything visible
            usernameloginTextbox.Enabled = false;
            passwordloginTextbox.Enabled = false;
            LoginCodeLabel.Visible = true;
            LoginSmtpCodeTextBox.Visible = true;
            LoginNewSmtpCodeSenderButton.Visible = true;
            LoginSmtpCodeVerifyButton.Visible = true;
        }
        private void SendLoginEmailThroughSmtpProtocol(string EmailAddress)
        {
            string username = usernameloginTextbox.Text;
            smtpHandler.SendCodeToUserEmail(username, EmailAddress, LoginMessage);
        }
        /// <summary>
        /// This function is responsible for the player's login to the game:
        /// the function checks for the presence of the '#' character in the username and password entered by the user.
        /// If it finds '#', it displays an error message.
        /// Otherwise, it disables the login button and sends a login request to the server.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameloginTextbox.Text;
            string password = passwordloginTextbox.Text;
            if (username.Contains("#"))
                MessageBox.Show("choose an username which doesn't contain '#'");
            else if (password.Contains("#"))
                MessageBox.Show("choose a password which doesn't contain '#'");
            else
            {
                loginButton.Enabled = false;
                string userLoginDetails = username + "#" + password;
                ServerCommunication.SendMessage(ServerCommunication.loginRequest + "$" + userLoginDetails);

            }

        }

        private void CaptchaCountDownTimer_Tick(object sender, EventArgs e)
        {
            CountDownTimeSpan -= TimerTickTimeSpan;
            if (CountDownTimeSpan.TotalMilliseconds <= 0)
            {
                CaptchaCountDownTimer.Stop();
                CountDownTimeLabel.Text = "Countdown Complete!";
                LoginGroupBox.Enabled = true;
                CaptchaLoginTextBox.Text = "";
                CaptchaLoginTextBox.Enabled = true;
            }
            else
            {
                CountDownTimeLabel.Text = $"{CountDownTimeSpan:mm\\:ss\\.fff}";
            }
            //if (counter == 0)
            //    CaptchaCountDownTimer.Stop();
            //CountDownTimeLabel.Text = CountDownTimeLabel.Text.Substring(0, 10) + counter.ToString();
        }

        /// <summary>
        /// The method "setLoginButtonEnabled" sets the "Enabled" property of the loginButton to true
        /// </summary>
        public void setLoginButtonEnabled()
        {
            loginButton.Enabled = true;
        }

        /// <summary>
        /// The method "setRegistButtonEnabled" sets the "Enabled" property of the registButton to true
        /// </summary>
        public void setRegistButtonEnabled()
        {
            registButton.Enabled = true;
        }

        /// <summary>
        /// The "RegisterScreenButton_Click" event handler the visibility of several elements:
        /// It sets the "Visible" property of ReturnToStarterScreen to true and sets the "Visible" property of RegisterScreenButton to false
        /// It also sets the "Visible" property of groupBox1 to true and sets the "Visible" property of groupBox2 to false
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void RegisterScreenButton_Click(object sender, EventArgs e)
        {
            RegisterReturnToStarterScreenButton.Visible = true;
            RegisterScreenButton.Visible = false;
            RegistrationGroupBox.Visible = true;
            LoginGroupBox.Visible = false;
        }

        /// <summary>
        /// The "ReturnToStarterScreen_Click" event handler the visibility of several elements:
        /// It sets the "Visible" property of ReturnToStarterScreen to false and sets the "Visible" property of RegisterScreenButton to true
        /// It also sets the "Visible" property of groupBox1 to false and sets the "Visible" property of groupBox2 to true        
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void ReturnToStarterScreen_Click(object sender, EventArgs e)
        {
            RegistrationGroupBox.Visible = false;
            LoginGroupBox.Visible = true;
            RegisterReturnToStarterScreenButton.Visible = false;
            RegisterScreenButton.Visible = true;
        }


        /// <summary>
        /// The "loginDetails" event handler checks if both the "usernameloginTextbox" and "passwordloginTextbox" fields are not empty
        /// If both fields have values, it enables the "loginButton"
        /// Otherwise, it disables the "loginButton"
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void loginDetails(object sender, EventArgs e)
        {
            if ((usernameloginTextbox.Text != "") && (passwordloginTextbox.Text != "") /*&& (CaptchaLoginTextBox.Text != "")*/)
                loginButton.Enabled = true;
            else
                loginButton.Enabled = false;
        }

        private void SendCodeDetails(object sender, EventArgs e)
        {
            if ((UsernameResetPasswordTextBox.Text != "") && (EmailResetPasswordTextBox.Text != ""))
                ResetPasswordCodeSenderButton.Enabled = true;
            else
                ResetPasswordCodeSenderButton.Enabled = false;
        }

        /// <summary>
        /// The "registerDetails" event handler checks if all the textboxes(usernameTextbox, passwordTextbox, firstnameTextbox, lastnameTextbox, emailTextbox, and cityTextbox) have values
        /// If all textboxes have values, it enables the "registButton"
        /// Otherwise, it disables the "registButton"
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void registerDetails(object sender, EventArgs e)
        {
            RegistButtonSetEnabled();
        }
        private void RegistButtonSetEnabled()
        {
            if ((usernameTextbox.Text != "") && (passwordTextbox.Text != "") && (firstnameTextbox.Text != "") && (lastnameTextbox.Text != "") && (emailTextbox.Text != "") && (cityTextbox.Text != "") && (BirthDateDateTimePicker.CustomFormat != " ") && (RadioButtonIsChecked()))
                registButton.Enabled = true;
            else
                registButton.Enabled = false;
        }

        /// <summary>
        /// The "LoginRegistPage_FormClosing" event handler sends a disconnect request message to the server
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void LoginRegistPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerCommunication.SendMessage(ServerCommunication.disconnectRequest + "$" + "color erasure");
            System.Windows.Forms.Application.ExitThread();
        }


        /// <summary>
        /// The "ViewPasswordButton_Click" event handler toggles the visibility of the password in the passwordloginTextbox:
        /// First, it switches the value of the "passwordIsShown" flag between true and false
        /// Then, If "passwordIsShown" is true, it sets the PasswordChar property of passwordloginTextbox to null character and updates the background image of ViewPasswordButton
        /// Otherwise, if "passwordIsShown" is false, it sets the PasswordChar property to '*' and updates the background image accordingly
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void ViewPasswordButton_Click(object sender, EventArgs e)
        {
            if (passwordIsShown == false)
                passwordIsShown = true;
            else
                passwordIsShown = false;
            if (passwordIsShown == true)
            {
                this.passwordloginTextbox.PasswordChar = '\0';
                ViewPasswordButton.BackgroundImage = passwordShown;
            }
            else
            {
                this.passwordloginTextbox.PasswordChar = '*';
                ViewPasswordButton.BackgroundImage = passwordNotShown;
            }
        }

        private void LoginAndRegistration_Load(object sender, EventArgs e)
        {
            //messagecontrolsettings();
            CreateCaptchaFailureWaitingTimeQueue();
            SetCaptchaCode();
            TimeTimer.Start();
            BirthDateDateTimePicker.MinDate = new DateTime(DateTime.Today.Year - 100, DateTime.Today.Month, DateTime.Today.Day);
            BirthDateDateTimePicker.MaxDate = DateTime.Now;
            SetPictureOrderForCaptcha();
            GenderOptionsComboBox.SelectedIndex = 0; // Automatically select the placeholder item
            //RECAPTCHAWebBrowser.Navigate($"https://www.google.com/recaptcha/api/fallback?k={SiteKey}");

        }

        //private void messagecontrolsettings()
        //{
        //    DateTime dt = DateTime.Now;
        //    messageControl1.Username.Text = "Yuval";
        //    messageControl1.Message.Text = "hi";

        //    messageControl1.Time.Text = dt.ToString();
        //    messageControl1.ProfilePicture.BackgroundImage = passwordNotShown;

        //}
        private void CreateCaptchaFailureWaitingTimeQueue() //todo to use this code again in the second captcha test
        {
            TimerTickTimeSpan = TimeSpan.FromMilliseconds(CaptchaCountDownTimer.Interval);
            CaptchaFailureWaitingTimeQueue = new Queue<double>();
            double[] WaitingTimeArray = { 0.25, 0.5, 1, 2, 3, 5, 10, 15, 20, 30 };
            foreach (double time in WaitingTimeArray)
            {
                CaptchaFailureWaitingTimeQueue.Enqueue(time);
            }
        }

        private void TimeTimer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                BirthDateDateTimePicker.CustomFormat = " ";
                RegistButtonSetEnabled();
            }
            // להוסיף כפתור של ריפרש וגם בלחיצה עליו יקרה אותו דבר
        }

        private void FemaleRadioButton_Click(object sender, EventArgs e)
        {
            MaleButtonIsChecked = false;
            AnotherGenderButtonIsChecked = false;
            GenderOptionsComboBox.Visible = false;
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
            RegistButtonSetEnabled();
        }

        private void AnotherGenderRadioButton_Click(object sender, EventArgs e)
        {
            MaleButtonIsChecked = false;
            FemaleButtonIsChecked = false;
            if (AnotherGenderButtonIsChecked == false)
            {
                GenderOptionsComboBox.Visible = true;
                AnotherGenderButtonIsChecked = true;
            }
            else
            {
                GenderOptionsComboBox.Visible = false;
                AnotherGenderButtonIsChecked = false;
                Gender = "";
            }
            if (AnotherGenderButtonIsChecked == true)
            {
                AnotherGenderRadioButton.Checked = true;

            }
            else
            {
                AnotherGenderRadioButton.Checked = false;
            }//יכול להיות חכם לעשות מערך של שלושת הכפתורים, ואז בקלט לקבל גם מספר שמייצג מיקום
            RegistButtonSetEnabled();
        }

        private void MaleRadioButton_Click(object sender, EventArgs e)
        {
            FemaleButtonIsChecked = false;
            AnotherGenderButtonIsChecked = false;
            GenderOptionsComboBox.Visible = false;
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
            RegistButtonSetEnabled();
        }

        private Boolean RadioButtonIsChecked()
        {
            return (MaleButtonIsChecked || FemaleButtonIsChecked || (AnotherGenderButtonIsChecked && (GenderOptionsComboBox.Text != "<Select A Gender>")));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            BirthDateDateTimePicker.CustomFormat = "dd/MM/yyyy";
            RegistButtonSetEnabled();
        }

        private void RestartCaptchaButton_Click(object sender, EventArgs e)
        {
            SetCaptchaCode();
        }

        private void ResetPasswordCodeSenderButton_Click(object sender, EventArgs e)
        {
            string Username = UsernameResetPasswordTextBox.Text;
            string Email = EmailResetPasswordTextBox.Text;
            string UserResetPasswordDetails = Username + "#" + Email;

            ServerCommunication.SendMessage(ServerCommunication.ResetPasswordRequest + "$" + UserResetPasswordDetails);
        }

        public void HandleMatchingUsernameAndEmailAddress()
        {
            SendResetPasswordEmailThroughSmtpProtocol();
            UsernameResetPasswordTextBox.Enabled = false;
            EmailResetPasswordTextBox.Enabled = false;
            ResetPasswordCodeLabel.Visible = true;
            ResetPasswordCodeTextBox.Visible = true;
            ResetPasswordVerificationButton.Visible = true;
            NewSmtpCodeSenderButton.Visible = true;
        }
        private void SendResetPasswordEmailThroughSmtpProtocol()
        {
            string username = UsernameResetPasswordTextBox.Text;
            string emailAddress = EmailResetPasswordTextBox.Text;
            smtpHandler.SendCodeToUserEmail(username, emailAddress, PasswordRenewalMessage);
        }

        private void ResetPasswordReturnToStarterScreenButton_Click(object sender, EventArgs e)
        {
            ReturnToLoginPanelFromResetPasswordPanel();
        }
        public void ReturToLoginPanelAfterSuccessfulPasswordRenewal()
        {
            ReturnToLoginPanelFromResetPasswordPanel();
            MessageBox.Show("Your new password has been saved");

        }

        private void ReturnToLoginPanelFromResetPasswordPanel()
        {
            RegistrationGroupBox.Visible = false;
            LoginGroupBox.Visible = true;
            ResetPasswordGroupBox.Visible = false;
            UsernameResetPasswordTextBox.Text = "";
            EmailResetPasswordTextBox.Text = "";
            ResetPasswordCodeTextBox.Text = "";
            NewPasswordTextBox.Text = "";
            UsernameResetPasswordTextBox.Enabled = true;
            EmailResetPasswordTextBox.Enabled = true;
            ResetPasswordCodeLabel.Visible = false;
            ResetPasswordCodeTextBox.Visible = false;
            ResetPasswordVerificationButton.Visible = false;
            NewSmtpCodeSenderButton.Visible = false;
            NewPasswordLabel.Visible = false;
            NewPasswordTextBox.Visible = false;
            ResetNewPasswordButton.Visible = false;
            NewPasswordSaverButton.Visible = false;
        }

        public void RestartResetPasswordDetails()
        {
            ResetPasswordCodeSenderButton.Enabled = false;
            //to make the border red when i'll switch it to the custom control...
            MessageBox.Show("Your details were incorrect\nPlease Check for mistakes", "Incorrect Details");
        }
        public void SelectNewPasswordForPasswordRenewal()
        {
            NewPasswordSaverButton.Enabled = false;
            MessageBox.Show("You have already chosen this password in the past\nChoose a new password that you haven't chosen before");


        }

        private void GenderOptionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenderOptionsComboBox.Text != "<Select A Gender>")
            {
                Gender = GenderOptionsComboBox.Text;
                RegistButtonSetEnabled();
            }
            if (GenderOptionsComboBox.Text == "Other...")
            {
                GenderOptionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            }
            else
            {
                GenderOptionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
        }

        private void GenderOptionsComboBox_Enter(object sender, EventArgs e)
        {
            if (GenderOptionsComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                GenderOptionsComboBox.Text = ""; //in the future i could make a server connection and add to a database- that way this will be improving...
            }
        }

        private void GenderOptionsComboBox_TextUpdate(object sender, EventArgs e)
        {
            if (GenderOptionsComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                GenderOptionsComboBox.Text = "";
            }
        }

        private void ResetPasswordFromLoginButton_Click(object sender, EventArgs e)
        {
            ResetPasswordGroupBox.Visible = true;
            LoginGroupBox.Visible = false;
        }




        //public void SendCodeToUserEmail()
        //{
        //    string server = "smtp.gmail.com";
        //    int port = 465;

        //    string password = "esnwzdlgfynpkmbk";
        //    string SourceEmail = "youchatcyberapplication@gmail.com";
        //    string DestinationEmail = emailTextbox.Text;
        //    string subject = "Verification Dode";
        //    string body = "here is your code\n" + getCode();

        //    //MailMessage mail = new MailMessage(SourceEmail, DestinationEmail);
        //    //mail.Subject = subject;
        //    //mail.Body = body;
        //    SmtpClient smtpClient = new SmtpClient(server, port);
        //    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtpClient.UseDefaultCredentials = false;
        //    smtpClient.EnableSsl = true;
        //    smtpClient.Credentials = new NetworkCredential(SourceEmail, password);
        //    smtpClient.Send(SourceEmail, DestinationEmail, subject, body);
        //}

        public void SendCodeToUserEmail()
        {
            string server = "smtp.gmail.com";
            int port = 587;  

            SmtpCode = getCode();
            string appPassword = "fmgwqaquwfmckchv";
            string sourceEmail = "youchatcyberapplication@gmail.com";
            string destinationEmail = emailTextbox.Text;
            string subject = "YouChat Verification Code";
            string body = "Welcome to YouChat!\nHere is your code:\n" + SmtpCode;

            using (SmtpClient smtpClient = new SmtpClient(server, port))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(sourceEmail, appPassword);

                using (MailMessage mail = new MailMessage(sourceEmail, destinationEmail))
                {
                    mail.Subject = subject;
                    mail.Body = body;

                    try
                    {
                        smtpClient.Send(mail);
                        Console.WriteLine("Email sent successfully.");
                    }
                    catch (SmtpException smtpEx)
                    {
                        Console.WriteLine("SMTP Exception: " + smtpEx.Message);

                        if (smtpEx.InnerException != null)
                        {
                            Console.WriteLine("Inner Exception: " + smtpEx.InnerException.Message);
                        }

                        // Handle the exception or log the error
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("General Exception: " + ex.Message);
                        // Handle the exception or log the error
                    }
                }
            }
        }

        public static string getCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6).Select(s =>
            s[random.Next(s.Length)]).ToArray());
        }


        private Point rotationPoint;


        private void LoadImage()
        {
            CurrentPictureIndex = NumbersForCaptchaPictures.Dequeue();
            //NumbersList[CurrentPictureIndex] = CurrentPictureIndex;
            CaptchaCircularPictureBox.BackgroundImage = CaptchaPicturesImageList.Images[CurrentPictureIndex];
            CaptchaPictureBox.BackgroundImage = CaptchaPicturesImageList.Images[CurrentPictureIndex];
            RotateBothPictureBoxsRandomlly();
        }

        private void CaptchaCircularPictureBox_Click(object sender, EventArgs e)
        {
            //CaptchaPictureBox.FlatAppearance.BorderColor = Color.Transparent;
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null)
            {
                Point clickPoint = mouseEventArgs.Location;
                RotateImageToPoint(clickPoint);
            }
        }


        private void CaptchaImageCheckerButton_Click(object sender, EventArgs e)
        {

            if (CaptchaPictureBoxAngle < 0)
            {
                CaptchaPictureBoxAngle += 360;
            }
            if (CaptchaCircularPictureBoxAngle < 0)
            {
                CaptchaCircularPictureBoxAngle += 360;
            }
            if (Math.Abs(CaptchaPictureBoxAngle - CaptchaCircularPictureBoxAngle) <= 5)
            {
                CaptchaPicturesScore++;
               // CaptchaPictureBox.FlatAppearance.BorderColor = Color.Green;
            }
            else
            {
                //CaptchaPictureBox.FlatAppearance.BorderColor = Color.Red;

            }
            //todo to add something after 5 failed before all 15 are done
            CaptchaPicturesScoreLabel.Text = CaptchaPicturesScore.ToString() + "/" + CaptchaPictureAttempts.ToString();
            //if (NumbersForCaptchaPictures.Count == 0)
            //{
            //    if (CaptchaPicturesScore <= 10)
            //    {
            //        //try again in 2 minutes
            //    }
            //    else
            //    {
            //        string username = usernameloginTextbox.Text;
            //        string password = passwordloginTextbox.Text;
            //        string userLoginDetails = username + "#" + password;
            //        ServerCommunication.SendMessage(ServerCommunication.loginRequest + "$" + userLoginDetails);
            //    }
            //}
            //else
            //{
            //    CurrentPictureIndex = NumbersForCaptchaPictures.Dequeue();
            //    CaptchaPictureBox.BackgroundImage = CaptchaPicturesImageList.Images[CurrentPictureIndex];
            //    CaptchaCircularPictureBox.BackgroundImage = CaptchaPicturesImageList.Images[CurrentPictureIndex];
            //    RotateBothPictureBoxsRandomlly();
            //}
            if (CaptchaPictureAttempts == 5)
            {
                if (CaptchaPicturesScore < 3)
                {
                    CaptchaPictureAttempts = 0;
                    CaptchaPicturesScore = 0;
                    //try again in 2 minutes 
                    //after two minutes:
                    if (NumbersForCaptchaPictures.Count == 0)
                    {
                        SetNumbersList();
                        SetNumberForCaptchaPicturesQueue();
                        LoadImage();

                    }

                }
                else
                {
                    string username = usernameloginTextbox.Text;
                    string password = passwordloginTextbox.Text;
                    string userLoginDetails = username + "#" + password;
                    //ServerCommunication.SendMessage(ServerCommunication.loginRequest + "$" + userLoginDetails);
                    ServerCommunication.SendMessage(ServerCommunication.InitialProfileSettingsCheckRequest + "$" + userLoginDetails);

                }

            }
            else
            {
                CurrentPictureIndex = NumbersForCaptchaPictures.Dequeue();
                CaptchaPictureBox.BackgroundImage = CaptchaPicturesImageList.Images[CurrentPictureIndex];
                CaptchaCircularPictureBox.BackgroundImage = CaptchaPicturesImageList.Images[CurrentPictureIndex];
                RotateBothPictureBoxsRandomlly();
            }
        }
        private void SetPictureOrderForCaptcha()
        {
            NumbersForCaptchaPictures = new Queue<int>();
            NumbersList = new List<int>();
            SetNumbersList();
            SetNumberForCaptchaPicturesQueue();
            LoadImage();
        }

        private void SetNumbersList()
        {
            for (int i = 0; i < CaptchaPicturesImageList.Images.Count; i++)
                NumbersList.Add(i);
        }
        private void SetNumberForCaptchaPicturesQueue()
        {
            Random random = new Random();
            int Index;
            while (NumbersList.Count > 0)
            {
                Index = random.Next(0, NumbersList.Count);
                NumbersForCaptchaPictures.Enqueue(NumbersList[Index]);
                NumbersList.RemoveAt(Index);
            }
        }

        private void passwordTextbox_Leave(object sender, EventArgs e)
        {
            string CurrentPassword = passwordTextbox.Text;
            PasswordHandler.CheckPassword(CurrentPassword);
            PasswordRequirementsLabel.Text = PasswordHandler.PasswordStrength;
            PasswordRequirementsLabel.BackColor = PasswordHandler.PasswordInformationColor;

            //PasswordRequirementsLabel.Text = CheckPassword(CurrentPassword);
            //string CheckedPasswordResult = PasswordRequirementsLabel.Text;

            //if (CheckedPasswordResult == "That's a strong password")
            //{
            //    PasswordRequirementsLabel.ForeColor = Color.Green;
            //}
            //else if(!CheckedPasswordResult.Contains("and"))
            //{
            //    PasswordRequirementsLabel.ForeColor = Color.Yellow;
            //}
            //else 
            //{
            //    PasswordRequirementsLabel.ForeColor = Color.Red;
            //}
            if (PasswordHandler.PasswordStrength != "That's a strong password")
            {
                PasswordExclamationButton.Visible = true;
            }
            else
            {
                PasswordExclamationButton.Visible = false;

            }
        }

        private void RotateBothPictureBoxsRandomlly()
        {
            CaptchaPictureAttempts++;
            Random random = new Random();
            CaptchaPictureBoxAngle = random.Next(1,4)*90;
            do
            {
                CaptchaCircularPictureBoxAngle = random.Next(360);

            }
            while (Math.Abs(CaptchaPictureBoxAngle - CaptchaCircularPictureBoxAngle) <= 25);


            Bitmap CaptchaPictureBoxRotatedImage = new Bitmap(CaptchaPictureBox.BackgroundImage.Width, CaptchaPictureBox.BackgroundImage.Height);
            Bitmap CaptchaCircularPictureBoxAngleRotatedImage = new Bitmap(CaptchaCircularPictureBox.BackgroundImage.Width, CaptchaCircularPictureBox.BackgroundImage.Height);

            using (Graphics graphics = Graphics.FromImage(CaptchaPictureBoxRotatedImage))
            {
                graphics.TranslateTransform(CaptchaPictureBoxRotatedImage.Width / 2, CaptchaPictureBoxRotatedImage.Height / 2);
                graphics.RotateTransform((float)CaptchaPictureBoxAngle);
                graphics.TranslateTransform(-CaptchaPictureBoxRotatedImage.Width / 2, -CaptchaPictureBoxRotatedImage.Height / 2);
                graphics.DrawImage(CaptchaPicturesImageList.Images[CurrentPictureIndex], new PointF(0, 0));
            }

            using (Graphics graphics = Graphics.FromImage(CaptchaCircularPictureBoxAngleRotatedImage))
            {
                graphics.TranslateTransform(CaptchaCircularPictureBoxAngleRotatedImage.Width / 2, CaptchaCircularPictureBoxAngleRotatedImage.Height / 2);
                graphics.RotateTransform((float)CaptchaCircularPictureBoxAngle);
                graphics.TranslateTransform(-CaptchaCircularPictureBoxAngleRotatedImage.Width / 2, -CaptchaCircularPictureBoxAngleRotatedImage.Height / 2);
                graphics.DrawImage(CaptchaPicturesImageList.Images[CurrentPictureIndex], new PointF(0, 0));
            }
            CaptchaPictureBox.BackgroundImage = CaptchaPictureBoxRotatedImage;
            CaptchaCircularPictureBox.BackgroundImage = CaptchaCircularPictureBoxAngleRotatedImage;
        }
        private void RotateImageToPoint(Point clickPoint)
        {
            CaptchaCircularPictureBoxAngle = CalculateRotationAngle(clickPoint);

            Bitmap rotatedImage = new Bitmap(CaptchaCircularPictureBox.BackgroundImage.Width, CaptchaCircularPictureBox.BackgroundImage.Height);
            using (Graphics graphics = Graphics.FromImage(rotatedImage))
            {
                graphics.TranslateTransform(rotatedImage.Width / 2, rotatedImage.Height / 2);
                graphics.RotateTransform((float)CaptchaCircularPictureBoxAngle);
                graphics.TranslateTransform(-rotatedImage.Width / 2, -rotatedImage.Height / 2);
                graphics.DrawImage(CaptchaPicturesImageList.Images[CurrentPictureIndex], new PointF(0, 0));
            }

            CaptchaCircularPictureBox.BackgroundImage = rotatedImage;
        }
        private void RotateImage(Control control) //try to use it - if doesnt work 2 parmeters: picturebox and circularpicturebox - to check which one and act accordinglly
        {
            Bitmap rotatedImage = new Bitmap(control.BackgroundImage.Width, control.BackgroundImage.Height);
            using (Graphics graphics = Graphics.FromImage(rotatedImage))
            {
                graphics.TranslateTransform(rotatedImage.Width / 2, rotatedImage.Height / 2);
                graphics.RotateTransform((float)CaptchaCircularPictureBoxAngle);
                graphics.TranslateTransform(-rotatedImage.Width / 2, -rotatedImage.Height / 2);
                graphics.DrawImage(CaptchaPicturesImageList.Images[CurrentPictureIndex], new PointF(0, 0));
            }

            control.BackgroundImage = rotatedImage;
        }

        private void ResetNewPasswordButton_Click(object sender, EventArgs e)
        {
            NewPasswordTextBox.Text = "";
        }

        private void NewSmtpCodeSenderButton_Click(object sender, EventArgs e)
        {
            SendResetPasswordEmailThroughSmtpProtocol();
        }

        private void ResetPasswordVerificationButton_Click(object sender, EventArgs e)
        {
            string EnteredSmtpCode = ResetPasswordCodeTextBox.Text;
            if (EnteredSmtpCode == smtpHandler.GetSmtpCode())
            {
                NewPasswordLabel.Visible = true;
                NewPasswordTextBox.Visible = true;
                ResetNewPasswordButton.Visible = true;
                NewPasswordSaverButton.Visible = true;
            }
        }

        private void NewPasswordSaverButton_Click(object sender, EventArgs e)
        {
            //if the password is good...
            string username = UsernameResetPasswordTextBox.Text;
            string newPassword = NewPasswordTextBox.Text;
            string userDetails = username + "#" + newPassword;
            ServerCommunication.SendMessage(ServerCommunication.PasswordRenewalMessageRequest + "$" + userDetails);

        }

        private void LoginSmtpCodeVerifyButton_Click(object sender, EventArgs e)
        {
            string EnteredSmtpCode = LoginSmtpCodeTextBox.Text;
            if (EnteredSmtpCode == smtpHandler.GetSmtpCode())
            {
                CaptchaWordTestPanel.Visible = true;
            }
        }

        private void LoginSmtpCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = LoginSmtpCodeTextBox.Text;
            if (text != "")
            {
                LoginSmtpCodeVerifyButton.Enabled = true;
            }
            else
            {
                LoginSmtpCodeVerifyButton.Enabled = false;

            }
        }

        private void ResetPasswordCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = ResetPasswordCodeTextBox.Text;
            if (text != "")
            {
                ResetPasswordVerificationButton.Enabled = true;
            }
            else
            {
                ResetPasswordVerificationButton.Enabled = false;

            }
        }

        private void NewPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = NewPasswordTextBox.Text;
            if (text != "")
            {
                NewPasswordSaverButton.Enabled = true;
            }
            else
            {
                NewPasswordSaverButton.Enabled = false;

            }
        }

        private void CaptchaLoginTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = CaptchaLoginTextBox.Text;
            if (text != "")
            {
                CheckWordCaptchaButton.Enabled = true;
            }
            else
            {
                CheckWordCaptchaButton.Enabled = false;

            }
        }

        private void CheckWordCaptchaButton_Click(object sender, EventArgs e)
        {
            string CaptchaCodeEntered = CaptchaLoginTextBox.Text;
            string CaptchaCode = CaptchaLabel.Text;
            CaptchaLoginTextBox.Enabled = false;

            if (CaptchaCodeEntered != CaptchaCode)
            {
                NumberOfFailedCaptchaTests++;
                if (NumberOfFailedCaptchaTests >= 3)
                {
                    if (CaptchaFailureWaitingTimeQueue.Count > 0)
                    {
                        CountDownTime = CaptchaFailureWaitingTimeQueue.Dequeue();
                    }
                    CountDownTimeSpan = TimeSpan.FromMinutes(CountDownTime);
                    MessageBox.Show("Captcha Failed\nTry again in " + CountDownTimeSpan.ToString(@"mm\:ss"));

                    CaptchaCountDownTimer.Start();
                    CountDownTimeLabel.Visible = true;
                    LoginGroupBox.Enabled = false;
                }
                else
                {
                    CaptchaLoginTextBox.Text = "";
                    MessageBox.Show("Try Again");
                    CaptchaLoginTextBox.Enabled = true;

                    SetCaptchaCode();
                }
            }
            else
            {
                CaptchaImageTestPanel.Visible = true;
                CaptchaWordTestPanel.Visible = false;
            }
        }

        private void CodeTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = CodeTextBox.Text;
            if (text != "")
            {
                registButton.Enabled = true;
            }
            else
            {
                registButton.Enabled = false;

            }
        }

        private double CalculateRotationAngle(Point clickPoint)
        {
            double deltaX = clickPoint.X - CaptchaCircularPictureBox.Width / 2;
            double deltaY = clickPoint.Y - CaptchaCircularPictureBox.Height / 2;

            double angleInRadians = Math.Atan2(deltaY, deltaX);
            double angleInDegrees = angleInRadians * (180.0 / Math.PI);
            return angleInDegrees + 90; // Add 90 degrees to align with clicked point
        }

        public void SetProfileDetails(bool IsPhaseOne)
        {
            this.Hide();
            ServerCommunication.InitialProfileSelection = new InitialProfileSelection(IsPhaseOne); 
            this.Invoke(new Action(() => ServerCommunication.InitialProfileSelection.ShowDialog()));
        }

    }
}
