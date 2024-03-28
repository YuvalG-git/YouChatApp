namespace YouChatApp.UserAuthentication.Forms
{
    partial class PasswordRestart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ResetPasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.EmailAddressLabel = new System.Windows.Forms.Label();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.PasswordReplacerCustomButton = new YouChatApp.Controls.CustomButton();
            this.RestartCodeCustomButton = new YouChatApp.Controls.CustomButton();
            this.VerifyCustomButton = new YouChatApp.Controls.CustomButton();
            this.CodeCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.PasswordGeneratorControl = new YouChatApp.Controls.PasswordGeneratorControl();
            this.CodeSenderCustomButton = new YouChatApp.Controls.CustomButton();
            this.EmailAddressCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.UsernameCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.LoginReturnerCustomButton = new YouChatApp.Controls.CustomButton();
            this.SuspendLayout();
            // 
            // ResetPasswordLabel
            // 
            this.ResetPasswordLabel.AutoSize = true;
            this.ResetPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetPasswordLabel.Location = new System.Drawing.Point(100, 20);
            this.ResetPasswordLabel.Name = "ResetPasswordLabel";
            this.ResetPasswordLabel.Size = new System.Drawing.Size(270, 31);
            this.ResetPasswordLabel.TabIndex = 1;
            this.ResetPasswordLabel.Text = "RESET PASSWORD";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(30, 80);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(95, 18);
            this.UsernameLabel.TabIndex = 50;
            this.UsernameLabel.Text = "Username:";
            // 
            // EmailAddressLabel
            // 
            this.EmailAddressLabel.AutoSize = true;
            this.EmailAddressLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailAddressLabel.Location = new System.Drawing.Point(30, 150);
            this.EmailAddressLabel.Name = "EmailAddressLabel";
            this.EmailAddressLabel.Size = new System.Drawing.Size(127, 18);
            this.EmailAddressLabel.TabIndex = 52;
            this.EmailAddressLabel.Text = "Email Address:";
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeLabel.Location = new System.Drawing.Point(30, 270);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(55, 18);
            this.CodeLabel.TabIndex = 55;
            this.CodeLabel.Text = "Code:";
            this.CodeLabel.Visible = false;
            // 
            // PasswordReplacerCustomButton
            // 
            this.PasswordReplacerCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.PasswordReplacerCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.PasswordReplacerCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.PasswordReplacerCustomButton.BorderRadius = 10;
            this.PasswordReplacerCustomButton.BorderSize = 0;
            this.PasswordReplacerCustomButton.Circular = false;
            this.PasswordReplacerCustomButton.FlatAppearance.BorderSize = 0;
            this.PasswordReplacerCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordReplacerCustomButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordReplacerCustomButton.ForeColor = System.Drawing.Color.White;
            this.PasswordReplacerCustomButton.Location = new System.Drawing.Point(80, 490);
            this.PasswordReplacerCustomButton.Name = "PasswordReplacerCustomButton";
            this.PasswordReplacerCustomButton.Size = new System.Drawing.Size(220, 40);
            this.PasswordReplacerCustomButton.TabIndex = 59;
            this.PasswordReplacerCustomButton.Text = "Change Password";
            this.PasswordReplacerCustomButton.TextColor = System.Drawing.Color.White;
            this.PasswordReplacerCustomButton.UseVisualStyleBackColor = false;
            this.PasswordReplacerCustomButton.Visible = false;
            // 
            // RestartCodeCustomButton
            // 
            this.RestartCodeCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.RestartCodeCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.RestartCodeCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RestartCodeCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RestartCodeCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RestartCodeCustomButton.BorderRadius = 10;
            this.RestartCodeCustomButton.BorderSize = 0;
            this.RestartCodeCustomButton.Circular = false;
            this.RestartCodeCustomButton.FlatAppearance.BorderSize = 0;
            this.RestartCodeCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartCodeCustomButton.ForeColor = System.Drawing.Color.White;
            this.RestartCodeCustomButton.Location = new System.Drawing.Point(265, 257);
            this.RestartCodeCustomButton.Name = "RestartCodeCustomButton";
            this.RestartCodeCustomButton.Size = new System.Drawing.Size(40, 40);
            this.RestartCodeCustomButton.TabIndex = 58;
            this.RestartCodeCustomButton.TextColor = System.Drawing.Color.White;
            this.RestartCodeCustomButton.UseVisualStyleBackColor = false;
            this.RestartCodeCustomButton.Visible = false;
            this.RestartCodeCustomButton.Click += new System.EventHandler(this.RestartCodeCustomButton_Click);
            // 
            // VerifyCustomButton
            // 
            this.VerifyCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.VerifyCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.VerifyCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.VerifyCustomButton.BorderRadius = 10;
            this.VerifyCustomButton.BorderSize = 0;
            this.VerifyCustomButton.Circular = false;
            this.VerifyCustomButton.FlatAppearance.BorderSize = 0;
            this.VerifyCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerifyCustomButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyCustomButton.ForeColor = System.Drawing.Color.White;
            this.VerifyCustomButton.Location = new System.Drawing.Point(140, 305);
            this.VerifyCustomButton.Name = "VerifyCustomButton";
            this.VerifyCustomButton.Size = new System.Drawing.Size(110, 40);
            this.VerifyCustomButton.TabIndex = 57;
            this.VerifyCustomButton.Text = "Verify";
            this.VerifyCustomButton.TextColor = System.Drawing.Color.White;
            this.VerifyCustomButton.UseVisualStyleBackColor = false;
            this.VerifyCustomButton.Visible = false;
            this.VerifyCustomButton.Click += new System.EventHandler(this.VerifyCustomButton_Click);
            // 
            // CodeCustomTextBox
            // 
            this.CodeCustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.CodeCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CodeCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CodeCustomTextBox.BorderRadius = 0;
            this.CodeCustomTextBox.BorderSize = 2;
            this.CodeCustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.CodeCustomTextBox.IsFocused = false;
            this.CodeCustomTextBox.Location = new System.Drawing.Point(85, 260);
            this.CodeCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CodeCustomTextBox.MaxLength = 32767;
            this.CodeCustomTextBox.Multiline = false;
            this.CodeCustomTextBox.Name = "CodeCustomTextBox";
            this.CodeCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CodeCustomTextBox.PasswordChar = false;
            this.CodeCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.CodeCustomTextBox.PlaceHolderText = "Enter Code";
            this.CodeCustomTextBox.ReadOnly = false;
            this.CodeCustomTextBox.Size = new System.Drawing.Size(173, 33);
            this.CodeCustomTextBox.TabIndex = 56;
            this.CodeCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CodeCustomTextBox.TextContent = "";
            this.CodeCustomTextBox.UnderlineStyle = true;
            this.CodeCustomTextBox.Visible = false;
            this.CodeCustomTextBox.TextChangedEvent += new System.EventHandler(this.CodeCustomTextBox_TextChangedEvent);
            // 
            // PasswordGeneratorControl
            // 
            this.PasswordGeneratorControl.ConfirmPasswordVisible = true;
            this.PasswordGeneratorControl.Location = new System.Drawing.Point(20, 350);
            this.PasswordGeneratorControl.Name = "PasswordGeneratorControl";
            this.PasswordGeneratorControl.NewPasswordTextContent = "New Password";
            this.PasswordGeneratorControl.OldPasswordVisible = false;
            this.PasswordGeneratorControl.Size = new System.Drawing.Size(335, 135);
            this.PasswordGeneratorControl.TabIndex = 36;
            this.PasswordGeneratorControl.Visible = false;
            // 
            // CodeSenderCustomButton
            // 
            this.CodeSenderCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.CodeSenderCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.CodeSenderCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.CodeSenderCustomButton.BorderRadius = 10;
            this.CodeSenderCustomButton.BorderSize = 0;
            this.CodeSenderCustomButton.Circular = false;
            this.CodeSenderCustomButton.Enabled = false;
            this.CodeSenderCustomButton.FlatAppearance.BorderSize = 0;
            this.CodeSenderCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CodeSenderCustomButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeSenderCustomButton.ForeColor = System.Drawing.Color.White;
            this.CodeSenderCustomButton.Location = new System.Drawing.Point(140, 215);
            this.CodeSenderCustomButton.Name = "CodeSenderCustomButton";
            this.CodeSenderCustomButton.Size = new System.Drawing.Size(110, 40);
            this.CodeSenderCustomButton.TabIndex = 54;
            this.CodeSenderCustomButton.Text = "Send Code";
            this.CodeSenderCustomButton.TextColor = System.Drawing.Color.White;
            this.CodeSenderCustomButton.UseVisualStyleBackColor = false;
            // 
            // EmailAddressCustomTextBox
            // 
            this.EmailAddressCustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.EmailAddressCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.EmailAddressCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.EmailAddressCustomTextBox.BorderRadius = 0;
            this.EmailAddressCustomTextBox.BorderSize = 2;
            this.EmailAddressCustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailAddressCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.EmailAddressCustomTextBox.IsFocused = false;
            this.EmailAddressCustomTextBox.Location = new System.Drawing.Point(30, 170);
            this.EmailAddressCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.EmailAddressCustomTextBox.MaxLength = 32767;
            this.EmailAddressCustomTextBox.Multiline = false;
            this.EmailAddressCustomTextBox.Name = "EmailAddressCustomTextBox";
            this.EmailAddressCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.EmailAddressCustomTextBox.PasswordChar = false;
            this.EmailAddressCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.EmailAddressCustomTextBox.PlaceHolderText = "Enter Email Address";
            this.EmailAddressCustomTextBox.ReadOnly = false;
            this.EmailAddressCustomTextBox.Size = new System.Drawing.Size(228, 33);
            this.EmailAddressCustomTextBox.TabIndex = 53;
            this.EmailAddressCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EmailAddressCustomTextBox.TextContent = "";
            this.EmailAddressCustomTextBox.UnderlineStyle = true;
            this.EmailAddressCustomTextBox.TextChangedEvent += new System.EventHandler(this.ResetPasswordFieldsChecker);
            // 
            // UsernameCustomTextBox
            // 
            this.UsernameCustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.UsernameCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.UsernameCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.UsernameCustomTextBox.BorderRadius = 0;
            this.UsernameCustomTextBox.BorderSize = 2;
            this.UsernameCustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.UsernameCustomTextBox.IsFocused = false;
            this.UsernameCustomTextBox.Location = new System.Drawing.Point(30, 100);
            this.UsernameCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.UsernameCustomTextBox.MaxLength = 32767;
            this.UsernameCustomTextBox.Multiline = false;
            this.UsernameCustomTextBox.Name = "UsernameCustomTextBox";
            this.UsernameCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.UsernameCustomTextBox.PasswordChar = false;
            this.UsernameCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.UsernameCustomTextBox.PlaceHolderText = "Enter Username";
            this.UsernameCustomTextBox.ReadOnly = false;
            this.UsernameCustomTextBox.Size = new System.Drawing.Size(228, 33);
            this.UsernameCustomTextBox.TabIndex = 51;
            this.UsernameCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernameCustomTextBox.TextContent = "";
            this.UsernameCustomTextBox.UnderlineStyle = true;
            this.UsernameCustomTextBox.TextChangedEvent += new System.EventHandler(this.ResetPasswordFieldsChecker);
            // 
            // LoginReturnerCustomButton
            // 
            this.LoginReturnerCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.LoginReturnerCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.LoginReturnerCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.returnArrow;
            this.LoginReturnerCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LoginReturnerCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.LoginReturnerCustomButton.BorderRadius = 10;
            this.LoginReturnerCustomButton.BorderSize = 0;
            this.LoginReturnerCustomButton.Circular = false;
            this.LoginReturnerCustomButton.FlatAppearance.BorderSize = 0;
            this.LoginReturnerCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginReturnerCustomButton.ForeColor = System.Drawing.Color.White;
            this.LoginReturnerCustomButton.Location = new System.Drawing.Point(20, 20);
            this.LoginReturnerCustomButton.Name = "LoginReturnerCustomButton";
            this.LoginReturnerCustomButton.Size = new System.Drawing.Size(60, 30);
            this.LoginReturnerCustomButton.TabIndex = 49;
            this.LoginReturnerCustomButton.TextColor = System.Drawing.Color.White;
            this.LoginReturnerCustomButton.UseVisualStyleBackColor = false;
            this.LoginReturnerCustomButton.Click += new System.EventHandler(this.LoginReturnerCustomButton_Click);
            // 
            // PasswordRestart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 541);
            this.Controls.Add(this.PasswordReplacerCustomButton);
            this.Controls.Add(this.RestartCodeCustomButton);
            this.Controls.Add(this.VerifyCustomButton);
            this.Controls.Add(this.CodeCustomTextBox);
            this.Controls.Add(this.CodeLabel);
            this.Controls.Add(this.PasswordGeneratorControl);
            this.Controls.Add(this.CodeSenderCustomButton);
            this.Controls.Add(this.EmailAddressCustomTextBox);
            this.Controls.Add(this.EmailAddressLabel);
            this.Controls.Add(this.UsernameCustomTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.LoginReturnerCustomButton);
            this.Controls.Add(this.ResetPasswordLabel);
            this.Name = "PasswordRestart";
            this.Text = "PasswordReset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label ResetPasswordLabel;
        private Controls.CustomButton LoginReturnerCustomButton;
        private Controls.CustomTextBox UsernameCustomTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private Controls.CustomTextBox EmailAddressCustomTextBox;
        private System.Windows.Forms.Label EmailAddressLabel;
        private Controls.PasswordGeneratorControl PasswordGeneratorControl;
        private Controls.CustomButton CodeSenderCustomButton;
        private Controls.CustomTextBox CodeCustomTextBox;
        private System.Windows.Forms.Label CodeLabel;
        private Controls.CustomButton VerifyCustomButton;
        private Controls.CustomButton RestartCodeCustomButton;
        private Controls.CustomButton PasswordReplacerCustomButton;
    }
}