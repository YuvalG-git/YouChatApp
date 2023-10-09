﻿namespace YouChatApp
{
    partial class ChatControl
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
            this.ProfilePictureCircularPictureBox = new YouChatApp.CircularPictureBox();
            this.ChatNameLabel = new System.Windows.Forms.Label();
            this.LastMessageLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.OptionalMessageOrAddUserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).BeginInit();
            this.SuspendLayout();
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
            // LastMessageLabel
            // 
            this.LastMessageLabel.AutoSize = true;
            this.LastMessageLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastMessageLabel.Location = new System.Drawing.Point(80, 45);
            this.LastMessageLabel.MaximumSize = new System.Drawing.Size(175, 0);
            this.LastMessageLabel.Name = "LastMessageLabel";
            this.LastMessageLabel.Size = new System.Drawing.Size(95, 15);
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
            // OptionalMessageOrAddUserButton
            // 
            this.OptionalMessageOrAddUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionalMessageOrAddUserButton.Location = new System.Drawing.Point(264, 54);
            this.OptionalMessageOrAddUserButton.Name = "OptionalMessageOrAddUserButton";
            this.OptionalMessageOrAddUserButton.Size = new System.Drawing.Size(33, 23);
            this.OptionalMessageOrAddUserButton.TabIndex = 4;
            this.OptionalMessageOrAddUserButton.UseVisualStyleBackColor = true;
            this.OptionalMessageOrAddUserButton.Visible = false;
            this.OptionalMessageOrAddUserButton.Click += new System.EventHandler(this.OptionalMessageOrAddUserButton_Click);
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OptionalMessageOrAddUserButton);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.LastMessageLabel);
            this.Controls.Add(this.ChatNameLabel);
            this.Controls.Add(this.ProfilePictureCircularPictureBox);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(300, 80);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularPictureBox ProfilePictureCircularPictureBox;
        private System.Windows.Forms.Label ChatNameLabel;
        private System.Windows.Forms.Label LastMessageLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Button OptionalMessageOrAddUserButton;
    }
}