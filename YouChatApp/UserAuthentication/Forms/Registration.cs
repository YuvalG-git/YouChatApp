using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YouChatApp.UserAuthentication.Forms
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void UsernameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {

        }

        private void UsernameCustomTextBox_Leave(object sender, EventArgs e)
        {
            string username = UsernameCustomTextBox.TextContent;
            string error = "";
            if (UsernameCustomTextBox.isPlaceHolder())
            {
                UsernameCustomTextBox.BorderColor = Color.MediumSlateBlue;
            }
            else
            {
                if (!StringHandler.IsAlphanumeric(username))
                {
                    error += "The Username can only contain alpha and numeric characters\r\n";
                }
                if (username.Length < 4)
                {
                    error += "The Username must be longer than 4 letters";
                }
                else if (username.Length >= 30)
                {
                    error += "The Username must be shorter than 31 letters";
                }
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
}
