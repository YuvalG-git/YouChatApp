namespace YouChatApp
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
            this.components = new System.ComponentModel.Container();
            this.ProfilePictureCircularPictureBox = new YouChatApp.CircularPictureBox();
            this.ChatNameLabel = new System.Windows.Forms.Label();
            this.LastMessageLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.OptionalMessageOrAddUserButton = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ProfilePictureCustomPictureBox = new YouChatApp.Controls.CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCustomPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfilePictureCircularPictureBox
            // 
            this.ProfilePictureCircularPictureBox.BackgroundImage = global::YouChatApp.Properties.Resources.AnonymousProfile;
            this.ProfilePictureCircularPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfilePictureCircularPictureBox.BorderColor = System.Drawing.Color.Gray;
            this.ProfilePictureCircularPictureBox.BorderSize = 1;
            this.ProfilePictureCircularPictureBox.HasBorder = false;
            this.ProfilePictureCircularPictureBox.Location = new System.Drawing.Point(10, 10);
            this.ProfilePictureCircularPictureBox.Name = "ProfilePictureCircularPictureBox";
            this.ProfilePictureCircularPictureBox.Size = new System.Drawing.Size(60, 60);
            this.ProfilePictureCircularPictureBox.TabIndex = 0;
            this.ProfilePictureCircularPictureBox.TabStop = false;
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
            this.TimeLabel.TextChanged += new System.EventHandler(this.TimeLabel_TextChanged);
            // 
            // OptionalMessageOrAddUserButton
            // 
            this.OptionalMessageOrAddUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionalMessageOrAddUserButton.Location = new System.Drawing.Point(279, 54);
            this.OptionalMessageOrAddUserButton.Name = "OptionalMessageOrAddUserButton";
            this.OptionalMessageOrAddUserButton.Size = new System.Drawing.Size(33, 23);
            this.OptionalMessageOrAddUserButton.TabIndex = 4;
            this.OptionalMessageOrAddUserButton.UseVisualStyleBackColor = true;
            this.OptionalMessageOrAddUserButton.Visible = false;
            this.OptionalMessageOrAddUserButton.Click += new System.EventHandler(this.OptionalMessageOrAddUserButton_Click);
            // 
            // ProfilePictureCustomPictureBox
            // 
            this.ProfilePictureCustomPictureBox.BackgroundImage = global::YouChatApp.Properties.Resources.AnonymousProfile;
            this.ProfilePictureCustomPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfilePictureCustomPictureBox.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.ProfilePictureCustomPictureBox.BorderColor = System.Drawing.Color.RoyalBlue;
            this.ProfilePictureCustomPictureBox.BorderColor2 = System.Drawing.Color.HotPink;
            this.ProfilePictureCustomPictureBox.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ProfilePictureCustomPictureBox.BorderSize = 3;
            this.ProfilePictureCustomPictureBox.GradientAngle = 50F;
            this.ProfilePictureCustomPictureBox.Location = new System.Drawing.Point(10, 10);
            this.ProfilePictureCustomPictureBox.Name = "ProfilePictureCustomPictureBox";
            this.ProfilePictureCustomPictureBox.Size = new System.Drawing.Size(60, 60);
            this.ProfilePictureCustomPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilePictureCustomPictureBox.TabIndex = 5;
            this.ProfilePictureCustomPictureBox.TabStop = false;
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProfilePictureCustomPictureBox);
            this.Controls.Add(this.OptionalMessageOrAddUserButton);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.LastMessageLabel);
            this.Controls.Add(this.ChatNameLabel);
            this.Controls.Add(this.ProfilePictureCircularPictureBox);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(315, 80);
            this.Enter += new System.EventHandler(this.ChatControl_Enter);
            this.MouseEnter += new System.EventHandler(this.ChatControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ChatControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCustomPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularPictureBox ProfilePictureCircularPictureBox;
        private System.Windows.Forms.Label ChatNameLabel;
        private System.Windows.Forms.Label LastMessageLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Button OptionalMessageOrAddUserButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private Controls.CustomPictureBox ProfilePictureCustomPictureBox;
    }
}
