﻿using System;
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
        public event EventHandler TextChangedEvent;

        private bool[] PasswordIsShownArray;
        private bool OldPasswordVisibleProperty = true;
        private bool ConfirmPasswordVisibleProperty = true;
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
                this.PasswordTextBoxArray[i].TextChangedEvent += new System.EventHandler(this.CheckPasswordFieldsValue);

                this.Controls.Add(this.PasswordTextBoxArray[i]);


                height += HeightDifference;
            }
            this.PasswordTextBoxArray[0].Name = "OldPasswordTextBox";
            this.PasswordTextBoxArray[1].Name = "NewPasswordTextBox";
            this.PasswordTextBoxArray[2].Name = "ConfirmPasswordTextBox";
            this.PasswordTextBoxArray[0].PlaceHolderText = "Enter Old Password";


        }
        private void CheckPasswordFieldsValue(object sender, EventArgs e)
        {
            if ((IsContainingValue(PasswordTextBoxArray[1])) && (IsContainingValue(PasswordTextBoxArray[2])) && ((IsContainingValue(PasswordTextBoxArray[0])) || !OldPasswordVisibleProperty))
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
        public string GetNewPassword()
        {
            return PasswordTextBoxArray[1].Text; //will need to make sure if this password is similar to the password the server returned to me after logging in...
        }

        private void PasswordGeneratorControl_Load(object sender, EventArgs e)
        {

        }
    }
}
