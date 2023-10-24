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
            this.MethodsGroupBox = new System.Windows.Forms.GroupBox();
            this.CropImageCustomButton = new YouChatApp.Controls.CustomButton();
            this.CameraModeCustomButton = new YouChatApp.Controls.CustomButton();
            this.ImageTakerCustomButton = new YouChatApp.Controls.CustomButton();
            this.SaveImageCustomButton = new YouChatApp.Controls.CustomButton();
            this.TimerGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TimerOptionComboBox = new System.Windows.Forms.ComboBox();
            this.CropGroupBox = new System.Windows.Forms.GroupBox();
            this.CropYLocationHorizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.CropSizeLabel = new System.Windows.Forms.Label();
            this.CropXLocationHorizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.CropXLocationLabel = new System.Windows.Forms.Label();
            this.CropSizeCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.CropYLocationLabel = new System.Windows.Forms.Label();
            this.CropYLocationustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.CropSizeHorizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.CropXLocationustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.VideoDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.CameraDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.RefreshCameraOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.CameraTimerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TimerOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TwoSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FiveSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TenSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserImageTakenPictureBox = new System.Windows.Forms.PictureBox();
            this.UserVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CameraOpenTimer = new System.Windows.Forms.Timer(this.components);
            this.ReturnCustomButton = new YouChatApp.Controls.CustomButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackgroundPanel.SuspendLayout();
            this.MethodsGroupBox.SuspendLayout();
            this.TimerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CropGroupBox.SuspendLayout();
            this.VideoDeviceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).BeginInit();
            this.CameraTimerContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserImageTakenPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserVideoPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraDeviceComboBox
            // 
            this.CameraDeviceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraDeviceComboBox.FormattingEnabled = true;
            this.CameraDeviceComboBox.Location = new System.Drawing.Point(45, 54);
            this.CameraDeviceComboBox.Name = "CameraDeviceComboBox";
            this.CameraDeviceComboBox.Size = new System.Drawing.Size(250, 28);
            this.CameraDeviceComboBox.TabIndex = 0;
            // 
            // BackgroundPanel
            // 
            this.BackgroundPanel.BackColor = System.Drawing.Color.Black;
            this.BackgroundPanel.Controls.Add(this.MethodsGroupBox);
            this.BackgroundPanel.Controls.Add(this.TimerGroupBox);
            this.BackgroundPanel.Controls.Add(this.CropGroupBox);
            this.BackgroundPanel.Controls.Add(this.VideoDeviceGroupBox);
            this.BackgroundPanel.Location = new System.Drawing.Point(10, 600);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(1300, 150);
            this.BackgroundPanel.TabIndex = 7;
            // 
            // MethodsGroupBox
            // 
            this.MethodsGroupBox.Controls.Add(this.CropImageCustomButton);
            this.MethodsGroupBox.Controls.Add(this.CameraModeCustomButton);
            this.MethodsGroupBox.Controls.Add(this.SaveImageCustomButton);
            this.MethodsGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodsGroupBox.ForeColor = System.Drawing.Color.White;
            this.MethodsGroupBox.Location = new System.Drawing.Point(885, 10);
            this.MethodsGroupBox.Name = "MethodsGroupBox";
            this.MethodsGroupBox.Size = new System.Drawing.Size(400, 125);
            this.MethodsGroupBox.TabIndex = 11;
            this.MethodsGroupBox.TabStop = false;
            this.MethodsGroupBox.Text = "Methods";
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
            this.CropImageCustomButton.Circular = false;
            this.CropImageCustomButton.Enabled = false;
            this.CropImageCustomButton.FlatAppearance.BorderSize = 0;
            this.CropImageCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CropImageCustomButton.ForeColor = System.Drawing.Color.White;
            this.CropImageCustomButton.Location = new System.Drawing.Point(155, 35);
            this.CropImageCustomButton.Name = "CropImageCustomButton";
            this.CropImageCustomButton.Size = new System.Drawing.Size(90, 65);
            this.CropImageCustomButton.TabIndex = 16;
            this.CropImageCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.CropImageCustomButton, "To crop the taken picture");
            this.CropImageCustomButton.UseVisualStyleBackColor = false;
            this.CropImageCustomButton.Click += new System.EventHandler(this.CropImageCustomButton_Click);
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
            this.CameraModeCustomButton.Location = new System.Drawing.Point(40, 35);
            this.CameraModeCustomButton.Name = "CameraModeCustomButton";
            this.CameraModeCustomButton.Size = new System.Drawing.Size(90, 65);
            this.CameraModeCustomButton.TabIndex = 7;
            this.CameraModeCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.CameraModeCustomButton, "To start Video");
            this.CameraModeCustomButton.UseVisualStyleBackColor = false;
            this.CameraModeCustomButton.Click += new System.EventHandler(this.CameraModeCustomButton_Click);
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
            this.ImageTakerCustomButton.Circular = false;
            this.ImageTakerCustomButton.Enabled = false;
            this.ImageTakerCustomButton.FlatAppearance.BorderSize = 0;
            this.ImageTakerCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageTakerCustomButton.ForeColor = System.Drawing.Color.White;
            this.ImageTakerCustomButton.Location = new System.Drawing.Point(590, 10);
            this.ImageTakerCustomButton.Name = "ImageTakerCustomButton";
            this.ImageTakerCustomButton.Size = new System.Drawing.Size(120, 70);
            this.ImageTakerCustomButton.TabIndex = 14;
            this.ImageTakerCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.ImageTakerCustomButton, "To take a picture");
            this.ImageTakerCustomButton.UseVisualStyleBackColor = false;
            this.ImageTakerCustomButton.Click += new System.EventHandler(this.ImageTakerCustomButton_Click);
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
            this.SaveImageCustomButton.Circular = false;
            this.SaveImageCustomButton.Enabled = false;
            this.SaveImageCustomButton.FlatAppearance.BorderSize = 0;
            this.SaveImageCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveImageCustomButton.ForeColor = System.Drawing.Color.White;
            this.SaveImageCustomButton.Location = new System.Drawing.Point(270, 35);
            this.SaveImageCustomButton.Name = "SaveImageCustomButton";
            this.SaveImageCustomButton.Size = new System.Drawing.Size(90, 65);
            this.SaveImageCustomButton.TabIndex = 15;
            this.SaveImageCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.SaveImageCustomButton, "To continue");
            this.SaveImageCustomButton.UseVisualStyleBackColor = false;
            this.SaveImageCustomButton.Click += new System.EventHandler(this.SaveImageCustomButton_Click);
            // 
            // TimerGroupBox
            // 
            this.TimerGroupBox.Controls.Add(this.pictureBox1);
            this.TimerGroupBox.Controls.Add(this.TimerOptionComboBox);
            this.TimerGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerGroupBox.ForeColor = System.Drawing.Color.White;
            this.TimerGroupBox.Location = new System.Drawing.Point(680, 10);
            this.TimerGroupBox.Name = "TimerGroupBox";
            this.TimerGroupBox.Size = new System.Drawing.Size(195, 125);
            this.TimerGroupBox.TabIndex = 11;
            this.TimerGroupBox.TabStop = false;
            this.TimerGroupBox.Text = "Timer";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::YouChatApp.Properties.Resources.Timer1;
            this.pictureBox1.Location = new System.Drawing.Point(10, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // TimerOptionComboBox
            // 
            this.TimerOptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimerOptionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerOptionComboBox.FormattingEnabled = true;
            this.TimerOptionComboBox.Items.AddRange(new object[] {
            "Off",
            "2 Seconds",
            "5 Seconds",
            "10 Seconds"});
            this.TimerOptionComboBox.Location = new System.Drawing.Point(45, 54);
            this.TimerOptionComboBox.Name = "TimerOptionComboBox";
            this.TimerOptionComboBox.Size = new System.Drawing.Size(125, 28);
            this.TimerOptionComboBox.TabIndex = 0;
            this.TimerOptionComboBox.SelectedIndexChanged += new System.EventHandler(this.TimerOptionComboBox_SelectedIndexChanged);
            this.TimerOptionComboBox.TextChanged += new System.EventHandler(this.TimerOptionComboBox_TextChanged);
            // 
            // CropGroupBox
            // 
            this.CropGroupBox.Controls.Add(this.CropYLocationHorizontalScrollBar);
            this.CropGroupBox.Controls.Add(this.CropSizeLabel);
            this.CropGroupBox.Controls.Add(this.CropXLocationHorizontalScrollBar);
            this.CropGroupBox.Controls.Add(this.CropXLocationLabel);
            this.CropGroupBox.Controls.Add(this.CropSizeCustomTextBox);
            this.CropGroupBox.Controls.Add(this.CropYLocationLabel);
            this.CropGroupBox.Controls.Add(this.CropYLocationustomTextBox);
            this.CropGroupBox.Controls.Add(this.CropSizeHorizontalScrollBar);
            this.CropGroupBox.Controls.Add(this.CropXLocationustomTextBox);
            this.CropGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropGroupBox.ForeColor = System.Drawing.Color.White;
            this.CropGroupBox.Location = new System.Drawing.Point(15, 10);
            this.CropGroupBox.Name = "CropGroupBox";
            this.CropGroupBox.Size = new System.Drawing.Size(325, 125);
            this.CropGroupBox.TabIndex = 11;
            this.CropGroupBox.TabStop = false;
            this.CropGroupBox.Text = "Crop";
            // 
            // CropYLocationHorizontalScrollBar
            // 
            this.CropYLocationHorizontalScrollBar.LargeChange = 1;
            this.CropYLocationHorizontalScrollBar.Location = new System.Drawing.Point(230, 94);
            this.CropYLocationHorizontalScrollBar.Name = "CropYLocationHorizontalScrollBar";
            this.CropYLocationHorizontalScrollBar.Size = new System.Drawing.Size(80, 17);
            this.CropYLocationHorizontalScrollBar.TabIndex = 25;
            this.CropYLocationHorizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CropYLocationHorizontalScrollBar_Scroll);
            this.CropYLocationHorizontalScrollBar.ValueChanged += new System.EventHandler(this.CropYLocationHorizontalScrollBar_ValueChanged);
            // 
            // CropSizeLabel
            // 
            this.CropSizeLabel.AutoSize = true;
            this.CropSizeLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropSizeLabel.ForeColor = System.Drawing.Color.White;
            this.CropSizeLabel.Location = new System.Drawing.Point(10, 30);
            this.CropSizeLabel.Name = "CropSizeLabel";
            this.CropSizeLabel.Size = new System.Drawing.Size(122, 21);
            this.CropSizeLabel.TabIndex = 10;
            this.CropSizeLabel.Text = "Width && Height: ";
            // 
            // CropXLocationHorizontalScrollBar
            // 
            this.CropXLocationHorizontalScrollBar.LargeChange = 1;
            this.CropXLocationHorizontalScrollBar.Location = new System.Drawing.Point(230, 64);
            this.CropXLocationHorizontalScrollBar.Name = "CropXLocationHorizontalScrollBar";
            this.CropXLocationHorizontalScrollBar.Size = new System.Drawing.Size(80, 17);
            this.CropXLocationHorizontalScrollBar.TabIndex = 24;
            this.CropXLocationHorizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CropXLocationHorizontalScrollBar_Scroll);
            this.CropXLocationHorizontalScrollBar.ValueChanged += new System.EventHandler(this.CropXLocationHorizontalScrollBar_ValueChanged);
            // 
            // CropXLocationLabel
            // 
            this.CropXLocationLabel.AutoSize = true;
            this.CropXLocationLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropXLocationLabel.ForeColor = System.Drawing.Color.White;
            this.CropXLocationLabel.Location = new System.Drawing.Point(10, 60);
            this.CropXLocationLabel.Name = "CropXLocationLabel";
            this.CropXLocationLabel.Size = new System.Drawing.Size(101, 21);
            this.CropXLocationLabel.TabIndex = 18;
            this.CropXLocationLabel.Text = "X Coordinate:";
            // 
            // CropSizeCustomTextBox
            // 
            this.CropSizeCustomTextBox.BackColor = System.Drawing.Color.Black;
            this.CropSizeCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CropSizeCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CropSizeCustomTextBox.BorderRadius = 0;
            this.CropSizeCustomTextBox.BorderSize = 2;
            this.CropSizeCustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropSizeCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.CropSizeCustomTextBox.IsFocused = false;
            this.CropSizeCustomTextBox.Location = new System.Drawing.Point(139, 15);
            this.CropSizeCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CropSizeCustomTextBox.MaxLength = 32767;
            this.CropSizeCustomTextBox.Multiline = false;
            this.CropSizeCustomTextBox.Name = "CropSizeCustomTextBox";
            this.CropSizeCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CropSizeCustomTextBox.PasswordChar = false;
            this.CropSizeCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.CropSizeCustomTextBox.PlaceHolderText = "";
            this.CropSizeCustomTextBox.ReadOnly = false;
            this.CropSizeCustomTextBox.Size = new System.Drawing.Size(67, 31);
            this.CropSizeCustomTextBox.TabIndex = 23;
            this.CropSizeCustomTextBox.TextContent = "";
            this.CropSizeCustomTextBox.UnderlineStyle = true;
            this.CropSizeCustomTextBox.TextChangedEvent += new System.EventHandler(this.CropSizeCustomTextBox_TextChangedEvent);
            this.CropSizeCustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CropSizeCustomTextBox_KeyDown);
            this.CropSizeCustomTextBox.Leave += new System.EventHandler(this.CropSizeCustomTextBox_Leave);
            // 
            // CropYLocationLabel
            // 
            this.CropYLocationLabel.AutoSize = true;
            this.CropYLocationLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropYLocationLabel.ForeColor = System.Drawing.Color.White;
            this.CropYLocationLabel.Location = new System.Drawing.Point(10, 90);
            this.CropYLocationLabel.Name = "CropYLocationLabel";
            this.CropYLocationLabel.Size = new System.Drawing.Size(101, 21);
            this.CropYLocationLabel.TabIndex = 19;
            this.CropYLocationLabel.Text = "Y Coordinate:";
            this.CropYLocationLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // CropYLocationustomTextBox
            // 
            this.CropYLocationustomTextBox.BackColor = System.Drawing.Color.Black;
            this.CropYLocationustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CropYLocationustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CropYLocationustomTextBox.BorderRadius = 0;
            this.CropYLocationustomTextBox.BorderSize = 2;
            this.CropYLocationustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropYLocationustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.CropYLocationustomTextBox.IsFocused = false;
            this.CropYLocationustomTextBox.Location = new System.Drawing.Point(120, 79);
            this.CropYLocationustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CropYLocationustomTextBox.MaxLength = 32767;
            this.CropYLocationustomTextBox.Multiline = false;
            this.CropYLocationustomTextBox.Name = "CropYLocationustomTextBox";
            this.CropYLocationustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CropYLocationustomTextBox.PasswordChar = false;
            this.CropYLocationustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.CropYLocationustomTextBox.PlaceHolderText = "";
            this.CropYLocationustomTextBox.ReadOnly = false;
            this.CropYLocationustomTextBox.Size = new System.Drawing.Size(67, 31);
            this.CropYLocationustomTextBox.TabIndex = 22;
            this.CropYLocationustomTextBox.TextContent = "";
            this.CropYLocationustomTextBox.UnderlineStyle = true;
            this.CropYLocationustomTextBox.TextChangedEvent += new System.EventHandler(this.CropYLocationustomTextBox_TextChangedEvent);
            this.CropYLocationustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CropYLocationustomTextBox_KeyDown);
            this.CropYLocationustomTextBox.MouseLeave += new System.EventHandler(this.CropYLocationustomTextBox_MouseLeave);
            // 
            // CropSizeHorizontalScrollBar
            // 
            this.CropSizeHorizontalScrollBar.LargeChange = 1;
            this.CropSizeHorizontalScrollBar.Location = new System.Drawing.Point(230, 34);
            this.CropSizeHorizontalScrollBar.Name = "CropSizeHorizontalScrollBar";
            this.CropSizeHorizontalScrollBar.Size = new System.Drawing.Size(80, 17);
            this.CropSizeHorizontalScrollBar.TabIndex = 17;
            this.CropSizeHorizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CropSizeHorizontalScrollBar_Scroll);
            this.CropSizeHorizontalScrollBar.ValueChanged += new System.EventHandler(this.CropSizeHorizontalScrollBar_ValueChanged);
            // 
            // CropXLocationustomTextBox
            // 
            this.CropXLocationustomTextBox.BackColor = System.Drawing.Color.Black;
            this.CropXLocationustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CropXLocationustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CropXLocationustomTextBox.BorderRadius = 0;
            this.CropXLocationustomTextBox.BorderSize = 2;
            this.CropXLocationustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropXLocationustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.CropXLocationustomTextBox.IsFocused = false;
            this.CropXLocationustomTextBox.Location = new System.Drawing.Point(120, 46);
            this.CropXLocationustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CropXLocationustomTextBox.MaxLength = 32767;
            this.CropXLocationustomTextBox.Multiline = false;
            this.CropXLocationustomTextBox.Name = "CropXLocationustomTextBox";
            this.CropXLocationustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CropXLocationustomTextBox.PasswordChar = false;
            this.CropXLocationustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.CropXLocationustomTextBox.PlaceHolderText = "";
            this.CropXLocationustomTextBox.ReadOnly = false;
            this.CropXLocationustomTextBox.Size = new System.Drawing.Size(67, 31);
            this.CropXLocationustomTextBox.TabIndex = 21;
            this.CropXLocationustomTextBox.TextContent = "";
            this.CropXLocationustomTextBox.UnderlineStyle = true;
            this.CropXLocationustomTextBox.TextChangedEvent += new System.EventHandler(this.CropXLocationustomTextBox_TextChangedEvent);
            this.CropXLocationustomTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CropXLocationustomTextBox_KeyDown);
            this.CropXLocationustomTextBox.Leave += new System.EventHandler(this.CropXLocationustomTextBox_Leave);
            // 
            // VideoDeviceGroupBox
            // 
            this.VideoDeviceGroupBox.Controls.Add(this.CameraDevicePictureBox);
            this.VideoDeviceGroupBox.Controls.Add(this.RefreshCameraOptionsCustomButton);
            this.VideoDeviceGroupBox.Controls.Add(this.CameraDeviceComboBox);
            this.VideoDeviceGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoDeviceGroupBox.ForeColor = System.Drawing.Color.White;
            this.VideoDeviceGroupBox.Location = new System.Drawing.Point(350, 10);
            this.VideoDeviceGroupBox.Name = "VideoDeviceGroupBox";
            this.VideoDeviceGroupBox.Size = new System.Drawing.Size(320, 125);
            this.VideoDeviceGroupBox.TabIndex = 10;
            this.VideoDeviceGroupBox.TabStop = false;
            this.VideoDeviceGroupBox.Text = "Video Devices";
            // 
            // CameraDevicePictureBox
            // 
            this.CameraDevicePictureBox.Image = global::YouChatApp.Properties.Resources.CameraLens;
            this.CameraDevicePictureBox.Location = new System.Drawing.Point(10, 54);
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
            this.RefreshCameraOptionsCustomButton.Location = new System.Drawing.Point(280, 85);
            this.RefreshCameraOptionsCustomButton.Name = "RefreshCameraOptionsCustomButton";
            this.RefreshCameraOptionsCustomButton.Size = new System.Drawing.Size(35, 35);
            this.RefreshCameraOptionsCustomButton.TabIndex = 8;
            this.RefreshCameraOptionsCustomButton.TextColor = System.Drawing.Color.White;
            this.RefreshCameraOptionsCustomButton.UseVisualStyleBackColor = false;
            this.RefreshCameraOptionsCustomButton.Click += new System.EventHandler(this.RefreshCameraOptionsCustomButton_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // CameraTimerContextMenuStrip
            // 
            this.CameraTimerContextMenuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraTimerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimerOffToolStripMenuItem,
            this.TwoSecondToolStripMenuItem,
            this.FiveSecondToolStripMenuItem,
            this.TenSecondToolStripMenuItem});
            this.CameraTimerContextMenuStrip.Name = "CameraTimerContextMenuStrip";
            this.CameraTimerContextMenuStrip.Size = new System.Drawing.Size(129, 100);
            // 
            // TimerOffToolStripMenuItem
            // 
            this.TimerOffToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TimerOffToolStripMenuItem.Name = "TimerOffToolStripMenuItem";
            this.TimerOffToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.TimerOffToolStripMenuItem.Text = "Off";
            // 
            // TwoSecondToolStripMenuItem
            // 
            this.TwoSecondToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TwoSecondToolStripMenuItem.Name = "TwoSecondToolStripMenuItem";
            this.TwoSecondToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.TwoSecondToolStripMenuItem.Text = "2 Sec";
            // 
            // FiveSecondToolStripMenuItem
            // 
            this.FiveSecondToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FiveSecondToolStripMenuItem.Name = "FiveSecondToolStripMenuItem";
            this.FiveSecondToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.FiveSecondToolStripMenuItem.Text = "5 Sec";
            // 
            // TenSecondToolStripMenuItem
            // 
            this.TenSecondToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TenSecondToolStripMenuItem.Name = "TenSecondToolStripMenuItem";
            this.TenSecondToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.TenSecondToolStripMenuItem.Text = "10 Sec";
            // 
            // UserImageTakenPictureBox
            // 
            this.UserImageTakenPictureBox.BackColor = System.Drawing.Color.Black;
            this.UserImageTakenPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UserImageTakenPictureBox.Location = new System.Drawing.Point(670, 110);
            this.UserImageTakenPictureBox.Name = "UserImageTakenPictureBox";
            this.UserImageTakenPictureBox.Size = new System.Drawing.Size(640, 480);
            this.UserImageTakenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserImageTakenPictureBox.TabIndex = 10;
            this.UserImageTakenPictureBox.TabStop = false;
            this.UserImageTakenPictureBox.Click += new System.EventHandler(this.UserImageTakenPictureBox_Click);
            this.UserImageTakenPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.UserImageTakenPictureBox_Paint);
            this.UserImageTakenPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserImageTakenPictureBox_MouseDown);
            this.UserImageTakenPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserImageTakenPictureBox_MouseMove);
            // 
            // UserVideoPictureBox
            // 
            this.UserVideoPictureBox.BackColor = System.Drawing.Color.Black;
            this.UserVideoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UserVideoPictureBox.Location = new System.Drawing.Point(10, 110);
            this.UserVideoPictureBox.Name = "UserVideoPictureBox";
            this.UserVideoPictureBox.Size = new System.Drawing.Size(640, 480);
            this.UserVideoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserVideoPictureBox.TabIndex = 9;
            this.UserVideoPictureBox.TabStop = false;
            this.UserVideoPictureBox.Click += new System.EventHandler(this.UserVideoPictureBox_Click);
            // 
            // CameraOpenTimer
            // 
            this.CameraOpenTimer.Interval = 500;
            this.CameraOpenTimer.Tick += new System.EventHandler(this.CameraOpenTimer_Tick);
            // 
            // ReturnCustomButton
            // 
            this.ReturnCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ReturnCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.ReturnCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.returnArrow;
            this.ReturnCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReturnCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ReturnCustomButton.BorderRadius = 5;
            this.ReturnCustomButton.BorderSize = 0;
            this.ReturnCustomButton.Circular = false;
            this.ReturnCustomButton.FlatAppearance.BorderSize = 0;
            this.ReturnCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnCustomButton.ForeColor = System.Drawing.Color.White;
            this.ReturnCustomButton.Location = new System.Drawing.Point(5, 5);
            this.ReturnCustomButton.Name = "ReturnCustomButton";
            this.ReturnCustomButton.Size = new System.Drawing.Size(70, 30);
            this.ReturnCustomButton.TabIndex = 9;
            this.ReturnCustomButton.TextColor = System.Drawing.Color.White;
            this.ReturnCustomButton.UseVisualStyleBackColor = false;
            this.ReturnCustomButton.Click += new System.EventHandler(this.ReturnCustomButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.ReturnCustomButton);
            this.panel1.Controls.Add(this.ImageTakerCustomButton);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 90);
            this.panel1.TabIndex = 11;
            // 
            // Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1319, 761);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UserImageTakenPictureBox);
            this.Controls.Add(this.UserVideoPictureBox);
            this.Controls.Add(this.BackgroundPanel);
            this.Name = "Camera";
            this.Text = "Camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Camera_FormClosing);
            this.Load += new System.EventHandler(this.Camera_Load);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Camera_MouseWheel);
            this.BackgroundPanel.ResumeLayout(false);
            this.MethodsGroupBox.ResumeLayout(false);
            this.TimerGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CropGroupBox.ResumeLayout(false);
            this.CropGroupBox.PerformLayout();
            this.VideoDeviceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).EndInit();
            this.CameraTimerContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserImageTakenPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserVideoPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CameraDeviceComboBox;
        private System.Windows.Forms.PictureBox CameraDevicePictureBox;
        private Controls.CustomButton CameraModeCustomButton;
        private Controls.CustomButton RefreshCameraOptionsCustomButton;
        private System.Windows.Forms.PictureBox UserVideoPictureBox;
        private System.Windows.Forms.Panel BackgroundPanel;
        private System.Windows.Forms.PictureBox UserImageTakenPictureBox;
        private Controls.CustomButton ImageTakerCustomButton;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ContextMenuStrip CameraTimerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TimerOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TwoSecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FiveSecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TenSecondToolStripMenuItem;
        private System.Windows.Forms.ComboBox TimerOptionComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.CustomButton SaveImageCustomButton;
        private Controls.CustomButton CropImageCustomButton;
        private System.Windows.Forms.HScrollBar CropSizeHorizontalScrollBar;
        private System.Windows.Forms.Label CropSizeLabel;
        private System.Windows.Forms.Label CropXLocationLabel;
        private System.Windows.Forms.Label CropYLocationLabel;
        private Controls.CustomTextBox CropSizeCustomTextBox;
        private Controls.CustomTextBox CropYLocationustomTextBox;
        private Controls.CustomTextBox CropXLocationustomTextBox;
        private System.Windows.Forms.HScrollBar CropYLocationHorizontalScrollBar;
        private System.Windows.Forms.HScrollBar CropXLocationHorizontalScrollBar;
        private System.Windows.Forms.GroupBox VideoDeviceGroupBox;
        private System.Windows.Forms.GroupBox CropGroupBox;
        private System.Windows.Forms.GroupBox TimerGroupBox;
        private System.Windows.Forms.GroupBox MethodsGroupBox;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Timer CameraOpenTimer;
        private Controls.CustomButton ReturnCustomButton;
        private System.Windows.Forms.Panel panel1;
    }
}