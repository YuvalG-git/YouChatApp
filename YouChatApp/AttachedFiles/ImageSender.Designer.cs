namespace YouChatApp.AttachedFiles
{
    partial class ImageSender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSender));
            this.UploadedPictureOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LoadedImagePictureBox = new System.Windows.Forms.PictureBox();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.ReturnCustomButton = new YouChatApp.Controls.CustomButton();
            this.RestartPictureCustomButton = new YouChatApp.Controls.CustomButton();
            this.SendPictureCustomButton = new YouChatApp.Controls.CustomButton();
            this.LoadPictureCustomButton = new YouChatApp.Controls.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.LoadedImagePictureBox)).BeginInit();
            this.SettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadedImagePictureBox
            // 
            this.LoadedImagePictureBox.BackColor = System.Drawing.Color.Black;
            this.LoadedImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LoadedImagePictureBox.Location = new System.Drawing.Point(10, 10);
            this.LoadedImagePictureBox.Name = "LoadedImagePictureBox";
            this.LoadedImagePictureBox.Size = new System.Drawing.Size(560, 400);
            this.LoadedImagePictureBox.TabIndex = 1;
            this.LoadedImagePictureBox.TabStop = false;
            this.LoadedImagePictureBox.Click += new System.EventHandler(this.LoadedImagePictureBox_Click);
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.BackColor = System.Drawing.Color.Black;
            this.SettingsPanel.Controls.Add(this.ReturnCustomButton);
            this.SettingsPanel.Controls.Add(this.RestartPictureCustomButton);
            this.SettingsPanel.Controls.Add(this.SendPictureCustomButton);
            this.SettingsPanel.Controls.Add(this.LoadPictureCustomButton);
            this.SettingsPanel.Location = new System.Drawing.Point(0, 431);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(585, 100);
            this.SettingsPanel.TabIndex = 40;
            // 
            // ReturnCustomButton
            // 
            this.ReturnCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ReturnCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.ReturnCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.returnArrow;
            this.ReturnCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReturnCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ReturnCustomButton.BorderRadius = 10;
            this.ReturnCustomButton.BorderSize = 0;
            this.ReturnCustomButton.Circular = false;
            this.ReturnCustomButton.FlatAppearance.BorderSize = 0;
            this.ReturnCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnCustomButton.ForeColor = System.Drawing.Color.White;
            this.ReturnCustomButton.Location = new System.Drawing.Point(11, 30);
            this.ReturnCustomButton.Name = "ReturnCustomButton";
            this.ReturnCustomButton.Size = new System.Drawing.Size(50, 40);
            this.ReturnCustomButton.TabIndex = 41;
            this.ReturnCustomButton.TextColor = System.Drawing.Color.White;
            this.ReturnCustomButton.UseVisualStyleBackColor = false;
            this.ReturnCustomButton.Click += new System.EventHandler(this.ReturnCustomButton_Click);
            // 
            // RestartPictureCustomButton
            // 
            this.RestartPictureCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.RestartPictureCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.RestartPictureCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RestartPictureCustomButton.BorderRadius = 10;
            this.RestartPictureCustomButton.BorderSize = 0;
            this.RestartPictureCustomButton.Circular = false;
            this.RestartPictureCustomButton.Enabled = false;
            this.RestartPictureCustomButton.FlatAppearance.BorderSize = 0;
            this.RestartPictureCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartPictureCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartPictureCustomButton.ForeColor = System.Drawing.Color.White;
            this.RestartPictureCustomButton.Location = new System.Drawing.Point(245, 30);
            this.RestartPictureCustomButton.Name = "RestartPictureCustomButton";
            this.RestartPictureCustomButton.Size = new System.Drawing.Size(150, 40);
            this.RestartPictureCustomButton.TabIndex = 41;
            this.RestartPictureCustomButton.Text = "RestartPicture";
            this.RestartPictureCustomButton.TextColor = System.Drawing.Color.White;
            this.RestartPictureCustomButton.UseVisualStyleBackColor = false;
            this.RestartPictureCustomButton.Click += new System.EventHandler(this.RestartPictureCustomButton_Click);
            // 
            // SendPictureCustomButton
            // 
            this.SendPictureCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.SendPictureCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.SendPictureCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.SendPictureCustomButton.BorderRadius = 10;
            this.SendPictureCustomButton.BorderSize = 0;
            this.SendPictureCustomButton.Circular = false;
            this.SendPictureCustomButton.Enabled = false;
            this.SendPictureCustomButton.FlatAppearance.BorderSize = 0;
            this.SendPictureCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendPictureCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendPictureCustomButton.ForeColor = System.Drawing.Color.White;
            this.SendPictureCustomButton.Location = new System.Drawing.Point(415, 30);
            this.SendPictureCustomButton.Name = "SendPictureCustomButton";
            this.SendPictureCustomButton.Size = new System.Drawing.Size(150, 40);
            this.SendPictureCustomButton.TabIndex = 40;
            this.SendPictureCustomButton.Text = "Send Picture";
            this.SendPictureCustomButton.TextColor = System.Drawing.Color.White;
            this.SendPictureCustomButton.UseVisualStyleBackColor = false;
            this.SendPictureCustomButton.Click += new System.EventHandler(this.SendPictureCustomButton_Click);
            // 
            // LoadPictureCustomButton
            // 
            this.LoadPictureCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.LoadPictureCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.LoadPictureCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.LoadPictureCustomButton.BorderRadius = 10;
            this.LoadPictureCustomButton.BorderSize = 0;
            this.LoadPictureCustomButton.Circular = false;
            this.LoadPictureCustomButton.FlatAppearance.BorderSize = 0;
            this.LoadPictureCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadPictureCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadPictureCustomButton.ForeColor = System.Drawing.Color.White;
            this.LoadPictureCustomButton.Location = new System.Drawing.Point(75, 30);
            this.LoadPictureCustomButton.Name = "LoadPictureCustomButton";
            this.LoadPictureCustomButton.Size = new System.Drawing.Size(150, 40);
            this.LoadPictureCustomButton.TabIndex = 39;
            this.LoadPictureCustomButton.Text = "Load Picture";
            this.LoadPictureCustomButton.TextColor = System.Drawing.Color.White;
            this.LoadPictureCustomButton.UseVisualStyleBackColor = false;
            this.LoadPictureCustomButton.Click += new System.EventHandler(this.LoadPictureCustomButton_Click);
            // 
            // ImageSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(580, 529);
            this.Controls.Add(this.LoadedImagePictureBox);
            this.Controls.Add(this.SettingsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageSender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageSender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageSender_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.LoadedImagePictureBox)).EndInit();
            this.SettingsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox LoadedImagePictureBox;
        private System.Windows.Forms.OpenFileDialog UploadedPictureOpenFileDialog;
        private System.Windows.Forms.Panel SettingsPanel;
        private Controls.CustomButton LoadPictureCustomButton;
        private Controls.CustomButton SendPictureCustomButton;
        private Controls.CustomButton RestartPictureCustomButton;
        private Controls.CustomButton ReturnCustomButton;
    }
}