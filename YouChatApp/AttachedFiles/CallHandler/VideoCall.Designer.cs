namespace YouChatApp.AttachedFiles
{
    partial class VideoCall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoCall));
            this.CameraDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.AudioInputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.BackgroundPanel = new System.Windows.Forms.Panel();
            this.AudioOutputDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshAudioOutputOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.AudioOutputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.AudioOutputDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.AudioInputDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshAudioInputOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.AudioInputDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.VideoDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.CameraDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.RefreshCameraOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CallEnderCustomButton = new YouChatApp.Controls.CustomButton();
            this.MethodsPanel = new System.Windows.Forms.Panel();
            this.CameraModeCustomButton = new YouChatApp.Controls.CustomButton();
            this.MicrophoneModeCustomButton = new YouChatApp.Controls.CustomButton();
            this.UserVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.RemoteVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.CallDetailsPanel = new System.Windows.Forms.Panel();
            this.CallTimeLabel = new System.Windows.Forms.Label();
            this.FriendNameLabel = new System.Windows.Forms.Label();
            this.CallTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.VideoPanel = new System.Windows.Forms.Panel();
            this.CallDetailsBackgroundPanel = new System.Windows.Forms.Panel();
            this.BackgroundPanel.SuspendLayout();
            this.AudioOutputDeviceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioOutputDevicePictureBox)).BeginInit();
            this.AudioInputDeviceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioInputDevicePictureBox)).BeginInit();
            this.VideoDeviceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).BeginInit();
            this.MethodsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserVideoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoteVideoPictureBox)).BeginInit();
            this.CallDetailsPanel.SuspendLayout();
            this.VideoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraDeviceComboBox
            // 
            this.CameraDeviceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraDeviceComboBox.FormattingEnabled = true;
            this.CameraDeviceComboBox.Location = new System.Drawing.Point(38, 41);
            this.CameraDeviceComboBox.Name = "CameraDeviceComboBox";
            this.CameraDeviceComboBox.Size = new System.Drawing.Size(145, 28);
            this.CameraDeviceComboBox.TabIndex = 0;
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
            // BackgroundPanel
            // 
            this.BackgroundPanel.BackColor = System.Drawing.Color.Black;
            this.BackgroundPanel.Controls.Add(this.AudioOutputDeviceGroupBox);
            this.BackgroundPanel.Controls.Add(this.AudioInputDeviceGroupBox);
            this.BackgroundPanel.Controls.Add(this.VideoDeviceGroupBox);
            this.BackgroundPanel.Location = new System.Drawing.Point(0, 725);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(720, 130);
            this.BackgroundPanel.TabIndex = 7;
            // 
            // AudioOutputDeviceGroupBox
            // 
            this.AudioOutputDeviceGroupBox.Controls.Add(this.RefreshAudioOutputOptionsCustomButton);
            this.AudioOutputDeviceGroupBox.Controls.Add(this.AudioOutputDeviceComboBox);
            this.AudioOutputDeviceGroupBox.Controls.Add(this.AudioOutputDevicePictureBox);
            this.AudioOutputDeviceGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioOutputDeviceGroupBox.ForeColor = System.Drawing.Color.White;
            this.AudioOutputDeviceGroupBox.Location = new System.Drawing.Point(483, 10);
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
            this.RefreshAudioOutputOptionsCustomButton.Click += new System.EventHandler(this.RefreshAudioOptionsCustomButtons_Click);
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
            this.AudioInputDeviceGroupBox.Location = new System.Drawing.Point(247, 10);
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
            this.RefreshAudioInputOptionsCustomButton.Click += new System.EventHandler(this.RefreshAudioOptionsCustomButtons_Click);
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
            // VideoDeviceGroupBox
            // 
            this.VideoDeviceGroupBox.Controls.Add(this.CameraDevicePictureBox);
            this.VideoDeviceGroupBox.Controls.Add(this.RefreshCameraOptionsCustomButton);
            this.VideoDeviceGroupBox.Controls.Add(this.CameraDeviceComboBox);
            this.VideoDeviceGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoDeviceGroupBox.ForeColor = System.Drawing.Color.White;
            this.VideoDeviceGroupBox.Location = new System.Drawing.Point(12, 10);
            this.VideoDeviceGroupBox.Name = "VideoDeviceGroupBox";
            this.VideoDeviceGroupBox.Size = new System.Drawing.Size(225, 100);
            this.VideoDeviceGroupBox.TabIndex = 19;
            this.VideoDeviceGroupBox.TabStop = false;
            this.VideoDeviceGroupBox.Text = "Video Device";
            // 
            // CameraDevicePictureBox
            // 
            this.CameraDevicePictureBox.Image = global::YouChatApp.Properties.Resources.CameraLens;
            this.CameraDevicePictureBox.Location = new System.Drawing.Point(6, 41);
            this.CameraDevicePictureBox.Name = "CameraDevicePictureBox";
            this.CameraDevicePictureBox.Size = new System.Drawing.Size(28, 28);
            this.CameraDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CameraDevicePictureBox.TabIndex = 3;
            this.CameraDevicePictureBox.TabStop = false;
            // 
            // RefreshCameraOptionsCustomButton
            // 
            this.RefreshCameraOptionsCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.RefreshCameraOptionsCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.RefreshCameraOptionsCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RefreshCameraOptionsCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshCameraOptionsCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RefreshCameraOptionsCustomButton.BorderRadius = 17;
            this.RefreshCameraOptionsCustomButton.BorderSize = 0;
            this.RefreshCameraOptionsCustomButton.Circular = false;
            this.RefreshCameraOptionsCustomButton.FlatAppearance.BorderSize = 0;
            this.RefreshCameraOptionsCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshCameraOptionsCustomButton.ForeColor = System.Drawing.Color.White;
            this.RefreshCameraOptionsCustomButton.Location = new System.Drawing.Point(185, 60);
            this.RefreshCameraOptionsCustomButton.Name = "RefreshCameraOptionsCustomButton";
            this.RefreshCameraOptionsCustomButton.Size = new System.Drawing.Size(35, 35);
            this.RefreshCameraOptionsCustomButton.TabIndex = 8;
            this.RefreshCameraOptionsCustomButton.TextColor = System.Drawing.Color.White;
            this.RefreshCameraOptionsCustomButton.UseVisualStyleBackColor = false;
            this.RefreshCameraOptionsCustomButton.Click += new System.EventHandler(this.RefreshCameraOptionsCustomButton_Click);
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
            this.CallEnderCustomButton.Location = new System.Drawing.Point(630, 10);
            this.CallEnderCustomButton.Name = "CallEnderCustomButton";
            this.CallEnderCustomButton.Size = new System.Drawing.Size(80, 80);
            this.CallEnderCustomButton.TabIndex = 17;
            this.CallEnderCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.CallEnderCustomButton, "To decline the call");
            this.CallEnderCustomButton.UseVisualStyleBackColor = false;
            this.CallEnderCustomButton.Click += new System.EventHandler(this.DeclineCallCustomButton_Click);
            // 
            // MethodsPanel
            // 
            this.MethodsPanel.BackColor = System.Drawing.Color.Black;
            this.MethodsPanel.Controls.Add(this.CameraModeCustomButton);
            this.MethodsPanel.Controls.Add(this.MicrophoneModeCustomButton);
            this.MethodsPanel.Controls.Add(this.CallEnderCustomButton);
            this.MethodsPanel.Location = new System.Drawing.Point(0, 0);
            this.MethodsPanel.Name = "MethodsPanel";
            this.MethodsPanel.Size = new System.Drawing.Size(720, 100);
            this.MethodsPanel.TabIndex = 16;
            // 
            // CameraModeCustomButton
            // 
            this.CameraModeCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.CameraModeCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.CameraModeCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.VideoOpen;
            this.CameraModeCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CameraModeCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.CameraModeCustomButton.BorderRadius = 10;
            this.CameraModeCustomButton.BorderSize = 0;
            this.CameraModeCustomButton.Circular = false;
            this.CameraModeCustomButton.FlatAppearance.BorderSize = 0;
            this.CameraModeCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CameraModeCustomButton.ForeColor = System.Drawing.Color.White;
            this.CameraModeCustomButton.Location = new System.Drawing.Point(20, 20);
            this.CameraModeCustomButton.Name = "CameraModeCustomButton";
            this.CameraModeCustomButton.Size = new System.Drawing.Size(80, 60);
            this.CameraModeCustomButton.TabIndex = 7;
            this.CameraModeCustomButton.TextColor = System.Drawing.Color.White;
            this.CameraModeCustomButton.UseVisualStyleBackColor = false;
            this.CameraModeCustomButton.Click += new System.EventHandler(this.CameraModeCustomButton_Click);
            // 
            // MicrophoneModeCustomButton
            // 
            this.MicrophoneModeCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.MicrophoneModeCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.MicrophoneModeCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.MicrophoneClose;
            this.MicrophoneModeCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MicrophoneModeCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.MicrophoneModeCustomButton.BorderRadius = 10;
            this.MicrophoneModeCustomButton.BorderSize = 0;
            this.MicrophoneModeCustomButton.Circular = false;
            this.MicrophoneModeCustomButton.FlatAppearance.BorderSize = 0;
            this.MicrophoneModeCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MicrophoneModeCustomButton.ForeColor = System.Drawing.Color.White;
            this.MicrophoneModeCustomButton.Location = new System.Drawing.Point(120, 20);
            this.MicrophoneModeCustomButton.Name = "MicrophoneModeCustomButton";
            this.MicrophoneModeCustomButton.Size = new System.Drawing.Size(80, 60);
            this.MicrophoneModeCustomButton.TabIndex = 16;
            this.MicrophoneModeCustomButton.TextColor = System.Drawing.Color.White;
            this.MicrophoneModeCustomButton.UseVisualStyleBackColor = false;
            this.MicrophoneModeCustomButton.Click += new System.EventHandler(this.MicrophoneModeCustomButton_Click);
            // 
            // UserVideoPictureBox
            // 
            this.UserVideoPictureBox.BackColor = System.Drawing.Color.Gray;
            this.UserVideoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UserVideoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserVideoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserVideoPictureBox.Location = new System.Drawing.Point(405, 305);
            this.UserVideoPictureBox.Name = "UserVideoPictureBox";
            this.UserVideoPictureBox.Size = new System.Drawing.Size(240, 180);
            this.UserVideoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserVideoPictureBox.TabIndex = 9;
            this.UserVideoPictureBox.TabStop = false;
            this.UserVideoPictureBox.DoubleClick += new System.EventHandler(this.UserVideoPictureBox_DoubleClick);
            this.UserVideoPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserVideoPictureBox_MouseDown);
            this.UserVideoPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserVideoPictureBox_MouseMove);
            this.UserVideoPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserVideoPictureBox_MouseUp);
            // 
            // RemoteVideoPictureBox
            // 
            this.RemoteVideoPictureBox.BackColor = System.Drawing.Color.Gray;
            this.RemoteVideoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RemoteVideoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RemoteVideoPictureBox.Location = new System.Drawing.Point(5, 5);
            this.RemoteVideoPictureBox.Name = "RemoteVideoPictureBox";
            this.RemoteVideoPictureBox.Size = new System.Drawing.Size(640, 480);
            this.RemoteVideoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RemoteVideoPictureBox.TabIndex = 10;
            this.RemoteVideoPictureBox.TabStop = false;
            this.RemoteVideoPictureBox.DoubleClick += new System.EventHandler(this.RemoteVideoPictureBox_DoubleClick);
            // 
            // CallDetailsPanel
            // 
            this.CallDetailsPanel.BackColor = System.Drawing.Color.DimGray;
            this.CallDetailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CallDetailsPanel.Controls.Add(this.CallTimeLabel);
            this.CallDetailsPanel.Controls.Add(this.FriendNameLabel);
            this.CallDetailsPanel.Location = new System.Drawing.Point(200, 100);
            this.CallDetailsPanel.Name = "CallDetailsPanel";
            this.CallDetailsPanel.Size = new System.Drawing.Size(320, 100);
            this.CallDetailsPanel.TabIndex = 18;
            // 
            // CallTimeLabel
            // 
            this.CallTimeLabel.AutoSize = true;
            this.CallTimeLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CallTimeLabel.Location = new System.Drawing.Point(133, 65);
            this.CallTimeLabel.Name = "CallTimeLabel";
            this.CallTimeLabel.Size = new System.Drawing.Size(65, 26);
            this.CallTimeLabel.TabIndex = 1;
            this.CallTimeLabel.Text = "00:00";
            // 
            // FriendNameLabel
            // 
            this.FriendNameLabel.AutoSize = true;
            this.FriendNameLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FriendNameLabel.Location = new System.Drawing.Point(123, 3);
            this.FriendNameLabel.Name = "FriendNameLabel";
            this.FriendNameLabel.Size = new System.Drawing.Size(83, 34);
            this.FriendNameLabel.TabIndex = 0;
            this.FriendNameLabel.Text = "name";
            // 
            // CallTimeTimer
            // 
            this.CallTimeTimer.Interval = 1000;
            this.CallTimeTimer.Tick += new System.EventHandler(this.CallTimeTimer_Tick);
            // 
            // VideoPanel
            // 
            this.VideoPanel.BackColor = System.Drawing.Color.Black;
            this.VideoPanel.Controls.Add(this.UserVideoPictureBox);
            this.VideoPanel.Controls.Add(this.RemoteVideoPictureBox);
            this.VideoPanel.Location = new System.Drawing.Point(35, 220);
            this.VideoPanel.Name = "VideoPanel";
            this.VideoPanel.Size = new System.Drawing.Size(650, 490);
            this.VideoPanel.TabIndex = 19;
            // 
            // CallDetailsBackgroundPanel
            // 
            this.CallDetailsBackgroundPanel.BackColor = System.Drawing.Color.DarkGray;
            this.CallDetailsBackgroundPanel.Location = new System.Drawing.Point(195, 100);
            this.CallDetailsBackgroundPanel.Name = "CallDetailsBackgroundPanel";
            this.CallDetailsBackgroundPanel.Size = new System.Drawing.Size(330, 105);
            this.CallDetailsBackgroundPanel.TabIndex = 20;
            // 
            // VideoCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(719, 856);
            this.Controls.Add(this.CallDetailsPanel);
            this.Controls.Add(this.MethodsPanel);
            this.Controls.Add(this.BackgroundPanel);
            this.Controls.Add(this.VideoPanel);
            this.Controls.Add(this.CallDetailsBackgroundPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoCall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoCall";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoCall_FormClosing);
            this.BackgroundPanel.ResumeLayout(false);
            this.AudioOutputDeviceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AudioOutputDevicePictureBox)).EndInit();
            this.AudioInputDeviceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AudioInputDevicePictureBox)).EndInit();
            this.VideoDeviceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).EndInit();
            this.MethodsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserVideoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoteVideoPictureBox)).EndInit();
            this.CallDetailsPanel.ResumeLayout(false);
            this.CallDetailsPanel.PerformLayout();
            this.VideoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CameraDeviceComboBox;
        private System.Windows.Forms.PictureBox CameraDevicePictureBox;
        private System.Windows.Forms.PictureBox AudioInputDevicePictureBox;
        private System.Windows.Forms.ComboBox AudioInputDeviceComboBox;
        private Controls.CustomButton CameraModeCustomButton;
        private Controls.CustomButton RefreshCameraOptionsCustomButton;
        private System.Windows.Forms.PictureBox UserVideoPictureBox;
        private System.Windows.Forms.PictureBox RemoteVideoPictureBox;
        private System.Windows.Forms.Panel BackgroundPanel;
        private System.Windows.Forms.PictureBox AudioOutputDevicePictureBox;
        private System.Windows.Forms.ComboBox AudioOutputDeviceComboBox;
        private System.Windows.Forms.ToolTip ToolTip;
        private Controls.CustomButton MicrophoneModeCustomButton;
        private Controls.CustomButton CallEnderCustomButton;
        private System.Windows.Forms.Panel MethodsPanel;
        private System.Windows.Forms.GroupBox VideoDeviceGroupBox;
        private System.Windows.Forms.GroupBox AudioInputDeviceGroupBox;
        private System.Windows.Forms.GroupBox AudioOutputDeviceGroupBox;
        private System.Windows.Forms.Panel CallDetailsPanel;
        private System.Windows.Forms.Label FriendNameLabel;
        private System.Windows.Forms.Label CallTimeLabel;
        private System.Windows.Forms.Timer CallTimeTimer;
        private Controls.CustomButton RefreshAudioOutputOptionsCustomButton;
        private Controls.CustomButton RefreshAudioInputOptionsCustomButton;
        private System.Windows.Forms.Panel VideoPanel;
        private System.Windows.Forms.Panel CallDetailsBackgroundPanel;
    }
}