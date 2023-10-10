namespace YouChatApp.Controls
{
    partial class ProfileControl
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
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ProfilePictureCircularPictureBox = new YouChatApp.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoEllipsis = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(0, 77);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(90, 13);
            this.UsernameLabel.TabIndex = 1;
            this.UsernameLabel.Text = "Name";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UsernameLabel.Click += new System.EventHandler(this.UsernameLabel_Click);
            // 
            // ProfilePictureCircularPictureBox
            // 
            this.ProfilePictureCircularPictureBox.BackgroundImage = global::YouChatApp.Properties.Resources.AnonymousProfile;
            this.ProfilePictureCircularPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ProfilePictureCircularPictureBox.HasBorder = true;
            this.ProfilePictureCircularPictureBox.Location = new System.Drawing.Point(0, 0);
            this.ProfilePictureCircularPictureBox.Name = "ProfilePictureCircularPictureBox";
            this.ProfilePictureCircularPictureBox.Size = new System.Drawing.Size(90, 90);
            this.ProfilePictureCircularPictureBox.TabIndex = 0;
            this.ProfilePictureCircularPictureBox.TabStop = false;
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.ProfilePictureCircularPictureBox);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(90, 90);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.ToolTip ToolTip;
        private CircularPictureBox ProfilePictureCircularPictureBox;
    }
}
