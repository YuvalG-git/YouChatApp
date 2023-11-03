namespace YouChatApp.AttachedFiles
{
    partial class AudioCall
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
            this.BackgroundPanel = new System.Windows.Forms.Panel();
            this.MicrophoneModeCustomButton = new YouChatApp.Controls.CustomButton();
            this.AudioOutputDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshAudioOutputOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.AudioOutputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.AudioOutputDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.AudioInputDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshAudioInputOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.AudioInputDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.AudioInputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.CallDetailsPanel = new System.Windows.Forms.Panel();
            this.HeadlineLabel = new System.Windows.Forms.Label();
            this.CallTimeLabel = new System.Windows.Forms.Label();
            this.FriendNameLabel = new System.Windows.Forms.Label();
            this.CallDetailsBackgroundPanel = new System.Windows.Forms.Panel();
            this.ContactProfilePicture = new System.Windows.Forms.PictureBox();
            this.CallEnderCustomButton = new YouChatApp.Controls.CustomButton();
            this.BackgroundPanel.SuspendLayout();
            this.AudioOutputDeviceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioOutputDevicePictureBox)).BeginInit();
            this.AudioInputDeviceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioInputDevicePictureBox)).BeginInit();
            this.CallDetailsPanel.SuspendLayout();
            this.CallDetailsBackgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContactProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundPanel
            // 
            this.BackgroundPanel.BackColor = System.Drawing.Color.Black;
            this.BackgroundPanel.Controls.Add(this.MicrophoneModeCustomButton);
            this.BackgroundPanel.Controls.Add(this.AudioOutputDeviceGroupBox);
            this.BackgroundPanel.Controls.Add(this.AudioInputDeviceGroupBox);
            this.BackgroundPanel.Location = new System.Drawing.Point(0, 530);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(600, 130);
            this.BackgroundPanel.TabIndex = 8;
            // 
            // MicrophoneModeCustomButton
            // 
            this.MicrophoneModeCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.MicrophoneModeCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.MicrophoneModeCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.MicrophoneOpen;
            this.MicrophoneModeCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MicrophoneModeCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.MicrophoneModeCustomButton.BorderRadius = 10;
            this.MicrophoneModeCustomButton.BorderSize = 0;
            this.MicrophoneModeCustomButton.Circular = false;
            this.MicrophoneModeCustomButton.FlatAppearance.BorderSize = 0;
            this.MicrophoneModeCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MicrophoneModeCustomButton.ForeColor = System.Drawing.Color.White;
            this.MicrophoneModeCustomButton.Location = new System.Drawing.Point(505, 35);
            this.MicrophoneModeCustomButton.Name = "MicrophoneModeCustomButton";
            this.MicrophoneModeCustomButton.Size = new System.Drawing.Size(80, 60);
            this.MicrophoneModeCustomButton.TabIndex = 16;
            this.MicrophoneModeCustomButton.TextColor = System.Drawing.Color.White;
            this.MicrophoneModeCustomButton.UseVisualStyleBackColor = false;
            this.MicrophoneModeCustomButton.Click += new System.EventHandler(this.MicrophoneModeCustomButton_Click);
            // 
            // AudioOutputDeviceGroupBox
            // 
            this.AudioOutputDeviceGroupBox.Controls.Add(this.RefreshAudioOutputOptionsCustomButton);
            this.AudioOutputDeviceGroupBox.Controls.Add(this.AudioOutputDeviceComboBox);
            this.AudioOutputDeviceGroupBox.Controls.Add(this.AudioOutputDevicePictureBox);
            this.AudioOutputDeviceGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioOutputDeviceGroupBox.ForeColor = System.Drawing.Color.White;
            this.AudioOutputDeviceGroupBox.Location = new System.Drawing.Point(260, 10);
            this.AudioOutputDeviceGroupBox.Name = "AudioOutputDeviceGroupBox";
            this.AudioOutputDeviceGroupBox.Size = new System.Drawing.Size(225, 100);
            this.AudioOutputDeviceGroupBox.TabIndex = 21;
            this.AudioOutputDeviceGroupBox.TabStop = false;
            this.AudioOutputDeviceGroupBox.Text = "Audio Output Device";
            // 
            // RefreshAudioOutputOptionsCustomButton
            // 
            this.RefreshAudioOutputOptionsCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.RefreshAudioOutputOptionsCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.RefreshAudioOutputOptionsCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RefreshAudioOutputOptionsCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshAudioOutputOptionsCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RefreshAudioOutputOptionsCustomButton.BorderRadius = 17;
            this.RefreshAudioOutputOptionsCustomButton.BorderSize = 0;
            this.RefreshAudioOutputOptionsCustomButton.Circular = false;
            this.RefreshAudioOutputOptionsCustomButton.FlatAppearance.BorderSize = 0;
            this.RefreshAudioOutputOptionsCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshAudioOutputOptionsCustomButton.ForeColor = System.Drawing.Color.White;
            this.RefreshAudioOutputOptionsCustomButton.Location = new System.Drawing.Point(185, 60);
            this.RefreshAudioOutputOptionsCustomButton.Name = "RefreshAudioOutputOptionsCustomButton";
            this.RefreshAudioOutputOptionsCustomButton.Size = new System.Drawing.Size(35, 35);
            this.RefreshAudioOutputOptionsCustomButton.TabIndex = 10;
            this.RefreshAudioOutputOptionsCustomButton.TextColor = System.Drawing.Color.White;
            this.RefreshAudioOutputOptionsCustomButton.UseVisualStyleBackColor = false;
            // 
            // AudioOutputDeviceComboBox
            // 
            this.AudioOutputDeviceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioOutputDeviceComboBox.FormattingEnabled = true;
            this.AudioOutputDeviceComboBox.Location = new System.Drawing.Point(38, 41);
            this.AudioOutputDeviceComboBox.Name = "AudioOutputDeviceComboBox";
            this.AudioOutputDeviceComboBox.Size = new System.Drawing.Size(145, 28);
            this.AudioOutputDeviceComboBox.TabIndex = 6;
            this.AudioOutputDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioOutputDeviceComboBox_SelectedIndexChanged);
            // 
            // AudioOutputDevicePictureBox
            // 
            this.AudioOutputDevicePictureBox.Image = global::YouChatApp.Properties.Resources.Headphone;
            this.AudioOutputDevicePictureBox.Location = new System.Drawing.Point(6, 41);
            this.AudioOutputDevicePictureBox.Name = "AudioOutputDevicePictureBox";
            this.AudioOutputDevicePictureBox.Size = new System.Drawing.Size(28, 28);
            this.AudioOutputDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AudioOutputDevicePictureBox.TabIndex = 5;
            this.AudioOutputDevicePictureBox.TabStop = false;
            // 
            // AudioInputDeviceGroupBox
            // 
            this.AudioInputDeviceGroupBox.Controls.Add(this.RefreshAudioInputOptionsCustomButton);
            this.AudioInputDeviceGroupBox.Controls.Add(this.AudioInputDevicePictureBox);
            this.AudioInputDeviceGroupBox.Controls.Add(this.AudioInputDeviceComboBox);
            this.AudioInputDeviceGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioInputDeviceGroupBox.ForeColor = System.Drawing.Color.White;
            this.AudioInputDeviceGroupBox.Location = new System.Drawing.Point(15, 10);
            this.AudioInputDeviceGroupBox.Name = "AudioInputDeviceGroupBox";
            this.AudioInputDeviceGroupBox.Size = new System.Drawing.Size(225, 100);
            this.AudioInputDeviceGroupBox.TabIndex = 20;
            this.AudioInputDeviceGroupBox.TabStop = false;
            this.AudioInputDeviceGroupBox.Text = "Audio Input Device";
            // 
            // RefreshAudioInputOptionsCustomButton
            // 
            this.RefreshAudioInputOptionsCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.RefreshAudioInputOptionsCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.RefreshAudioInputOptionsCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RefreshAudioInputOptionsCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshAudioInputOptionsCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RefreshAudioInputOptionsCustomButton.BorderRadius = 17;
            this.RefreshAudioInputOptionsCustomButton.BorderSize = 0;
            this.RefreshAudioInputOptionsCustomButton.Circular = false;
            this.RefreshAudioInputOptionsCustomButton.FlatAppearance.BorderSize = 0;
            this.RefreshAudioInputOptionsCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshAudioInputOptionsCustomButton.ForeColor = System.Drawing.Color.White;
            this.RefreshAudioInputOptionsCustomButton.Location = new System.Drawing.Point(185, 60);
            this.RefreshAudioInputOptionsCustomButton.Name = "RefreshAudioInputOptionsCustomButton";
            this.RefreshAudioInputOptionsCustomButton.Size = new System.Drawing.Size(35, 35);
            this.RefreshAudioInputOptionsCustomButton.TabIndex = 9;
            this.RefreshAudioInputOptionsCustomButton.TextColor = System.Drawing.Color.White;
            this.RefreshAudioInputOptionsCustomButton.UseVisualStyleBackColor = false;
            // 
            // AudioInputDevicePictureBox
            // 
            this.AudioInputDevicePictureBox.Image = global::YouChatApp.Properties.Resources.Microphone;
            this.AudioInputDevicePictureBox.Location = new System.Drawing.Point(6, 41);
            this.AudioInputDevicePictureBox.Name = "AudioInputDevicePictureBox";
            this.AudioInputDevicePictureBox.Size = new System.Drawing.Size(28, 28);
            this.AudioInputDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AudioInputDevicePictureBox.TabIndex = 5;
            this.AudioInputDevicePictureBox.TabStop = false;
            // 
            // AudioInputDeviceComboBox
            // 
            this.AudioInputDeviceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioInputDeviceComboBox.FormattingEnabled = true;
            this.AudioInputDeviceComboBox.Location = new System.Drawing.Point(38, 41);
            this.AudioInputDeviceComboBox.Name = "AudioInputDeviceComboBox";
            this.AudioInputDeviceComboBox.Size = new System.Drawing.Size(145, 28);
            this.AudioInputDeviceComboBox.TabIndex = 6;
            this.AudioInputDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioInputDeviceComboBox_SelectedIndexChanged);
            // 
            // CallDetailsPanel
            // 
            this.CallDetailsPanel.BackColor = System.Drawing.Color.DimGray;
            this.CallDetailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CallDetailsPanel.Controls.Add(this.HeadlineLabel);
            this.CallDetailsPanel.Controls.Add(this.CallTimeLabel);
            this.CallDetailsPanel.Controls.Add(this.FriendNameLabel);
            this.CallDetailsPanel.Location = new System.Drawing.Point(10, 0);
            this.CallDetailsPanel.Name = "CallDetailsPanel";
            this.CallDetailsPanel.Size = new System.Drawing.Size(580, 110);
            this.CallDetailsPanel.TabIndex = 22;
            // 
            // HeadlineLabel
            // 
            this.HeadlineLabel.AutoSize = true;
            this.HeadlineLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadlineLabel.Location = new System.Drawing.Point(10, 10);
            this.HeadlineLabel.Name = "HeadlineLabel";
            this.HeadlineLabel.Size = new System.Drawing.Size(184, 24);
            this.HeadlineLabel.TabIndex = 2;
            this.HeadlineLabel.Text = "YOUCHAT VOICE CALL";
            // 
            // CallTimeLabel
            // 
            this.CallTimeLabel.AutoSize = true;
            this.CallTimeLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CallTimeLabel.Location = new System.Drawing.Point(10, 75);
            this.CallTimeLabel.Name = "CallTimeLabel";
            this.CallTimeLabel.Size = new System.Drawing.Size(65, 26);
            this.CallTimeLabel.TabIndex = 1;
            this.CallTimeLabel.Text = "00:00";
            // 
            // FriendNameLabel
            // 
            this.FriendNameLabel.AutoSize = true;
            this.FriendNameLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FriendNameLabel.Location = new System.Drawing.Point(10, 40);
            this.FriendNameLabel.Name = "FriendNameLabel";
            this.FriendNameLabel.Size = new System.Drawing.Size(83, 34);
            this.FriendNameLabel.TabIndex = 0;
            this.FriendNameLabel.Text = "name";
            // 
            // CallDetailsBackgroundPanel
            // 
            this.CallDetailsBackgroundPanel.BackColor = System.Drawing.Color.DarkGray;
            this.CallDetailsBackgroundPanel.Controls.Add(this.CallDetailsPanel);
            this.CallDetailsBackgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.CallDetailsBackgroundPanel.Name = "CallDetailsBackgroundPanel";
            this.CallDetailsBackgroundPanel.Size = new System.Drawing.Size(600, 120);
            this.CallDetailsBackgroundPanel.TabIndex = 24;
            // 
            // ContactProfilePicture
            // 
            this.ContactProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContactProfilePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContactProfilePicture.Location = new System.Drawing.Point(0, 120);
            this.ContactProfilePicture.Name = "ContactProfilePicture";
            this.ContactProfilePicture.Size = new System.Drawing.Size(600, 410);
            this.ContactProfilePicture.TabIndex = 25;
            this.ContactProfilePicture.TabStop = false;
            // 
            // CallEnderCustomButton
            // 
            this.CallEnderCustomButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.CallEnderCustomButton.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.CallEnderCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.DeclineCallFinalImage;
            this.CallEnderCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CallEnderCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.CallEnderCustomButton.BorderRadius = 20;
            this.CallEnderCustomButton.BorderSize = 0;
            this.CallEnderCustomButton.Circular = false;
            this.CallEnderCustomButton.FlatAppearance.BorderSize = 0;
            this.CallEnderCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CallEnderCustomButton.ForeColor = System.Drawing.Color.White;
            this.CallEnderCustomButton.Location = new System.Drawing.Point(260, 440);
            this.CallEnderCustomButton.Name = "CallEnderCustomButton";
            this.CallEnderCustomButton.Size = new System.Drawing.Size(80, 80);
            this.CallEnderCustomButton.TabIndex = 17;
            this.CallEnderCustomButton.TextColor = System.Drawing.Color.White;
            this.CallEnderCustomButton.UseVisualStyleBackColor = false;
            // 
            // AudioCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(599, 661);
            this.Controls.Add(this.CallDetailsBackgroundPanel);
            this.Controls.Add(this.CallEnderCustomButton);
            this.Controls.Add(this.BackgroundPanel);
            this.Controls.Add(this.ContactProfilePicture);
            this.Name = "AudioCall";
            this.Text = "AudioCall";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AudioCall_FormClosing);
            this.Load += new System.EventHandler(this.AudioCall_Load);
            this.BackgroundPanel.ResumeLayout(false);
            this.AudioOutputDeviceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AudioOutputDevicePictureBox)).EndInit();
            this.AudioInputDeviceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AudioInputDevicePictureBox)).EndInit();
            this.CallDetailsPanel.ResumeLayout(false);
            this.CallDetailsPanel.PerformLayout();
            this.CallDetailsBackgroundPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContactProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BackgroundPanel;
        private System.Windows.Forms.GroupBox AudioOutputDeviceGroupBox;
        private Controls.CustomButton RefreshAudioOutputOptionsCustomButton;
        private System.Windows.Forms.ComboBox AudioOutputDeviceComboBox;
        private System.Windows.Forms.PictureBox AudioOutputDevicePictureBox;
        private System.Windows.Forms.GroupBox AudioInputDeviceGroupBox;
        private Controls.CustomButton RefreshAudioInputOptionsCustomButton;
        private System.Windows.Forms.PictureBox AudioInputDevicePictureBox;
        private System.Windows.Forms.ComboBox AudioInputDeviceComboBox;
        private System.Windows.Forms.Panel CallDetailsPanel;
        private System.Windows.Forms.Label CallTimeLabel;
        private System.Windows.Forms.Label FriendNameLabel;
        private Controls.CustomButton MicrophoneModeCustomButton;
        private Controls.CustomButton CallEnderCustomButton;
        private System.Windows.Forms.Panel CallDetailsBackgroundPanel;
        private System.Windows.Forms.PictureBox ContactProfilePicture;
        private System.Windows.Forms.Label HeadlineLabel;
    }
}