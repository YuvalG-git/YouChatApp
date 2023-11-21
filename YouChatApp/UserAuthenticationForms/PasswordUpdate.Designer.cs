namespace YouChatApp.LoginForms
{
    partial class PasswordUpdate
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
            this.UpdatePasswordGeneratorControl = new YouChatApp.Controls.PasswordGeneratorControl();
            this.ExpiredPasswordLabel = new System.Windows.Forms.Label();
            this.UpdatePasswordReturnToStarterScreenButton = new System.Windows.Forms.Button();
            this.UpdatePasswordButton = new System.Windows.Forms.Button();
            this.PasswordUpdateLabel = new System.Windows.Forms.Label();
            this.UsernameCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UpdatePasswordGeneratorControl
            // 
            this.UpdatePasswordGeneratorControl.ConfirmPasswordVisible = true;
            this.UpdatePasswordGeneratorControl.Location = new System.Drawing.Point(17, 215);
            this.UpdatePasswordGeneratorControl.Name = "UpdatePasswordGeneratorControl";
            this.UpdatePasswordGeneratorControl.NewPasswordTextContent = "New Password";
            this.UpdatePasswordGeneratorControl.OldPasswordVisible = true;
            this.UpdatePasswordGeneratorControl.Size = new System.Drawing.Size(288, 188);
            this.UpdatePasswordGeneratorControl.TabIndex = 33;
            // 
            // ExpiredPasswordLabel
            // 
            this.ExpiredPasswordLabel.AutoSize = true;
            this.ExpiredPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpiredPasswordLabel.Location = new System.Drawing.Point(13, 74);
            this.ExpiredPasswordLabel.Name = "ExpiredPasswordLabel";
            this.ExpiredPasswordLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExpiredPasswordLabel.Size = new System.Drawing.Size(248, 40);
            this.ExpiredPasswordLabel.TabIndex = 31;
            this.ExpiredPasswordLabel.Text = "Your password has expired.\r\nPlease choose another password.";
            // 
            // UpdatePasswordReturnToStarterScreenButton
            // 
            this.UpdatePasswordReturnToStarterScreenButton.BackColor = System.Drawing.SystemColors.Control;
            this.UpdatePasswordReturnToStarterScreenButton.BackgroundImage = global::YouChatApp.Properties.Resources.returnArrow;
            this.UpdatePasswordReturnToStarterScreenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UpdatePasswordReturnToStarterScreenButton.Location = new System.Drawing.Point(12, 20);
            this.UpdatePasswordReturnToStarterScreenButton.Name = "UpdatePasswordReturnToStarterScreenButton";
            this.UpdatePasswordReturnToStarterScreenButton.Size = new System.Drawing.Size(46, 29);
            this.UpdatePasswordReturnToStarterScreenButton.TabIndex = 30;
            this.UpdatePasswordReturnToStarterScreenButton.UseVisualStyleBackColor = true;
            // 
            // UpdatePasswordButton
            // 
            this.UpdatePasswordButton.Enabled = false;
            this.UpdatePasswordButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.UpdatePasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePasswordButton.Location = new System.Drawing.Point(94, 415);
            this.UpdatePasswordButton.Name = "UpdatePasswordButton";
            this.UpdatePasswordButton.Size = new System.Drawing.Size(196, 32);
            this.UpdatePasswordButton.TabIndex = 13;
            this.UpdatePasswordButton.Text = "Update Password";
            this.UpdatePasswordButton.UseVisualStyleBackColor = true;
            // 
            // PasswordUpdateLabel
            // 
            this.PasswordUpdateLabel.AutoSize = true;
            this.PasswordUpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordUpdateLabel.Location = new System.Drawing.Point(88, 20);
            this.PasswordUpdateLabel.Name = "PasswordUpdateLabel";
            this.PasswordUpdateLabel.Size = new System.Drawing.Size(290, 31);
            this.PasswordUpdateLabel.TabIndex = 1;
            this.PasswordUpdateLabel.Text = "UPDATE PASSWORD";
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
            this.UsernameCustomTextBox.Location = new System.Drawing.Point(17, 151);
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
            this.UsernameCustomTextBox.TabIndex = 45;
            this.UsernameCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernameCustomTextBox.TextContent = "";
            this.UsernameCustomTextBox.UnderlineStyle = true;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(14, 129);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(95, 18);
            this.UsernameLabel.TabIndex = 44;
            this.UsernameLabel.Text = "Username:";
            // 
            // PasswordUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UsernameCustomTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UpdatePasswordButton);
            this.Controls.Add(this.UpdatePasswordGeneratorControl);
            this.Controls.Add(this.UpdatePasswordReturnToStarterScreenButton);
            this.Controls.Add(this.ExpiredPasswordLabel);
            this.Controls.Add(this.PasswordUpdateLabel);
            this.Name = "PasswordUpdate";
            this.Text = "PasswordUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.PasswordGeneratorControl UpdatePasswordGeneratorControl;
        public System.Windows.Forms.Label ExpiredPasswordLabel;
        private System.Windows.Forms.Button UpdatePasswordReturnToStarterScreenButton;
        public System.Windows.Forms.Button UpdatePasswordButton;
        public System.Windows.Forms.Label PasswordUpdateLabel;
        private Controls.CustomTextBox UsernameCustomTextBox;
        private System.Windows.Forms.Label UsernameLabel;
    }
}