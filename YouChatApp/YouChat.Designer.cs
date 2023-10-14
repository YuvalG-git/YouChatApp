using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YouChatApp.Controls;


namespace YouChatApp
{
    partial class YouChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YouChat));
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.ContactManagementPanel = new System.Windows.Forms.Panel();
            this.UserTaglineCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.FriendRequestSenderCustomButton = new YouChatApp.Controls.CustomButton();
            this.UserIdCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.FriendRequestIdPanel = new System.Windows.Forms.Panel();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.FriendRequestPanel = new System.Windows.Forms.Panel();
            this.HashtagLabel = new System.Windows.Forms.Label();
            this.GroupCreatorBackgroundPanel = new System.Windows.Forms.Panel();
            this.GroupCreatorPanel = new System.Windows.Forms.Panel();
            this.ContinueToGroupSettingsCustomButton = new YouChatApp.Controls.CustomButton();
            this.SelectedContactsPanel = new System.Windows.Forms.Panel();
            this.GroupCreatorSearchPanel = new System.Windows.Forms.Panel();
            this.GroupCreatorSearchBar = new YouChatApp.Controls.SearchBar();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.ChatLabel = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ChatCustomButton = new YouChatApp.Controls.CustomButton();
            this.NewGroupCustomButton = new YouChatApp.Controls.CustomButton();
            this.NewContactCustomButton = new YouChatApp.Controls.CustomButton();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.ChatBackgroundPanel = new System.Windows.Forms.Panel();
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.ChatSearchPanel = new System.Windows.Forms.Panel();
            this.ChatSearchBar = new YouChatApp.Controls.SearchBar();
            this.GroupSettingsPanel = new System.Windows.Forms.Panel();
            this.GroupIconCircularPictureBox = new YouChatApp.CircularPictureBox();
            this.BackgroundCircularPictureBox = new YouChatApp.CircularPictureBox();
            this.GroupSubjectPanel = new System.Windows.Forms.Panel();
            this.RestartGroupSubjectCustomButton = new YouChatApp.Controls.CustomButton();
            this.GroupSubjectCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.GroupSubjectLengthLabel = new System.Windows.Forms.Label();
            this.GroupSubjectLabel = new System.Windows.Forms.Label();
            this.GroupIconLabel = new System.Windows.Forms.Label();
            this.GroupCreatorSettingsPanel = new System.Windows.Forms.Panel();
            this.GroupCreatorSettingsHeadlineLabel = new System.Windows.Forms.Label();
            this.ReturnToGroupContactsSelectionCustomButton = new YouChatApp.Controls.CustomButton();
            this.GroupCreatorCustomButton = new YouChatApp.Controls.CustomButton();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.TimeLabel = new System.Windows.Forms.Label();
            this.CurrentChatPanel = new System.Windows.Forms.Panel();
            this.AudioCallCustomButton = new YouChatApp.Controls.CustomButton();
            this.VideoCallCustomButton = new YouChatApp.Controls.CustomButton();
            this.ChatParticipantsLabel = new System.Windows.Forms.Label();
            this.LastSeenOnlineLabel = new System.Windows.Forms.Label();
            this.CurrentChatNameLabel = new System.Windows.Forms.Label();
            this.CurrentPictureChatPictureBox = new System.Windows.Forms.PictureBox();
            this.UploadedPictureOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.GroupIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TakePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmojiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawingFileButton = new System.Windows.Forms.Button();
            this.DocumentFileButton = new System.Windows.Forms.Button();
            this.EmojiFileButton = new System.Windows.Forms.Button();
            this.PhotoFileButton = new System.Windows.Forms.Button();
            this.VideoFileButton = new System.Windows.Forms.Button();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.UserFileCustomButton = new YouChatApp.Controls.CustomButton();
            this.ContactManagementPanel.SuspendLayout();
            this.FriendRequestIdPanel.SuspendLayout();
            this.GroupCreatorBackgroundPanel.SuspendLayout();
            this.GroupCreatorSearchPanel.SuspendLayout();
            this.MessagePanel.SuspendLayout();
            this.ChatBackgroundPanel.SuspendLayout();
            this.ChatSearchPanel.SuspendLayout();
            this.GroupSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupIconCircularPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundCircularPictureBox)).BeginInit();
            this.GroupSubjectPanel.SuspendLayout();
            this.GroupCreatorSettingsPanel.SuspendLayout();
            this.CurrentChatPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPictureChatPictureBox)).BeginInit();
            this.OptionsPanel.SuspendLayout();
            this.GroupIconContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContactManagementPanel
            // 
            this.ContactManagementPanel.BackColor = System.Drawing.Color.Aqua;
            this.ContactManagementPanel.Controls.Add(this.UserTaglineCustomTextBox);
            this.ContactManagementPanel.Controls.Add(this.FriendRequestSenderCustomButton);
            this.ContactManagementPanel.Controls.Add(this.UserIdCustomTextBox);
            this.ContactManagementPanel.Controls.Add(this.FriendRequestIdPanel);
            this.ContactManagementPanel.Controls.Add(this.FriendRequestPanel);
            this.ContactManagementPanel.Controls.Add(this.HashtagLabel);
            this.ContactManagementPanel.Location = new System.Drawing.Point(10, 110);
            this.ContactManagementPanel.Name = "ContactManagementPanel";
            this.ContactManagementPanel.Size = new System.Drawing.Size(340, 825);
            this.ContactManagementPanel.TabIndex = 10;
            this.ContactManagementPanel.Visible = false;
            // 
            // UserTaglineCustomTextBox
            // 
            this.UserTaglineCustomTextBox.BackColor = System.Drawing.Color.Aqua;
            this.UserTaglineCustomTextBox.BorderColor = System.Drawing.Color.RoyalBlue;
            this.UserTaglineCustomTextBox.BorderFocusColor = System.Drawing.Color.MidnightBlue;
            this.UserTaglineCustomTextBox.BorderRadius = 0;
            this.UserTaglineCustomTextBox.BorderSize = 2;
            this.UserTaglineCustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserTaglineCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.UserTaglineCustomTextBox.IsFocused = false;
            this.UserTaglineCustomTextBox.Location = new System.Drawing.Point(171, 772);
            this.UserTaglineCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.UserTaglineCustomTextBox.MaxLength = 32767;
            this.UserTaglineCustomTextBox.Multiline = false;
            this.UserTaglineCustomTextBox.Name = "UserTaglineCustomTextBox";
            this.UserTaglineCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.UserTaglineCustomTextBox.PasswordChar = false;
            this.UserTaglineCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.UserTaglineCustomTextBox.PlaceHolderText = "TAGLINE";
            this.UserTaglineCustomTextBox.ReadOnly = false;
            this.UserTaglineCustomTextBox.Size = new System.Drawing.Size(90, 31);
            this.UserTaglineCustomTextBox.TabIndex = 27;
            this.UserTaglineCustomTextBox.TextContent = "";
            this.UserTaglineCustomTextBox.UnderlineStyle = true;
            this.UserTaglineCustomTextBox.TextChangedEvent += new System.EventHandler(this.FriendRequestFields_TextChangedEvent);
            // 
            // FriendRequestSenderCustomButton
            // 
            this.FriendRequestSenderCustomButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.FriendRequestSenderCustomButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.FriendRequestSenderCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.Add;
            this.FriendRequestSenderCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FriendRequestSenderCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.FriendRequestSenderCustomButton.BorderRadius = 10;
            this.FriendRequestSenderCustomButton.BorderSize = 0;
            this.FriendRequestSenderCustomButton.FlatAppearance.BorderSize = 0;
            this.FriendRequestSenderCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FriendRequestSenderCustomButton.ForeColor = System.Drawing.Color.White;
            this.FriendRequestSenderCustomButton.Location = new System.Drawing.Point(280, 765);
            this.FriendRequestSenderCustomButton.Name = "FriendRequestSenderCustomButton";
            this.FriendRequestSenderCustomButton.Size = new System.Drawing.Size(45, 45);
            this.FriendRequestSenderCustomButton.TabIndex = 25;
            this.FriendRequestSenderCustomButton.TextColor = System.Drawing.Color.White;
            this.FriendRequestSenderCustomButton.UseVisualStyleBackColor = false;
            this.FriendRequestSenderCustomButton.Click += new System.EventHandler(this.FriendRequestSenderCustomButton_Click);
            // 
            // UserIdCustomTextBox
            // 
            this.UserIdCustomTextBox.BackColor = System.Drawing.Color.Aqua;
            this.UserIdCustomTextBox.BorderColor = System.Drawing.Color.RoyalBlue;
            this.UserIdCustomTextBox.BorderFocusColor = System.Drawing.Color.MidnightBlue;
            this.UserIdCustomTextBox.BorderRadius = 0;
            this.UserIdCustomTextBox.BorderSize = 2;
            this.UserIdCustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserIdCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.UserIdCustomTextBox.IsFocused = false;
            this.UserIdCustomTextBox.Location = new System.Drawing.Point(16, 772);
            this.UserIdCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.UserIdCustomTextBox.MaxLength = 32767;
            this.UserIdCustomTextBox.Multiline = false;
            this.UserIdCustomTextBox.Name = "UserIdCustomTextBox";
            this.UserIdCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.UserIdCustomTextBox.PasswordChar = false;
            this.UserIdCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.UserIdCustomTextBox.PlaceHolderText = "YouChat ID";
            this.UserIdCustomTextBox.ReadOnly = false;
            this.UserIdCustomTextBox.Size = new System.Drawing.Size(135, 31);
            this.UserIdCustomTextBox.TabIndex = 26;
            this.UserIdCustomTextBox.TextContent = "";
            this.UserIdCustomTextBox.UnderlineStyle = true;
            this.UserIdCustomTextBox.TextChangedEvent += new System.EventHandler(this.FriendRequestFields_TextChangedEvent);
            // 
            // FriendRequestIdPanel
            // 
            this.FriendRequestIdPanel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.FriendRequestIdPanel.Controls.Add(this.UserIDLabel);
            this.FriendRequestIdPanel.Location = new System.Drawing.Point(0, 0);
            this.FriendRequestIdPanel.Name = "FriendRequestIdPanel";
            this.FriendRequestIdPanel.Size = new System.Drawing.Size(340, 100);
            this.FriendRequestIdPanel.TabIndex = 2;
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDLabel.Location = new System.Drawing.Point(20, 38);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(93, 24);
            this.UserIDLabel.TabIndex = 0;
            this.UserIDLabel.Text = "Your ID:";
            // 
            // FriendRequestPanel
            // 
            this.FriendRequestPanel.AutoScroll = true;
            this.FriendRequestPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.FriendRequestPanel.Location = new System.Drawing.Point(0, 100);
            this.FriendRequestPanel.Name = "FriendRequestPanel";
            this.FriendRequestPanel.Size = new System.Drawing.Size(340, 650);
            this.FriendRequestPanel.TabIndex = 24;
            // 
            // HashtagLabel
            // 
            this.HashtagLabel.AutoSize = true;
            this.HashtagLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HashtagLabel.Location = new System.Drawing.Point(151, 775);
            this.HashtagLabel.Name = "HashtagLabel";
            this.HashtagLabel.Size = new System.Drawing.Size(25, 28);
            this.HashtagLabel.TabIndex = 23;
            this.HashtagLabel.Text = "#";
            // 
            // GroupCreatorBackgroundPanel
            // 
            this.GroupCreatorBackgroundPanel.BackColor = System.Drawing.Color.Aqua;
            this.GroupCreatorBackgroundPanel.Controls.Add(this.GroupCreatorPanel);
            this.GroupCreatorBackgroundPanel.Controls.Add(this.ContinueToGroupSettingsCustomButton);
            this.GroupCreatorBackgroundPanel.Controls.Add(this.SelectedContactsPanel);
            this.GroupCreatorBackgroundPanel.Controls.Add(this.GroupCreatorSearchPanel);
            this.GroupCreatorBackgroundPanel.Location = new System.Drawing.Point(376, 15);
            this.GroupCreatorBackgroundPanel.Name = "GroupCreatorBackgroundPanel";
            this.GroupCreatorBackgroundPanel.Size = new System.Drawing.Size(340, 825);
            this.GroupCreatorBackgroundPanel.TabIndex = 27;
            this.GroupCreatorBackgroundPanel.Visible = false;
            // 
            // GroupCreatorPanel
            // 
            this.GroupCreatorPanel.AutoScroll = true;
            this.GroupCreatorPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.GroupCreatorPanel.Location = new System.Drawing.Point(0, 190);
            this.GroupCreatorPanel.Name = "GroupCreatorPanel";
            this.GroupCreatorPanel.Size = new System.Drawing.Size(340, 560);
            this.GroupCreatorPanel.TabIndex = 2;
            // 
            // ContinueToGroupSettingsCustomButton
            // 
            this.ContinueToGroupSettingsCustomButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ContinueToGroupSettingsCustomButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.ContinueToGroupSettingsCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.ContinueArrow;
            this.ContinueToGroupSettingsCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContinueToGroupSettingsCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ContinueToGroupSettingsCustomButton.BorderRadius = 10;
            this.ContinueToGroupSettingsCustomButton.BorderSize = 0;
            this.ContinueToGroupSettingsCustomButton.Enabled = false;
            this.ContinueToGroupSettingsCustomButton.FlatAppearance.BorderSize = 0;
            this.ContinueToGroupSettingsCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContinueToGroupSettingsCustomButton.ForeColor = System.Drawing.Color.White;
            this.ContinueToGroupSettingsCustomButton.Location = new System.Drawing.Point(110, 765);
            this.ContinueToGroupSettingsCustomButton.Name = "ContinueToGroupSettingsCustomButton";
            this.ContinueToGroupSettingsCustomButton.Size = new System.Drawing.Size(120, 45);
            this.ContinueToGroupSettingsCustomButton.TabIndex = 29;
            this.ContinueToGroupSettingsCustomButton.TextColor = System.Drawing.Color.White;
            this.ContinueToGroupSettingsCustomButton.UseVisualStyleBackColor = false;
            this.ContinueToGroupSettingsCustomButton.Click += new System.EventHandler(this.ContinueToGroupSettingsCustomButton_Click);
            // 
            // SelectedContactsPanel
            // 
            this.SelectedContactsPanel.AutoScroll = true;
            this.SelectedContactsPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.SelectedContactsPanel.Location = new System.Drawing.Point(0, 100);
            this.SelectedContactsPanel.Name = "SelectedContactsPanel";
            this.SelectedContactsPanel.Size = new System.Drawing.Size(340, 90);
            this.SelectedContactsPanel.TabIndex = 0;
            // 
            // GroupCreatorSearchPanel
            // 
            this.GroupCreatorSearchPanel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.GroupCreatorSearchPanel.Controls.Add(this.GroupCreatorSearchBar);
            this.GroupCreatorSearchPanel.Location = new System.Drawing.Point(0, 0);
            this.GroupCreatorSearchPanel.Name = "GroupCreatorSearchPanel";
            this.GroupCreatorSearchPanel.Size = new System.Drawing.Size(340, 100);
            this.GroupCreatorSearchPanel.TabIndex = 2;
            // 
            // GroupCreatorSearchBar
            // 
            this.GroupCreatorSearchBar.BorderColor = System.Drawing.Color.DodgerBlue;
            this.GroupCreatorSearchBar.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.GroupCreatorSearchBar.Location = new System.Drawing.Point(14, 20);
            this.GroupCreatorSearchBar.Name = "GroupCreatorSearchBar";
            this.GroupCreatorSearchBar.Size = new System.Drawing.Size(312, 60);
            this.GroupCreatorSearchBar.TabIndex = 0;
            this.GroupCreatorSearchBar.Load += new System.EventHandler(this.GroupCreatorSearchBar_Load);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageTextBox.ForeColor = System.Drawing.Color.Silver;
            this.MessageTextBox.Location = new System.Drawing.Point(465, 969);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageTextBox.Size = new System.Drawing.Size(1085, 30);
            this.MessageTextBox.TabIndex = 3;
            this.MessageTextBox.Text = "Here You Write Your Message";
            this.MessageTextBox.TextChanged += new System.EventHandler(this.MessageTextBox_TextChanged);
            this.MessageTextBox.Enter += new System.EventHandler(this.MessageTextBox_Enter);
            this.MessageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTextBox_KeyDown);
            this.MessageTextBox.Leave += new System.EventHandler(this.MessageTextBox_Leave);
            // 
            // ChatLabel
            // 
            this.ChatLabel.AutoSize = true;
            this.ChatLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatLabel.Location = new System.Drawing.Point(128, 31);
            this.ChatLabel.Name = "ChatLabel";
            this.ChatLabel.Size = new System.Drawing.Size(129, 37);
            this.ChatLabel.TabIndex = 4;
            this.ChatLabel.Text = "CHATS";
            // 
            // ChatCustomButton
            // 
            this.ChatCustomButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ChatCustomButton.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.ChatCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.Chat;
            this.ChatCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChatCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ChatCustomButton.BorderRadius = 5;
            this.ChatCustomButton.BorderSize = 0;
            this.ChatCustomButton.FlatAppearance.BorderSize = 0;
            this.ChatCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChatCustomButton.ForeColor = System.Drawing.Color.White;
            this.ChatCustomButton.Location = new System.Drawing.Point(255, 15);
            this.ChatCustomButton.Name = "ChatCustomButton";
            this.ChatCustomButton.Size = new System.Drawing.Size(60, 70);
            this.ChatCustomButton.TabIndex = 30;
            this.ChatCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.ChatCustomButton, "To view the chats");
            this.ChatCustomButton.UseVisualStyleBackColor = false;
            this.ChatCustomButton.Click += new System.EventHandler(this.ChatCustomButton_Click);
            // 
            // NewGroupCustomButton
            // 
            this.NewGroupCustomButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.NewGroupCustomButton.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.NewGroupCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.group;
            this.NewGroupCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NewGroupCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.NewGroupCustomButton.BorderRadius = 5;
            this.NewGroupCustomButton.BorderSize = 0;
            this.NewGroupCustomButton.FlatAppearance.BorderSize = 0;
            this.NewGroupCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGroupCustomButton.ForeColor = System.Drawing.Color.White;
            this.NewGroupCustomButton.Location = new System.Drawing.Point(70, 15);
            this.NewGroupCustomButton.Name = "NewGroupCustomButton";
            this.NewGroupCustomButton.Size = new System.Drawing.Size(60, 70);
            this.NewGroupCustomButton.TabIndex = 29;
            this.NewGroupCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.NewGroupCustomButton, "To create a new YouChat group");
            this.NewGroupCustomButton.UseVisualStyleBackColor = false;
            this.NewGroupCustomButton.Click += new System.EventHandler(this.NewGroupCustomButton_Click);
            // 
            // NewContactCustomButton
            // 
            this.NewContactCustomButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.NewContactCustomButton.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.NewContactCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.contact;
            this.NewContactCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NewContactCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.NewContactCustomButton.BorderRadius = 5;
            this.NewContactCustomButton.BorderSize = 0;
            this.NewContactCustomButton.FlatAppearance.BorderSize = 0;
            this.NewContactCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewContactCustomButton.ForeColor = System.Drawing.Color.White;
            this.NewContactCustomButton.Location = new System.Drawing.Point(5, 15);
            this.NewContactCustomButton.Name = "NewContactCustomButton";
            this.NewContactCustomButton.Size = new System.Drawing.Size(60, 70);
            this.NewContactCustomButton.TabIndex = 28;
            this.NewContactCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.NewContactCustomButton, "To manage friend requests");
            this.NewContactCustomButton.UseVisualStyleBackColor = false;
            this.NewContactCustomButton.Click += new System.EventHandler(this.NewContactCustomButton_Click);
            // 
            // MessagePanel
            // 
            this.MessagePanel.AutoScroll = true;
            this.MessagePanel.Controls.Add(this.ChatBackgroundPanel);
            this.MessagePanel.Controls.Add(this.GroupCreatorBackgroundPanel);
            this.MessagePanel.Controls.Add(this.GroupSettingsPanel);
            this.MessagePanel.Location = new System.Drawing.Point(465, 95);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(1435, 850);
            this.MessagePanel.TabIndex = 8;
            // 
            // ChatBackgroundPanel
            // 
            this.ChatBackgroundPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.ChatBackgroundPanel.Controls.Add(this.ChatPanel);
            this.ChatBackgroundPanel.Controls.Add(this.ChatSearchPanel);
            this.ChatBackgroundPanel.Location = new System.Drawing.Point(30, 15);
            this.ChatBackgroundPanel.Name = "ChatBackgroundPanel";
            this.ChatBackgroundPanel.Size = new System.Drawing.Size(340, 825);
            this.ChatBackgroundPanel.TabIndex = 2;
            // 
            // ChatPanel
            // 
            this.ChatPanel.AutoScroll = true;
            this.ChatPanel.Location = new System.Drawing.Point(0, 100);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(340, 725);
            this.ChatPanel.TabIndex = 1;
            // 
            // ChatSearchPanel
            // 
            this.ChatSearchPanel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ChatSearchPanel.Controls.Add(this.ChatSearchBar);
            this.ChatSearchPanel.Location = new System.Drawing.Point(0, 0);
            this.ChatSearchPanel.Name = "ChatSearchPanel";
            this.ChatSearchPanel.Size = new System.Drawing.Size(340, 100);
            this.ChatSearchPanel.TabIndex = 1;
            // 
            // ChatSearchBar
            // 
            this.ChatSearchBar.BorderColor = System.Drawing.Color.DodgerBlue;
            this.ChatSearchBar.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.ChatSearchBar.Location = new System.Drawing.Point(14, 20);
            this.ChatSearchBar.Name = "ChatSearchBar";
            this.ChatSearchBar.Size = new System.Drawing.Size(312, 60);
            this.ChatSearchBar.TabIndex = 0;
            // 
            // GroupSettingsPanel
            // 
            this.GroupSettingsPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.GroupSettingsPanel.Controls.Add(this.GroupIconCircularPictureBox);
            this.GroupSettingsPanel.Controls.Add(this.BackgroundCircularPictureBox);
            this.GroupSettingsPanel.Controls.Add(this.GroupSubjectPanel);
            this.GroupSettingsPanel.Controls.Add(this.GroupIconLabel);
            this.GroupSettingsPanel.Controls.Add(this.GroupCreatorSettingsPanel);
            this.GroupSettingsPanel.Controls.Add(this.GroupCreatorCustomButton);
            this.GroupSettingsPanel.Location = new System.Drawing.Point(755, 15);
            this.GroupSettingsPanel.Name = "GroupSettingsPanel";
            this.GroupSettingsPanel.Size = new System.Drawing.Size(340, 825);
            this.GroupSettingsPanel.TabIndex = 28;
            this.GroupSettingsPanel.Visible = false;
            // 
            // GroupIconCircularPictureBox
            // 
            this.GroupIconCircularPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GroupIconCircularPictureBox.BorderColor = System.Drawing.Color.Gray;
            this.GroupIconCircularPictureBox.BorderSize = 1;
            this.GroupIconCircularPictureBox.HasBorder = false;
            this.GroupIconCircularPictureBox.Location = new System.Drawing.Point(73, 263);
            this.GroupIconCircularPictureBox.Name = "GroupIconCircularPictureBox";
            this.GroupIconCircularPictureBox.Size = new System.Drawing.Size(194, 194);
            this.GroupIconCircularPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GroupIconCircularPictureBox.TabIndex = 32;
            this.GroupIconCircularPictureBox.TabStop = false;
            this.GroupIconCircularPictureBox.BackgroundImageChanged += new System.EventHandler(this.GroupIconCircularPictureBox_BackgroundImageChanged);
            this.GroupIconCircularPictureBox.Click += new System.EventHandler(this.GroupIconCircularPictureBox_Click);
            // 
            // BackgroundCircularPictureBox
            // 
            this.BackgroundCircularPictureBox.BackColor = System.Drawing.Color.Black;
            this.BackgroundCircularPictureBox.BorderColor = System.Drawing.Color.Black;
            this.BackgroundCircularPictureBox.BorderSize = 2;
            this.BackgroundCircularPictureBox.HasBorder = false;
            this.BackgroundCircularPictureBox.Location = new System.Drawing.Point(70, 260);
            this.BackgroundCircularPictureBox.Name = "BackgroundCircularPictureBox";
            this.BackgroundCircularPictureBox.Size = new System.Drawing.Size(200, 200);
            this.BackgroundCircularPictureBox.TabIndex = 31;
            this.BackgroundCircularPictureBox.TabStop = false;
            // 
            // GroupSubjectPanel
            // 
            this.GroupSubjectPanel.BackColor = System.Drawing.Color.Aqua;
            this.GroupSubjectPanel.Controls.Add(this.RestartGroupSubjectCustomButton);
            this.GroupSubjectPanel.Controls.Add(this.GroupSubjectCustomTextBox);
            this.GroupSubjectPanel.Controls.Add(this.GroupSubjectLengthLabel);
            this.GroupSubjectPanel.Controls.Add(this.GroupSubjectLabel);
            this.GroupSubjectPanel.Location = new System.Drawing.Point(0, 530);
            this.GroupSubjectPanel.Name = "GroupSubjectPanel";
            this.GroupSubjectPanel.Size = new System.Drawing.Size(340, 220);
            this.GroupSubjectPanel.TabIndex = 0;
            // 
            // RestartGroupSubjectCustomButton
            // 
            this.RestartGroupSubjectCustomButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.RestartGroupSubjectCustomButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.RestartGroupSubjectCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.RefreshButton;
            this.RestartGroupSubjectCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RestartGroupSubjectCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RestartGroupSubjectCustomButton.BorderRadius = 10;
            this.RestartGroupSubjectCustomButton.BorderSize = 0;
            this.RestartGroupSubjectCustomButton.FlatAppearance.BorderSize = 0;
            this.RestartGroupSubjectCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartGroupSubjectCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartGroupSubjectCustomButton.ForeColor = System.Drawing.Color.White;
            this.RestartGroupSubjectCustomButton.Location = new System.Drawing.Point(135, 150);
            this.RestartGroupSubjectCustomButton.Name = "RestartGroupSubjectCustomButton";
            this.RestartGroupSubjectCustomButton.Size = new System.Drawing.Size(70, 50);
            this.RestartGroupSubjectCustomButton.TabIndex = 31;
            this.RestartGroupSubjectCustomButton.TextColor = System.Drawing.Color.White;
            this.RestartGroupSubjectCustomButton.UseVisualStyleBackColor = false;
            this.RestartGroupSubjectCustomButton.Click += new System.EventHandler(this.RestartGroupSubjectCustomButton_Click);
            // 
            // GroupSubjectCustomTextBox
            // 
            this.GroupSubjectCustomTextBox.BackColor = System.Drawing.Color.Aqua;
            this.GroupSubjectCustomTextBox.BorderColor = System.Drawing.Color.RoyalBlue;
            this.GroupSubjectCustomTextBox.BorderFocusColor = System.Drawing.Color.MidnightBlue;
            this.GroupSubjectCustomTextBox.BorderRadius = 0;
            this.GroupSubjectCustomTextBox.BorderSize = 2;
            this.GroupSubjectCustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupSubjectCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.GroupSubjectCustomTextBox.IsFocused = false;
            this.GroupSubjectCustomTextBox.Location = new System.Drawing.Point(20, 50);
            this.GroupSubjectCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.GroupSubjectCustomTextBox.MaxLength = 80;
            this.GroupSubjectCustomTextBox.Multiline = true;
            this.GroupSubjectCustomTextBox.Name = "GroupSubjectCustomTextBox";
            this.GroupSubjectCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.GroupSubjectCustomTextBox.PasswordChar = false;
            this.GroupSubjectCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.GroupSubjectCustomTextBox.PlaceHolderText = "Choose the YouChat group subject";
            this.GroupSubjectCustomTextBox.ReadOnly = false;
            this.GroupSubjectCustomTextBox.Size = new System.Drawing.Size(300, 85);
            this.GroupSubjectCustomTextBox.TabIndex = 28;
            this.GroupSubjectCustomTextBox.TextContent = "";
            this.GroupSubjectCustomTextBox.UnderlineStyle = false;
            this.GroupSubjectCustomTextBox.TextChangedEvent += new System.EventHandler(this.GroupSubjectCustomTextBox_TextChangedEvent);
            // 
            // GroupSubjectLengthLabel
            // 
            this.GroupSubjectLengthLabel.AutoSize = true;
            this.GroupSubjectLengthLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupSubjectLengthLabel.Location = new System.Drawing.Point(150, 20);
            this.GroupSubjectLengthLabel.Name = "GroupSubjectLengthLabel";
            this.GroupSubjectLengthLabel.Size = new System.Drawing.Size(64, 18);
            this.GroupSubjectLengthLabel.TabIndex = 30;
            this.GroupSubjectLengthLabel.Text = "Length";
            // 
            // GroupSubjectLabel
            // 
            this.GroupSubjectLabel.AutoSize = true;
            this.GroupSubjectLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupSubjectLabel.Location = new System.Drawing.Point(20, 20);
            this.GroupSubjectLabel.Name = "GroupSubjectLabel";
            this.GroupSubjectLabel.Size = new System.Drawing.Size(128, 18);
            this.GroupSubjectLabel.TabIndex = 29;
            this.GroupSubjectLabel.Text = "Group Subject:";
            // 
            // GroupIconLabel
            // 
            this.GroupIconLabel.AutoSize = true;
            this.GroupIconLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupIconLabel.Location = new System.Drawing.Point(20, 220);
            this.GroupIconLabel.Name = "GroupIconLabel";
            this.GroupIconLabel.Size = new System.Drawing.Size(102, 18);
            this.GroupIconLabel.TabIndex = 30;
            this.GroupIconLabel.Text = "Group Icon:";
            // 
            // GroupCreatorSettingsPanel
            // 
            this.GroupCreatorSettingsPanel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.GroupCreatorSettingsPanel.Controls.Add(this.GroupCreatorSettingsHeadlineLabel);
            this.GroupCreatorSettingsPanel.Controls.Add(this.ReturnToGroupContactsSelectionCustomButton);
            this.GroupCreatorSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.GroupCreatorSettingsPanel.Name = "GroupCreatorSettingsPanel";
            this.GroupCreatorSettingsPanel.Size = new System.Drawing.Size(340, 100);
            this.GroupCreatorSettingsPanel.TabIndex = 2;
            // 
            // GroupCreatorSettingsHeadlineLabel
            // 
            this.GroupCreatorSettingsHeadlineLabel.AutoSize = true;
            this.GroupCreatorSettingsHeadlineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupCreatorSettingsHeadlineLabel.Location = new System.Drawing.Point(125, 31);
            this.GroupCreatorSettingsHeadlineLabel.Name = "GroupCreatorSettingsHeadlineLabel";
            this.GroupCreatorSettingsHeadlineLabel.Size = new System.Drawing.Size(191, 37);
            this.GroupCreatorSettingsHeadlineLabel.TabIndex = 31;
            this.GroupCreatorSettingsHeadlineLabel.Text = "NEW CHAT";
            // 
            // ReturnToGroupContactsSelectionCustomButton
            // 
            this.ReturnToGroupContactsSelectionCustomButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ReturnToGroupContactsSelectionCustomButton.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.ReturnToGroupContactsSelectionCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.ReturnBackArrow;
            this.ReturnToGroupContactsSelectionCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReturnToGroupContactsSelectionCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ReturnToGroupContactsSelectionCustomButton.BorderRadius = 10;
            this.ReturnToGroupContactsSelectionCustomButton.BorderSize = 0;
            this.ReturnToGroupContactsSelectionCustomButton.FlatAppearance.BorderSize = 0;
            this.ReturnToGroupContactsSelectionCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnToGroupContactsSelectionCustomButton.ForeColor = System.Drawing.Color.White;
            this.ReturnToGroupContactsSelectionCustomButton.Location = new System.Drawing.Point(20, 30);
            this.ReturnToGroupContactsSelectionCustomButton.Name = "ReturnToGroupContactsSelectionCustomButton";
            this.ReturnToGroupContactsSelectionCustomButton.Size = new System.Drawing.Size(80, 40);
            this.ReturnToGroupContactsSelectionCustomButton.TabIndex = 30;
            this.ReturnToGroupContactsSelectionCustomButton.TextColor = System.Drawing.Color.White;
            this.ReturnToGroupContactsSelectionCustomButton.UseVisualStyleBackColor = false;
            this.ReturnToGroupContactsSelectionCustomButton.Click += new System.EventHandler(this.ReturnToGroupContactsSelectionCustomButton_Click);
            // 
            // GroupCreatorCustomButton
            // 
            this.GroupCreatorCustomButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.GroupCreatorCustomButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.GroupCreatorCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GroupCreatorCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.GroupCreatorCustomButton.BorderRadius = 10;
            this.GroupCreatorCustomButton.BorderSize = 0;
            this.GroupCreatorCustomButton.FlatAppearance.BorderSize = 0;
            this.GroupCreatorCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GroupCreatorCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupCreatorCustomButton.ForeColor = System.Drawing.Color.White;
            this.GroupCreatorCustomButton.Location = new System.Drawing.Point(95, 765);
            this.GroupCreatorCustomButton.Name = "GroupCreatorCustomButton";
            this.GroupCreatorCustomButton.Size = new System.Drawing.Size(150, 45);
            this.GroupCreatorCustomButton.TabIndex = 28;
            this.GroupCreatorCustomButton.Text = "CREATE";
            this.GroupCreatorCustomButton.TextColor = System.Drawing.Color.White;
            this.GroupCreatorCustomButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GroupCreatorCustomButton.UseVisualStyleBackColor = false;
            this.GroupCreatorCustomButton.Click += new System.EventHandler(this.GroupCreatorCustomButton_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(10, 10);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(0, 18);
            this.TimeLabel.TabIndex = 20;
            // 
            // CurrentChatPanel
            // 
            this.CurrentChatPanel.BackColor = System.Drawing.Color.Turquoise;
            this.CurrentChatPanel.Controls.Add(this.AudioCallCustomButton);
            this.CurrentChatPanel.Controls.Add(this.VideoCallCustomButton);
            this.CurrentChatPanel.Controls.Add(this.ChatParticipantsLabel);
            this.CurrentChatPanel.Controls.Add(this.LastSeenOnlineLabel);
            this.CurrentChatPanel.Controls.Add(this.CurrentChatNameLabel);
            this.CurrentChatPanel.Controls.Add(this.CurrentPictureChatPictureBox);
            this.CurrentChatPanel.Location = new System.Drawing.Point(465, 5);
            this.CurrentChatPanel.Name = "CurrentChatPanel";
            this.CurrentChatPanel.Size = new System.Drawing.Size(1435, 80);
            this.CurrentChatPanel.TabIndex = 0;
            // 
            // AudioCallCustomButton
            // 
            this.AudioCallCustomButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.AudioCallCustomButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.AudioCallCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.AudioCall;
            this.AudioCallCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AudioCallCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.AudioCallCustomButton.BorderRadius = 5;
            this.AudioCallCustomButton.BorderSize = 0;
            this.AudioCallCustomButton.FlatAppearance.BorderSize = 0;
            this.AudioCallCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioCallCustomButton.ForeColor = System.Drawing.Color.White;
            this.AudioCallCustomButton.Location = new System.Drawing.Point(1292, 17);
            this.AudioCallCustomButton.Name = "AudioCallCustomButton";
            this.AudioCallCustomButton.Size = new System.Drawing.Size(50, 50);
            this.AudioCallCustomButton.TabIndex = 31;
            this.AudioCallCustomButton.TextColor = System.Drawing.Color.White;
            this.AudioCallCustomButton.UseVisualStyleBackColor = false;
            // 
            // VideoCallCustomButton
            // 
            this.VideoCallCustomButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.VideoCallCustomButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.VideoCallCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.VideoCall;
            this.VideoCallCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VideoCallCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.VideoCallCustomButton.BorderRadius = 5;
            this.VideoCallCustomButton.BorderSize = 0;
            this.VideoCallCustomButton.FlatAppearance.BorderSize = 0;
            this.VideoCallCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VideoCallCustomButton.ForeColor = System.Drawing.Color.White;
            this.VideoCallCustomButton.Location = new System.Drawing.Point(1360, 17);
            this.VideoCallCustomButton.Name = "VideoCallCustomButton";
            this.VideoCallCustomButton.Size = new System.Drawing.Size(50, 50);
            this.VideoCallCustomButton.TabIndex = 30;
            this.VideoCallCustomButton.TextColor = System.Drawing.Color.White;
            this.VideoCallCustomButton.UseVisualStyleBackColor = false;
            // 
            // ChatParticipantsLabel
            // 
            this.ChatParticipantsLabel.AutoSize = true;
            this.ChatParticipantsLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatParticipantsLabel.Location = new System.Drawing.Point(148, 41);
            this.ChatParticipantsLabel.Name = "ChatParticipantsLabel";
            this.ChatParticipantsLabel.Size = new System.Drawing.Size(101, 18);
            this.ChatParticipantsLabel.TabIndex = 29;
            this.ChatParticipantsLabel.Text = "yuval, yuval";
            // 
            // LastSeenOnlineLabel
            // 
            this.LastSeenOnlineLabel.AutoSize = true;
            this.LastSeenOnlineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastSeenOnlineLabel.Location = new System.Drawing.Point(83, 41);
            this.LastSeenOnlineLabel.Name = "LastSeenOnlineLabel";
            this.LastSeenOnlineLabel.Size = new System.Drawing.Size(59, 18);
            this.LastSeenOnlineLabel.TabIndex = 28;
            this.LastSeenOnlineLabel.Text = "Online";
            // 
            // CurrentChatNameLabel
            // 
            this.CurrentChatNameLabel.AutoSize = true;
            this.CurrentChatNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentChatNameLabel.Location = new System.Drawing.Point(82, 7);
            this.CurrentChatNameLabel.Name = "CurrentChatNameLabel";
            this.CurrentChatNameLabel.Size = new System.Drawing.Size(69, 24);
            this.CurrentChatNameLabel.TabIndex = 27;
            this.CurrentChatNameLabel.Text = "Name";
            // 
            // CurrentPictureChatPictureBox
            // 
            this.CurrentPictureChatPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CurrentPictureChatPictureBox.Location = new System.Drawing.Point(7, 7);
            this.CurrentPictureChatPictureBox.Name = "CurrentPictureChatPictureBox";
            this.CurrentPictureChatPictureBox.Size = new System.Drawing.Size(60, 60);
            this.CurrentPictureChatPictureBox.TabIndex = 26;
            this.CurrentPictureChatPictureBox.TabStop = false;
            // 
            // UploadedPictureOpenFileDialog
            // 
            this.UploadedPictureOpenFileDialog.FileName = "openFileDialog1";
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.OptionsPanel.Controls.Add(this.ChatCustomButton);
            this.OptionsPanel.Controls.Add(this.NewGroupCustomButton);
            this.OptionsPanel.Controls.Add(this.ChatLabel);
            this.OptionsPanel.Controls.Add(this.NewContactCustomButton);
            this.OptionsPanel.Location = new System.Drawing.Point(10, 5);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(340, 100);
            this.OptionsPanel.TabIndex = 29;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "GroupDialogOpenFileDialog";
            // 
            // GroupIconContextMenuStrip
            // 
            this.GroupIconContextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.GroupIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TakePhotoToolStripMenuItem,
            this.UploadPhotoToolStripMenuItem,
            this.EmojiToolStripMenuItem});
            this.GroupIconContextMenuStrip.Name = "GroupIconContextMenuStrip";
            this.GroupIconContextMenuStrip.Size = new System.Drawing.Size(199, 118);
            // 
            // TakePhotoToolStripMenuItem
            // 
            this.TakePhotoToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TakePhotoToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.CameraFlash;
            this.TakePhotoToolStripMenuItem.Name = "TakePhotoToolStripMenuItem";
            this.TakePhotoToolStripMenuItem.Size = new System.Drawing.Size(198, 38);
            this.TakePhotoToolStripMenuItem.Text = "Take Photo";
            this.TakePhotoToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.TakePhotoToolStripMenuItem.Click += new System.EventHandler(this.TakePhotoToolStripMenuItem_Click);
            // 
            // UploadPhotoToolStripMenuItem
            // 
            this.UploadPhotoToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadPhotoToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.UploadImage;
            this.UploadPhotoToolStripMenuItem.Name = "UploadPhotoToolStripMenuItem";
            this.UploadPhotoToolStripMenuItem.Size = new System.Drawing.Size(198, 38);
            this.UploadPhotoToolStripMenuItem.Text = "Upload Photo";
            this.UploadPhotoToolStripMenuItem.Click += new System.EventHandler(this.UploadPhotoToolStripMenuItem_Click);
            // 
            // EmojiToolStripMenuItem
            // 
            this.EmojiToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmojiToolStripMenuItem.Image = global::YouChatApp.Properties.Resources._1f6001;
            this.EmojiToolStripMenuItem.Name = "EmojiToolStripMenuItem";
            this.EmojiToolStripMenuItem.Size = new System.Drawing.Size(198, 38);
            this.EmojiToolStripMenuItem.Text = "Emoji";
            this.EmojiToolStripMenuItem.Click += new System.EventHandler(this.EmojiToolStripMenuItem_Click);
            // 
            // DrawingFileButton
            // 
            this.DrawingFileButton.BackgroundImage = global::YouChatApp.Properties.Resources.DrawingFile;
            this.DrawingFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DrawingFileButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawingFileButton.Location = new System.Drawing.Point(1857, 963);
            this.DrawingFileButton.Name = "DrawingFileButton";
            this.DrawingFileButton.Size = new System.Drawing.Size(40, 40);
            this.DrawingFileButton.TabIndex = 22;
            this.DrawingFileButton.UseVisualStyleBackColor = true;
            // 
            // DocumentFileButton
            // 
            this.DocumentFileButton.BackgroundImage = global::YouChatApp.Properties.Resources.DocumentFile;
            this.DocumentFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DocumentFileButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentFileButton.Location = new System.Drawing.Point(1675, 962);
            this.DocumentFileButton.Name = "DocumentFileButton";
            this.DocumentFileButton.Size = new System.Drawing.Size(40, 40);
            this.DocumentFileButton.TabIndex = 23;
            this.DocumentFileButton.UseVisualStyleBackColor = true;
            // 
            // EmojiFileButton
            // 
            this.EmojiFileButton.BackgroundImage = global::YouChatApp.Properties.Resources.EmojiFile;
            this.EmojiFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EmojiFileButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmojiFileButton.Location = new System.Drawing.Point(1629, 962);
            this.EmojiFileButton.Name = "EmojiFileButton";
            this.EmojiFileButton.Size = new System.Drawing.Size(40, 40);
            this.EmojiFileButton.TabIndex = 24;
            this.EmojiFileButton.UseVisualStyleBackColor = true;
            // 
            // PhotoFileButton
            // 
            this.PhotoFileButton.BackgroundImage = global::YouChatApp.Properties.Resources.PictureFile;
            this.PhotoFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PhotoFileButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhotoFileButton.Location = new System.Drawing.Point(1767, 962);
            this.PhotoFileButton.Name = "PhotoFileButton";
            this.PhotoFileButton.Size = new System.Drawing.Size(40, 40);
            this.PhotoFileButton.TabIndex = 24;
            this.PhotoFileButton.UseVisualStyleBackColor = true;
            this.PhotoFileButton.Click += new System.EventHandler(this.PhotoFileButton_Click);
            // 
            // VideoFileButton
            // 
            this.VideoFileButton.BackgroundImage = global::YouChatApp.Properties.Resources.VideoFile;
            this.VideoFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VideoFileButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoFileButton.Location = new System.Drawing.Point(1813, 962);
            this.VideoFileButton.Name = "VideoFileButton";
            this.VideoFileButton.Size = new System.Drawing.Size(40, 40);
            this.VideoFileButton.TabIndex = 21;
            this.VideoFileButton.UseVisualStyleBackColor = true;
            this.VideoFileButton.Click += new System.EventHandler(this.VideoFileButton_Click);
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.BackgroundImage = global::YouChatApp.Properties.Resources.sendMessage;
            this.SendMessageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SendMessageButton.Enabled = false;
            this.SendMessageButton.Location = new System.Drawing.Point(1563, 950);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(60, 60);
            this.SendMessageButton.TabIndex = 6;
            this.SendMessageButton.UseVisualStyleBackColor = true;
            this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // ProfileButton
            // 
            this.ProfileButton.BackgroundImage = global::YouChatApp.Properties.Resources.UserProfile2;
            this.ProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfileButton.Location = new System.Drawing.Point(13, 940);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(65, 65);
            this.ProfileButton.TabIndex = 0;
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // UserFileCustomButton
            // 
            this.UserFileCustomButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.UserFileCustomButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.UserFileCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.UserFile;
            this.UserFileCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UserFileCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.UserFileCustomButton.BorderRadius = 5;
            this.UserFileCustomButton.BorderSize = 0;
            this.UserFileCustomButton.FlatAppearance.BorderSize = 0;
            this.UserFileCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserFileCustomButton.ForeColor = System.Drawing.Color.White;
            this.UserFileCustomButton.Location = new System.Drawing.Point(1721, 962);
            this.UserFileCustomButton.Name = "UserFileCustomButton";
            this.UserFileCustomButton.Size = new System.Drawing.Size(40, 40);
            this.UserFileCustomButton.TabIndex = 32;
            this.UserFileCustomButton.TextColor = System.Drawing.Color.White;
            this.UserFileCustomButton.UseVisualStyleBackColor = false;
            this.UserFileCustomButton.Click += new System.EventHandler(this.UserFileCustomButton_Click);
            // 
            // YouChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Controls.Add(this.UserFileCustomButton);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.DrawingFileButton);
            this.Controls.Add(this.DocumentFileButton);
            this.Controls.Add(this.EmojiFileButton);
            this.Controls.Add(this.PhotoFileButton);
            this.Controls.Add(this.VideoFileButton);
            this.Controls.Add(this.CurrentChatPanel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.MessagePanel);
            this.Controls.Add(this.SendMessageButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.ProfileButton);
            this.Controls.Add(this.ContactManagementPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YouChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouChat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.YouChat_Load);
            this.ContactManagementPanel.ResumeLayout(false);
            this.ContactManagementPanel.PerformLayout();
            this.FriendRequestIdPanel.ResumeLayout(false);
            this.FriendRequestIdPanel.PerformLayout();
            this.GroupCreatorBackgroundPanel.ResumeLayout(false);
            this.GroupCreatorSearchPanel.ResumeLayout(false);
            this.MessagePanel.ResumeLayout(false);
            this.ChatBackgroundPanel.ResumeLayout(false);
            this.ChatSearchPanel.ResumeLayout(false);
            this.GroupSettingsPanel.ResumeLayout(false);
            this.GroupSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupIconCircularPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundCircularPictureBox)).EndInit();
            this.GroupSubjectPanel.ResumeLayout(false);
            this.GroupSubjectPanel.PerformLayout();
            this.GroupCreatorSettingsPanel.ResumeLayout(false);
            this.GroupCreatorSettingsPanel.PerformLayout();
            this.CurrentChatPanel.ResumeLayout(false);
            this.CurrentChatPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPictureChatPictureBox)).EndInit();
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            this.GroupIconContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        public System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Label ChatLabel;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button SendMessageButton;
        public System.Windows.Forms.Panel MessagePanel;
        public List<System.Windows.Forms.Label> MessageLabels;
        public List<List<MessageControl>> MessageControlListOfLists;
        public List<ChatControl> ChatControlListOfContacts;
        public List<FriendRequestControl> ListOfFriendRequestControl;
        public List<ContactControl> ContactControlList;
        public List<ProfileControl> ProfileControlList;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Panel CurrentChatPanel;
        private System.Windows.Forms.Button VideoFileButton;
        private System.Windows.Forms.Button DocumentFileButton;
        private System.Windows.Forms.Button DrawingFileButton;
        private System.Windows.Forms.Button PhotoFileButton;
        private System.Windows.Forms.Button EmojiFileButton;
        private System.Windows.Forms.PictureBox CurrentPictureChatPictureBox;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.Label HashtagLabel;
        private System.Windows.Forms.Panel ContactManagementPanel;
        private System.Windows.Forms.Label ChatParticipantsLabel;
        private System.Windows.Forms.Label LastSeenOnlineLabel;
        private System.Windows.Forms.Label CurrentChatNameLabel;
        private System.Windows.Forms.Panel GroupCreatorBackgroundPanel;
        private System.Windows.Forms.OpenFileDialog UploadedPictureOpenFileDialog;
        private System.Windows.Forms.Panel FriendRequestPanel;
        private CustomButton VideoCallCustomButton;
        private CustomButton AudioCallCustomButton;
        private System.Windows.Forms.Panel ChatSearchPanel;
        private CustomButton NewContactCustomButton;
        private System.Windows.Forms.Panel ChatBackgroundPanel;
        private System.Windows.Forms.Panel OptionsPanel;
        private CustomButton ChatCustomButton;
        private CustomButton NewGroupCustomButton;
        private SearchBar ChatSearchBar;
        private System.Windows.Forms.Panel ChatPanel;
        private Panel GroupCreatorPanel;
        private Panel GroupCreatorSearchPanel;
        private SearchBar GroupCreatorSearchBar;
        private Panel FriendRequestIdPanel;
        private CustomButton FriendRequestSenderCustomButton;
        private CustomTextBox UserTaglineCustomTextBox;
        private CustomTextBox UserIdCustomTextBox;
        private Panel SelectedContactsPanel;
        private Panel GroupSubjectPanel;
        private Label GroupSubjectLabel;
        private CustomButton GroupCreatorCustomButton;
        private Label GroupIconLabel;
        private CustomButton ContinueToGroupSettingsCustomButton;
        private Panel GroupSettingsPanel;
        private Panel GroupCreatorSettingsPanel;
        private CustomButton ReturnToGroupContactsSelectionCustomButton;
        private Label GroupCreatorSettingsHeadlineLabel;
        private Label GroupSubjectLengthLabel;
        private CustomTextBox GroupSubjectCustomTextBox;
        private CustomButton RestartGroupSubjectCustomButton;
        private OpenFileDialog openFileDialog1;
        private CircularPictureBox BackgroundCircularPictureBox;
        private CircularPictureBox GroupIconCircularPictureBox;
        private ContextMenuStrip GroupIconContextMenuStrip;
        private ToolStripMenuItem TakePhotoToolStripMenuItem;
        private ToolStripMenuItem UploadPhotoToolStripMenuItem;
        private ToolStripMenuItem EmojiToolStripMenuItem;
        private CustomButton UserFileCustomButton;
    }
}