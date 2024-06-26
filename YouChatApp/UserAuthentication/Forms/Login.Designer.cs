﻿namespace YouChatApp.UserAuthentication.Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.ForgottenPasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SignUpLabel = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.BanControl = new YouChatApp.Controls.BanControl();
            this.SmtpControl = new YouChatApp.Controls.SmtpControl();
            this.PersonalVerificationAnswersControl = new YouChatApp.Controls.PersonalVerificationAnswersControl();
            this.SignUpCustomButton = new YouChatApp.Controls.CustomButton();
            this.CaptchaRotatingImageControl = new YouChatApp.Controls.CaptchaRotatingImageControl();
            this.CaptchaCodeControl = new YouChatApp.Controls.CaptchaCodeControl();
            this.LoginCustomButton = new YouChatApp.Controls.CustomButton();
            this.ResetPasswordCustomButton = new YouChatApp.Controls.CustomButton();
            this.PasswordGeneratorControl = new YouChatApp.Controls.PasswordGeneratorControl();
            this.UsernameCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ForgottenPasswordLabel
            // 
            this.ForgottenPasswordLabel.AutoSize = true;
            this.ForgottenPasswordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgottenPasswordLabel.Location = new System.Drawing.Point(10, 168);
            this.ForgottenPasswordLabel.Name = "ForgottenPasswordLabel";
            this.ForgottenPasswordLabel.Size = new System.Drawing.Size(263, 34);
            this.ForgottenPasswordLabel.TabIndex = 24;
            this.ForgottenPasswordLabel.Text = "Forgot Your Password?\r\nTo reset the password, press here!\r\n";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(10, 22);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(95, 18);
            this.UsernameLabel.TabIndex = 42;
            this.UsernameLabel.Text = "Username:";
            // 
            // SignUpLabel
            // 
            this.SignUpLabel.AutoSize = true;
            this.SignUpLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpLabel.Location = new System.Drawing.Point(10, 340);
            this.SignUpLabel.Name = "SignUpLabel";
            this.SignUpLabel.Size = new System.Drawing.Size(179, 34);
            this.SignUpLabel.TabIndex = 49;
            this.SignUpLabel.Text = "Don\'t have an account?\r\nSign up here!\r\n";
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.Location = new System.Drawing.Point(370, 28);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(139, 43);
            this.LoginLabel.TabIndex = 50;
            this.LoginLabel.Text = "LOGIN";
            // 
            // BanControl
            // 
            this.BanControl.AutoSize = true;
            this.BanControl.Location = new System.Drawing.Point(771, 54);
            this.BanControl.Name = "BanControl";
            this.BanControl.Size = new System.Drawing.Size(400, 400);
            this.BanControl.TabIndex = 53;
            this.BanControl.Visible = false;
            // 
            // SmtpControl
            // 
            this.SmtpControl.Location = new System.Drawing.Point(802, 12);
            this.SmtpControl.Name = "SmtpControl";
            this.SmtpControl.Size = new System.Drawing.Size(350, 190);
            this.SmtpControl.TabIndex = 52;
            this.SmtpControl.Visible = false;
            // 
            // PersonalVerificationAnswersControl
            // 
            this.PersonalVerificationAnswersControl.Location = new System.Drawing.Point(781, 169);
            this.PersonalVerificationAnswersControl.MaximumSize = new System.Drawing.Size(400, 380);
            this.PersonalVerificationAnswersControl.MinimumSize = new System.Drawing.Size(400, 380);
            this.PersonalVerificationAnswersControl.Name = "PersonalVerificationAnswersControl";
            this.PersonalVerificationAnswersControl.Size = new System.Drawing.Size(400, 380);
            this.PersonalVerificationAnswersControl.TabIndex = 51;
            this.PersonalVerificationAnswersControl.Visible = false;
            // 
            // SignUpCustomButton
            // 
            this.SignUpCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.SignUpCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.SignUpCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.SignUpCustomButton.BorderRadius = 10;
            this.SignUpCustomButton.BorderSize = 0;
            this.SignUpCustomButton.Circular = false;
            this.SignUpCustomButton.FlatAppearance.BorderSize = 0;
            this.SignUpCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignUpCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpCustomButton.ForeColor = System.Drawing.Color.White;
            this.SignUpCustomButton.Location = new System.Drawing.Point(47, 377);
            this.SignUpCustomButton.Name = "SignUpCustomButton";
            this.SignUpCustomButton.Size = new System.Drawing.Size(150, 40);
            this.SignUpCustomButton.TabIndex = 48;
            this.SignUpCustomButton.Text = "Sign Up";
            this.SignUpCustomButton.TextColor = System.Drawing.Color.White;
            this.SignUpCustomButton.UseVisualStyleBackColor = false;
            this.SignUpCustomButton.Click += new System.EventHandler(this.SignUpCustomButton_Click);
            // 
            // CaptchaRotatingImageControl
            // 
            this.CaptchaRotatingImageControl.AutoSize = true;
            this.CaptchaRotatingImageControl.Location = new System.Drawing.Point(496, 307);
            this.CaptchaRotatingImageControl.Name = "CaptchaRotatingImageControl";
            this.CaptchaRotatingImageControl.Size = new System.Drawing.Size(260, 330);
            this.CaptchaRotatingImageControl.TabIndex = 47;
            this.CaptchaRotatingImageControl.Visible = false;
            // 
            // CaptchaCodeControl
            // 
            this.CaptchaCodeControl.AutoSize = true;
            this.CaptchaCodeControl.Location = new System.Drawing.Point(515, 28);
            this.CaptchaCodeControl.Name = "CaptchaCodeControl";
            this.CaptchaCodeControl.Size = new System.Drawing.Size(260, 273);
            this.CaptchaCodeControl.TabIndex = 46;
            this.CaptchaCodeControl.Visible = false;
            // 
            // LoginCustomButton
            // 
            this.LoginCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.LoginCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.LoginCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.LoginCustomButton.BorderRadius = 10;
            this.LoginCustomButton.BorderSize = 0;
            this.LoginCustomButton.Circular = false;
            this.LoginCustomButton.Enabled = false;
            this.LoginCustomButton.FlatAppearance.BorderSize = 0;
            this.LoginCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginCustomButton.ForeColor = System.Drawing.Color.White;
            this.LoginCustomButton.Location = new System.Drawing.Point(47, 276);
            this.LoginCustomButton.Name = "LoginCustomButton";
            this.LoginCustomButton.Size = new System.Drawing.Size(150, 40);
            this.LoginCustomButton.TabIndex = 45;
            this.LoginCustomButton.Text = "Login";
            this.LoginCustomButton.TextColor = System.Drawing.Color.White;
            this.LoginCustomButton.UseVisualStyleBackColor = false;
            this.LoginCustomButton.Click += new System.EventHandler(this.LoginCustomButton_Click);
            // 
            // ResetPasswordCustomButton
            // 
            this.ResetPasswordCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ResetPasswordCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.ResetPasswordCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ResetPasswordCustomButton.BorderRadius = 10;
            this.ResetPasswordCustomButton.BorderSize = 0;
            this.ResetPasswordCustomButton.Circular = false;
            this.ResetPasswordCustomButton.FlatAppearance.BorderSize = 0;
            this.ResetPasswordCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetPasswordCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetPasswordCustomButton.ForeColor = System.Drawing.Color.White;
            this.ResetPasswordCustomButton.Location = new System.Drawing.Point(47, 230);
            this.ResetPasswordCustomButton.Name = "ResetPasswordCustomButton";
            this.ResetPasswordCustomButton.Size = new System.Drawing.Size(150, 40);
            this.ResetPasswordCustomButton.TabIndex = 38;
            this.ResetPasswordCustomButton.Text = "Reset Password";
            this.ResetPasswordCustomButton.TextColor = System.Drawing.Color.White;
            this.ResetPasswordCustomButton.UseVisualStyleBackColor = false;
            this.ResetPasswordCustomButton.Click += new System.EventHandler(this.ResetPasswordCustomButton_Click);
            // 
            // PasswordGeneratorControl
            // 
            this.PasswordGeneratorControl.ConfirmPasswordVisible = false;
            this.PasswordGeneratorControl.Location = new System.Drawing.Point(3, 86);
            this.PasswordGeneratorControl.Name = "PasswordGeneratorControl";
            this.PasswordGeneratorControl.NewPasswordTextContent = "Password";
            this.PasswordGeneratorControl.OldPasswordVisible = false;
            this.PasswordGeneratorControl.PasswordExclamationVisible = false;
            this.PasswordGeneratorControl.Size = new System.Drawing.Size(310, 72);
            this.PasswordGeneratorControl.TabIndex = 44;
            this.PasswordGeneratorControl.TextChangedEvent += new System.EventHandler(this.LoginFieldsTextChangedEvent);
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
            this.UsernameCustomTextBox.Location = new System.Drawing.Point(13, 43);
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
            this.UsernameCustomTextBox.TabIndex = 43;
            this.UsernameCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernameCustomTextBox.TextContent = "";
            this.UsernameCustomTextBox.UnderlineStyle = true;
            this.UsernameCustomTextBox.TextChangedEvent += new System.EventHandler(this.LoginFieldsTextChangedEvent);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.PasswordGeneratorControl);
            this.LoginPanel.Controls.Add(this.ForgottenPasswordLabel);
            this.LoginPanel.Controls.Add(this.UsernameLabel);
            this.LoginPanel.Controls.Add(this.UsernameCustomTextBox);
            this.LoginPanel.Controls.Add(this.ResetPasswordCustomButton);
            this.LoginPanel.Controls.Add(this.SignUpLabel);
            this.LoginPanel.Controls.Add(this.LoginCustomButton);
            this.LoginPanel.Controls.Add(this.SignUpCustomButton);
            this.LoginPanel.Location = new System.Drawing.Point(99, 112);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(349, 470);
            this.LoginPanel.TabIndex = 54;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 689);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.SmtpControl);
            this.Controls.Add(this.PersonalVerificationAnswersControl);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.CaptchaRotatingImageControl);
            this.Controls.Add(this.CaptchaCodeControl);
            this.Controls.Add(this.BanControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ForgottenPasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private Controls.CustomTextBox UsernameCustomTextBox;
        private Controls.PasswordGeneratorControl PasswordGeneratorControl;
        private Controls.CustomButton ResetPasswordCustomButton;
        private Controls.CustomButton LoginCustomButton;
        private Controls.CaptchaCodeControl CaptchaCodeControl;
        private Controls.CaptchaRotatingImageControl CaptchaRotatingImageControl;
        private Controls.CustomButton SignUpCustomButton;
        private System.Windows.Forms.Label SignUpLabel;
        public System.Windows.Forms.Label LoginLabel;
        private Controls.PersonalVerificationAnswersControl PersonalVerificationAnswersControl;
        private Controls.SmtpControl SmtpControl;
        private Controls.BanControl BanControl;
        private System.Windows.Forms.Panel LoginPanel;
    }
}