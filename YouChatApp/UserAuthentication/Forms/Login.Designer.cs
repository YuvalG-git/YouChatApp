namespace YouChatApp.UserAuthentication.Forms
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
            this.LoginGroupBox = new System.Windows.Forms.GroupBox();
            this.LoginNewSmtpCodeSenderButton = new System.Windows.Forms.Button();
            this.CaptchaWordTestPanel = new System.Windows.Forms.Panel();
            this.CheckWordCaptchaButton = new System.Windows.Forms.Button();
            this.RestartCaptchaButton = new System.Windows.Forms.Button();
            this.CaptchaLoginLabel = new System.Windows.Forms.Label();
            this.CaptchaLoginTextBox = new System.Windows.Forms.TextBox();
            this.CaptchaLabel = new System.Windows.Forms.Label();
            this.LoginSmtpCodeVerifyButton = new System.Windows.Forms.Button();
            this.ResetPasswordFromLoginButton = new System.Windows.Forms.Button();
            this.LoginSmtpCodeTextBox = new System.Windows.Forms.TextBox();
            this.LoginCodeLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.ForgottenPasswordLabel = new System.Windows.Forms.Label();
            this.RegisterScreenButton = new System.Windows.Forms.Button();
            this.NoAccountLabel = new System.Windows.Forms.Label();
            this.CaptchaImageTestPanel = new System.Windows.Forms.Panel();
            this.CaptchaImageCheckerButton = new System.Windows.Forms.Button();
            this.CaptchaPicturesScoreLabel = new System.Windows.Forms.Label();
            this.CaptchaCircularPictureBox = new YouChatApp.CircularPictureBox();
            this.CaptchaPictureBox = new System.Windows.Forms.PictureBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.PasswordGeneratorControl = new YouChatApp.Controls.PasswordGeneratorControl();
            this.ResetPasswordCustomButton = new YouChatApp.Controls.CustomButton();
            this.LoginCustomButton = new YouChatApp.Controls.CustomButton();
            this.LoginGroupBox.SuspendLayout();
            this.CaptchaWordTestPanel.SuspendLayout();
            this.CaptchaImageTestPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaCircularPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginGroupBox
            // 
            this.LoginGroupBox.Controls.Add(this.LoginNewSmtpCodeSenderButton);
            this.LoginGroupBox.Controls.Add(this.CaptchaWordTestPanel);
            this.LoginGroupBox.Controls.Add(this.LoginSmtpCodeVerifyButton);
            this.LoginGroupBox.Controls.Add(this.ResetPasswordFromLoginButton);
            this.LoginGroupBox.Controls.Add(this.LoginSmtpCodeTextBox);
            this.LoginGroupBox.Controls.Add(this.LoginCodeLabel);
            this.LoginGroupBox.Controls.Add(this.loginButton);
            this.LoginGroupBox.Controls.Add(this.loginLabel);
            this.LoginGroupBox.Location = new System.Drawing.Point(530, 12);
            this.LoginGroupBox.Name = "LoginGroupBox";
            this.LoginGroupBox.Size = new System.Drawing.Size(245, 502);
            this.LoginGroupBox.TabIndex = 15;
            this.LoginGroupBox.TabStop = false;
            // 
            // LoginNewSmtpCodeSenderButton
            // 
            this.LoginNewSmtpCodeSenderButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.LoginNewSmtpCodeSenderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginNewSmtpCodeSenderButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.LoginNewSmtpCodeSenderButton.Location = new System.Drawing.Point(201, 266);
            this.LoginNewSmtpCodeSenderButton.Name = "LoginNewSmtpCodeSenderButton";
            this.LoginNewSmtpCodeSenderButton.Size = new System.Drawing.Size(40, 40);
            this.LoginNewSmtpCodeSenderButton.TabIndex = 40;
            this.LoginNewSmtpCodeSenderButton.UseMnemonic = false;
            this.LoginNewSmtpCodeSenderButton.UseVisualStyleBackColor = true;
            this.LoginNewSmtpCodeSenderButton.Visible = false;
            // 
            // CaptchaWordTestPanel
            // 
            this.CaptchaWordTestPanel.Controls.Add(this.CheckWordCaptchaButton);
            this.CaptchaWordTestPanel.Controls.Add(this.RestartCaptchaButton);
            this.CaptchaWordTestPanel.Controls.Add(this.CaptchaLoginLabel);
            this.CaptchaWordTestPanel.Controls.Add(this.CaptchaLoginTextBox);
            this.CaptchaWordTestPanel.Controls.Add(this.CaptchaLabel);
            this.CaptchaWordTestPanel.Location = new System.Drawing.Point(6, 350);
            this.CaptchaWordTestPanel.Name = "CaptchaWordTestPanel";
            this.CaptchaWordTestPanel.Size = new System.Drawing.Size(239, 140);
            this.CaptchaWordTestPanel.TabIndex = 37;
            this.CaptchaWordTestPanel.Visible = false;
            // 
            // CheckWordCaptchaButton
            // 
            this.CheckWordCaptchaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckWordCaptchaButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.CheckWordCaptchaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckWordCaptchaButton.Location = new System.Drawing.Point(31, 96);
            this.CheckWordCaptchaButton.Name = "CheckWordCaptchaButton";
            this.CheckWordCaptchaButton.Size = new System.Drawing.Size(170, 41);
            this.CheckWordCaptchaButton.TabIndex = 37;
            this.CheckWordCaptchaButton.Text = "Check Captcha";
            this.CheckWordCaptchaButton.UseVisualStyleBackColor = true;
            // 
            // RestartCaptchaButton
            // 
            this.RestartCaptchaButton.BackgroundImage = global::YouChatApp.Properties.Resources.Restart;
            this.RestartCaptchaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RestartCaptchaButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RestartCaptchaButton.Location = new System.Drawing.Point(193, 3);
            this.RestartCaptchaButton.Name = "RestartCaptchaButton";
            this.RestartCaptchaButton.Size = new System.Drawing.Size(40, 40);
            this.RestartCaptchaButton.TabIndex = 23;
            this.RestartCaptchaButton.UseMnemonic = false;
            this.RestartCaptchaButton.UseVisualStyleBackColor = true;
            // 
            // CaptchaLoginLabel
            // 
            this.CaptchaLoginLabel.AutoSize = true;
            this.CaptchaLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaLoginLabel.Location = new System.Drawing.Point(7, 75);
            this.CaptchaLoginLabel.Name = "CaptchaLoginLabel";
            this.CaptchaLoginLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CaptchaLoginLabel.Size = new System.Drawing.Size(88, 20);
            this.CaptchaLoginLabel.TabIndex = 21;
            this.CaptchaLoginLabel.Text = "CAPTCHA:";
            // 
            // CaptchaLoginTextBox
            // 
            this.CaptchaLoginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaLoginTextBox.Location = new System.Drawing.Point(128, 70);
            this.CaptchaLoginTextBox.Name = "CaptchaLoginTextBox";
            this.CaptchaLoginTextBox.PasswordChar = '*';
            this.CaptchaLoginTextBox.Size = new System.Drawing.Size(90, 22);
            this.CaptchaLoginTextBox.TabIndex = 22;
            // 
            // CaptchaLabel
            // 
            this.CaptchaLabel.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaLabel.Location = new System.Drawing.Point(3, 0);
            this.CaptchaLabel.Name = "CaptchaLabel";
            this.CaptchaLabel.Size = new System.Drawing.Size(200, 50);
            this.CaptchaLabel.TabIndex = 20;
            this.CaptchaLabel.Text = "captcha";
            this.CaptchaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginSmtpCodeVerifyButton
            // 
            this.LoginSmtpCodeVerifyButton.Enabled = false;
            this.LoginSmtpCodeVerifyButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LoginSmtpCodeVerifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginSmtpCodeVerifyButton.Location = new System.Drawing.Point(76, 306);
            this.LoginSmtpCodeVerifyButton.Name = "LoginSmtpCodeVerifyButton";
            this.LoginSmtpCodeVerifyButton.Size = new System.Drawing.Size(94, 32);
            this.LoginSmtpCodeVerifyButton.TabIndex = 38;
            this.LoginSmtpCodeVerifyButton.Text = "Verify";
            this.LoginSmtpCodeVerifyButton.UseVisualStyleBackColor = true;
            this.LoginSmtpCodeVerifyButton.Visible = false;
            // 
            // ResetPasswordFromLoginButton
            // 
            this.ResetPasswordFromLoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ResetPasswordFromLoginButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ResetPasswordFromLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetPasswordFromLoginButton.Location = new System.Drawing.Point(37, 162);
            this.ResetPasswordFromLoginButton.Name = "ResetPasswordFromLoginButton";
            this.ResetPasswordFromLoginButton.Size = new System.Drawing.Size(170, 47);
            this.ResetPasswordFromLoginButton.TabIndex = 25;
            this.ResetPasswordFromLoginButton.Text = "Reset Password";
            this.ResetPasswordFromLoginButton.UseVisualStyleBackColor = true;
            // 
            // LoginSmtpCodeTextBox
            // 
            this.LoginSmtpCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginSmtpCodeTextBox.Location = new System.Drawing.Point(61, 273);
            this.LoginSmtpCodeTextBox.Name = "LoginSmtpCodeTextBox";
            this.LoginSmtpCodeTextBox.Size = new System.Drawing.Size(134, 22);
            this.LoginSmtpCodeTextBox.TabIndex = 36;
            this.LoginSmtpCodeTextBox.Visible = false;
            // 
            // LoginCodeLabel
            // 
            this.LoginCodeLabel.AutoSize = true;
            this.LoginCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginCodeLabel.Location = new System.Drawing.Point(3, 273);
            this.LoginCodeLabel.Name = "LoginCodeLabel";
            this.LoginCodeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoginCodeLabel.Size = new System.Drawing.Size(51, 20);
            this.LoginCodeLabel.TabIndex = 37;
            this.LoginCodeLabel.Text = "Code:";
            this.LoginCodeLabel.Visible = false;
            // 
            // loginButton
            // 
            this.loginButton.Enabled = false;
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(80, 215);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(90, 32);
            this.loginButton.TabIndex = 13;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.Location = new System.Drawing.Point(69, 16);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(99, 31);
            this.loginLabel.TabIndex = 1;
            this.loginLabel.Text = "LOGIN";
            // 
            // ForgottenPasswordLabel
            // 
            this.ForgottenPasswordLabel.AutoSize = true;
            this.ForgottenPasswordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgottenPasswordLabel.Location = new System.Drawing.Point(153, 223);
            this.ForgottenPasswordLabel.Name = "ForgottenPasswordLabel";
            this.ForgottenPasswordLabel.Size = new System.Drawing.Size(263, 34);
            this.ForgottenPasswordLabel.TabIndex = 24;
            this.ForgottenPasswordLabel.Text = "Forgot Your Password?\r\nTo reset the password, press here!\r\n";
            // 
            // RegisterScreenButton
            // 
            this.RegisterScreenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterScreenButton.Location = new System.Drawing.Point(276, 622);
            this.RegisterScreenButton.Name = "RegisterScreenButton";
            this.RegisterScreenButton.Size = new System.Drawing.Size(90, 32);
            this.RegisterScreenButton.TabIndex = 17;
            this.RegisterScreenButton.Text = "Sign Up";
            this.RegisterScreenButton.UseVisualStyleBackColor = true;
            // 
            // NoAccountLabel
            // 
            this.NoAccountLabel.AutoSize = true;
            this.NoAccountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoAccountLabel.Location = new System.Drawing.Point(300, 575);
            this.NoAccountLabel.Name = "NoAccountLabel";
            this.NoAccountLabel.Size = new System.Drawing.Size(146, 32);
            this.NoAccountLabel.TabIndex = 14;
            this.NoAccountLabel.Text = "Don\'t have an account?\r\nSign up here!";
            // 
            // CaptchaImageTestPanel
            // 
            this.CaptchaImageTestPanel.Controls.Add(this.CaptchaImageCheckerButton);
            this.CaptchaImageTestPanel.Controls.Add(this.CaptchaPicturesScoreLabel);
            this.CaptchaImageTestPanel.Controls.Add(this.CaptchaCircularPictureBox);
            this.CaptchaImageTestPanel.Controls.Add(this.CaptchaPictureBox);
            this.CaptchaImageTestPanel.Location = new System.Drawing.Point(26, 458);
            this.CaptchaImageTestPanel.Name = "CaptchaImageTestPanel";
            this.CaptchaImageTestPanel.Size = new System.Drawing.Size(221, 220);
            this.CaptchaImageTestPanel.TabIndex = 41;
            this.CaptchaImageTestPanel.Visible = false;
            // 
            // CaptchaImageCheckerButton
            // 
            this.CaptchaImageCheckerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CaptchaImageCheckerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.CaptchaImageCheckerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaImageCheckerButton.Location = new System.Drawing.Point(19, 173);
            this.CaptchaImageCheckerButton.Name = "CaptchaImageCheckerButton";
            this.CaptchaImageCheckerButton.Size = new System.Drawing.Size(170, 47);
            this.CaptchaImageCheckerButton.TabIndex = 26;
            this.CaptchaImageCheckerButton.Text = "Check Captcha";
            this.CaptchaImageCheckerButton.UseVisualStyleBackColor = true;
            // 
            // CaptchaPicturesScoreLabel
            // 
            this.CaptchaPicturesScoreLabel.AutoSize = true;
            this.CaptchaPicturesScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaPicturesScoreLabel.Location = new System.Drawing.Point(3, 156);
            this.CaptchaPicturesScoreLabel.Name = "CaptchaPicturesScoreLabel";
            this.CaptchaPicturesScoreLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CaptchaPicturesScoreLabel.Size = new System.Drawing.Size(55, 20);
            this.CaptchaPicturesScoreLabel.TabIndex = 26;
            this.CaptchaPicturesScoreLabel.Text = "Score:";
            // 
            // CaptchaCircularPictureBox
            // 
            this.CaptchaCircularPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptchaCircularPictureBox.BorderColor = System.Drawing.Color.Gray;
            this.CaptchaCircularPictureBox.BorderSize = 1;
            this.CaptchaCircularPictureBox.HasBorder = false;
            this.CaptchaCircularPictureBox.Location = new System.Drawing.Point(30, 15);
            this.CaptchaCircularPictureBox.Name = "CaptchaCircularPictureBox";
            this.CaptchaCircularPictureBox.Size = new System.Drawing.Size(150, 150);
            this.CaptchaCircularPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CaptchaCircularPictureBox.TabIndex = 35;
            this.CaptchaCircularPictureBox.TabStop = false;
            // 
            // CaptchaPictureBox
            // 
            this.CaptchaPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptchaPictureBox.Location = new System.Drawing.Point(30, 15);
            this.CaptchaPictureBox.Name = "CaptchaPictureBox";
            this.CaptchaPictureBox.Size = new System.Drawing.Size(150, 150);
            this.CaptchaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CaptchaPictureBox.TabIndex = 36;
            this.CaptchaPictureBox.TabStop = false;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(153, 77);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(95, 18);
            this.UsernameLabel.TabIndex = 42;
            this.UsernameLabel.Text = "Username:";
            // 
            // UsernameCustomTextBox
            // 
            this.UsernameCustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.UsernameCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.UsernameCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.UsernameCustomTextBox.BorderRadius = 0;
            this.UsernameCustomTextBox.BorderSize = 2;
            this.UsernameCustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UsernameCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.UsernameCustomTextBox.IsFocused = false;
            this.UsernameCustomTextBox.Location = new System.Drawing.Point(156, 98);
            this.UsernameCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.UsernameCustomTextBox.MaxLength = 32767;
            this.UsernameCustomTextBox.Multiline = false;
            this.UsernameCustomTextBox.Name = "UsernameCustomTextBox";
            this.UsernameCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.UsernameCustomTextBox.PasswordChar = false;
            this.UsernameCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.UsernameCustomTextBox.PlaceHolderText = "Enter Username";
            this.UsernameCustomTextBox.ReadOnly = false;
            this.UsernameCustomTextBox.Size = new System.Drawing.Size(228, 31);
            this.UsernameCustomTextBox.TabIndex = 43;
            this.UsernameCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernameCustomTextBox.TextContent = "";
            this.UsernameCustomTextBox.UnderlineStyle = true;
            // 
            // PasswordGeneratorControl
            // 
            this.PasswordGeneratorControl.ConfirmPasswordVisible = false;
            this.PasswordGeneratorControl.Location = new System.Drawing.Point(146, 141);
            this.PasswordGeneratorControl.Name = "PasswordGeneratorControl";
            this.PasswordGeneratorControl.NewPasswordTextContent = "Password";
            this.PasswordGeneratorControl.OldPasswordVisible = false;
            this.PasswordGeneratorControl.Size = new System.Drawing.Size(310, 72);
            this.PasswordGeneratorControl.TabIndex = 44;
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
            this.ResetPasswordCustomButton.Location = new System.Drawing.Point(190, 285);
            this.ResetPasswordCustomButton.Name = "ResetPasswordCustomButton";
            this.ResetPasswordCustomButton.Size = new System.Drawing.Size(150, 40);
            this.ResetPasswordCustomButton.TabIndex = 38;
            this.ResetPasswordCustomButton.Text = "Reset Password";
            this.ResetPasswordCustomButton.TextColor = System.Drawing.Color.White;
            this.ResetPasswordCustomButton.UseVisualStyleBackColor = false;
            // 
            // LoginCustomButton
            // 
            this.LoginCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.LoginCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.LoginCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.LoginCustomButton.BorderRadius = 10;
            this.LoginCustomButton.BorderSize = 0;
            this.LoginCustomButton.Circular = false;
            this.LoginCustomButton.FlatAppearance.BorderSize = 0;
            this.LoginCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginCustomButton.ForeColor = System.Drawing.Color.White;
            this.LoginCustomButton.Location = new System.Drawing.Point(190, 331);
            this.LoginCustomButton.Name = "LoginCustomButton";
            this.LoginCustomButton.Size = new System.Drawing.Size(150, 40);
            this.LoginCustomButton.TabIndex = 45;
            this.LoginCustomButton.Text = "Login";
            this.LoginCustomButton.TextColor = System.Drawing.Color.White;
            this.LoginCustomButton.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 689);
            this.Controls.Add(this.LoginCustomButton);
            this.Controls.Add(this.ResetPasswordCustomButton);
            this.Controls.Add(this.PasswordGeneratorControl);
            this.Controls.Add(this.UsernameCustomTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.CaptchaImageTestPanel);
            this.Controls.Add(this.LoginGroupBox);
            this.Controls.Add(this.NoAccountLabel);
            this.Controls.Add(this.ForgottenPasswordLabel);
            this.Controls.Add(this.RegisterScreenButton);
            this.Name = "Login";
            this.Text = "Login";
            this.LoginGroupBox.ResumeLayout(false);
            this.LoginGroupBox.PerformLayout();
            this.CaptchaWordTestPanel.ResumeLayout(false);
            this.CaptchaWordTestPanel.PerformLayout();
            this.CaptchaImageTestPanel.ResumeLayout(false);
            this.CaptchaImageTestPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaCircularPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox LoginGroupBox;
        private System.Windows.Forms.Button LoginNewSmtpCodeSenderButton;
        private System.Windows.Forms.Panel CaptchaWordTestPanel;
        public System.Windows.Forms.Button CheckWordCaptchaButton;
        private System.Windows.Forms.Button RestartCaptchaButton;
        public System.Windows.Forms.Label CaptchaLoginLabel;
        public System.Windows.Forms.TextBox CaptchaLoginTextBox;
        private System.Windows.Forms.Label CaptchaLabel;
        public System.Windows.Forms.Button LoginSmtpCodeVerifyButton;
        public System.Windows.Forms.Button ResetPasswordFromLoginButton;
        public System.Windows.Forms.TextBox LoginSmtpCodeTextBox;
        public System.Windows.Forms.Label LoginCodeLabel;
        private System.Windows.Forms.Label ForgottenPasswordLabel;
        private System.Windows.Forms.Button RegisterScreenButton;
        private System.Windows.Forms.Label NoAccountLabel;
        public System.Windows.Forms.Button loginButton;
        public System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Panel CaptchaImageTestPanel;
        public System.Windows.Forms.Button CaptchaImageCheckerButton;
        public System.Windows.Forms.Label CaptchaPicturesScoreLabel;
        private CircularPictureBox CaptchaCircularPictureBox;
        private System.Windows.Forms.PictureBox CaptchaPictureBox;
        private System.Windows.Forms.Label UsernameLabel;
        private Controls.CustomTextBox UsernameCustomTextBox;
        private Controls.PasswordGeneratorControl PasswordGeneratorControl;
        private Controls.CustomButton ResetPasswordCustomButton;
        private Controls.CustomButton LoginCustomButton;
    }
}