using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    public partial class Profile : Form
    {
        YouChat YouChat;
        List<Image> images;
        public Profile(YouChat youChat)
        {
            InitializeComponent();
            YouChat = youChat;
            SetProfileAvatarMatrix();
            images = new List<Image>();
            DirectoryInfo di = new DirectoryInfo(@"C:\\Users\\יובל\\Documents\\יא2 יובל\\הנדסת תוכנה\\avatars"); // give a path    
            FileInfo[] finfos = di.GetFiles("*.jpg", SearchOption.AllDirectories);
            foreach (FileInfo fi in finfos)
                images.Add(Image.FromFile(fi.FullName));
            //todo to set the profile picture and the status according to the server...
            //need to also change the previous messages that have been sent after a changed profile picture
        }

        private void SetProfileAvatarMatrix()
        {
            ProfileAvatarMatrix = new Button[4, 9];
            int x = 50, y = 5;
            for (int i = 0; i < ProfileAvatarMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ProfileAvatarMatrix.GetLength(1); j++)
                {
                    string name = i.ToString() + "," + j.ToString();
                    ProfileAvatarMatrix[i, j] = new System.Windows.Forms.Button();
                    this.ProfileAvatarMatrix[i, j].Location = new System.Drawing.Point(x, y);
                    this.ProfileAvatarMatrix[i, j].Name = name;
                    this.ProfileAvatarMatrix[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177))); ;
                    this.ProfileAvatarMatrix[i, j].Size = new System.Drawing.Size(75, 75);
                    this.ProfileAvatarMatrix[i, j].TabIndex = 0;
                    this.ProfileAvatarMatrix[i, j].Text = "";
                    this.ProfileAvatarMatrix[i, j].BackColor = SystemColors.Control;
                    this.ProfileAvatarMatrix[i, j].UseVisualStyleBackColor = true;
                    this.ProfileAvatarMatrix[i, j].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    //this.ProfileAvatarMatrix[i, j].BackgroundImage = images[(i*5)+j];
                    this.Controls.Add(this.ProfileAvatarMatrix[i, j]);
                    this.ProfilePicturePanel.Controls.Add(this.ProfileAvatarMatrix[i, j]);
                    this.ProfileAvatarMatrix[i, j].Click += new System.EventHandler(ProfilePictureOption_Click);
                    x += 85;
                }
                x = 50;
                y += 85;
            }
        }

        private void ProfilePictureOption_Click(object sender, EventArgs e)
        {
            foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
            {
                AvatarProfilePicture.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                AvatarProfilePicture.UseVisualStyleBackColor = true;
                AvatarProfilePicture.Enabled = true;

            }

            ((Button)(sender)).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ((Button)(sender)).FlatAppearance.BorderColor = Color.Green;
            ((Button)(sender)).FlatAppearance.BorderSize = 2;
            ((Button)(sender)).BackColor = System.Drawing.SystemColors.ButtonShadow;
            ((Button)(sender)).Enabled = false;
        }
        private void SetProfilePictures()
        {

        }

        public Profile()
        {
            //בשביל הניסיונות - לא לשמור את זה
            InitializeComponent();
            SetProfileAvatarMatrix();
            images = new List<Image>();
            DirectoryInfo di = new DirectoryInfo(@"C:\\Users\\יובל\\Documents\\יא2 יובל\\הנדסת תוכנה\\avatars"); // give a path    
            FileInfo[] finfos = di.GetFiles("*.jpg", SearchOption.AllDirectories);
            foreach (FileInfo fi in finfos)
                images.Add(Image.FromFile(fi.FullName));

        }

        private void Profile_FormClosing(object sender, FormClosingEventArgs e)
        {
            //לטפל בכל החלק של להעביר את המושכות למסך הצאט
        }

        private void DisconnentButton_Click(object sender, EventArgs e)
        {
            LogOutApprovalButton.Visible = true;
            LackOfLogOutApprovalButton.Visible = true;
            LogOutConfirmationLabel.Visible = true;
            DisconnentButton.Enabled = false;
        }

        private void LackOfLogOutApprovalButton_Click(object sender, EventArgs e)
        {
            LogOutApprovalButton.Visible = false;
            LackOfLogOutApprovalButton.Visible = false;
            LogOutConfirmationLabel.Visible = false;
            DisconnentButton.Enabled = true;
        }

        private void LogOutApprovalButton_Click(object sender, EventArgs e)
        {
            //ServerCommunication.SendMessage(ServerCommunication.disconnectRequest + "$" + "color erasure");
            this.Close();
            //System.Windows.Forms.Application.ExitThread();

            //אולי עדיף במקום לסגור פשוט להחזיר למסך הכניסה של הlogin register
        }

        private void ProfilePictureSelectionButton_Click(object sender, EventArgs e)
        {
            ProfilePictureSelectionButton.Enabled = false;
            StatusSelectionButton.Enabled = true;
            ProfilePictureSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            StatusSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            ProfilePictureSelectionButton.FlatAppearance.BorderColor = Color.Green;
            ProfilePictureSelectionButton.FlatAppearance.BorderSize = 2;
            ProfilePictureSelectionButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            StatusSelectionButton.UseVisualStyleBackColor = true;
            SettingsModeLabel.Visible = true;
            SettingsModeLabel.Text = "Profile Picture";
            StatusPanel.Visible = false;
            ProfilePicturePanel.Visible = true;
            //locationלטפל גם ב
        }

        private void StatusSelectionButton_Click(object sender, EventArgs e)
        {
            StatusSelectionButton.Enabled = false;
            ProfilePictureSelectionButton.Enabled = true;
            StatusSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ProfilePictureSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            StatusSelectionButton.FlatAppearance.BorderColor = Color.Green;
            StatusSelectionButton.FlatAppearance.BorderSize = 2;
            StatusSelectionButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            ProfilePictureSelectionButton.UseVisualStyleBackColor = true;
            SettingsModeLabel.Visible = true;
            SettingsModeLabel.Text = "Status";
            StatusPanel.Visible = true;
            ProfilePicturePanel.Visible = false;


            //locationלטפל גם ב


        }

        private void SaveTextButton_Click(object sender, EventArgs e)
        {
            CurrentStatusLabel.Text = CurrentStatusLabel.Text.Substring(0, 16) + ProfileStatusTextBox.Text;
            //todo need to send the server the new status
        }

        private void RefreshTextButton_Click(object sender, EventArgs e)
        {
            ProfileStatusTextBox.Text = "";
        }

        private void ProfileStatusTextBox_TextChanged(object sender, EventArgs e)
        {
           CharNumberLabel.Text = ProfileStatusTextBox.TextLength.ToString() + "/" + ProfileStatusTextBox.MaxLength;
        }
    }
}
