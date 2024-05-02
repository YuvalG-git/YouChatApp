using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace YouChatApp.Controls
{
    /// <summary>
    /// The "PasswordGeneratorControl" class represents a user control for generating and managing passwords.
    /// </summary>
    /// <remarks>
    /// This control provides functionality for entering and managing passwords, including options for showing/hiding password characters,
    /// checking password strength, and handling password-related events.
    /// It includes methods for initializing the control, handling password visibility, and checking password strength.
    /// The control also provides events for notifying external code about password changes and strength updates.
    /// </remarks>
    public partial class PasswordGeneratorControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "TextChangedEvent" event is raised when the text in the control is changed.
        /// </summary>
        public event EventHandler TextChangedEvent;

        #endregion

        #region Private Readonly Fields

        /// <summary>
        /// The readonly Image "passwordNotShown" represents the image for a password that is not shown.
        /// </summary>
        private readonly Image passwordNotShown = global::YouChatApp.Properties.Resources.showPassword;

        /// <summary>
        /// The readonly Image "passwordShown" represents the image for a password that is shown.
        /// </summary>
        private readonly Image passwordShown = global::YouChatApp.Properties.Resources.dontShowPassword;


        #endregion

        #region Private Fields

        /// <summary>
        /// The PasswordHandler "passwordHandler" represents the password handler.
        /// </summary>
        private PasswordHandler passwordHandler;

        /// <summary>
        /// The bool array "PasswordIsShownArray" indicates whether passwords are shown.
        /// </summary>
        private bool[] PasswordIsShownArray;

        /// <summary>
        /// The bool "OldPasswordVisibleProperty" indicates whether the old password is visible.
        /// </summary>
        private bool OldPasswordVisibleProperty = true;

        /// <summary>
        /// The bool "ConfirmPasswordVisibleProperty" indicates whether the confirm password is visible.
        /// </summary>
        private bool ConfirmPasswordVisibleProperty = true;

        /// <summary>
        /// The bool "PasswordExclamationVisibleProperty" indicates whether the password exclamation is visible.
        /// </summary>
        private bool PasswordExclamationVisibleProperty = true;

        /// <summary>
        /// The string "NewPasswordTextContentProperty" represents the text content for the new password.
        /// </summary>
        private string NewPasswordTextContentProperty = "New Password";

        /// <summary>
        /// The bool "IsCurrentOldPasswordVisible" indicates whether the current old password is visible.
        /// </summary>
        private bool IsCurrentOldPasswordVisible = true;

        /// <summary>
        /// The int "HeightDifference" represents the height difference.
        /// </summary>
        private int HeightDifference = 60;

        /// <summary>
        /// The bool "AllFieldsHaveValue" indicates whether all fields have a value.
        /// </summary>
        private bool AllFieldsHaveValue = false;

        #endregion

        #region Constructors

        /// <summary>
        ///  The "PasswordGeneratorControl" constructor initializes a new instance of the <see cref="PasswordGeneratorControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the PasswordGeneratorControl by initializing its components.
        /// </remarks>
        public PasswordGeneratorControl()
        {
            InitializeComponent();
            InitializePasswordTextBoxArray();
            InitializePasswordViewerButtonArray();
            InitializePasswordIsShownArray();
            setPasswordExclamationCustomButtonLocation();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "NewPasswordTextContent" property represents the text content for a new password.
        /// It gets or sets the text content for the new password.
        /// </summary>
        /// <value>
        /// The text content for the new password.
        /// </value>
        public string NewPasswordTextContent
        {
            get
            {
                return NewPasswordTextContentProperty;
            }
            set
            {
                NewPasswordTextContentProperty = value;
                NewPasswordLabel.Text = NewPasswordTextContentProperty + ":";
                PasswordTextBoxArray[1].PlaceHolderText = "Enter " + NewPasswordTextContentProperty;
            }
        }

        /// <summary>
        /// The "OldPasswordVisible" property represents whether the old password is visible.
        /// It gets or sets a value indicating whether the old password is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the old password is visible; otherwise, <c>false</c>.
        /// </value>
        public bool OldPasswordVisible
        {
            get
            {
                return OldPasswordVisibleProperty;
            }
            set
            {
                OldPasswordVisibleProperty = value;
                SetCase();
            }
        }

        /// <summary>
        /// The "ConfirmPasswordVisible" property represents whether the confirm password field is visible.
        /// It gets or sets a value indicating whether the confirm password field is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the confirm password field is visible; otherwise, <c>false</c>.
        /// </value>
        public bool ConfirmPasswordVisible
        {
            get
            {
                return ConfirmPasswordVisibleProperty;
            }
            set
            {
                ConfirmPasswordVisibleProperty = value;
                SetConfirmPassword();
            }
        }

        /// <summary>
        /// The "PasswordExclamationVisible" property represents whether the exclamation mark for password strength is visible.
        /// It gets or sets a value indicating whether the exclamation mark for password strength is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the exclamation mark for password strength is visible; otherwise, <c>false</c>.
        /// </value>
        public bool PasswordExclamationVisible
        {
            get
            {
                return PasswordExclamationVisibleProperty;
            }
            set
            {
                PasswordExclamationVisibleProperty = value;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "InitializePasswordViewerButtonArray" method initializes an array of custom buttons used for viewing a password.
        /// </summary>
        /// <remarks>
        /// This method creates and configures three custom buttons, each representing a part of the password to be shown.
        /// The buttons are styled with specific colors and properties to match the application's design.
        /// The Click event of each button is wired to the PasswordViewerCustomButton_Click method for handling the password viewing logic.
        /// </remarks>
        private void InitializePasswordViewerButtonArray()
        {
            int height = 30;
            PasswordViewerCustomButtonArray = new CustomButton[3];
            for (int i = 0; i < PasswordViewerCustomButtonArray.Length; i++)
            {
                PasswordViewerCustomButtonArray[i] = new CustomButton();
                this.PasswordViewerCustomButtonArray[i].BackgroundImage = passwordNotShown;
                this.PasswordViewerCustomButtonArray[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.PasswordViewerCustomButtonArray[i].FlatAppearance.BorderColor = System.Drawing.Color.Black;
                this.PasswordViewerCustomButtonArray[i].BackColor = System.Drawing.Color.MediumSlateBlue;
                this.PasswordViewerCustomButtonArray[i].BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                this.PasswordViewerCustomButtonArray[i].BorderColor = System.Drawing.Color.PaleVioletRed;
                this.PasswordViewerCustomButtonArray[i].Location = new System.Drawing.Point(250, height);
                this.PasswordViewerCustomButtonArray[i].BorderRadius = 3;
                this.PasswordViewerCustomButtonArray[i].BorderSize = 0;
                this.PasswordViewerCustomButtonArray[i].Circular = false;
                this.PasswordViewerCustomButtonArray[i].FlatAppearance.BorderSize = 0;
                this.PasswordViewerCustomButtonArray[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.PasswordViewerCustomButtonArray[i].ForeColor = System.Drawing.Color.White;
                this.PasswordViewerCustomButtonArray[i].Name = "ViewPasswordButtonNumber" + (i+1);
                this.PasswordViewerCustomButtonArray[i].Size = new System.Drawing.Size(22, 23);
                this.PasswordViewerCustomButtonArray[i].TabIndex = 18;
                this.PasswordViewerCustomButtonArray[i].UseMnemonic = false;
                this.PasswordViewerCustomButtonArray[i].UseVisualStyleBackColor = false;
                this.PasswordViewerCustomButtonArray[i].Click += new System.EventHandler(this.PasswordViewerCustomButton_Click);
                this.Controls.Add(this.PasswordViewerCustomButtonArray[i]);
                height += HeightDifference;
            }
        }

        /// <summary>
        /// The "InitializePasswordTextBoxArray" method initializes an array of custom text boxes used for entering passwords.
        /// </summary>
        /// <remarks>
        /// This method creates and configures three custom text boxes, each representing a part of the password to be entered.
        /// The text boxes are styled with a specific font and size to match the application's design.
        /// They are set to accept passwords (characters are displayed as asterisks), with shortcuts disabled.
        /// Placeholder text is set for each text box to guide the user on what to enter.
        /// Event handlers are attached to handle key events, text changes, leaving the text box, and other interactions.
        /// </remarks>
        private void InitializePasswordTextBoxArray()
        {
            int height = 30;
            PasswordTextBoxArray = new CustomTextBox[3];
            for (int i = 0; i < PasswordTextBoxArray.Length; i++)
            {
                PasswordTextBoxArray[i] = new CustomTextBox();
                this.PasswordTextBoxArray[i].Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.PasswordTextBoxArray[i].Location = new System.Drawing.Point(10, height);
                this.PasswordTextBoxArray[i].Size = new System.Drawing.Size(228, 26);
                this.PasswordTextBoxArray[i].TabIndex = 1;
                this.PasswordTextBoxArray[i].UnderlineStyle = true;
                this.PasswordTextBoxArray[i].PasswordChar = true;
                this.PasswordTextBoxArray[i].ShortcutsEnabled = false;
                this.PasswordTextBoxArray[i].ContextMenu = new ContextMenu();
                this.PasswordTextBoxArray[i].PlaceHolderText = "Enter New Password";
                this.PasswordTextBoxArray[i].KeyDown += new KeyEventHandler(this.CustomTextBox_KeyDown);
                if (i!= 1)
                    this.PasswordTextBoxArray[i].TextChangedEvent += new System.EventHandler(this.PasswordTextBoxLocation0And2_TextChangedEvent);
                else
                    this.PasswordTextBoxArray[i].TextChangedEvent += new System.EventHandler(this.PasswordTextBoxLocation1_TextChangedEvent);
                this.Controls.Add(this.PasswordTextBoxArray[i]);
                height += HeightDifference;
            }
            this.PasswordTextBoxArray[0].Name = "OldPasswordTextBox";
            this.PasswordTextBoxArray[1].Name = "NewPasswordTextBox";
            this.PasswordTextBoxArray[2].Name = "ConfirmPasswordTextBox";
            this.PasswordTextBoxArray[0].PlaceHolderText = "Enter Old Password";
            InitializePasswordHandler();
            this.PasswordTextBoxArray[1].Leave += new System.EventHandler(this.PasswordTextBox_Leave);
            this.PasswordTextBoxArray[1].KeyDown += new KeyEventHandler(this.CustomTextBox_KeyDown);
        }

        /// <summary>
        /// The "setPasswordExclamationCustomButtonLocation" method sets the location of the PasswordExclamationCustomButton relative to the NewPasswordTextBox.
        /// </summary>
        /// <remarks>
        /// This method adjusts the position of the PasswordExclamationCustomButton based on the location of the NewPasswordTextBox.
        /// It ensures that the exclamation button is positioned above the NewPasswordTextBox to indicate password strength or requirements.
        /// </remarks>
        private void setPasswordExclamationCustomButtonLocation()
        {
            PasswordExclamationCustomButton.Location = new Point(PasswordExclamationCustomButton.Location.X, PasswordTextBoxArray[1].Location.Y - 14);
        }

        /// <summary>
        /// The "InitializePasswordHandler" method initializes the passwordHandler object.
        /// </summary>
        /// <remarks>
        /// This method creates a new instance of the PasswordHandler class, which is used for handling password-related logic and operations.
        /// </remarks>
        private void InitializePasswordHandler()
        {
            passwordHandler = new PasswordHandler();
        }

        /// <summary>
        /// The "HandlePasswordTextBoxContent" method handles the content of the password text box.
        /// </summary>
        /// <remarks>
        /// This method checks if the password exclamation icon is visible.
        /// If the password text box contains a placeholder, it sets the border color to MediumSlateBlue and hides the exclamation icon.
        /// Otherwise, it checks the strength of the entered password using the passwordHandler object.
        /// It sets the border color of the text box based on the password strength and shows a tooltip with password information if the password is not strong enough.
        /// </remarks>
        private void HandlePasswordTextBoxContent()
        {
            if (PasswordExclamationVisibleProperty)
            {
                if (PasswordTextBoxArray[1].isPlaceHolder())
                {
                    PasswordTextBoxArray[1].BorderColor = Color.MediumSlateBlue;
                    PasswordExclamationCustomButton.Visible = false;
                }
                else
                {
                    string CurrentPassword = PasswordTextBoxArray[1].TextContent;
                    passwordHandler.CheckPassword(CurrentPassword);
                    PasswordTextBoxArray[1].BorderColor = passwordHandler.PasswordInformationColor;
                    if (passwordHandler.PasswordStrength != "That's a strong password")
                    {
                        PasswordExclamationCustomButton.Visible = true;
                        ToolTip.SetToolTip(PasswordExclamationCustomButton, passwordHandler.PasswordStrength + "\n" + passwordHandler.PasswordInformation);
                    }
                    else
                    {
                        PasswordExclamationCustomButton.Visible = false;
                    }
                }
            }  
        }

        /// <summary>
        /// The "PasswordTextBox_Leave" method handles the Leave event of the password text box.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandlePasswordTextBoxContent method to handle the content of the password text box when it loses focus.
        /// </remarks>
        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            HandlePasswordTextBoxContent();
        }

        /// <summary>
        /// The "PasswordTextBoxLocation0And2_TextChangedEvent" method handles the TextChanged event of the PasswordTextBoxArray for indexes 0 and 2.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the CheckPasswordFieldsValue method to check if all password fields have a value when the text in the password text boxes at indexes 0 and 2 changes.
        /// </remarks>
        private void PasswordTextBoxLocation0And2_TextChangedEvent(object sender, EventArgs e)
        {
            CheckPasswordFieldsValue(e);
        }

        /// <summary>
        /// The "PasswordTextBoxLocation1_TextChangedEvent" method handles the TextChanged event of the PasswordTextBoxArray at index 1.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the CheckPasswordFieldsValue method to check if all password fields have a value when the text in the password text box at index 1 changes.
        /// It also calls the HandlePasswordTextBoxContent method to handle the content of the password text box at index 1.
        /// </remarks>
        private void PasswordTextBoxLocation1_TextChangedEvent(object sender, EventArgs e)
        {
            CheckPasswordFieldsValue(e);
            HandlePasswordTextBoxContent();
        }

        /// <summary>
        /// The "CheckPasswordFieldsValue" method checks if all password fields have a value.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the new password field has a value and either the confirm password field also has a value or the confirm password field is not visible,
        /// and similarly, if the old password field has a value or is not visible. It sets the AllFieldsHaveValue property accordingly.
        /// It then raises the TextChangedEvent to notify subscribers that the value of the password fields has changed.
        /// </remarks>
        private void CheckPasswordFieldsValue(EventArgs e)
        {
            if ((IsContainingValue(PasswordTextBoxArray[1])) && ((IsContainingValue(PasswordTextBoxArray[2])) || !ConfirmPasswordVisibleProperty) && ((IsContainingValue(PasswordTextBoxArray[0])) || !OldPasswordVisibleProperty))
            {
                AllFieldsHaveValue = true;
            }
            else
            {
                AllFieldsHaveValue = false;
            }
            TextChangedEvent?.Invoke(this, e);
        }

        /// <summary>
        /// The "InitializePasswordIsShownArray" method initializes an array to track whether password characters are shown or hidden.
        /// </summary>
        /// <remarks>
        /// This method creates a boolean array with three elements, each initialized to false, to keep track of whether the characters in the corresponding password text boxes are currently shown or hidden.
        /// </remarks>
        private void InitializePasswordIsShownArray()
        {
            PasswordIsShownArray = new bool[3];
            for (int i = 0; i < PasswordIsShownArray.Length; i++)
            {
                PasswordIsShownArray[i] = false;
            }
        }

        /// <summary>
        /// The "PasswordViewerCustomButton_Click" method toggles the visibility of password characters in the associated text box.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is used to toggle the visibility of password characters in the text box associated with the clicked button.
        /// It determines the index of the clicked button based on its name, toggles the visibility status in the PasswordIsShownArray,
        /// and updates the text box's PasswordChar property and the button's background image accordingly.
        /// </remarks>
        private void PasswordViewerCustomButton_Click(object sender, EventArgs e)
        {
            int ButtonNameLength = ((CustomButton)(sender)).Name.Length;
            string NumberAsString = ((CustomButton)(sender)).Name[ButtonNameLength - 1].ToString();
            int Number = int.Parse(NumberAsString);
            int IndexLocation = Number - 1;
            PasswordIsShownArray[IndexLocation] = !PasswordIsShownArray[IndexLocation];
            if (PasswordIsShownArray[IndexLocation])
            {
                this.PasswordTextBoxArray[IndexLocation].PasswordChar = false;
                ((CustomButton)(sender)).BackgroundImage = passwordShown;
            }
            else
            {
                if (!this.PasswordTextBoxArray[IndexLocation].isPlaceHolder())
                {
                    this.PasswordTextBoxArray[IndexLocation].PasswordChar = true;
                    ((CustomButton)(sender)).BackgroundImage = passwordNotShown;
                }
            }
        }

        /// <summary>
        /// The "SetCase" method adjusts the visibility and layout of password-related controls based on the visibility of the old password field.
        /// </summary>
        /// <remarks>
        /// This method checks if the visibility of the old password field has changed and adjusts the visibility and layout of
        /// the associated controls accordingly. If the old password field is hidden, it repositions the new and confirm password fields
        /// and adjusts the form height accordingly. If the old password field is shown, it repositions the new and confirm password fields
        /// back to their original positions and adjusts the form height accordingly.
        /// </remarks>
        private void SetCase()
        {
            if (IsCurrentOldPasswordVisible != OldPasswordVisibleProperty)
            {
                IsCurrentOldPasswordVisible = OldPasswordVisibleProperty;
                this.OldPasswordLabel.Visible = OldPasswordVisibleProperty;
                this.PasswordViewerCustomButtonArray[0].Visible = OldPasswordVisibleProperty;
                this.PasswordTextBoxArray[0].Visible = OldPasswordVisibleProperty;
                if (!OldPasswordVisibleProperty)
                {
                    for (int i = PasswordTextBoxArray.Length - 1; i > 0; i--)
                    {
                        this.PasswordTextBoxArray[i].Location = new System.Drawing.Point(this.PasswordTextBoxArray[i].Location.X, this.PasswordTextBoxArray[i - 1].Location.Y);
                        this.PasswordViewerCustomButtonArray[i].Location = new System.Drawing.Point(this.PasswordViewerCustomButtonArray[i].Location.X, this.PasswordViewerCustomButtonArray[i - 1].Location.Y);
                    }
                    this.ConfirmPasswordLabel.Location = new System.Drawing.Point(this.ConfirmPasswordLabel.Location.X, this.NewPasswordLabel.Location.Y);
                    this.NewPasswordLabel.Location = new System.Drawing.Point(this.NewPasswordLabel.Location.X, this.OldPasswordLabel.Location.Y);
                    this.Height -= (OldPasswordLabel.Height + PasswordTextBoxArray[0].Height);
                }
                else
                {
                    this.PasswordTextBoxArray[1].Location = new System.Drawing.Point(this.PasswordTextBoxArray[1].Location.X, this.PasswordTextBoxArray[2].Location.Y);
                    this.PasswordTextBoxArray[2].Location = new System.Drawing.Point(this.PasswordTextBoxArray[2].Location.X, this.PasswordTextBoxArray[2].Location.Y + HeightDifference);
                    this.PasswordViewerCustomButtonArray[1].Location = new System.Drawing.Point(this.PasswordViewerCustomButtonArray[1].Location.X, this.PasswordViewerCustomButtonArray[2].Location.Y);
                    this.PasswordViewerCustomButtonArray[2].Location = new System.Drawing.Point(this.PasswordViewerCustomButtonArray[2].Location.X, this.PasswordViewerCustomButtonArray[2].Location.Y + HeightDifference);
                    this.NewPasswordLabel.Location = new System.Drawing.Point(this.NewPasswordLabel.Location.X, this.ConfirmPasswordLabel.Location.Y);
                    this.ConfirmPasswordLabel.Location = new System.Drawing.Point(this.ConfirmPasswordLabel.Location.X, this.ConfirmPasswordLabel.Location.Y + HeightDifference);
                    this.Height += (OldPasswordLabel.Height + PasswordTextBoxArray[0].Height);
                }
            }
            setPasswordExclamationCustomButtonLocation();
        }

        /// <summary>
        /// The "SetConfirmPassword" method adjusts the visibility and layout of the confirm password field based on the ConfirmPasswordVisibleProperty.
        /// </summary>
        /// <remarks>
        /// This method checks the value of ConfirmPasswordVisibleProperty and sets the visibility of the confirm password label, viewer button, and text box accordingly.
        /// If ConfirmPasswordVisibleProperty is false, it hides the confirm password field and reduces the form height accordingly.
        /// If ConfirmPasswordVisibleProperty is true, it shows the confirm password field and increases the form height accordingly.
        /// The method then adjusts the position of the password exclamation button.
        /// </remarks>
        private void SetConfirmPassword()
        {
            this.ConfirmPasswordLabel.Visible = ConfirmPasswordVisibleProperty;
            this.PasswordViewerCustomButtonArray[2].Visible = ConfirmPasswordVisibleProperty;
            this.PasswordTextBoxArray[2].Visible = ConfirmPasswordVisibleProperty;
            if (!ConfirmPasswordVisibleProperty)
            {
                this.Height -= (ConfirmPasswordLabel.Height + PasswordTextBoxArray[2].Height);
            }
            else
            {
                this.Height += (ConfirmPasswordLabel.Height + PasswordTextBoxArray[2].Height);
            }
            setPasswordExclamationCustomButtonLocation();
        }

        /// <summary>
        /// The "IsContainingValue" method checks if the specified CustomTextBox contains a non-empty value.
        /// </summary>
        /// <param name="PasswordTextBox">The CustomTextBox to check.</param>
        /// <returns>True if the CustomTextBox contains a non-empty value, otherwise false.</returns>
        /// <remarks>
        /// This method checks if the specified CustomTextBox is not displaying its placeholder text.
        /// If the CustomTextBox is displaying its placeholder text, it returns false.
        /// If the CustomTextBox is not displaying its placeholder text, it checks if the text content of the CustomTextBox is empty.
        /// If the text content is empty, it returns false. Otherwise, it returns true.
        /// </remarks>
        private bool IsContainingValue(CustomTextBox PasswordTextBox)
        {
            if (PasswordTextBox.isPlaceHolder())
            {
                return false;
            }
            else
            {
                string text = PasswordTextBox.TextContent;
                if (text == "")
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The "CustomTextBox_KeyDown" method handles the KeyDown event for a CustomTextBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The KeyEventArgs containing event data.</param>
        /// <remarks>
        /// This method checks if the Control key and the C key are pressed simultaneously.
        /// If the keys are pressed and the CustomTextBox's PasswordChar property is set to true (password mode),
        /// it displays a message box indicating that copying from a password field is not allowed.
        /// </remarks>
        private void CustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            CustomTextBox textBox = (CustomTextBox)sender;

            if (e.Control && e.KeyCode == Keys.C)
            {
                if (!textBox.PasswordChar)
                {
                    MessageBox.Show(".לא ניתן להעתיק קוד משדה סיסמה", "הפעולה אסורה");
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "DoesAllFieldsHaveValue" method checks if all password fields have a value.
        /// </summary>
        /// <returns>True if all password fields have a value; otherwise, false.</returns>
        /// <remarks>
        /// This method returns true if all password fields (old, new, and confirm) have a value,
        /// indicating that the user has filled in all required password information.
        /// </remarks>
        public bool DoesAllFieldsHaveValue()
        {
            return AllFieldsHaveValue;
        }

        /// <summary>
        /// The "OnTextChangedEventHandler" method adds an event handler to the TextChangedEvent event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        /// <remarks>
        /// This method subscribes to the TextChangedEvent event, which is triggered when the text content of any password field changes.
        /// It allows external code to respond to changes in the password fields.
        /// </remarks>
        public void OnTextChangedEventHandler(EventHandler handler)
        {
            TextChangedEvent += handler;
        }

        /// <summary>
        /// The "IsSamePassword" method checks if the new password and confirm password fields contain the same value.
        /// </summary>
        /// <returns>True if the new password and confirm password fields match, false otherwise.</returns>
        /// <remarks>
        /// This method compares the text content of the new password and confirm password fields.
        /// It returns true if both fields contain the same value and the border color of the new password field is LimeGreen, indicating a valid password.
        /// </remarks>
        public bool IsSamePassword()
        {
            if (PasswordTextBoxArray[1].BorderColor != Color.LimeGreen)
                return false;
            string NewPasswordText = PasswordTextBoxArray[1].TextContent;
            string ConfirmPasswordText = PasswordTextBoxArray[2].TextContent;
            return (NewPasswordText == ConfirmPasswordText);
        }

        /// <summary>
        /// The "GetOldPassword" method returns the text content of the Old Password field.
        /// </summary>
        /// <returns>The text content of the Old Password field.</returns>
        /// <remarks>
        /// This method is used to retrieve the text content entered in the Old Password field.
        /// </remarks>
        public string GetOldPassword()
        {
            return PasswordTextBoxArray[0].TextContent; 
        }

        /// <summary>
        /// The "GetNewPassword" method returns the text content of the New Password field.
        /// </summary>
        /// <returns>The text content of the New Password field.</returns>
        /// <remarks>
        /// This method is used to retrieve the text content entered in the New Password field.
        /// </remarks>
        public string GetNewPassword()
        {
            return PasswordTextBoxArray[1].TextContent;
        }

        /// <summary>
        /// The "SetEnable" method sets the enable/disable state of all password text boxes.
        /// </summary>
        /// <param name="enable">A boolean value indicating whether the text boxes should be enabled or disabled.</param>
        /// <remarks>
        /// This method is used to enable or disable all password text boxes based on the specified boolean value.
        /// </remarks>
        public void SetEnable(bool enable)
        {
            for (int i = 0; i < PasswordTextBoxArray.Length; i++)
            {
                PasswordTextBoxArray[i].Enabled = enable;
            }
        }

        #endregion
    }
}
