using System.Collections.Generic;
using System.Drawing;
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
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.ContactManagementPanel = new System.Windows.Forms.Panel();
            this.FriendRequestPanel = new System.Windows.Forms.Panel();
            this.HashtagLabel = new System.Windows.Forms.Label();
            this.UserTagLineTextBox = new System.Windows.Forms.TextBox();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.RequestSender = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IDNameLabel = new System.Windows.Forms.Label();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.GroupCreatorPanel = new System.Windows.Forms.Panel();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.ChatLabel = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ChatButton = new System.Windows.Forms.Button();
            this.NewContactButton = new System.Windows.Forms.Button();
            this.NewGroupButton = new System.Windows.Forms.Button();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.LoadedPictureGroupBox = new System.Windows.Forms.GroupBox();
            this.UploadedPictureRotationButton = new System.Windows.Forms.Button();
            this.LoadedPicturePictureBox = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.TimeLabel = new System.Windows.Forms.Label();
            this.CurrentChatPanel = new System.Windows.Forms.Panel();
            this.ChatParticipantsLabel = new System.Windows.Forms.Label();
            this.LastSeenOnlineLabel = new System.Windows.Forms.Label();
            this.CurrentChatNameLabel = new System.Windows.Forms.Label();
            this.CurrentPictureChatPictureBox = new System.Windows.Forms.PictureBox();
            this.DrawingFileButton = new System.Windows.Forms.Button();
            this.DocumentFileButton = new System.Windows.Forms.Button();
            this.EmojiFileButton = new System.Windows.Forms.Button();
            this.UserFileButton = new System.Windows.Forms.Button();
            this.PhotoFileButton = new System.Windows.Forms.Button();
            this.VideoFileButton = new System.Windows.Forms.Button();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.UploadedPictureOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ContactManagementPanel.SuspendLayout();
            this.GroupCreatorPanel.SuspendLayout();
            this.ChatPanel.SuspendLayout();
            this.MessagePanel.SuspendLayout();
            this.LoadedPictureGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadedPicturePictureBox)).BeginInit();
            this.CurrentChatPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPictureChatPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChatPanel
            // 
            this.ChatPanel.AutoScroll = true;
            this.ChatPanel.Location = new System.Drawing.Point(10, 95);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(300, 825);
            this.ChatPanel.TabIndex = 2;
            // 
            // ContactManagementPanel
            // 
            this.ContactManagementPanel.Controls.Add(this.FriendRequestPanel);
            this.ContactManagementPanel.Controls.Add(this.HashtagLabel);
            this.ContactManagementPanel.Controls.Add(this.UserTagLineTextBox);
            this.ContactManagementPanel.Controls.Add(this.UserIDTextBox);
            this.ContactManagementPanel.Controls.Add(this.RequestSender);
            this.ContactManagementPanel.Controls.Add(this.label2);
            this.ContactManagementPanel.Controls.Add(this.IDNameLabel);
            this.ContactManagementPanel.Controls.Add(this.UserIDLabel);
            this.ContactManagementPanel.Location = new System.Drawing.Point(10, 95);
            this.ContactManagementPanel.Name = "ContactManagementPanel";
            this.ContactManagementPanel.Size = new System.Drawing.Size(300, 825);
            this.ContactManagementPanel.TabIndex = 10;
            this.ContactManagementPanel.Visible = false;
            // 
            // FriendRequestPanel
            // 
            this.FriendRequestPanel.AutoScroll = true;
            this.FriendRequestPanel.Location = new System.Drawing.Point(10, 43);
            this.FriendRequestPanel.Name = "FriendRequestPanel";
            this.FriendRequestPanel.Size = new System.Drawing.Size(277, 492);
            this.FriendRequestPanel.TabIndex = 24;
            // 
            // HashtagLabel
            // 
            this.HashtagLabel.AutoSize = true;
            this.HashtagLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HashtagLabel.Location = new System.Drawing.Point(123, 780);
            this.HashtagLabel.Name = "HashtagLabel";
            this.HashtagLabel.Size = new System.Drawing.Size(25, 28);
            this.HashtagLabel.TabIndex = 23;
            this.HashtagLabel.Text = "#";
            // 
            // UserTagLineTextBox
            // 
            this.UserTagLineTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserTagLineTextBox.ForeColor = System.Drawing.Color.Silver;
            this.UserTagLineTextBox.Location = new System.Drawing.Point(147, 782);
            this.UserTagLineTextBox.Name = "UserTagLineTextBox";
            this.UserTagLineTextBox.Size = new System.Drawing.Size(100, 26);
            this.UserTagLineTextBox.TabIndex = 21;
            this.UserTagLineTextBox.Text = "TAGLINE";
            this.UserTagLineTextBox.Enter += new System.EventHandler(this.UserTagLineTextBox_Enter);
            this.UserTagLineTextBox.Leave += new System.EventHandler(this.UserTagLineTextBox_Leave);
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDTextBox.ForeColor = System.Drawing.Color.Silver;
            this.UserIDTextBox.Location = new System.Drawing.Point(24, 782);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.Size = new System.Drawing.Size(100, 26);
            this.UserIDTextBox.TabIndex = 4;
            this.UserIDTextBox.Text = "YouChat ID";
            this.UserIDTextBox.Enter += new System.EventHandler(this.UserIDTextBox_Enter);
            this.UserIDTextBox.Leave += new System.EventHandler(this.UserIDTextBox_Leave);
            // 
            // RequestSender
            // 
            this.RequestSender.BackgroundImage = global::YouChatApp.Properties.Resources.Add;
            this.RequestSender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RequestSender.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestSender.Location = new System.Drawing.Point(252, 775);
            this.RequestSender.Name = "RequestSender";
            this.RequestSender.Size = new System.Drawing.Size(45, 45);
            this.RequestSender.TabIndex = 3;
            this.RequestSender.UseVisualStyleBackColor = true;
            this.RequestSender.Click += new System.EventHandler(this.RequestSender_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "#A3V3";
            // 
            // IDNameLabel
            // 
            this.IDNameLabel.AutoSize = true;
            this.IDNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDNameLabel.Location = new System.Drawing.Point(115, 22);
            this.IDNameLabel.Name = "IDNameLabel";
            this.IDNameLabel.Size = new System.Drawing.Size(0, 18);
            this.IDNameLabel.TabIndex = 1;
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDLabel.Location = new System.Drawing.Point(30, 22);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(71, 18);
            this.UserIDLabel.TabIndex = 0;
            this.UserIDLabel.Text = "Your ID:";
            // 
            // GroupCreatorPanel
            // 
            this.GroupCreatorPanel.Location = new System.Drawing.Point(13, 92);
            this.GroupCreatorPanel.Name = "GroupCreatorPanel";
            this.GroupCreatorPanel.Size = new System.Drawing.Size(300, 825);
            this.GroupCreatorPanel.TabIndex = 27;
            this.GroupCreatorPanel.Visible = false;
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
            this.ChatLabel.Location = new System.Drawing.Point(130, 35);
            this.ChatLabel.Name = "ChatLabel";
            this.ChatLabel.Size = new System.Drawing.Size(129, 37);
            this.ChatLabel.TabIndex = 4;
            this.ChatLabel.Text = "CHATS";
            // 
            // ChatButton
            // 
            this.ChatButton.BackgroundImage = global::YouChatApp.Properties.Resources.Chat;
            this.ChatButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ChatButton.Location = new System.Drawing.Point(253, 20);
            this.ChatButton.Name = "ChatButton";
            this.ChatButton.Size = new System.Drawing.Size(60, 60);
            this.ChatButton.TabIndex = 26;
            this.ToolTip.SetToolTip(this.ChatButton, "To create a new YouChat group");
            this.ChatButton.UseVisualStyleBackColor = true;
            this.ChatButton.Click += new System.EventHandler(this.ChatButton_Click);
            // 
            // NewContactButton
            // 
            this.NewContactButton.BackgroundImage = global::YouChatApp.Properties.Resources.contact;
            this.NewContactButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewContactButton.Location = new System.Drawing.Point(10, 20);
            this.NewContactButton.Name = "NewContactButton";
            this.NewContactButton.Size = new System.Drawing.Size(60, 60);
            this.NewContactButton.TabIndex = 9;
            this.ToolTip.SetToolTip(this.NewContactButton, "To create a new YouChat group");
            this.NewContactButton.UseVisualStyleBackColor = true;
            this.NewContactButton.Click += new System.EventHandler(this.NewContactButton_Click);
            // 
            // NewGroupButton
            // 
            this.NewGroupButton.BackgroundImage = global::YouChatApp.Properties.Resources.group;
            this.NewGroupButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewGroupButton.Location = new System.Drawing.Point(75, 20);
            this.NewGroupButton.Name = "NewGroupButton";
            this.NewGroupButton.Size = new System.Drawing.Size(60, 60);
            this.NewGroupButton.TabIndex = 5;
            this.ToolTip.SetToolTip(this.NewGroupButton, "To create a new YouChat group");
            this.NewGroupButton.UseVisualStyleBackColor = true;
            this.NewGroupButton.Click += new System.EventHandler(this.NewGroupButton_Click);
            // 
            // MessagePanel
            // 
            this.MessagePanel.AutoScroll = true;
            this.MessagePanel.Controls.Add(this.LoadedPictureGroupBox);
            this.MessagePanel.Location = new System.Drawing.Point(465, 95);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(1435, 850);
            this.MessagePanel.TabIndex = 8;
            // 
            // LoadedPictureGroupBox
            // 
            this.LoadedPictureGroupBox.Controls.Add(this.UploadedPictureRotationButton);
            this.LoadedPictureGroupBox.Controls.Add(this.LoadedPicturePictureBox);
            this.LoadedPictureGroupBox.Location = new System.Drawing.Point(1210, 632);
            this.LoadedPictureGroupBox.Name = "LoadedPictureGroupBox";
            this.LoadedPictureGroupBox.Size = new System.Drawing.Size(200, 193);
            this.LoadedPictureGroupBox.TabIndex = 27;
            this.LoadedPictureGroupBox.TabStop = false;
            this.LoadedPictureGroupBox.Visible = false;
            // 
            // UploadedPictureRotationButton
            // 
            this.UploadedPictureRotationButton.BackgroundImage = global::YouChatApp.Properties.Resources.RotatePicture;
            this.UploadedPictureRotationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UploadedPictureRotationButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadedPictureRotationButton.Location = new System.Drawing.Point(80, 3);
            this.UploadedPictureRotationButton.Name = "UploadedPictureRotationButton";
            this.UploadedPictureRotationButton.Size = new System.Drawing.Size(40, 40);
            this.UploadedPictureRotationButton.TabIndex = 27;
            this.UploadedPictureRotationButton.UseVisualStyleBackColor = true;
            this.UploadedPictureRotationButton.Click += new System.EventHandler(this.UploadedPictureRotationButton_Click);
            // 
            // LoadedPicturePictureBox
            // 
            this.LoadedPicturePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoadedPicturePictureBox.Location = new System.Drawing.Point(29, 49);
            this.LoadedPicturePictureBox.Name = "LoadedPicturePictureBox";
            this.LoadedPicturePictureBox.Size = new System.Drawing.Size(120, 138);
            this.LoadedPicturePictureBox.TabIndex = 0;
            this.LoadedPicturePictureBox.TabStop = false;
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
            this.CurrentChatPanel.Controls.Add(this.ChatParticipantsLabel);
            this.CurrentChatPanel.Controls.Add(this.LastSeenOnlineLabel);
            this.CurrentChatPanel.Controls.Add(this.CurrentChatNameLabel);
            this.CurrentChatPanel.Controls.Add(this.CurrentPictureChatPictureBox);
            this.CurrentChatPanel.Location = new System.Drawing.Point(465, 5);
            this.CurrentChatPanel.Name = "CurrentChatPanel";
            this.CurrentChatPanel.Size = new System.Drawing.Size(1435, 80);
            this.CurrentChatPanel.TabIndex = 0;
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
            this.CurrentPictureChatPictureBox.Location = new System.Drawing.Point(7, 7);
            this.CurrentPictureChatPictureBox.Name = "CurrentPictureChatPictureBox";
            this.CurrentPictureChatPictureBox.Size = new System.Drawing.Size(60, 60);
            this.CurrentPictureChatPictureBox.TabIndex = 26;
            this.CurrentPictureChatPictureBox.TabStop = false;
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
            // UserFileButton
            // 
            this.UserFileButton.BackgroundImage = global::YouChatApp.Properties.Resources.UserFile;
            this.UserFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UserFileButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserFileButton.Location = new System.Drawing.Point(1721, 962);
            this.UserFileButton.Name = "UserFileButton";
            this.UserFileButton.Size = new System.Drawing.Size(40, 40);
            this.UserFileButton.TabIndex = 25;
            this.UserFileButton.UseVisualStyleBackColor = true;
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
            this.ProfileButton.Location = new System.Drawing.Point(13, 934);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(65, 65);
            this.ProfileButton.TabIndex = 0;
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // UploadedPictureOpenFileDialog
            // 
            this.UploadedPictureOpenFileDialog.FileName = "openFileDialog1";
            // 
            // YouChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Controls.Add(this.ChatButton);
            this.Controls.Add(this.DrawingFileButton);
            this.Controls.Add(this.DocumentFileButton);
            this.Controls.Add(this.EmojiFileButton);
            this.Controls.Add(this.UserFileButton);
            this.Controls.Add(this.PhotoFileButton);
            this.Controls.Add(this.VideoFileButton);
            this.Controls.Add(this.CurrentChatPanel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.NewContactButton);
            this.Controls.Add(this.MessagePanel);
            this.Controls.Add(this.SendMessageButton);
            this.Controls.Add(this.NewGroupButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.ProfileButton);
            this.Controls.Add(this.GroupCreatorPanel);
            this.Controls.Add(this.ChatLabel);
            this.Controls.Add(this.ContactManagementPanel);
            this.Controls.Add(this.ChatPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YouChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouChat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.YouChat_Load);
            this.ContactManagementPanel.ResumeLayout(false);
            this.ContactManagementPanel.PerformLayout();
            this.GroupCreatorPanel.ResumeLayout(false);
            this.ChatPanel.ResumeLayout(false);

            this.MessagePanel.ResumeLayout(false);
            this.LoadedPictureGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoadedPicturePictureBox)).EndInit();
            this.CurrentChatPanel.ResumeLayout(false);
            this.CurrentChatPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPictureChatPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        public System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Panel ChatPanel;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Label ChatLabel;
        private System.Windows.Forms.Button NewGroupButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button SendMessageButton;
        public System.Windows.Forms.Panel MessagePanel;
        public List<System.Windows.Forms.Label> MessageLabels;
        public List<List<MessageControl>> MessageControlListOfLists;
        public List<ChatControl> ChatControlListOfContacts;
        public List<FriendRequestControl> ListOfFriendRequestControl;

        private System.Windows.Forms.Button NewContactButton;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Panel CurrentChatPanel;
        private System.Windows.Forms.Button VideoFileButton;
        private System.Windows.Forms.Button DocumentFileButton;
        private System.Windows.Forms.Button DrawingFileButton;
        private System.Windows.Forms.Button PhotoFileButton;
        private System.Windows.Forms.Button UserFileButton;
        private System.Windows.Forms.Button EmojiFileButton;
        private System.Windows.Forms.PictureBox CurrentPictureChatPictureBox;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.Label IDNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RequestSender;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.TextBox UserTagLineTextBox;
        private System.Windows.Forms.Label HashtagLabel;
        private System.Windows.Forms.Panel ContactManagementPanel;
        private System.Windows.Forms.Label ChatParticipantsLabel;
        private System.Windows.Forms.Label LastSeenOnlineLabel;
        private System.Windows.Forms.Label CurrentChatNameLabel;
        private System.Windows.Forms.Button ChatButton;
        private System.Windows.Forms.Panel GroupCreatorPanel;
        private System.Windows.Forms.GroupBox LoadedPictureGroupBox;
        private System.Windows.Forms.PictureBox LoadedPicturePictureBox;
        private System.Windows.Forms.Button UploadedPictureRotationButton;
        private System.Windows.Forms.OpenFileDialog UploadedPictureOpenFileDialog;
        private System.Windows.Forms.Panel FriendRequestPanel;
    }
}