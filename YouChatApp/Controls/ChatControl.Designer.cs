namespace YouChatApp
{
    partial class ChatControl
    {

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ChatNameLabel = new System.Windows.Forms.Label();
            this.LastMessageLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ProfilePicturePictureBox = new YouChatApp.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicturePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChatNameLabel
            // 
            this.ChatNameLabel.AutoEllipsis = true;
            this.ChatNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatNameLabel.Location = new System.Drawing.Point(80, 15);
            this.ChatNameLabel.MaximumSize = new System.Drawing.Size(165, 22);
            this.ChatNameLabel.MinimumSize = new System.Drawing.Size(165, 22);
            this.ChatNameLabel.Name = "ChatNameLabel";
            this.ChatNameLabel.Size = new System.Drawing.Size(165, 22);
            this.ChatNameLabel.TabIndex = 1;
            this.ChatNameLabel.Text = "Name";
            // 
            // LastMessageLabel
            // 
            this.LastMessageLabel.AutoEllipsis = true;
            this.LastMessageLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastMessageLabel.Location = new System.Drawing.Point(81, 44);
            this.LastMessageLabel.MaximumSize = new System.Drawing.Size(175, 17);
            this.LastMessageLabel.MinimumSize = new System.Drawing.Size(175, 17);
            this.LastMessageLabel.Name = "LastMessageLabel";
            this.LastMessageLabel.Size = new System.Drawing.Size(175, 17);
            this.LastMessageLabel.TabIndex = 2;
            this.LastMessageLabel.Text = "Last Message";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(260, 15);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(36, 14);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = "Time";
            // 
            // ProfilePicturePictureBox
            // 
            this.ProfilePicturePictureBox.BackgroundImage = global::YouChatApp.Properties.Resources.AnonymousProfile;
            this.ProfilePicturePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfilePicturePictureBox.BorderColor = System.Drawing.Color.Gray;
            this.ProfilePicturePictureBox.BorderSize = 1;
            this.ProfilePicturePictureBox.HasBorder = false;
            this.ProfilePicturePictureBox.Location = new System.Drawing.Point(10, 10);
            this.ProfilePicturePictureBox.Name = "ProfilePicturePictureBox";
            this.ProfilePicturePictureBox.Size = new System.Drawing.Size(60, 60);
            this.ProfilePicturePictureBox.TabIndex = 6;
            this.ProfilePicturePictureBox.TabStop = false;
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProfilePicturePictureBox);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.LastMessageLabel);
            this.Controls.Add(this.ChatNameLabel);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(315, 80);
            this.MouseEnter += new System.EventHandler(this.ChatControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ChatControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicturePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.ComponentModel.IContainer components;
        private CircularPictureBox ProfilePictureCircularPictureBox;
        private System.Windows.Forms.Label ChatNameLabel;
        private System.Windows.Forms.Label LastMessageLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.ToolTip ToolTip;
        private CircularPictureBox ProfilePicturePictureBox;
    }
}
