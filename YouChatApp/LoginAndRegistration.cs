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

namespace YouChatApp
{
    public partial class LoginAndRegistration : Form
    {


        /// <summary>
        /// Declares a variable of type RulesPage
        /// </summary>
        //RulesPage rulesPage;

        /// <summary>
        /// Represents how the password will be displayed
        /// </summary>
        Boolean passwordIsShown = false;

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
        }

        /// <summary>
        /// The method "OpenColorChoiceForm" sets the "name" variable in the ClientClass to the value entered in the "usernameloginTextbox" field
        /// It then hides the current form and creates a new instance of the ColorChoice form
        /// Then it invokes a method to show the ColorChoice Dialog
        /// </summary>
        public void OpenApp()
        {
            this.Hide();
            ServerCommunication.youChat = new YouChat();
            this.Invoke(new Action(() => ServerCommunication.youChat.ShowDialog()));
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
            string dateOfBirth = dateTimePicker1.Value.ToShortDateString();
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
                            registButton.Enabled = false;
                            string userDetails = username + "#" + password + "#" + firstname + "#" + lastname + "#" + email + "#" + city + "#" + dateOfBirth + "#" + Gender;
                            //ServerCommunication.SendMessage(ServerCommunication.registerRequest + "$" + userDetails + "$" + userDetails.Length);
                            //SendCodeToUserEmail();
                        }
                    }
                }
            }
            else
                MessageBox.Show("That's not an email address");
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
            if (password.Contains("#"))
                MessageBox.Show("choose a password which doesn't contain '#'");
            else
            {
                loginButton.Enabled = false;
                string userLoginDetails = username + "#" + password;
                ServerCommunication.SendMessage(ServerCommunication.loginRequest + "$" + userLoginDetails);
            }

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
            ReturnToStarterScreen.Visible = true;
            RegisterScreenButton.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
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
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            ReturnToStarterScreen.Visible = false;
            RegisterScreenButton.Visible = true;
        }

        /// <summary>
        /// The method "moveToLoginPage" modifies the visibility of several elements
        /// It sets the "Visible" property of ReturnToStarterScreen to false and sets the "Visible" property of RegisterScreenButton to true
        /// It also sets the "Visible" property of groupBox1 to false and sets the "Visible" property of groupBox2 to true        
        /// </summary>
        public void moveToLoginPage()
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            ReturnToStarterScreen.Visible = false;
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
            if ((usernameloginTextbox.Text != "") && (passwordloginTextbox.Text != ""))
                loginButton.Enabled = true;
            else
                loginButton.Enabled = false;
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
            if ((usernameTextbox.Text != "") && (passwordTextbox.Text != "") && (firstnameTextbox.Text != "") && (lastnameTextbox.Text != "") && (emailTextbox.Text != "") && (cityTextbox.Text != "") && (dateTimePicker1.CustomFormat != " " && (RadioButtonIsChecked())))

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
        /// The "RulesButton_Click" event handler creates a new instance of the RulesPage form and shows it
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void RulesButton_Click(object sender, EventArgs e)
        {
            //rulesPage = new RulesPage(this);
            //rulesPage.Show();
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
            Timer.Start();
            dateTimePicker1.MinDate = new DateTime(DateTime.Today.Year - 100, DateTime.Today.Month, DateTime.Today.Day);
            dateTimePicker1.MaxDate = DateTime.Now;
            //dateTimePicker1.Value = DateTime.Now;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = " ";
                RegistButtonSetEnabled();
            }
            // להוסיף כפתור של ריפרש וגם בלחיצה עליו יקרה אותו דבר
        }

        private void FemaleRadioButton_Click(object sender, EventArgs e)
        {
            MaleButtonIsChecked = false;
            AnotherGenderButtonIsChecked = false;
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
        }

        private void AnotherGenderRadioButton_Click(object sender, EventArgs e)
        {
            MaleButtonIsChecked = false;
            FemaleButtonIsChecked = false;
            if (AnotherGenderButtonIsChecked == false)
            {
                AnotherGenderButtonIsChecked = true;
                Gender = "Another Gender";
            }
            else
            {
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
        }

        private void MaleRadioButton_Click(object sender, EventArgs e)
        {
            FemaleButtonIsChecked = false;
            AnotherGenderButtonIsChecked = false;
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
        }

        private Boolean RadioButtonIsChecked()
        {
            return (MaleButtonIsChecked || FemaleButtonIsChecked || AnotherGenderButtonIsChecked);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            RegistButtonSetEnabled();
        }

        public void SendCodeToUserEmail()
        {
            string server = "smtp.gmail.com";
            int port = 465;

            string password = "some password";
            string SourceEmail = "youchatcyberapplication@gmail.com";
            string DestinationEmail = emailTextbox.Text;
            string subject = "verification code";
            string body = "here is your code\n" + getCode();

            MailMessage mail = new MailMessage(SourceEmail, DestinationEmail);
            mail.Subject = subject;
            mail.Body = body;
            SmtpClient smtpClient = new SmtpClient(server, port);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(SourceEmail, password);
            smtpClient.Send(mail);
        }

        public static string getCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6).Select(s =>
            s[random.Next(s.Length)]).ToArray());
        }

    }
}
