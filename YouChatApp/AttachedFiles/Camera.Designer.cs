﻿namespace YouChatApp.AttachedFiles
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
            this.CameraModeCustomButton = new YouChatApp.Controls.CustomButton();
            this.CropImageCustomButton = new YouChatApp.Controls.CustomButton();
            this.SaveImageCustomButton = new YouChatApp.Controls.CustomButton();
            this.TimerPanel = new System.Windows.Forms.Panel();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.ImageTakerCustomButton = new YouChatApp.Controls.CustomButton();
            this.TimerOptionComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.VideoDevicePanel = new System.Windows.Forms.Panel();
            this.VideoDeviceLabel = new System.Windows.Forms.Label();
            this.RefreshCameraOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.CameraDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CropYLocationHorizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.CropXLocationHorizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.CropSizeCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.CropXLocationYustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.CropXLocationXustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.CropSizeHorizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.CropYLocationLabel = new System.Windows.Forms.Label();
            this.CropXLocationLabel = new System.Windows.Forms.Label();
            this.CropSizeLabel = new System.Windows.Forms.Label();
            this.CropLabel = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.CameraTimerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TimerOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TwoSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FiveSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TenSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WaitingTimeLabel = new System.Windows.Forms.Label();
            this.UserImageTakenPictureBox = new System.Windows.Forms.PictureBox();
            this.UserVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.BackgroundPanel.SuspendLayout();
            this.TimerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.VideoDevicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.CameraDeviceComboBox.Size = new System.Drawing.Size(219, 26);
            this.CameraDeviceComboBox.TabIndex = 0;
            // 
            // BackgroundPanel
            // 
            this.BackgroundPanel.BackColor = System.Drawing.Color.Black;
            this.BackgroundPanel.Controls.Add(this.CameraModeCustomButton);
            this.BackgroundPanel.Controls.Add(this.CropImageCustomButton);
            this.BackgroundPanel.Controls.Add(this.SaveImageCustomButton);
            this.BackgroundPanel.Controls.Add(this.TimerPanel);
            this.BackgroundPanel.Controls.Add(this.VideoDevicePanel);
            this.BackgroundPanel.Controls.Add(this.panel1);
            this.BackgroundPanel.Location = new System.Drawing.Point(2, 2);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(1355, 120);
            this.BackgroundPanel.TabIndex = 7;
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
            this.CameraModeCustomButton.Location = new System.Drawing.Point(1146, 30);
            this.CameraModeCustomButton.Name = "CameraModeCustomButton";
            this.CameraModeCustomButton.Size = new System.Drawing.Size(80, 60);
            this.CameraModeCustomButton.TabIndex = 7;
            this.CameraModeCustomButton.TextColor = System.Drawing.Color.White;
            this.CameraModeCustomButton.UseVisualStyleBackColor = false;
            this.CameraModeCustomButton.Click += new System.EventHandler(this.CameraModeCustomButton_Click);
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
            this.CropImageCustomButton.Location = new System.Drawing.Point(344, 35);
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
            this.SaveImageCustomButton.Location = new System.Drawing.Point(1232, 30);
            this.SaveImageCustomButton.Name = "SaveImageCustomButton";
            this.SaveImageCustomButton.Size = new System.Drawing.Size(80, 60);
            this.SaveImageCustomButton.TabIndex = 15;
            this.SaveImageCustomButton.TextColor = System.Drawing.Color.White;
            this.SaveImageCustomButton.UseVisualStyleBackColor = false;
            this.SaveImageCustomButton.Click += new System.EventHandler(this.SaveImageCustomButton_Click);
            // 
            // TimerPanel
            // 
            this.TimerPanel.Controls.Add(this.TimerLabel);
            this.TimerPanel.Controls.Add(this.ImageTakerCustomButton);
            this.TimerPanel.Controls.Add(this.TimerOptionComboBox);
            this.TimerPanel.Controls.Add(this.pictureBox1);
            this.TimerPanel.Location = new System.Drawing.Point(777, 10);
            this.TimerPanel.Name = "TimerPanel";
            this.TimerPanel.Size = new System.Drawing.Size(316, 75);
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
            this.ImageTakerCustomButton.Location = new System.Drawing.Point(185, 7);
            this.ImageTakerCustomButton.Name = "ImageTakerCustomButton";
            this.ImageTakerCustomButton.Size = new System.Drawing.Size(116, 60);
            this.ImageTakerCustomButton.TabIndex = 14;
            this.ImageTakerCustomButton.TextColor = System.Drawing.Color.White;
            this.ImageTakerCustomButton.UseVisualStyleBackColor = false;
            this.ImageTakerCustomButton.Click += new System.EventHandler(this.ImageTakerCustomButton_Click);
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
            this.VideoDevicePanel.Location = new System.Drawing.Point(442, 10);
            this.VideoDevicePanel.Name = "VideoDevicePanel";
            this.VideoDevicePanel.Size = new System.Drawing.Size(319, 75);
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
            this.RefreshCameraOptionsCustomButton.Location = new System.Drawing.Point(272, 30);
            this.RefreshCameraOptionsCustomButton.Name = "RefreshCameraOptionsCustomButton";
            this.RefreshCameraOptionsCustomButton.Size = new System.Drawing.Size(30, 30);
            this.RefreshCameraOptionsCustomButton.TabIndex = 8;
            this.RefreshCameraOptionsCustomButton.TextColor = System.Drawing.Color.White;
            this.RefreshCameraOptionsCustomButton.UseVisualStyleBackColor = false;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.CropYLocationHorizontalScrollBar);
            this.panel1.Controls.Add(this.CropXLocationHorizontalScrollBar);
            this.panel1.Controls.Add(this.CropSizeCustomTextBox);
            this.panel1.Controls.Add(this.CropXLocationYustomTextBox);
            this.panel1.Controls.Add(this.CropXLocationXustomTextBox);
            this.panel1.Controls.Add(this.CropSizeHorizontalScrollBar);
            this.panel1.Controls.Add(this.CropYLocationLabel);
            this.panel1.Controls.Add(this.CropXLocationLabel);
            this.panel1.Controls.Add(this.CropSizeLabel);
            this.panel1.Controls.Add(this.CropLabel);
            this.panel1.Location = new System.Drawing.Point(10, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 117);
            this.panel1.TabIndex = 14;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CropYLocationHorizontalScrollBar
            // 
            this.CropYLocationHorizontalScrollBar.Location = new System.Drawing.Point(221, 86);
            this.CropYLocationHorizontalScrollBar.Name = "CropYLocationHorizontalScrollBar";
            this.CropYLocationHorizontalScrollBar.Size = new System.Drawing.Size(80, 17);
            this.CropYLocationHorizontalScrollBar.TabIndex = 25;
            // 
            // CropXLocationHorizontalScrollBar
            // 
            this.CropXLocationHorizontalScrollBar.Location = new System.Drawing.Point(221, 55);
            this.CropXLocationHorizontalScrollBar.Name = "CropXLocationHorizontalScrollBar";
            this.CropXLocationHorizontalScrollBar.Size = new System.Drawing.Size(80, 17);
            this.CropXLocationHorizontalScrollBar.TabIndex = 24;
            // 
            // CropSizeCustomTextBox
            // 
            this.CropSizeCustomTextBox.BackColor = System.Drawing.Color.Black;
            this.CropSizeCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CropSizeCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CropSizeCustomTextBox.BorderRadius = 0;
            this.CropSizeCustomTextBox.BorderSize = 2;
            this.CropSizeCustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropSizeCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.CropSizeCustomTextBox.IsFocused = false;
            this.CropSizeCustomTextBox.Location = new System.Drawing.Point(135, 12);
            this.CropSizeCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CropSizeCustomTextBox.MaxLength = 32767;
            this.CropSizeCustomTextBox.Multiline = false;
            this.CropSizeCustomTextBox.Name = "CropSizeCustomTextBox";
            this.CropSizeCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CropSizeCustomTextBox.PasswordChar = false;
            this.CropSizeCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.CropSizeCustomTextBox.PlaceHolderText = "";
            this.CropSizeCustomTextBox.ReadOnly = false;
            this.CropSizeCustomTextBox.Size = new System.Drawing.Size(67, 30);
            this.CropSizeCustomTextBox.TabIndex = 23;
            this.CropSizeCustomTextBox.TextContent = "";
            this.CropSizeCustomTextBox.UnderlineStyle = true;
            // 
            // CropXLocationYustomTextBox
            // 
            this.CropXLocationYustomTextBox.BackColor = System.Drawing.Color.Black;
            this.CropXLocationYustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CropXLocationYustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CropXLocationYustomTextBox.BorderRadius = 0;
            this.CropXLocationYustomTextBox.BorderSize = 2;
            this.CropXLocationYustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropXLocationYustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.CropXLocationYustomTextBox.IsFocused = false;
            this.CropXLocationYustomTextBox.Location = new System.Drawing.Point(105, 73);
            this.CropXLocationYustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CropXLocationYustomTextBox.MaxLength = 32767;
            this.CropXLocationYustomTextBox.Multiline = false;
            this.CropXLocationYustomTextBox.Name = "CropXLocationYustomTextBox";
            this.CropXLocationYustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CropXLocationYustomTextBox.PasswordChar = false;
            this.CropXLocationYustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.CropXLocationYustomTextBox.PlaceHolderText = "";
            this.CropXLocationYustomTextBox.ReadOnly = false;
            this.CropXLocationYustomTextBox.Size = new System.Drawing.Size(67, 30);
            this.CropXLocationYustomTextBox.TabIndex = 22;
            this.CropXLocationYustomTextBox.TextContent = "";
            this.CropXLocationYustomTextBox.UnderlineStyle = true;
            // 
            // CropXLocationXustomTextBox
            // 
            this.CropXLocationXustomTextBox.BackColor = System.Drawing.Color.Black;
            this.CropXLocationXustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CropXLocationXustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CropXLocationXustomTextBox.BorderRadius = 0;
            this.CropXLocationXustomTextBox.BorderSize = 2;
            this.CropXLocationXustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropXLocationXustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.CropXLocationXustomTextBox.IsFocused = false;
            this.CropXLocationXustomTextBox.Location = new System.Drawing.Point(105, 40);
            this.CropXLocationXustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CropXLocationXustomTextBox.MaxLength = 32767;
            this.CropXLocationXustomTextBox.Multiline = false;
            this.CropXLocationXustomTextBox.Name = "CropXLocationXustomTextBox";
            this.CropXLocationXustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CropXLocationXustomTextBox.PasswordChar = false;
            this.CropXLocationXustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.CropXLocationXustomTextBox.PlaceHolderText = "";
            this.CropXLocationXustomTextBox.ReadOnly = false;
            this.CropXLocationXustomTextBox.Size = new System.Drawing.Size(67, 30);
            this.CropXLocationXustomTextBox.TabIndex = 21;
            this.CropXLocationXustomTextBox.TextContent = "";
            this.CropXLocationXustomTextBox.UnderlineStyle = true;
            // 
            // CropSizeHorizontalScrollBar
            // 
            this.CropSizeHorizontalScrollBar.Location = new System.Drawing.Point(221, 27);
            this.CropSizeHorizontalScrollBar.Name = "CropSizeHorizontalScrollBar";
            this.CropSizeHorizontalScrollBar.Size = new System.Drawing.Size(80, 17);
            this.CropSizeHorizontalScrollBar.TabIndex = 17;
            // 
            // CropYLocationLabel
            // 
            this.CropYLocationLabel.AutoSize = true;
            this.CropYLocationLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropYLocationLabel.ForeColor = System.Drawing.Color.White;
            this.CropYLocationLabel.Location = new System.Drawing.Point(3, 86);
            this.CropYLocationLabel.Name = "CropYLocationLabel";
            this.CropYLocationLabel.Size = new System.Drawing.Size(95, 15);
            this.CropYLocationLabel.TabIndex = 19;
            this.CropYLocationLabel.Text = "Y Coordinate:";
            this.CropYLocationLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // CropXLocationLabel
            // 
            this.CropXLocationLabel.AutoSize = true;
            this.CropXLocationLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropXLocationLabel.ForeColor = System.Drawing.Color.White;
            this.CropXLocationLabel.Location = new System.Drawing.Point(3, 55);
            this.CropXLocationLabel.Name = "CropXLocationLabel";
            this.CropXLocationLabel.Size = new System.Drawing.Size(95, 15);
            this.CropXLocationLabel.TabIndex = 18;
            this.CropXLocationLabel.Text = "X Coordinate:";
            // 
            // CropSizeLabel
            // 
            this.CropSizeLabel.AutoSize = true;
            this.CropSizeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropSizeLabel.ForeColor = System.Drawing.Color.White;
            this.CropSizeLabel.Location = new System.Drawing.Point(3, 27);
            this.CropSizeLabel.Name = "CropSizeLabel";
            this.CropSizeLabel.Size = new System.Drawing.Size(110, 15);
            this.CropSizeLabel.TabIndex = 10;
            this.CropSizeLabel.Text = "Width && Height: ";
            // 
            // CropLabel
            // 
            this.CropLabel.AutoSize = true;
            this.CropLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropLabel.ForeColor = System.Drawing.Color.White;
            this.CropLabel.Location = new System.Drawing.Point(0, 0);
            this.CropLabel.Name = "CropLabel";
            this.CropLabel.Size = new System.Drawing.Size(47, 18);
            this.CropLabel.TabIndex = 9;
            this.CropLabel.Text = "Crop";
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
            this.UserImageTakenPictureBox.Location = new System.Drawing.Point(696, 212);
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
            this.UserVideoPictureBox.Location = new System.Drawing.Point(18, 212);
            this.UserVideoPictureBox.Name = "UserVideoPictureBox";
            this.UserVideoPictureBox.Size = new System.Drawing.Size(640, 480);
            this.UserVideoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserVideoPictureBox.TabIndex = 9;
            this.UserVideoPictureBox.TabStop = false;
            // 
            // Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 700);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.HScrollBar CropSizeHorizontalScrollBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CropSizeLabel;
        private System.Windows.Forms.Label CropLabel;
        private System.Windows.Forms.Label CropXLocationLabel;
        private System.Windows.Forms.Label CropYLocationLabel;
        private Controls.CustomTextBox CropSizeCustomTextBox;
        private Controls.CustomTextBox CropXLocationYustomTextBox;
        private Controls.CustomTextBox CropXLocationXustomTextBox;
        private System.Windows.Forms.HScrollBar CropYLocationHorizontalScrollBar;
        private System.Windows.Forms.HScrollBar CropXLocationHorizontalScrollBar;
    }
}