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
            this.ForgottenPasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.LoginCustomButton = new YouChatApp.Controls.CustomButton();
            this.ResetPasswordCustomButton = new YouChatApp.Controls.CustomButton();
            this.PasswordGeneratorControl = new YouChatApp.Controls.PasswordGeneratorControl();
            this.UsernameCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.captchaCodeControl1 = new YouChatApp.Controls.CaptchaCodeControl();
            this.captchaRotatingImageControl1 = new YouChatApp.Controls.CaptchaRotatingImageControl();
            this.SignUpCustomButton = new YouChatApp.Controls.CustomButton();
            this.SignUpLabel = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.personalVerificationAnswersControl1 = new YouChatApp.Controls.PersonalVerificationAnswersControl();
            this.SuspendLayout();
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
            this.ResetPasswordCustomButton.Click += new System.EventHandler(this.ResetPasswordCustomButton_Click);
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
            this.UsernameCustomTextBox.Size = new System.Drawing.Size(228, 33);
            this.UsernameCustomTextBox.TabIndex = 43;
            this.UsernameCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernameCustomTextBox.TextContent = "";
            this.UsernameCustomTextBox.UnderlineStyle = true;
            // 
            // captchaCodeControl1
            // 
            this.captchaCodeControl1.AutoSize = true;
            this.captchaCodeControl1.Location = new System.Drawing.Point(515, 28);
            this.captchaCodeControl1.Name = "captchaCodeControl1";
            this.captchaCodeControl1.Size = new System.Drawing.Size(260, 250);
            this.captchaCodeControl1.TabIndex = 46;
            // 
            // captchaRotatingImageControl1
            // 
            this.captchaRotatingImageControl1.AutoSize = true;
            this.captchaRotatingImageControl1.Location = new System.Drawing.Point(515, 285);
            this.captchaRotatingImageControl1.Name = "captchaRotatingImageControl1";
            this.captchaRotatingImageControl1.Size = new System.Drawing.Size(260, 330);
            this.captchaRotatingImageControl1.TabIndex = 47;
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
            this.SignUpCustomButton.Location = new System.Drawing.Point(190, 516);
            this.SignUpCustomButton.Name = "SignUpCustomButton";
            this.SignUpCustomButton.Size = new System.Drawing.Size(150, 40);
            this.SignUpCustomButton.TabIndex = 48;
            this.SignUpCustomButton.Text = "Sign Up";
            this.SignUpCustomButton.TextColor = System.Drawing.Color.White;
            this.SignUpCustomButton.UseVisualStyleBackColor = false;
            this.SignUpCustomButton.Click += new System.EventHandler(this.SignUpCustomButton_Click);
            // 
            // SignUpLabel
            // 
            this.SignUpLabel.AutoSize = true;
            this.SignUpLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpLabel.Location = new System.Drawing.Point(167, 470);
            this.SignUpLabel.Name = "SignUpLabel";
            this.SignUpLabel.Size = new System.Drawing.Size(179, 34);
            this.SignUpLabel.TabIndex = 49;
            this.SignUpLabel.Text = "Don\'t have an account?\r\nSign up here!\r\n";
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.Location = new System.Drawing.Point(213, 28);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(104, 31);
            this.LoginLabel.TabIndex = 50;
            this.LoginLabel.Text = "LOGIN";
            // 
            // personalVerificationAnswersControl1
            // 
            this.personalVerificationAnswersControl1.Location = new System.Drawing.Point(781, 169);
            this.personalVerificationAnswersControl1.Name = "personalVerificationAnswersControl1";
            this.personalVerificationAnswersControl1.Size = new System.Drawing.Size(400, 240);
            this.personalVerificationAnswersControl1.TabIndex = 51;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 689);
            this.Controls.Add(this.personalVerificationAnswersControl1);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.SignUpLabel);
            this.Controls.Add(this.SignUpCustomButton);
            this.Controls.Add(this.captchaRotatingImageControl1);
            this.Controls.Add(this.captchaCodeControl1);
            this.Controls.Add(this.LoginCustomButton);
            this.Controls.Add(this.ResetPasswordCustomButton);
            this.Controls.Add(this.PasswordGeneratorControl);
            this.Controls.Add(this.UsernameCustomTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.ForgottenPasswordLabel);
            this.Name = "Login";
            this.Text = "Login";
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
        private Controls.CaptchaCodeControl captchaCodeControl1;
        private Controls.CaptchaRotatingImageControl captchaRotatingImageControl1;
        private Controls.CustomButton SignUpCustomButton;
        private System.Windows.Forms.Label SignUpLabel;
        public System.Windows.Forms.Label LoginLabel;
        private Controls.PersonalVerificationAnswersControl personalVerificationAnswersControl1;
    }
}