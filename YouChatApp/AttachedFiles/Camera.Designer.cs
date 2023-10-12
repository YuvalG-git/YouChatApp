namespace YouChatApp.AttachedFiles
{
    partial class Camera
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
            this.CameraDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.BackgroundPanel = new System.Windows.Forms.Panel();
            this.TimerPanel = new System.Windows.Forms.Panel();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.TimerOptionComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.VideoDevicePanel = new System.Windows.Forms.Panel();
            this.VideoDeviceLabel = new System.Windows.Forms.Label();
            this.CameraDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.CameraTimerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TimerOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TwoSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FiveSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TenSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WaitingTimeLabel = new System.Windows.Forms.Label();
            this.UserImageTakenPictureBox = new System.Windows.Forms.PictureBox();
            this.UserVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.CropImageCustomButton = new YouChatApp.Controls.CustomButton();
            this.SaveImageCustomButton = new YouChatApp.Controls.CustomButton();
            this.ImageTakerCustomButton = new YouChatApp.Controls.CustomButton();
            this.RefreshCameraOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.CameraModeCustomButton = new YouChatApp.Controls.CustomButton();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.BackgroundPanel.SuspendLayout();
            this.TimerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.VideoDevicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).BeginInit();
            this.CameraTimerContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserImageTakenPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserVideoPictureBox)).BeginInit();
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
            // BackgroundPanel
            // 
            this.BackgroundPanel.BackColor = System.Drawing.Color.Black;
            this.BackgroundPanel.Controls.Add(this.CropImageCustomButton);
            this.BackgroundPanel.Controls.Add(this.SaveImageCustomButton);
            this.BackgroundPanel.Controls.Add(this.TimerPanel);
            this.BackgroundPanel.Controls.Add(this.ImageTakerCustomButton);
            this.BackgroundPanel.Controls.Add(this.VideoDevicePanel);
            this.BackgroundPanel.Controls.Add(this.CameraModeCustomButton);
            this.BackgroundPanel.Location = new System.Drawing.Point(2, 2);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(1355, 100);
            this.BackgroundPanel.TabIndex = 7;
            // 
            // TimerPanel
            // 
            this.TimerPanel.Controls.Add(this.TimerLabel);
            this.TimerPanel.Controls.Add(this.TimerOptionComboBox);
            this.TimerPanel.Controls.Add(this.pictureBox1);
            this.TimerPanel.Location = new System.Drawing.Point(222, 10);
            this.TimerPanel.Name = "TimerPanel";
            this.TimerPanel.Size = new System.Drawing.Size(165, 75);
            this.TimerPanel.TabIndex = 14;
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.ForeColor = System.Drawing.Color.White;
            this.TimerLabel.Location = new System.Drawing.Point(0, 0);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(53, 18);
            this.TimerLabel.TabIndex = 9;
            this.TimerLabel.Text = "Timer";
            // 
            // TimerOptionComboBox
            // 
            this.TimerOptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimerOptionComboBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerOptionComboBox.FormattingEnabled = true;
            this.TimerOptionComboBox.Items.AddRange(new object[] {
            "Off",
            "2 Seconds",
            "5 Seconds",
            "10 Seconds"});
            this.TimerOptionComboBox.Location = new System.Drawing.Point(35, 32);
            this.TimerOptionComboBox.Name = "TimerOptionComboBox";
            this.TimerOptionComboBox.Size = new System.Drawing.Size(121, 26);
            this.TimerOptionComboBox.TabIndex = 0;
            this.TimerOptionComboBox.SelectedIndexChanged += new System.EventHandler(this.TimerOptionComboBox_SelectedIndexChanged);
            this.TimerOptionComboBox.TextChanged += new System.EventHandler(this.TimerOptionComboBox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::YouChatApp.Properties.Resources.Timer1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
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
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // CameraTimerContextMenuStrip
            // 
            this.CameraTimerContextMenuStrip.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraTimerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimerOffToolStripMenuItem,
            this.TwoSecondToolStripMenuItem,
            this.FiveSecondToolStripMenuItem,
            this.TenSecondToolStripMenuItem});
            this.CameraTimerContextMenuStrip.Name = "CameraTimerContextMenuStrip";
            this.CameraTimerContextMenuStrip.Size = new System.Drawing.Size(132, 92);
            // 
            // TimerOffToolStripMenuItem
            // 
            this.TimerOffToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TimerOffToolStripMenuItem.Name = "TimerOffToolStripMenuItem";
            this.TimerOffToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.TimerOffToolStripMenuItem.Text = "Off";
            // 
            // TwoSecondToolStripMenuItem
            // 
            this.TwoSecondToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TwoSecondToolStripMenuItem.Name = "TwoSecondToolStripMenuItem";
            this.TwoSecondToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.TwoSecondToolStripMenuItem.Text = "2 Sec";
            // 
            // FiveSecondToolStripMenuItem
            // 
            this.FiveSecondToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FiveSecondToolStripMenuItem.Name = "FiveSecondToolStripMenuItem";
            this.FiveSecondToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.FiveSecondToolStripMenuItem.Text = "5 Sec";
            // 
            // TenSecondToolStripMenuItem
            // 
            this.TenSecondToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TenSecondToolStripMenuItem.Name = "TenSecondToolStripMenuItem";
            this.TenSecondToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.TenSecondToolStripMenuItem.Text = "10 Sec";
            // 
            // WaitingTimeLabel
            // 
            this.WaitingTimeLabel.AutoSize = true;
            this.WaitingTimeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaitingTimeLabel.Location = new System.Drawing.Point(613, 119);
            this.WaitingTimeLabel.Name = "WaitingTimeLabel";
            this.WaitingTimeLabel.Size = new System.Drawing.Size(0, 24);
            this.WaitingTimeLabel.TabIndex = 15;
            // 
            // UserImageTakenPictureBox
            // 
            this.UserImageTakenPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UserImageTakenPictureBox.Location = new System.Drawing.Point(664, 158);
            this.UserImageTakenPictureBox.Name = "UserImageTakenPictureBox";
            this.UserImageTakenPictureBox.Size = new System.Drawing.Size(640, 480);
            this.UserImageTakenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserImageTakenPictureBox.TabIndex = 10;
            this.UserImageTakenPictureBox.TabStop = false;
            this.UserImageTakenPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.UserImageTakenPictureBox_Paint);
            this.UserImageTakenPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserImageTakenPictureBox_MouseDown);
            this.UserImageTakenPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserImageTakenPictureBox_MouseMove);
            // 
            // UserVideoPictureBox
            // 
            this.UserVideoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UserVideoPictureBox.Location = new System.Drawing.Point(8, 158);
            this.UserVideoPictureBox.Name = "UserVideoPictureBox";
            this.UserVideoPictureBox.Size = new System.Drawing.Size(640, 480);
            this.UserVideoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserVideoPictureBox.TabIndex = 9;
            this.UserVideoPictureBox.TabStop = false;
            // 
            // CropImageCustomButton
            // 
            this.CropImageCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.CropImageCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.CropImageCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.CropImage;
            this.CropImageCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CropImageCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.CropImageCustomButton.BorderRadius = 10;
            this.CropImageCustomButton.BorderSize = 0;
            this.CropImageCustomButton.FlatAppearance.BorderSize = 0;
            this.CropImageCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CropImageCustomButton.ForeColor = System.Drawing.Color.White;
            this.CropImageCustomButton.Location = new System.Drawing.Point(880, 25);
            this.CropImageCustomButton.Name = "CropImageCustomButton";
            this.CropImageCustomButton.Size = new System.Drawing.Size(80, 60);
            this.CropImageCustomButton.TabIndex = 16;
            this.CropImageCustomButton.TextColor = System.Drawing.Color.White;
            this.CropImageCustomButton.UseVisualStyleBackColor = false;
            this.CropImageCustomButton.Click += new System.EventHandler(this.CropImageCustomButton_Click);
            // 
            // SaveImageCustomButton
            // 
            this.SaveImageCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.SaveImageCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.SaveImageCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.SaveOption;
            this.SaveImageCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveImageCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.SaveImageCustomButton.BorderRadius = 10;
            this.SaveImageCustomButton.BorderSize = 0;
            this.SaveImageCustomButton.Enabled = false;
            this.SaveImageCustomButton.FlatAppearance.BorderSize = 0;
            this.SaveImageCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveImageCustomButton.ForeColor = System.Drawing.Color.White;
            this.SaveImageCustomButton.Location = new System.Drawing.Point(774, 25);
            this.SaveImageCustomButton.Name = "SaveImageCustomButton";
            this.SaveImageCustomButton.Size = new System.Drawing.Size(80, 60);
            this.SaveImageCustomButton.TabIndex = 15;
            this.SaveImageCustomButton.TextColor = System.Drawing.Color.White;
            this.SaveImageCustomButton.UseVisualStyleBackColor = false;
            this.SaveImageCustomButton.Click += new System.EventHandler(this.SaveImageCustomButton_Click);
            // 
            // ImageTakerCustomButton
            // 
            this.ImageTakerCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ImageTakerCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.ImageTakerCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.CameraImageTaker;
            this.ImageTakerCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ImageTakerCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ImageTakerCustomButton.BorderRadius = 10;
            this.ImageTakerCustomButton.BorderSize = 0;
            this.ImageTakerCustomButton.FlatAppearance.BorderSize = 0;
            this.ImageTakerCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageTakerCustomButton.ForeColor = System.Drawing.Color.White;
            this.ImageTakerCustomButton.Location = new System.Drawing.Point(598, 15);
            this.ImageTakerCustomButton.Name = "ImageTakerCustomButton";
            this.ImageTakerCustomButton.Size = new System.Drawing.Size(116, 60);
            this.ImageTakerCustomButton.TabIndex = 14;
            this.ImageTakerCustomButton.TextColor = System.Drawing.Color.White;
            this.ImageTakerCustomButton.UseVisualStyleBackColor = false;
            this.ImageTakerCustomButton.Click += new System.EventHandler(this.ImageTakerCustomButton_Click);
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
            this.CameraModeCustomButton.Location = new System.Drawing.Point(393, 15);
            this.CameraModeCustomButton.Name = "CameraModeCustomButton";
            this.CameraModeCustomButton.Size = new System.Drawing.Size(80, 60);
            this.CameraModeCustomButton.TabIndex = 7;
            this.CameraModeCustomButton.TextColor = System.Drawing.Color.White;
            this.CameraModeCustomButton.UseVisualStyleBackColor = false;
            this.CameraModeCustomButton.Click += new System.EventHandler(this.CameraModeCustomButton_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(899, 138);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(80, 17);
            this.hScrollBar1.TabIndex = 17;
            // 
            // Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 713);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.WaitingTimeLabel);
            this.Controls.Add(this.UserImageTakenPictureBox);
            this.Controls.Add(this.UserVideoPictureBox);
            this.Controls.Add(this.BackgroundPanel);
            this.Name = "Camera";
            this.Text = "Camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Camera_FormClosing);
            this.Load += new System.EventHandler(this.Camera_Load);
            this.BackgroundPanel.ResumeLayout(false);
            this.TimerPanel.ResumeLayout(false);
            this.TimerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.VideoDevicePanel.ResumeLayout(false);
            this.VideoDevicePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).EndInit();
            this.CameraTimerContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserImageTakenPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserVideoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CameraDeviceComboBox;
        private System.Windows.Forms.PictureBox CameraDevicePictureBox;
        private Controls.CustomButton CameraModeCustomButton;
        private Controls.CustomButton RefreshCameraOptionsCustomButton;
        private System.Windows.Forms.PictureBox UserVideoPictureBox;
        private System.Windows.Forms.Panel BackgroundPanel;
        private System.Windows.Forms.Panel VideoDevicePanel;
        private System.Windows.Forms.Label VideoDeviceLabel;
        private System.Windows.Forms.PictureBox UserImageTakenPictureBox;
        private Controls.CustomButton ImageTakerCustomButton;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ContextMenuStrip CameraTimerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TimerOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TwoSecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FiveSecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TenSecondToolStripMenuItem;
        private System.Windows.Forms.Panel TimerPanel;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.ComboBox TimerOptionComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label WaitingTimeLabel;
        private Controls.CustomButton SaveImageCustomButton;
        private Controls.CustomButton CropImageCustomButton;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}