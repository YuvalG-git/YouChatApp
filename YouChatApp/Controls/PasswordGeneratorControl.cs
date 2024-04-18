using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

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
        private void PasswordViewerCustomButton_Click(object sender, EventArgs e)
        {
            int ButtonNameLength = ((CustomButton)(sender)).Name.Length;
            string NumberAsString = ((CustomButton)(sender)).Name[ButtonNameLength - 1].ToString();
            int Number = int.Parse(NumberAsString);
            int IndexLocation = Number - 1;
            PasswordIsShownArray[IndexLocation] = !PasswordIsShownArray[IndexLocation];
            if (PasswordIsShownArray[IndexLocation])
            {
                //this.PasswordTextBoxArray[IndexLocation].PasswordChar = '\0';
                this.PasswordTextBoxArray[IndexLocation].PasswordChar = false;
                ((CustomButton)(sender)).BackgroundImage = passwordShown;
            }
            else
            {
                if (!this.PasswordTextBoxArray[IndexLocation].isPlaceHolder())
                {
                    //this.PasswordTextBoxArray[IndexLocation].PasswordChar = '*';
                    this.PasswordTextBoxArray[IndexLocation].PasswordChar = true;
                    ((CustomButton)(sender)).BackgroundImage = passwordNotShown;
                }
            }
        }
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
        public void SetEnable(bool enable)
        {
            for (int i = 0; i < PasswordTextBoxArray.Length; i++)
            {
                PasswordTextBoxArray[i].Enabled = enable;
            }
        }
        private void CustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            CustomTextBox textBox = (CustomTextBox)sender;

            if (e.Control && e.KeyCode == Keys.C)
            {
                if (!textBox.PasswordChar)
                {
                    MessageBox.Show(".לא ניתן להעתיק קוד משדה סיסמה", "הפעולה אסורה");
                    e.Handled = true; // Prevent default copy behavior
                }
            }
        }
    }
}
