namespace YouChatApp.Controls
{
    partial class ContactControl
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
            this.ContactNameLabel = new System.Windows.Forms.Label();
            this.ContactStatusLabel = new System.Windows.Forms.Label();
            this.ProfilePictureCircularPictureBox = new YouChatApp.CircularPictureBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ContactNameLabel
            // 
            this.ContactNameLabel.AutoEllipsis = true;
            this.ContactNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactNameLabel.Location = new System.Drawing.Point(92, 12);
            this.ContactNameLabel.Name = "ContactNameLabel";
            this.ContactNameLabel.Size = new System.Drawing.Size(200, 22);
            this.ContactNameLabel.TabIndex = 1;
            this.ContactNameLabel.Text = "Name";
            // 
            // ContactStatusLabel
            // 
            this.ContactStatusLabel.AutoEllipsis = true;
            this.ContactStatusLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactStatusLabel.Location = new System.Drawing.Point(93, 45);
            this.ContactStatusLabel.Name = "ContactStatusLabel";
            this.ContactStatusLabel.Size = new System.Drawing.Size(200, 15);
            this.ContactStatusLabel.TabIndex = 2;
            this.ContactStatusLabel.Text = "Status";
            // 
            // ProfilePictureCircularPictureBox
            // 
            this.ProfilePictureCircularPictureBox.HasBorder = false;
            this.ProfilePictureCircularPictureBox.Location = new System.Drawing.Point(10, 10);
            this.ProfilePictureCircularPictureBox.Name = "ProfilePictureCircularPictureBox";
            this.ProfilePictureCircularPictureBox.Size = new System.Drawing.Size(60, 60);
            this.ProfilePictureCircularPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfilePictureCircularPictureBox.TabIndex = 0;
            this.ProfilePictureCircularPictureBox.TabStop = false;
            // 
            // ContactControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContactStatusLabel);
            this.Controls.Add(this.ContactNameLabel);
            this.Controls.Add(this.ProfilePictureCircularPictureBox);
            this.Name = "ContactControl";
            this.Size = new System.Drawing.Size(325, 80);
            this.Load += new System.EventHandler(this.ContactControl_MouseLeave);
            this.MouseEnter += new System.EventHandler(this.ContactControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ContactControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CircularPictureBox ProfilePictureCircularPictureBox;
        private System.Windows.Forms.Label ContactNameLabel;
        private System.Windows.Forms.Label ContactStatusLabel;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}
