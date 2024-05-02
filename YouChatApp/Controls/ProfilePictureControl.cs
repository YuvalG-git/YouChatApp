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
    /// <summary>
    /// The "ProfilePictureControl" class represents a user control for selecting and displaying profile pictures.
    /// </summary>
    /// <remarks>
    /// This control provides functionality for selecting a profile picture from a file or camera and displaying it.
    /// It includes methods for capturing an image from a camera and loading an image from a file.
    /// The control also allows the user to crop and resize the selected image before setting it as the profile picture.
    /// </remarks>
    public partial class ProfilePictureControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "ButtonClick" event is raised when a profile picture option is clicked.
        /// </summary>
        public event EventHandler ButtonClick;

        #endregion

        #region Private Fields

        /// <summary>
        /// The Image "imageChosenAtTheMoment" represents the currently chosen image.
        /// </summary>
        private Image imageChosenAtTheMoment;

        /// <summary>
        /// The string array "ImageChosenAtTheMomentId" stores the IDs of the currently chosen images.
        /// </summary>
        private string[] ImageChosenAtTheMomentId = new string[2];

        /// <summary>
        /// The string "CurrentImageIndex" represents the index of the current image.
        /// </summary>
        private string CurrentImageIndex;

        /// <summary>
        /// The string "CurrentTypeOfProfilePicture" represents the current type of profile picture.
        /// </summary>
        private string CurrentTypeOfProfilePicture = "";

        /// <summary>
        /// The bool "ProfilePictureMatrixIsStandart" indicates whether the profile picture matrix is standard.
        /// </summary>
        private bool ProfilePictureMatrixIsStandart = true;

        /// <summary>
        /// The bool "FirstProfilePictureMatrixUpload" indicates whether it's the first profile picture matrix upload.
        /// </summary>
        private bool FirstProfilePictureMatrixUpload = true;

        #endregion

        #region Private Const Fields

        /// <summary>
        /// The const int "StartedX" represents the starting X coordinate.
        /// </summary>
        private const int StartedX = 30;

        #endregion

        #region Constructors

        /// <summary>
        /// The "ProfilePictureControl" constructor initializes a new instance of the <see cref="ProfilePictureControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the ProfilePictureControl by initializing the component and creating the profile picture kind custom buttons.
        /// It also sets the profile avatar matrix for displaying different profile picture options.
        /// </remarks>
        public ProfilePictureControl()
        {
            InitializeComponent();
            ProfilePictureKindCustomButtonsCreator();
            SetProfileAvatarMatrix();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "ImageChosenAtTheMoment" property represents the image currently chosen.
        /// It gets the image currently chosen.
        /// </summary>
        /// <value>
        /// The image currently chosen.
        /// </value>
        public Image ImageChosenAtTheMoment
        {
            get
            {
                return imageChosenAtTheMoment;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "ProfilePictureKindCustomButtonsCreator" method dynamically creates custom buttons for selecting different kinds of profile pictures.
        /// </summary>
        /// <remarks>
        /// This method is responsible for creating custom buttons that visually represent the available options for users to select when setting or updating their profile picture.
        /// It iterates through each button in the array of custom buttons and sets various properties, such as background color, border color, font style, and text color, to ensure a visually appealing design.
        /// Each button is positioned horizontally with a specified width, and a consistent spacing is maintained between buttons to improve readability and user interaction.
        /// Event handling is implemented to capture user clicks on the custom buttons. When a button is clicked, an event handler function is triggered to handle the selection logic, allowing the user to interactively choose the desired profile picture kind.
        /// Overall, the "ProfilePictureKindCustomButtonsCreator" method enhances the user experience by providing an intuitive and visually appealing interface for selecting profile picture kinds.
        /// </remarks>
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

        /// <summary>
        /// The "SetProfileAvatarMatrix" method dynamically creates a matrix of custom buttons for selecting profile avatars.
        /// </summary>
        /// <remarks>
        /// This method initializes a two-dimensional array of custom buttons to represent the profile avatar selection grid.
        /// It calculates the starting position and spacing for the buttons based on the form's width and the button size.
        /// The method then iterates through each row and column of the button matrix, excluding the corners, and creates a custom button for each cell.
        /// Each button is styled to have a shadow background, green border, rounded corners, and an image zoom layout.
        /// The buttons are disabled, invisible, and have no text initially.
        /// Event handling is implemented to capture user clicks on the buttons, triggering the "ProfilePictureOption_Click" event handler.
        /// Overall, the "SetProfileAvatarMatrix" method enhances the user interface by providing an interactive grid for selecting profile avatars.
        /// </remarks>
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
                        this.ProfileAvatarMatrixOfCustomButtons[i, j].BackColor = SystemColors.ButtonShadow;
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

        /// <summary>
        /// The "GetIndexFromName" method calculates the index of a custom button in the profile avatar matrix based on its name.
        /// </summary>
        /// <param name="Name">The name of the custom button in the format "row,column".</param>
        /// <returns>The index of the custom button in the flattened matrix representation.</returns>
        /// <remarks>
        /// This method parses the row and column numbers from the given name string, which is in the format "row,column".
        /// It then calculates the index of the custom button in the flattened matrix representation by multiplying the row number with the number of columns and adding the column number.
        /// If the button is in the last row, it adjusts the index by subtracting 1 to account for the missing corner button.
        /// The calculated index is returned as the result.
        /// </remarks>
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

        /// <summary>
        /// The "ProfilePictureOption_Click" method handles the click event for profile picture selection buttons.
        /// </summary>
        /// <param name="sender">The sender object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method first checks if the clicked button was already chosen by inspecting its flat style.
        /// If the button was not already chosen, it resets the flat style of all profile picture buttons to standard to deselect any previously chosen button.
        /// It then sets the flat style of the clicked button to flat, changes its border color and size, and updates its background color to indicate selection.
        /// The method also updates the currently chosen image and its corresponding ID in the ImageChosenAtTheMomentId array.
        /// If the clicked button was already chosen, it resets the currently chosen image and its ID.
        /// Finally, it invokes the ButtonClick event, passing itself as the sender and the event arguments.
        /// </remarks>
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
                imageChosenAtTheMoment = currentButton.BackgroundImage;
                ImageChosenAtTheMomentId[0] = CurrentTypeOfProfilePicture;
                ImageChosenAtTheMomentId[1] = currentButton.Name;
            }
            else
            {
                imageChosenAtTheMoment = null;
                ImageChosenAtTheMomentId[0] = "";
                ImageChosenAtTheMomentId[1] = "";
            }
            ButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// The "SetMaleProfilePictureOption" method sets the profile pictures for male avatars in the profile avatar matrix.
        /// </summary>
        /// <remarks>
        /// This method iterates through each custom button in the profile avatar matrix and assigns a male profile picture image to each button.
        /// It uses the images from the MaleProfilePictureImageList in the ProfilePictureImageList class, incrementing the location index for each button.
        /// If the profile picture matrix is not in its standard position (not displaying the last row), the method adjusts the position of the buttons to fit the male profile pictures.
        /// The method also ensures that only the last row of buttons is visible when displaying male profile pictures.
        /// Finally, it updates the ProfilePictureMatrixIsStandard flag to indicate that the profile picture matrix is in its standard position.
        /// </remarks>
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

        /// <summary>
        /// The "SetFemaleProfilePictureOption" method sets the profile pictures for female avatars in the profile avatar matrix.
        /// </summary>
        /// <remarks>
        /// This method iterates through each custom button in the profile avatar matrix and assigns a female profile picture image to each button.
        /// It uses the images from the FemaleProfilePictureImageList in the ProfilePictureImageList class, incrementing the location index for each button.
        /// If the profile picture matrix is in its standard position (displaying the last row), the method adjusts the position of the buttons to fit the female profile pictures.
        /// If there are more female profile pictures than buttons, it hides the excess buttons.
        /// The method also updates the ProfilePictureMatrixIsStandard flag to indicate whether the profile picture matrix is in its standard position.
        /// </remarks>
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

        /// <summary>
        /// The "SetAnimalProfilePictureOption" method sets the profile pictures for animal avatars in the profile avatar matrix.
        /// </summary>
        /// <remarks>
        /// This method iterates through each custom button in the profile avatar matrix and assigns an animal profile picture image to each button.
        /// It uses the images from the AnimalProfilePictureImageList in the ProfilePictureImageList class, incrementing the location index for each button.
        /// If the profile picture matrix is in its standard position (displaying the last row), the method adjusts the position of the buttons to fit the animal profile pictures.
        /// If there are more animal profile pictures than buttons, it hides the excess buttons.
        /// The method also updates the ProfilePictureMatrixIsStandard flag to indicate whether the profile picture matrix is in its standard position.
        /// </remarks>
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

        /// <summary>
        /// The "ProfilePictureKindOption_Click" method handles the selection of different types of profile pictures (male, female, or animal) for the user's profile.
        /// </summary>
        /// <remarks>
        /// This method first checks if it is the first time uploading the profile picture matrix, and if so, it sets the flag FirstProfilePictureMatrixUpload to false and calls the SetProfilePictureMatrixVisible method to make the profile picture matrix visible.
        /// It then calls the RestartProfilePictureSelection method to reset the profile picture selection process.
        /// Next, it retrieves the clicked custom button as the currentButton and updates its border size, background color, and enabled state to indicate selection.
        /// The method sets the CurrentTypeOfProfilePicture to the name of the currentButton.
        /// Depending on the CurrentTypeOfProfilePicture, the method calls the respective method to set the profile pictures for male, female, or animal avatars (SetMaleProfilePictureOption, SetFemaleProfilePictureOption, or SetAnimalProfilePictureOption).
        /// After setting the profile picture options, the method calls RestartProfilePicture to reset the profile picture selection state.
        /// If an image was already chosen by the user, the method calls ImageWasChosen to handle the chosen image.
        /// </remarks>
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
            if (imageChosenAtTheMoment != null)
            {
                ImageWasChosen();
            }
        }

        /// <summary>
        /// The "SetProfilePictrueMatrixVisible" method sets the visibility of the profile picture matrix buttons to true.
        /// </summary>
        /// <remarks>
        /// This method iterates through each custom button in the profile avatar matrix (ProfileAvatarMatrixOfCustomButtons) and sets the Visible property to true.
        /// It ensures that all profile picture buttons are visible when called, typically used when uploading the profile picture matrix for the first time.
        /// </remarks>
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

        /// <summary>
        /// The "RestartProfilePictureSelection" method resets the selection state of profile picture kind selection buttons.
        /// </summary>
        /// <remarks>
        /// This method iterates through each custom button in the ProfilePictureKindSelectionCustomButtons array and resets the BorderSize, BackColor, BackgroundColor, and Enabled properties.
        /// It is used to reset the selection state of profile picture kind selection buttons, typically called when restarting the profile picture selection process.
        /// </remarks>
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

        /// <summary>
        /// The "RestartProfilePicture" method resets the selection state of profile picture buttons in the profile avatar matrix.
        /// </summary>
        /// <remarks>
        /// This method iterates through each custom button in the ProfileAvatarMatrixOfCustomButtons array and resets the FlatStyle, UseVisualStyleBackColor, BorderSize, and Enabled properties.
        /// It is used to reset the selection state of profile picture buttons in the profile avatar matrix, typically called when restarting the profile picture selection process.
        /// </remarks>
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

        /// <summary>
        /// The "ImageWasChosen" method updates the visual state of the selected profile picture in the profile avatar matrix.
        /// </summary>
        /// <remarks>
        /// This method checks if the current type of profile picture matches the stored ID of the chosen image.
        /// If they match, it iterates through each custom button in the ProfileAvatarMatrixOfCustomButtons array to find the button corresponding to the chosen image.
        /// Once found, it sets the FlatStyle, BorderColor, BorderSize, BackColor, and BackgroundColor properties to visually indicate the selection of the profile picture.
        /// </remarks>
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

        #endregion

        #region Public Methods

        /// <summary>
        /// The "GetImageNameID" method retrieves the unique identifier for the currently chosen profile picture.
        /// </summary>
        /// <returns>The unique identifier for the currently chosen profile picture.</returns>
        /// <remarks>
        /// This method first obtains the index of the currently chosen profile picture from its name in the ProfileAvatarMatrixOfCustomButtons array.
        /// It then removes the "SelectionCustomButton" suffix from the current type of profile picture to get the base identifier.
        /// Finally, it appends the obtained index to the base identifier to create the complete unique identifier for the currently chosen profile picture.
        /// </remarks>
        public string GetImageNameID()
        {
            CurrentImageIndex = GetIndexFromName(ImageChosenAtTheMomentId[1]).ToString();
            return ImageChosenAtTheMomentId[0].Substring(0, ImageChosenAtTheMomentId[0].Length - "SelectionCustomButton".Length) + CurrentImageIndex;
        }

        /// <summary>
        /// The "AddButtonClickHandler" method adds an event handler to the ButtonClick event.
        /// </summary>
        /// <param name="handler">The event handler to add to the ButtonClick event.</param>
        /// <remarks>
        /// This method allows external code to subscribe to the ButtonClick event, which is raised when a button in the form is clicked.
        /// By adding an event handler to this event, external code can respond to button clicks in the form.
        /// </remarks>
        public void AddButtonClickHandler(EventHandler handler)
        {
            ButtonClick += handler;
        }

        #endregion
    }
}
