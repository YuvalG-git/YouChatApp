using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    public partial class CaptchaCodeControl : UserControl
    {
        public CaptchaCodeControl()
        {
            InitializeComponent();
        }
        public void SetCaptchaImage(Image captchaImage)
        {
            CaptchaPictureBox.Image = captchaImage;
        }

        private void CaptchaCheckerCustomButton_Click(object sender, EventArgs e)
        {
            //send a message to the server...
        }

        private void RestartCaptchaCustomButton_Click(object sender, EventArgs e)
        {

        }

        private void CaptchaCodeCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            if (CaptchaCodeCustomTextBox.IsContainingValue())
            {
                CaptchaCheckerCustomButton.Enabled = true;
            }
            else
            {
                CaptchaCheckerCustomButton.Enabled = false;
            }
        }
    }
}
