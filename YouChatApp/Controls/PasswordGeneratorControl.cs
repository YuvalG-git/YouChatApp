using System;
using System.Drawing;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    public partial class PasswordGeneratorControl : UserControl
    {
        /// <summary>
        /// Both declare an Image variable and assigns it the value of the image resource
        /// </summary>
        private Image passwordNotShown = global::YouChatApp.Properties.Resources.showPassword;
        private Image passwordShown = global::YouChatApp.Properties.Resources.dontShowPassword;
        public event EventHandler TextChangedEvent;

        private PasswordHandler passwordHandler;
        private bool[] PasswordIsShownArray;
        private bool OldPasswordVisibleProperty = true;
        private bool ConfirmPasswordVisibleProperty = true;
        private bool PasswordExclamationVisibleProperty = true;

        private string NewPasswordTextContentProperty = "New Password";

        private bool IsCurrentOldPasswordVisible = true;
        private int HeightDifference = 60;
        private bool AllFieldsHaveValue = false;
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
        public PasswordGeneratorControl(/*bool IsOldPasswordVisible*/)
        {
            InitializeComponent();
            InitializePasswordTextBoxArray();
            InitializePasswordViewerButtonArray();
            InitializePasswordIsShownArray();
            setPasswordExclamationCustomButtonLocation();
            //SetCase(IsOldPasswordVisible);
        }

        private void InitializePasswordViewerButtonArray()
        {
            int height = 30;
            PasswordViewerButtonArray = new CustomButton[3];
            for (int i = 0; i < PasswordViewerButtonArray.Length; i++)
            {
                PasswordViewerButtonArray[i] = new CustomButton();
                this.PasswordViewerButtonArray[i].BackgroundImage = passwordNotShown;
                this.PasswordViewerButtonArray[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.PasswordViewerButtonArray[i].FlatAppearance.BorderColor = System.Drawing.Color.Black;
                this.PasswordViewerButtonArray[i].BackColor = System.Drawing.Color.MediumSlateBlue;
                this.PasswordViewerButtonArray[i].BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                this.PasswordViewerButtonArray[i].BorderColor = System.Drawing.Color.PaleVioletRed;
                this.PasswordViewerButtonArray[i].Location = new System.Drawing.Point(250, height);
                this.PasswordViewerButtonArray[i].BorderRadius = 3;
                this.PasswordViewerButtonArray[i].BorderSize = 0;
                this.PasswordViewerButtonArray[i].Circular = false;
                this.PasswordViewerButtonArray[i].FlatAppearance.BorderSize = 0;
                this.PasswordViewerButtonArray[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.PasswordViewerButtonArray[i].ForeColor = System.Drawing.Color.White;
                this.PasswordViewerButtonArray[i].Name = "ViewPasswordButtonNumber" + (i+1);
                this.PasswordViewerButtonArray[i].Size = new System.Drawing.Size(22, 23);
                this.PasswordViewerButtonArray[i].TabIndex = 18;
                this.PasswordViewerButtonArray[i].UseMnemonic = false;
                this.PasswordViewerButtonArray[i].UseVisualStyleBackColor = false;
                this.PasswordViewerButtonArray[i].Click += new System.EventHandler(this.PasswordViewerButton_Click);
                this.Controls.Add(this.PasswordViewerButtonArray[i]);
                height += HeightDifference;

            }
        }
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
                this.PasswordTextBoxArray[i].PlaceHolderText = "Enter New Password";
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
        }
        private void setPasswordExclamationCustomButtonLocation()
        {
            PasswordExclamationCustomButton.Location = new Point(PasswordExclamationCustomButton.Location.X, PasswordTextBoxArray[1].Location.Y - 14);
        }
        private void InitializePasswordHandler()
        {
            passwordHandler = new PasswordHandler();
        }
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
        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            HandlePasswordTextBoxContent();

        }
        private void PasswordTextBoxLocation0And2_TextChangedEvent(object sender, EventArgs e)
        {
            CheckPasswordFieldsValue(e);
        }
        private void PasswordTextBoxLocation1_TextChangedEvent(object sender, EventArgs e)
        {
            CheckPasswordFieldsValue(e);
            HandlePasswordTextBoxContent();
        }
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
            //else if (PasswordTextBox.TextContent == "") //todo - for some reason it replaces the regular text with the place holder text...
            //{
            //    return false;
            //}
            return true;
        }
        public bool DoesAllFieldsHaveValue()
        {
            return AllFieldsHaveValue;
        }
        public void OnTextChangedEventHandler(EventHandler handler)
        {
            TextChangedEvent += handler;
        }
        private void InitializePasswordIsShownArray()
        {
            PasswordIsShownArray = new bool[3];
            for (int i = 0; i < PasswordIsShownArray.Length; i++)
            {
                PasswordIsShownArray[i] = false;
            }
        }
        private void PasswordViewerButton_Click(object sender, EventArgs e)
        {
            int ButtonNameLength = ((Button)(sender)).Name.Length;
            string NumberAsString = ((Button)(sender)).Name[ButtonNameLength - 1].ToString();
            int Number = int.Parse(NumberAsString);
            int IndexLocation = Number - 1;
            PasswordIsShownArray[IndexLocation] = !PasswordIsShownArray[IndexLocation];
            if (PasswordIsShownArray[IndexLocation])
            {
                //this.PasswordTextBoxArray[IndexLocation].PasswordChar = '\0';
                this.PasswordTextBoxArray[IndexLocation].PasswordChar = false;
                ((Button)(sender)).BackgroundImage = passwordShown;
            }
            else
            {
                if (!this.PasswordTextBoxArray[IndexLocation].isPlaceHolder())
                {
                    //this.PasswordTextBoxArray[IndexLocation].PasswordChar = '*';
                    this.PasswordTextBoxArray[IndexLocation].PasswordChar = true;
                    ((Button)(sender)).BackgroundImage = passwordNotShown;
                }
            }
        }
        private void SetCase()
        {
            if (IsCurrentOldPasswordVisible != OldPasswordVisibleProperty)
            {
                IsCurrentOldPasswordVisible = OldPasswordVisibleProperty;
                this.OldPasswordLabel.Visible = OldPasswordVisibleProperty;
                this.PasswordViewerButtonArray[0].Visible = OldPasswordVisibleProperty;
                this.PasswordTextBoxArray[0].Visible = OldPasswordVisibleProperty;
                if (!OldPasswordVisibleProperty)
                {
                    for (int i = PasswordTextBoxArray.Length - 1; i > 0; i--)
                    {
                        this.PasswordTextBoxArray[i].Location = new System.Drawing.Point(this.PasswordTextBoxArray[i].Location.X, this.PasswordTextBoxArray[i - 1].Location.Y);
                        this.PasswordViewerButtonArray[i].Location = new System.Drawing.Point(this.PasswordViewerButtonArray[i].Location.X, this.PasswordViewerButtonArray[i - 1].Location.Y);
                    }
                    this.ConfirmPasswordLabel.Location = new System.Drawing.Point(this.ConfirmPasswordLabel.Location.X, this.NewPasswordLabel.Location.Y);

                    this.NewPasswordLabel.Location = new System.Drawing.Point(this.NewPasswordLabel.Location.X, this.OldPasswordLabel.Location.Y);
                    this.Height -= (OldPasswordLabel.Height + PasswordTextBoxArray[0].Height);
                }
                else
                {
                    this.PasswordTextBoxArray[1].Location = new System.Drawing.Point(this.PasswordTextBoxArray[1].Location.X, this.PasswordTextBoxArray[2].Location.Y);
                    this.PasswordTextBoxArray[2].Location = new System.Drawing.Point(this.PasswordTextBoxArray[2].Location.X, this.PasswordTextBoxArray[2].Location.Y + HeightDifference);
                    this.PasswordViewerButtonArray[1].Location = new System.Drawing.Point(this.PasswordViewerButtonArray[1].Location.X, this.PasswordViewerButtonArray[2].Location.Y);
                    this.PasswordViewerButtonArray[2].Location = new System.Drawing.Point(this.PasswordViewerButtonArray[2].Location.X, this.PasswordViewerButtonArray[2].Location.Y + HeightDifference);
                    this.NewPasswordLabel.Location = new System.Drawing.Point(this.NewPasswordLabel.Location.X, this.ConfirmPasswordLabel.Location.Y);
                    this.ConfirmPasswordLabel.Location = new System.Drawing.Point(this.ConfirmPasswordLabel.Location.X, this.ConfirmPasswordLabel.Location.Y + HeightDifference);
                    this.Height += (OldPasswordLabel.Height + PasswordTextBoxArray[0].Height);

                }
            }
            setPasswordExclamationCustomButtonLocation();



        }
        private void SetConfirmPassword()
        {
            this.ConfirmPasswordLabel.Visible = ConfirmPasswordVisibleProperty;
            this.PasswordViewerButtonArray[2].Visible = ConfirmPasswordVisibleProperty;
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
        public bool IsSamePassword()
        {
            if (PasswordTextBoxArray[1].BorderColor != Color.LimeGreen)
                return false;
            string NewPasswordText = PasswordTextBoxArray[1].TextContent;
            string ConfirmPasswordText = PasswordTextBoxArray[2].TextContent;
            return (NewPasswordText == ConfirmPasswordText);
        }

        public string GetOldPassword()
        {
            return PasswordTextBoxArray[0].TextContent; //will need to make sure if this password is similar to the password the server returned to me after logging in...
        }
        public string GetNewPassword()
        {
            return PasswordTextBoxArray[1].TextContent; //will need to make sure if this password is similar to the password the server returned to me after logging in...
        }

        private void PasswordGeneratorControl_Load(object sender, EventArgs e)
        {

        }
    }
}
