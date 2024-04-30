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
    public partial class ProfilePictureControl : UserControl
    {
        public Image ImageChosenAtTheMoment { get; private set; }
        private string[] ImageChosenAtTheMomentId = new string[2];
        private string CurrentImageIndex;
        private string CurrentTypeOfProfilePicture = "";
        private bool ProfilePictureMatrixIsStandart = true;
        private Boolean FirstProfilePictureMatrixUpload = true;
        private const int StartedX = 30;
        private bool UsedForInitialProfile = true;

        public event EventHandler ButtonClick;

        public string GetImageNameID()
        {
            CurrentImageIndex = GetIndexFromName(ImageChosenAtTheMomentId[1]).ToString();
            return ImageChosenAtTheMomentId[0].Substring(0, ImageChosenAtTheMomentId[0].Length - "SelectionCustomButton".Length) + CurrentImageIndex;
        }

        public ProfilePictureControl()
        {
            InitializeComponent();
            ProfilePictureKindCustomButtonsCreator();
            SetProfileAvatarMatrix();
        }
        private void ProfilePictureKindCustomButtonsCreator()
        {
            ProfilePictureKindSelectionCustomButtons = new CustomButton[3];
            int x = StartedX;
            int widthSize = 150;
            for (int i = 0; i < ProfilePictureKindSelectionCustomButtons.GetLength(0); i++)
            {
                ProfilePictureKindSelectionCustomButtons[i] = new CustomButton();
                this.ProfilePictureKindSelectionCustomButtons[i].BackColor = System.Drawing.Color.MediumSlateBlue;
                this.ProfilePictureKindSelectionCustomButtons[i].BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                this.ProfilePictureKindSelectionCustomButtons[i].BorderColor = System.Drawing.Color.Green;
                this.ProfilePictureKindSelectionCustomButtons[i].BorderRadius = 10;
                this.ProfilePictureKindSelectionCustomButtons[i].BorderSize = 0;
                this.ProfilePictureKindSelectionCustomButtons[i].Circular = false;
                this.ProfilePictureKindSelectionCustomButtons[i].FlatAppearance.BorderSize = 0;
                this.ProfilePictureKindSelectionCustomButtons[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.ProfilePictureKindSelectionCustomButtons[i].Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ProfilePictureKindSelectionCustomButtons[i].ForeColor = System.Drawing.Color.White;
                this.ProfilePictureKindSelectionCustomButtons[i].Location = new System.Drawing.Point(x, 50);
                this.ProfilePictureKindSelectionCustomButtons[i].Size = new System.Drawing.Size(widthSize, 40);
                this.ProfilePictureKindSelectionCustomButtons[i].TabIndex = 41;
                this.ProfilePictureKindSelectionCustomButtons[i].TextColor = System.Drawing.Color.White;
                this.ProfilePictureKindSelectionCustomButtons[i].UseVisualStyleBackColor = false;
                this.Controls.Add(this.ProfilePictureKindSelectionCustomButtons[i]);
                this.ProfilePictureKindSelectionCustomButtons[i].Click += new System.EventHandler(ProfilePictureKindOption_Click);
                x += widthSize + 30;
            }
            this.ProfilePictureKindSelectionCustomButtons[0].Name = "MaleSelectionCustomButton";
            this.ProfilePictureKindSelectionCustomButtons[0].Text = "Male Icons";
            this.ProfilePictureKindSelectionCustomButtons[1].Name = "FemaleSelectionCustomButton";
            this.ProfilePictureKindSelectionCustomButtons[1].Text = "Female Icons";
            this.ProfilePictureKindSelectionCustomButtons[2].Name = "AnimalSelectionCustomButton";
            this.ProfilePictureKindSelectionCustomButtons[2].Text = "Animal Icons";
        }

        private void SetProfileAvatarMatrix()
        {
            ProfileAvatarMatrixOfCustomButtons = new CustomButton[6, 5];
            int size = 75;
            int ProfileAvatarMatrixOfCustomButtonsXCoordinateLength = ProfileAvatarMatrixOfCustomButtons.GetLength(1);
            int xConstant = (this.Width - (size * ProfileAvatarMatrixOfCustomButtonsXCoordinateLength) - (10 * (ProfileAvatarMatrixOfCustomButtonsXCoordinateLength - 1))) / 2;
            int x = xConstant, y = ProfilePictureKindSelectionCustomButtons[0].Height + ProfilePictureKindSelectionCustomButtons[0].Location.Y + 10; 
            for (int i = 0; i < ProfileAvatarMatrixOfCustomButtons.GetLength(0); i++)
            {
                for (int j = 0; j < ProfileAvatarMatrixOfCustomButtonsXCoordinateLength; j++)
                {
                    if (!((i == ProfileAvatarMatrixOfCustomButtons.GetLength(0) - 1) && ((j == 0) || (j == ProfileAvatarMatrixOfCustomButtonsXCoordinateLength - 1))))
                    {
                        string name = i.ToString() + "," + j.ToString();
                        ProfileAvatarMatrixOfCustomButtons[i, j] = new CustomButton();
                        this.ProfileAvatarMatrixOfCustomButtons[i,j].BackColor = SystemColors.ButtonShadow;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].BackgroundColor = SystemColors.ButtonShadow;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].BorderColor = System.Drawing.Color.Green;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].BorderRadius = 10;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].BorderSize = 0;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].Circular = false;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].Enabled = false;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].Name = name;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].Text = "";
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].Visible = false;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].FlatAppearance.BorderSize = 0;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].ForeColor = System.Drawing.Color.White;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].Location = new System.Drawing.Point(x, y);
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].Size = new System.Drawing.Size(size, size);
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].TabIndex = 0;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].TextColor = System.Drawing.Color.White;
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].UseVisualStyleBackColor = false;
                        this.Controls.Add(this.ProfileAvatarMatrixOfCustomButtons[i, j]);
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].Click += new System.EventHandler(ProfilePictureOption_Click);
                    }
                    x += size + 10;
                }
                x = xConstant;
                y += size + 10;
            }
        }
        private int GetIndexFromName(string Name)
        {
            string[] NameParts = Name.Split(',');
            string rowAsString = NameParts[0];
            string columnAsString = NameParts[1];
            int row = int.Parse(rowAsString);
            int column = int.Parse(columnAsString);
            int lastRow = ProfileAvatarMatrixOfCustomButtons.GetLength(0) - 1;
            int index = (row * ProfileAvatarMatrixOfCustomButtons.GetLength(1)) + column;
            if (row == lastRow)
            {
                index -= 1;
            }
            return index;
        }
        private void ProfilePictureOption_Click(object sender, EventArgs e)
        {
            bool wasCurrentlyChosen = false;
            CustomButton currentButton = sender as CustomButton;
            if (currentButton.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
            {
                wasCurrentlyChosen = true;
            }
            foreach (CustomButton AvatarProfilePicture in ProfileAvatarMatrixOfCustomButtons)
            {
                if (AvatarProfilePicture != null)
                {
                    AvatarProfilePicture.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                    AvatarProfilePicture.UseVisualStyleBackColor = true;
                    AvatarProfilePicture.BorderSize = 0;
                }
            }
            if (!wasCurrentlyChosen)
            {
                currentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                currentButton.BorderColor = System.Drawing.Color.Green;
                currentButton.BorderSize = 3;
                currentButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
                currentButton.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;

                ImageChosenAtTheMoment = currentButton.BackgroundImage;
                ImageChosenAtTheMomentId[0] = CurrentTypeOfProfilePicture;
                ImageChosenAtTheMomentId[1] = currentButton.Name;
            }
            else
            {
                ImageChosenAtTheMoment = null;
                ImageChosenAtTheMomentId[0] = "";
                ImageChosenAtTheMomentId[1] = "";
            }
            ButtonClick?.Invoke(this, e);
        }
        public void AddButtonClickHandler(EventHandler handler)
        {
            ButtonClick += handler;
        }

        private void SetMaleProfilePictureOption()
        {
            int location = 0;
            int LastRow = ProfileAvatarMatrixOfCustomButtons.GetLength(0) - 1;
            string lastRowAsString = LastRow.ToString();
            bool wasChanged = false;
            foreach (CustomButton AvatarProfilePicture in ProfileAvatarMatrixOfCustomButtons)
            {
                if (AvatarProfilePicture != null)
                {
                    AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.MaleProfilePictureImageList.Images[location];
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
            int LastRow = ProfileAvatarMatrixOfCustomButtons.GetLength(0) - 1;
            string lastRowAsString = LastRow.ToString();
            bool wasChanged = false;
            foreach (CustomButton AvatarProfilePicture in ProfileAvatarMatrixOfCustomButtons)
            {
                if (AvatarProfilePicture != null)
                {
                    if (ProfilePictureImageList.FemaleProfilePictureImageList.Images.Count > location)
                    {
                        AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.FemaleProfilePictureImageList.Images[location];
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
        private void SetAnimalProfilePictureOption()
        {
            int location = 0;
            int LastRow = ProfileAvatarMatrixOfCustomButtons.GetLength(0) - 1;
            string lastRowAsString = LastRow.ToString();
            bool wasChanged = false;
            foreach (CustomButton AvatarProfilePicture in ProfileAvatarMatrixOfCustomButtons)
            {
                if (AvatarProfilePicture != null)
                {
                    if (ProfilePictureImageList.AnimalProfilePictureImageList.Images.Count > location)
                    {
                        AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.AnimalProfilePictureImageList.Images[location];
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

        private void ProfilePictureKindOption_Click(object sender, EventArgs e)
        {
            if (FirstProfilePictureMatrixUpload)
            {
                FirstProfilePictureMatrixUpload = false;
                SetProfilePictrueMatrixVisible();
            }
            RestartProfilePictureSelection();
            CustomButton currentButton = sender as CustomButton;
            currentButton.BorderSize = 3;
            currentButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            currentButton.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            currentButton.Enabled = false;
            CurrentTypeOfProfilePicture = currentButton.Name;
            if (CurrentTypeOfProfilePicture == "MaleSelectionCustomButton")
            {
                SetMaleProfilePictureOption();
            }
            else if (CurrentTypeOfProfilePicture == "FemaleSelectionCustomButton")
            {
                SetFemaleProfilePictureOption();
            }
            else
            {
                SetAnimalProfilePictureOption();
            }
            RestartProfilePicture();
            if (ImageChosenAtTheMoment != null)
            {
                ImageWasChosen();
            }
        }

        private void SetProfilePictrueMatrixVisible()
        {
            foreach (CustomButton AvatarProfilePicture in ProfileAvatarMatrixOfCustomButtons)
            {
                if (AvatarProfilePicture != null)
                {
                    AvatarProfilePicture.Visible = true;
                }
            }
        }

        private void RestartProfilePictureSelection()
        {
            foreach (CustomButton ProfilePictureKind in ProfilePictureKindSelectionCustomButtons)
            {
                ProfilePictureKind.BorderSize = 0;
                ProfilePictureKind.BackColor = System.Drawing.Color.MediumSlateBlue;
                ProfilePictureKind.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                ProfilePictureKind.Enabled = true;
            }
        }
        private void RestartProfilePicture()
        {
            foreach (CustomButton ProfilePicture in ProfileAvatarMatrixOfCustomButtons)
            {
                if (ProfilePicture != null)
                {
                    ProfilePicture.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                    ProfilePicture.UseVisualStyleBackColor = true;
                    ProfilePicture.BorderSize = 0;
                    ProfilePicture.Enabled = true;
                }
            }
        }
        private void ImageWasChosen()
        {
            if (CurrentTypeOfProfilePicture == ImageChosenAtTheMomentId[0])
            {
                foreach (CustomButton ProfilePicture in ProfileAvatarMatrixOfCustomButtons)
                {
                    if (ProfilePicture != null)
                    {
                        if (ProfilePicture.Name == ImageChosenAtTheMomentId[1])
                        {
                            ProfilePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                            ProfilePicture.BorderColor = System.Drawing.Color.Green;
                            ProfilePicture.BorderSize = 3;
                            ProfilePicture.BackColor = System.Drawing.SystemColors.ButtonShadow;
                            ProfilePicture.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
                        }
                    }
                }
            }
        }
    }
}
