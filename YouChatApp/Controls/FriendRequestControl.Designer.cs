namespace YouChatApp.Controls
{
    partial class FriendRequestControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChatNameLabel = new System.Windows.Forms.Label();
            this.FriendMessageLabel = new System.Windows.Forms.Label();
            this.DenyFriendRequestCustomButton = new YouChatApp.Controls.CustomButton();
            this.AddFriendCustomButton = new YouChatApp.Controls.CustomButton();
            this.ProfilePictureCircularPictureBox = new YouChatApp.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChatNameLabel
            // 
            this.ChatNameLabel.AutoSize = true;
            this.ChatNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatNameLabel.Location = new System.Drawing.Point(80, 15);
            this.ChatNameLabel.Name = "ChatNameLabel";
            this.ChatNameLabel.Size = new System.Drawing.Size(63, 22);
            this.ChatNameLabel.TabIndex = 1;
            this.ChatNameLabel.Text = "Name";
            // 
            // FriendMessageLabel
            // 
            this.FriendMessageLabel.AutoSize = true;
            this.FriendMessageLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FriendMessageLabel.Location = new System.Drawing.Point(80, 40);
            this.FriendMessageLabel.Name = "FriendMessageLabel";
            this.FriendMessageLabel.Size = new System.Drawing.Size(129, 15);
            this.FriendMessageLabel.TabIndex = 2;
            this.FriendMessageLabel.Text = "wants to be friends";
            // 
            // DenyFriendRequestCustomButton
            // 
            this.DenyFriendRequestCustomButton.BackColor = System.Drawing.Color.Transparent;
            this.DenyFriendRequestCustomButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.DenyFriendRequestCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.Close;
            this.DenyFriendRequestCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DenyFriendRequestCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.DenyFriendRequestCustomButton.BorderRadius = 10;
            this.DenyFriendRequestCustomButton.BorderSize = 0;
            this.DenyFriendRequestCustomButton.FlatAppearance.BorderSize = 0;
            this.DenyFriendRequestCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DenyFriendRequestCustomButton.ForeColor = System.Drawing.Color.White;
            this.DenyFriendRequestCustomButton.Location = new System.Drawing.Point(210, 55);
            this.DenyFriendRequestCustomButton.Name = "DenyFriendRequestCustomButton";
            this.DenyFriendRequestCustomButton.Size = new System.Drawing.Size(30, 30);
            this.DenyFriendRequestCustomButton.TabIndex = 6;
            this.DenyFriendRequestCustomButton.TextColor = System.Drawing.Color.White;
            this.DenyFriendRequestCustomButton.UseVisualStyleBackColor = false;
            this.DenyFriendRequestCustomButton.Click += new System.EventHandler(this.DenyFriendRequestCustomButton_Click);
            // 
            // AddFriendCustomButton
            // 
            this.AddFriendCustomButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.AddFriendCustomButton.BackgroundColor = System.Drawing.Color.MediumTurquoise;
            this.AddFriendCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.AddFriendCustomButton.BorderRadius = 10;
            this.AddFriendCustomButton.BorderSize = 0;
            this.AddFriendCustomButton.FlatAppearance.BorderSize = 0;
            this.AddFriendCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFriendCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFriendCustomButton.ForeColor = System.Drawing.Color.White;
            this.AddFriendCustomButton.Location = new System.Drawing.Point(80, 55);
            this.AddFriendCustomButton.Name = "AddFriendCustomButton";
            this.AddFriendCustomButton.Size = new System.Drawing.Size(124, 30);
            this.AddFriendCustomButton.TabIndex = 5;
            this.AddFriendCustomButton.Text = "ADD FRIEND";
            this.AddFriendCustomButton.TextColor = System.Drawing.Color.White;
            this.AddFriendCustomButton.UseVisualStyleBackColor = false;
            this.AddFriendCustomButton.Click += new System.EventHandler(this.AddFriendCustomButton_Click);
            // 
            // ProfilePictureCircularPictureBox
            // 
            this.ProfilePictureCircularPictureBox.BackgroundImage = global::YouChatApp.Properties.Resources.AnonymousProfile;
            this.ProfilePictureCircularPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfilePictureCircularPictureBox.Image = global::YouChatApp.Properties.Resources.contact;
            this.ProfilePictureCircularPictureBox.Location = new System.Drawing.Point(10, 10);
            this.ProfilePictureCircularPictureBox.Name = "ProfilePictureCircularPictureBox";
            this.ProfilePictureCircularPictureBox.Size = new System.Drawing.Size(60, 60);
            this.ProfilePictureCircularPictureBox.TabIndex = 0;
            this.ProfilePictureCircularPictureBox.TabStop = false;
            // 
            // FriendRequestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DenyFriendRequestCustomButton);
            this.Controls.Add(this.AddFriendCustomButton);
            this.Controls.Add(this.FriendMessageLabel);
            this.Controls.Add(this.ChatNameLabel);
            this.Controls.Add(this.ProfilePictureCircularPictureBox);
            this.Name = "FriendRequestControl";
            this.Size = new System.Drawing.Size(300, 90);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularPictureBox ProfilePictureCircularPictureBox;
        private System.Windows.Forms.Label ChatNameLabel;
        private System.Windows.Forms.Label FriendMessageLabel;
        private CustomButton AddFriendCustomButton;
        private CustomButton DenyFriendRequestCustomButton;
    }
}
