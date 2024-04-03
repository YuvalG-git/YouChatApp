using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    public partial class InitialProfileSelection : Form
    {
        public InitialProfileSelection(bool IsPhaseOne)
        {
            InitializeComponent();
            //ServerCommunication.MessageBeginRead();
            //ProfilePictureImageList.InitializeImageLists(); //todo - does it nessery if i did it before in another form - need to check...
            ProfilePictureControl.AddButtonClickHandler(SetConfirmButtonEnabled);
            if (IsPhaseOne)
            {
                SetPhaseOne();
            }
            else
            {
                SetPhaseTwo();
            }



        }

        private void RefreshTextButton_Click(object sender, EventArgs e)
        {
            ProfileStatusTextBox.Text = "Write Here Your YouChat Status";
            ProfileStatusTextBox.ForeColor = Color.Silver;
            CharNumberLabel.Text = "0/" + ProfileStatusTextBox.MaxLength;

        }

        private void ProfileStatusTextBox_TextChanged(object sender, EventArgs e)
        {
            CharNumberLabel.Text = ProfileStatusTextBox.TextLength.ToString() + "/" + ProfileStatusTextBox.MaxLength;
            string StatusText = ProfileStatusTextBox.Text;
            if ((StatusText != "") && (StatusText != "Write Here Your YouChat Status"))
            {
                ConfirmCustomButton.Enabled = true;
            }
            else
            {
                ConfirmCustomButton.Enabled = false;
            }
        }

        private void ProfileStatusTextBox_Enter(object sender, EventArgs e)
        {
            if (ProfileStatusTextBox.Text == "Write Here Your YouChat Status")
            {
                ProfileStatusTextBox.Text = "";
                ProfileStatusTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void ProfileStatusTextBox_Leave(object sender, EventArgs e)
        {
            if (ProfileStatusTextBox.Text == "")
            {
                ProfileStatusTextBox.Text = "Write Here Your YouChat Status";
                ProfileStatusTextBox.ForeColor = Color.Silver;
            }
        }

        public void OpenApp()
        {
            this.Hide();
            ServerCommunication._youChat = new YouChat();
            this.Invoke(new Action(() => ServerCommunication._youChat.ShowDialog()));
        }

        private void SetPhaseOne()
        {
            ProfilePictureControl.Visible = true;
            StatusGroupBox.Visible = false;
            ProfileSettingsHeadlineLabel.Text = "Profile Picture";
        }
        public void SetPhaseTwo()
        {
            ProfilePictureControl.Visible = false;
            StatusGroupBox.Visible = true;
            ProfileSettingsHeadlineLabel.Text = "Status";

        }

        public void SetConfirmButtonEnabled(object sender, EventArgs e)
        {
            if (ProfilePictureControl.ImageChosenAtTheMoment != null)
            {
                ConfirmCustomButton.Enabled = true;
            }
            else
            {
                ConfirmCustomButton.Enabled = false;

            }
        }
        public void SetConfirmButtonEnabledToFalse()
        {
            ConfirmCustomButton.Enabled = false;
        }
        public void SetConfirmButtonEnabledToTrue()
        {
            ConfirmCustomButton.Enabled = true;
        }

        private void ConfirmCustomButton_Click(object sender, EventArgs e)
        {
            if (ProfilePictureControl.Visible)
            {
                string ProfilePictureId = ProfilePictureControl.GetImageNameID();
                //ServerCommunication.SendMessage(ServerCommunication.UploadProfilePictureRequest + "$" + ProfilePictureId);

                //ServerCommunication.SendMessage(ServerCommunication.UploadProfilePictureRequest, ProfilePictureId);
            }
            else
            {
                string ProfileStatus = ProfileStatusTextBox.Text;
                //ServerCommunication.SendMessage(ServerCommunication.UploadStatusRequest + "$" + ProfileStatus);

                //ServerCommunication.SendMessage(ServerCommunication.UploadStatusRequest, ProfileStatus);
            }
        }
    }
}
