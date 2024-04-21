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
            this.PasswordReplacerCustomButton = new YouChatApp.Controls.CustomButton();
            this.PasswordGeneratorControl = new YouChatApp.Controls.PasswordGeneratorControl();
            this.CodeSenderCustomButton = new YouChatApp.Controls.CustomButton();
            this.EmailAddressCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.UsernameCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.LoginReturnerCustomButton = new YouChatApp.Controls.CustomButton();
            this.SmtpControl = new YouChatApp.Controls.SmtpControl();
            this.PasswordResetPanel = new System.Windows.Forms.Panel();
            this.BanControl = new YouChatApp.Controls.BanControl();
            this.PasswordResetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResetPasswordLabel
            // 
            this.ResetPasswordLabel.AutoSize = true;
            this.ResetPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetPasswordLabel.Location = new System.Drawing.Point(101, 26);
            this.ResetPasswordLabel.Name = "ResetPasswordLabel";
            this.ResetPasswordLabel.Size = new System.Drawing.Size(270, 31);
            this.ResetPasswordLabel.TabIndex = 1;
            this.ResetPasswordLabel.Text = "RESET PASSWORD";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(31, 86);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(95, 18);
            this.UsernameLabel.TabIndex = 50;
            this.UsernameLabel.Text = "Username:";
            // 
            // EmailAddressLabel
            // 
            this.EmailAddressLabel.AutoSize = true;
            this.EmailAddressLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailAddressLabel.Location = new System.Drawing.Point(31, 156);
            this.EmailAddressLabel.Name = "EmailAddressLabel";
            this.EmailAddressLabel.Size = new System.Drawing.Size(127, 18);
            this.EmailAddressLabel.TabIndex = 52;
            this.EmailAddressLabel.Text = "Email Address:";
            // 
            // PasswordReplacerCustomButton
            // 
            this.PasswordReplacerCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.PasswordReplacerCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.PasswordReplacerCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.PasswordReplacerCustomButton.BorderRadius = 10;
            this.PasswordReplacerCustomButton.BorderSize = 0;
            this.PasswordReplacerCustomButton.Circular = false;
            this.PasswordReplacerCustomButton.Enabled = false;
            this.PasswordReplacerCustomButton.FlatAppearance.BorderSize = 0;
            this.PasswordReplacerCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordReplacerCustomButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordReplacerCustomButton.ForeColor = System.Drawing.Color.White;
            this.PasswordReplacerCustomButton.Location = new System.Drawing.Point(81, 614);
            this.PasswordReplacerCustomButton.Name = "PasswordReplacerCustomButton";
            this.PasswordReplacerCustomButton.Size = new System.Drawing.Size(220, 40);
            this.PasswordReplacerCustomButton.TabIndex = 59;
            this.PasswordReplacerCustomButton.Text = "Change Password";
            this.PasswordReplacerCustomButton.TextColor = System.Drawing.Color.White;
            this.PasswordReplacerCustomButton.UseVisualStyleBackColor = false;
            this.PasswordReplacerCustomButton.Click += new System.EventHandler(this.PasswordReplacerCustomButton_Click);
            // 
            // PasswordGeneratorControl
            // 
            this.PasswordGeneratorControl.ConfirmPasswordVisible = true;
            this.PasswordGeneratorControl.Enabled = false;
            this.PasswordGeneratorControl.Location = new System.Drawing.Point(21, 474);
            this.PasswordGeneratorControl.Name = "PasswordGeneratorControl";
            this.PasswordGeneratorControl.NewPasswordTextContent = "New Password";
            this.PasswordGeneratorControl.OldPasswordVisible = false;
            this.PasswordGeneratorControl.PasswordExclamationVisible = true;
            this.PasswordGeneratorControl.Size = new System.Drawing.Size(335, 135);
            this.PasswordGeneratorControl.TabIndex = 36;
            this.PasswordGeneratorControl.Load += new System.EventHandler(this.PasswordGeneratorControl_Load);
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
            this.CodeSenderCustomButton.Location = new System.Drawing.Point(141, 221);
            this.CodeSenderCustomButton.Name = "CodeSenderCustomButton";
            this.CodeSenderCustomButton.Size = new System.Drawing.Size(110, 40);
            this.CodeSenderCustomButton.TabIndex = 54;
            this.CodeSenderCustomButton.Text = "Send Code";
            this.CodeSenderCustomButton.TextColor = System.Drawing.Color.White;
            this.CodeSenderCustomButton.UseVisualStyleBackColor = false;
            this.CodeSenderCustomButton.Click += new System.EventHandler(this.CodeSenderCustomButton_Click);
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
            this.EmailAddressCustomTextBox.Location = new System.Drawing.Point(31, 176);
            this.EmailAddressCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.EmailAddressCustomTextBox.MaxLength = 32767;
            this.EmailAddressCustomTextBox.Multiline = false;
            this.EmailAddressCustomTextBox.Name = "EmailAddressCustomTextBox";
            this.EmailAddressCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.EmailAddressCustomTextBox.PasswordChar = false;
            this.EmailAddressCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.EmailAddressCustomTextBox.PlaceHolderText = "Enter Email Address";
            this.EmailAddressCustomTextBox.ReadOnly = false;
            this.EmailAddressCustomTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.EmailAddressCustomTextBox.ShortcutsEnabled = true;
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
            this.UsernameCustomTextBox.Location = new System.Drawing.Point(31, 106);
            this.UsernameCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.UsernameCustomTextBox.MaxLength = 32767;
            this.UsernameCustomTextBox.Multiline = false;
            this.UsernameCustomTextBox.Name = "UsernameCustomTextBox";
            this.UsernameCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.UsernameCustomTextBox.PasswordChar = false;
            this.UsernameCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.UsernameCustomTextBox.PlaceHolderText = "Enter Username";
            this.UsernameCustomTextBox.ReadOnly = false;
            this.UsernameCustomTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UsernameCustomTextBox.ShortcutsEnabled = true;
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
            this.LoginReturnerCustomButton.Location = new System.Drawing.Point(21, 26);
            this.LoginReturnerCustomButton.Name = "LoginReturnerCustomButton";
            this.LoginReturnerCustomButton.Size = new System.Drawing.Size(60, 30);
            this.LoginReturnerCustomButton.TabIndex = 49;
            this.LoginReturnerCustomButton.TextColor = System.Drawing.Color.White;
            this.LoginReturnerCustomButton.UseVisualStyleBackColor = false;
            this.LoginReturnerCustomButton.Click += new System.EventHandler(this.LoginReturnerCustomButton_Click);
            // 
            // SmtpControl
            // 
            this.SmtpControl.Location = new System.Drawing.Point(21, 267);
            this.SmtpControl.Name = "SmtpControl";
            this.SmtpControl.Size = new System.Drawing.Size(350, 200);
            this.SmtpControl.TabIndex = 60;
            // 
            // PasswordResetPanel
            // 
            this.PasswordResetPanel.Controls.Add(this.PasswordReplacerCustomButton);
            this.PasswordResetPanel.Controls.Add(this.SmtpControl);
            this.PasswordResetPanel.Controls.Add(this.ResetPasswordLabel);
            this.PasswordResetPanel.Controls.Add(this.LoginReturnerCustomButton);
            this.PasswordResetPanel.Controls.Add(this.PasswordGeneratorControl);
            this.PasswordResetPanel.Controls.Add(this.UsernameLabel);
            this.PasswordResetPanel.Controls.Add(this.CodeSenderCustomButton);
            this.PasswordResetPanel.Controls.Add(this.UsernameCustomTextBox);
            this.PasswordResetPanel.Controls.Add(this.EmailAddressCustomTextBox);
            this.PasswordResetPanel.Controls.Add(this.EmailAddressLabel);
            this.PasswordResetPanel.Location = new System.Drawing.Point(51, 1);
            this.PasswordResetPanel.Name = "PasswordResetPanel";
            this.PasswordResetPanel.Size = new System.Drawing.Size(426, 661);
            this.PasswordResetPanel.TabIndex = 61;
            // 
            // BanControl
            // 
            this.BanControl.AutoSize = true;
            this.BanControl.Location = new System.Drawing.Point(505, 87);
            this.BanControl.Name = "BanControl";
            this.BanControl.Size = new System.Drawing.Size(400, 400);
            this.BanControl.TabIndex = 62;
            this.BanControl.Visible = false;
            // 
            // PasswordRestart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 655);
            this.Controls.Add(this.BanControl);
            this.Controls.Add(this.PasswordResetPanel);
            this.Name = "PasswordRestart";
            this.Text = "PasswordReset";
            this.PasswordResetPanel.ResumeLayout(false);
            this.PasswordResetPanel.PerformLayout();
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
        private Controls.CustomButton PasswordReplacerCustomButton;
        private Controls.SmtpControl SmtpControl;
        private System.Windows.Forms.Panel PasswordResetPanel;
        private Controls.BanControl BanControl;
    }
}