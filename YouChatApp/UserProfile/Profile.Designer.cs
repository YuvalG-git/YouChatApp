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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.ProfileHeadlineLabel = new System.Windows.Forms.Label();
            this.SettingsModeLabel = new System.Windows.Forms.Label();
            this.ProfilePicturePanel = new System.Windows.Forms.Panel();
            this.SaveProfilePictureCustomButton = new YouChatApp.Controls.CustomButton();
            this.ProfilePictureControl = new YouChatApp.Controls.ProfilePictureControl();
            this.CurrentProfilePicturePictureBox = new System.Windows.Forms.PictureBox();
            this.CurrentProfilePictureLabel = new System.Windows.Forms.Label();
            this.ProfilePictureOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MaleImageList = new System.Windows.Forms.ImageList(this.components);
            this.FemaleImageList = new System.Windows.Forms.ImageList(this.components);
            this.AnimalImageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ProfilePictureSelectionCustomButton = new YouChatApp.Controls.CustomButton();
            this.StatusSelectionCustomButton = new YouChatApp.Controls.CustomButton();
            this.ProfileStatusControl = new YouChatApp.Controls.ProfileStatusControl();
            this.ProfilePicturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentProfilePicturePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfileHeadlineLabel
            // 
            this.ProfileHeadlineLabel.AutoSize = true;
            this.ProfileHeadlineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileHeadlineLabel.Location = new System.Drawing.Point(320, 9);
            this.ProfileHeadlineLabel.Name = "ProfileHeadlineLabel";
            this.ProfileHeadlineLabel.Size = new System.Drawing.Size(491, 55);
            this.ProfileHeadlineLabel.TabIndex = 0;
            this.ProfileHeadlineLabel.Text = "PROFILE SETTINGS";
            // 
            // SettingsModeLabel
            // 
            this.SettingsModeLabel.AutoSize = true;
            this.SettingsModeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsModeLabel.Location = new System.Drawing.Point(463, 140);
            this.SettingsModeLabel.Name = "SettingsModeLabel";
            this.SettingsModeLabel.Size = new System.Drawing.Size(0, 37);
            this.SettingsModeLabel.TabIndex = 1;
            this.SettingsModeLabel.Visible = false;
            // 
            // ProfilePicturePanel
            // 
            this.ProfilePicturePanel.Controls.Add(this.SaveProfilePictureCustomButton);
            this.ProfilePicturePanel.Controls.Add(this.ProfilePictureControl);
            this.ProfilePicturePanel.Controls.Add(this.CurrentProfilePicturePictureBox);
            this.ProfilePicturePanel.Controls.Add(this.CurrentProfilePictureLabel);
            this.ProfilePicturePanel.Location = new System.Drawing.Point(124, 155);
            this.ProfilePicturePanel.Name = "ProfilePicturePanel";
            this.ProfilePicturePanel.Size = new System.Drawing.Size(822, 667);
            this.ProfilePicturePanel.TabIndex = 15;
            this.ProfilePicturePanel.Visible = false;
            // 
            // SaveProfilePictureCustomButton
            // 
            this.SaveProfilePictureCustomButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.SaveProfilePictureCustomButton.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.SaveProfilePictureCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.approve;
            this.SaveProfilePictureCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveProfilePictureCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.SaveProfilePictureCustomButton.BorderRadius = 5;
            this.SaveProfilePictureCustomButton.BorderSize = 0;
            this.SaveProfilePictureCustomButton.Circular = false;
            this.SaveProfilePictureCustomButton.FlatAppearance.BorderSize = 0;
            this.SaveProfilePictureCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveProfilePictureCustomButton.ForeColor = System.Drawing.Color.White;
            this.SaveProfilePictureCustomButton.Location = new System.Drawing.Point(55, 384);
            this.SaveProfilePictureCustomButton.Name = "SaveProfilePictureCustomButton";
            this.SaveProfilePictureCustomButton.Size = new System.Drawing.Size(87, 70);
            this.SaveProfilePictureCustomButton.TabIndex = 31;
            this.SaveProfilePictureCustomButton.TextColor = System.Drawing.Color.White;
            this.SaveProfilePictureCustomButton.UseVisualStyleBackColor = false;
            this.SaveProfilePictureCustomButton.Click += new System.EventHandler(this.SaveProfilePictureCustomButton_Click);
            // 
            // ProfilePictureControl
            // 
            this.ProfilePictureControl.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ProfilePictureControl.Location = new System.Drawing.Point(206, 12);
            this.ProfilePictureControl.MaximumSize = new System.Drawing.Size(570, 620);
            this.ProfilePictureControl.MinimumSize = new System.Drawing.Size(570, 620);
            this.ProfilePictureControl.Name = "ProfilePictureControl";
            this.ProfilePictureControl.Size = new System.Drawing.Size(570, 620);
            this.ProfilePictureControl.TabIndex = 19;
            // 
            // CurrentProfilePicturePictureBox
            // 
            this.CurrentProfilePicturePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CurrentProfilePicturePictureBox.Image = global::YouChatApp.Properties.Resources.BoyCharacter1;
            this.CurrentProfilePicturePictureBox.Location = new System.Drawing.Point(12, 247);
            this.CurrentProfilePicturePictureBox.Name = "CurrentProfilePicturePictureBox";
            this.CurrentProfilePicturePictureBox.Size = new System.Drawing.Size(184, 105);
            this.CurrentProfilePicturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CurrentProfilePicturePictureBox.TabIndex = 18;
            this.CurrentProfilePicturePictureBox.TabStop = false;
            // 
            // CurrentProfilePictureLabel
            // 
            this.CurrentProfilePictureLabel.AutoSize = true;
            this.CurrentProfilePictureLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentProfilePictureLabel.Location = new System.Drawing.Point(0, 226);
            this.CurrentProfilePictureLabel.Name = "CurrentProfilePictureLabel";
            this.CurrentProfilePictureLabel.Size = new System.Drawing.Size(196, 18);
            this.CurrentProfilePictureLabel.TabIndex = 7;
            this.CurrentProfilePictureLabel.Text = "Current Profile Picture: ";
            // 
            // ProfilePictureOpenFileDialog
            // 
            this.ProfilePictureOpenFileDialog.FileName = "openFileDialog1";
            // 
            // MaleImageList
            // 
            this.MaleImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MaleImageList.ImageStream")));
            this.MaleImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MaleImageList.Images.SetKeyName(0, "BoyCharacter1.png");
            this.MaleImageList.Images.SetKeyName(1, "BoyCharacter2.png");
            this.MaleImageList.Images.SetKeyName(2, "BoyCharacter3.png");
            this.MaleImageList.Images.SetKeyName(3, "BoyCharacter4.png");
            this.MaleImageList.Images.SetKeyName(4, "BoyCharacter5.png");
            this.MaleImageList.Images.SetKeyName(5, "BoyCharacter6.png");
            this.MaleImageList.Images.SetKeyName(6, "BoyCharacter7.png");
            this.MaleImageList.Images.SetKeyName(7, "BoyCharacter8.png");
            this.MaleImageList.Images.SetKeyName(8, "BoyCharacter9.png");
            this.MaleImageList.Images.SetKeyName(9, "BoyCharacter10.png");
            this.MaleImageList.Images.SetKeyName(10, "BoyCharacter11.png");
            this.MaleImageList.Images.SetKeyName(11, "BoyCharacter12.png");
            this.MaleImageList.Images.SetKeyName(12, "BoyCharacter13.png");
            this.MaleImageList.Images.SetKeyName(13, "BoyCharacter14.png");
            this.MaleImageList.Images.SetKeyName(14, "BoyCharacter15.png");
            this.MaleImageList.Images.SetKeyName(15, "BoyCharacter16.png");
            this.MaleImageList.Images.SetKeyName(16, "BoyCharacter17.png");
            this.MaleImageList.Images.SetKeyName(17, "BoyCharacter18.png");
            this.MaleImageList.Images.SetKeyName(18, "BoyCharacter19.png");
            this.MaleImageList.Images.SetKeyName(19, "BoyCharacter20.png");
            this.MaleImageList.Images.SetKeyName(20, "BoyCharacter21.png");
            this.MaleImageList.Images.SetKeyName(21, "BoyCharacter22.png");
            this.MaleImageList.Images.SetKeyName(22, "BoyCharacter23.png");
            this.MaleImageList.Images.SetKeyName(23, "BoyCharacter24.png");
            this.MaleImageList.Images.SetKeyName(24, "BoyCharacter25.png");
            this.MaleImageList.Images.SetKeyName(25, "BoyCharacter26.png");
            this.MaleImageList.Images.SetKeyName(26, "BoyCharacter27.png");
            this.MaleImageList.Images.SetKeyName(27, "BoyCharacter28.png");
            // 
            // FemaleImageList
            // 
            this.FemaleImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FemaleImageList.ImageStream")));
            this.FemaleImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FemaleImageList.Images.SetKeyName(0, "GirlCharacter1.png");
            this.FemaleImageList.Images.SetKeyName(1, "GirlCharacter2.png");
            this.FemaleImageList.Images.SetKeyName(2, "GirlCharacter3.png");
            this.FemaleImageList.Images.SetKeyName(3, "GirlCharacter4.png");
            this.FemaleImageList.Images.SetKeyName(4, "GirlCharacter5.png");
            this.FemaleImageList.Images.SetKeyName(5, "GirlCharacter6.png");
            this.FemaleImageList.Images.SetKeyName(6, "GirlCharacter7.png");
            this.FemaleImageList.Images.SetKeyName(7, "GirlCharacter8.png");
            this.FemaleImageList.Images.SetKeyName(8, "GirlCharacter9.png");
            this.FemaleImageList.Images.SetKeyName(9, "GirlCharacter10.png");
            this.FemaleImageList.Images.SetKeyName(10, "GirlCharacter11.png");
            this.FemaleImageList.Images.SetKeyName(11, "GirlCharacter12.png");
            this.FemaleImageList.Images.SetKeyName(12, "GirlCharacter13.png");
            this.FemaleImageList.Images.SetKeyName(13, "GirlCharacter14.png");
            this.FemaleImageList.Images.SetKeyName(14, "GirlCharacter15.png");
            this.FemaleImageList.Images.SetKeyName(15, "GirlCharacter16.png");
            this.FemaleImageList.Images.SetKeyName(16, "GirlCharacter17.png");
            this.FemaleImageList.Images.SetKeyName(17, "GirlCharacter18.png");
            this.FemaleImageList.Images.SetKeyName(18, "GirlCharacter19.png");
            this.FemaleImageList.Images.SetKeyName(19, "GirlCharacter20.png");
            this.FemaleImageList.Images.SetKeyName(20, "GirlCharacter21.png");
            this.FemaleImageList.Images.SetKeyName(21, "GirlCharacter22.png");
            this.FemaleImageList.Images.SetKeyName(22, "GirlCharacter23.png");
            this.FemaleImageList.Images.SetKeyName(23, "GirlCharacter24.png");
            this.FemaleImageList.Images.SetKeyName(24, "GirlCharacter25.png");
            this.FemaleImageList.Images.SetKeyName(25, "GirlCharacter26.png");
            this.FemaleImageList.Images.SetKeyName(26, "GirlCharacter27.png");
            // 
            // AnimalImageList
            // 
            this.AnimalImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("AnimalImageList.ImageStream")));
            this.AnimalImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.AnimalImageList.Images.SetKeyName(0, "AnimalCharacter18.png");
            this.AnimalImageList.Images.SetKeyName(1, "AnimalCharacter19.png");
            this.AnimalImageList.Images.SetKeyName(2, "AnimalCharacter20.png");
            this.AnimalImageList.Images.SetKeyName(3, "AnimalCharacter21.png");
            this.AnimalImageList.Images.SetKeyName(4, "AnimalCharacter22.png");
            this.AnimalImageList.Images.SetKeyName(5, "AnimalCharacter23.png");
            this.AnimalImageList.Images.SetKeyName(6, "AnimalCharacter24.png");
            this.AnimalImageList.Images.SetKeyName(7, "AnimalCharacter25.png");
            this.AnimalImageList.Images.SetKeyName(8, "AnimalCharacter26.png");
            this.AnimalImageList.Images.SetKeyName(9, "AnimalCharacter27.png");
            this.AnimalImageList.Images.SetKeyName(10, "AnimalCharacter28.png");
            this.AnimalImageList.Images.SetKeyName(11, "AnimalCharacter29.png");
            this.AnimalImageList.Images.SetKeyName(12, "AnimalCharacter30.png");
            this.AnimalImageList.Images.SetKeyName(13, "AnimalCharacter31.png");
            this.AnimalImageList.Images.SetKeyName(14, "AnimalCharacter32.png");
            this.AnimalImageList.Images.SetKeyName(15, "AnimalCharacter33.png");
            this.AnimalImageList.Images.SetKeyName(16, "AnimalCharacter34.png");
            this.AnimalImageList.Images.SetKeyName(17, "AnimalCharacter35.png");
            this.AnimalImageList.Images.SetKeyName(18, "AnimalCharacter36.png");
            this.AnimalImageList.Images.SetKeyName(19, "AnimalCharacter37.png");
            this.AnimalImageList.Images.SetKeyName(20, "AnimalCharacter38.png");
            this.AnimalImageList.Images.SetKeyName(21, "AnimalCharacter39.png");
            this.AnimalImageList.Images.SetKeyName(22, "AnimalCharacter40.png");
            this.AnimalImageList.Images.SetKeyName(23, "AnimalCharacter41.png");
            this.AnimalImageList.Images.SetKeyName(24, "AnimalCharacter42.png");
            this.AnimalImageList.Images.SetKeyName(25, "AnimalCharacter43.png");
            this.AnimalImageList.Images.SetKeyName(26, "AnimalCharacter44.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ProfilePictureSelectionCustomButton
            // 
            this.ProfilePictureSelectionCustomButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.ProfilePictureSelectionCustomButton.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.ProfilePictureSelectionCustomButton.BorderColor = System.Drawing.Color.MediumSpringGreen;
            this.ProfilePictureSelectionCustomButton.BorderRadius = 5;
            this.ProfilePictureSelectionCustomButton.BorderSize = 0;
            this.ProfilePictureSelectionCustomButton.Circular = false;
            this.ProfilePictureSelectionCustomButton.FlatAppearance.BorderSize = 0;
            this.ProfilePictureSelectionCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfilePictureSelectionCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfilePictureSelectionCustomButton.ForeColor = System.Drawing.Color.White;
            this.ProfilePictureSelectionCustomButton.Location = new System.Drawing.Point(631, 102);
            this.ProfilePictureSelectionCustomButton.Name = "ProfilePictureSelectionCustomButton";
            this.ProfilePictureSelectionCustomButton.Size = new System.Drawing.Size(150, 40);
            this.ProfilePictureSelectionCustomButton.TabIndex = 20;
            this.ProfilePictureSelectionCustomButton.Text = "Profile Picture";
            this.ProfilePictureSelectionCustomButton.TextColor = System.Drawing.Color.White;
            this.ProfilePictureSelectionCustomButton.UseVisualStyleBackColor = false;
            this.ProfilePictureSelectionCustomButton.Click += new System.EventHandler(this.ProfilePictureSelectionCustomButton_Click);
            // 
            // StatusSelectionCustomButton
            // 
            this.StatusSelectionCustomButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.StatusSelectionCustomButton.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.StatusSelectionCustomButton.BorderColor = System.Drawing.Color.MediumSpringGreen;
            this.StatusSelectionCustomButton.BorderRadius = 5;
            this.StatusSelectionCustomButton.BorderSize = 0;
            this.StatusSelectionCustomButton.Circular = false;
            this.StatusSelectionCustomButton.FlatAppearance.BorderSize = 0;
            this.StatusSelectionCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusSelectionCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusSelectionCustomButton.ForeColor = System.Drawing.Color.White;
            this.StatusSelectionCustomButton.Location = new System.Drawing.Point(796, 102);
            this.StatusSelectionCustomButton.Name = "StatusSelectionCustomButton";
            this.StatusSelectionCustomButton.Size = new System.Drawing.Size(150, 40);
            this.StatusSelectionCustomButton.TabIndex = 21;
            this.StatusSelectionCustomButton.Text = "Status";
            this.StatusSelectionCustomButton.TextColor = System.Drawing.Color.White;
            this.StatusSelectionCustomButton.UseVisualStyleBackColor = false;
            this.StatusSelectionCustomButton.Click += new System.EventHandler(this.StatusSelectionCustomButton_Click);
            // 
            // ProfileStatusControl
            // 
            this.ProfileStatusControl.IsSelectedStatusShown = true;
            this.ProfileStatusControl.Location = new System.Drawing.Point(884, 648);
            this.ProfileStatusControl.Name = "ProfileStatusControl";
            this.ProfileStatusControl.Size = new System.Drawing.Size(320, 345);
            this.ProfileStatusControl.TabIndex = 22;
            this.ProfileStatusControl.Visible = false;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 1061);
            this.Controls.Add(this.ProfileStatusControl);
            this.Controls.Add(this.StatusSelectionCustomButton);
            this.Controls.Add(this.ProfilePictureSelectionCustomButton);
            this.Controls.Add(this.ProfilePicturePanel);
            this.Controls.Add(this.SettingsModeLabel);
            this.Controls.Add(this.ProfileHeadlineLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Profile";
            this.Text = "Profile";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Profile_FormClosed);
            this.ProfilePicturePanel.ResumeLayout(false);
            this.ProfilePicturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentProfilePicturePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button[,] ProfileAvatarMatrix;
        public System.Windows.Forms.Button[] ProfilePictureKindSelectionButtons;
        public System.Windows.Forms.Button[] PrivacySettingsKindSelectionButtons;
        public System.Windows.Forms.Button[] ChatSettingsKindSelectionButtons;
        private System.Windows.Forms.Label ProfileHeadlineLabel;
        private System.Windows.Forms.Label SettingsModeLabel;
        private System.Windows.Forms.Panel ProfilePicturePanel;
        private System.Windows.Forms.Label CurrentProfilePictureLabel;
        private System.Windows.Forms.PictureBox CurrentProfilePicturePictureBox;
        private System.Windows.Forms.OpenFileDialog ProfilePictureOpenFileDialog;
        private System.Windows.Forms.ImageList MaleImageList;
        private System.Windows.Forms.ImageList FemaleImageList;
        private System.Windows.Forms.ImageList AnimalImageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Controls.CustomButton ProfilePictureSelectionCustomButton;
        private Controls.CustomButton StatusSelectionCustomButton;
        private Controls.ProfilePictureControl ProfilePictureControl;
        private Controls.ProfileStatusControl ProfileStatusControl;
        private Controls.CustomButton SaveProfilePictureCustomButton;
    }
}