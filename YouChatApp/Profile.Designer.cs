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
            this.ProfileStatusTextBox = new System.Windows.Forms.TextBox();
            this.LogOutConfirmationLabel = new System.Windows.Forms.Label();
            this.ProfilePictureSelectionButton = new System.Windows.Forms.Button();
            this.StatusSelectionButton = new System.Windows.Forms.Button();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.StatusTextPanel = new System.Windows.Forms.Panel();
            this.CurrentStatusLabel = new System.Windows.Forms.Label();
            this.CharNumberLabel = new System.Windows.Forms.Label();
            this.RefreshTextButton = new System.Windows.Forms.Button();
            this.SaveTextButton = new System.Windows.Forms.Button();
            this.ProfilePicturePanel = new System.Windows.Forms.Panel();
            this.PictureUploaderButton = new System.Windows.Forms.Button();
            this.ProfilePictureUploaderPictureBox = new System.Windows.Forms.PictureBox();
            this.CurrentProfilePicturePictureBox = new System.Windows.Forms.PictureBox();
            this.CurrentProfilePictureLabel = new System.Windows.Forms.Label();
            this.SaveProfilePictureButton = new System.Windows.Forms.Button();
            this.LackOfLogOutApprovalButton = new System.Windows.Forms.Button();
            this.LogOutApprovalButton = new System.Windows.Forms.Button();
            this.DisconnentButton = new System.Windows.Forms.Button();
            this.ProfilePictureOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MaleImageList = new System.Windows.Forms.ImageList(this.components);
            this.FemaleImageList = new System.Windows.Forms.ImageList(this.components);
            this.AnimalImageList = new System.Windows.Forms.ImageList(this.components);
            this.PrivacySettingsSelectionButton = new System.Windows.Forms.Button();
            this.PrivacySettingsPanel = new System.Windows.Forms.Panel();
            this.NobodyOptionRadioButton = new System.Windows.Forms.RadioButton();
            this.ContactsOptionRadioButton = new System.Windows.Forms.RadioButton();
            this.ChatSettingsPanel = new System.Windows.Forms.Panel();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StatusPanel.SuspendLayout();
            this.StatusTextPanel.SuspendLayout();
            this.ProfilePicturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureUploaderPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentProfilePicturePictureBox)).BeginInit();
            this.PrivacySettingsPanel.SuspendLayout();
            this.ChatSettingsPanel.SuspendLayout();
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
            // ProfileStatusTextBox
            // 
            this.ProfileStatusTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileStatusTextBox.ForeColor = System.Drawing.Color.Silver;
            this.ProfileStatusTextBox.Location = new System.Drawing.Point(28, 173);
            this.ProfileStatusTextBox.MaxLength = 150;
            this.ProfileStatusTextBox.Multiline = true;
            this.ProfileStatusTextBox.Name = "ProfileStatusTextBox";
            this.ProfileStatusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProfileStatusTextBox.Size = new System.Drawing.Size(262, 55);
            this.ProfileStatusTextBox.TabIndex = 3;
            this.ProfileStatusTextBox.Text = "Write Here Your YouChat Status";
            this.ProfileStatusTextBox.TextChanged += new System.EventHandler(this.ProfileStatusTextBox_TextChanged);
            this.ProfileStatusTextBox.Enter += new System.EventHandler(this.ProfileStatusTextBox_Enter);
            this.ProfileStatusTextBox.Leave += new System.EventHandler(this.ProfileStatusTextBox_Leave);
            // 
            // LogOutConfirmationLabel
            // 
            this.LogOutConfirmationLabel.AutoSize = true;
            this.LogOutConfirmationLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutConfirmationLabel.Location = new System.Drawing.Point(12, 70);
            this.LogOutConfirmationLabel.Name = "LogOutConfirmationLabel";
            this.LogOutConfirmationLabel.Size = new System.Drawing.Size(273, 18);
            this.LogOutConfirmationLabel.TabIndex = 9;
            this.LogOutConfirmationLabel.Text = "Are you sure you want to log out?";
            this.LogOutConfirmationLabel.Visible = false;
            // 
            // ProfilePictureSelectionButton
            // 
            this.ProfilePictureSelectionButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfilePictureSelectionButton.Location = new System.Drawing.Point(325, 91);
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
            this.StatusSelectionButton.Location = new System.Drawing.Point(507, 91);
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
            this.StatusPanel.Location = new System.Drawing.Point(185, 0);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(350, 320);
            this.StatusPanel.TabIndex = 14;
            this.StatusPanel.Visible = false;
            // 
            // StatusTextPanel
            // 
            this.StatusTextPanel.AutoScroll = true;
            this.StatusTextPanel.Controls.Add(this.CurrentStatusLabel);
            this.StatusTextPanel.Location = new System.Drawing.Point(28, 13);
            this.StatusTextPanel.MaximumSize = new System.Drawing.Size(300, 200);
            this.StatusTextPanel.MinimumSize = new System.Drawing.Size(300, 0);
            this.StatusTextPanel.Name = "StatusTextPanel";
            this.StatusTextPanel.Size = new System.Drawing.Size(300, 100);
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
            // ProfilePicturePanel
            // 
            this.ProfilePicturePanel.Controls.Add(this.PictureUploaderButton);
            this.ProfilePicturePanel.Controls.Add(this.StatusPanel);
            this.ProfilePicturePanel.Controls.Add(this.ProfilePictureUploaderPictureBox);
            this.ProfilePicturePanel.Controls.Add(this.CurrentProfilePicturePictureBox);
            this.ProfilePicturePanel.Controls.Add(this.CurrentProfilePictureLabel);
            this.ProfilePicturePanel.Controls.Add(this.SaveProfilePictureButton);
            this.ProfilePicturePanel.Location = new System.Drawing.Point(188, 192);
            this.ProfilePicturePanel.Name = "ProfilePicturePanel";
            this.ProfilePicturePanel.Size = new System.Drawing.Size(705, 580);
            this.ProfilePicturePanel.TabIndex = 15;
            this.ProfilePicturePanel.Visible = false;
            // 
            // PictureUploaderButton
            // 
            this.PictureUploaderButton.BackgroundImage = global::YouChatApp.Properties.Resources.PictureUploader;
            this.PictureUploaderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureUploaderButton.Location = new System.Drawing.Point(69, 443);
            this.PictureUploaderButton.Name = "PictureUploaderButton";
            this.PictureUploaderButton.Size = new System.Drawing.Size(75, 63);
            this.PictureUploaderButton.TabIndex = 19;
            this.PictureUploaderButton.UseVisualStyleBackColor = true;
            this.PictureUploaderButton.Click += new System.EventHandler(this.PictureUploaderButton_Click);
            // 
            // ProfilePictureUploaderPictureBox
            // 
            this.ProfilePictureUploaderPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ProfilePictureUploaderPictureBox.Location = new System.Drawing.Point(34, 280);
            this.ProfilePictureUploaderPictureBox.Name = "ProfilePictureUploaderPictureBox";
            this.ProfilePictureUploaderPictureBox.Size = new System.Drawing.Size(145, 157);
            this.ProfilePictureUploaderPictureBox.TabIndex = 17;
            this.ProfilePictureUploaderPictureBox.TabStop = false;
            // 
            // CurrentProfilePicturePictureBox
            // 
            this.CurrentProfilePicturePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CurrentProfilePicturePictureBox.Image = global::YouChatApp.Properties.Resources.BoyCharacter1;
            this.CurrentProfilePicturePictureBox.Location = new System.Drawing.Point(19, 43);
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
            this.CurrentProfilePictureLabel.Location = new System.Drawing.Point(16, 22);
            this.CurrentProfilePictureLabel.Name = "CurrentProfilePictureLabel";
            this.CurrentProfilePictureLabel.Size = new System.Drawing.Size(196, 18);
            this.CurrentProfilePictureLabel.TabIndex = 7;
            this.CurrentProfilePictureLabel.Text = "Current Profile Picture: ";
            // 
            // SaveProfilePictureButton
            // 
            this.SaveProfilePictureButton.BackgroundImage = global::YouChatApp.Properties.Resources.approve;
            this.SaveProfilePictureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveProfilePictureButton.Enabled = false;
            this.SaveProfilePictureButton.Location = new System.Drawing.Point(69, 171);
            this.SaveProfilePictureButton.Name = "SaveProfilePictureButton";
            this.SaveProfilePictureButton.Size = new System.Drawing.Size(75, 63);
            this.SaveProfilePictureButton.TabIndex = 17;
            this.SaveProfilePictureButton.UseVisualStyleBackColor = true;
            this.SaveProfilePictureButton.Click += new System.EventHandler(this.SaveProfilePictureButton_Click);
            // 
            // LackOfLogOutApprovalButton
            // 
            this.LackOfLogOutApprovalButton.BackgroundImage = global::YouChatApp.Properties.Resources.no;
            this.LackOfLogOutApprovalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LackOfLogOutApprovalButton.Location = new System.Drawing.Point(93, 91);
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
            this.LogOutApprovalButton.Location = new System.Drawing.Point(12, 91);
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
            this.DisconnentButton.Location = new System.Drawing.Point(12, 9);
            this.DisconnentButton.Name = "DisconnentButton";
            this.DisconnentButton.Size = new System.Drawing.Size(94, 58);
            this.DisconnentButton.TabIndex = 8;
            this.DisconnentButton.UseVisualStyleBackColor = true;
            this.DisconnentButton.Click += new System.EventHandler(this.DisconnentButton_Click);
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
            // PrivacySettingsSelectionButton
            // 
            this.PrivacySettingsSelectionButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrivacySettingsSelectionButton.Location = new System.Drawing.Point(704, 91);
            this.PrivacySettingsSelectionButton.Name = "PrivacySettingsSelectionButton";
            this.PrivacySettingsSelectionButton.Size = new System.Drawing.Size(148, 35);
            this.PrivacySettingsSelectionButton.TabIndex = 16;
            this.PrivacySettingsSelectionButton.Text = "Privacy Settings";
            this.PrivacySettingsSelectionButton.UseVisualStyleBackColor = true;
            this.PrivacySettingsSelectionButton.Click += new System.EventHandler(this.PrivacySettingsSelectionButton_Click);
            // 
            // PrivacySettingsPanel
            // 
            this.PrivacySettingsPanel.Controls.Add(this.NobodyOptionRadioButton);
            this.PrivacySettingsPanel.Controls.Add(this.ContactsOptionRadioButton);
            this.PrivacySettingsPanel.Location = new System.Drawing.Point(373, 192);
            this.PrivacySettingsPanel.Name = "PrivacySettingsPanel";
            this.PrivacySettingsPanel.Size = new System.Drawing.Size(350, 320);
            this.PrivacySettingsPanel.TabIndex = 17;
            this.PrivacySettingsPanel.Visible = false;
            // 
            // NobodyOptionRadioButton
            // 
            this.NobodyOptionRadioButton.AutoSize = true;
            this.NobodyOptionRadioButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NobodyOptionRadioButton.Location = new System.Drawing.Point(143, 60);
            this.NobodyOptionRadioButton.Name = "NobodyOptionRadioButton";
            this.NobodyOptionRadioButton.Size = new System.Drawing.Size(87, 22);
            this.NobodyOptionRadioButton.TabIndex = 4;
            this.NobodyOptionRadioButton.Text = "Nobody";
            this.NobodyOptionRadioButton.UseVisualStyleBackColor = true;
            this.NobodyOptionRadioButton.Visible = false;
            this.NobodyOptionRadioButton.Click += new System.EventHandler(this.PrivacySettingsRadioButton_Click);
            // 
            // ContactsOptionRadioButton
            // 
            this.ContactsOptionRadioButton.AutoSize = true;
            this.ContactsOptionRadioButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactsOptionRadioButton.Location = new System.Drawing.Point(143, 20);
            this.ContactsOptionRadioButton.Name = "ContactsOptionRadioButton";
            this.ContactsOptionRadioButton.Size = new System.Drawing.Size(123, 22);
            this.ContactsOptionRadioButton.TabIndex = 3;
            this.ContactsOptionRadioButton.Text = "My contacts";
            this.ContactsOptionRadioButton.UseVisualStyleBackColor = true;
            this.ContactsOptionRadioButton.Visible = false;
            this.ContactsOptionRadioButton.Click += new System.EventHandler(this.PrivacySettingsRadioButton_Click);
            // 
            // ChatSettingsPanel
            // 
            this.ChatSettingsPanel.Controls.Add(this.textBox1);
            this.ChatSettingsPanel.Controls.Add(this.hScrollBar1);
            this.ChatSettingsPanel.Controls.Add(this.domainUpDown1);
            this.ChatSettingsPanel.Location = new System.Drawing.Point(929, 192);
            this.ChatSettingsPanel.Name = "ChatSettingsPanel";
            this.ChatSettingsPanel.Size = new System.Drawing.Size(347, 328);
            this.ChatSettingsPanel.TabIndex = 18;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Items.Add("1");
            this.domainUpDown1.Items.Add("10");
            this.domainUpDown1.Items.Add("2");
            this.domainUpDown1.Items.Add("3");
            this.domainUpDown1.Items.Add("4");
            this.domainUpDown1.Items.Add("5");
            this.domainUpDown1.Items.Add("6");
            this.domainUpDown1.Items.Add("7");
            this.domainUpDown1.Items.Add("8");
            this.domainUpDown1.Items.Add("9");
            this.domainUpDown1.Location = new System.Drawing.Point(53, 60);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(133, 20);
            this.domainUpDown1.Sorted = true;
            this.domainUpDown1.TabIndex = 0;
            this.domainUpDown1.Text = "domainUpDown1";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(66, 171);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(149, 24);
            this.hScrollBar1.TabIndex = 19;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 148);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 20;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 786);
            this.Controls.Add(this.ChatSettingsPanel);
            this.Controls.Add(this.PrivacySettingsPanel);
            this.Controls.Add(this.PrivacySettingsSelectionButton);
            this.Controls.Add(this.ProfilePicturePanel);
            this.Controls.Add(this.StatusSelectionButton);
            this.Controls.Add(this.ProfilePictureSelectionButton);
            this.Controls.Add(this.LackOfLogOutApprovalButton);
            this.Controls.Add(this.LogOutApprovalButton);
            this.Controls.Add(this.LogOutConfirmationLabel);
            this.Controls.Add(this.DisconnentButton);
            this.Controls.Add(this.SettingsModeLabel);
            this.Controls.Add(this.ProfileHeadlineLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Profile";
            this.Text = "Profile";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Profile_FormClosed);
            this.Load += new System.EventHandler(this.Profile_Load);
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.StatusTextPanel.ResumeLayout(false);
            this.StatusTextPanel.PerformLayout();
            this.ProfilePicturePanel.ResumeLayout(false);
            this.ProfilePicturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureUploaderPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentProfilePicturePictureBox)).EndInit();
            this.PrivacySettingsPanel.ResumeLayout(false);
            this.PrivacySettingsPanel.PerformLayout();
            this.ChatSettingsPanel.ResumeLayout(false);
            this.ChatSettingsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button[,] ProfileAvatarMatrix;
        public System.Windows.Forms.Button[] ProfilePictureKindSelectionButtons;
        public System.Windows.Forms.Button[] PrivacySettingsKindSelectionButtons;

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
        private System.Windows.Forms.PictureBox CurrentProfilePicturePictureBox;
        private System.Windows.Forms.PictureBox ProfilePictureUploaderPictureBox;
        private System.Windows.Forms.Button PictureUploaderButton;
        private System.Windows.Forms.OpenFileDialog ProfilePictureOpenFileDialog;
        private System.Windows.Forms.ImageList MaleImageList;
        private System.Windows.Forms.ImageList FemaleImageList;
        private System.Windows.Forms.ImageList AnimalImageList;
        private System.Windows.Forms.Button PrivacySettingsSelectionButton;
        private System.Windows.Forms.Panel PrivacySettingsPanel;
        private System.Windows.Forms.RadioButton NobodyOptionRadioButton;
        private System.Windows.Forms.RadioButton ContactsOptionRadioButton;
        private System.Windows.Forms.Panel ChatSettingsPanel;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}