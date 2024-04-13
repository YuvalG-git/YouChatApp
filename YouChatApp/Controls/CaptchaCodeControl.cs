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
        public event EventHandler CaptchaCheckerCustomButtonClick;
        public event EventHandler RestartCaptchaCustomButtonClick;
        public CaptchaCodeControl()
        {
            InitializeComponent();
        }

        public void AddCaptchaCheckerCustomButtonClickHandler(EventHandler handler)
        {
            CaptchaCheckerCustomButtonClick += handler;
        }
        public void HandleWrongCodeCase()
        {
            NotificationLabel.Visible = true;
            RestartCaptchaCustomButton.Enabled = true;
            CaptchaCodeCustomTextBox.TextContent = "";
        }
        public void AddRestartCaptchaCustomButtonClickHandler(EventHandler handler)
        {
            RestartCaptchaCustomButtonClick += handler;
        }
        public void SetCaptchaImage(Image captchaImage)
        {
            CaptchaPictureBox.Image = captchaImage;
            CaptchaCodeCustomTextBox.TextContent = "";
            CaptchaCodeCustomTextBox.Enabled = true;
        }

        private void CaptchaCheckerCustomButton_Click(object sender, EventArgs e)
        {
            CaptchaCodeCustomTextBox.Enabled = false;
            CaptchaCheckerCustomButton.Enabled = false;
            RestartCaptchaCustomButton.Enabled = false;
            CaptchaCheckerCustomButtonClick?.Invoke(this, e);
        }
        public string GetCaptchaCode()
        {
            return CaptchaCodeCustomTextBox.TextContent;
        }

        private void RestartCaptchaCustomButton_Click(object sender, EventArgs e)
        {
            CaptchaCodeCustomTextBox.TextContent = "";
            CaptchaCodeCustomTextBox.Enabled = false;
            CaptchaCheckerCustomButton.Enabled = false;
            CaptchaPictureBox.Image = null;
            NotificationLabel.Visible = false;

            RestartCaptchaCustomButtonClick?.Invoke(this, e);
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
