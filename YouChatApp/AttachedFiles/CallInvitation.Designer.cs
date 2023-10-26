namespace YouChatApp.AttachedFiles
{
    partial class CallInvitation
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
            this.ContentLabel = new System.Windows.Forms.Label();
            this.FriendInformationPanel = new System.Windows.Forms.Panel();
            this.FriendCircularPictureBox = new YouChatApp.CircularPictureBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MessageSenderCustomButton = new YouChatApp.Controls.CustomButton();
            this.DeclineCallCustomButton = new YouChatApp.Controls.CustomButton();
            this.JoinCallCustomButton = new YouChatApp.Controls.CustomButton();
            this.OptionPanel = new System.Windows.Forms.Panel();
            this.FriendInformationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FriendCircularPictureBox)).BeginInit();
            this.OptionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentLabel
            // 
            this.ContentLabel.AutoSize = true;
            this.ContentLabel.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContentLabel.Location = new System.Drawing.Point(124, 25);
            this.ContentLabel.Name = "ContentLabel";
            this.ContentLabel.Size = new System.Drawing.Size(91, 26);
            this.ContentLabel.TabIndex = 1;
            this.ContentLabel.Text = "message";
            // 
            // FriendInformationPanel
            // 
            this.FriendInformationPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.FriendInformationPanel.Controls.Add(this.FriendCircularPictureBox);
            this.FriendInformationPanel.Controls.Add(this.ContentLabel);
            this.FriendInformationPanel.Location = new System.Drawing.Point(10, 10);
            this.FriendInformationPanel.Name = "FriendInformationPanel";
            this.FriendInformationPanel.Size = new System.Drawing.Size(350, 300);
            this.FriendInformationPanel.TabIndex = 4;
            // 
            // FriendCircularPictureBox
            // 
            this.FriendCircularPictureBox.BorderColor = System.Drawing.Color.Gray;
            this.FriendCircularPictureBox.BorderSize = 1;
            this.FriendCircularPictureBox.HasBorder = false;
            this.FriendCircularPictureBox.Image = global::YouChatApp.Properties.Resources.AnonymousProfile;
            this.FriendCircularPictureBox.Location = new System.Drawing.Point(75, 75);
            this.FriendCircularPictureBox.Name = "FriendCircularPictureBox";
            this.FriendCircularPictureBox.Size = new System.Drawing.Size(200, 200);
            this.FriendCircularPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FriendCircularPictureBox.TabIndex = 0;
            this.FriendCircularPictureBox.TabStop = false;
            this.FriendCircularPictureBox.Click += new System.EventHandler(this.FriendCircularPictureBox_Click);
            // 
            // MessageSenderCustomButton
            // 
            this.MessageSenderCustomButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.MessageSenderCustomButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.MessageSenderCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.ChatInCircle;
            this.MessageSenderCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MessageSenderCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.MessageSenderCustomButton.BorderRadius = 20;
            this.MessageSenderCustomButton.BorderSize = 0;
            this.MessageSenderCustomButton.Circular = false;
            this.MessageSenderCustomButton.FlatAppearance.BorderSize = 0;
            this.MessageSenderCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MessageSenderCustomButton.ForeColor = System.Drawing.Color.White;
            this.MessageSenderCustomButton.Location = new System.Drawing.Point(245, 10);
            this.MessageSenderCustomButton.Name = "MessageSenderCustomButton";
            this.MessageSenderCustomButton.Padding = new System.Windows.Forms.Padding(5);
            this.MessageSenderCustomButton.Size = new System.Drawing.Size(80, 80);
            this.MessageSenderCustomButton.TabIndex = 5;
            this.MessageSenderCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.MessageSenderCustomButton, "To decline the call and send a message");
            this.MessageSenderCustomButton.UseVisualStyleBackColor = false;
            this.MessageSenderCustomButton.Click += new System.EventHandler(this.MessageSenderCustomButton_Click);
            // 
            // DeclineCallCustomButton
            // 
            this.DeclineCallCustomButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.DeclineCallCustomButton.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.DeclineCallCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.DeclineCallFinalImage;
            this.DeclineCallCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeclineCallCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.DeclineCallCustomButton.BorderRadius = 20;
            this.DeclineCallCustomButton.BorderSize = 0;
            this.DeclineCallCustomButton.Circular = false;
            this.DeclineCallCustomButton.FlatAppearance.BorderSize = 0;
            this.DeclineCallCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeclineCallCustomButton.ForeColor = System.Drawing.Color.White;
            this.DeclineCallCustomButton.Location = new System.Drawing.Point(25, 10);
            this.DeclineCallCustomButton.Name = "DeclineCallCustomButton";
            this.DeclineCallCustomButton.Size = new System.Drawing.Size(80, 80);
            this.DeclineCallCustomButton.TabIndex = 3;
            this.DeclineCallCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.DeclineCallCustomButton, "To decline the call");
            this.DeclineCallCustomButton.UseVisualStyleBackColor = false;
            this.DeclineCallCustomButton.Click += new System.EventHandler(this.DeclineCallCustomButton_Click);
            // 
            // JoinCallCustomButton
            // 
            this.JoinCallCustomButton.BackColor = System.Drawing.Color.White;
            this.JoinCallCustomButton.BackgroundColor = System.Drawing.Color.White;
            this.JoinCallCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.JoinCallImage;
            this.JoinCallCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.JoinCallCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.JoinCallCustomButton.BorderRadius = 20;
            this.JoinCallCustomButton.BorderSize = 0;
            this.JoinCallCustomButton.Circular = false;
            this.JoinCallCustomButton.FlatAppearance.BorderSize = 0;
            this.JoinCallCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinCallCustomButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.JoinCallCustomButton.Location = new System.Drawing.Point(135, 10);
            this.JoinCallCustomButton.Name = "JoinCallCustomButton";
            this.JoinCallCustomButton.Size = new System.Drawing.Size(80, 80);
            this.JoinCallCustomButton.TabIndex = 2;
            this.JoinCallCustomButton.TextColor = System.Drawing.SystemColors.ControlText;
            this.ToolTip.SetToolTip(this.JoinCallCustomButton, "To join the call");
            this.JoinCallCustomButton.UseVisualStyleBackColor = false;
            this.JoinCallCustomButton.Click += new System.EventHandler(this.JoinCallCustomButton_Click);
            // 
            // OptionPanel
            // 
            this.OptionPanel.BackColor = System.Drawing.Color.Black;
            this.OptionPanel.Controls.Add(this.JoinCallCustomButton);
            this.OptionPanel.Controls.Add(this.MessageSenderCustomButton);
            this.OptionPanel.Controls.Add(this.DeclineCallCustomButton);
            this.OptionPanel.Location = new System.Drawing.Point(10, 310);
            this.OptionPanel.Name = "OptionPanel";
            this.OptionPanel.Size = new System.Drawing.Size(350, 100);
            this.OptionPanel.TabIndex = 6;
            // 
            // CallInvitation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(370, 420);
            this.Controls.Add(this.OptionPanel);
            this.Controls.Add(this.FriendInformationPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CallInvitation";
            this.Text = "CallInvitation";
            this.Load += new System.EventHandler(this.CallInvitation_Load);
            this.FriendInformationPanel.ResumeLayout(false);
            this.FriendInformationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FriendCircularPictureBox)).EndInit();
            this.OptionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CircularPictureBox FriendCircularPictureBox;
        private System.Windows.Forms.Label ContentLabel;
        private Controls.CustomButton JoinCallCustomButton;
        private Controls.CustomButton DeclineCallCustomButton;
        private System.Windows.Forms.Panel FriendInformationPanel;
        private System.Windows.Forms.ToolTip ToolTip;
        private Controls.CustomButton MessageSenderCustomButton;
        private Controls.CustomButton customButton3;
        private System.Windows.Forms.Panel OptionPanel;
    }
}