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
            this.UsernameCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.EmailCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.CodeSenderCustomButton = new YouChatApp.Controls.CustomButton();
            this.passwordGeneratorControl1 = new YouChatApp.Controls.PasswordGeneratorControl();
            this.LoginReturnerCustomButton = new YouChatApp.Controls.CustomButton();
            this.CodeCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.VerifycustomButton = new YouChatApp.Controls.CustomButton();
            this.RestartCodeCustomButton = new YouChatApp.Controls.CustomButton();
            this.PasswordReplacerCustomButton = new YouChatApp.Controls.CustomButton();
            this.SuspendLayout();
            // 
            // ResetPasswordLabel
            // 
            this.ResetPasswordLabel.AutoSize = true;
            this.ResetPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetPasswordLabel.Location = new System.Drawing.Point(100, 10);
            this.ResetPasswordLabel.Name = "ResetPasswordLabel";
            this.ResetPasswordLabel.Size = new System.Drawing.Size(270, 31);
            this.ResetPasswordLabel.TabIndex = 1;
            this.ResetPasswordLabel.Text = "RESET PASSWORD";
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
            this.UsernameCustomTextBox.Location = new System.Drawing.Point(106, 80);
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
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(103, 58);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(95, 18);
            this.UsernameLabel.TabIndex = 50;
            this.UsernameLabel.Text = "Username:";
            // 
            // EmailCustomTextBox
            // 
            this.EmailCustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.EmailCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.EmailCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.EmailCustomTextBox.BorderRadius = 0;
            this.EmailCustomTextBox.BorderSize = 2;
            this.EmailCustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.EmailCustomTextBox.IsFocused = false;
            this.EmailCustomTextBox.Location = new System.Drawing.Point(103, 150);
            this.EmailCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.EmailCustomTextBox.MaxLength = 32767;
            this.EmailCustomTextBox.Multiline = false;
            this.EmailCustomTextBox.Name = "EmailCustomTextBox";
            this.EmailCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.EmailCustomTextBox.PasswordChar = false;
            this.EmailCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.EmailCustomTextBox.PlaceHolderText = "Enter Email Address";
            this.EmailCustomTextBox.ReadOnly = false;
            this.EmailCustomTextBox.Size = new System.Drawing.Size(228, 33);
            this.EmailCustomTextBox.TabIndex = 53;
            this.EmailCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EmailCustomTextBox.TextContent = "";
            this.EmailCustomTextBox.UnderlineStyle = true;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(103, 128);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(127, 18);
            this.EmailLabel.TabIndex = 52;
            this.EmailLabel.Text = "Email Address:";
            // 
            // CodeSenderCustomButton
            // 
            this.CodeSenderCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.CodeSenderCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.CodeSenderCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.CodeSenderCustomButton.BorderRadius = 10;
            this.CodeSenderCustomButton.BorderSize = 0;
            this.CodeSenderCustomButton.Circular = false;
            this.CodeSenderCustomButton.FlatAppearance.BorderSize = 0;
            this.CodeSenderCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CodeSenderCustomButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeSenderCustomButton.ForeColor = System.Drawing.Color.White;
            this.CodeSenderCustomButton.Location = new System.Drawing.Point(160, 190);
            this.CodeSenderCustomButton.Name = "CodeSenderCustomButton";
            this.CodeSenderCustomButton.Size = new System.Drawing.Size(110, 40);
            this.CodeSenderCustomButton.TabIndex = 54;
            this.CodeSenderCustomButton.Text = "Send Code";
            this.CodeSenderCustomButton.TextColor = System.Drawing.Color.White;
            this.CodeSenderCustomButton.UseVisualStyleBackColor = false;
            // 
            // passwordGeneratorControl1
            // 
            this.passwordGeneratorControl1.ConfirmPasswordVisible = true;
            this.passwordGeneratorControl1.Location = new System.Drawing.Point(103, 355);
            this.passwordGeneratorControl1.Name = "passwordGeneratorControl1";
            this.passwordGeneratorControl1.NewPasswordTextContent = "New Password";
            this.passwordGeneratorControl1.OldPasswordVisible = false;
            this.passwordGeneratorControl1.Size = new System.Drawing.Size(310, 135);
            this.passwordGeneratorControl1.TabIndex = 36;
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
            this.LoginReturnerCustomButton.Location = new System.Drawing.Point(10, 10);
            this.LoginReturnerCustomButton.Name = "LoginReturnerCustomButton";
            this.LoginReturnerCustomButton.Size = new System.Drawing.Size(60, 30);
            this.LoginReturnerCustomButton.TabIndex = 49;
            this.LoginReturnerCustomButton.TextColor = System.Drawing.Color.White;
            this.LoginReturnerCustomButton.UseVisualStyleBackColor = false;
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
            this.CodeCustomTextBox.Location = new System.Drawing.Point(160, 252);
            this.CodeCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CodeCustomTextBox.MaxLength = 32767;
            this.CodeCustomTextBox.Multiline = false;
            this.CodeCustomTextBox.Name = "CodeCustomTextBox";
            this.CodeCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CodeCustomTextBox.PasswordChar = false;
            this.CodeCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.CodeCustomTextBox.PlaceHolderText = "Enter Code";
            this.CodeCustomTextBox.ReadOnly = false;
            this.CodeCustomTextBox.Size = new System.Drawing.Size(156, 33);
            this.CodeCustomTextBox.TabIndex = 56;
            this.CodeCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CodeCustomTextBox.TextContent = "";
            this.CodeCustomTextBox.UnderlineStyle = true;
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeLabel.Location = new System.Drawing.Point(103, 252);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(55, 18);
            this.CodeLabel.TabIndex = 55;
            this.CodeLabel.Text = "Code:";
            // 
            // VerifycustomButton
            // 
            this.VerifycustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.VerifycustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.VerifycustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.VerifycustomButton.BorderRadius = 10;
            this.VerifycustomButton.BorderSize = 0;
            this.VerifycustomButton.Circular = false;
            this.VerifycustomButton.FlatAppearance.BorderSize = 0;
            this.VerifycustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerifycustomButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifycustomButton.ForeColor = System.Drawing.Color.White;
            this.VerifycustomButton.Location = new System.Drawing.Point(160, 309);
            this.VerifycustomButton.Name = "VerifycustomButton";
            this.VerifycustomButton.Size = new System.Drawing.Size(110, 40);
            this.VerifycustomButton.TabIndex = 57;
            this.VerifycustomButton.Text = "Verify";
            this.VerifycustomButton.TextColor = System.Drawing.Color.White;
            this.VerifycustomButton.UseVisualStyleBackColor = false;
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
            this.RestartCodeCustomButton.Location = new System.Drawing.Point(323, 252);
            this.RestartCodeCustomButton.Name = "RestartCodeCustomButton";
            this.RestartCodeCustomButton.Size = new System.Drawing.Size(40, 40);
            this.RestartCodeCustomButton.TabIndex = 58;
            this.RestartCodeCustomButton.TextColor = System.Drawing.Color.White;
            this.RestartCodeCustomButton.UseVisualStyleBackColor = false;
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
            this.PasswordReplacerCustomButton.Location = new System.Drawing.Point(125, 496);
            this.PasswordReplacerCustomButton.Name = "PasswordReplacerCustomButton";
            this.PasswordReplacerCustomButton.Size = new System.Drawing.Size(220, 40);
            this.PasswordReplacerCustomButton.TabIndex = 59;
            this.PasswordReplacerCustomButton.Text = "Change Password";
            this.PasswordReplacerCustomButton.TextColor = System.Drawing.Color.White;
            this.PasswordReplacerCustomButton.UseVisualStyleBackColor = false;
            // 
            // PasswordRestart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 536);
            this.Controls.Add(this.PasswordReplacerCustomButton);
            this.Controls.Add(this.RestartCodeCustomButton);
            this.Controls.Add(this.VerifycustomButton);
            this.Controls.Add(this.CodeCustomTextBox);
            this.Controls.Add(this.CodeLabel);
            this.Controls.Add(this.passwordGeneratorControl1);
            this.Controls.Add(this.CodeSenderCustomButton);
            this.Controls.Add(this.EmailCustomTextBox);
            this.Controls.Add(this.EmailLabel);
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
        private Controls.CustomTextBox EmailCustomTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private Controls.PasswordGeneratorControl passwordGeneratorControl1;
        private Controls.CustomButton CodeSenderCustomButton;
        private Controls.CustomTextBox CodeCustomTextBox;
        private System.Windows.Forms.Label CodeLabel;
        private Controls.CustomButton VerifycustomButton;
        private Controls.CustomButton RestartCodeCustomButton;
        private Controls.CustomButton PasswordReplacerCustomButton;
    }
}