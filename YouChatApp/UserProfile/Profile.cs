using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.JsonClasses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace YouChatApp
{
    public partial class Profile : Form
    {
        YouChat YouChat;
        Queue<Image> MaleImages;
        Boolean ProfilePictureMatrixIsStandart = true;
        Boolean FirstProfilePictureMatrixUpload = true;
        Image ImageChosenAtTheMoment;
        Boolean[] PrivacySettingsChoicesArray;
        string CurrentSelectedPrivacySettingsOption;
        string CurrentSelectedRadioButtonName;
        string CurrentSelectedChatSettingsOption;

        public Profile(YouChat youChat)
        {
            InitializeComponent();
            YouChat = youChat;
            MaleImages = new Queue<Image>();
            //DirectoryInfo di = new DirectoryInfo(@"C:\\Users\\יובל\\Documents\\יא2 יובל\\הנדסת תוכנה\\avatars"); // give a path    
            //FileInfo[] finfos = di.GetFiles("*.jpg", SearchOption.AllDirectories);
            //foreach (FileInfo fi in finfos)
             //   MaleImages.Enqueue(Image.FromFile(fi.FullName));
            SetProfileAvatarMatrix();
            ProfilePictureKindButtonsCreator();
            ChatSettingsOptionButtonCreator();
            PrivacySettingsOptionButtonCreator();
            SetPrivacySettingsChoicesArray();
            ServerCommunication._profile = this;
            //ProfilePictureImageList.InitializeImageLists(); //todo - does it nessery if i did it before in another form - need to check...
            SetProperties();

            //todo to set the profile picture and the status according to the server...
            //need to also change the previous messages that have been sent after a changed profile picture
        }
        private void SetProperties()
        {
            //to take the information from profiledetailshandler and to insert them to the different controls..
            CurrentStatusLabel.Text += UserProfile.ProfileDetailsHandler.Status; //this is example to everything
            PrivacySettingsChoicesArray[0] = UserProfile.ProfileDetailsHandler.LastSeenProperty;
            PrivacySettingsChoicesArray[1] = UserProfile.ProfileDetailsHandler.OnlineProperty;
            PrivacySettingsChoicesArray[2] = UserProfile.ProfileDetailsHandler.ProfilePictureProperty;
            PrivacySettingsChoicesArray[3] = UserProfile.ProfileDetailsHandler.StatusProperty;
            MessageGapScrollBar.Value = UserProfile.ProfileDetailsHandler.MessageGap;
            MessageTextSizeComboBox.SelectedIndex = UserProfile.ProfileDetailsHandler.TextSize;
            EnterPressedToggleButton.Checked = UserProfile.ProfileDetailsHandler.EnterKeyPressed;
        }

        private void SetPrivacySettingsChoicesArray()
        {
            PrivacySettingsChoicesArray = new Boolean[4];
            for (int i = 0; i < PrivacySettingsChoicesArray.GetLength(0); i++)
            {
                PrivacySettingsChoicesArray[i] = true;
            }
        }

        private void ProfilePictureKindButtonsCreator()
        {
            ProfilePictureKindSelectionButtons = new Button[3];
            int x = 250;
            for (int i = 0; i < ProfilePictureKindSelectionButtons.GetLength(0); i++)
            {
                ProfilePictureKindSelectionButtons[i] = new Button();
                this.ProfilePictureKindSelectionButtons[i].Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ProfilePictureKindSelectionButtons[i].Location = new System.Drawing.Point(x, 10);
                this.ProfilePictureKindSelectionButtons[i].Size = new System.Drawing.Size(120, 35);
                this.ProfilePictureKindSelectionButtons[i].TabIndex = 16;
                this.ProfilePictureKindSelectionButtons[i].UseVisualStyleBackColor = true;
                this.ProfilePicturePanel.Controls.Add(this.ProfilePictureKindSelectionButtons[i]);
                this.ProfilePictureKindSelectionButtons[i].Click += new System.EventHandler(ProfilePictureKindOption_Click);

                x += 150;
            }
            this.ProfilePictureKindSelectionButtons[0].Name = "MaleSelectionButton";
            this.ProfilePictureKindSelectionButtons[0].Text = "Male Icons"; //האם כדאי לעשות רשימה במקום ואז להגיד שהשם שווה לשם במיקום המסוים ברשימה
            this.ProfilePictureKindSelectionButtons[1].Name = "FemaleSelectionButton";
            this.ProfilePictureKindSelectionButtons[1].Text = "Female Icons";
            this.ProfilePictureKindSelectionButtons[2].Name = "AnimalSelectionButton";
            this.ProfilePictureKindSelectionButtons[2].Text = "Animal Icons";
        }

        private void SetProfileAvatarMatrix()
        {
            ProfileAvatarMatrix = new Button[6, 5];
            int x = 220, y = 60;
            for (int i = 0; i < ProfileAvatarMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ProfileAvatarMatrix.GetLength(1); j++)
                {
                    if (!((i == ProfileAvatarMatrix.GetLength(0) - 1) && ((j == 0) || (j == ProfileAvatarMatrix.GetLength(1) - 1))))
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
                        this.ProfileAvatarMatrix[i, j].Visible = false;

                        //this.ProfileAvatarMatrix[i, j].BackgroundImage = MaleImages.Dequeue();
                        //this.ProfileAvatarMatrix[i, j].BackgroundImage = MaleImageList.Images[i];
                        this.Controls.Add(this.ProfileAvatarMatrix[i, j]);
                        this.ProfilePicturePanel.Controls.Add(this.ProfileAvatarMatrix[i, j]);
                        this.ProfileAvatarMatrix[i, j].Click += new System.EventHandler(ProfilePictureOption_Click);
                    }
                    x += 85;
                }
                x = 220;
                y += 85;
            }
        }



        private void ProfilePictureOption_Click(object sender, EventArgs e)
        {
            Boolean wasCurrentlyChosen = false;
            if (((Button)(sender)).FlatStyle == System.Windows.Forms.FlatStyle.Flat)
            {
                wasCurrentlyChosen = true;
                SaveProfilePictureButton.Enabled = false;
            }
            foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
            {
                if (AvatarProfilePicture != null)
                {
                    AvatarProfilePicture.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                    AvatarProfilePicture.UseVisualStyleBackColor = true;
                }
            }//לחשוב אם אני רוצה לאחר אישור התמונה להעלים את הבחירה בתמונה (במקרה כזה להעתיק את קטע הקוד הזה ולהעביר אותו לפעולה) ואז לזמן את הפעולה גם כאן וגם לאחר לחיצה על כפתור האישור
            // אחרת לדאוג שמלכתחילה שפותחים את החלון, תמונת הפרופיל הנוכחית מופיעה מיוחד...
            if (!wasCurrentlyChosen)
            {
                ((Button)(sender)).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                ((Button)(sender)).FlatAppearance.BorderColor = Color.Green;
                ((Button)(sender)).FlatAppearance.BorderSize = 2;
                ((Button)(sender)).BackColor = System.Drawing.SystemColors.ButtonShadow;
                ImageChosenAtTheMoment = ((Button)(sender)).BackgroundImage;
                SaveProfilePictureButton.Enabled = true;

            }
        }
        private void SetProfilePictures()
        {

        }

        public Profile()
        {
            //בשביל הניסיונות - לא לשמור את זה
            InitializeComponent();
            LoadImages1();
            SetProfileAvatarMatrix();
            ProfilePictureKindButtonsCreator();
            PrivacySettingsOptionButtonCreator();
            SetPrivacySettingsChoicesArray();
            ChatSettingsOptionButtonCreator();
            ServerCommunication._profile = this;
            //ProfilePictureImageList.InitializeImageLists(); //todo - does it nessery if i did it before in another form - need to check...

        }

        private void LoadImages1()
        {
            MaleImages = new Queue<Image>();
            //Properties.Resources
            DirectoryInfo di = new DirectoryInfo(@"C:\\Users\\יובל\\Documents\\יא2 יובל\\הנדסת תוכנה\\avatars"); // give a path    
            FileInfo[] finfos = di.GetFiles("*.png", SearchOption.AllDirectories);
            foreach (FileInfo fi in finfos)
                MaleImages.Enqueue(Image.FromFile(fi.FullName));
        }

        private void SetProfilePictrueMatrixVisible()
        {
            foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
            {
                if (AvatarProfilePicture != null)
                {
                    AvatarProfilePicture.Visible = true;
                }
            }
        }

        private void SetProfilePictrueMatrixInvisible()
        {
            for (int i = 0; i < ProfileAvatarMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ProfileAvatarMatrix.GetLength(1); j++)
                {
                    if (ProfileAvatarMatrix[i, j] != null)
                    {
                        ProfileAvatarMatrix[i, j].Visible = false;
                        if (i == ProfileAvatarMatrix.GetLength(0) - 1)
                        {
                            this.ProfileAvatarMatrix[i, j].Location = new System.Drawing.Point(this.ProfileAvatarMatrix[i-1, j].Location.X, this.ProfileAvatarMatrix[i, j].Location.Y);
                        }
                    }
                }
            }
            FirstProfilePictureMatrixUpload = true;
            ProfilePictureMatrixIsStandart = true;
        }

        private void SetPrivacySettingsVisible()
        {
            ContactsOptionRadioButton.Visible = true;
            NobodyOptionRadioButton.Visible = true;

        }

        private void SetPrivacySettingsInvisible()
        {
            ContactsOptionRadioButton.Visible = false;
            NobodyOptionRadioButton.Visible = false;

        }

        private void SetChatSettingsInvisible()
        {
            MessageGapScrollBar.Visible = false;
            MessageGapTextBox.Visible = false;
            MessageGapLabel.Visible = false;
            MessageTextSizeComboBox.Visible = false;
            EnterPressedLabel.Visible = false;
            EnterPressedToggleButton.Visible = false;
        }

        private void SetMaleProfilePictureOption()
        {
            int location = 0;
            int LastRow = ProfileAvatarMatrix.GetLength(0) - 1;
            string lastRowAsString = LastRow.ToString();
            Boolean wasChanged = false;
            foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
            {
                if (AvatarProfilePicture != null)
                {
                    AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.MaleProfilePictureImageList.Images[location];
                    //AvatarProfilePicture.BackgroundImage = MaleImageList.Images[location];
                    location++;
                    if ((!ProfilePictureMatrixIsStandart) && (AvatarProfilePicture.Name.StartsWith(lastRowAsString)))
                    {
                        wasChanged = true;
                        if (AvatarProfilePicture.Name.EndsWith("3"))
                        {
                            AvatarProfilePicture.Visible = true;
                        }
                        else
                        {
                            AvatarProfilePicture.Location = new System.Drawing.Point(AvatarProfilePicture.Location.X - 41, AvatarProfilePicture.Location.Y);
                        }
                    }
                }               
            }
            if (wasChanged)
                ProfilePictureMatrixIsStandart = true;

        }

        private void SetFemaleProfilePictureOption()
        {
            int location = 0;
            int LastRow = ProfileAvatarMatrix.GetLength(0) - 1;
            string lastRowAsString = LastRow.ToString();
            Boolean wasChanged = false;
            foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
            {
                if (AvatarProfilePicture != null)
                {
                    if (FemaleImageList.Images.Count > location)
                    {
                        AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.FemaleProfilePictureImageList.Images[location];
                        //AvatarProfilePicture.BackgroundImage = FemaleImageList.Images[location];
                        location++;
                        if ((ProfilePictureMatrixIsStandart) && (AvatarProfilePicture.Name.StartsWith(lastRowAsString)))
                        {
                            //if (AvatarProfilePicture.Name.EndsWith("3"))
                            //{
                            //    AvatarProfilePicture.Visible = false;
                            //    AvatarProfilePicture.BackgroundImage = null;

                            //}
                            //else
                            //{
                            //    AvatarProfilePicture.Location = new System.Drawing.Point(AvatarProfilePicture.Location.X  + 41, AvatarProfilePicture.Location.Y);
                            //}
                            wasChanged = true;
                            AvatarProfilePicture.Location = new System.Drawing.Point(AvatarProfilePicture.Location.X + 41, AvatarProfilePicture.Location.Y);
                        }
                    }
                    else if (ProfilePictureMatrixIsStandart)
                    {
                        AvatarProfilePicture.Visible = false;
                    }
                }
            }
            if (wasChanged)
                ProfilePictureMatrixIsStandart = false;
        }
        private void SetAnimalProfilePictureOption()
        {
            int location = 0;
            int LastRow = ProfileAvatarMatrix.GetLength(0) - 1;
            string lastRowAsString = LastRow.ToString();
            Boolean wasChanged = false;

            foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
            {
                if (AvatarProfilePicture != null)
                {
                    if (AnimalImageList.Images.Count > location)
                    {
                        //AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.AnimalProfilePictureImageList.Images[location];

                        AvatarProfilePicture.BackgroundImage = AnimalImageList.Images[location];

                        location++;
                        if ((ProfilePictureMatrixIsStandart) && (AvatarProfilePicture.Name.StartsWith(lastRowAsString)))
                        {
                            wasChanged = true;
                            AvatarProfilePicture.Location = new System.Drawing.Point(AvatarProfilePicture.Location.X + 41, AvatarProfilePicture.Location.Y);
                        }
                    }
                    else if (ProfilePictureMatrixIsStandart)
                    {
                        AvatarProfilePicture.Visible = false;
                    }
                }
            }
            if (wasChanged)
                ProfilePictureMatrixIsStandart = false;
        }
        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Invoke(new Action(() => ServerCommunication._youChat.SetProfileButtonEnabled()));

        }


        private void DisconnentButton_Click(object sender, EventArgs e)
        {
            LogOutApprovalButton.Visible = true;
            LackOfLogOutApprovalButton.Visible = true;
            LogOutConfirmationLabel.Visible = true;
            DisconnentButton.Enabled = false;
            if (MessageBox.Show("Are you sure you want to log out?", "YouChat Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }    

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
            PrivacySettingsSelectionButton.Enabled = true;
            ChatSettingsSelectionButton.Enabled = true;


            ProfilePictureSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            StatusSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            PrivacySettingsSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            ChatSettingsSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;


            ProfilePictureSelectionButton.FlatAppearance.BorderColor = Color.Green;
            ProfilePictureSelectionButton.FlatAppearance.BorderSize = 2;
            ProfilePictureSelectionButton.BackColor = System.Drawing.SystemColors.ButtonShadow;

            StatusSelectionButton.UseVisualStyleBackColor = true;
            PrivacySettingsSelectionButton.UseVisualStyleBackColor = true;
            ChatSettingsSelectionButton.UseVisualStyleBackColor = true;


            SettingsModeLabel.Visible = true;
            SettingsModeLabel.Text = "Profile Picture";
            ProfilePicturePanel.Visible = true;
            StatusPanel.Visible = false;
            PrivacySettingsPanel.Visible = false;
            ChatSettingsPanel.Visible = false;

            RestartPrivacySettingsKindSelection();
            SetPrivacySettingsInvisible();
            RestartChatSettingsKindSelection();
            SetChatSettingsInvisible();
            //locationלטפל גם ב
        }

        private void StatusSelectionButton_Click(object sender, EventArgs e)
        {
            StatusSelectionButton.Enabled = false;
            ProfilePictureSelectionButton.Enabled = true;
            PrivacySettingsSelectionButton.Enabled = true;
            ChatSettingsSelectionButton.Enabled = true;


            StatusSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ProfilePictureSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            PrivacySettingsSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            ChatSettingsSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;


            StatusSelectionButton.FlatAppearance.BorderColor = Color.Green;
            StatusSelectionButton.FlatAppearance.BorderSize = 2;

            StatusSelectionButton.BackColor = System.Drawing.SystemColors.ButtonShadow;

            ProfilePictureSelectionButton.UseVisualStyleBackColor = true;
            PrivacySettingsSelectionButton.UseVisualStyleBackColor = true;
            ChatSettingsSelectionButton.UseVisualStyleBackColor = true;


            SettingsModeLabel.Visible = true;
            SettingsModeLabel.Text = "Status";
            StatusPanel.Visible = true;
            ProfilePicturePanel.Visible = false;
            PrivacySettingsPanel.Visible = false;
            ChatSettingsPanel.Visible = false;

            RestartProfilePictureSelection();
            RestartPrivacySettingsKindSelection();
            SetProfilePictrueMatrixInvisible();
            SetPrivacySettingsInvisible();
            RestartChatSettingsKindSelection();
            SetChatSettingsInvisible();


        }

        private void PrivacySettingsSelectionButton_Click(object sender, EventArgs e)
        {
            PrivacySettingsSelectionButton.Enabled = false;
            StatusSelectionButton.Enabled = true;
            ProfilePictureSelectionButton.Enabled = true;
            ChatSettingsSelectionButton.Enabled = true;

            PrivacySettingsSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            StatusSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            ProfilePictureSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            ChatSettingsSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;


            PrivacySettingsSelectionButton.FlatAppearance.BorderColor = Color.Green;
            PrivacySettingsSelectionButton.FlatAppearance.BorderSize = 2;
            PrivacySettingsSelectionButton.BackColor = System.Drawing.SystemColors.ButtonShadow;

            StatusSelectionButton.UseVisualStyleBackColor = true;
            ProfilePictureSelectionButton.UseVisualStyleBackColor = true;
            ChatSettingsSelectionButton.UseVisualStyleBackColor = true;


            SettingsModeLabel.Visible = true;
            SettingsModeLabel.Text = "Privacy Settings";

            PrivacySettingsPanel.Visible = true;
            StatusPanel.Visible = false;
            ProfilePicturePanel.Visible = false;
            ChatSettingsPanel.Visible = false;

            RestartProfilePictureSelection();
            SetProfilePictrueMatrixInvisible();
            RestartChatSettingsKindSelection();
            SetChatSettingsInvisible();
        }

        private void ChatSettingsSelectionButton_Click(object sender, EventArgs e)
        {
            ChatSettingsSelectionButton.Enabled = false;
            ProfilePictureSelectionButton.Enabled = true;
            PrivacySettingsSelectionButton.Enabled = true;
            StatusSelectionButton.Enabled = true;


            ChatSettingsSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ProfilePictureSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            PrivacySettingsSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            StatusSelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;


            ChatSettingsSelectionButton.FlatAppearance.BorderColor = Color.Green;
            ChatSettingsSelectionButton.FlatAppearance.BorderSize = 2;
            ChatSettingsSelectionButton.BackColor = System.Drawing.SystemColors.ButtonShadow;

            ProfilePictureSelectionButton.UseVisualStyleBackColor = true;
            PrivacySettingsSelectionButton.UseVisualStyleBackColor = true;
            StatusSelectionButton.UseVisualStyleBackColor = true;


            SettingsModeLabel.Visible = true;
            SettingsModeLabel.Text = "Chat Settings"; //todo to set the location of this label as well after i will decide the form's size
            ChatSettingsPanel.Visible = true;
            ProfilePicturePanel.Visible = false;
            PrivacySettingsPanel.Visible = false;
            StatusPanel.Visible = false;

            RestartProfilePictureSelection(); // אולי כדאי לשמור את שם הכפתור שהיה לחוץ ובהתאם אליו לזמן את הפעולות - נשמע די מיותר לזמן עבור כל אחד ואחד מהם המון פעולות
            RestartPrivacySettingsKindSelection();
            SetProfilePictrueMatrixInvisible();
            SetPrivacySettingsInvisible();
        }
        private Boolean ProfilePictureWasSelected()
        {
            foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
            {
                if ((AvatarProfilePicture != null) && (AvatarProfilePicture.BackColor == System.Drawing.SystemColors.ButtonShadow))
                    return true;

            }
            return false;
        }

        private void RestartProfilePictureSelection()
        {
            foreach (Button ProfilePictureKind in ProfilePictureKindSelectionButtons)
            {
                ProfilePictureKind.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                ProfilePictureKind.UseVisualStyleBackColor = true;
                ProfilePictureKind.Enabled = true;
            }
        }

        private void ProfilePictureKindOption_Click(object sender, EventArgs e)
        {
            if (FirstProfilePictureMatrixUpload)
            {
                FirstProfilePictureMatrixUpload = false;
                SetProfilePictrueMatrixVisible();
            }
            RestartProfilePictureSelection();
            ((Button)(sender)).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ((Button)(sender)).FlatAppearance.BorderColor = Color.Green;
            ((Button)(sender)).FlatAppearance.BorderSize = 2;
            ((Button)(sender)).BackColor = System.Drawing.SystemColors.ButtonShadow;
            ((Button)(sender)).Enabled = false;
            if (((Button)(sender)).Name == "MaleSelectionButton")
            {
                SetMaleProfilePictureOption();
            }
            else if (((Button)(sender)).Name == "FemaleSelectionButton")
            {
                SetFemaleProfilePictureOption();
            }
            else
            {
                SetAnimalProfilePictureOption();
            }
        }

        private void SaveTextButton_Click(object sender, EventArgs e)
        {
            if (ProfileStatusTextBox.ForeColor != Color.Silver)
                CurrentStatusLabel.Text = CurrentStatusLabel.Text.Substring(0, 16) + ProfileStatusTextBox.Text;
            //todo need to send the server the new status
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

        private void SaveProfilePictureButton_Click(object sender, EventArgs e)
        {
            //foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
            //{
            //    if ((AvatarProfilePicture != null) && (AvatarProfilePicture.BackColor == System.Drawing.SystemColors.ButtonShadow))
            //    {
            //        CurrentProfilePicturePictureBox.Image = AvatarProfilePicture.BackgroundImage;
            //        SaveProfilePictureButton.Enabled = false;
            //        //todo to sent to the server
            //        //todo to make sure it's possible to press the button just when a picture has been chosen, meaning when choosing a picture i need to unlock it and add an option to cancel the previous choice...
            //    }

            //}
            CurrentProfilePicturePictureBox.Image = ImageChosenAtTheMoment;
            SaveProfilePictureButton.Enabled = false;

        }

        private void PictureUploaderButton_Click(object sender, EventArgs e)
        {
            string ImageLocation = "";
            try
            {
                ProfilePictureOpenFileDialog.Filter = "jpg files(*.jpg)|*.jpg|PNG files (*.png)|*.png|All Files (*.*)|*.*";
                if (ProfilePictureOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ImageLocation = ProfilePictureOpenFileDialog.FileName;
                    ProfilePictureUploaderPictureBox.Image = Image.FromFile(ImageLocation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured");
            }

        }


        private void Profile_Load(object sender, EventArgs e)
        {
            MessageTextSizeComboBox.SelectedIndex = ServerCommunication.SelectedMessageTextSize;
        }


        private void PrivacySettingsOptionButtonCreator()
        {
            PrivacySettingsKindSelectionButtons = new Button[4];
            int y = 20;
            for (int i = 0; i < PrivacySettingsKindSelectionButtons.GetLength(0); i++)
            {
                PrivacySettingsKindSelectionButtons[i] = new Button();
                this.PrivacySettingsKindSelectionButtons[i].Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.PrivacySettingsKindSelectionButtons[i].Location = new System.Drawing.Point(10, y);
                this.PrivacySettingsKindSelectionButtons[i].Size = new System.Drawing.Size(100, 50);
                this.PrivacySettingsKindSelectionButtons[i].TabIndex = 16;
                this.PrivacySettingsKindSelectionButtons[i].UseVisualStyleBackColor = true;
                this.PrivacySettingsPanel.Controls.Add(this.PrivacySettingsKindSelectionButtons[i]);
                this.PrivacySettingsKindSelectionButtons[i].Click += new System.EventHandler(PrivacySettingsKindOption_Click);

                y += 70;
            }
            this.PrivacySettingsKindSelectionButtons[0].Name = "PrivacySettingsLastSeenSelectionButton";
            this.PrivacySettingsKindSelectionButtons[0].Text = "Last Seen"; //האם כדאי לעשות רשימה במקום ואז להגיד שהשם שווה לשם במיקום המסוים ברשימה
            this.PrivacySettingsKindSelectionButtons[1].Name = "PrivacySettingsOnlineSelectionButton";
            this.PrivacySettingsKindSelectionButtons[1].Text = "Online";
            this.PrivacySettingsKindSelectionButtons[2].Name = "PrivacySettingsProfilePictureSelectionButton";
            this.PrivacySettingsKindSelectionButtons[2].Text = "Profile Picture";
            this.PrivacySettingsKindSelectionButtons[3].Name = "PrivacySettingsStatusSelectionButton";
            this.PrivacySettingsKindSelectionButtons[3].Text = "Status";
        }

        private void ChatSettingsOptionButtonCreator()
        {
            ChatSettingsKindSelectionButtons = new Button[3];
            int y = 20;
            for (int i = 0; i < ChatSettingsKindSelectionButtons.GetLength(0); i++)
            {
                ChatSettingsKindSelectionButtons[i] = new Button();
                this.ChatSettingsKindSelectionButtons[i].Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ChatSettingsKindSelectionButtons[i].Location = new System.Drawing.Point(10, y);
                this.ChatSettingsKindSelectionButtons[i].Size = new System.Drawing.Size(100, 50);
                this.ChatSettingsKindSelectionButtons[i].TabIndex = 16;
                this.ChatSettingsKindSelectionButtons[i].UseVisualStyleBackColor = true;
                this.ChatSettingsPanel.Controls.Add(this.ChatSettingsKindSelectionButtons[i]);
                this.ChatSettingsKindSelectionButtons[i].Click += new System.EventHandler(ChatSettingsKindOption_Click);
                y += 70;
            }
            this.ChatSettingsKindSelectionButtons[0].Name = "ChatSettingsMessageGapSelectionButton";
            this.ChatSettingsKindSelectionButtons[0].Text = "Gap Between Messages"; 
            this.ChatSettingsKindSelectionButtons[1].Name = "ChatSettingsMessageTextSizeSelectionButton";
            this.ChatSettingsKindSelectionButtons[1].Text = "Text Size";
            this.ChatSettingsKindSelectionButtons[2].Name = "ChatSettingsEnterKeyPressedSelectionButton";
            this.ChatSettingsKindSelectionButtons[2].Text = "Enter Key Pressed";

        }
        private void ChatSettingsKindOption_Click(object sender, EventArgs e)
        {
            RestartChatSettingsKindSelection();
            ((Button)(sender)).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ((Button)(sender)).FlatAppearance.BorderColor = Color.Green;
            ((Button)(sender)).FlatAppearance.BorderSize = 2;
            ((Button)(sender)).BackColor = System.Drawing.SystemColors.ButtonShadow;
            ((Button)(sender)).Enabled = false;
            CurrentSelectedChatSettingsOption = ((Button)(sender)).Name;
            if (CurrentSelectedChatSettingsOption == "ChatSettingsMessageGapSelectionButton")
            {
                MessageGapScrollBar.Visible = true;
                MessageGapTextBox.Visible = true;
                MessageGapLabel.Visible = true;
                MessageTextSizeComboBox.Visible = false;
                EnterPressedLabel.Visible = false;
                EnterPressedToggleButton.Visible = false;
            }
            else if (CurrentSelectedChatSettingsOption == "ChatSettingsMessageTextSizeSelectionButton")
            {
                MessageGapScrollBar.Visible = false;
                MessageGapTextBox.Visible = false;
                MessageGapLabel.Visible = false;
                MessageTextSizeComboBox.Visible = true;
                EnterPressedLabel.Visible = false;
                EnterPressedToggleButton.Visible = false;
            }
            else
            {
                MessageGapScrollBar.Visible = false;
                MessageGapTextBox.Visible = false;
                MessageGapLabel.Visible = false;
                MessageTextSizeComboBox.Visible = false;
                EnterPressedLabel.Visible = true;
                EnterPressedToggleButton.Visible = true;

            }
        }

        private void PrivacySettingsKindOption_Click(object sender, EventArgs e)
        {
            RestartPrivacySettingsKindSelection();
            SetPrivacySettingsVisible();
            ((Button)(sender)).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ((Button)(sender)).FlatAppearance.BorderColor = Color.Green;
            ((Button)(sender)).FlatAppearance.BorderSize = 2;
            ((Button)(sender)).BackColor = System.Drawing.SystemColors.ButtonShadow;
            ((Button)(sender)).Enabled = false;
            CurrentSelectedPrivacySettingsOption = ((Button)(sender)).Name;
            if (CurrentSelectedPrivacySettingsOption == "PrivacySettingsLastSeenSelectionButton")
            {
                ContactsOptionRadioButton.Checked = PrivacySettingsChoicesArray[0];
                NobodyOptionRadioButton.Checked = !PrivacySettingsChoicesArray[0];

            }
            else if (CurrentSelectedPrivacySettingsOption == "PrivacySettingsOnlineSelectionButton")
            {
                ContactsOptionRadioButton.Checked = PrivacySettingsChoicesArray[1];
                NobodyOptionRadioButton.Checked = !PrivacySettingsChoicesArray[1];
            }
            else if (CurrentSelectedPrivacySettingsOption == "PrivacySettingsProfilePictureSelectionButton")
            {
                ContactsOptionRadioButton.Checked = PrivacySettingsChoicesArray[2];
                NobodyOptionRadioButton.Checked = !PrivacySettingsChoicesArray[2];
            }
            else
            {
                ContactsOptionRadioButton.Checked = PrivacySettingsChoicesArray[3];
                NobodyOptionRadioButton.Checked = !PrivacySettingsChoicesArray[3];
            }
            if (ContactsOptionRadioButton.Checked)
            {
                CurrentSelectedRadioButtonName = ContactsOptionRadioButton.Name;
            }
            else
            {
                CurrentSelectedRadioButtonName = NobodyOptionRadioButton.Name;

            }
        }

        private void RestartChatSettingsKindSelection()
        {
            foreach (Button ChatSettingsKindButton in ChatSettingsKindSelectionButtons)
            {
                ChatSettingsKindButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                ChatSettingsKindButton.UseVisualStyleBackColor = true;
                ChatSettingsKindButton.Enabled = true;
            }
        }

        private void RestartPrivacySettingsKindSelection()
        {
            foreach (Button PrivacySettingsKindButton in PrivacySettingsKindSelectionButtons)
            {
                PrivacySettingsKindButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                PrivacySettingsKindButton.UseVisualStyleBackColor = true;
                PrivacySettingsKindButton.Enabled = true;
            }
        }

        private void PrivacySettingsRadioButton_Click(object sender, EventArgs e)
        {
            if (StatusSelectionButton.Enabled) //for some reason the function get activted when the statusselectionbutton is pressed
            {
                if (CurrentSelectedRadioButtonName != ((RadioButton)(sender)).Name)
                {
                    if (CurrentSelectedPrivacySettingsOption == "PrivacySettingsLastSeenSelectionButton")
                    {

                        PrivacySettingsChoicesArray[0] = !PrivacySettingsChoicesArray[0];
                    }
                    else if (CurrentSelectedPrivacySettingsOption == "PrivacySettingsOnlineSelectionButton")
                    {
                        PrivacySettingsChoicesArray[1] = !PrivacySettingsChoicesArray[1];

                    }
                    else if (CurrentSelectedPrivacySettingsOption == "PrivacySettingsProfilePictureSelectionButton")
                    {
                        PrivacySettingsChoicesArray[2] = !PrivacySettingsChoicesArray[2];

                    }
                    else
                    {
                        PrivacySettingsChoicesArray[3] = !PrivacySettingsChoicesArray[3];
                    }
                    CurrentSelectedRadioButtonName = ((RadioButton)(sender)).Name;
                }
            }
        }
        int counter = 0;
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.Last)
                counter = 40;
            if (e.Type == ScrollEventType.First)
                counter = 10;
            if (e.Type == ScrollEventType.SmallDecrement)
                counter--;
            if (e.Type == ScrollEventType.SmallIncrement)
            {
                counter++;
            }
            if (e.Type == ScrollEventType.LargeDecrement)
                counter -= 5;
            if (e.Type == ScrollEventType.LargeIncrement)
            {
                counter += 5;
            }
            if (e.Type == ScrollEventType.First)
                counter = 10;
            if (e.Type == ScrollEventType.Last)
                counter = 100;

            if (counter > 100) counter = 40;
            if (counter < 10) counter = 10;
        }
        /// <summary>
        /// The "IsNumeric" method checks if "number" represents a number
        /// </summary>
        /// <param name="number"> Represents the board's size that the player has chosen</param>
        /// <returns> It returns true if all the characters in the string are numeric. OtherWise, it returns false </returns>

        string LastValue = "10";

        private void MessageGapTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((StringHandler.IsNumeric(MessageGapTextBox.Text)))
            {
                LastValue = MessageGapTextBox.Text;
            }
            else
            {
                MessageGapTextBox.Text = LastValue;
                MessageGapTextBox.Select(MessageGapTextBox.Text.Length, 0);

            }
        }

        private void MessageTextSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerCommunication.SelectedMessageTextSize = MessageTextSizeComboBox.SelectedIndex;
            //ServerCommunication.SendMessage();
            //this.Invoke(new Action(() => ServerCommunication.youChat.ChangeMessagesAppearance()));
            // אולי כדאי שבמקום להשתמש בפעולה הזאת יהיה כפתור של שמירה, והוא יוודא שהערך החדש שונה מהנוכחי, אם הוא לא אז לא יקרה כלום, ואם הוא כן שונה אז הערך הנוכחי ישתנה בהתאם והצאט ישנה את גודל הטקסט
            //לשנות לכל אחד מהכפתורים של ההודעות את הגודל בהתאם לגודל החדש אבל גם את המיקומים החדשים של ההודעות...
        }

        //private void MessageGapTextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if ((MessageGapTextBox.Text) != "" && (IsNumeric(MessageGapTextBox.Text)))
        //    {
        //        int Value = int.Parse(MessageGapTextBox.Text);
        //        if (Value < 10)
        //        {
        //            MessageGapScrollBar.Value = 10;
        //            MessageGapTextBox.Text = "10";
        //        }
        //        else if (Value > 40)
        //        {
        //            MessageGapScrollBar.Value = 40;
        //            MessageGapTextBox.Text = "40";
        //        }
        //        else
        //            MessageGapScrollBar.Value = Value;
        //        LastValue = MessageGapTextBox.Text;

        //    }
        //    else
        //    {
        //        MessageGapTextBox.Text = LastValue;
        //        MessageGapTextBox.Select(MessageGapTextBox.Text.Length, 0);

        //    }
        //}
        private void MessageGapTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MessageGapTextBox.Text != "")
                {
                    int Value = int.Parse(MessageGapTextBox.Text);
                    if (Value < 10)
                    {
                        MessageGapScrollBar.Value = 10;
                        MessageGapTextBox.Text = "10";
                        MessageGapTextBox.Select(MessageGapTextBox.Text.Length, 0);
                    }
                    else if (Value > 40)
                    {
                        MessageGapScrollBar.Value = 40;
                        MessageGapTextBox.Text = "40";
                        MessageGapTextBox.Select(MessageGapTextBox.Text.Length, 0);
                    }
                    else
                        MessageGapScrollBar.Value = Value;
                }
            }     
        }

        private void EnterPressedToggleButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SaveChatSettingsCustomButton_Click(object sender, EventArgs e)
        {
            JsonObject chatSettingsChangeJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.ChatSettingsChangeRequest, null);
            string chatSettingsChangeJson = JsonConvert.SerializeObject(chatSettingsChangeJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ServerCommunication.SendMessage(chatSettingsChangeJson);
        }
    }
}
