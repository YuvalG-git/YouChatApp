namespace YouChatApp
{
    partial class Profile
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
            this.ProfileHeadlineLabel = new System.Windows.Forms.Label();
            this.SettingsModeLabel = new System.Windows.Forms.Label();
            this.ProfileStatusTextBox = new System.Windows.Forms.TextBox();
            this.LogOutConfirmationLabel = new System.Windows.Forms.Label();
            this.ProfilePictureSelectionButton = new System.Windows.Forms.Button();
            this.StatusSelectionButton = new System.Windows.Forms.Button();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.StatusTextPanel = new System.Windows.Forms.Panel();
            this.CurrentStatusLabel = new System.Windows.Forms.Label();
            this.CharNumberLabel = new System.Windows.Forms.Label();
            this.ProfilePicturePanel = new System.Windows.Forms.Panel();
            this.CurrentProfilePictureLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SaveProfilePictureButton = new System.Windows.Forms.Button();
            this.RefreshTextButton = new System.Windows.Forms.Button();
            this.SaveTextButton = new System.Windows.Forms.Button();
            this.LackOfLogOutApprovalButton = new System.Windows.Forms.Button();
            this.LogOutApprovalButton = new System.Windows.Forms.Button();
            this.DisconnentButton = new System.Windows.Forms.Button();
            this.MaleSelectionButton = new System.Windows.Forms.Button();
            this.FemaleSelectionButton = new System.Windows.Forms.Button();
            this.AnimalSelectionButton = new System.Windows.Forms.Button();
            this.StatusPanel.SuspendLayout();
            this.StatusTextPanel.SuspendLayout();
            this.ProfilePicturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfileHeadlineLabel
            // 
            this.ProfileHeadlineLabel.AutoSize = true;
            this.ProfileHeadlineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileHeadlineLabel.Location = new System.Drawing.Point(262, 9);
            this.ProfileHeadlineLabel.Name = "ProfileHeadlineLabel";
            this.ProfileHeadlineLabel.Size = new System.Drawing.Size(491, 55);
            this.ProfileHeadlineLabel.TabIndex = 0;
            this.ProfileHeadlineLabel.Text = "PROFILE SETTINGS";
            // 
            // SettingsModeLabel
            // 
            this.SettingsModeLabel.AutoSize = true;
            this.SettingsModeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsModeLabel.Location = new System.Drawing.Point(318, 142);
            this.SettingsModeLabel.Name = "SettingsModeLabel";
            this.SettingsModeLabel.Size = new System.Drawing.Size(0, 37);
            this.SettingsModeLabel.TabIndex = 1;
            this.SettingsModeLabel.Visible = false;
            // 
            // ProfileStatusTextBox
            // 
            this.ProfileStatusTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileStatusTextBox.Location = new System.Drawing.Point(28, 173);
            this.ProfileStatusTextBox.MaxLength = 150;
            this.ProfileStatusTextBox.Multiline = true;
            this.ProfileStatusTextBox.Name = "ProfileStatusTextBox";
            this.ProfileStatusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProfileStatusTextBox.Size = new System.Drawing.Size(262, 55);
            this.ProfileStatusTextBox.TabIndex = 3;
            this.ProfileStatusTextBox.TextChanged += new System.EventHandler(this.ProfileStatusTextBox_TextChanged);
            // 
            // LogOutConfirmationLabel
            // 
            this.LogOutConfirmationLabel.AutoSize = true;
            this.LogOutConfirmationLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutConfirmationLabel.Location = new System.Drawing.Point(123, 610);
            this.LogOutConfirmationLabel.Name = "LogOutConfirmationLabel";
            this.LogOutConfirmationLabel.Size = new System.Drawing.Size(273, 18);
            this.LogOutConfirmationLabel.TabIndex = 9;
            this.LogOutConfirmationLabel.Text = "Are you sure you want to log out?";
            this.LogOutConfirmationLabel.Visible = false;
            // 
            // ProfilePictureSelectionButton
            // 
            this.ProfilePictureSelectionButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfilePictureSelectionButton.Location = new System.Drawing.Point(329, 77);
            this.ProfilePictureSelectionButton.Name = "ProfilePictureSelectionButton";
            this.ProfilePictureSelectionButton.Size = new System.Drawing.Size(148, 35);
            this.ProfilePictureSelectionButton.TabIndex = 12;
            this.ProfilePictureSelectionButton.Text = "Profile Picture";
            this.ProfilePictureSelectionButton.UseVisualStyleBackColor = true;
            this.ProfilePictureSelectionButton.Click += new System.EventHandler(this.ProfilePictureSelectionButton_Click);
            // 
            // StatusSelectionButton
            // 
            this.StatusSelectionButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusSelectionButton.Location = new System.Drawing.Point(532, 77);
            this.StatusSelectionButton.Name = "StatusSelectionButton";
            this.StatusSelectionButton.Size = new System.Drawing.Size(148, 35);
            this.StatusSelectionButton.TabIndex = 13;
            this.StatusSelectionButton.Text = "Status";
            this.StatusSelectionButton.UseVisualStyleBackColor = true;
            this.StatusSelectionButton.Click += new System.EventHandler(this.StatusSelectionButton_Click);
            // 
            // StatusPanel
            // 
            this.StatusPanel.Controls.Add(this.StatusTextPanel);
            this.StatusPanel.Controls.Add(this.CharNumberLabel);
            this.StatusPanel.Controls.Add(this.ProfileStatusTextBox);
            this.StatusPanel.Controls.Add(this.RefreshTextButton);
            this.StatusPanel.Controls.Add(this.SaveTextButton);
            this.StatusPanel.Location = new System.Drawing.Point(982, 246);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(342, 311);
            this.StatusPanel.TabIndex = 14;
            this.StatusPanel.Visible = false;
            // 
            // StatusTextPanel
            // 
            this.StatusTextPanel.AutoScroll = true;
            this.StatusTextPanel.Controls.Add(this.CurrentStatusLabel);
            this.StatusTextPanel.Location = new System.Drawing.Point(28, 13);
            this.StatusTextPanel.MaximumSize = new System.Drawing.Size(270, 200);
            this.StatusTextPanel.MinimumSize = new System.Drawing.Size(270, 0);
            this.StatusTextPanel.Name = "StatusTextPanel";
            this.StatusTextPanel.Size = new System.Drawing.Size(270, 100);
            this.StatusTextPanel.TabIndex = 16;
            // 
            // CurrentStatusLabel
            // 
            this.CurrentStatusLabel.AutoEllipsis = true;
            this.CurrentStatusLabel.AutoSize = true;
            this.CurrentStatusLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentStatusLabel.Location = new System.Drawing.Point(1, 0);
            this.CurrentStatusLabel.MaximumSize = new System.Drawing.Size(250, 200);
            this.CurrentStatusLabel.MinimumSize = new System.Drawing.Size(250, 0);
            this.CurrentStatusLabel.Name = "CurrentStatusLabel";
            this.CurrentStatusLabel.Size = new System.Drawing.Size(250, 18);
            this.CurrentStatusLabel.TabIndex = 6;
            this.CurrentStatusLabel.Text = "Current Status: ";
            // 
            // CharNumberLabel
            // 
            this.CharNumberLabel.AutoSize = true;
            this.CharNumberLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharNumberLabel.Location = new System.Drawing.Point(29, 231);
            this.CharNumberLabel.Name = "CharNumberLabel";
            this.CharNumberLabel.Size = new System.Drawing.Size(38, 14);
            this.CharNumberLabel.TabIndex = 7;
            this.CharNumberLabel.Text = "0/150";
            // 
            // ProfilePicturePanel
            // 
            this.ProfilePicturePanel.Controls.Add(this.AnimalSelectionButton);
            this.ProfilePicturePanel.Controls.Add(this.FemaleSelectionButton);
            this.ProfilePicturePanel.Controls.Add(this.MaleSelectionButton);
            this.ProfilePicturePanel.Controls.Add(this.pictureBox1);
            this.ProfilePicturePanel.Controls.Add(this.CurrentProfilePictureLabel);
            this.ProfilePicturePanel.Controls.Add(this.SaveProfilePictureButton);
            this.ProfilePicturePanel.Location = new System.Drawing.Point(174, 139);
            this.ProfilePicturePanel.Name = "ProfilePicturePanel";
            this.ProfilePicturePanel.Size = new System.Drawing.Size(659, 404);
            this.ProfilePicturePanel.TabIndex = 15;
            this.ProfilePicturePanel.Visible = false;
            // 
            // CurrentProfilePictureLabel
            // 
            this.CurrentProfilePictureLabel.AutoSize = true;
            this.CurrentProfilePictureLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentProfilePictureLabel.Location = new System.Drawing.Point(16, 22);
            this.CurrentProfilePictureLabel.Name = "CurrentProfilePictureLabel";
            this.CurrentProfilePictureLabel.Size = new System.Drawing.Size(196, 18);
            this.CurrentProfilePictureLabel.TabIndex = 7;
            this.CurrentProfilePictureLabel.Text = "Current Profile Picture: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::YouChatApp.Properties.Resources.BoyCharacter1;
            this.pictureBox1.Location = new System.Drawing.Point(19, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // SaveProfilePictureButton
            // 
            this.SaveProfilePictureButton.BackgroundImage = global::YouChatApp.Properties.Resources.approve;
            this.SaveProfilePictureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveProfilePictureButton.Location = new System.Drawing.Point(69, 171);
            this.SaveProfilePictureButton.Name = "SaveProfilePictureButton";
            this.SaveProfilePictureButton.Size = new System.Drawing.Size(75, 63);
            this.SaveProfilePictureButton.TabIndex = 17;
            this.SaveProfilePictureButton.UseVisualStyleBackColor = true;
            // 
            // RefreshTextButton
            // 
            this.RefreshTextButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RefreshTextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RefreshTextButton.Location = new System.Drawing.Point(172, 241);
            this.RefreshTextButton.Name = "RefreshTextButton";
            this.RefreshTextButton.Size = new System.Drawing.Size(75, 49);
            this.RefreshTextButton.TabIndex = 5;
            this.RefreshTextButton.UseVisualStyleBackColor = true;
            this.RefreshTextButton.Click += new System.EventHandler(this.RefreshTextButton_Click);
            // 
            // SaveTextButton
            // 
            this.SaveTextButton.BackgroundImage = global::YouChatApp.Properties.Resources.approve;
            this.SaveTextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveTextButton.Location = new System.Drawing.Point(72, 241);
            this.SaveTextButton.Name = "SaveTextButton";
            this.SaveTextButton.Size = new System.Drawing.Size(75, 49);
            this.SaveTextButton.TabIndex = 4;
            this.SaveTextButton.UseVisualStyleBackColor = true;
            this.SaveTextButton.Click += new System.EventHandler(this.SaveTextButton_Click);
            // 
            // LackOfLogOutApprovalButton
            // 
            this.LackOfLogOutApprovalButton.BackgroundImage = global::YouChatApp.Properties.Resources.no;
            this.LackOfLogOutApprovalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LackOfLogOutApprovalButton.Location = new System.Drawing.Point(483, 596);
            this.LackOfLogOutApprovalButton.Name = "LackOfLogOutApprovalButton";
            this.LackOfLogOutApprovalButton.Size = new System.Drawing.Size(74, 49);
            this.LackOfLogOutApprovalButton.TabIndex = 11;
            this.LackOfLogOutApprovalButton.UseVisualStyleBackColor = true;
            this.LackOfLogOutApprovalButton.Visible = false;
            this.LackOfLogOutApprovalButton.Click += new System.EventHandler(this.LackOfLogOutApprovalButton_Click);
            // 
            // LogOutApprovalButton
            // 
            this.LogOutApprovalButton.BackgroundImage = global::YouChatApp.Properties.Resources.yes2;
            this.LogOutApprovalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LogOutApprovalButton.Location = new System.Drawing.Point(402, 596);
            this.LogOutApprovalButton.Name = "LogOutApprovalButton";
            this.LogOutApprovalButton.Size = new System.Drawing.Size(75, 49);
            this.LogOutApprovalButton.TabIndex = 10;
            this.LogOutApprovalButton.UseVisualStyleBackColor = true;
            this.LogOutApprovalButton.Visible = false;
            this.LogOutApprovalButton.Click += new System.EventHandler(this.LogOutApprovalButton_Click);
            // 
            // DisconnentButton
            // 
            this.DisconnentButton.BackgroundImage = global::YouChatApp.Properties.Resources.logout;
            this.DisconnentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DisconnentButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnentButton.Location = new System.Drawing.Point(126, 549);
            this.DisconnentButton.Name = "DisconnentButton";
            this.DisconnentButton.Size = new System.Drawing.Size(94, 58);
            this.DisconnentButton.TabIndex = 8;
            this.DisconnentButton.UseVisualStyleBackColor = true;
            this.DisconnentButton.Click += new System.EventHandler(this.DisconnentButton_Click);
            // 
            // MaleSelectionButton
            // 
            this.MaleSelectionButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaleSelectionButton.Location = new System.Drawing.Point(218, 43);
            this.MaleSelectionButton.Name = "MaleSelectionButton";
            this.MaleSelectionButton.Size = new System.Drawing.Size(120, 35);
            this.MaleSelectionButton.TabIndex = 16;
            this.MaleSelectionButton.Text = "Males";
            this.MaleSelectionButton.UseVisualStyleBackColor = true;
            // 
            // FemaleSelectionButton
            // 
            this.FemaleSelectionButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FemaleSelectionButton.Location = new System.Drawing.Point(372, 43);
            this.FemaleSelectionButton.Name = "FemaleSelectionButton";
            this.FemaleSelectionButton.Size = new System.Drawing.Size(120, 35);
            this.FemaleSelectionButton.TabIndex = 19;
            this.FemaleSelectionButton.Text = "Females";
            this.FemaleSelectionButton.UseVisualStyleBackColor = true;
            // 
            // AnimalSelectionButton
            // 
            this.AnimalSelectionButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimalSelectionButton.Location = new System.Drawing.Point(526, 43);
            this.AnimalSelectionButton.Name = "AnimalSelectionButton";
            this.AnimalSelectionButton.Size = new System.Drawing.Size(120, 35);
            this.AnimalSelectionButton.TabIndex = 20;
            this.AnimalSelectionButton.Text = "Animals";
            this.AnimalSelectionButton.UseVisualStyleBackColor = true;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 649);
            this.Controls.Add(this.ProfilePicturePanel);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.StatusSelectionButton);
            this.Controls.Add(this.ProfilePictureSelectionButton);
            this.Controls.Add(this.LackOfLogOutApprovalButton);
            this.Controls.Add(this.LogOutApprovalButton);
            this.Controls.Add(this.LogOutConfirmationLabel);
            this.Controls.Add(this.DisconnentButton);
            this.Controls.Add(this.SettingsModeLabel);
            this.Controls.Add(this.ProfileHeadlineLabel);
            this.Name = "Profile";
            this.Text = "Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Profile_FormClosing);
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.StatusTextPanel.ResumeLayout(false);
            this.StatusTextPanel.PerformLayout();
            this.ProfilePicturePanel.ResumeLayout(false);
            this.ProfilePicturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button[,] ProfileAvatarMatrix;
        private System.Windows.Forms.Label ProfileHeadlineLabel;
        private System.Windows.Forms.Label SettingsModeLabel;
        private System.Windows.Forms.TextBox ProfileStatusTextBox;
        private System.Windows.Forms.Button SaveTextButton;
        private System.Windows.Forms.Button RefreshTextButton;
        private System.Windows.Forms.Button DisconnentButton;
        private System.Windows.Forms.Label LogOutConfirmationLabel;
        private System.Windows.Forms.Button LogOutApprovalButton;
        private System.Windows.Forms.Button LackOfLogOutApprovalButton;
        private System.Windows.Forms.Button ProfilePictureSelectionButton;
        private System.Windows.Forms.Button StatusSelectionButton;
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.Label CurrentStatusLabel;
        private System.Windows.Forms.Panel ProfilePicturePanel;
        private System.Windows.Forms.Label CharNumberLabel;
        private System.Windows.Forms.Panel StatusTextPanel;
        private System.Windows.Forms.Button SaveProfilePictureButton;
        private System.Windows.Forms.Label CurrentProfilePictureLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AnimalSelectionButton;
        private System.Windows.Forms.Button FemaleSelectionButton;
        private System.Windows.Forms.Button MaleSelectionButton;
    }
}