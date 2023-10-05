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
    public partial class PasswordGeneratorControl : UserControl
    {
        /// <summary>
        /// Both declare an Image variable and assigns it the value of the image resource
        /// </summary>
        private Image passwordNotShown = global::YouChatApp.Properties.Resources.showPassword;
        private Image passwordShown = global::YouChatApp.Properties.Resources.dontShowPassword;

        private bool[] PasswordIsShownArray;
        private bool OldPasswordVisibleProperty = false;

        public bool OldPasswordVisible
        {
            get 
            { 
                return OldPasswordVisibleProperty;
            }
            set
            {
                OldPasswordVisibleProperty = value;
                SetCase(OldPasswordVisibleProperty);
                this.Invalidate();
            }
        }
        public PasswordGeneratorControl(/*bool IsOldPasswordVisible*/)
        {
            InitializeComponent();
            InitializePasswordTextBoxArray();
            InitializePasswordViewerButtonArray();
            InitializePasswordIsShownArray();
            //SetCase(IsOldPasswordVisible);
        }

        private void InitializePasswordViewerButtonArray()
        {
            PasswordViewerButtonArray = new System.Windows.Forms.Button[3];
            for (int i = 0; i < PasswordViewerButtonArray.Length; i++)
            {
                PasswordViewerButtonArray[i] = new System.Windows.Forms.Button();
                this.PasswordViewerButtonArray[i].BackgroundImage = passwordNotShown;
                this.PasswordViewerButtonArray[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.PasswordViewerButtonArray[i].FlatAppearance.BorderColor = System.Drawing.Color.Black;
                this.PasswordViewerButtonArray[i].Location = new System.Drawing.Point(223, 95);
                this.PasswordViewerButtonArray[i].Name = "ViewPasswordButtonNumber" + (i+1);
                this.PasswordViewerButtonArray[i].Size = new System.Drawing.Size(22, 23);
                this.PasswordViewerButtonArray[i].TabIndex = 18;
                this.PasswordViewerButtonArray[i].UseMnemonic = false;
                this.PasswordViewerButtonArray[i].UseVisualStyleBackColor = true;
                this.PasswordViewerButtonArray[i].Click += new System.EventHandler(this.PasswordViewerButton_Click);
            }
        }
        private void InitializePasswordTextBoxArray()
        {
            PasswordTextBoxArray = new System.Windows.Forms.TextBox[3];
            for (int i = 0; i < PasswordTextBoxArray.Length; i++)
            {
                PasswordTextBoxArray[i] = new System.Windows.Forms.TextBox();
                this.PasswordTextBoxArray[i].Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.PasswordTextBoxArray[i].Location = new System.Drawing.Point(6, 39);
                this.PasswordTextBoxArray[i].Size = new System.Drawing.Size(228, 26);
                this.PasswordTextBoxArray[i].TabIndex = 1;
            }
            this.PasswordTextBoxArray[0].Name = "OldPasswordTextBox";
            this.PasswordTextBoxArray[1].Name = "NewPasswordTextBox";
            this.PasswordTextBoxArray[2].Name = "ConfirmPasswordTextBox";

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
                this.PasswordTextBoxArray[IndexLocation].PasswordChar = '\0';
                ((Button)(sender)).BackgroundImage = passwordShown;
            }
            else
            {
                this.PasswordTextBoxArray[IndexLocation].PasswordChar = '*';
                ((Button)(sender)).BackgroundImage = passwordNotShown;
            }
        }
        private void SetCase(bool IsOldPasswordVisible)
        {
            this.OldPasswordLabel.Visible = IsOldPasswordVisible;
            this.PasswordViewerButtonArray[0].Visible = IsOldPasswordVisible;
            this.PasswordTextBoxArray[0].Visible = IsOldPasswordVisible;
            if (IsOldPasswordVisible)
            {

            }
            else
            {

            }
        }
        public bool IsSamePassword()
        {
            string NewPasswordText = PasswordTextBoxArray[1].Text;
            string ConfirmPasswordText = PasswordTextBoxArray[2].Text;
            return (NewPasswordText == ConfirmPasswordText);
        }

        public string GetOldPassword()
        {
            return PasswordTextBoxArray[0].Text; //will need to make sure if this password is similar to the password the server returned to me after logging in...
        }
    }
}
