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
            this.AudioDeviceLabel = new System.Windows.Forms.Label();
            this.AudioDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.AudioDevicePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AudioDevicePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AudioDeviceLabel
            // 
            this.AudioDeviceLabel.AutoSize = true;
            this.AudioDeviceLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioDeviceLabel.Location = new System.Drawing.Point(499, 574);
            this.AudioDeviceLabel.Name = "AudioDeviceLabel";
            this.AudioDeviceLabel.Size = new System.Drawing.Size(189, 18);
            this.AudioDeviceLabel.TabIndex = 4;
            this.AudioDeviceLabel.Text = "Connect a microphone";
            // 
            // AudioDeviceComboBox
            // 
            this.AudioDeviceComboBox.FormattingEnabled = true;
            this.AudioDeviceComboBox.Location = new System.Drawing.Point(533, 595);
            this.AudioDeviceComboBox.Name = "AudioDeviceComboBox";
            this.AudioDeviceComboBox.Size = new System.Drawing.Size(121, 21);
            this.AudioDeviceComboBox.TabIndex = 6;
            // 
            // AudioDevicePictureBox
            // 
            this.AudioDevicePictureBox.Image = global::YouChatApp.Properties.Resources.Microphone;
            this.AudioDevicePictureBox.Location = new System.Drawing.Point(468, 574);
            this.AudioDevicePictureBox.Name = "AudioDevicePictureBox";
            this.AudioDevicePictureBox.Size = new System.Drawing.Size(25, 25);
            this.AudioDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AudioDevicePictureBox.TabIndex = 5;
            this.AudioDevicePictureBox.TabStop = false;
            // 
            // AudioCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 641);
            this.Controls.Add(this.AudioDeviceComboBox);
            this.Controls.Add(this.AudioDevicePictureBox);
            this.Controls.Add(this.AudioDeviceLabel);
            this.Name = "AudioCall";
            this.Text = "AudioCall";
            ((System.ComponentModel.ISupportInitialize)(this.AudioDevicePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label AudioDeviceLabel;
        private System.Windows.Forms.PictureBox AudioDevicePictureBox;
        private System.Windows.Forms.ComboBox AudioDeviceComboBox;
    }
}