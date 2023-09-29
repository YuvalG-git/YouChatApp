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
            this.CameraModeButton = new System.Windows.Forms.Button();
            this.CameraDeviceLabel = new System.Windows.Forms.Label();
            this.AudioDeviceLabel = new System.Windows.Forms.Label();
            this.AudioDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.CameraDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.AudioDeviceComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.AudioDevicePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CameraDeviceComboBox
            // 
            this.CameraDeviceComboBox.FormattingEnabled = true;
            this.CameraDeviceComboBox.Location = new System.Drawing.Point(299, 399);
            this.CameraDeviceComboBox.Name = "CameraDeviceComboBox";
            this.CameraDeviceComboBox.Size = new System.Drawing.Size(121, 21);
            this.CameraDeviceComboBox.TabIndex = 0;
            // 
            // CameraModeButton
            // 
            this.CameraModeButton.Location = new System.Drawing.Point(738, 198);
            this.CameraModeButton.Name = "CameraModeButton";
            this.CameraModeButton.Size = new System.Drawing.Size(50, 50);
            this.CameraModeButton.TabIndex = 1;
            this.CameraModeButton.UseVisualStyleBackColor = true;
            // 
            // CameraDeviceLabel
            // 
            this.CameraDeviceLabel.AutoSize = true;
            this.CameraDeviceLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraDeviceLabel.Location = new System.Drawing.Point(282, 423);
            this.CameraDeviceLabel.Name = "CameraDeviceLabel";
            this.CameraDeviceLabel.Size = new System.Drawing.Size(155, 18);
            this.CameraDeviceLabel.TabIndex = 2;
            this.CameraDeviceLabel.Text = "Connect a camera";
            // 
            // AudioDeviceLabel
            // 
            this.AudioDeviceLabel.AutoSize = true;
            this.AudioDeviceLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioDeviceLabel.Location = new System.Drawing.Point(499, 423);
            this.AudioDeviceLabel.Name = "AudioDeviceLabel";
            this.AudioDeviceLabel.Size = new System.Drawing.Size(189, 18);
            this.AudioDeviceLabel.TabIndex = 4;
            this.AudioDeviceLabel.Text = "Connect a microphone";
            // 
            // AudioDevicePictureBox
            // 
            this.AudioDevicePictureBox.Image = global::YouChatApp.Properties.Resources.Microphone;
            this.AudioDevicePictureBox.Location = new System.Drawing.Point(468, 423);
            this.AudioDevicePictureBox.Name = "AudioDevicePictureBox";
            this.AudioDevicePictureBox.Size = new System.Drawing.Size(25, 25);
            this.AudioDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AudioDevicePictureBox.TabIndex = 5;
            this.AudioDevicePictureBox.TabStop = false;
            // 
            // CameraDevicePictureBox
            // 
            this.CameraDevicePictureBox.Image = global::YouChatApp.Properties.Resources.CameraLens;
            this.CameraDevicePictureBox.Location = new System.Drawing.Point(260, 423);
            this.CameraDevicePictureBox.Name = "CameraDevicePictureBox";
            this.CameraDevicePictureBox.Size = new System.Drawing.Size(25, 25);
            this.CameraDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CameraDevicePictureBox.TabIndex = 3;
            this.CameraDevicePictureBox.TabStop = false;
            // 
            // AudioDeviceComboBox
            // 
            this.AudioDeviceComboBox.FormattingEnabled = true;
            this.AudioDeviceComboBox.Location = new System.Drawing.Point(518, 399);
            this.AudioDeviceComboBox.Name = "AudioDeviceComboBox";
            this.AudioDeviceComboBox.Size = new System.Drawing.Size(121, 21);
            this.AudioDeviceComboBox.TabIndex = 6;
            this.AudioDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioDeviceComboBox_SelectedIndexChanged);
            // 
            // VideoCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AudioDeviceComboBox);
            this.Controls.Add(this.AudioDevicePictureBox);
            this.Controls.Add(this.AudioDeviceLabel);
            this.Controls.Add(this.CameraDevicePictureBox);
            this.Controls.Add(this.CameraDeviceLabel);
            this.Controls.Add(this.CameraModeButton);
            this.Controls.Add(this.CameraDeviceComboBox);
            this.Name = "VideoCall";
            this.Text = "VideoCall";
            ((System.ComponentModel.ISupportInitialize)(this.AudioDevicePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDevicePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CameraDeviceComboBox;
        private System.Windows.Forms.Button CameraModeButton;
        private System.Windows.Forms.Label CameraDeviceLabel;
        private System.Windows.Forms.PictureBox CameraDevicePictureBox;
        private System.Windows.Forms.Label AudioDeviceLabel;
        private System.Windows.Forms.PictureBox AudioDevicePictureBox;
        private System.Windows.Forms.ComboBox AudioDeviceComboBox;
    }
}