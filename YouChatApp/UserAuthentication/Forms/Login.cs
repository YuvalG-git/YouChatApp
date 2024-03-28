using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.UserAuthentication.Forms
{
    public partial class Login : Form
    {
        SmtpHandler smtpHandler;

        public Login()
        {
            InitializeComponent();
            //ServerCommunication.Connect("10.100.102.3");
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
    }
}
