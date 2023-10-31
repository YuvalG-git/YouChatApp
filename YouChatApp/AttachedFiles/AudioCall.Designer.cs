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
            this.AudioOutputDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshAudioOutputOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.AudioOutputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.AudioOutputDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.AudioInputDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshAudioInputOptionsCustomButton = new YouChatApp.Controls.CustomButton();
            this.AudioInputDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.AudioInputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.BackgroundPanel.SuspendLayout();
            this.AudioOutputDeviceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioOutputDevicePictureBox)).BeginInit();
            this.AudioInputDeviceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioInputDevicePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundPanel
            // 
            this.BackgroundPanel.BackColor = System.Drawing.Color.Black;
            this.BackgroundPanel.Controls.Add(this.AudioOutputDeviceGroupBox);
            this.BackgroundPanel.Controls.Add(this.AudioInputDeviceGroupBox);
            this.BackgroundPanel.Location = new System.Drawing.Point(50, 452);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(720, 130);
            this.BackgroundPanel.TabIndex = 8;
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
            // 
            // AudioOutputDeviceComboBox
            // 
            this.AudioOutputDeviceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioOutputDeviceComboBox.FormattingEnabled = true;
            this.AudioOutputDeviceComboBox.Location = new System.Drawing.Point(38, 41);
            this.AudioOutputDeviceComboBox.Name = "AudioOutputDeviceComboBox";
            this.AudioOutputDeviceComboBox.Size = new System.Drawing.Size(145, 28);
            this.AudioOutputDeviceComboBox.TabIndex = 6;
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
            // 
            // AudioCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 641);
            this.Controls.Add(this.BackgroundPanel);
            this.Name = "AudioCall";
            this.Text = "AudioCall";
            this.BackgroundPanel.ResumeLayout(false);
            this.AudioOutputDeviceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AudioOutputDevicePictureBox)).EndInit();
            this.AudioInputDeviceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AudioInputDevicePictureBox)).EndInit();
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
    }
}