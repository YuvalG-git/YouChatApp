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
            ServerCommunication.BeginRead();
            ProfilePictureImageList.InitializeImageLists(); //todo - does it nessery if i did it before in another form - need to check...
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
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
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

        //private void ProfilePictureKindButtonsCreator()
        //{
        //    ProfilePictureKindSelectionButtons = new Button[3];
        //    int x = 250;
        //    for (int i = 0; i < ProfilePictureKindSelectionButtons.GetLength(0); i++)
        //    {
        //        ProfilePictureKindSelectionButtons[i] = new Button();
        //        this.ProfilePictureKindSelectionButtons[i].Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        this.ProfilePictureKindSelectionButtons[i].Location = new System.Drawing.Point(x, 10);
        //        this.ProfilePictureKindSelectionButtons[i].Size = new System.Drawing.Size(120, 35);
        //        this.ProfilePictureKindSelectionButtons[i].TabIndex = 16;
        //        this.ProfilePictureKindSelectionButtons[i].UseVisualStyleBackColor = true;
        //        this.ProfilePictureGroupBox.Controls.Add(this.ProfilePictureKindSelectionButtons[i]);
        //        this.ProfilePictureKindSelectionButtons[i].Click += new System.EventHandler(ProfilePictureKindOption_Click);

        //        x += 150;
        //    }
        //    this.ProfilePictureKindSelectionButtons[0].Name = "MaleSelectionButton";
        //    this.ProfilePictureKindSelectionButtons[0].Text = "Male Icons"; //האם כדאי לעשות רשימה במקום ואז להגיד שהשם שווה לשם במיקום המסוים ברשימה
        //    this.ProfilePictureKindSelectionButtons[1].Name = "FemaleSelectionButton";
        //    this.ProfilePictureKindSelectionButtons[1].Text = "Female Icons";
        //    this.ProfilePictureKindSelectionButtons[2].Name = "AnimalSelectionButton";
        //    this.ProfilePictureKindSelectionButtons[2].Text = "Animal Icons";
        //}

        //private void SetProfileAvatarMatrix()
        //{
        //    ProfileAvatarMatrix = new Button[6, 5];
        //    int x = 220, y = 60;
        //    for (int i = 0; i < ProfileAvatarMatrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < ProfileAvatarMatrix.GetLength(1); j++)
        //        {
        //            if (!((i == ProfileAvatarMatrix.GetLength(0) - 1) && ((j == 0) || (j == ProfileAvatarMatrix.GetLength(1) - 1))))
        //            {
        //                string name = i.ToString() + "," + j.ToString();
        //                ProfileAvatarMatrix[i, j] = new System.Windows.Forms.Button();
        //                this.ProfileAvatarMatrix[i, j].Location = new System.Drawing.Point(x, y);
        //                this.ProfileAvatarMatrix[i, j].Name = name;
        //                this.ProfileAvatarMatrix[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177))); ;
        //                this.ProfileAvatarMatrix[i, j].Size = new System.Drawing.Size(75, 75);
        //                this.ProfileAvatarMatrix[i, j].TabIndex = 0;
        //                this.ProfileAvatarMatrix[i, j].Text = "";
        //                this.ProfileAvatarMatrix[i, j].BackColor = SystemColors.Control;
        //                this.ProfileAvatarMatrix[i, j].UseVisualStyleBackColor = true;
        //                this.ProfileAvatarMatrix[i, j].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        //                this.ProfileAvatarMatrix[i, j].Visible = false;

        //                //this.ProfileAvatarMatrix[i, j].BackgroundImage = MaleImages.Dequeue();
        //                //this.ProfileAvatarMatrix[i, j].BackgroundImage = MaleImageList.Images[i];
        //                this.Controls.Add(this.ProfileAvatarMatrix[i, j]);
        //                this.ProfilePictureGroupBox.Controls.Add(this.ProfileAvatarMatrix[i, j]);
        //                this.ProfileAvatarMatrix[i, j].Click += new System.EventHandler(ProfilePictureOption_Click);
        //            }
        //            x += 85;
        //        }
        //        x = 220;
        //        y += 85;
        //    }
        //}
        //private void ProfilePictureOption_Click(object sender, EventArgs e)
        //{
        //    Boolean wasCurrentlyChosen = false;
        //    if (((Button)(sender)).FlatStyle == System.Windows.Forms.FlatStyle.Flat)
        //    {
        //        wasCurrentlyChosen = true;
        //        SaveProfilePictureButton.Enabled = false;
        //    }
        //    foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
        //    {
        //        if (AvatarProfilePicture != null)
        //        {
        //            AvatarProfilePicture.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        //            AvatarProfilePicture.UseVisualStyleBackColor = true;
        //        }
        //    }//לחשוב אם אני רוצה לאחר אישור התמונה להעלים את הבחירה בתמונה (במקרה כזה להעתיק את קטע הקוד הזה ולהעביר אותו לפעולה) ואז לזמן את הפעולה גם כאן וגם לאחר לחיצה על כפתור האישור
        //    // אחרת לדאוג שמלכתחילה שפותחים את החלון, תמונת הפרופיל הנוכחית מופיעה מיוחד...
        //    if (!wasCurrentlyChosen)
        //    {
        //        ((Button)(sender)).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //        ((Button)(sender)).FlatAppearance.BorderColor = Color.Green;
        //        ((Button)(sender)).FlatAppearance.BorderSize = 2;
        //        ((Button)(sender)).BackColor = System.Drawing.SystemColors.ButtonShadow;
        //        ImageChosenAtTheMoment = ((Button)(sender)).BackgroundImage;
        //        SaveProfilePictureButton.Enabled = true;

        //    }
        //}

        //private void SetMaleProfilePictureOption()
        //{
        //    int location = 0;
        //    int LastRow = ProfileAvatarMatrix.GetLength(0) - 1;
        //    string lastRowAsString = LastRow.ToString();
        //    Boolean wasChanged = false;
        //    foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
        //    {
        //        if (AvatarProfilePicture != null)
        //        {
        //            AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.MaleProfilePictureImageList.Images[location];
        //            //AvatarProfilePicture.BackgroundImage = MaleImageList.Images[location];
        //            location++;
        //            if ((!ProfilePictureMatrixIsStandart) && (AvatarProfilePicture.Name.StartsWith(lastRowAsString)))
        //            {
        //                wasChanged = true;
        //                if (AvatarProfilePicture.Name.EndsWith("3"))
        //                {
        //                    AvatarProfilePicture.Visible = true;
        //                }
        //                else
        //                {
        //                    AvatarProfilePicture.Location = new System.Drawing.Point(AvatarProfilePicture.Location.X - 41, AvatarProfilePicture.Location.Y);
        //                }
        //            }
        //        }
        //    }
        //    if (wasChanged)
        //        ProfilePictureMatrixIsStandart = true;

        //}

        //private void SetFemaleProfilePictureOption()
        //{
        //    int location = 0;
        //    int LastRow = ProfileAvatarMatrix.GetLength(0) - 1;
        //    string lastRowAsString = LastRow.ToString();
        //    Boolean wasChanged = false;
        //    foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
        //    {
        //        if (AvatarProfilePicture != null)
        //        {
        //            if (FemaleImageList.Images.Count > location)
        //            {
        //                AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.FemaleProfilePictureImageList.Images[location];
        //                //AvatarProfilePicture.BackgroundImage = FemaleImageList.Images[location];
        //                location++;
        //                if ((ProfilePictureMatrixIsStandart) && (AvatarProfilePicture.Name.StartsWith(lastRowAsString)))
        //                {
        //                    //if (AvatarProfilePicture.Name.EndsWith("3"))
        //                    //{
        //                    //    AvatarProfilePicture.Visible = false;
        //                    //    AvatarProfilePicture.BackgroundImage = null;

        //                    //}
        //                    //else
        //                    //{
        //                    //    AvatarProfilePicture.Location = new System.Drawing.Point(AvatarProfilePicture.Location.X  + 41, AvatarProfilePicture.Location.Y);
        //                    //}
        //                    wasChanged = true;
        //                    AvatarProfilePicture.Location = new System.Drawing.Point(AvatarProfilePicture.Location.X + 41, AvatarProfilePicture.Location.Y);
        //                }
        //            }
        //            else if (ProfilePictureMatrixIsStandart)
        //            {
        //                AvatarProfilePicture.Visible = false;
        //            }
        //        }
        //    }
        //    if (wasChanged)
        //        ProfilePictureMatrixIsStandart = false;
        //}
        //private void SetAnimalProfilePictureOption()
        //{
        //    int location = 0;
        //    int LastRow = ProfileAvatarMatrix.GetLength(0) - 1;
        //    string lastRowAsString = LastRow.ToString();
        //    Boolean wasChanged = false;

        //    foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
        //    {
        //        if (AvatarProfilePicture != null)
        //        {
        //            if (AnimalImageList.Images.Count > location)
        //            {
        //                AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.AnimalProfilePictureImageList.Images[location];

        //                //AvatarProfilePicture.BackgroundImage = AnimalImageList.Images[location];

        //                location++;
        //                if ((ProfilePictureMatrixIsStandart) && (AvatarProfilePicture.Name.StartsWith(lastRowAsString)))
        //                {
        //                    wasChanged = true;
        //                    AvatarProfilePicture.Location = new System.Drawing.Point(AvatarProfilePicture.Location.X + 41, AvatarProfilePicture.Location.Y);
        //                }
        //            }
        //            else if (ProfilePictureMatrixIsStandart)
        //            {
        //                AvatarProfilePicture.Visible = false;
        //            }
        //        }
        //    }
        //    if (wasChanged)
        //        ProfilePictureMatrixIsStandart = false;
        //}

        //private void ProfilePictureKindOption_Click(object sender, EventArgs e)
        //{
        //    if (FirstProfilePictureMatrixUpload)
        //    {
        //        FirstProfilePictureMatrixUpload = false;
        //        SetProfilePictrueMatrixVisible();
        //    }
        //    RestartProfilePictureSelection();
        //    ((Button)(sender)).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //    ((Button)(sender)).FlatAppearance.BorderColor = Color.Green;
        //    ((Button)(sender)).FlatAppearance.BorderSize = 2;
        //    ((Button)(sender)).BackColor = System.Drawing.SystemColors.ButtonShadow;
        //    ((Button)(sender)).Enabled = false;
        //    if (((Button)(sender)).Name == "MaleSelectionButton")
        //    {
        //        SetMaleProfilePictureOption();
        //    }
        //    else if (((Button)(sender)).Name == "FemaleSelectionButton")
        //    {
        //        SetFemaleProfilePictureOption();
        //    }
        //    else
        //    {
        //        SetAnimalProfilePictureOption();
        //    }
        //}

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (ProfilePictureGroupBox.Visible)
            {
                string ProfilePictureId = ProfilePictureControl.GetImageNameID();
                //ServerCommunication.SendMessage(ServerCommunication.UploadProfilePictureRequest + "$" + ProfilePictureId);

                ServerCommunication.SendMessage(ServerCommunication.UploadProfilePictureRequest, ProfilePictureId);
            }
            else
            {
                string ProfileStatus = ProfileStatusTextBox.Text;
                //ServerCommunication.SendMessage(ServerCommunication.UploadStatusRequest + "$" + ProfileStatus);

                ServerCommunication.SendMessage(ServerCommunication.UploadStatusRequest, ProfileStatus);
            }
        }
        public void OpenApp()
        {
            this.Hide();
            ServerCommunication.youChat = new YouChat();
            this.Invoke(new Action(() => ServerCommunication.youChat.ShowDialog()));
        }

        private void SetPhaseOne()
        {
            ProfilePictureGroupBox.Visible = true;
            StatusGroupBox.Visible = false;
            ProfileSettingsHeadlineLabel.Text = "Profile Picture";
        }
        public void SetPhaseTwo()
        {
            ProfilePictureGroupBox.Visible = false;
            StatusGroupBox.Visible = true;
            ProfileSettingsHeadlineLabel.Text = "Status";

        }

        private void ProfilePictureControl_Click(object sender, EventArgs e) //how to do it?
        {
            if (ProfilePictureControl.ImageChosenAtTheMoment != null)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;

            }
        }
        public void SetConfirmButtonEnabled(object sender, EventArgs e)
        {
            if (ProfilePictureControl.ImageChosenAtTheMoment != null)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;

            }
        }
        public void SetConfirmButtonEnabledToFalse()
        {
            ConfirmButton.Enabled = false;
        }
        public void SetConfirmButtonEnabledToTrue()
        {
            ConfirmButton.Enabled = true;
        }
    }
}
