using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.JsonClasses;

namespace YouChatApp.UserAuthentication.Forms
{
    public partial class Login : Form
    {
        SmtpHandler smtpHandler;

        public Login()
        {
            InitializeComponent();
            ServerCommunication.Connect("10.100.102.3");
            ServerCommunication._login = this;
            smtpHandler = new SmtpHandler();

        }

        private void ResetPasswordCustomButton_Click(object sender, EventArgs e)
        {
            ServerCommunication._passwordRestart = new PasswordRestart();
            this.Invoke(new Action(() => ServerCommunication._passwordRestart.ShowDialog()));
        }

        private void SignUpCustomButton_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the login form
            ServerCommunication._registration = new Registration();
            ServerCommunication._registration.ShowDialog(); // Show the registration form
        }

        private void LoginFieldsTextChangedEvent(object sender, EventArgs e)
        {
            if (UsernameCustomTextBox.IsContainingValue() && PasswordGeneratorControl.DoesAllFieldsHaveValue())
                LoginCustomButton.Enabled = true;
            else
                LoginCustomButton.Enabled = false;
        }

        private void PasswordGeneratorControl_Load(object sender, EventArgs e)
        {

        }

        private void LoginCustomButton_Click(object sender, EventArgs e)
        {
            string username = UsernameCustomTextBox.TextContent;
            string password = PasswordGeneratorControl.GetNewPassword();
            if (username.Contains("#"))
                MessageBox.Show("choose an username which doesn't contain '#'");
            else if (password.Contains("#"))
                MessageBox.Show("choose a password which doesn't contain '#'");
            else
            {
                LoginCustomButton.Enabled = false;
                //string userLoginDetails = username + "#" + password;
                LoginDetails userLoginDetails = new LoginDetails(username, password);
                JsonObject jsonObject = new JsonClasses.JsonObject(EnumHandler.CommunicationMessageID_Enum.loginRequest, userLoginDetails);
                string userLoginDetailsJson = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                ServerCommunication.SendMessage(userLoginDetailsJson);

                // Deserialize with TypeNameHandling and a custom converter for MessageBody
                JsonClasses.JsonObject p1 = JsonConvert.DeserializeObject<JsonClasses.JsonObject>(chatDetailsJson, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Converters = { new EnumConverter<EnumHandler.UserAuthentication_Enum>() }
                });


                JsonClasses.PersonalVerificationAnswers p34 = p1.MessageBody as JsonClasses.PersonalVerificationAnswers;
                //ServerCommunication.SendMessage(ServerCommunication.loginRequest, userLoginDetails);
            }
        }
    }
}
