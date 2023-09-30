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
        string[] ImageChosenAtTheMomentId = new string[2];
        string CurrentImageIndex;
        string CurrentTypeOfProfilePicture = "";
        Boolean ProfilePictureMatrixIsStandart = true;
        Boolean FirstProfilePictureMatrixUpload = true;
        int StartedX = 30;
        bool UsedForInitialProfile = true;

        public event EventHandler ButtonClick;

        public string GetImageNameID()
        {
            CurrentImageIndex = GetIndexFromName(ImageChosenAtTheMomentId[1]).ToString();
            return ImageChosenAtTheMomentId[0].Substring(0, ImageChosenAtTheMomentId[0].Length - "SelectionButton".Length) + CurrentImageIndex;
        }

        public ProfilePictureControl()
        {
            InitializeComponent();
            ProfilePictureImageList.InitializeImageLists(); //todo - does it nessery if i did it before in another form - need to check...
            ProfilePictureKindButtonsCreator();
            SetProfileAvatarMatrix();

        }
        private void ProfilePictureKindButtonsCreator()
        {
            ProfilePictureKindSelectionButtons = new Button[3];
            int x = StartedX;
            for (int i = 0; i < ProfilePictureKindSelectionButtons.GetLength(0); i++)
            {
                ProfilePictureKindSelectionButtons[i] = new Button();
                this.ProfilePictureKindSelectionButtons[i].Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ProfilePictureKindSelectionButtons[i].Location = new System.Drawing.Point(x, 10);
                this.ProfilePictureKindSelectionButtons[i].Size = new System.Drawing.Size(120, 35);
                this.ProfilePictureKindSelectionButtons[i].TabIndex = 16;
                this.ProfilePictureKindSelectionButtons[i].UseVisualStyleBackColor = true;
                this.Controls.Add(this.ProfilePictureKindSelectionButtons[i]);
                this.ProfilePictureKindSelectionButtons[i].Click += new System.EventHandler(ProfilePictureKindOption_Click);

                x += 150;
            }
            this.ProfilePictureKindSelectionButtons[0].Name = "MaleSelectionButton";
            this.ProfilePictureKindSelectionButtons[0].Text = "Male Icons";
            this.ProfilePictureKindSelectionButtons[1].Name = "FemaleSelectionButton";
            this.ProfilePictureKindSelectionButtons[1].Text = "Female Icons";
            this.ProfilePictureKindSelectionButtons[2].Name = "AnimalSelectionButton";
            this.ProfilePictureKindSelectionButtons[2].Text = "Animal Icons";
        }

        private void SetProfileAvatarMatrix()
        {
            ProfileAvatarMatrix = new Button[6, 5];
            int x = 30, y = 60;
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
                        this.Controls.Add(this.ProfileAvatarMatrix[i, j]);
                        this.ProfileAvatarMatrix[i, j].Click += new System.EventHandler(ProfilePictureOption_Click);
                    }
                    x += 85;
                }
                x = 30;
                y += 85;
            }
        }
        private int GetIndexFromName(string Name)
        {
            string[] NameParts = Name.Split(',');
            string rowAsString = NameParts[0];
            string columnAsString = NameParts[1];
            int row = int.Parse(rowAsString);
            int column = int.Parse(columnAsString);
            int lastRow = ProfileAvatarMatrix.GetLength(0) - 1;
            int index = (row * ProfileAvatarMatrix.GetLength(1)) + column;
            if (row == lastRow)
            {
                index -= 1;
            }
            return index;
        }
        private void ProfilePictureOption_Click(object sender, EventArgs e)
        {
            Boolean wasCurrentlyChosen = false;
            if (((Button)(sender)).FlatStyle == System.Windows.Forms.FlatStyle.Flat)
            {
                wasCurrentlyChosen = true;
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
                ImageChosenAtTheMomentId[0] = CurrentTypeOfProfilePicture;
                ImageChosenAtTheMomentId[1] = ((Button)(sender)).Name;
                if (UsedForInitialProfile)
                {
                    //this.Invoke(new Action(() => InitialProfileSelection.SetConfirmButtonEnabledToTrue())); //need to change the enabled of confirmbutton on form...

                }
            }
            else
            {
                ImageChosenAtTheMoment =null;
                ImageChosenAtTheMomentId[0] = "";
                ImageChosenAtTheMomentId[1] = "";
                if (UsedForInitialProfile)
                {
                    //this.Invoke(new Action(() => InitialProfileSelection.SetConfirmButtonEnabledToFalse()));

                }
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
                    if (ProfilePictureImageList.FemaleProfilePictureImageList.Images.Count > location)
                    {
                        AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.FemaleProfilePictureImageList.Images[location];
                        //AvatarProfilePicture.BackgroundImage = FemaleImageList.Images[location];
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
            int LastRow = ProfileAvatarMatrix.GetLength(0) - 1;
            string lastRowAsString = LastRow.ToString();
            Boolean wasChanged = false;

            foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
            {
                if (AvatarProfilePicture != null)
                {
                    if (ProfilePictureImageList.AnimalProfilePictureImageList.Images.Count > location)
                    {
                        AvatarProfilePicture.BackgroundImage = ProfilePictureImageList.AnimalProfilePictureImageList.Images[location];

                        //AvatarProfilePicture.BackgroundImage = AnimalImageList.Images[location];

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
            ((Button)(sender)).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ((Button)(sender)).FlatAppearance.BorderColor = Color.Green;
            ((Button)(sender)).FlatAppearance.BorderSize = 2;
            ((Button)(sender)).BackColor = System.Drawing.SystemColors.ButtonShadow;
            ((Button)(sender)).Enabled = false;
            CurrentTypeOfProfilePicture = ((Button)(sender)).Name;
            if (CurrentTypeOfProfilePicture == "MaleSelectionButton")
            {
                SetMaleProfilePictureOption();
            }
            else if (CurrentTypeOfProfilePicture == "FemaleSelectionButton")
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
            foreach (Button AvatarProfilePicture in ProfileAvatarMatrix)
            {
                if (AvatarProfilePicture != null)
                {
                    AvatarProfilePicture.Visible = true;
                }
            }
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
        private void RestartProfilePicture()
        {
            foreach (Button ProfilePicture in ProfileAvatarMatrix)
            {
                if (ProfilePicture != null)
                {
                    ProfilePicture.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                    ProfilePicture.UseVisualStyleBackColor = true;
                    ProfilePicture.Enabled = true;
                }
            }
        }
        private void ImageWasChosen()
        {
            if (CurrentTypeOfProfilePicture == ImageChosenAtTheMomentId[0])
            {
                foreach (Button ProfilePicture in ProfileAvatarMatrix)
                {
                    if (ProfilePicture != null)
                    {
                        if (ProfilePicture.Name == ImageChosenAtTheMomentId[1])
                        {
                            ProfilePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                            ProfilePicture.FlatAppearance.BorderColor = Color.Green;
                            ProfilePicture.FlatAppearance.BorderSize = 2;
                            ProfilePicture.BackColor = System.Drawing.SystemColors.ButtonShadow;
                        }
                    }
                }
            }
           
        }
    }
}
