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
            this.CameraDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.AudioInputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.BackgroundPanel = new System.Windows.Forms.Panel();
            this.AudioOutputPanel = new System.Windows.Forms.Panel();
            this.AudioOutputDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.AudioOutputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.AudioOutputDeviceLabel = new System.Windows.Forms.Label();
            this.AudioInputPanel = new System.Windows.Forms.Panel();
            this.AudioInputDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.AudioInputDeviceLabel = new System.Windows.Forms.Label();
            this.VideoDevicePanel = new System.Windows.Forms.Panel();
            this.VideoDeviceLabel = new System.Windows.Forms.Label();
            this.CameraDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.UserVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.RemoteVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.RefreshCameraOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.CameraModeCustomButton = new YouChatApp.Controls.CustomButton();
            this.BackgroundPanel.SuspendLayout();
            this.AudioOutputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioOutputDevicePictureBox)).BeginInit();
            this.AudioInputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioInputDevicePictureBox)).BeginInit();
            this.VideoDevicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserVideoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoteVideoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CameraDeviceComboBox
            // 
            this.CameraDeviceComboBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraDeviceComboBox.FormattingEnabled = true;
            this.CameraDeviceComboBox.Location = new System.Drawing.Point(35, 32);
            this.CameraDeviceComboBox.Name = "CameraDeviceComboBox";
            this.CameraDeviceComboBox.Size = new System.Drawing.Size(121, 26);
            this.CameraDeviceComboBox.TabIndex = 0;
            // 
            // AudioInputDeviceComboBox
            // 
            this.AudioInputDeviceComboBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioInputDeviceComboBox.FormattingEnabled = true;
            this.AudioInputDeviceComboBox.Location = new System.Drawing.Point(35, 32);
            this.AudioInputDeviceComboBox.Name = "AudioInputDeviceComboBox";
            this.AudioInputDeviceComboBox.Size = new System.Drawing.Size(121, 26);
            this.AudioInputDeviceComboBox.TabIndex = 6;
            this.AudioInputDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioDeviceComboBox_SelectedIndexChanged);
            // 
            // BackgroundPanel
            // 
            this.BackgroundPanel.BackColor = System.Drawing.Color.Black;
            this.BackgroundPanel.Controls.Add(this.AudioOutputPanel);
            this.BackgroundPanel.Controls.Add(this.AudioInputPanel);
            this.BackgroundPanel.Controls.Add(this.VideoDevicePanel);
            this.BackgroundPanel.Controls.Add(this.CameraModeCustomButton);
            this.BackgroundPanel.Location = new System.Drawing.Point(2, 2);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(802, 100);
            this.BackgroundPanel.TabIndex = 7;
            // 
            // AudioOutputPanel
            // 
            this.AudioOutputPanel.Controls.Add(this.AudioOutputDevicePictureBox);
            this.AudioOutputPanel.Controls.Add(this.AudioOutputDeviceComboBox);
            this.AudioOutputPanel.Controls.Add(this.AudioOutputDeviceLabel);
            this.AudioOutputPanel.Location = new System.Drawing.Point(441, 10);
            this.AudioOutputPanel.Name = "AudioOutputPanel";
            this.AudioOutputPanel.Size = new System.Drawing.Size(200, 75);
            this.AudioOutputPanel.TabIndex = 15;
            // 
            // AudioOutputDevicePictureBox
            // 
            this.AudioOutputDevicePictureBox.Image = global::YouChatApp.Properties.Resources.Headphone;
            this.AudioOutputDevicePictureBox.Location = new System.Drawing.Point(3, 32);
            this.AudioOutputDevicePictureBox.Name = "AudioOutputDevicePictureBox";
            this.AudioOutputDevicePictureBox.Size = new System.Drawing.Size(26, 26);
            this.AudioOutputDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AudioOutputDevicePictureBox.TabIndex = 5;
            this.AudioOutputDevicePictureBox.TabStop = false;
            // 
            // AudioOutputDeviceComboBox
            // 
            this.AudioOutputDeviceComboBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioOutputDeviceComboBox.FormattingEnabled = true;
            this.AudioOutputDeviceComboBox.Location = new System.Drawing.Point(35, 32);
            this.AudioOutputDeviceComboBox.Name = "AudioOutputDeviceComboBox";
            this.AudioOutputDeviceComboBox.Size = new System.Drawing.Size(121, 26);
            this.AudioOutputDeviceComboBox.TabIndex = 6;
            // 
            // AudioOutputDeviceLabel
            // 
            this.AudioOutputDeviceLabel.AutoSize = true;
            this.AudioOutputDeviceLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioOutputDeviceLabel.ForeColor = System.Drawing.Color.White;
            this.AudioOutputDeviceLabel.Location = new System.Drawing.Point(0, 0);
            this.AudioOutputDeviceLabel.Name = "AudioOutputDeviceLabel";
            this.AudioOutputDeviceLabel.Size = new System.Drawing.Size(172, 18);
            this.AudioOutputDeviceLabel.TabIndex = 9;
            this.AudioOutputDeviceLabel.Text = "Audio Output Device";
            // 
            // AudioInputPanel
            // 
            this.AudioInputPanel.Controls.Add(this.AudioInputDevicePictureBox);
            this.AudioInputPanel.Controls.Add(this.AudioInputDeviceComboBox);
            this.AudioInputPanel.Controls.Add(this.AudioInputDeviceLabel);
            this.AudioInputPanel.Location = new System.Drawing.Point(218, 10);
            this.AudioInputPanel.Name = "AudioInputPanel";
            this.AudioInputPanel.Size = new System.Drawing.Size(200, 75);
            this.AudioInputPanel.TabIndex = 14;
            // 
            // AudioInputDevicePictureBox
            // 
            this.AudioInputDevicePictureBox.Image = global::YouChatApp.Properties.Resources.Microphone;
            this.AudioInputDevicePictureBox.Location = new System.Drawing.Point(3, 32);
            this.AudioInputDevicePictureBox.Name = "AudioInputDevicePictureBox";
            this.AudioInputDevicePictureBox.Size = new System.Drawing.Size(26, 26);
            this.AudioInputDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AudioInputDevicePictureBox.TabIndex = 5;
            this.AudioInputDevicePictureBox.TabStop = false;
            // 
            // AudioInputDeviceLabel
            // 
            this.AudioInputDeviceLabel.AutoSize = true;
            this.AudioInputDeviceLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioInputDeviceLabel.ForeColor = System.Drawing.Color.White;
            this.AudioInputDeviceLabel.Location = new System.Drawing.Point(0, 0);
            this.AudioInputDeviceLabel.Name = "AudioInputDeviceLabel";
            this.AudioInputDeviceLabel.Size = new System.Drawing.Size(158, 18);
            this.AudioInputDeviceLabel.TabIndex = 9;
            this.AudioInputDeviceLabel.Text = "Audio Input Device";
            // 
            // VideoDevicePanel
            // 
            this.VideoDevicePanel.Controls.Add(this.VideoDeviceLabel);
            this.VideoDevicePanel.Controls.Add(this.RefreshCameraOptionsCustomButton);
            this.VideoDevicePanel.Controls.Add(this.CameraDeviceComboBox);
            this.VideoDevicePanel.Controls.Add(this.CameraDevicePictureBox);
            this.VideoDevicePanel.Location = new System.Drawing.Point(3, 10);
            this.VideoDevicePanel.Name = "VideoDevicePanel";
            this.VideoDevicePanel.Size = new System.Drawing.Size(200, 75);
            this.VideoDevicePanel.TabIndex = 13;
            // 
            // VideoDeviceLabel
            // 
            this.VideoDeviceLabel.AutoSize = true;
            this.VideoDeviceLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoDeviceLabel.ForeColor = System.Drawing.Color.White;
            this.VideoDeviceLabel.Location = new System.Drawing.Point(0, 0);
            this.VideoDeviceLabel.Name = "VideoDeviceLabel";
            this.VideoDeviceLabel.Size = new System.Drawing.Size(112, 18);
            this.VideoDeviceLabel.TabIndex = 9;
            this.VideoDeviceLabel.Text = "Video Device";
            // 
            // CameraDevicePictureBox
            // 
            this.CameraDevicePictureBox.Image = global::YouChatApp.Properties.Resources.CameraLens;
            this.CameraDevicePictureBox.Location = new System.Drawing.Point(3, 32);
            this.CameraDevicePictureBox.Name = "CameraDevicePictureBox";
            this.CameraDevicePictureBox.Size = new System.Drawing.Size(26, 26);
            this.CameraDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CameraDevicePictureBox.TabIndex = 3;
            this.CameraDevicePictureBox.TabStop = false;
            // 
            // UserVideoPictureBox
            // 
            this.UserVideoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UserVideoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserVideoPictureBox.Location = new System.Drawing.Point(479, 489);
            this.UserVideoPictureBox.Name = "UserVideoPictureBox";
            this.UserVideoPictureBox.Size = new System.Drawing.Size(240, 180);
            this.UserVideoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserVideoPictureBox.TabIndex = 9;
            this.UserVideoPictureBox.TabStop = false;
            this.UserVideoPictureBox.SizeChanged += new System.EventHandler(this.VideoPictureBox_SizeChanged);
            this.UserVideoPictureBox.Click += new System.EventHandler(this.UserVideoPictureBox_Click);
            this.UserVideoPictureBox.DoubleClick += new System.EventHandler(this.UserVideoPictureBox_DoubleClick);
            this.UserVideoPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserVideoPictureBox_MouseDown);
            this.UserVideoPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserVideoPictureBox_MouseMove);
            this.UserVideoPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserVideoPictureBox_MouseUp);
            // 
            // RemoteVideoPictureBox
            // 
            this.RemoteVideoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RemoteVideoPictureBox.Location = new System.Drawing.Point(79, 189);
            this.RemoteVideoPictureBox.Name = "RemoteVideoPictureBox";
            this.RemoteVideoPictureBox.Size = new System.Drawing.Size(640, 480);
            this.RemoteVideoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RemoteVideoPictureBox.TabIndex = 10;
            this.RemoteVideoPictureBox.TabStop = false;
            // 
            // RefreshCameraOptionsCustomButton
            // 
            this.RefreshCameraOptionsCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.RefreshCameraOptionsCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.RefreshCameraOptionsCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RefreshCameraOptionsCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshCameraOptionsCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RefreshCameraOptionsCustomButton.BorderRadius = 10;
            this.RefreshCameraOptionsCustomButton.BorderSize = 0;
            this.RefreshCameraOptionsCustomButton.FlatAppearance.BorderSize = 0;
            this.RefreshCameraOptionsCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshCameraOptionsCustomButton.ForeColor = System.Drawing.Color.White;
            this.RefreshCameraOptionsCustomButton.Location = new System.Drawing.Point(162, 30);
            this.RefreshCameraOptionsCustomButton.Name = "RefreshCameraOptionsCustomButton";
            this.RefreshCameraOptionsCustomButton.Size = new System.Drawing.Size(30, 30);
            this.RefreshCameraOptionsCustomButton.TabIndex = 8;
            this.RefreshCameraOptionsCustomButton.TextColor = System.Drawing.Color.White;
            this.RefreshCameraOptionsCustomButton.UseVisualStyleBackColor = false;
            this.RefreshCameraOptionsCustomButton.Click += new System.EventHandler(this.RefreshCameraOptionsCustomButton_Click);
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
            this.CameraModeCustomButton.FlatAppearance.BorderSize = 0;
            this.CameraModeCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CameraModeCustomButton.ForeColor = System.Drawing.Color.White;
            this.CameraModeCustomButton.Location = new System.Drawing.Point(696, 18);
            this.CameraModeCustomButton.Name = "CameraModeCustomButton";
            this.CameraModeCustomButton.Size = new System.Drawing.Size(80, 60);
            this.CameraModeCustomButton.TabIndex = 7;
            this.CameraModeCustomButton.TextColor = System.Drawing.Color.White;
            this.CameraModeCustomButton.UseVisualStyleBackColor = false;
            this.CameraModeCustomButton.Click += new System.EventHandler(this.CameraModeCustomButton_Click);
            // 
            // VideoCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 713);
            this.Controls.Add(this.UserVideoPictureBox);
            this.Controls.Add(this.RemoteVideoPictureBox);
            this.Controls.Add(this.BackgroundPanel);
            this.Name = "VideoCall";
            this.Text = "VideoCall";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoCall_FormClosing);
            this.Load += new System.EventHandler(this.VideoCall_Load);
            this.BackgroundPanel.ResumeLayout(false);
            this.AudioOutputPanel.ResumeLayout(false);
            this.AudioOutputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioOutputDevicePictureBox)).EndInit();
            this.AudioInputPanel.ResumeLayout(false);
            this.AudioInputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioInputDevicePictureBox)).EndInit();
            this.VideoDevicePanel.ResumeLayout(false);
            this.VideoDevicePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserVideoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoteVideoPictureBox)).EndInit();
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
        private System.Windows.Forms.Panel AudioInputPanel;
        private System.Windows.Forms.Label AudioInputDeviceLabel;
        private System.Windows.Forms.Panel VideoDevicePanel;
        private System.Windows.Forms.Label VideoDeviceLabel;
        private System.Windows.Forms.Panel AudioOutputPanel;
        private System.Windows.Forms.PictureBox AudioOutputDevicePictureBox;
        private System.Windows.Forms.ComboBox AudioOutputDeviceComboBox;
        private System.Windows.Forms.Label AudioOutputDeviceLabel;
    }
}