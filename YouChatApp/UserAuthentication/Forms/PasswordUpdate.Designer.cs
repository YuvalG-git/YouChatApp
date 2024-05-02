namespace YouChatApp.UserAuthentication.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordUpdate));
            this.UpdatePasswordGeneratorControl = new YouChatApp.Controls.PasswordGeneratorControl();
            this.ExpiredPasswordLabel = new System.Windows.Forms.Label();
            this.PasswordUpdateLabel = new System.Windows.Forms.Label();
            this.UsernameCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UpdatePasswordCustomButton = new YouChatApp.Controls.CustomButton();
            this.PasswordUpdatePanel = new System.Windows.Forms.Panel();
            this.BanControl = new YouChatApp.Controls.BanControl();
            this.PasswordUpdatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdatePasswordGeneratorControl
            // 
            this.UpdatePasswordGeneratorControl.ConfirmPasswordVisible = true;
            this.UpdatePasswordGeneratorControl.Location = new System.Drawing.Point(9, 174);
            this.UpdatePasswordGeneratorControl.Name = "UpdatePasswordGeneratorControl";
            this.UpdatePasswordGeneratorControl.NewPasswordTextContent = "New Password";
            this.UpdatePasswordGeneratorControl.OldPasswordVisible = true;
            this.UpdatePasswordGeneratorControl.PasswordExclamationVisible = true;
            this.UpdatePasswordGeneratorControl.Size = new System.Drawing.Size(340, 190);
            this.UpdatePasswordGeneratorControl.TabIndex = 33;
            // 
            // ExpiredPasswordLabel
            // 
            this.ExpiredPasswordLabel.AutoSize = true;
            this.ExpiredPasswordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpiredPasswordLabel.Location = new System.Drawing.Point(19, 69);
            this.ExpiredPasswordLabel.Name = "ExpiredPasswordLabel";
            this.ExpiredPasswordLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExpiredPasswordLabel.Size = new System.Drawing.Size(255, 34);
            this.ExpiredPasswordLabel.TabIndex = 31;
            this.ExpiredPasswordLabel.Text = "Your password has expired.\r\nPlease choose another password.";
            // 
            // PasswordUpdateLabel
            // 
            this.PasswordUpdateLabel.AutoSize = true;
            this.PasswordUpdateLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordUpdateLabel.Location = new System.Drawing.Point(-8, 7);
            this.PasswordUpdateLabel.Name = "PasswordUpdateLabel";
            this.PasswordUpdateLabel.Size = new System.Drawing.Size(403, 43);
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
            this.UsernameCustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.UsernameCustomTextBox.IsFocused = false;
            this.UsernameCustomTextBox.Location = new System.Drawing.Point(19, 139);
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
            this.UsernameCustomTextBox.Size = new System.Drawing.Size(225, 33);
            this.UsernameCustomTextBox.TabIndex = 45;
            this.UsernameCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernameCustomTextBox.TextContent = "";
            this.UsernameCustomTextBox.UnderlineStyle = true;
            this.UsernameCustomTextBox.TextChangedEvent += new System.EventHandler(this.UpdatePasswordFieldsChecker);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(19, 119);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(95, 18);
            this.UsernameLabel.TabIndex = 44;
            this.UsernameLabel.Text = "Username:";
            // 
            // UpdatePasswordCustomButton
            // 
            this.UpdatePasswordCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.UpdatePasswordCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.UpdatePasswordCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.UpdatePasswordCustomButton.BorderRadius = 10;
            this.UpdatePasswordCustomButton.BorderSize = 0;
            this.UpdatePasswordCustomButton.Circular = false;
            this.UpdatePasswordCustomButton.Enabled = false;
            this.UpdatePasswordCustomButton.FlatAppearance.BorderSize = 0;
            this.UpdatePasswordCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdatePasswordCustomButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePasswordCustomButton.ForeColor = System.Drawing.Color.White;
            this.UpdatePasswordCustomButton.Location = new System.Drawing.Point(139, 374);
            this.UpdatePasswordCustomButton.Name = "UpdatePasswordCustomButton";
            this.UpdatePasswordCustomButton.Size = new System.Drawing.Size(110, 40);
            this.UpdatePasswordCustomButton.TabIndex = 49;
            this.UpdatePasswordCustomButton.Text = "Update";
            this.UpdatePasswordCustomButton.TextColor = System.Drawing.Color.White;
            this.UpdatePasswordCustomButton.UseVisualStyleBackColor = false;
            this.UpdatePasswordCustomButton.Click += new System.EventHandler(this.UpdatePasswordCustomButton_Click);
            // 
            // PasswordUpdatePanel
            // 
            this.PasswordUpdatePanel.Controls.Add(this.BanControl);
            this.PasswordUpdatePanel.Controls.Add(this.PasswordUpdateLabel);
            this.PasswordUpdatePanel.Controls.Add(this.UpdatePasswordCustomButton);
            this.PasswordUpdatePanel.Controls.Add(this.ExpiredPasswordLabel);
            this.PasswordUpdatePanel.Controls.Add(this.UpdatePasswordGeneratorControl);
            this.PasswordUpdatePanel.Controls.Add(this.UsernameCustomTextBox);
            this.PasswordUpdatePanel.Controls.Add(this.UsernameLabel);
            this.PasswordUpdatePanel.Location = new System.Drawing.Point(10, 2);
            this.PasswordUpdatePanel.Name = "PasswordUpdatePanel";
            this.PasswordUpdatePanel.Size = new System.Drawing.Size(382, 431);
            this.PasswordUpdatePanel.TabIndex = 50;
            // 
            // BanControl
            // 
            this.BanControl.AutoSize = true;
            this.BanControl.Location = new System.Drawing.Point(-5, 31);
            this.BanControl.Name = "BanControl";
            this.BanControl.Size = new System.Drawing.Size(400, 400);
            this.BanControl.TabIndex = 51;
            this.BanControl.Visible = false;
            // 
            // PasswordUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 436);
            this.Controls.Add(this.PasswordUpdatePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PasswordUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PasswordUpdate";
            this.PasswordUpdatePanel.ResumeLayout(false);
            this.PasswordUpdatePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.PasswordGeneratorControl UpdatePasswordGeneratorControl;
        public System.Windows.Forms.Label ExpiredPasswordLabel;
        public System.Windows.Forms.Label PasswordUpdateLabel;
        private Controls.CustomTextBox UsernameCustomTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private Controls.CustomButton UpdatePasswordCustomButton;
        private System.Windows.Forms.Panel PasswordUpdatePanel;
        private Controls.BanControl BanControl;
    }
}