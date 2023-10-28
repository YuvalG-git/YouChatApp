namespace YouChatApp
{
    partial class MessageControl
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
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.MenuBarPictureBox = new System.Windows.Forms.PictureBox();
            this.ProfilePictureCircularPictureBox = new YouChatApp.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MenuBarPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(50, 5);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(83, 20);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username";
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoEllipsis = true;
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(50, 25);
            this.MessageLabel.MaximumSize = new System.Drawing.Size(550, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(100, 25);
            this.MessageLabel.TabIndex = 1;
            this.MessageLabel.Text = "Message";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(148, 55);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(30, 13);
            this.TimeLabel.TabIndex = 2;
            this.TimeLabel.Text = "Time";
            // 
            // MenuBarPictureBox
            // 
            this.MenuBarPictureBox.BackgroundImage = global::YouChatApp.Properties.Resources.MenuBar;
            this.MenuBarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuBarPictureBox.Location = new System.Drawing.Point(170, 20);
            this.MenuBarPictureBox.Name = "MenuBarPictureBox";
            this.MenuBarPictureBox.Size = new System.Drawing.Size(20, 30);
            this.MenuBarPictureBox.TabIndex = 5;
            this.MenuBarPictureBox.TabStop = false;
            this.MenuBarPictureBox.Click += new System.EventHandler(this.MenuBarPictureBox_Click);
            // 
            // ProfilePictureCircularPictureBox
            // 
            this.ProfilePictureCircularPictureBox.BackgroundImage = global::YouChatApp.Properties.Resources.AnonymousProfile;
            this.ProfilePictureCircularPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfilePictureCircularPictureBox.BorderColor = System.Drawing.Color.Gray;
            this.ProfilePictureCircularPictureBox.BorderSize = 1;
            this.ProfilePictureCircularPictureBox.HasBorder = false;
            this.ProfilePictureCircularPictureBox.Location = new System.Drawing.Point(5, 10);
            this.ProfilePictureCircularPictureBox.Name = "ProfilePictureCircularPictureBox";
            this.ProfilePictureCircularPictureBox.Size = new System.Drawing.Size(40, 40);
            this.ProfilePictureCircularPictureBox.TabIndex = 3;
            this.ProfilePictureCircularPictureBox.TabStop = false;
            // 
            // MessageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.MenuBarPictureBox);
            this.Controls.Add(this.ProfilePictureCircularPictureBox);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.UsernameLabel);
            this.MaximumSize = new System.Drawing.Size(850, 0);
            this.MinimumSize = new System.Drawing.Size(175, 70);
            this.Name = "MessageControl";
            this.Size = new System.Drawing.Size(193, 70);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MessageControl_MouseDown);
            this.MouseEnter += new System.EventHandler(this.MessageControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MessageControl_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MessageControl_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.MenuBarPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label TimeLabel;
        private CircularPictureBox ProfilePictureCircularPictureBox;
        private System.Windows.Forms.PictureBox MenuBarPictureBox;
    }
}
